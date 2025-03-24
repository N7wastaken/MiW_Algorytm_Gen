namespace ProjektStudent
{
    partial class Form1
    {
        // Deklaracje komponentów
        private System.ComponentModel.IContainer components = null;

        // Zad1
        private System.Windows.Forms.GroupBox grpZad1;
        private System.Windows.Forms.Label lblZ1Pop;
        private System.Windows.Forms.TextBox txtZ1Pop;
        private System.Windows.Forms.Label lblZ1Bits;
        private System.Windows.Forms.TextBox txtZ1Bits;
        private System.Windows.Forms.Label lblZ1Iter;
        private System.Windows.Forms.TextBox txtZ1Iter;
        private System.Windows.Forms.Label lblZ1Tourn;
        private System.Windows.Forms.TextBox txtZ1Tourn;
        private System.Windows.Forms.Button btnZ1Start;
        private System.Windows.Forms.Button btnZ1Stop;
        private System.Windows.Forms.TextBox txtZ1Wyniki;

        // Zad2
        private System.Windows.Forms.GroupBox grpZad2;
        private System.Windows.Forms.Label lblZ2Pop;
        private System.Windows.Forms.TextBox txtZ2Pop;
        private System.Windows.Forms.Label lblZ2Bits;
        private System.Windows.Forms.TextBox txtZ2Bits;
        private System.Windows.Forms.Label lblZ2Iter;
        private System.Windows.Forms.TextBox txtZ2Iter;
        private System.Windows.Forms.Label lblZ2Tourn;
        private System.Windows.Forms.TextBox txtZ2Tourn;
        private System.Windows.Forms.Button btnZ2Start;
        private System.Windows.Forms.Button btnZ2Stop;
        private System.Windows.Forms.TextBox txtZ2Wyniki;

        // Zad3
        private System.Windows.Forms.GroupBox grpZad3;
        private System.Windows.Forms.Label lblZ3Pop;
        private System.Windows.Forms.TextBox txtZ3Pop;
        private System.Windows.Forms.Label lblZ3Bits;
        private System.Windows.Forms.TextBox txtZ3Bits;
        private System.Windows.Forms.Label lblZ3Iter;
        private System.Windows.Forms.TextBox txtZ3Iter;
        private System.Windows.Forms.Label lblZ3Tourn;
        private System.Windows.Forms.TextBox txtZ3Tourn;
        private System.Windows.Forms.Button btnZ3Start;
        private System.Windows.Forms.Button btnZ3Stop;
        private System.Windows.Forms.TextBox txtZ3Wyniki;

        // Timery
        private System.Windows.Forms.Timer timerZad1;
        private System.Windows.Forms.Timer timerZad2;
        private System.Windows.Forms.Timer timerZad3;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Zad1
            this.grpZad1 = new System.Windows.Forms.GroupBox();
            this.lblZ1Pop = new System.Windows.Forms.Label();
            this.txtZ1Pop = new System.Windows.Forms.TextBox();
            this.lblZ1Bits = new System.Windows.Forms.Label();
            this.txtZ1Bits = new System.Windows.Forms.TextBox();
            this.lblZ1Iter = new System.Windows.Forms.Label();
            this.txtZ1Iter = new System.Windows.Forms.TextBox();
            this.lblZ1Tourn = new System.Windows.Forms.Label();
            this.txtZ1Tourn = new System.Windows.Forms.TextBox();
            this.btnZ1Start = new System.Windows.Forms.Button();
            this.btnZ1Stop = new System.Windows.Forms.Button();
            this.txtZ1Wyniki = new System.Windows.Forms.TextBox();

            // Zad2
            this.grpZad2 = new System.Windows.Forms.GroupBox();
            this.lblZ2Pop = new System.Windows.Forms.Label();
            this.txtZ2Pop = new System.Windows.Forms.TextBox();
            this.lblZ2Bits = new System.Windows.Forms.Label();
            this.txtZ2Bits = new System.Windows.Forms.TextBox();
            this.lblZ2Iter = new System.Windows.Forms.Label();
            this.txtZ2Iter = new System.Windows.Forms.TextBox();
            this.lblZ2Tourn = new System.Windows.Forms.Label();
            this.txtZ2Tourn = new System.Windows.Forms.TextBox();
            this.btnZ2Start = new System.Windows.Forms.Button();
            this.btnZ2Stop = new System.Windows.Forms.Button();
            this.txtZ2Wyniki = new System.Windows.Forms.TextBox();

            // Zad3
            this.grpZad3 = new System.Windows.Forms.GroupBox();
            this.lblZ3Pop = new System.Windows.Forms.Label();
            this.txtZ3Pop = new System.Windows.Forms.TextBox();
            this.lblZ3Bits = new System.Windows.Forms.Label();
            this.txtZ3Bits = new System.Windows.Forms.TextBox();
            this.lblZ3Iter = new System.Windows.Forms.Label();
            this.txtZ3Iter = new System.Windows.Forms.TextBox();
            this.lblZ3Tourn = new System.Windows.Forms.Label();
            this.txtZ3Tourn = new System.Windows.Forms.TextBox();
            this.btnZ3Start = new System.Windows.Forms.Button();
            this.btnZ3Stop = new System.Windows.Forms.Button();
            this.txtZ3Wyniki = new System.Windows.Forms.TextBox();

            // Timery
            this.timerZad1 = new System.Windows.Forms.Timer(this.components);
            this.timerZad2 = new System.Windows.Forms.Timer(this.components);
            this.timerZad3 = new System.Windows.Forms.Timer(this.components);

            // Ustawienia Form
            this.SuspendLayout();
            // Rozmiar okna
            this.ClientSize = new System.Drawing.Size(1080, 520);
            this.Name = "Form1";
            this.Text = "Zadania Genetyczne - Student";

            // =====================
            // Zadanie 1
            // =====================
            this.grpZad1.Text = "Zadanie 1 (Dywanik)";
            // Pozycja i rozmiar groupBox
            this.grpZad1.Location = new System.Drawing.Point(10, 10);
            this.grpZad1.Size = new System.Drawing.Size(340, 140);

            // Label Populacja
            this.lblZ1Pop.Text = "Populacja";
            this.lblZ1Pop.Location = new System.Drawing.Point(10, 25);
            this.lblZ1Pop.Size = new System.Drawing.Size(60, 23);
            // Pole Populacja
            this.txtZ1Pop.Text = "9";
            this.txtZ1Pop.Location = new System.Drawing.Point(80, 22);
            this.txtZ1Pop.Size = new System.Drawing.Size(50, 23);

            // Label Bity
            this.lblZ1Bits.Text = "Bity";
            this.lblZ1Bits.Location = new System.Drawing.Point(10, 55);
            this.lblZ1Bits.Size = new System.Drawing.Size(60, 23);
            // Pole Bity
            this.txtZ1Bits.Text = "5";
            this.txtZ1Bits.Location = new System.Drawing.Point(80, 52);
            this.txtZ1Bits.Size = new System.Drawing.Size(50, 23);

            // Label Iteracje
            this.lblZ1Iter.Text = "Iteracje";
            this.lblZ1Iter.Location = new System.Drawing.Point(150, 25);
            this.lblZ1Iter.Size = new System.Drawing.Size(60, 23);
            // Pole Iteracje
            this.txtZ1Iter.Text = "20";
            this.txtZ1Iter.Location = new System.Drawing.Point(210, 22);
            this.txtZ1Iter.Size = new System.Drawing.Size(50, 23);

            // Label Turniej
            this.lblZ1Tourn.Text = "Turniej";
            this.lblZ1Tourn.Location = new System.Drawing.Point(150, 55);
            this.lblZ1Tourn.Size = new System.Drawing.Size(60, 23);
            // Pole Turniej
            this.txtZ1Tourn.Text = "2";
            this.txtZ1Tourn.Location = new System.Drawing.Point(210, 52);
            this.txtZ1Tourn.Size = new System.Drawing.Size(50, 23);

            // Przycisk Start
            this.btnZ1Start.Text = "Start";
            this.btnZ1Start.Location = new System.Drawing.Point(10, 90);
            this.btnZ1Start.Size = new System.Drawing.Size(60, 30);
            // Przycisk Stop
            this.btnZ1Stop.Text = "Stop";
            this.btnZ1Stop.Location = new System.Drawing.Point(80, 90);
            this.btnZ1Stop.Size = new System.Drawing.Size(60, 30);

            // Dodaj do groupBox Zad1
            this.grpZad1.Controls.Add(this.lblZ1Pop);
            this.grpZad1.Controls.Add(this.txtZ1Pop);
            this.grpZad1.Controls.Add(this.lblZ1Bits);
            this.grpZad1.Controls.Add(this.txtZ1Bits);
            this.grpZad1.Controls.Add(this.lblZ1Iter);
            this.grpZad1.Controls.Add(this.txtZ1Iter);
            this.grpZad1.Controls.Add(this.lblZ1Tourn);
            this.grpZad1.Controls.Add(this.txtZ1Tourn);
            this.grpZad1.Controls.Add(this.btnZ1Start);
            this.grpZad1.Controls.Add(this.btnZ1Stop);

            // Pole wyników Zad1
            this.txtZ1Wyniki.Multiline = true;
            this.txtZ1Wyniki.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtZ1Wyniki.Location = new System.Drawing.Point(10, 160);
            this.txtZ1Wyniki.Size = new System.Drawing.Size(340, 150);

            // =====================
            // Zadanie 2
            // =====================
            this.grpZad2.Text = "Zadanie 2 (Sinusik)";
            this.grpZad2.Location = new System.Drawing.Point(360, 10);
            this.grpZad2.Size = new System.Drawing.Size(340, 140);

            this.lblZ2Pop.Text = "Populacja";
            this.lblZ2Pop.Location = new System.Drawing.Point(10, 25);
            this.txtZ2Pop.Text = "13";
            this.txtZ2Pop.Location = new System.Drawing.Point(80, 22);
            this.txtZ2Pop.Size = new System.Drawing.Size(50, 23);

            this.lblZ2Bits.Text = "Bity";
            this.lblZ2Bits.Location = new System.Drawing.Point(10, 55);
            this.txtZ2Bits.Text = "4";
            this.txtZ2Bits.Location = new System.Drawing.Point(80, 52);
            this.txtZ2Bits.Size = new System.Drawing.Size(50, 23);

            this.lblZ2Iter.Text = "Iteracje";
            this.lblZ2Iter.Location = new System.Drawing.Point(150, 25);
            this.txtZ2Iter.Text = "20";
            this.txtZ2Iter.Location = new System.Drawing.Point(210, 22);
            this.txtZ2Iter.Size = new System.Drawing.Size(50, 23);

            this.lblZ2Tourn.Text = "Turniej";
            this.lblZ2Tourn.Location = new System.Drawing.Point(150, 55);
            this.txtZ2Tourn.Text = "3";
            this.txtZ2Tourn.Location = new System.Drawing.Point(210, 52);
            this.txtZ2Tourn.Size = new System.Drawing.Size(50, 23);

            this.btnZ2Start.Text = "Start";
            this.btnZ2Start.Location = new System.Drawing.Point(10, 90);
            this.btnZ2Start.Size = new System.Drawing.Size(60, 30);

            this.btnZ2Stop.Text = "Stop";
            this.btnZ2Stop.Location = new System.Drawing.Point(80, 90);
            this.btnZ2Stop.Size = new System.Drawing.Size(60, 30);

            this.grpZad2.Controls.Add(this.lblZ2Pop);
            this.grpZad2.Controls.Add(this.txtZ2Pop);
            this.grpZad2.Controls.Add(this.lblZ2Bits);
            this.grpZad2.Controls.Add(this.txtZ2Bits);
            this.grpZad2.Controls.Add(this.lblZ2Iter);
            this.grpZad2.Controls.Add(this.txtZ2Iter);
            this.grpZad2.Controls.Add(this.lblZ2Tourn);
            this.grpZad2.Controls.Add(this.txtZ2Tourn);
            this.grpZad2.Controls.Add(this.btnZ2Start);
            this.grpZad2.Controls.Add(this.btnZ2Stop);

            this.txtZ2Wyniki.Multiline = true;
            this.txtZ2Wyniki.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtZ2Wyniki.Location = new System.Drawing.Point(360, 160);
            this.txtZ2Wyniki.Size = new System.Drawing.Size(340, 150);

            // =====================
            // Zadanie 3
            // =====================
            this.grpZad3.Text = "Zadanie 3 (XOR)";
            this.grpZad3.Location = new System.Drawing.Point(710, 10);
            this.grpZad3.Size = new System.Drawing.Size(340, 140);

            this.lblZ3Pop.Text = "Populacja";
            this.lblZ3Pop.Location = new System.Drawing.Point(10, 25);
            this.txtZ3Pop.Text = "13";
            this.txtZ3Pop.Location = new System.Drawing.Point(80, 22);
            this.txtZ3Pop.Size = new System.Drawing.Size(50, 23);

            this.lblZ3Bits.Text = "Bity";
            this.lblZ3Bits.Location = new System.Drawing.Point(10, 55);
            this.txtZ3Bits.Text = "5";
            this.txtZ3Bits.Location = new System.Drawing.Point(80, 52);
            this.txtZ3Bits.Size = new System.Drawing.Size(50, 23);

            this.lblZ3Iter.Text = "Iteracje";
            this.lblZ3Iter.Location = new System.Drawing.Point(150, 25);
            this.txtZ3Iter.Text = "20";
            this.txtZ3Iter.Location = new System.Drawing.Point(210, 22);
            this.txtZ3Iter.Size = new System.Drawing.Size(50, 23);

            this.lblZ3Tourn.Text = "Turniej";
            this.lblZ3Tourn.Location = new System.Drawing.Point(150, 55);
            this.txtZ3Tourn.Text = "3";
            this.txtZ3Tourn.Location = new System.Drawing.Point(210, 52);
            this.txtZ3Tourn.Size = new System.Drawing.Size(50, 23);

            this.btnZ3Start.Text = "Start";
            this.btnZ3Start.Location = new System.Drawing.Point(10, 90);
            this.btnZ3Start.Size = new System.Drawing.Size(60, 30);

            this.btnZ3Stop.Text = "Stop";
            this.btnZ3Stop.Location = new System.Drawing.Point(80, 90);
            this.btnZ3Stop.Size = new System.Drawing.Size(60, 30);

            this.grpZad3.Controls.Add(this.lblZ3Pop);
            this.grpZad3.Controls.Add(this.txtZ3Pop);
            this.grpZad3.Controls.Add(this.lblZ3Bits);
            this.grpZad3.Controls.Add(this.txtZ3Bits);
            this.grpZad3.Controls.Add(this.lblZ3Iter);
            this.grpZad3.Controls.Add(this.txtZ3Iter);
            this.grpZad3.Controls.Add(this.lblZ3Tourn);
            this.grpZad3.Controls.Add(this.txtZ3Tourn);
            this.grpZad3.Controls.Add(this.btnZ3Start);
            this.grpZad3.Controls.Add(this.btnZ3Stop);

            this.txtZ3Wyniki.Multiline = true;
            this.txtZ3Wyniki.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtZ3Wyniki.Location = new System.Drawing.Point(710, 160);
            this.txtZ3Wyniki.Size = new System.Drawing.Size(340, 150);

            // Ustawienia timerów
            this.timerZad1.Interval = 500;
            this.timerZad2.Interval = 500;
            this.timerZad3.Interval = 500;

            // Dodaj kontenery do Form
            this.Controls.Add(this.grpZad1);
            this.Controls.Add(this.grpZad2);
            this.Controls.Add(this.grpZad3);

            // Dodaj pola wyników
            this.Controls.Add(this.txtZ1Wyniki);
            this.Controls.Add(this.txtZ2Wyniki);
            this.Controls.Add(this.txtZ3Wyniki);

            // Kończymy
            this.ResumeLayout(false);
        }
    }
}
