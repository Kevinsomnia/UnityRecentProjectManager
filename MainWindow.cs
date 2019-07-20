using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace UnityRecentProjectManager {
    public partial class MainWindow : Form {
        private const string LIST_FORMATTING = "{0, -31}{1, 0}";
        private const string PATH_TO_UNITY_REG = @"Software\Unity Technologies\Unity Editor 5.x";
        private const string TARGET_VALUE_NAME = "RecentlyUsedProjectPaths";

        private List<ProjectEntry> projects;
        private bool successfullyLoaded;

        public MainWindow() {
            // Initialize form designer.
            InitializeComponent();

            // Register form close event for saving.
            FormClosed += OnWindowClosed;

            // Initialize member variables.
            projects = new List<ProjectEntry>();
            successfullyLoaded = false;

            // Load the registry values that contain the locations/paths of the projects.
            LoadRecentProjectPaths();
        }

        private void LoadRecentProjectPaths() {
            RegistryKey unityEditorKey = Registry.CurrentUser.OpenSubKey(PATH_TO_UNITY_REG);

            if(unityEditorKey == null) {
                // The subkey for Unity Editor 5.x cannot be found. Is Unity installed?
                return;
            }

            // Clear project path list from memory.
            projects.Clear();

            // Iterate through all values that start with RecentlyUsedProjectPaths.
            string[] valNames = unityEditorKey.GetValueNames();

            for(int i = 0; i < valNames.Length; i++) {
                if(valNames[i].StartsWith(TARGET_VALUE_NAME)) {
                    // Retrieve entire project path (encoded as binary by Unity).
                    byte[] fullPathBytes = (byte[])unityEditorKey.GetValue(valNames[i]);
                    string fullPath = Encoding.UTF8.GetString(fullPathBytes);

                    // Retrieve hashes.
                    int hashStart = valNames[i].LastIndexOf('-'); // Formatted like -1_h32183271...
                    string hash = string.Empty;

                    if(hashStart > -1)
                        hash = valNames[i].Substring(hashStart);

                    ProjectEntry proj = new ProjectEntry(fullPath, hash);
                    projects.Add(proj);
                }
            }

            unityEditorKey.Dispose();
            successfullyLoaded = true;
            UpdateRecentProjectList();
        }

        private void OnWindowClosed(object sender, FormClosedEventArgs e) {
            if(successfullyLoaded) {
                // Only write to registry if we successfully loaded it.
                RegistryKey unityEditorKey = Registry.CurrentUser.OpenSubKey(PATH_TO_UNITY_REG, true);
                string[] valueNames = unityEditorKey.GetValueNames();

                // Delete all existing values from registry.
                for(int i = 0; i < valueNames.Length; i++) {
                    if(valueNames[i].StartsWith(TARGET_VALUE_NAME)) {
                        unityEditorKey.DeleteValue(valueNames[i]);
                    }
                }

                // Write new/current list to registry.
                for(int i = 0; i < projects.Count; i++) {
                    ProjectEntry pe = projects[i];
                    string valName = TARGET_VALUE_NAME + pe.hash;
                    string valData = pe.fullPath;
                    byte[] encodedPath = Encoding.UTF8.GetBytes(valData);
                    unityEditorKey.SetValue(valName, encodedPath, RegistryValueKind.Binary);
                }

                unityEditorKey.Close();
            }
        }

        private void UpdateRecentProjectList() {
            // Clear UI list.
            projectList.Items.Clear();

            // Add all project paths to UI list.
            for(int i = 0; i < projects.Count; i++) {
                ProjectEntry pe = projects[i];
                string fullPath = pe.fullPath;

                // Get the last folder name in path and use it as project name.
                int lastSlash = fullPath.LastIndexOf('/');

                if(lastSlash > 0) {
                    int projectNameLength = fullPath.Length - lastSlash - 2; // We need to cut off last character (null terminator).
                    string projectName = fullPath.Substring(lastSlash + 1, projectNameLength); // Retrieve project name after last slash.
                    fullPath = fullPath.Substring(0, lastSlash); // Remove project name, along with last slash.
                    projectList.Items.Add(string.Format(LIST_FORMATTING, projectName, fullPath));
                }
                else {
                    projectList.Items.Add("Unable to parse project path.");
                }
            }
        }

        private void DeleteSelBtn_Click(object sender, EventArgs e) {
            List<ProjectEntry> newProjects = new List<ProjectEntry>();

            for(int i = 0; i < projects.Count; i++) {
                bool delete = false;

                for(int j = 0; j < projectList.SelectedIndices.Count; j++) {
                    int selectedIndex = projectList.SelectedIndices[j];

                    if(i == selectedIndex) {
                        delete = true;
                        break;
                    }
                }

                if(!delete) {
                    // Retain items that were not selected.
                    newProjects.Add(projects[i]);
                }
            }

            projects = newProjects;
            UpdateRecentProjectList();
        }

        private void MoveUpBtn_Click(object sender, EventArgs e) {
            if(projectList.SelectedIndices.Count != 1)
                return; // Must select exactly one item.

            if(projectList.SelectedIndex == 0)
                return; // Cannot move the first item up any more.

            // Swap this and the previous element.
            int swapA = projectList.SelectedIndex;
            int swapB = projectList.SelectedIndex - 1;
            string projPathTemp = projects[swapA].fullPath;
            projects[swapA].fullPath = projects[swapB].fullPath;
            projects[swapB].fullPath = projPathTemp;

            // Update UI list.
            UpdateRecentProjectList();

            // Updated selection to moved element.
            projectList.SelectedIndex = swapB;
        }

        private void MoveDownBtn_Click(object sender, EventArgs e) {
            if(projectList.SelectedIndices.Count != 1)
                return; // Must select exactly one item.

            if(projectList.SelectedIndex == projectList.Items.Count - 1)
                return; // Cannot move the last item down any more.

            // Swap this and the next element.
            int swapA = projectList.SelectedIndex;
            int swapB = projectList.SelectedIndex + 1;
            string projPathTemp = projects[swapA].fullPath;
            projects[swapA].fullPath = projects[swapB].fullPath;
            projects[swapB].fullPath = projPathTemp;

            // Update UI list.
            UpdateRecentProjectList();

            // Updated selection to moved element.
            projectList.SelectedIndex = swapB;
        }

        private void RevertBtn_Click(object sender, EventArgs e) {
            LoadRecentProjectPaths();
        }

        private void ProjectList_KeyDown(object sender, KeyEventArgs e) {
            if(e.Control && e.KeyCode == Keys.A) {
                for(int i = 0; i < projectList.Items.Count; i++) {
                    projectList.SetSelected(i, true);
                }

                e.SuppressKeyPress = true;
            }
        }
    }

    public class ProjectEntry {
        public string fullPath { get; set; }
        public string hash { get; private set; }

        public ProjectEntry(string path, string hash) {
            fullPath = path;
            this.hash = hash;
        }
    }
}
