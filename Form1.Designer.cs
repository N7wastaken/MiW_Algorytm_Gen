namespace AlGen
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // ============= Dywanik (Zadanie 1) =============
        private System.Windows.Forms.GroupBox grpDywanik;
        private System.Windows.Forms.Label lblPopulacjaDywanik;
        private System.Windows.Forms.TextBox txtPopulacjaDywanik;
        private System.Windows.Forms.Label lblBityDywanik;
        private System.Windows.Forms.TextBox txtBityDywanik;
        private System.Windows.Forms.Label lblIteracjeDywanik;
        private System.Windows.Forms.TextBox txtIteracjeDywanik;
        private System.Windows.Forms.Label lblTurniejDywanik;
        private System.Windows.Forms.TextBox txtTurniejDywanik;
        private System.Windows.Forms.Button btnStartDywanik;
        private System.Windows.Forms.Button btnStopDywanik;
        private System.Windows.Forms.TextBox txtWynikiDywanik;

        // ============= Sinus (Zadanie 2) =============
        private System.Windows.Forms.GroupBox grpSinus;
        private System.Windows.Forms.Label lblPopulacjaSinus;
        private System.Windows.Forms.TextBox txtPopulacjaSinus;
        private System.Windows.Forms.Label lblBitySinus;
        private System.Windows.Forms.TextBox txtBitySinus;
        private System.Windows.Forms.Label lblIteracjeSinus;
        private System.Windows.Forms.TextBox txtIteracjeSinus;
        private System.Windows.Forms.Label lblTurniejSinus;
        private System.Windows.Forms.TextBox txtTurniejSinus;
        private System.Windows.Forms.Button btnStartSinus;
        private System.Windows.Forms.Button btnStopSinus;
        private System.Windows.Forms.Button btnLoadSinusData; // <-- Nowy przycisk
        private System.Windows.Forms.TextBox txtWynikiSinus;

        // ============= XOR (Zadanie 3) =============
        private System.Windows.Forms.GroupBox grpXOR;
        private System.Windows.Forms.Label lblPopulacjaXOR;
        private System.Windows.Forms.TextBox txtPopulacjaXOR;
        private System.Windows.Forms.Label lblBityXOR;
        private System.Windows.Forms.TextBox txtBityXOR;
        private System.Windows.Forms.Label lblIteracjeXOR;
        private System.Windows.Forms.TextBox txtIteracjeXOR;
        private System.Windows.Forms.Label lblTurniejXOR;
        private System.Windows.Forms.TextBox txtTurniejXOR;
        private System.Windows.Forms.Button btnStartXOR;
        private System.Windows.Forms.Button btnStopXOR;
        private System.Windows.Forms.TextBox txtWynikiXOR;

        private System.Windows.Forms.Timer timerDywanik;
        private System.Windows.Forms.Timer timerSinus;
        private System.Windows.Forms.Timer timerXOR;

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

            // ------------------------------------------------------------
            // GROUPBOX: Dywanik (Zadanie 1)
            // ------------------------------------------------------------
            this.grpDywanik = new System.Windows.Forms.GroupBox();
            this.lblPopulacjaDywanik = new System.Windows.Forms.Label();
            this.txtPopulacjaDywanik = new System.Windows.Forms.TextBox();
            this.lblBityDywanik = new System.Windows.Forms.Label();
            this.txtBityDywanik = new System.Windows.Forms.TextBox();
            this.lblIteracjeDywanik = new System.Windows.Forms.Label();
            this.txtIteracjeDywanik = new System.Windows.Forms.TextBox();
            this.lblTurniejDywanik = new System.Windows.Forms.Label();
            this.txtTurniejDywanik = new System.Windows.Forms.TextBox();
            this.btnStartDywanik = new System.Windows.Forms.Button();
            this.btnStopDywanik = new System.Windows.Forms.Button();
            this.txtWynikiDywanik = new System.Windows.Forms.TextBox();

            // ------------------------------------------------------------
            // GROUPBOX: Sinus (Zadanie 2)
            // ------------------------------------------------------------
            this.grpSinus = new System.Windows.Forms.GroupBox();
            this.lblPopulacjaSinus = new System.Windows.Forms.Label();
            this.txtPopulacjaSinus = new System.Windows.Forms.TextBox();
            this.lblBitySinus = new System.Windows.Forms.Label();
            this.txtBitySinus = new System.Windows.Forms.TextBox();
            this.lblIteracjeSinus = new System.Windows.Forms.Label();
            this.txtIteracjeSinus = new System.Windows.Forms.TextBox();
            this.lblTurniejSinus = new System.Windows.Forms.Label();
            this.txtTurniejSinus = new System.Windows.Forms.TextBox();
            this.btnStartSinus = new System.Windows.Forms.Button();
            this.btnStopSinus = new System.Windows.Forms.Button();
            this.btnLoadSinusData = new System.Windows.Forms.Button(); // nowy
            this.txtWynikiSinus = new System.Windows.Forms.TextBox();

            // ------------------------------------------------------------
            // GROUPBOX: XOR (Zadanie 3)
            // ------------------------------------------------------------
            this.grpXOR = new System.Windows.Forms.GroupBox();
            this.lblPopulacjaXOR = new System.Windows.Forms.Label();
            this.txtPopulacjaXOR = new System.Windows.Forms.TextBox();
            this.lblBityXOR = new System.Windows.Forms.Label();
            this.txtBityXOR = new System.Windows.Forms.TextBox();
            this.lblIteracjeXOR = new System.Windows.Forms.Label();
            this.txtIteracjeXOR = new System.Windows.Forms.TextBox();
            this.lblTurniejXOR = new System.Windows.Forms.Label();
            this.txtTurniejXOR = new System.Windows.Forms.TextBox();
            this.btnStartXOR = new System.Windows.Forms.Button();
            this.btnStopXOR = new System.Windows.Forms.Button();
            this.txtWynikiXOR = new System.Windows.Forms.TextBox();

            this.timerDywanik = new System.Windows.Forms.Timer(this.components);
            this.timerSinus = new System.Windows.Forms.Timer(this.components);
            this.timerXOR = new System.Windows.Forms.Timer(this.components);

            // ------------------------------------------------------------
            // FORM (główne okno)
            // ------------------------------------------------------------
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(1060, 325);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AlGen";

            // ============================================================
            // Dywanik
            // ============================================================
            this.grpDywanik.Text = "Zadanie 1 (Dywanik)";
            this.grpDywanik.Location = new System.Drawing.Point(10, 10);
            this.grpDywanik.Size = new System.Drawing.Size(340, 140);

            this.lblPopulacjaDywanik.Text = "Populacja";
            this.lblPopulacjaDywanik.Location = new System.Drawing.Point(10, 25);
            this.lblPopulacjaDywanik.Size = new System.Drawing.Size(60, 23);

            this.txtPopulacjaDywanik.Text = "9";
            this.txtPopulacjaDywanik.Location = new System.Drawing.Point(80, 22);
            this.txtPopulacjaDywanik.Size = new System.Drawing.Size(50, 23);

            this.lblBityDywanik.Text = "Bity";
            this.lblBityDywanik.Location = new System.Drawing.Point(10, 55);
            this.lblBityDywanik.Size = new System.Drawing.Size(60, 23);

            this.txtBityDywanik.Text = "5";
            this.txtBityDywanik.Location = new System.Drawing.Point(80, 52);
            this.txtBityDywanik.Size = new System.Drawing.Size(50, 23);

            this.lblIteracjeDywanik.Text = "Iteracje";
            this.lblIteracjeDywanik.Location = new System.Drawing.Point(150, 25);
            this.lblIteracjeDywanik.Size = new System.Drawing.Size(60, 23);

            this.txtIteracjeDywanik.Text = "20";
            this.txtIteracjeDywanik.Location = new System.Drawing.Point(210, 22);
            this.txtIteracjeDywanik.Size = new System.Drawing.Size(50, 23);

            this.lblTurniejDywanik.Text = "Turniej";
            this.lblTurniejDywanik.Location = new System.Drawing.Point(150, 55);
            this.lblTurniejDywanik.Size = new System.Drawing.Size(60, 23);

            this.txtTurniejDywanik.Text = "2";
            this.txtTurniejDywanik.Location = new System.Drawing.Point(210, 52);
            this.txtTurniejDywanik.Size = new System.Drawing.Size(50, 23);

            this.btnStartDywanik.Text = "Start";
            this.btnStartDywanik.Location = new System.Drawing.Point(10, 90);
            this.btnStartDywanik.Size = new System.Drawing.Size(60, 30);

            this.btnStopDywanik.Text = "Stop";
            this.btnStopDywanik.Location = new System.Drawing.Point(80, 90);
            this.btnStopDywanik.Size = new System.Drawing.Size(60, 30);

            this.grpDywanik.Controls.Add(this.lblPopulacjaDywanik);
            this.grpDywanik.Controls.Add(this.txtPopulacjaDywanik);
            this.grpDywanik.Controls.Add(this.lblBityDywanik);
            this.grpDywanik.Controls.Add(this.txtBityDywanik);
            this.grpDywanik.Controls.Add(this.lblIteracjeDywanik);
            this.grpDywanik.Controls.Add(this.txtIteracjeDywanik);
            this.grpDywanik.Controls.Add(this.lblTurniejDywanik);
            this.grpDywanik.Controls.Add(this.txtTurniejDywanik);
            this.grpDywanik.Controls.Add(this.btnStartDywanik);
            this.grpDywanik.Controls.Add(this.btnStopDywanik);

            this.txtWynikiDywanik.Multiline = true;
            this.txtWynikiDywanik.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWynikiDywanik.Location = new System.Drawing.Point(10, 160);
            this.txtWynikiDywanik.Size = new System.Drawing.Size(340, 150);
            this.txtWynikiDywanik.ReadOnly = true; // <-- DODANE

            // ============================================================
            // Sinus
            // ============================================================
            this.grpSinus.Text = "Zadanie 2 (Sinus)";
            this.grpSinus.Location = new System.Drawing.Point(360, 10);
            this.grpSinus.Size = new System.Drawing.Size(340, 140);

            this.lblPopulacjaSinus.Text = "Populacja";
            this.lblPopulacjaSinus.Location = new System.Drawing.Point(10, 25);
            this.lblPopulacjaSinus.Size = new System.Drawing.Size(60, 23);

            this.txtPopulacjaSinus.Text = "13";
            this.txtPopulacjaSinus.Location = new System.Drawing.Point(80, 22);
            this.txtPopulacjaSinus.Size = new System.Drawing.Size(50, 23);

            this.lblBitySinus.Text = "Bity";
            this.lblBitySinus.Location = new System.Drawing.Point(10, 55);
            this.lblBitySinus.Size = new System.Drawing.Size(60, 23);

            this.txtBitySinus.Text = "4";
            this.txtBitySinus.Location = new System.Drawing.Point(80, 52);
            this.txtBitySinus.Size = new System.Drawing.Size(50, 23);

            this.lblIteracjeSinus.Text = "Iteracje";
            this.lblIteracjeSinus.Location = new System.Drawing.Point(150, 25);
            this.lblIteracjeSinus.Size = new System.Drawing.Size(60, 23);

            this.txtIteracjeSinus.Text = "100";
            this.txtIteracjeSinus.Location = new System.Drawing.Point(210, 22);
            this.txtIteracjeSinus.Size = new System.Drawing.Size(50, 23);

            this.lblTurniejSinus.Text = "Turniej";
            this.lblTurniejSinus.Location = new System.Drawing.Point(150, 55);
            this.lblTurniejSinus.Size = new System.Drawing.Size(60, 23);

            this.txtTurniejSinus.Text = "3";
            this.txtTurniejSinus.Location = new System.Drawing.Point(210, 52);
            this.txtTurniejSinus.Size = new System.Drawing.Size(50, 23);

            this.btnStartSinus.Text = "Start";
            this.btnStartSinus.Location = new System.Drawing.Point(10, 90);
            this.btnStartSinus.Size = new System.Drawing.Size(60, 30);

            this.btnStopSinus.Text = "Stop";
            this.btnStopSinus.Location = new System.Drawing.Point(80, 90);
            this.btnStopSinus.Size = new System.Drawing.Size(60, 30);

            // ---- NOWY PRZYCISK do wczytania pliku ----
            this.btnLoadSinusData.Text = "Wczytaj plik Sinus";
            this.btnLoadSinusData.Location = new System.Drawing.Point(210, 90);
            this.btnLoadSinusData.Size = new System.Drawing.Size(110, 30);

            this.grpSinus.Controls.Add(this.lblPopulacjaSinus);
            this.grpSinus.Controls.Add(this.txtPopulacjaSinus);
            this.grpSinus.Controls.Add(this.lblBitySinus);
            this.grpSinus.Controls.Add(this.txtBitySinus);
            this.grpSinus.Controls.Add(this.lblIteracjeSinus);
            this.grpSinus.Controls.Add(this.txtIteracjeSinus);
            this.grpSinus.Controls.Add(this.lblTurniejSinus);
            this.grpSinus.Controls.Add(this.txtTurniejSinus);
            this.grpSinus.Controls.Add(this.btnStartSinus);
            this.grpSinus.Controls.Add(this.btnStopSinus);
            this.grpSinus.Controls.Add(this.btnLoadSinusData);

            this.txtWynikiSinus.Multiline = true;
            this.txtWynikiSinus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWynikiSinus.Location = new System.Drawing.Point(360, 160);
            this.txtWynikiSinus.Size = new System.Drawing.Size(340, 150);
            this.txtWynikiSinus.ReadOnly = true; // <-- DODANE

            // ============================================================
            // XOR
            // ============================================================
            this.grpXOR.Text = "Zadanie 3 (XOR)";
            this.grpXOR.Location = new System.Drawing.Point(710, 10);
            this.grpXOR.Size = new System.Drawing.Size(340, 140);

            this.lblPopulacjaXOR.Text = "Populacja";
            this.lblPopulacjaXOR.Location = new System.Drawing.Point(10, 25);
            this.lblPopulacjaXOR.Size = new System.Drawing.Size(60, 23);

            this.txtPopulacjaXOR.Text = "13";
            this.txtPopulacjaXOR.Location = new System.Drawing.Point(80, 22);
            this.txtPopulacjaXOR.Size = new System.Drawing.Size(50, 23);

            this.lblBityXOR.Text = "Bity";
            this.lblBityXOR.Location = new System.Drawing.Point(10, 55);
            this.lblBityXOR.Size = new System.Drawing.Size(60, 23);

            this.txtBityXOR.Text = "5";
            this.txtBityXOR.Location = new System.Drawing.Point(80, 52);
            this.txtBityXOR.Size = new System.Drawing.Size(50, 23);

            this.lblIteracjeXOR.Text = "Iteracje";
            this.lblIteracjeXOR.Location = new System.Drawing.Point(150, 25);
            this.lblIteracjeXOR.Size = new System.Drawing.Size(60, 23);

            this.txtIteracjeXOR.Text = "100";
            this.txtIteracjeXOR.Location = new System.Drawing.Point(210, 22);
            this.txtIteracjeXOR.Size = new System.Drawing.Size(50, 23);

            this.lblTurniejXOR.Text = "Turniej";
            this.lblTurniejXOR.Location = new System.Drawing.Point(150, 55);
            this.lblTurniejXOR.Size = new System.Drawing.Size(60, 23);

            this.txtTurniejXOR.Text = "3";
            this.txtTurniejXOR.Location = new System.Drawing.Point(210, 52);
            this.txtTurniejXOR.Size = new System.Drawing.Size(50, 23);

            this.btnStartXOR.Text = "Start";
            this.btnStartXOR.Location = new System.Drawing.Point(10, 90);
            this.btnStartXOR.Size = new System.Drawing.Size(60, 30);

            this.btnStopXOR.Text = "Stop";
            this.btnStopXOR.Location = new System.Drawing.Point(80, 90);
            this.btnStopXOR.Size = new System.Drawing.Size(60, 30);

            this.grpXOR.Controls.Add(this.lblPopulacjaXOR);
            this.grpXOR.Controls.Add(this.txtPopulacjaXOR);
            this.grpXOR.Controls.Add(this.lblBityXOR);
            this.grpXOR.Controls.Add(this.txtBityXOR);
            this.grpXOR.Controls.Add(this.lblIteracjeXOR);
            this.grpXOR.Controls.Add(this.txtIteracjeXOR);
            this.grpXOR.Controls.Add(this.lblTurniejXOR);
            this.grpXOR.Controls.Add(this.txtTurniejXOR);
            this.grpXOR.Controls.Add(this.btnStartXOR);
            this.grpXOR.Controls.Add(this.btnStopXOR);

            this.txtWynikiXOR.Multiline = true;
            this.txtWynikiXOR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWynikiXOR.Location = new System.Drawing.Point(710, 160);
            this.txtWynikiXOR.Size = new System.Drawing.Size(340, 150);
            this.txtWynikiXOR.ReadOnly = true; // <-- DODANE

            // ------------------------------------------------------------
            // Ustawienia timerów
            // ------------------------------------------------------------
            this.timerDywanik.Interval = 500;
            this.timerSinus.Interval = 500;
            this.timerXOR.Interval = 500;

            // ------------------------------------------------------------
            // Dodaj grupy + pola wyników do formy
            // ------------------------------------------------------------
            this.Controls.Add(this.grpDywanik);
            this.Controls.Add(this.grpSinus);
            this.Controls.Add(this.grpXOR);

            this.Controls.Add(this.txtWynikiDywanik);
            this.Controls.Add(this.txtWynikiSinus);
            this.Controls.Add(this.txtWynikiXOR);

            this.ResumeLayout(false);
        }
    }
}
