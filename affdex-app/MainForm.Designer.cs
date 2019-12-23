namespace AffdexApp
{
    partial class MainForm
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
            this.ImagePicBox = new System.Windows.Forms.PictureBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.LogLabel = new System.Windows.Forms.Label();
            this.LogListView = new System.Windows.Forms.ListBox();
            this.ResultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagePicBox
            // 
            this.ImagePicBox.Location = new System.Drawing.Point(250, 12);
            this.ImagePicBox.Name = "ImagePicBox";
            this.ImagePicBox.Size = new System.Drawing.Size(437, 443);
            this.ImagePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePicBox.TabIndex = 0;
            this.ImagePicBox.TabStop = false;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(24, 12);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(89, 41);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(132, 12);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(93, 41);
            this.ProcessButton.TabIndex = 2;
            this.ProcessButton.Text = "Process";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(21, 73);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(25, 13);
            this.LogLabel.TabIndex = 4;
            this.LogLabel.Text = "Log";
            // 
            // LogListView
            // 
            this.LogListView.FormattingEnabled = true;
            this.LogListView.Location = new System.Drawing.Point(24, 90);
            this.LogListView.Name = "LogListView";
            this.LogListView.Size = new System.Drawing.Size(201, 95);
            this.LogListView.TabIndex = 5;
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(24, 241);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(0, 13);
            this.ResultLabel.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 467);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.LogListView);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.ImagePicBox);
            this.Name = "MainForm";
            this.Text = "Affdex App - Load an image";
            ((System.ComponentModel.ISupportInitialize)(this.ImagePicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagePicBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.ListBox LogListView;
        private System.Windows.Forms.Label ResultLabel;
    }
}

