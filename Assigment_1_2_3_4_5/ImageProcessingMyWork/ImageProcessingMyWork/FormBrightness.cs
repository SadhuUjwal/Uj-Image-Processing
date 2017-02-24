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
    public partial class FormBrightness : Form
    {
        public int Brightness
        {
            get
            {
                return int.Parse(txtBrightness.Text);
            }
            set { txtBrightness.Text = value.ToString(); }
        }

        public FormBrightness()
        {
            InitializeComponent();
        }

        private void FormBrightness_Load(object sender, EventArgs e)
        {

        }

        private void btnBright_Click(object sender, EventArgs e)
        {

        }
    }
}
