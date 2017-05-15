using NonoGram;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NonogramSolver
{
    public partial class MainWindow : Form
    {
        // Obiekt gry i bufory obrazu
        private Nonogram Game;
        private Graphics GamePanelGraphics;
        private Bitmap GamePanelBitmap;
        // Kontrola i stan rozwiązywania
        private bool Solving;
        private Timer SolvingInterval;
        // Rozmiar kratki w UI
        private const int BoxSize = 40;

        // Konstruktor
        public MainWindow()
        {
            InitializeComponent();
            // Wartości początkowe
            Game = new Nonogram();
            Solving = false;

            // Stworzenie nowe Timera i przypisanie mu metodi i interwału
            SolvingInterval = new Timer();
            SolvingInterval.Tick += new EventHandler(NextSolveStage);
            SolvingInterval.Interval = 1;
        }

        // Aktualizacja widoku głównego programu
        private void UpdateView()
        {
            // Aktualizacja tylko jeśli XML został wczytany 
            if (Game.NonogramLoaded)
            {
                // Wyczyszczenie okne
                GamePanelGraphics.Clear(GamePanel.BackColor);
                // Elementy uzywane do rysowania gry
                Pen Pen = new Pen(Color.Black, 1);
                Pen GameBoardPen = new Pen(Color.Black, 2);
                Brush Boxes = new SolidBrush(Color.Black);
                Font TextFont = new Font("Arial", 11);
                // Rysowanie definicji grup na osi X
                for (int y = 0; y < Game.InfoSizeX; y++)
                {
                    for (int x = 0; x < Game.Width; x++)
                    {
                        // Wstawienie wartości grupy
                        try
                        {
                            GamePanelGraphics.DrawString(Game.DataX.ElementAt(x).ElementAt(y).ToString(), TextFont, Boxes,
                                new Point((x * BoxSize) + GamePanel.AutoScrollPosition.X + (int)(Game.InfoSizeY * BoxSize + (BoxSize * 0.3)),
                                    ((y) * BoxSize) + GamePanel.AutoScrollPosition.Y + (int)(BoxSize * 0.3)));
                        } catch (Exception ex) { }
                    }
                }
                // Rysowanie definicji grup na osi Y
                for (int y = 0; y < Game.InfoSizeY; y++)
                {
                    for (int x = 0; x < Game.Height; x++)
                    {
                        // Wstawienie wartości grupy
                        try
                        {
                            GamePanelGraphics.DrawString(Game.DataY.ElementAt(x).ElementAt(y).ToString(), TextFont, Boxes,
                                new Point((y * BoxSize) + GamePanel.AutoScrollPosition.X + (int)(BoxSize * 0.3),
                                    ((x) * BoxSize) + GamePanel.AutoScrollPosition.Y + (int)(Game.InfoSizeX * BoxSize + (BoxSize * 0.3))));
                        } catch (Exception ex) { }
                    }
                }
                // Rysowanie kratek gry
                for (int y = 0; y < Game.Height + Game.InfoSizeX; y++)
                {
                    for (int x = 0; x < Game.Width + Game.InfoSizeY; x++)
                    {
                        // Pominięcie obszaru bez kratek (lewa-góra)
                        if (x >= Game.InfoSizeY || y >= Game.InfoSizeX)
                        {
                            // Rysowanie siatki - jeśli jest obszarem gry stosuje grupszą linie
                            GamePanelGraphics.DrawRectangle((x >= Game.InfoSizeY && y >= Game.InfoSizeX) ? GameBoardPen : Pen,
                            (x * BoxSize) + GamePanel.AutoScrollPosition.X,
                            (y * BoxSize) + GamePanel.AutoScrollPosition.Y, BoxSize, BoxSize);
                            // Jeśli rysowane są pola gry sprawdza czy są one 'Box'ami i je wypełnia
                            if ((x >= Game.InfoSizeY && y >= Game.InfoSizeX))
                            {
                                if (Game.NonogramMatrix [x - Game.InfoSizeY, y - Game.InfoSizeX] == Nonogram.State.Box)
                                {
                                    GamePanelGraphics.FillRectangle(Boxes, (x * BoxSize) + GamePanel.AutoScrollPosition.X,
                                    (y * BoxSize) + GamePanel.AutoScrollPosition.Y, BoxSize, BoxSize);
                                }
                            }
                        }
                    }
                }
                GamePanel.CreateGraphics().DrawImage(GamePanelBitmap, 0, 0);

                // Usuwa elementy
                TextFont.Dispose();
                Pen.Dispose();
                Boxes.Dispose();
                GameBoardPen.Dispose();
            }
        }

        // Generacja wyniku
        private void GenerateResultBitmap()
        {
            Brush BlackBoxes = new SolidBrush(Color.Black);
            Brush WhiteBoxes = new SolidBrush(Color.White);

            // Wyczyszczenie okna
            GamePanelGraphics.Clear(GamePanel.BackColor);
            GamePanel.CreateGraphics().DrawImage(GamePanelBitmap, 0, 0);

            // Stworzenie bufora dla obrazu wyjściowego
            GamePanelBitmap = new Bitmap(Game.Width * BoxSize, Game.Height * BoxSize);
            GamePanelGraphics = Graphics.FromImage(GamePanelBitmap);

            // Generacja wyniku
            for (int y = 0; y < Game.Height; y++)
            {
                for (int x = 0; x < Game.Width; x++)
                {
                    GamePanelGraphics.FillRectangle(
                        (Game.NonogramMatrix [x, y] == Nonogram.State.Box) ? BlackBoxes : WhiteBoxes,
                        (x * BoxSize),(y * BoxSize), BoxSize, BoxSize);

                }
            }
            // Wyświetlenie wyniku
            GamePanel.CreateGraphics().DrawImage(GamePanelBitmap, 0, 0);
            BlackBoxes.Dispose();
            WhiteBoxes.Dispose();
        }

        // Wykonanie kroku w szukaniu rozwiązania
        private void NextSolveStage(object sender, EventArgs e)
        {
            // Odświeżenie widoku
            UpdateView();
            // Sprawdzenie czy aktualny układ jest poprawny
            if (Game.IsNonogramCorrect())
            {
                // Wyłączenie szukania ,zapis obrazu i poinformowanie o znalezieniu rozwiązania
                ToongleSolvingState(null, null);
                // Wygenerowanie wyniku
                GenerateResultBitmap();
                // Zapis do bitmapy ( Rozwiązanie Dzień-Miesiąc-Rok Godzina_Minuta_Sekunda )
                GamePanelBitmap.Save("Rozwiazanie " + DateTime.Now.ToString("dd-MM-yyyy") + " " + DateTime.Now.ToString("HH_mm_ss") + ".bmp");
                MessageBox.Show("Znaleziono rozwiązanie!");
                return;
            }
            // Wykonanie kolejnego kroku w kombinacji (false jeśli to ostatnia możliwa kombinacja)
            if (!Game.ForceNextStep())
            {
                // Wyłączenie szukania i poinformowanie o nie znalezieniu rozwiązania
                ToongleSolvingState(null, null);
                MessageBox.Show("Nie znaleziono rozwiązanie!");
            }
        }

        // Wczytanie definicji obrazu z pliku
        private void LoadXML(object sender, EventArgs e)
        {
            // Otwarcie dialogu wybierania pliku z filtrem dla plików XML
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Filter = "XML | *.xml";
            DialogResult Result = FileDialog.ShowDialog();

            // Sprawdzienie czy wybrano plik i czy jest on typu xml
            if (Result == DialogResult.OK && FileDialog.FileName.Remove(0, FileDialog.FileName.Length - 3).ToLower() == "xml")
            {
                // Stworzenie nowej gey na podstawi wybranego pliku
                Game = new Nonogram();
                try
                {
                    Game.LoadNonogramXML(FileDialog.FileName);
                } catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił bład podczas wczytywania pliku:\n" + ex.Message);
                }
                // Sworzenie bitmapy i odblokowywanie przycisków
                CreateBitmap();
            }
        }

        // Tworzenie nowego własnego obrazu
        private void CreateNewNonogram(object sender, EventArgs e)
        {
            // Otwarcie okne tworzenia nowego obrazu
            CreateNonogram NewNonogram = new CreateNonogram();
            NewNonogram.ShowDialog();

            //Sprawdzenie czy został stworzony nowy obraz
            if (NewNonogram.XML != null && NewNonogram.NonogramCreated)
            {
                // Stworzenie nowej gry na podstawie informacji użytkownika
                Game = new Nonogram();
                try
                {
                    Game.LoadNonogramXML(NewNonogram.XML);
                } catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił bład podczas wczytywania pliku:\n" + ex.Message);
                }
                // Sworzenie bitmapy i odblokowywanie przycisków
                CreateBitmap();
            }
        }

        // Sworzenie bitmapy dla wybranego xml i odblokowywanie przycisków
        private void CreateBitmap()
        {
            // Odblokowanie przycisku rozpoczynania rozwiązywania
            StartSolvingButton.Enabled = true;
            // Wyczyszenie okna jeśli znajduje się na nim już jakiś obraz

            // Wyczyszczenie okne
            if (GamePanelGraphics != null)
            {
                GamePanelGraphics.Clear(GamePanel.BackColor);
                GamePanel.CreateGraphics().DrawImage(GamePanelBitmap, 0, 0);
            }
            // Tworzy scroll bar aby można było przewijać większe obrazy
            GamePanel.AutoScrollPosition = new Point(0, 0);
            GamePanel.AutoScrollMinSize = new Size(((Game.Width + Game.InfoSizeY) * BoxSize) + 1, ((Game.Height + Game.InfoSizeX) * BoxSize) + 1);

            // Stworzenie bitmapy dla aktualnie wybranego przykładu
            GamePanelBitmap = new Bitmap(((Game.Width + Game.InfoSizeY) * BoxSize) + 1, ((Game.Height + Game.InfoSizeX) * BoxSize) + 1);
            GamePanelGraphics = Graphics.FromImage(GamePanelBitmap);
            //Odświeżenie okna
            UpdateView();
        }

        // Przełączenie stanu rozwiązywania obrazu
        private void ToongleSolvingState(object sender, EventArgs e)
        {
            // Przełączanie stanów przycisków
            StopSolvingButton.Enabled = !Solving;
            StartSolvingButton.Enabled = Solving;
            LoadXMLButton.Enabled = Solving;
            CreateNonogramButton.Enabled = Solving;

            // Włączanie i wyłączanie wywoływania metody rozwiązywania
            if (Solving)
                SolvingInterval.Stop();
            else
                SolvingInterval.Start();
            //Przełączenie stanu zadania
            Solving = !Solving;
        }

        // Otwieranie okna "O programie"
        private void AboutProgram(object sender, EventArgs e)
        {
            AboutProgram About = new AboutProgram();
            About.ShowDialog();
        }

        // Odświeżanie okna przy przesówaniu okna
        private void WindowUpdate(object sender, EventArgs e) { UpdateView(); }

        // Generowanie i rysowanie obrazu w oknie przy przewijaniu
        private void WindowUpdate(object sender, ScrollEventArgs e) { UpdateView(); }

        // Przerysowanie okna przy przesówaniu okna
        private void WindowRedraw(object sender, EventArgs e)
        {
            if (GamePanelGraphics != null)
            {
                GamePanel.CreateGraphics().DrawImage(GamePanelBitmap, 0, 0);
            }
        }
    }
}
