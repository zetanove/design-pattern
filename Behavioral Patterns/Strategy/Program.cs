using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection coll=new Collection(new []{"b","c", "a", "d", "e"});
            Console.WriteLine(coll);
            coll.SetSortStrategy(new SortAscending());
            coll.Sort();
            Console.WriteLine(coll);

            coll.SetSortStrategy(new SortDescending());
            coll.Sort();
            Console.WriteLine(coll);

            coll.SetSortStrategy(new SortRandom());
            coll.Sort();
            Console.WriteLine(coll);

        }
    }

    public class Collection
    {
        private string[] elements;
        private SortStrategy strategy;

        public Collection(string[] array)
        {
            elements = array;
        }

        public override string ToString()
        {
            return string.Join(", ", elements);
        }

        public void SetSortStrategy(SortStrategy strategy)
        {
            Console.WriteLine("Impostazione "+strategy);
            this.strategy = strategy;
        }

        public void Sort()
        {
            if(this.strategy!=null)
                this.strategy.Sort(this.elements);
        }
    }

    public interface SortStrategy
    {
        void Sort(string[] elements);
    }

    public class SortAscending : SortStrategy
    {
        public void Sort(string[] elements)
        {
            Array.Sort(elements);
        }
    }

    public class SortDescending : SortStrategy
    {
        public void Sort(string[] elements)
        {
            Array.Sort(elements);
            Array.Reverse(elements);
        }
    }

    public class SortRandom : SortStrategy
    {
        public void Sort(string[] elements)
        {
            var random = elements.OrderBy(e => Guid.NewGuid()).ToArray();
            for (int i = 0; i < random.Length; i++)
            {
                elements[i] = random[i];
            }

        }
    }
}
