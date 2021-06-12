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

        private void listBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            string selected =(string)listBoxStudent.SelectedItem;
            string[] allStudentFiles = Directory.GetFiles("students");

            foreach (var item in allStudentFiles)
            {
                string[] lines = File.ReadAllLines(item);
                if (lines[0]+" "+lines[1]==selected)
                {
                    labelName.Text = lines[0];
                    labelNumber.Text = lines[1];
                    labelClass.Text = lines[2];
                    break;
                }
            }
        }

        private void buttonDelstudent_Click(object sender, EventArgs e)
        {
            if (listBoxStudent.SelectedItem==null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                string selected = (string)listBoxStudent.SelectedItem;
                string[] allStudentFiles = Directory.GetFiles("students");

                foreach (var item in allStudentFiles)
                {
                    string[] lines = File.ReadAllLines(item);
                    if (lines[0] + " " + lines[1] == selected)
                    {
                        listBoxStudent.Items.Remove(selected);
                        File.Delete(item);
                        break;
                    }
                }

            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            labelName.Text = "";
            labelNumber.Text = "";
            labelClass.Text = "";

            string[] allStudents = Directory.GetFiles("students");
            foreach (var item in allStudents)
            {
                string[] lines = File.ReadAllLines(item);
                string name = lines[0];
                string numbr = lines[1];
                listBoxStudent.Items.Add(name + " " + numbr);
                //string claSS = lines[2];
                

            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            textBoxNumber.Clear();
            comboBoxClass.Text = "";


        }
    }
}
