using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxUsername.Text=="admin1" && textBoxPassword.Text=="12345")
            {
                new Dashboard().Show();
            }
            else { MessageBox.Show("Chek your data","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        }
    }
}
