namespace LBPFaceRecognition
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
            this.pbxSrc = new System.Windows.Forms.PictureBox();
            this.pbxMatched = new System.Windows.Forms.PictureBox();
            this.lblSrc = new System.Windows.Forms.Label();
            this.lblMatched = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnMatch = new System.Windows.Forms.Button();
            this.lblTrainedPath = new System.Windows.Forms.Label();
            this.txtTrainingPath = new System.Windows.Forms.TextBox();
            this.btnTrainingPath = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnTestPath = new System.Windows.Forms.Button();
            this.txtTestPath = new System.Windows.Forms.TextBox();
            this.lblTestPath = new System.Windows.Forms.Label();
            this.btnRate = new System.Windows.Forms.Button();
            this.txtRate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMatched)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxSrc
            // 
            this.pbxSrc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxSrc.Location = new System.Drawing.Point(24, 105);
            this.pbxSrc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbxSrc.Name = "pbxSrc";
            this.pbxSrc.Size = new System.Drawing.Size(357, 356);
            this.pbxSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSrc.TabIndex = 0;
            this.pbxSrc.TabStop = false;
            // 
            // pbxMatched
            // 
            this.pbxMatched.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxMatched.Location = new System.Drawing.Point(408, 105);
            this.pbxMatched.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbxMatched.Name = "pbxMatched";
            this.pbxMatched.Size = new System.Drawing.Size(357, 356);
            this.pbxMatched.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxMatched.TabIndex = 2;
            this.pbxMatched.TabStop = false;
            // 
            // lblSrc
            // 
            this.lblSrc.AutoSize = true;
            this.lblSrc.Location = new System.Drawing.Point(24, 65);
            this.lblSrc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSrc.Name = "lblSrc";
            this.lblSrc.Size = new System.Drawing.Size(53, 17);
            this.lblSrc.TabIndex = 3;
            this.lblSrc.Text = "Source";
            // 
            // lblMatched
            // 
            this.lblMatched.AutoSize = true;
            this.lblMatched.Location = new System.Drawing.Point(421, 65);
            this.lblMatched.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatched.Name = "lblMatched";
            this.lblMatched.Size = new System.Drawing.Size(62, 17);
            this.lblMatched.TabIndex = 5;
            this.lblMatched.Text = "Matched";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(137, 470);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 28);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.OnSrcOpenClicked);
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(533, 469);
            this.btnMatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(100, 28);
            this.btnMatch.TabIndex = 8;
            this.btnMatch.Text = "Match";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // lblTrainedPath
            // 
            this.lblTrainedPath.AutoSize = true;
            this.lblTrainedPath.Location = new System.Drawing.Point(24, 27);
            this.lblTrainedPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrainedPath.Name = "lblTrainedPath";
            this.lblTrainedPath.Size = new System.Drawing.Size(93, 17);
            this.lblTrainedPath.TabIndex = 9;
            this.lblTrainedPath.Text = "Training Path";
            // 
            // txtTrainingPath
            // 
            this.txtTrainingPath.Location = new System.Drawing.Point(137, 23);
            this.txtTrainingPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTrainingPath.Name = "txtTrainingPath";
            this.txtTrainingPath.ReadOnly = true;
            this.txtTrainingPath.Size = new System.Drawing.Size(547, 22);
            this.txtTrainingPath.TabIndex = 10;
            this.txtTrainingPath.TextChanged += new System.EventHandler(this.txtTrainingPath_TextChanged);
            // 
            // btnTrainingPath
            // 
            this.btnTrainingPath.Location = new System.Drawing.Point(693, 21);
            this.btnTrainingPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTrainingPath.Name = "btnTrainingPath";
            this.btnTrainingPath.Size = new System.Drawing.Size(44, 28);
            this.btnTrainingPath.TabIndex = 11;
            this.btnTrainingPath.Text = "...";
            this.btnTrainingPath.UseVisualStyleBackColor = true;
            this.btnTrainingPath.Click += new System.EventHandler(this.OnTrainingPathAdded);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 597);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(783, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(111, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // btnTestPath
            // 
            this.btnTestPath.Location = new System.Drawing.Point(619, 518);
            this.btnTestPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestPath.Name = "btnTestPath";
            this.btnTestPath.Size = new System.Drawing.Size(44, 28);
            this.btnTestPath.TabIndex = 15;
            this.btnTestPath.Text = "...";
            this.btnTestPath.UseVisualStyleBackColor = true;
            this.btnTestPath.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTestPath
            // 
            this.txtTestPath.Location = new System.Drawing.Point(137, 518);
            this.txtTestPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTestPath.Name = "txtTestPath";
            this.txtTestPath.ReadOnly = true;
            this.txtTestPath.Size = new System.Drawing.Size(472, 22);
            this.txtTestPath.TabIndex = 14;
            // 
            // lblTestPath
            // 
            this.lblTestPath.AutoSize = true;
            this.lblTestPath.Location = new System.Drawing.Point(16, 522);
            this.lblTestPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTestPath.Name = "lblTestPath";
            this.lblTestPath.Size = new System.Drawing.Size(118, 17);
            this.lblTestPath.TabIndex = 13;
            this.lblTestPath.Text = "Test Images Path";
            // 
            // btnRate
            // 
            this.btnRate.Location = new System.Drawing.Point(671, 518);
            this.btnRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRate.Name = "btnRate";
            this.btnRate.Size = new System.Drawing.Size(100, 28);
            this.btnRate.TabIndex = 16;
            this.btnRate.Text = "Rate";
            this.btnRate.UseVisualStyleBackColor = true;
            this.btnRate.Click += new System.EventHandler(this.btnRate_Click);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(671, 486);
            this.txtRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(100, 22);
            this.txtRate.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 622);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.btnRate);
            this.Controls.Add(this.btnTestPath);
            this.Controls.Add(this.txtTestPath);
            this.Controls.Add(this.lblTestPath);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnTrainingPath);
            this.Controls.Add(this.txtTrainingPath);
            this.Controls.Add(this.lblTrainedPath);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblMatched);
            this.Controls.Add(this.lblSrc);
            this.Controls.Add(this.pbxMatched);
            this.Controls.Add(this.pbxSrc);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMatched)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxSrc;
        private System.Windows.Forms.PictureBox pbxMatched;
        private System.Windows.Forms.Label lblSrc;
        private System.Windows.Forms.Label lblMatched;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Label lblTrainedPath;
        private System.Windows.Forms.TextBox txtTrainingPath;
        private System.Windows.Forms.Button btnTrainingPath;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Button btnTestPath;
        private System.Windows.Forms.TextBox txtTestPath;
        private System.Windows.Forms.Label lblTestPath;
        private System.Windows.Forms.Button btnRate;
        private System.Windows.Forms.TextBox txtRate;
    }
}

