using System.Collections;

namespace CommandPattern
{


    //Invoker
    class CommandInvoker
    {
        private Stack commandStack = new Stack();

        public void ExecuteCommand(DocumentCommand cmd)
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


    //Command
    public abstract class DocumentCommand
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
        protected string testoPrecedente;

        public UndoableCommand(Document doc):base(doc)
        {

        }
        public abstract void Undo();
    }

    //Concrete Command
    public class CutCommand : UndoableCommand
    {
        public CutCommand(Document doc): base(doc)
        {
            this.testoPrecedente = doc.Text;
        }

        public override void Execute()
        {
            document.Cut();
        }

        public override void Undo()
        {
            document.Text = testoPrecedente;
        }
    }

    public class CopyCommand : DocumentCommand
    {
        public CopyCommand(Document doc) : base(doc)
        {
        }

        public override void Execute()
        {
            document.Copy();
        }
    }
}
