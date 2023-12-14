using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.models;

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        private String NameDisease;
        private int y = 200;
        private List<String> list = new List<string>();
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        public Form2(String NameDisease)
        {
            this.NameDisease = NameDisease;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (var db = new EFDbContext())
            {
                label3.Text = this.NameDisease;
                List<String> nameDisease = db.Diseases
                    .Where(p => p.Name == this.NameDisease)
                    .Select(o => o.DiseaseID)
                    .ToList();
                List<String> symptons = db.Symptons
                    .Where(p => p.Disease.DiseaseID == nameDisease[0])
                    .Select(s => s.Name).ToList();
                Queue<String> queue = new Queue<string>();
                foreach(String sympton in symptons)
                {
                    queue.Enqueue(sympton);
                }
                while (!queue.IsNullOrEmpty())
                {
                    String temp = queue.Dequeue();
                    List<String> name = db.Diseases
                    .Where(p => p.Name == temp)
                    .Select(o => o.DiseaseID)
                    .ToList();
                    if (name.Count == 0)
                    {
                        list.Add(temp);
                    }
                    else
                    {
                        List<String> sptons = db.Symptons
                                .Where(p => p.Disease.DiseaseID == name[0])
                                .Select(s => s.Name).ToList();
                        foreach (String sympton in sptons)
                        {
                            queue.Enqueue(sympton);
                        }
                    }
                }
                for(int i = 0; i < list.Count; i++)
                {
                    Label label = new Label();
                    label.Text = Convert.ToString(i + 1) + ".Bạn có bị mắc triệu chứng " + list[i] + " không?";
                    label.Location = new System.Drawing.Point(100, y);
                    label.Font = new Font("Arial", 11, FontStyle.Italic);
                    label.ForeColor = System.Drawing.Color.Maroon;
                    label.AutoSize = true;
                    y += 25;
                    CheckBox checkBox1 = new CheckBox();
                    checkBox1.Text = "Yes";
                    checkBoxes.Add(checkBox1);
                    checkBox1.Location = new System.Drawing.Point(200, y);
                    checkBox1.ForeColor = System.Drawing.Color.Maroon;
                    CheckBox checkBox2 = new CheckBox();
                    checkBox2.Text = "No";
                    checkBox2.Location = new System.Drawing.Point(350, y);
                    checkBox2.ForeColor = System.Drawing.Color.Maroon;
                    y += 25;
                    this.Controls.Add(label);
                    this.Controls.Add(checkBox1);
                    this.Controls.Add(checkBox2);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = true;
            foreach(CheckBox checkBox in checkBoxes)
            {
                if(!checkBox.Checked)
                {
                    flag = false;
                    break;
                }
            }
            if(flag == false)
            {
                MessageBox.Show("Chưa đủ cơ sở kiến thức để chuẩn đoán là " + this.NameDisease);
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn có khả năng đã bị " + this.NameDisease + " . Hãy đến bác sĩ kiểm tra!");
                this.Close();
            }
        }
    }
}
