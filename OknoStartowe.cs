
using System;
using System.Windows.Forms;

namespace GdzieJestDydelf
{
    public partial class OknoStartowe : Form
    {
        public OknoStartowe()
        {
            InitializeComponent();
        }

        private void przyciskStart_Click(object sender, EventArgs e)
        {
            int szerokosc = (int)numericSzerokosc.Value;
            int wysokosc = (int)numericWysokosc.Value;
            int czas = (int)numericCzas.Value;
            int liczbaDydelfow = (int)numericDydelfy.Value;
            int liczbaSzopow = (int)numericSzopy.Value;
            int liczbaKrokodyli = (int)numericKrokodyle.Value;

            Hide();
            Plansza plansza = new Plansza(szerokosc, wysokosc, czas, liczbaDydelfow, liczbaSzopow, liczbaKrokodyli);
            plansza.ShowDialog();
            Show();
        }

        private void przyciskZakoncz_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
