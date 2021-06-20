
namespace Tarım_Borsa_v1._1
{
    partial class Giris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.sifreal = new System.Windows.Forms.Label();
            this.oturumac = new System.Windows.Forms.Button();
            this.kullaniciadialtxtbox = new System.Windows.Forms.TextBox();
            this.parolaaltxtbox = new System.Windows.Forms.TextBox();
            this.yöneticiradiobuton = new System.Windows.Forms.RadioButton();
            this.kullaniciradiobuton = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.kayitadres = new System.Windows.Forms.TextBox();
            this.kayitmail = new System.Windows.Forms.TextBox();
            this.kayittelno = new System.Windows.Forms.TextBox();
            this.kayitkimlik = new System.Windows.Forms.TextBox();
            this.kayitparola = new System.Windows.Forms.TextBox();
            this.kayitkullaniciad = new System.Windows.Forms.TextBox();
            this.kayitsoyad = new System.Windows.Forms.TextBox();
            this.kayitad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(47, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // sifreal
            // 
            this.sifreal.AutoSize = true;
            this.sifreal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifreal.Location = new System.Drawing.Point(47, 175);
            this.sifreal.Name = "sifreal";
            this.sifreal.Size = new System.Drawing.Size(46, 18);
            this.sifreal.TabIndex = 1;
            this.sifreal.Text = "Şifre :";
            // 
            // oturumac
            // 
            this.oturumac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(188)))));
            this.oturumac.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.oturumac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.oturumac.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.oturumac.Location = new System.Drawing.Point(50, 270);
            this.oturumac.Name = "oturumac";
            this.oturumac.Size = new System.Drawing.Size(215, 45);
            this.oturumac.TabIndex = 2;
            this.oturumac.Text = "OTURUM AÇ";
            this.oturumac.UseVisualStyleBackColor = false;
            this.oturumac.Click += new System.EventHandler(this.oturumac_Click);
            // 
            // kullaniciadialtxtbox
            // 
            this.kullaniciadialtxtbox.Location = new System.Drawing.Point(158, 139);
            this.kullaniciadialtxtbox.Name = "kullaniciadialtxtbox";
            this.kullaniciadialtxtbox.Size = new System.Drawing.Size(107, 20);
            this.kullaniciadialtxtbox.TabIndex = 3;
            // 
            // parolaaltxtbox
            // 
            this.parolaaltxtbox.Location = new System.Drawing.Point(158, 173);
            this.parolaaltxtbox.Name = "parolaaltxtbox";
            this.parolaaltxtbox.Size = new System.Drawing.Size(107, 20);
            this.parolaaltxtbox.TabIndex = 4;
            // 
            // yöneticiradiobuton
            // 
            this.yöneticiradiobuton.AutoSize = true;
            this.yöneticiradiobuton.Location = new System.Drawing.Point(158, 222);
            this.yöneticiradiobuton.Name = "yöneticiradiobuton";
            this.yöneticiradiobuton.Size = new System.Drawing.Size(63, 17);
            this.yöneticiradiobuton.TabIndex = 5;
            this.yöneticiradiobuton.Text = "Yönetici";
            this.yöneticiradiobuton.UseVisualStyleBackColor = true;
            // 
            // kullaniciradiobuton
            // 
            this.kullaniciradiobuton.AutoSize = true;
            this.kullaniciradiobuton.Checked = true;
            this.kullaniciradiobuton.Location = new System.Drawing.Point(50, 222);
            this.kullaniciradiobuton.Name = "kullaniciradiobuton";
            this.kullaniciradiobuton.Size = new System.Drawing.Size(64, 17);
            this.kullaniciradiobuton.TabIndex = 6;
            this.kullaniciradiobuton.TabStop = true;
            this.kullaniciradiobuton.Text = "Kullanıcı";
            this.kullaniciradiobuton.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(329, 475);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.kullaniciradiobuton);
            this.tabPage1.Controls.Add(this.sifreal);
            this.tabPage1.Controls.Add(this.yöneticiradiobuton);
            this.tabPage1.Controls.Add(this.oturumac);
            this.tabPage1.Controls.Add(this.parolaaltxtbox);
            this.tabPage1.Controls.Add(this.kullaniciadialtxtbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(321, 449);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Giriş Sayfası";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.kayitadres);
            this.tabPage2.Controls.Add(this.kayitmail);
            this.tabPage2.Controls.Add(this.kayittelno);
            this.tabPage2.Controls.Add(this.kayitkimlik);
            this.tabPage2.Controls.Add(this.kayitparola);
            this.tabPage2.Controls.Add(this.kayitkullaniciad);
            this.tabPage2.Controls.Add(this.kayitsoyad);
            this.tabPage2.Controls.Add(this.kayitad);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(321, 449);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kayıt Sayfası";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(188)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(54, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 44);
            this.button1.TabIndex = 16;
            this.button1.Text = "HESAP OLUŞTUR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kayitadres
            // 
            this.kayitadres.Location = new System.Drawing.Point(157, 260);
            this.kayitadres.Name = "kayitadres";
            this.kayitadres.Size = new System.Drawing.Size(100, 20);
            this.kayitadres.TabIndex = 15;
            // 
            // kayitmail
            // 
            this.kayitmail.Location = new System.Drawing.Point(157, 233);
            this.kayitmail.Name = "kayitmail";
            this.kayitmail.Size = new System.Drawing.Size(100, 20);
            this.kayitmail.TabIndex = 14;
            // 
            // kayittelno
            // 
            this.kayittelno.Location = new System.Drawing.Point(157, 206);
            this.kayittelno.Name = "kayittelno";
            this.kayittelno.Size = new System.Drawing.Size(100, 20);
            this.kayittelno.TabIndex = 13;
            // 
            // kayitkimlik
            // 
            this.kayitkimlik.Location = new System.Drawing.Point(157, 179);
            this.kayitkimlik.Name = "kayitkimlik";
            this.kayitkimlik.Size = new System.Drawing.Size(100, 20);
            this.kayitkimlik.TabIndex = 12;
            // 
            // kayitparola
            // 
            this.kayitparola.Location = new System.Drawing.Point(157, 152);
            this.kayitparola.Name = "kayitparola";
            this.kayitparola.Size = new System.Drawing.Size(100, 20);
            this.kayitparola.TabIndex = 11;
            // 
            // kayitkullaniciad
            // 
            this.kayitkullaniciad.Location = new System.Drawing.Point(157, 125);
            this.kayitkullaniciad.Name = "kayitkullaniciad";
            this.kayitkullaniciad.Size = new System.Drawing.Size(100, 20);
            this.kayitkullaniciad.TabIndex = 10;
            // 
            // kayitsoyad
            // 
            this.kayitsoyad.Location = new System.Drawing.Point(157, 98);
            this.kayitsoyad.Name = "kayitsoyad";
            this.kayitsoyad.Size = new System.Drawing.Size(100, 20);
            this.kayitsoyad.TabIndex = 9;
            // 
            // kayitad
            // 
            this.kayitad.Location = new System.Drawing.Point(157, 71);
            this.kayitad.Name = "kayitad";
            this.kayitad.Size = new System.Drawing.Size(100, 20);
            this.kayitad.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "ADRES :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "MAİL :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "TELEFON :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "KİMLİK NO :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "PAROLA :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "KULLANICI ADI :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "SOYAD :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "AD :";
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 474);
            this.Controls.Add(this.tabControl1);
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sifreal;
        private System.Windows.Forms.Button oturumac;
        private System.Windows.Forms.TextBox kullaniciadialtxtbox;
        private System.Windows.Forms.TextBox parolaaltxtbox;
        private System.Windows.Forms.RadioButton yöneticiradiobuton;
        private System.Windows.Forms.RadioButton kullaniciradiobuton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox kayitadres;
        private System.Windows.Forms.TextBox kayitmail;
        private System.Windows.Forms.TextBox kayittelno;
        private System.Windows.Forms.TextBox kayitkimlik;
        private System.Windows.Forms.TextBox kayitparola;
        private System.Windows.Forms.TextBox kayitkullaniciad;
        private System.Windows.Forms.TextBox kayitsoyad;
        private System.Windows.Forms.TextBox kayitad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

