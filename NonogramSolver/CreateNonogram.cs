using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace NonogramSolver
{
    public partial class CreateNonogram : Form
    {

        // Rozmiar obrazu i ilości warstw
        private int GameWidth, GameHeight;
        private int XLayers, YLayers;
        // XML z informacjami o obrazie
        public XmlDocument XML { get; private set; }

        // Konstruktor
        public CreateNonogram()
        {
            // Wartości domyślne
            InitializeComponent();
            GameWidth = GameHeight = 1;
            XLayers = YLayers = 1;
            GridX.RowCount = GridY.RowCount = 1;
            XML = null;
        }

        // Zamknięcie okna bez tworzenie XML
        private void CloseWindow(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        // Zamknięcie okna (bez zapisu do pliku)
        private void Confirm(object sender, EventArgs e)
        {
            // Stworzenie i przypisanie XML (stworzonego w pamięci) do zmiennej
            if (CreateXML())
            {
                // Ukrycie i usunięcie okna
                this.Hide();
                this.Dispose();
            }
        }

        // Zapis XML do pliku
        private void SaveToXML(object sender, EventArgs e)
        {
            // Otwarcie dialogu zapisu do pliku z filtrem XML
            SaveFileDialog FileDialog = new SaveFileDialog();
            FileDialog.Filter = "XML | *.xml";
            DialogResult Result = FileDialog.ShowDialog();

            // Jeśli wybrano poprawny plik zapisuje
            if (Result == DialogResult.OK)
            {
                if (CreateXML())
                {
                    XML.Save(FileDialog.FileName);
                }
            }
        }

        // Tworzenie XML w pamięci
        private bool CreateXML()
        {
            string InnerText;
            int BlocksCounter = 0;
            // Tworzenie buffora dokumentu XML
            XML = new XmlDocument();
            // Dopisanie nagłówka
            XmlNode docNode = XML.CreateXmlDeclaration("1.0", "UTF-8", null);
            XML.AppendChild(docNode);

            // Stworzenie korzenia dokumentu
            XmlNode productsNode = XML.CreateElement("BinLogic");
            XML.AppendChild(productsNode);

            // Wpisanie definicji kolumn
            for (int x = 0; x < GameWidth; x++)
            {
                XmlNode CurrentNode = XML.CreateElement("Column");
                XmlAttribute NodeID = XML.CreateAttribute("id");
                NodeID.Value = x.ToString();
                CurrentNode.Attributes.Append(NodeID);
                productsNode.AppendChild(CurrentNode);
                // Wpisanie grup z kolumny i wprawdzenie czy ich suma nie jest większa od szerokości obrazu
                for (int y = 0; y < XLayers; y++)
                {
                    if (GridX [x, y].Value != null && Int32.Parse(GridX [x, y].Value.ToString()) != 0)
                    {
                        InnerText = GridX [x, y].Value.ToString();
                        InnerText = Regex.Replace(InnerText, "[^0-9,]", ""); // Kasownaie niepoprawnych znaków
                        CurrentNode.AppendChild(XML.CreateTextNode(InnerText));
                        BlocksCounter += Int32.Parse(InnerText);
                    }

                    // Oddzielenie przecinkiem 
                    if (y + 1 < XLayers && GridX [x, y + 1].Value != null)
                    {
                        if (y < XLayers && GridX [x, y].Value != null)
                        {
                            CurrentNode.AppendChild(XML.CreateTextNode(","));
                            BlocksCounter++;
                        }
                    }
                }
                // Sprawdzenie czy podane wartości są poprawne - kolumny
                if (BlocksCounter > GameWidth)
                {
                    MessageBox.Show("Wartości w kolumnie " + (1 + x) + " osi X są niepoprawne!");
                    return false;
                }
                BlocksCounter = 0;
            }
            // Wpisanie definicji kolumn
            for (int y = 0; y < GameHeight; y++)
            {
                XmlNode CurrentNode = XML.CreateElement("Row");
                XmlAttribute NodeID = XML.CreateAttribute("id");
                NodeID.Value = y.ToString();
                CurrentNode.Attributes.Append(NodeID);
                productsNode.AppendChild(CurrentNode);
                // Wpisanie grup z wiersza
                for (int x = 0; x < YLayers; x++)
                {
                    if (GridY [x, y].Value != null && Int32.Parse(GridY [x, y].Value.ToString()) != 0)
                    {
                        InnerText = GridY [x, y].Value.ToString();
                        InnerText = Regex.Replace(InnerText, "[^0-9,]", "");// Kasownaie niepoprawnych znaków
                        CurrentNode.AppendChild(XML.CreateTextNode(InnerText));
                        BlocksCounter += Int32.Parse(InnerText);
                    }
                    // Oddzielenie przecinkiem 
                    if (x + 1 < YLayers && GridY [x + 1, y].Value != null)
                    {
                        if (x < YLayers && GridY [x, y].Value != null)
                        {
                            CurrentNode.AppendChild(XML.CreateTextNode(","));
                            BlocksCounter++;
                        }
                    }
                }
                // Sprawdzenie czy podane wartości są poprawne - wiersze
                if (BlocksCounter > GameHeight)
                {
                    MessageBox.Show("Wartości w wierszu " + (1 + y) + " osi Y są niepoprawne!");
                    return false;
                }
                BlocksCounter = 0;
            }
            return true;
        }

        // Dodanie nowej warstwy dla osi X
        private void ChangeXLayers(object sender, EventArgs e)
        {
            // Przypisanie nowej warstwy jeśli jest wieksza niż 0
            if (XLayersUpDown.Value > 0)
            {
                // Blokada przekroszenia wilkości obrazu
                if (XLayersUpDown.Value <= GameHeight)
                {
                    GridX.RowCount = XLayers = (int)XLayersUpDown.Value;
                } else
                    XLayersUpDown.Value = GameHeight;
            } else
            {
                XLayersUpDown.Value = 1;
            }
        }

        // Dodanie nowej warstwy dla osi Y
        private void ChangeYLayers(object sender, EventArgs e)
        {
            // Przypisanie nowej warstwy jeśli jest wieksza niż 0
            if (YLayersUpDown.Value > 0)
            {
                // Blokada przekroszenia wilkości obrazu
                if (YLayersUpDown.Value <= GameWidth)
                {
                    YLayers = GridY.ColumnCount = (int)YLayersUpDown.Value;
                    // Ustawnienie szerokości kolumny na 50
                    GridY.Columns [GridY.ColumnCount - 1].Width = 50;
                } else
                    YLayersUpDown.Value = GameWidth;
            } else
            {
                YLayersUpDown.Value = 1;
            }
        }

        // Zmiana szerokości obrazu
        private void WidthChange(object sender, EventArgs e)
        {
            // Przypisanie nowej szerokości jeśli jest wieksza niż 0
            if (WidthUpDown.Value > 0)
            {
                GameWidth = GridX.ColumnCount = (int)WidthUpDown.Value;
                // Ustawnienie szerokości kolumny na 50
                GridX.Columns [GridX.ColumnCount - 1].Width = 50;
            } else
            {
                WidthUpDown.Value = 1;
            }
            // Zmiana warstwy jeśli była ona równa szerokości
            ChangeYLayers(null, null);
        }

        // Zmiana wysokości obrazu
        private void HeightChange(object sender, EventArgs e)
        {
            // Przypisanie nowej wysokości jeśli jest wieksza niż 0
            if (HeightUpDown.Value > 0)
            {
                GameHeight = GridY.RowCount = (int)HeightUpDown.Value;
            } else
            {
                HeightUpDown.Value = 1;
            }
            // Zmiana warstwy jeśli była ona równa wysokości
            ChangeXLayers(null, null);
        }
    }
}
