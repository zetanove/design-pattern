using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyweight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(Pens.Red, 100,100,50,50);
        }
    }

    public class CircleFactory
    {
        
    }

    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }


    }

    public class CircleFlyweight
    {
        private Circle _sharedState;

        public CircleFlyweight(Circle c)
        {
            this._sharedState = c;
        }

        public void Move(Circle newState)
        {

        }
    }
}
