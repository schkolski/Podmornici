namespace Podmornici
{
    partial class NewGame
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
            this.btnNovaIgra = new System.Windows.Forms.Button();
            this.btnInstrukcii = new System.Windows.Forms.Button();
            this.btnLesno = new System.Windows.Forms.Button();
            this.btnSredno = new System.Windows.Forms.Button();
            this.btnTesko = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNovaIgra
            // 
            this.btnNovaIgra.Location = new System.Drawing.Point(12, 12);
            this.btnNovaIgra.Name = "btnNovaIgra";
            this.btnNovaIgra.Size = new System.Drawing.Size(166, 47);
            this.btnNovaIgra.TabIndex = 0;
            this.btnNovaIgra.Text = "Нова игра";
            this.btnNovaIgra.UseVisualStyleBackColor = true;
            // 
            // btnInstrukcii
            // 
            this.btnInstrukcii.Location = new System.Drawing.Point(12, 111);
            this.btnInstrukcii.Name = "btnInstrukcii";
            this.btnInstrukcii.Size = new System.Drawing.Size(166, 48);
            this.btnInstrukcii.TabIndex = 1;
            this.btnInstrukcii.Text = "Инструкции";
            this.btnInstrukcii.UseVisualStyleBackColor = true;
            // 
            // btnLesno
            // 
            this.btnLesno.Location = new System.Drawing.Point(12, 82);
            this.btnLesno.Name = "btnLesno";
            this.btnLesno.Size = new System.Drawing.Size(75, 23);
            this.btnLesno.TabIndex = 2;
            this.btnLesno.Text = "Лесно";
            this.btnLesno.UseVisualStyleBackColor = true;
            // 
            // btnSredno
            // 
            this.btnSredno.Location = new System.Drawing.Point(103, 82);
            this.btnSredno.Name = "btnSredno";
            this.btnSredno.Size = new System.Drawing.Size(75, 23);
            this.btnSredno.TabIndex = 3;
            this.btnSredno.Text = "Средно";
            this.btnSredno.UseVisualStyleBackColor = true;
            // 
            // btnTesko
            // 
            this.btnTesko.Location = new System.Drawing.Point(184, 82);
            this.btnTesko.Name = "btnTesko";
            this.btnTesko.Size = new System.Drawing.Size(75, 23);
            this.btnTesko.TabIndex = 4;
            this.btnTesko.Text = "Тешко";
            this.btnTesko.UseVisualStyleBackColor = true;
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 167);
            this.Controls.Add(this.btnTesko);
            this.Controls.Add(this.btnSredno);
            this.Controls.Add(this.btnLesno);
            this.Controls.Add(this.btnInstrukcii);
            this.Controls.Add(this.btnNovaIgra);
            this.Name = "NewGame";
            this.Text = "NewGame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNovaIgra;
        private System.Windows.Forms.Button btnInstrukcii;
        private System.Windows.Forms.Button btnLesno;
        private System.Windows.Forms.Button btnSredno;
        private System.Windows.Forms.Button btnTesko;
    }
}