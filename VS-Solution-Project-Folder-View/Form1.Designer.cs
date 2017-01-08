namespace VS_Solution_Project_Folder_View
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BrowseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderPathTextBox = new System.Windows.Forms.TextBox();
            this.GenerateViewButton = new System.Windows.Forms.Button();
            this.FolderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(755, 38);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(67, 23);
            this.BrowseButton.TabIndex = 0;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the Folder to create the HTML  View :";
            // 
            // FolderPathTextBox
            // 
            this.FolderPathTextBox.Enabled = false;
            this.FolderPathTextBox.Location = new System.Drawing.Point(12, 38);
            this.FolderPathTextBox.Name = "FolderPathTextBox";
            this.FolderPathTextBox.Size = new System.Drawing.Size(736, 20);
            this.FolderPathTextBox.TabIndex = 2;
            // 
            // GenerateViewButton
            // 
            this.GenerateViewButton.Location = new System.Drawing.Point(625, 67);
            this.GenerateViewButton.Name = "GenerateViewButton";
            this.GenerateViewButton.Size = new System.Drawing.Size(197, 23);
            this.GenerateViewButton.TabIndex = 3;
            this.GenerateViewButton.Text = "Generate structure view...";
            this.GenerateViewButton.UseVisualStyleBackColor = true;
            this.GenerateViewButton.Click += new System.EventHandler(this.GenerateViewButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 100);
            this.Controls.Add(this.GenerateViewButton);
            this.Controls.Add(this.FolderPathTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrowseButton);
            this.Name = "Form1";
            this.Text = "Solution structure view generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FolderPathTextBox;
        private System.Windows.Forms.Button GenerateViewButton;
        private System.Windows.Forms.FolderBrowserDialog FolderDlg;
    }
}

