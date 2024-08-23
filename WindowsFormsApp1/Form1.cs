using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string currentFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void 새파일ToolStripMenuItem1_Click(object sender, EventArgs e)

        {
            if (CheckIfUnsavedChanges())
            {
                textBox1.Clear();
                currentFilePath = null;
            }
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckIfUnsavedChanges())
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = openFileDialog.FileName;
                        textBox1.Text = File.ReadAllText(currentFilePath);
                    }
                }
            }
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckIfUnsavedChanges())
            {
                Application.Exit();
            }
        }

        private bool CheckIfUnsavedChanges()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                var result = MessageBox.Show("저장하시겠습니까?", "저장", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFile();
                    return true;
                }
                else if (result == DialogResult.No)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void SaveFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        File.WriteAllText(currentFilePath, textBox1.Text);
                    }
                }
            }
            else
            {
                File.WriteAllText(currentFilePath, textBox1.Text);
            }
        }


    }
}
