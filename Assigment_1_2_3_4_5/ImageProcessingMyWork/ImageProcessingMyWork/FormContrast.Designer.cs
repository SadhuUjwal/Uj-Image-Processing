namespace ImageProcessingMyWork
{
    partial class FormContrast
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
            this.btnContrast = new System.Windows.Forms.Button();
            this.txtContrast = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contrast (e.g 30 or -20)";
            // 
            // btnContrast
            // 
            this.btnContrast.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContrast.Location = new System.Drawing.Point(60, 61);
            this.btnContrast.Name = "btnContrast";
            this.btnContrast.Size = new System.Drawing.Size(88, 19);
            this.btnContrast.TabIndex = 1;
            this.btnContrast.Text = "Contrast";
            this.btnContrast.UseVisualStyleBackColor = true;
            // 
            // txtContrast
            // 
            this.txtContrast.Location = new System.Drawing.Point(133, 32);
            this.txtContrast.Name = "txtContrast";
            this.txtContrast.Size = new System.Drawing.Size(109, 20);
            this.txtContrast.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(154, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 19);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormContrast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 97);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtContrast);
            this.Controls.Add(this.btnContrast);
            this.Controls.Add(this.label1);
            this.Name = "FormContrast";
            this.Text = "FormContrast";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnContrast;
        private System.Windows.Forms.TextBox txtContrast;
        private System.Windows.Forms.Button btnCancel;
    }
}