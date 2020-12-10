using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Persona: Prototype
    {
        private string nome;

        private string cognome { get; set; }

        internal List<Contatto> Contatti;

        public Persona(string n, string c)
        {
            nome = n;
            cognome = c;
            Contatti = new List<Contatto>();
        }

        public Persona(Persona originale)
        {
            this.nome = originale.nome;
            this.cognome = originale.cognome;
            this.Contatti = originale.Contatti;
        }

        public string GetNome()
        {
            return nome;
        }
        public string GetCognome()
        {
            return cognome;
        }

        public void SetNome(string n)
        {
            nome=n;
        }
        public void SetCognome(string c)
        {
            cognome=c;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{nome} {cognome} - hashcode: {this.GetHashCode()}");
            foreach (var c in Contatti)
                sb.AppendLine(c.ToString());

            return sb.ToString();
        }

        
        public Prototype Clone()
        {
            //Shallow copy, i contatti rimangono per riferimento
            //return (Person)this.MemberwiseClone();

            //con costruttore di copia
            //Persona clone = new Persona(this);


            //deep
            Persona clone = (Persona)this.MemberwiseClone();
            clone.Contatti = new List<Contatto>();
            foreach (var c in this.Contatti)
                clone.Contatti.Add((Contatto)c.Clone());

            return clone;
                
        }
    }

    enum ContactType
    {
        Tel,
        Email,
        Fax,
        Social,
    }

     class Contatto: Prototype
    {
        public ContactType Type;
        public string Text;

        public Contatto(ContactType type)
        {
            this.Type = type;
        }

        public Contatto(ContactType type, string text)
        {
            Type = type;
            Text = text;
        }

        public override string ToString()
        {
            return $"{Type} {Text} - hashcode: {this.GetHashCode()}";
        }

        public Prototype Clone()
        {
            return (Contatto)this.MemberwiseClone();
        }
    }
}
