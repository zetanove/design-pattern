using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{

    public class PrototypeManager
    {
        Dictionary<string, Prototype> prototypesList = new Dictionary<string, Prototype>();
        public void AddPrototype(string key, Prototype prototype)
        {
            if (prototypesList.ContainsKey(key))
            {
                prototypesList[key] = prototype;
            }
            else prototypesList.Add(key, prototype);
        }
        public Prototype GetPrototype(string key)
        {
            if (prototypesList.ContainsKey(key))
            {
                return prototypesList[key].Clone();
            }
            return null;
        }
    }

    public class Bullet: Prototype
    {
        public string Color { get; set; }
        public int Size { get; set; }

        public Bullet()
        {}

        public Bullet(string color, int size)
        {
            Color = color;
            Size = size;
        }

        public Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}
