using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;

namespace EverTopZadanieV1_XML_Test {
    class Program {


        static void Main(string[] args) {

            Nonogram Game;
            Game = new Nonogram();

            try {
                Game.LoadNonogramXML("E:\\Projekty\\EverTopZadanie\\EverTopZadanie\\EverTopZadanieV1_XML_Test\\XMLFile1.xml");
            } catch (XmlException ex) {
                Console.WriteLine("Błąd wczytywania XML");
            }


            Console.Read();

        }
    }
}
