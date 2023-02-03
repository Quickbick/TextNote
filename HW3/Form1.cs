// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW3

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
{
    using System.Text;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void SaveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        /// <summary>
        /// Saves content from Text Box 1 into a file using system file windows. No user inputted parameters.
        /// </summary>
        private void SaveToFile(object sender, EventArgs e)
        {
            Stream saveStream;

            this.saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.RestoreDirectory = true;

            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((saveStream = this.saveFileDialog1.OpenFile()) != null)
                {
                    // writes text to selected file
                    using (StreamWriter writer = new StreamWriter(saveStream, Encoding.UTF8))
                    {
                        writer.Write(this.textBox1.Text);
                    }

                    saveStream.Close();
                }
            }
        }

        /// <summary>
        /// Reads in text from reader and writes it into Text Box 1.
        /// </summary>
        /// <param name="reader">Provides text from outside source.</param>
        private void LoadText(TextReader reader)
        {
           this.textBox1.Clear();
           this.textBox1.Text = reader.ReadToEnd();
        }

        /// <summary>
        /// Reads in text from a file into the text box. No user inputted parameters.
        /// </summary>
        private void LoadFromFile(object sender, EventArgs e)
        {
            Stream loadStream;

            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.RestoreDirectory = true;

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the path of specified file
                string filePath = this.openFileDialog1.FileName;

                // Read the contents of the file into a stream
                loadStream = this.openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(loadStream))
                {
                    this.LoadText(reader);
                }
            }
        }

        /// <summary>
        /// Loads first 50 numbers of Fibonacci sequence to text box. No user inputted perameters.
        /// </summary>
        private void LoadFibonacci50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader loadReader = new FibonacciTextReader(51);
            this.LoadText(loadReader);
        }

        /// <summary>
        /// Loads first 100 numbers of Fibonacci sequence to text box. No user inputted perameters.
        /// </summary>
        private void LoadFibonacci100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader loadReader = new FibonacciTextReader(101);
            this.LoadText(loadReader);
        }
    }
}