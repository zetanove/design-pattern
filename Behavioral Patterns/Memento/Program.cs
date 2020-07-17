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
            string GetText();
            void SetText(string text);
        }

        private class Memento : IMementoNarrow, IMementoWide
        {
            private string m_strText = String.Empty;

            public Memento(string strText)
            {
                this.m_strText = strText;
            }

            public string GetText()
            {
                return this.m_strText;
            }
            public void SetText(string text)
            {
                this.m_strText = text;
            }
        }

        private string text = String.Empty;

        public Originator(string t)
        {
            this.text = t;
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                text = value;
            }
        }

        public IMementoNarrow SaveMemento()
        {
            IMementoWide memento = new Memento(this.text);

            return (IMementoNarrow)memento;
        }

        public bool RestoreMemento(IMementoNarrow memento)
        {
            try
            {
                this.text = ((IMementoWide)memento).GetText();

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
