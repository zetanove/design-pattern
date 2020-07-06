using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Image img=new ProxyImage("C:\\temp\\image1.jpg");
            img.ShowImage();
            img.ShowImage();
        }
    }

    public interface Image
    {
        void ShowImage();
    }

    public class RealImage : Image
    {
        private string filename { get; set; }

        public RealImage(string file)
        {
            filename = file;
            LoadImage();
        }

        private void LoadImage()
        {
            Console.WriteLine("Caricamento immagine "+filename);
            Thread.Sleep(2000); //simulo caricamento pesante
        }

        public void ShowImage()
        {
            Console.WriteLine("Visualizzazione immagine caricata da " + filename);
        }
    }

    public class ProxyImage: Image
    {
        private RealImage realImage = null;
        private string filename { get; set; }


        public ProxyImage(string file)
        {
            filename = file;
        }

        public void ShowImage()
        {
            if (realImage == null)
            {
                realImage=new RealImage(filename);
            }
            realImage.ShowImage();
        }
    }

}
