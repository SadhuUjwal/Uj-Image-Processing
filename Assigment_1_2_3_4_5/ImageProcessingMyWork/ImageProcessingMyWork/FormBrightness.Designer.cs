namespace ImageProcessingMyWork
{
    partial class FormBrightness
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrightness = new System.Windows.Forms.TextBox();
            this.btnBright = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brightness (e.g 30 or -20)";
            // 
            // txtBrightness
            // 
            this.txtBrightness.Location = new System.Drawing.Point(165, 38);
            this.txtBrightness.Name = "txtBrightness";
            this.txtBrightness.Size = new System.Drawing.Size(105, 20);
            this.txtBrightness.TabIndex = 1;
            // 
            // btnBright
            // 
            this.btnBright.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBright.Location = new System.Drawing.Point(98, 64);
            this.btnBright.Name = "btnBright";
            this.btnBright.Size = new System.Drawing.Size(83, 25);
            this.btnBright.TabIndex = 2;
            this.btnBright.Text = "Bright";
            this.btnBright.UseVisualStyleBackColor = true;
            this.btnBright.Click += new System.EventHandler(this.btnBright_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(187, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormBrightness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 112);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBright);
            this.Controls.Add(this.txtBrightness);
            this.Controls.Add(this.label1);
            this.Name = "FormBrightness";
            this.Text = "FormBrightness";
            this.Load += new System.EventHandler(this.FormBrightness_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrightness;
        private System.Windows.Forms.Button btnBright;
        private System.Windows.Forms.Button btnCancel;
    }
}