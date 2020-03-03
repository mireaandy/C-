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

namespace charGuess
{
    public partial class Form1 : Form
    {
        string path = @"\\Mac\Home\Documents\MTP\Examen\charGuess\charGuess\sursa.txt";
        int numberOfCharacters = 0, numberOfCharGuessed = 0;
        StreamReader charSource;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(path))
                MessageBox.Show("Fisierul nu exista!");
            else
                charSource = File.OpenText(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char charInserted = textBox1.Text.ToString()[0];

            if (charInserted.Equals(string.Empty))
                MessageBox.Show("Nu ai introdus un caracter!");
            else
            {
                char charToGuess = charSource.ReadLine()[0];

                numberOfCharacters++;

                if (charInserted.Equals(charToGuess))
                {
                    numberOfCharGuessed++;
                    MessageBox.Show("Ai ghicit caracterul " + charToGuess);
                }
                else
                    MessageBox.Show("Nu ai ghicit caracterul " + charToGuess);
            }

            if (charSource.Peek().Equals(-1))
            {
                MessageBox.Show("Jocul s-a terminat! \n Ai ghicit " + ((numberOfCharGuessed / (float)numberOfCharacters) * 100.0) + "% !");
            }
                
        }
    }
}
