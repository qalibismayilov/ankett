using System.Xml;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private Anket? anket;
        public Form1()
        {
            InitializeComponent();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Dosyasý|*.json|Butun Hamisi|*.*";
            saveFileDialog.Title = "Dosyayi Kaydet";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                anket = new Anket();
                anket.Name = textBox1.Text;
                anket.Surname = textBox2.Text;
                anket.FatherN = textBox3.Text;
                anket.Birthday = textBox4.Text;
                anket.Gender = radioButton1.Checked ? "erkek" : "kadin";
                string json = JsonSerializer.Serialize(anket);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "JSON Dosyasý|*.json";
            OpenFileDialog.Title = "Dosya sec";

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                String json = File.ReadAllText(OpenFileDialog.FileName);
                anket = JsonSerializer.Deserialize<Anket>(json);


                textBox1.Text = anket!.Name;
                textBox2.Text = anket.Surname;
                textBox3.Text = anket.FatherN;
                textBox4.Text = anket.Birthday;
                if (anket.Gender == "Erkek")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }

            }
        }
    }
}