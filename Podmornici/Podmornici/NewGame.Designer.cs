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
            this.components = new System.ComponentModel.Container();
            this.btnInstrukcii = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.rbLesno = new System.Windows.Forms.RadioButton();
            this.tbTeshko = new System.Windows.Forms.RadioButton();
            this.btnNovaIgra = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInstrukcii
            // 
            this.btnInstrukcii.BackColor = System.Drawing.Color.Transparent;
            this.btnInstrukcii.FlatAppearance.BorderSize = 0;
            this.btnInstrukcii.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnInstrukcii.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstrukcii.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnInstrukcii.ForeColor = System.Drawing.Color.White;
            this.btnInstrukcii.Location = new System.Drawing.Point(483, 355);
            this.btnInstrukcii.Name = "btnInstrukcii";
            this.btnInstrukcii.Size = new System.Drawing.Size(114, 36);
            this.btnInstrukcii.TabIndex = 1;
            this.btnInstrukcii.Text = "Инструкции";
            this.btnInstrukcii.UseVisualStyleBackColor = false;
            this.btnInstrukcii.Click += new System.EventHandler(this.btnInstrukcii_Click);
            this.btnInstrukcii.MouseLeave += new System.EventHandler(this.btnInstrukcii_MouseLeave);
            this.btnInstrukcii.MouseHover += new System.EventHandler(this.btnInstrukcii_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Име:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ниво:";
            // 
            // tbIme
            // 
            this.tbIme.Location = new System.Drawing.Point(66, 13);
            this.tbIme.Name = "tbIme";
            this.tbIme.Size = new System.Drawing.Size(107, 20);
            this.tbIme.TabIndex = 4;
            this.tbIme.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tbIme.Validating += new System.ComponentModel.CancelEventHandler(this.tbIme_Validating);
            // 
            // rbLesno
            // 
            this.rbLesno.AutoSize = true;
            this.rbLesno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLesno.ForeColor = System.Drawing.SystemColors.Window;
            this.rbLesno.Location = new System.Drawing.Point(66, 67);
            this.rbLesno.Name = "rbLesno";
            this.rbLesno.Size = new System.Drawing.Size(72, 21);
            this.rbLesno.TabIndex = 5;
            this.rbLesno.Text = "Лесно";
            this.rbLesno.UseVisualStyleBackColor = true;
            // 
            // tbTeshko
            // 
            this.tbTeshko.AutoSize = true;
            this.tbTeshko.Checked = true;
            this.tbTeshko.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTeshko.ForeColor = System.Drawing.SystemColors.Window;
            this.tbTeshko.Location = new System.Drawing.Point(66, 40);
            this.tbTeshko.Name = "tbTeshko";
            this.tbTeshko.Size = new System.Drawing.Size(74, 21);
            this.tbTeshko.TabIndex = 6;
            this.tbTeshko.TabStop = true;
            this.tbTeshko.Text = "Тешко";
            this.tbTeshko.UseVisualStyleBackColor = true;
            // 
            // btnNovaIgra
            // 
            this.btnNovaIgra.BackColor = System.Drawing.Color.Transparent;
            this.btnNovaIgra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNovaIgra.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNovaIgra.FlatAppearance.BorderSize = 0;
            this.btnNovaIgra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNovaIgra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaIgra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNovaIgra.ForeColor = System.Drawing.Color.White;
            this.btnNovaIgra.Location = new System.Drawing.Point(603, 355);
            this.btnNovaIgra.Name = "btnNovaIgra";
            this.btnNovaIgra.Size = new System.Drawing.Size(114, 35);
            this.btnNovaIgra.TabIndex = 0;
            this.btnNovaIgra.Text = "Нова игра";
            this.btnNovaIgra.UseVisualStyleBackColor = false;
            this.btnNovaIgra.Click += new System.EventHandler(this.btnNovaIgra_Click);
            this.btnNovaIgra.MouseLeave += new System.EventHandler(this.btnNovaIgra_MouseLeave);
            this.btnNovaIgra.MouseHover += new System.EventHandler(this.btnNovaIgra_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbLesno);
            this.panel1.Controls.Add(this.tbTeshko);
            this.panel1.Controls.Add(this.tbIme);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(483, 236);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 113);
            this.panel1.TabIndex = 8;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 402);
            this.Controls.Add(this.btnInstrukcii);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNovaIgra);
            this.Name = "NewGame";
            this.Text = "NewGame";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewGame_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNovaIgra;
        private System.Windows.Forms.Button btnInstrukcii;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIme;
        private System.Windows.Forms.RadioButton rbLesno;
        private System.Windows.Forms.RadioButton tbTeshko;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}