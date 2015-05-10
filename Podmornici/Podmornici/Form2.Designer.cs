namespace Podmornici
{
    partial class Form2
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
            this.btnIzlezi = new System.Windows.Forms.Button();
            this.btnDoma = new System.Windows.Forms.Button();
            this.btnNovaIgra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIzlezi
            // 
            this.btnIzlezi.BackColor = System.Drawing.Color.Transparent;
            this.btnIzlezi.FlatAppearance.BorderSize = 0;
            this.btnIzlezi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIzlezi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIzlezi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzlezi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzlezi.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnIzlezi.Location = new System.Drawing.Point(24, 389);
            this.btnIzlezi.Name = "btnIzlezi";
            this.btnIzlezi.Size = new System.Drawing.Size(163, 49);
            this.btnIzlezi.TabIndex = 1;
            this.btnIzlezi.Text = "Затвори";
            this.btnIzlezi.UseVisualStyleBackColor = false;
            this.btnIzlezi.Click += new System.EventHandler(this.btnIzlezi_Click);
            this.btnIzlezi.MouseLeave += new System.EventHandler(this.btnIzlezi_MouseLeave);
            this.btnIzlezi.MouseHover += new System.EventHandler(this.btnIzlezi_MouseHover);
            // 
            // btnDoma
            // 
            this.btnDoma.BackColor = System.Drawing.Color.Transparent;
            this.btnDoma.FlatAppearance.BorderSize = 0;
            this.btnDoma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDoma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDoma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoma.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDoma.Location = new System.Drawing.Point(283, 389);
            this.btnDoma.Name = "btnDoma";
            this.btnDoma.Size = new System.Drawing.Size(163, 49);
            this.btnDoma.TabIndex = 2;
            this.btnDoma.Text = "Дома";
            this.btnDoma.UseVisualStyleBackColor = false;
            this.btnDoma.Click += new System.EventHandler(this.btnDoma_Click);
            this.btnDoma.MouseLeave += new System.EventHandler(this.btnDoma_MouseLeave);
            this.btnDoma.MouseHover += new System.EventHandler(this.btnDoma_MouseHover);
            // 
            // btnNovaIgra
            // 
            this.btnNovaIgra.BackColor = System.Drawing.Color.Transparent;
            this.btnNovaIgra.FlatAppearance.BorderSize = 0;
            this.btnNovaIgra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNovaIgra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNovaIgra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaIgra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaIgra.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnNovaIgra.Location = new System.Drawing.Point(536, 389);
            this.btnNovaIgra.Name = "btnNovaIgra";
            this.btnNovaIgra.Size = new System.Drawing.Size(163, 49);
            this.btnNovaIgra.TabIndex = 3;
            this.btnNovaIgra.Text = "Нова игра";
            this.btnNovaIgra.UseVisualStyleBackColor = false;
            this.btnNovaIgra.Click += new System.EventHandler(this.btnNovaIgra_Click);
            this.btnNovaIgra.MouseLeave += new System.EventHandler(this.btnNovaIgra_MouseLeave);
            this.btnNovaIgra.MouseHover += new System.EventHandler(this.btnNovaIgra_MouseHover);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(754, 461);
            this.Controls.Add(this.btnNovaIgra);
            this.Controls.Add(this.btnDoma);
            this.Controls.Add(this.btnIzlezi);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIzlezi;
        private System.Windows.Forms.Button btnDoma;
        private System.Windows.Forms.Button btnNovaIgra;


        

    }
}