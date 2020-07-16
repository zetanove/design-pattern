using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memento
{
    /// <summary>
    /// Memento
    /// </summary>


    //originator

    public class Document
    {
        private string Text;
        private int cursorPosition;

        public DocumentState CreateMemento()
        {
            return new DocumentState(this.Text, this.cursorPosition);
        }

        public void SetStateFromMemento(DocumentState state)
        {
            this.Text = state.GetText();

        }



        public class DocumentState
        {
            private string text;
            private int cursorPosition;

            public DocumentState(string text, int position)
            {
                this.text = text;
                this.cursorPosition = position;
            }

            public string GetText()
            {
                return text;
            }

            int GetPosition()
            {
                return cursorPosition;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator("stato 1");
            //CareTaker ct = new CareTaker(originator.SaveMemento());
            CareTaker ct = new CareTaker();
            ct.AddMemento(originator.SaveMemento());
            Console.WriteLine("stato: "+originator.Text);

            originator.Text = "stato modificato";
            Console.WriteLine("stato: " + originator.Text);
            ct.AddMemento(originator.SaveMemento());

            originator.Text = "stato modificato2";
            Console.WriteLine("stato: " + originator.Text);
            ct.AddMemento(originator.SaveMemento());

            originator.Text = "stato modificato3";
            Console.WriteLine("stato: " + originator.Text);

            originator.RestoreMemento(ct.GetMemento());
            Console.WriteLine("stato: " + originator.Text);

            originator.RestoreMemento(ct.GetMemento());
            Console.WriteLine("stato: " + originator.Text);

            //originator.RestoreMemento(ct.Memento);
            //Console.WriteLine("stato: " + originator.Text);

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 


        }
    }

    public interface IMementoNarrow
    {
    }

    public class Originator
    {
        private interface IMementoWide
        {
            string Text
            {
                get;
                set;
            }
        }

        private class Memento : IMementoNarrow, IMementoWide
        {
            private string m_strText = String.Empty;

            public Memento(string strText)
            {
                this.m_strText = strText;
            }

            public string Text
            {
                get
                {
                    return this.m_strText;
                }
                set
                {
                    this.m_strText = value;
                }
            }
        }

        private string m_strText = String.Empty;

        public Originator(string strText)
        {
            this.m_strText = strText;
        }

        public string Text
        {
            get
            {
                return this.m_strText;
            }
            set
            {
                this.m_strText = value;
            }
        }

        public IMementoNarrow SaveMemento()
        {
            IMementoWide memento = new Memento(this.m_strText);

            return (IMementoNarrow)memento;
        }

        public bool RestoreMemento(IMementoNarrow memento)
        {
            try
            {
                this.m_strText = ((IMementoWide)memento).Text;

                return true;
            }
            catch
            {
                return false;
            }
        }

    }

    public class CareTaker
    {
        private Stack<IMementoNarrow> mementos;

        //il caretaker non può usare l'interfaccia Wide
        private IMementoNarrow m_Memento = null;

        public CareTaker(IMementoNarrow memento)
        {
            this.m_Memento = memento;
        }

        public CareTaker()
        {
            mementos = new Stack<IMementoNarrow>();
        }

        public void AddMemento(IMementoNarrow memento)
        {
            Console.WriteLine("Salvo lo stato... "); //salva lo stato ma non lo può leggere
            mementos.Push(memento);
        }

        public IMementoNarrow GetMemento()
        {
            Console.WriteLine("Ricavo lo stato... "); //ricavo lo stato ma non lo può leggere
            return this.mementos.Pop();
        }

        public IMementoNarrow Memento
        {
            get
            {
                return this.m_Memento;
            }
            set
            {
                this.m_Memento = value;
            }
        }
    }

}
