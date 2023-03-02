using System.Security.Cryptography;
using System.Text;

namespace szyfrowanie
{
    public partial class Form1 : Form
    {
        CspParameters csp = new CspParameters();

        public Form1()
        {
            InitializeComponent();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tekst = textBox1.Text;
            String zaszyfr = "";

            for (int i = 0; i < tekst.Length; i++)
            {
                if ((tekst[i] + numericUpDown1.Value) <= 65535)
                {
                    zaszyfr += (char)(tekst[i] + numericUpDown1.Value);
                }
                else
                {
                    zaszyfr += (char)(tekst[i] + numericUpDown1.Value - 65535);
                }

            }
            textBox2.Text = zaszyfr;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String tekst = textBox1.Text;
            String zaszyfr = "";

            for (int i = 0; i < tekst.Length; i++)
            {
                if ((tekst[i] - numericUpDown1.Value) >= 0)
                {
                zaszyfr += (char)(tekst[i] - numericUpDown1.Value);
                }
                else
                {
                    zaszyfr += (char)(tekst[i] - numericUpDown1.Value + 65535);
                }
            }
            textBox2.Text = zaszyfr;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            String tekst = textBox1.Text;
            String szyfr = textBox3.Text.ToUpper() + textBox3.Text.ToLower();
            String zaszyfr = "";

            for (int i = 0; i < tekst.Length; i++)
            {
                for (int j = 0; j < szyfr.Length; j++)
                {
                    if (tekst[i] == szyfr[j])
                    {
                        if (j % 2 == 0)
                        {
                            zaszyfr += szyfr[j + 1];
                        }
                        else if (j % 2 == 1)
                        {
                            zaszyfr += szyfr[j-1];
                        }
                    }
                    else if (j + 1 == szyfr.Length && zaszyfr.Length == i)
                    {
                        zaszyfr += tekst[i];
                    }
                }
            }
            textBox2.Text = zaszyfr;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}