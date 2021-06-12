using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace student_app
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void buttonSavestudent_Click(object sender, EventArgs e)
        {
            string getStudents = GetFormData();
            string filePath = GetFilePath();
            File.WriteAllText("students/" + filePath,getStudents);
            MessageBox.Show("Saved");

            listBoxStudent.Items.Add(textBoxName.Text + " " + textBoxNumber.Text + " " + comboBoxClass.Text);
        }

        private string GetFilePath()
        {
            //files in ..bin/debug/students
            string[] files = Directory.GetFiles("students");
            if (files.Length==0)
            {
                return "1.txt";
            }
            else
            {
                return (FileCountt(files) + 1) + ".txt";
            }
        }

        private int FileCountt(string[] files)
        {
            int maxNum = 0;
            foreach (var item in files)
            {
                string lastfile = GetLastFile(item);
                int lastNum =Convert.ToInt32(lastfile.Replace(".txt", "")) ;
                if (lastNum>maxNum)
                {
                    maxNum = lastNum;
                }                
            }
            return maxNum;
        }

        private string GetLastFile(string item)
        {
            string[] parts = item.Split('\\');
            return parts[parts.Length - 1];
        }

        private string GetFormData()
        {
            string c = textBoxName.Text;
            c += Environment.NewLine;
            c += textBoxNumber.Text;
            c += Environment.NewLine;
            c += comboBoxClass.Text;
            c += Environment.NewLine;
            c += DateTime.Today.ToShortDateString();
            return c;
        }
    }
}
