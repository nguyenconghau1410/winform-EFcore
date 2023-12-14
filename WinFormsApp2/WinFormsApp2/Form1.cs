namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using(var db = new EFDbContext())
            {
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Name";
                var symptons = db.Symptons
                                 .GroupBy(s => s.Name)
                                 .Select(g => g.First())
                                 .ToList();
                comboBox1.DataSource = symptons;
                comboBox1.Text = null;
            }
        }


        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            if(index != ListBox.NoMatches)
            {
                string selectedItem = listBox1.Items[index].ToString();
                Form2 f = new Form2(selectedItem);
                f.ShowDialog();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var db = new EFDbContext())
            {
                String sympton = comboBox1.Text;
                listBox1.ValueMember = "Disease.DiseaseID";
                listBox1.DataSource = db.Symptons.Where(p => p.Name == sympton).Select(s => s.Disease.Name).ToList();
            }
        }
    }
}