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
            this.components = new System.ComponentModel.Container();
            this.ImagePicBox = new System.Windows.Forms.PictureBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DatasetComboBox = new System.Windows.Forms.ComboBox();
            this.LogListView = new System.Windows.Forms.ListBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LoadingProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.TimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePicBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.ImagePicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImagePicBox_MouseMove);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(9, 19);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(89, 41);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(114, 19);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(93, 41);
            this.ProcessButton.TabIndex = 2;
            this.ProcessButton.Text = "Process";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(9, 66);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTextBox.Size = new System.Drawing.Size(201, 114);
            this.ResultTextBox.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(232, 225);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseMove);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LoadButton);
            this.tabPage1.Controls.Add(this.ResultTextBox);
            this.tabPage1.Controls.Add(this.ProcessButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(224, 199);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Single Test";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.StartButton);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.DatasetComboBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(224, 199);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datasets";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(16, 75);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(121, 37);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dataset";
            // 
            // DatasetComboBox
            // 
            this.DatasetComboBox.DisplayMember = "0";
            this.DatasetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DatasetComboBox.FormattingEnabled = true;
            this.DatasetComboBox.Items.AddRange(new object[] {
            "LFW",
            "CelebA"});
            this.DatasetComboBox.Location = new System.Drawing.Point(16, 38);
            this.DatasetComboBox.Name = "DatasetComboBox";
            this.DatasetComboBox.Size = new System.Drawing.Size(121, 21);
            this.DatasetComboBox.TabIndex = 0;
            this.DatasetComboBox.SelectedIndexChanged += new System.EventHandler(this.DatasetComboBox_SelectedIndexChanged);
            // 
            // LogListView
            // 
            this.LogListView.FormattingEnabled = true;
            this.LogListView.Location = new System.Drawing.Point(16, 262);
            this.LogListView.Name = "LogListView";
            this.LogListView.Size = new System.Drawing.Size(224, 186);
            this.LogListView.TabIndex = 10;
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(13, 246);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(25, 13);
            this.LogLabel.TabIndex = 9;
            this.LogLabel.Text = "Log";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.LoadingProgressBar,
            this.TimeLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(698, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(16, 17);
            this.StatusLabel.Text = "Ы";
            // 
            // LoadingProgressBar
            // 
            this.LoadingProgressBar.MarqueeAnimationSpeed = 50;
            this.LoadingProgressBar.Name = "LoadingProgressBar";
            this.LoadingProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // TimeLabel
            // 
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.TimeLabel.Size = new System.Drawing.Size(79, 17);
            this.TimeLabel.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 467);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.LogListView);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ImagePicBox);
            this.Name = "MainForm";
            this.Text = "Affdex App - Load an image";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseHover += new System.EventHandler(this.MainForm_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePicBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagePicBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DatasetComboBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ListBox LogListView;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar LoadingProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel TimeLabel;
        private System.Windows.Forms.Timer timer1;
    }
}

