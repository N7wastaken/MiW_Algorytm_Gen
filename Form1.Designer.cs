namespace DywanikReal
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblInfo;

        private System.Windows.Forms.Label labelPop;
        private System.Windows.Forms.TextBox txtPopSize;
        private System.Windows.Forms.Label labelMutRate;
        private System.Windows.Forms.TextBox txtMutRate;
        private System.Windows.Forms.Label labelMutStep;
        private System.Windows.Forms.TextBox txtMutStep;

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
            this.btnInit = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblInfo = new System.Windows.Forms.Label();

            this.labelPop = new System.Windows.Forms.Label();
            this.txtPopSize = new System.Windows.Forms.TextBox();
            this.labelMutRate = new System.Windows.Forms.Label();
            this.txtMutRate = new System.Windows.Forms.TextBox();
            this.labelMutStep = new System.Windows.Forms.Label();
            this.txtMutStep = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();

            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(10, 10);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(80, 30);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(10, 45);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(80, 30);
            this.btnStep.TabIndex = 1;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(10, 80);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(80, 30);
            this.btnAuto.TabIndex = 2;
            this.btnAuto.Text = "Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // chart1
            // 
            this.chart1.Location = new System.Drawing.Point(100, 10);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(500, 200);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(100, 220);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(500, 23);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Info...";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPop
            // 
            this.labelPop.AutoSize = true;
            this.labelPop.Location = new System.Drawing.Point(10, 120);
            this.labelPop.Name = "labelPop";
            this.labelPop.Size = new System.Drawing.Size(28, 15);
            this.labelPop.TabIndex = 5;
            this.labelPop.Text = "Pop";
            // 
            // txtPopSize
            // 
            this.txtPopSize.Location = new System.Drawing.Point(10, 138);
            this.txtPopSize.Name = "txtPopSize";
            this.txtPopSize.Size = new System.Drawing.Size(80, 23);
            this.txtPopSize.TabIndex = 6;
            this.txtPopSize.Text = "25";
            // 
            // labelMutRate
            // 
            this.labelMutRate.AutoSize = true;
            this.labelMutRate.Location = new System.Drawing.Point(10, 165);
            this.labelMutRate.Name = "labelMutRate";
            this.labelMutRate.Size = new System.Drawing.Size(47, 15);
            this.labelMutRate.TabIndex = 7;
            this.labelMutRate.Text = "mutRate";
            // 
            // txtMutRate
            // 
            this.txtMutRate.Location = new System.Drawing.Point(10, 183);
            this.txtMutRate.Name = "txtMutRate";
            this.txtMutRate.Size = new System.Drawing.Size(80, 23);
            this.txtMutRate.TabIndex = 8;
            this.txtMutRate.Text = "1";
            // 
            // labelMutStep
            // 
            this.labelMutStep.AutoSize = true;
            this.labelMutStep.Location = new System.Drawing.Point(10, 210);
            this.labelMutStep.Name = "labelMutStep";
            this.labelMutStep.Size = new System.Drawing.Size(49, 15);
            this.labelMutStep.TabIndex = 9;
            this.labelMutStep.Text = "mutStep";
            // 
            // txtMutStep
            // 
            this.txtMutStep.Location = new System.Drawing.Point(10, 228);
            this.txtMutStep.Name = "txtMutStep";
            this.txtMutStep.Size = new System.Drawing.Size(80, 23);
            this.txtMutStep.TabIndex = 10;
            this.txtMutStep.Text = "1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(640, 260);
            this.Controls.Add(this.txtMutStep);
            this.Controls.Add(this.labelMutStep);
            this.Controls.Add(this.txtMutRate);
            this.Controls.Add(this.labelMutRate);
            this.Controls.Add(this.txtPopSize);
            this.Controls.Add(this.labelPop);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.btnInit);
            this.Name = "Form1";
            this.Text = "Zmutowany Dywanik";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
