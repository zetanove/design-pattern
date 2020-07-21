using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace State
{
    public partial class Form1 : Form
    {
        private Clock clock;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clock = new Clock();
            txtState.Text = clock.GetCurrentState().ToString(); 
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            clock.ChangeButton();
            AggiornaGUI();
        }

        private void btMode_Click(object sender, EventArgs e)
        {
            clock.ModeButton();
            AggiornaGUI();
        }

        private void AggiornaGUI()
        {
            txtState.Text = clock.GetCurrentState().ToString();
            txtOre.Text = clock.Hours.ToString();
            txtMin.Text = clock.Minutes.ToString();
        }
    }
}
