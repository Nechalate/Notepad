using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NotepadWF
{
    public partial class Form1 : Form
    {
        public string filename;
        public bool isFileChanging;
        public Form1()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            filename = "";
            isFileChanging = false;
        }

        public void CreateNewDocument(Object sender, EventArgs e)
        {
            textBox1.Text = "";
            filename = "";
        }

        public void OpenFile(Object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    textBox1.Text = sr.ReadToEnd();
                    filename = openFileDialog1.FileName;
                }
                catch
                {
                    MessageBox.Show("Не возможно открыть файл!");
                }
            }
        }

        public void SaveFile(string _filename)
        {
            if(_filename == "")
            {
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _filename = saveFileDialog1.FileName;
                }
            }
            try
            {
                StreamWriter sw = new StreamWriter(_filename);
                sw.Write(textBox1.Text);
                sw.Close();
                filename = _filename;
                isFileChanging = false;
            }
            catch
            {
                MessageBox.Show("Не возможно сохранить файл!");
            }
        }

        public void Save(Object sender, EventArgs e)
        {
            SaveFile(filename);
        }

        public void SaveAs(Object sender, EventArgs e)
        {
            SaveFile("");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (!isFileChanging)
            {
                isFileChanging = true;
                this.Text = "*" + this.Text;
            }
        }
    }
}
