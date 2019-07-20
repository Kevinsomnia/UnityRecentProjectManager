namespace UnityRecentProjectManager {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.deleteSelBtn = new System.Windows.Forms.Button();
            this.moveUpBtn = new System.Windows.Forms.Button();
            this.moveDownBtn = new System.Windows.Forms.Button();
            this.revertBtn = new System.Windows.Forms.Button();
            this.projNameLabel = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.projectList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // deleteSelBtn
            // 
            this.deleteSelBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.deleteSelBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.deleteSelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.deleteSelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.deleteSelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.deleteSelBtn.Location = new System.Drawing.Point(12, 404);
            this.deleteSelBtn.Name = "deleteSelBtn";
            this.deleteSelBtn.Size = new System.Drawing.Size(140, 25);
            this.deleteSelBtn.TabIndex = 1;
            this.deleteSelBtn.Text = "Delete Selected";
            this.deleteSelBtn.UseVisualStyleBackColor = true;
            this.deleteSelBtn.Click += new System.EventHandler(this.DeleteSelBtn_Click);
            // 
            // moveUpBtn
            // 
            this.moveUpBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.moveUpBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.moveUpBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.moveUpBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.moveUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveUpBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveUpBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.moveUpBtn.Location = new System.Drawing.Point(158, 404);
            this.moveUpBtn.Name = "moveUpBtn";
            this.moveUpBtn.Size = new System.Drawing.Size(100, 25);
            this.moveUpBtn.TabIndex = 2;
            this.moveUpBtn.Text = "Move Up";
            this.moveUpBtn.UseVisualStyleBackColor = true;
            this.moveUpBtn.Click += new System.EventHandler(this.MoveUpBtn_Click);
            // 
            // moveDownBtn
            // 
            this.moveDownBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.moveDownBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.moveDownBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.moveDownBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.moveDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveDownBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveDownBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.moveDownBtn.Location = new System.Drawing.Point(264, 404);
            this.moveDownBtn.Name = "moveDownBtn";
            this.moveDownBtn.Size = new System.Drawing.Size(100, 25);
            this.moveDownBtn.TabIndex = 3;
            this.moveDownBtn.Text = "Move Down";
            this.moveDownBtn.UseVisualStyleBackColor = true;
            this.moveDownBtn.Click += new System.EventHandler(this.MoveDownBtn_Click);
            // 
            // revertBtn
            // 
            this.revertBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.revertBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.revertBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.revertBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.revertBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.revertBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.revertBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.revertBtn.Location = new System.Drawing.Point(472, 404);
            this.revertBtn.Name = "revertBtn";
            this.revertBtn.Size = new System.Drawing.Size(140, 25);
            this.revertBtn.TabIndex = 4;
            this.revertBtn.Text = "Revert Changes";
            this.revertBtn.UseVisualStyleBackColor = true;
            this.revertBtn.Click += new System.EventHandler(this.RevertBtn_Click);
            // 
            // projNameLabel
            // 
            this.projNameLabel.AutoSize = true;
            this.projNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.projNameLabel.Location = new System.Drawing.Point(12, 9);
            this.projNameLabel.Name = "projNameLabel";
            this.projNameLabel.Size = new System.Drawing.Size(79, 15);
            this.projNameLabel.TabIndex = 500;
            this.projNameLabel.Text = "Project Name";
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.pathLabel.Location = new System.Drawing.Point(259, 9);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(31, 15);
            this.pathLabel.TabIndex = 501;
            this.pathLabel.Text = "Path";
            // 
            // projectList
            // 
            this.projectList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.projectList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectList.Font = new System.Drawing.Font("InputMono", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.projectList.FormattingEnabled = true;
            this.projectList.ItemHeight = 16;
            this.projectList.Location = new System.Drawing.Point(12, 27);
            this.projectList.Name = "projectList";
            this.projectList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.projectList.Size = new System.Drawing.Size(600, 368);
            this.projectList.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.projectList);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.projNameLabel);
            this.Controls.Add(this.revertBtn);
            this.Controls.Add(this.moveDownBtn);
            this.Controls.Add(this.moveUpBtn);
            this.Controls.Add(this.deleteSelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unity Recent Project Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button deleteSelBtn;
        private System.Windows.Forms.Button moveUpBtn;
        private System.Windows.Forms.Button moveDownBtn;
        private System.Windows.Forms.Button revertBtn;
        private System.Windows.Forms.Label projNameLabel;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.ListBox projectList;
    }
}

