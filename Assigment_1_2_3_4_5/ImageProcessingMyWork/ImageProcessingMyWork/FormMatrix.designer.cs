namespace ImageProcessingMyWork
{
    partial class FormMatrix
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
            this.btnApplyUserFilter = new System.Windows.Forms.Button();
            this.txtBox33 = new System.Windows.Forms.TextBox();
            this.txtBox32 = new System.Windows.Forms.TextBox();
            this.txtBox31 = new System.Windows.Forms.TextBox();
            this.txtBox23 = new System.Windows.Forms.TextBox();
            this.txtBox22 = new System.Windows.Forms.TextBox();
            this.txtBox21 = new System.Windows.Forms.TextBox();
            this.txtBox13 = new System.Windows.Forms.TextBox();
            this.txtBox12 = new System.Windows.Forms.TextBox();
            this.lblKernel = new System.Windows.Forms.Label();
            this.txtBox11 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnApplyUserFilter
            // 
            this.btnApplyUserFilter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApplyUserFilter.Location = new System.Drawing.Point(77, 198);
            this.btnApplyUserFilter.Name = "btnApplyUserFilter";
            this.btnApplyUserFilter.Size = new System.Drawing.Size(107, 35);
            this.btnApplyUserFilter.TabIndex = 24;
            this.btnApplyUserFilter.Text = "Apply Filter";
            this.btnApplyUserFilter.UseVisualStyleBackColor = true;
            this.btnApplyUserFilter.Click += new System.EventHandler(this.btnApplyUserFilter_Click);
            // 
            // txtBox33
            // 
            this.txtBox33.Location = new System.Drawing.Point(153, 136);
            this.txtBox33.Multiline = true;
            this.txtBox33.Name = "txtBox33";
            this.txtBox33.Size = new System.Drawing.Size(31, 26);
            this.txtBox33.TabIndex = 23;
            // 
            // txtBox32
            // 
            this.txtBox32.Location = new System.Drawing.Point(116, 136);
            this.txtBox32.Multiline = true;
            this.txtBox32.Name = "txtBox32";
            this.txtBox32.Size = new System.Drawing.Size(31, 26);
            this.txtBox32.TabIndex = 22;
            // 
            // txtBox31
            // 
            this.txtBox31.Location = new System.Drawing.Point(79, 136);
            this.txtBox31.Multiline = true;
            this.txtBox31.Name = "txtBox31";
            this.txtBox31.Size = new System.Drawing.Size(31, 26);
            this.txtBox31.TabIndex = 21;
            // 
            // txtBox23
            // 
            this.txtBox23.Location = new System.Drawing.Point(153, 104);
            this.txtBox23.Multiline = true;
            this.txtBox23.Name = "txtBox23";
            this.txtBox23.Size = new System.Drawing.Size(31, 26);
            this.txtBox23.TabIndex = 20;
            // 
            // txtBox22
            // 
            this.txtBox22.Location = new System.Drawing.Point(116, 104);
            this.txtBox22.Multiline = true;
            this.txtBox22.Name = "txtBox22";
            this.txtBox22.Size = new System.Drawing.Size(31, 26);
            this.txtBox22.TabIndex = 19;
            // 
            // txtBox21
            // 
            this.txtBox21.Location = new System.Drawing.Point(79, 104);
            this.txtBox21.Multiline = true;
            this.txtBox21.Name = "txtBox21";
            this.txtBox21.Size = new System.Drawing.Size(31, 26);
            this.txtBox21.TabIndex = 18;
            // 
            // txtBox13
            // 
            this.txtBox13.Location = new System.Drawing.Point(153, 72);
            this.txtBox13.Multiline = true;
            this.txtBox13.Name = "txtBox13";
            this.txtBox13.Size = new System.Drawing.Size(31, 26);
            this.txtBox13.TabIndex = 17;
            // 
            // txtBox12
            // 
            this.txtBox12.Location = new System.Drawing.Point(116, 72);
            this.txtBox12.Multiline = true;
            this.txtBox12.Name = "txtBox12";
            this.txtBox12.Size = new System.Drawing.Size(31, 26);
            this.txtBox12.TabIndex = 16;
            // 
            // lblKernel
            // 
            this.lblKernel.AutoSize = true;
            this.lblKernel.Location = new System.Drawing.Point(10, 41);
            this.lblKernel.Name = "lblKernel";
            this.lblKernel.Size = new System.Drawing.Size(62, 13);
            this.lblKernel.TabIndex = 15;
            this.lblKernel.Text = "3 * 3 Kernel";
            // 
            // txtBox11
            // 
            this.txtBox11.Location = new System.Drawing.Point(79, 72);
            this.txtBox11.Multiline = true;
            this.txtBox11.Name = "txtBox11";
            this.txtBox11.Size = new System.Drawing.Size(31, 26);
            this.txtBox11.TabIndex = 14;
            this.txtBox11.Text = "\r\n";
            this.txtBox11.TextChanged += new System.EventHandler(this.txtBox11_TextChanged);
            // 
            // FormMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnApplyUserFilter);
            this.Controls.Add(this.txtBox33);
            this.Controls.Add(this.txtBox32);
            this.Controls.Add(this.txtBox31);
            this.Controls.Add(this.txtBox23);
            this.Controls.Add(this.txtBox22);
            this.Controls.Add(this.txtBox21);
            this.Controls.Add(this.txtBox13);
            this.Controls.Add(this.txtBox12);
            this.Controls.Add(this.lblKernel);
            this.Controls.Add(this.txtBox11);
            this.Name = "FormMatrix";
            this.Text = "FormMatrix";
            this.Load += new System.EventHandler(this.FormMatrix_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApplyUserFilter;
        private System.Windows.Forms.TextBox txtBox33;
        private System.Windows.Forms.TextBox txtBox32;
        private System.Windows.Forms.TextBox txtBox31;
        private System.Windows.Forms.TextBox txtBox23;
        private System.Windows.Forms.TextBox txtBox22;
        private System.Windows.Forms.TextBox txtBox21;
        private System.Windows.Forms.TextBox txtBox13;
        private System.Windows.Forms.TextBox txtBox12;
        private System.Windows.Forms.Label lblKernel;
        private System.Windows.Forms.TextBox txtBox11;
    }
}