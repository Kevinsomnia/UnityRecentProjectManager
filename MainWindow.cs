using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace UnityRecentProjectManager {
    public partial class MainWindow : Form {
        private const string LIST_FORMATTING = "{0, -31}{1, 0}";
        private const string PATH_TO_UNITY_REG = @"Software\Unity Technologies\Unity Editor 5.x";
        private const string TARGET_VALUE_NAME = "RecentlyUsedProjectPaths-";

        private List<string> projectHashes;
        private List<string> projectPaths;
        private bool successfullyLoaded;

        public MainWindow() {
            // Initialize form designer.
            InitializeComponent();

            // Register form close event for saving.
            FormClosed += OnWindowClosed;

            // Initialize member variables.
            projectHashes = new List<string>(); // Store hash values assigned to project path registry values (by Unity).
            projectPaths = new List<string>();
            successfullyLoaded = false;

            // Load the registry values that contain the locations/paths of the projects.
            LoadRecentProjectPaths();
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
                for(int i = 0; i < projectPaths.Count; i++) {
                    string valName = TARGET_VALUE_NAME + i;
                    string valData = projectPaths[i];
                    byte[] encodedPath = Encoding.UTF8.GetBytes(valData);
                    unityEditorKey.SetValue(valName, encodedPath, RegistryValueKind.Binary);
                }

                unityEditorKey.Close();
                Console.WriteLine("Saved to registry...");
            }
        }

        private void LoadRecentProjectPaths() {
            RegistryKey unityEditorKey = Registry.CurrentUser.OpenSubKey(PATH_TO_UNITY_REG);

            if(unityEditorKey == null) {
                // The subkey for Unity Editor 5.x cannot be found. Is Unity installed?
                return;
            }

            // Clear project path list from memory.
            projectPaths.Clear();

            // Iterate through all values that start with RecentlyUsedProjectPaths.
            string[] valNames = unityEditorKey.GetValueNames();

            for(int i = 0; i < valNames.Length; i++) {
                if(valNames[i].StartsWith(TARGET_VALUE_NAME)) {
                    // Retrieve entire project path (encoded as binary by Unity).
                    byte[] fullPathBytes = (byte[])unityEditorKey.GetValue(valNames[i]);
                    string projectPath = Encoding.UTF8.GetString(fullPathBytes);
                    projectPaths.Add(projectPath);
                }
            }

            unityEditorKey.Dispose();
            successfullyLoaded = true;
            UpdateRecentProjectList();
        }

        private void UpdateRecentProjectList() {
            // Clear UI list.
            projectList.Items.Clear();

            // Add all project paths to UI list.
            for(int i = 0; i < projectPaths.Count; i++) {
                string fullPath = projectPaths[i];

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
            List<string> newPaths = new List<string>();

            for(int i = 0; i < projectPaths.Count; i++) {
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
                    newPaths.Add(projectPaths[i]);
                }
            }

            projectPaths = newPaths;
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
            string origPathTemp = projectPaths[swapA];
            projectPaths[swapA] = projectPaths[swapB];
            projectPaths[swapB] = origPathTemp;

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
            string origPathTemp = projectPaths[swapA];
            projectPaths[swapA] = projectPaths[swapB];
            projectPaths[swapB] = origPathTemp;

            // Update UI list.
            UpdateRecentProjectList();

            // Updated selection to moved element.
            projectList.SelectedIndex = swapB;
        }

        private void RevertBtn_Click(object sender, EventArgs e) {
            LoadRecentProjectPaths();
        }
    }
}
