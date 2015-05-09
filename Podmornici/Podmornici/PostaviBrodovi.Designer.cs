namespace Podmornici
{
    partial class PostaviBrodovi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPocni = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnResetiraj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPocni
            // 
            this.btnPocni.Location = new System.Drawing.Point(570, 269);
            this.btnPocni.Name = "btnPocni";
            this.btnPocni.Size = new System.Drawing.Size(142, 35);
            this.btnPocni.TabIndex = 0;
            this.btnPocni.Text = "Започни игра";
            this.btnPocni.UseVisualStyleBackColor = true;
            this.btnPocni.Click += new System.EventHandler(this.btnPocni_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(570, 355);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(142, 35);
            this.btnRandom.TabIndex = 1;
            this.btnRandom.Text = "Намести случајно";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnResetiraj
            // 
            this.btnResetiraj.Location = new System.Drawing.Point(570, 314);
            this.btnResetiraj.Name = "btnResetiraj";
            this.btnResetiraj.Size = new System.Drawing.Size(142, 35);
            this.btnResetiraj.TabIndex = 2;
            this.btnResetiraj.Text = "Ресетирај";
            this.btnResetiraj.UseVisualStyleBackColor = true;
            this.btnResetiraj.Click += new System.EventHandler(this.btnResetiraj_Click);
            // 
            // PostaviBrodovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 402);
            this.Controls.Add(this.btnResetiraj);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnPocni);
            this.Name = "PostaviBrodovi";
            this.Text = "PostaviBrodovi";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PostaviBrodovi_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PostaviBrodovi_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PostaviBrodovi_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PostaviBrodovi_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PostaviBrodovi_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPocni;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnResetiraj;
    }
}