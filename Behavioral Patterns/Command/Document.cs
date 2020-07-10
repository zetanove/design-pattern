using System.Windows.Forms;

namespace CommandPattern
{
    //Receiver
    public class Document
    {
        private TextBox textBox;

        public Document(TextBox txt)
        {
            this.textBox = txt;
        }

        public string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }


        public void Cut()
        {
            textBox.Cut();
        }

        public void Paste()
        {
            textBox.Paste();
        }

        public void Copy()
        {
            textBox.Copy();
        }
    }
}
