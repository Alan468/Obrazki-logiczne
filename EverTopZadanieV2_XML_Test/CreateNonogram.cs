using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace NonogramSolver {
    public partial class CreateNonogram : Form {

        // Rozmiar obrazu i ilości warstw
        private int GameWidth, GameHeight;
        private int XLayers, YLayers;
        // XML z informacjami o obrazie
        public XmlDocument XML { get; private set; }

        // Konstruktor
        public CreateNonogram() {
            // Wartości domyślne
            InitializeComponent();
            GameWidth = GameHeight = 1;
            XLayers = YLayers = 1;
            GridX.RowCount = GridY.RowCount = 1;
            XML = null;
        }

        // Zamknięcie okna bez tworzenie XML
        private void CloseWindow(object sender, EventArgs e) {
            this.Hide();
            this.Dispose();
        }

        // Zamknięcie okna (bez zapisu do pliku)
        private void Confirm(object sender, EventArgs e) {
            // Stworzenie i przypisanie XML (stworzonego w pamięci) do zmiennej
            XML = CreateXML();
            // Ukrycie i usunięcie okna
            this.Hide();
            this.Dispose();
        }

        // Zapis XML do pliku
        private void SaveToXML(object sender, EventArgs e) {
            // Otwarcie dialogu zapisu do pliku z filtrem XML
            SaveFileDialog FileDialog = new SaveFileDialog();
            FileDialog.Filter = "XML | *.xml";
            DialogResult Result = FileDialog.ShowDialog();

            // Jeśli wybrano poprawny plik zapisuje
            if (Result == DialogResult.OK) {
                CreateXML().Save(FileDialog.FileName);
            }
        }

        // Tworzenie XML w pamięci
        private XmlDocument CreateXML() {
            // Tworzenie buffora dokumentu XML
            XmlDocument XMLDoc = new XmlDocument();
            // Dopisanie nagłówka
            XmlNode docNode = XMLDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XMLDoc.AppendChild(docNode);

            // Stworzenie korzenia dokumentu
            XmlNode productsNode = XMLDoc.CreateElement("BinLogic");
            XMLDoc.AppendChild(productsNode);

            // Wpisanie definicji kolumn
            for (int x = 0; x < GameWidth; x++) {
                XmlNode CurrentNode = XMLDoc.CreateElement("Column");
                XmlAttribute NodeID = XMLDoc.CreateAttribute("id");
                NodeID.Value = x.ToString();
                CurrentNode.Attributes.Append(NodeID);
                productsNode.AppendChild(CurrentNode);
                // Wpisanie grup z kolumny
                for (int y = 0; y < XLayers; y++) {
                    if (GridX[x, y].Value != null)
                        CurrentNode.AppendChild(XMLDoc.CreateTextNode(GridX[x, y].Value.ToString()));
                    // Oddzielenie przecinkiem 
                    if (y + 1 < XLayers && GridX[x, y + 1].Value != null)
                        if (y < XLayers && GridX[x, y].Value != null)
                            CurrentNode.AppendChild(XMLDoc.CreateTextNode(","));
                }
            }
            // Wpisanie definicji kolumn
            for (int y = 0; y < GameHeight; y++) {
                XmlNode CurrentNode = XMLDoc.CreateElement("Row");
                XmlAttribute NodeID = XMLDoc.CreateAttribute("id");
                NodeID.Value = y.ToString();
                CurrentNode.Attributes.Append(NodeID);
                productsNode.AppendChild(CurrentNode);
                // Wpisanie grup z wiersza
                for (int x = 0; x < YLayers; x++) {
                    if (GridY[x, y].Value != null)
                        CurrentNode.AppendChild(XMLDoc.CreateTextNode(GridY[x, y].Value.ToString()));
                    // Oddzielenie przecinkiem 
                    if (x + 1 < YLayers && GridY[x + 1, y].Value != null)
                        if (x < YLayers && GridY[x, y].Value != null)
                            CurrentNode.AppendChild(XMLDoc.CreateTextNode(","));
                }
            }
            return XMLDoc;
        }

        // Dodanie nowej warstwy dla osi X
        private void AddXLayer(object sender, EventArgs e) {
            NumericUpDown Sender = (NumericUpDown)sender;

            // Przypisanie nowej warstwy jeśli jest wieksza niż 0
            if (Sender.Value > 0) {
                // Blokada przekroszenia wilkości obrazu
                if (Sender.Value <= GameHeight) {
                    GridX.RowCount = XLayers = (int)Sender.Value;
                } else
                    Sender.Value = GameHeight;
            } else {
                ((NumericUpDown)sender).Value = 1;
            }
        }

        // Dodanie nowej warstwy dla osi Y
        private void AddYLayer(object sender, EventArgs e) {
            NumericUpDown Sender = (NumericUpDown)sender;

            // Przypisanie nowej warstwy jeśli jest wieksza niż 0
            if (Sender.Value > 0) {
                // Blokada przekroszenia wilkości obrazu
                if (Sender.Value <= GameWidth) {
                    YLayers = GridY.ColumnCount = (int)Sender.Value;
                    // Ustawnienie szerokości kolumny na 50
                    GridY.Columns[GridY.ColumnCount - 1].Width = 50;
                } else
                    Sender.Value = GameWidth;
            } else {
                ((NumericUpDown)sender).Value = 1;
            }
        }

        // Zmiana szerokości obrazu
        private void WidthChange(object sender, EventArgs e) {
            NumericUpDown Sender = (NumericUpDown)sender;

            // Przypisanie nowej szerokości jeśli jest wieksza niż 0
            if (Sender.Value > 0) {
                GameWidth = GridX.ColumnCount = (int)Sender.Value;
                // Ustawnienie szerokości kolumny na 50
                GridX.Columns[GridX.ColumnCount - 1].Width = 50;
            } else {
                Sender.Value = 1;
            }
        }

        // Zmiana wysokości obrazu
        private void HeightChange(object sender, EventArgs e) {
            NumericUpDown Sender = (NumericUpDown)sender;

            // Przypisanie nowej wysokości jeśli jest wieksza niż 0
            if (Sender.Value > 0) {
                GameHeight = GridY.RowCount = (int)Sender.Value;
            } else {
                Sender.Value = 1;
            }
        }
    }
}
