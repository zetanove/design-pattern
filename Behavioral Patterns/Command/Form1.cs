using CommandPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandPattern
{
    public partial class Form1 : Form
    {
        Document document;
        CommandManager commandManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            commandManager = new CommandManager();
            document = new Document(this.textBox1);
        }

        private void btCut_Click(object sender, EventArgs e)
        {
            commandManager.ExecuteCommand(new CutCommand(document));
        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            commandManager.Undo();
        }
    }
}
