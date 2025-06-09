
namespace GdzieJestDydelf
{
    partial class OknoStartowe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NumericUpDown numericSzerokosc;
        private System.Windows.Forms.NumericUpDown numericWysokosc;
        private System.Windows.Forms.NumericUpDown numericCzas;
        private System.Windows.Forms.NumericUpDown numericDydelfy;
        private System.Windows.Forms.NumericUpDown numericSzopy;
        private System.Windows.Forms.NumericUpDown numericKrokodyle;
        private System.Windows.Forms.Button przyciskStart;
        private System.Windows.Forms.Button przyciskZakoncz;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            numericSzerokosc = new System.Windows.Forms.NumericUpDown();
            numericWysokosc = new System.Windows.Forms.NumericUpDown();
            numericCzas = new System.Windows.Forms.NumericUpDown();
            numericDydelfy = new System.Windows.Forms.NumericUpDown();
            numericSzopy = new System.Windows.Forms.NumericUpDown();
            numericKrokodyle = new System.Windows.Forms.NumericUpDown();
            przyciskStart = new System.Windows.Forms.Button();
            przyciskZakoncz = new System.Windows.Forms.Button();
            SuspendLayout();

            numericSzerokosc.Minimum = 3;
            numericSzerokosc.Maximum = 10;
            numericSzerokosc.Value = 5;
            numericSzerokosc.Location = new System.Drawing.Point(10, 10);

            numericWysokosc.Minimum = 3;
            numericWysokosc.Maximum = 10;
            numericWysokosc.Value = 5;
            numericWysokosc.Location = new System.Drawing.Point(10, 40);

            numericCzas.Minimum = 10;
            numericCzas.Maximum = 60;
            numericCzas.Value = 30;
            numericCzas.Location = new System.Drawing.Point(10, 70);

            numericDydelfy.Minimum = 1;
            numericDydelfy.Maximum = 6;
            numericDydelfy.Value = 2;
            numericDydelfy.Location = new System.Drawing.Point(10, 100);

            numericSzopy.Minimum = 3;
            numericSzopy.Maximum = 8;
            numericSzopy.Value = 3;
            numericSzopy.Location = new System.Drawing.Point(10, 130);

            numericKrokodyle.Minimum = 0;
            numericKrokodyle.Maximum = 1;
            numericKrokodyle.Value = 1;
            numericKrokodyle.Location = new System.Drawing.Point(10, 160);

            przyciskStart.Text = "Start";
            przyciskStart.Location = new System.Drawing.Point(10, 190);
            przyciskStart.Click += new System.EventHandler(this.przyciskStart_Click);

            przyciskZakoncz.Text = "Zakończ";
            przyciskZakoncz.Location = new System.Drawing.Point(90, 190);
            przyciskZakoncz.Click += new System.EventHandler(this.przyciskZakoncz_Click);

            Controls.Add(numericSzerokosc);
            Controls.Add(numericWysokosc);
            Controls.Add(numericCzas);
            Controls.Add(numericDydelfy);
            Controls.Add(numericSzopy);
            Controls.Add(numericKrokodyle);
            Controls.Add(przyciskStart);
            Controls.Add(przyciskZakoncz);

            ClientSize = new System.Drawing.Size(200, 230);
            Text = "Gdzie jest Dydelf";
            ResumeLayout(false);
        }
    }
}
