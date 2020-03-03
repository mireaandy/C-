using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace treasureFinder
{
    public partial class Form1 : Form
    {
        int turnNumber;
        public Form1()
        {
            InitializeComponent();
        }

        public int TurnNumber { get => turnNumber; set { turnNumber = value; OnTurnNumberChanged(); } }

        public void OnTurnNumberChanged()
        {
            label1.Text = "Numar ture ramase : " + (10 - TurnNumber);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int treasureLocationX = rand.Next(0,5);
            int treasureLocationY = rand.Next(0,5);

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    Button hole = new Button();
                    string name;

                    if (i == treasureLocationX && j == treasureLocationY)
                    {
                        name ="1";
                        //hole.Text = "Aici este comoara!";
                    }
                    else
                        name ="0";

                    hole.Name = name;
                    hole.Width = 150;
                    hole.Height = 150;
                    hole.Click += holeDigged;

                    tableLayoutPanel1.Controls.Add(hole);
                }
        }

        private void holeDigged(object sender, EventArgs e)
        {
            Button hole = (Button)sender;

            TurnNumber++;

            if (TurnNumber < 10)
            {
                if (hole.Name.CompareTo("1") == 0)
                {
                    DialogResult option;
                    string mBText1 = "Ai castigat!";
                    string mBText2 = "Vrei sa reincerci?";
                    MessageBoxButtons mBButtons = MessageBoxButtons.YesNo;

                    option = MessageBox.Show(mBText2, mBText1, mBButtons);

                    if (option == DialogResult.Yes)
                        Application.Restart();
                    else
                        Application.Exit();
                }
            }
            else
            {
                DialogResult option;
                string mBText1 = "Ai pierdut!";
                string mBText2 = "Vrei sa reincerci?";
                MessageBoxButtons mBButtons = MessageBoxButtons.YesNo;

                option = MessageBox.Show(mBText2, mBText1, mBButtons);

                if (option == DialogResult.Yes)
                    Application.Restart();
                else
                    Application.Exit();
            }
        }
    }
}
