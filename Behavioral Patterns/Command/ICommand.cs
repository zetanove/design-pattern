using System.Collections;
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

    public interface ICommand
    {
        void Execute();
    }

    //Invoker
    class CommandManager
    {
        private Stack commandStack = new Stack();

        public void ExecuteCommand(ICommand cmd)
        {
            cmd.Execute();
            if (cmd is UndoableCommand)
            {
                commandStack.Push(cmd);
            }
        }

        public void Undo()
        {
            if (commandStack.Count > 0)
            {
                UndoableCommand cmd = (UndoableCommand)commandStack.Pop();
                cmd.Undo();
            }
        }
    }



    public abstract class DocumentCommand : ICommand
    {
        protected Document document;

        public DocumentCommand(Document doc)
        {
            this.document = doc;
        }

        public abstract void Execute();
    }

    public abstract class UndoableCommand: DocumentCommand
    {
        protected string previousText;

        public UndoableCommand(Document doc):base(doc)
        {

        }
        public abstract void Undo();
    }

    public class CutCommand : UndoableCommand
    {
        public CutCommand(Document doc): base(doc)
        {
            this.previousText = doc.Text;
        }

        public override void Execute()
        {
            document.Cut();
        }

        public override void Undo()
        {
            document.Text = previousText;
        }
    }
}
