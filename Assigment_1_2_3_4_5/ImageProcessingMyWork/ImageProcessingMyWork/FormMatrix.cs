using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingMyWork
{
    public partial class FormMatrix : Form
    {
        public FormMatrix()
        {
            InitializeComponent();
        }
        public string Tb11
        {
            get
            {
                return txtBox11.Text;
            }
            set { txtBox11.Text = value.ToString(); }
        }
        public string Tb12
        {
            get
            {
                return txtBox12.Text;
            }
            set { txtBox12.Text = value.ToString(); }
        }
        public string Tb13
        {
            get
            {
                return txtBox13.Text;
            }
            set { txtBox13.Text = value.ToString(); }
        }
        public string Tb21
        {
            get
            {
                return txtBox21.Text;
            }
            set { txtBox21.Text = value.ToString(); }
        }
        public string Tb22
        {
            get
            {
                return txtBox22.Text;
            }
            set { txtBox22.Text = value.ToString(); }
        }
        public string Tb23
        {
            get
            {
                return txtBox23.Text;
            }
            set { txtBox23.Text = value.ToString(); }
        }
        public string Tb31
        {
            get
            {
                return txtBox31.Text;
            }
            set { txtBox31.Text = value.ToString(); }
        }
        public string Tb32
        {
            get
            {
                return txtBox32.Text;
            }
            set { txtBox32.Text = value.ToString(); }
        }
        public string Tb33
        {
            get
            {
                return txtBox33.Text;
            }
            set { txtBox33.Text = value.ToString(); }
        }
        private void FormMatrix_Load(object sender, EventArgs e)
        {

        }

        private void txtBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnApplyUserFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
