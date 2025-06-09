
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Timers;

namespace GdzieJestDydelf
{
    public partial class Plansza : Form
    {
        int szerokosc, wysokosc, czas, liczbaDydelfow, liczbaSzopow, liczbaKrokodyli;
        Zwierze[,] pola;
        Button[,] przyciski;
        int znalezioneDydelfy = 0;
        System.Windows.Forms.Timer zegar;
        int pozostalyCzas;
        Random losuj = new Random();

        public Plansza(int szer, int wys, int czasSekundy, int dyd, int szopy, int krokodyle)
        {
            szerokosc = szer;
            wysokosc = wys;
            czas = czasSekundy;
            liczbaDydelfow = dyd;
            liczbaSzopow = szopy;
            liczbaKrokodyli = krokodyle;
            InitializeComponent();
            RozpocznijGre();
        }

        void RozpocznijGre()
        {
            pozostalyCzas = czas;
            pola = new Zwierze[wysokosc, szerokosc];
            przyciski = new Button[wysokosc, szerokosc];
            this.ClientSize = new Size(szerokosc * 40, wysokosc * 40 + 30);
            for (int y = 0; y < wysokosc; y++)
            {
                for (int x = 0; x < szerokosc; x++)
                {
                    Button b = new Button();
                    b.Size = new Size(40, 40);
                    b.Location = new Point(x * 40, y * 40);
                    b.Tag = new Point(x, y);
                    b.Click += Klikniecie;
                    Controls.Add(b);
                    przyciski[y, x] = b;
                }
            }

            LosujZwierze(Zwierze.Dydelf, liczbaDydelfow);
            LosujZwierze(Zwierze.Szop, liczbaSzopow);
            LosujZwierze(Zwierze.Krokodyl, liczbaKrokodyli);

            zegar = new System.Windows.Forms.Timer();
            zegar.Interval = 1000;
            zegar.Tick += Odliczanie;
            zegar.Start();
        }

        void LosujZwierze(Zwierze zwierze, int ilosc)
        {
            int wstawione = 0;
            while (wstawione < ilosc)
            {
                int x = losuj.Next(szerokosc);
                int y = losuj.Next(wysokosc);
                if (pola[y, x] == Zwierze.Puste)
                {
                    pola[y, x] = zwierze;
                    wstawione++;
                }
            }
        }

        void Odliczanie(object sender, EventArgs e)
        {
            pozostalyCzas--;
            this.Text = $"Pozostały czas: {pozostalyCzas}s";
            if (pozostalyCzas <= 0)
            {
                zegar.Stop();
                MessageBox.Show("Czas minął. Przegrana.");
                this.Close();
            }
        }

        async void Klikniecie(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Point p = (Point)b.Tag;
            int x = p.X;
            int y = p.Y;
            if (!b.Enabled) return;
            b.Enabled = false;
            switch (pola[y, x])
            {
                case Zwierze.Puste:
                    b.BackColor = Color.LightGray;
                    break;
                case Zwierze.Dydelf:
                    b.BackColor = Color.Green;
                    znalezioneDydelfy++;
                    if (znalezioneDydelfy >= liczbaDydelfow)
                    {
                        zegar.Stop();
                        MessageBox.Show("Wszystkie Dydelfy znalezione. Wygrana!");
                        this.Close();
                    }
                    break;
                case Zwierze.Szop:
                    b.BackColor = Color.Blue;
                    await Task.Delay(2000);
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            int nx = x + dx;
                            int ny = y + dy;
                            if (nx >= 0 && ny >= 0 && nx < szerokosc && ny < wysokosc)
                            {
                                przyciski[ny, nx].Enabled = false;
                                przyciski[ny, nx].BackColor = Color.DarkGray;
                            }
                        }
                    }
                    break;
                case Zwierze.Krokodyl:
                    b.BackColor = Color.Red;
                    var wynik = MessageBox.Show("Kliknij ponownie w ciągu 2 sekund!", "Uwaga!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (wynik == DialogResult.OK)
                    {
                        b.BackColor = Color.Gray;
                    }
                    else
                    {
                        zegar.Stop();
                        MessageBox.Show("Zaatakował Cię Krokodyl. Przegrana.");
                        this.Close();
                    }
                    break;
            }
        }
    }
}
