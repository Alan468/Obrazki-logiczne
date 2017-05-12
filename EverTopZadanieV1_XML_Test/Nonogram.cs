using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace EverTopZadanieV1_XML_Test {
    class Nonogram {

        enum State { Empty, Box }

        int Width, Height;
        List<List<int>> DataX, DataY;
        int InfoSizeX, InfoSizeY;
        XmlDocument NonogramXML;
        State[] NonogramMatrix;

        public Nonogram() {
            Width = Height = InfoSizeX = InfoSizeY = 0;
            DataX = new List<List<int>>();
            DataY = new List<List<int>>();

            NonogramXML = new XmlDocument();
        }

        public void LoadNonogramXML(string NonogramXMLPath) {
            NonogramXML.Load(NonogramXMLPath);

            Width = NonogramXML.DocumentElement.GetElementsByTagName("Column").Count;
            Height = NonogramXML.DocumentElement.GetElementsByTagName("Row").Count;

            NonogramMatrix = new State[Width * Height];

            int y = 0;

            XmlNodeList Columns = NonogramXML.DocumentElement.GetElementsByTagName("Column");
            foreach (XmlNode Value in Columns) {
                string[] Vals = Regex.Replace(Value.InnerText, "[^0-9,]", "").Split(',');
                if (Vals.Length > InfoSizeX) InfoSizeX++;
                DataX.Add(new List<int>());
                foreach (string V in Vals) {
                    DataX[y].Add(Int32.Parse(V)); // throw WartoscWiekszaOdRozmiaru

                }
                y++;
            }

            y = 0;

            XmlNodeList Rows = NonogramXML.DocumentElement.GetElementsByTagName("Row");
            foreach (XmlNode Value in Rows) {
                string[] Vals = Regex.Replace(Value.InnerText, "[^0-9,]", "").Split(',');
                if (Vals.Length > InfoSizeY) InfoSizeY++;
                DataY.Add(new List<int>());
                foreach (string V in Vals) {
                    DataY[y].Add(Int32.Parse(V)); // throw WartoscWiekszaOdRozmiaru

                }
                y++;
            }

        }

    }
}
