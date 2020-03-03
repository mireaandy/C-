using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testXsi0
{
    public partial class Form1 : Form
    {
        string jucator1, jucator2;
        int tura = -1;
        int[,] sitJoc = new int[5, 5];

        public Form1()
        {
            InitializeComponent();
        }

        bool Castigat(int jucator)
        {
            int verifDiagPrinc = 0;
            int verifDiagSec = 0;
            for (int i = 0; i < 5; i++)
                if (SitJoc[i, 0] == jucator && SitJoc[i, 1] == jucator && SitJoc[i, 2] == jucator && SitJoc[i, 3] == jucator && SitJoc[i, 4] == jucator)
                    return true;
            for (int i = 0; i < 5; i++)
                if (SitJoc[0,i] == jucator && SitJoc[1,i] == jucator && SitJoc[2,i] == jucator && SitJoc[3,i] == jucator && SitJoc[4,i] == jucator)
                    return true;
            for (int i = 0; i < 5; i++)
                if (SitJoc[i, i] == jucator)
                    verifDiagPrinc++;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (i + j == 4)
                        if(SitJoc[i, j] == jucator)
                            verifDiagSec++;
            if(verifDiagPrinc == 5 || verifDiagSec == 5)
                return true;
            return false;
        }

        public string Jucator1 { get => jucator1; set => jucator1 = value; }
        public string Jucator2 { get => jucator2; set => jucator2 = value; }
        public int Tura { get => tura; set => tura = value; }
        public int[,] SitJoc { get => sitJoc; set => sitJoc = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            Jucator1 = textBox1.Text;
            Jucator2 = textBox2.Text;
            for(int i = 0; i < 5; i++)
                for(int j = 0; j < 5; j++)
                {
                    string name = i + "_" + j;
                    Button x0 = new Button();
                    x0.Name = name;
                    x0.Width = 50;
                    x0.Height = 50;
                    x0.Click += X0_Click;
                    flowLayoutPanel1.Controls.Add(x0);
                }
            Tura++;
        }

        private void X0_Click(object sender, EventArgs e)
        {
            int pozix, poziy;
            string pozsx, pozsy;
            Button x0 = (Button)sender;
            if (x0.Text.Equals(""))
            {
                if (Tura % 2 == 0)
                {
                    x0.Text = "X";
                    pozsx = x0.Name.Substring(0, 1);
                    pozix = int.Parse(pozsx);
                    pozsy = x0.Name.Substring(2, 1);
                    poziy = int.Parse(pozsy);
                    SitJoc[pozix, poziy] = 1;
                    if(Castigat(1))
                    {
                        MessageBox.Show(Jucator1 + " a castigat jocul!");
                        Application.Restart();
                    }
                }
                else
                {
                    x0.Text = "O";
                    pozsx = x0.Name.Substring(0, 1);
                    pozix = int.Parse(pozsx);
                    pozsy = x0.Name.Substring(2, 1);
                    poziy = int.Parse(pozsy);
                    SitJoc[pozix, poziy] = 2;
                    if (Castigat(2))
                    {
                        MessageBox.Show(Jucator2 + " a castigat jocul!");
                        Application.Restart();
                    }
                }
                Tura++;
            }
            else
                MessageBox.Show("Apasa pe un o pozitie goala!");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write(SitJoc[i, j]);
                Console.Write("\n");
            }
        }

        //private void textBox1_validated(object sender, EventArgs e)
        //{
        //    if (textBox1.Text.Equals(""))
        //        namejuc1ErrorProvider.SetError(textBox1, "Numele este necesar.");
        //    else namejuc1ErrorProvider.Clear();

        //}

        //private void textBox2_validated(object sender, EventArgs e)
        //{
        //    if (textBox2.Text.Equals(""))
        //        namejuc2ErrorProvider.SetError(textBox2, "Numele este necesar.");
        //    else
        //        namejuc2ErrorProvider.Clear();

        //}
    }
}
