using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace NonoGram {
    public class Nonogram {

        // Reprezentacja stanu pojedyńczego pola
        public enum State { Empty, Box /*,LockEmpty ,LockBox*/}
        // Zmienna pliku XML
        private XmlDocument NonogramXML;

        // Pola opisujące obraz
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int InfoSizeX { get; private set; }
        public int InfoSizeY { get; private set; }
        public bool NonogramLoaded { get; private set; }
        // Dane o obrazie
        public List<List<int>> DataX { get; private set; }
        public List<List<int>> DataY { get; private set; }
        public State[,] NonogramMatrix { get; private set; }

        // Konstruktor
        public Nonogram() {
            // Wartości domyślne
            Width = Height = InfoSizeX = InfoSizeY = 0;
            DataX = new List<List<int>>();
            DataY = new List<List<int>>();
            NonogramLoaded = false;
            NonogramXML = new XmlDocument();
        }

        // Wczytanie XML z pliku
        public void LoadNonogramXML(string NonogramXMLPath) {
            NonogramXML.Load(NonogramXMLPath);
            ReadData();
        }

        // Wczytanie XML z pamięci
        public void LoadNonogramXML(XmlDocument xML) {
            NonogramXML = xML;
            ReadData();
        }

        // Odczyt danych z XML 
        private void ReadData() {
            // Gra nie została (jeszcze) wczytana
            NonogramLoaded = false;
            // Sprawdzenie czy element root xml jest poprawny
            if (NonogramXML.DocumentElement.Name == "BinLogic") {
                // Odczyt ilości kolumn i wierszy
                Width = NonogramXML.DocumentElement.GetElementsByTagName("Column").Count;
                Height = NonogramXML.DocumentElement.GetElementsByTagName("Row").Count;

                // Stworzenie tablick obrazu dla zadanej wielkości
                NonogramMatrix = new State[Width, Height];

                // Zainicjalizowanie obazu zerami
                int y = 0;
                for (; y < Height; y++) {
                    for (int x = 0; x < Width; x++) {
                        NonogramMatrix[x, y] = State.Empty;
                    }
                }

                y = 0;
                // Pobranie list wszystkich kolumn z XML
                XmlNodeList Columns = NonogramXML.DocumentElement.GetElementsByTagName("Column");
                foreach (XmlNode Value in Columns) {
                    // Podział zawrtości danego pola weług ',' (kolejna grupa)
                    string[] Vals = Regex.Replace(Value.InnerText, "[^0-9,]", "").Split(',');
                    // Zliczanie ilości grup
                    if (Vals.Length > InfoSizeX) InfoSizeX = Vals.Length;
                    // Zapis wartości do listy
                    DataX.Add(new List<int>());
                    foreach (string V in Vals) {
                        // Jeśli dane pole jest puste albo mniejsze niż 0 wstawia 0 inaczej przepisuje wartość
                        if (V == null || V.Length <= 0)
                            DataX[y].Add(0);
                        else
                            DataX[y].Add(Int32.Parse(V));
                        // TODO: if(ilość == height) LockBox/LockEmpty
                    }
                    y++;
                }

                y = 0;

                // Pobranie list wszystkich wierszy z XML
                XmlNodeList Rows = NonogramXML.DocumentElement.GetElementsByTagName("Row");
                foreach (XmlNode Value in Rows) {
                    // Podział zawrtości danego pola weług ',' (kolejna grupa)
                    string[] Vals = Regex.Replace(Value.InnerText, "[^0-9,]", "").Split(',');
                    // Zliczanie ilości grup
                    if (Vals.Length > InfoSizeY) InfoSizeY = Vals.Length;
                    // Zapis wartości do listy
                    DataY.Add(new List<int>());
                    foreach (string V in Vals) {
                        // Jeśli dane pole jest puste albo mniejsze niż 0 wstawia 0 inaczej przepisuje wartość
                        if (V == null || V.Length <= 0)
                            DataY[y].Add(0);
                        else
                            DataY[y].Add(Int32.Parse(V));
                        // TODO: if(ilość == width) LockBox/LockEmpty
                    }
                    y++;
                }

                // Wykasowanie pól z wartościami równymi 0
                for (int i = 0; i < DataY.Count; i++) {
                    DataY[i].RemoveAll(m => m == 0);
                }

                for (int i = 0; i < DataX.Count; i++) {
                    DataX[i].RemoveAll(m => m == 0);
                }
                // Gra została załadowana
                NonogramLoaded = true;
            } else {
                throw new Exception("Plik XML jest uszkodzony");
            }
        }

        // Wykonanie kolejnego kroku w rozwiązywaniu
        public bool ForceNextStep() {
            // Bufor zapisu stanu obrazu w postaci bitów
            string Bits = "";

            int x = 0, y = 0;

            // Zapis pól obrazu do bufora
            for (y = 0; y < Height; y++) {
                for (x = 0; x < Width; x++) {
                    if (NonogramMatrix[x, y] == State.Empty)
                        Bits += "0";
                    else
                        Bits += "1";

                }
            }
            // Sprawdzenie czy w buforze znajduje sie maksymalna liczba '1' (ostatnia kombinacja)
            if (Bits.Replace("0", "").Length == (Width * Height)) return false;

            // Zmiana liczby na int w systemie dziesiętnym dodanie 1 i zapis do bufora w postaci tekstu liczy binarnej
            Bits = Convert.ToString(Convert.ToInt64(Bits, 2) + 1, 2);

            // Dodanie brakujących zer na początku
            for (int i = Bits.Length; i < (Width * Height); i++) {
                Bits = "0" + Bits;
            }

            x = 0; y = 0;
            // Zmiane bufora na tablice znaków
            char[] BitsArray = Bits.ToCharArray(); ;

            // Zapisanie nowego układu do głównej tablicy obrazu
            foreach (char Bit in BitsArray) {
                NonogramMatrix[x, y] = (State)Int32.Parse(Bit.ToString());
                if (++x >= Width) { x = 0; y++; }
            }
            return true;
        }

        // Sprawdzenie czy aktualny stan pasuje do definicji obrazu
        public bool IsNonogramCorrect() {
            // Bufor do zliczania grup
            List<List<int>> Counter = new List<List<int>>();
            // Licznik grupy
            int CounterOffset = 0;

            // Liczenie grup na osi X
            for (int y = 0; y < Height; y++) {
                Counter.Add(new List<int>());
                for (int x = 0; x < Width; x++) {
                    if (x == 0) 
                        Counter[y].Add(0);
                    
                    if (NonogramMatrix[x, y] == State.Box) {
                        Counter[y][CounterOffset]++;
                    } else if (NonogramMatrix[x, y] == State.Empty) {
                        Counter[y].Add(0);
                        CounterOffset++;
                    }
                }
                CounterOffset = 0;
            }
            // Kasowanie pól zawierających 0
            for (int i = 0; i < Counter.Count; i++) {
                Counter[i].RemoveAll(m => m == 0);
            }
            // Porównywanie grup z aktywnej gry i definicji obrazka
            if (!CompateLists(Counter, DataY)) return false;

            // Czyszczenie bufora zliczania
            Counter.Clear();
            // Wyzerowanie licznika grupy
            CounterOffset = 0;

            // Liczenie grup na osi Y
            for (int x = 0; x < Width; x++) {
                Counter.Add(new List<int>());
                for (int y = 0; y < Height; y++) {
                    if (y == 0) 
                        Counter[x].Add(0);
                    
                    if (NonogramMatrix[x, y] == State.Box) {
                        Counter[x][CounterOffset]++;
                    } else if (NonogramMatrix[x, y] == State.Empty) {
                        Counter[x].Add(0);
                        CounterOffset++;
                    }
                }
                CounterOffset = 0;
            }
            // Kasowanie pól zawierających 0
            for (int i = 0; i < Counter.Count; i++) {
                Counter[i].RemoveAll(m => m == 0);
            }
            // Porównywanie grup z aktywnej gry i definicji obrazka
            if (!CompateLists(Counter, DataX)) return false;

            // Obie osie są identyczne
            return true;
        }

        // Porównanie dwóch list
        private bool CompateLists(List<List<int>> ListA, List<List<int>> ListB) {
            // Sprawdzenie rozmiaru tablicy
            if (ListA.Count() != ListB.Count()) return false;

            for (int x = 0; x < ListA.Count; x++) {
                // Sprawdzenie rozmiaru 1 wymiaru tablicy
                if (ListA[x].Count != ListB[x].Count) return false;

                // Porównanie elementów
                for (int y = 0; y < ListA[x].Count; y++) {
                    if (ListA[x][y] != ListB[x][y]) return false;
                }
            }
            return true;
        }
    }
}