
namespace Tarım_Borsa_v1._1
{
    partial class admin_ekrani
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
            this.admindgw = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.adminilandgw = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.urunreddetbtn = new System.Windows.Forms.Button();
            this.urunonaylabtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.uyeenvgoster = new System.Windows.Forms.DataGridView();
            this.bekleyenurunonaydgw = new System.Windows.Forms.Label();
            this.onaysizurundgw = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.parareddbtn = new System.Windows.Forms.Button();
            this.paraonaybtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.uyeenvgoster2 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.onaysizparadgw = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.admindgw)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminilandgw)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uyeenvgoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onaysizurundgw)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uyeenvgoster2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onaysizparadgw)).BeginInit();
            this.SuspendLayout();
            // 
            // admindgw
            // 
            this.admindgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.admindgw.Location = new System.Drawing.Point(6, 38);
            this.admindgw.Name = "admindgw";
            this.admindgw.Size = new System.Drawing.Size(955, 333);
            this.admindgw.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Crimson;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(1031, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 49);
            this.button3.TabIndex = 30;
            this.button3.Text = "ÇIKIŞ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Kullanıcılar :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 530);
            this.tabControl1.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.admindgw);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1152, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kullanıcı Listesi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.adminilandgw);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1152, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "İlan Kontrol Sayfası";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(1033, 683);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 49);
            this.button1.TabIndex = 30;
            this.button1.Text = "ÇIKIŞ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(1, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "İLANLAR:";
            // 
            // adminilandgw
            // 
            this.adminilandgw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.adminilandgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adminilandgw.Location = new System.Drawing.Point(6, 46);
            this.adminilandgw.Name = "adminilandgw";
            this.adminilandgw.Size = new System.Drawing.Size(848, 332);
            this.adminilandgw.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.urunreddetbtn);
            this.tabPage3.Controls.Add(this.urunonaylabtn);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.uyeenvgoster);
            this.tabPage3.Controls.Add(this.bekleyenurunonaydgw);
            this.tabPage3.Controls.Add(this.onaysizurundgw);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1152, 504);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ürün Onayı";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // urunreddetbtn
            // 
            this.urunreddetbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.urunreddetbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunreddetbtn.ForeColor = System.Drawing.Color.White;
            this.urunreddetbtn.Location = new System.Drawing.Point(879, 155);
            this.urunreddetbtn.Name = "urunreddetbtn";
            this.urunreddetbtn.Size = new System.Drawing.Size(238, 59);
            this.urunreddetbtn.TabIndex = 8;
            this.urunreddetbtn.Text = "ÜRÜN TALEBİNİ REDDET";
            this.urunreddetbtn.UseVisualStyleBackColor = false;
            this.urunreddetbtn.Click += new System.EventHandler(this.urunreddetbtn_Click);
            // 
            // urunonaylabtn
            // 
            this.urunonaylabtn.BackColor = System.Drawing.Color.Lime;
            this.urunonaylabtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunonaylabtn.ForeColor = System.Drawing.Color.White;
            this.urunonaylabtn.Location = new System.Drawing.Point(879, 54);
            this.urunonaylabtn.Name = "urunonaylabtn";
            this.urunonaylabtn.Size = new System.Drawing.Size(238, 59);
            this.urunonaylabtn.TabIndex = 7;
            this.urunonaylabtn.Text = "ÜRÜN TALEBİNİ ONAYLA";
            this.urunonaylabtn.UseVisualStyleBackColor = false;
            this.urunonaylabtn.Click += new System.EventHandler(this.urunonaylabtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "ÜYELERİN ENVANTER BİLGİSİ";
            // 
            // uyeenvgoster
            // 
            this.uyeenvgoster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uyeenvgoster.Location = new System.Drawing.Point(6, 276);
            this.uyeenvgoster.Name = "uyeenvgoster";
            this.uyeenvgoster.Size = new System.Drawing.Size(848, 193);
            this.uyeenvgoster.TabIndex = 5;
            // 
            // bekleyenurunonaydgw
            // 
            this.bekleyenurunonaydgw.AutoSize = true;
            this.bekleyenurunonaydgw.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bekleyenurunonaydgw.Location = new System.Drawing.Point(6, 13);
            this.bekleyenurunonaydgw.Name = "bekleyenurunonaydgw";
            this.bekleyenurunonaydgw.Size = new System.Drawing.Size(183, 25);
            this.bekleyenurunonaydgw.TabIndex = 4;
            this.bekleyenurunonaydgw.Text = "ÜRÜN ONAYLARI :";
            // 
            // onaysizurundgw
            // 
            this.onaysizurundgw.BackgroundColor = System.Drawing.Color.DarkGray;
            this.onaysizurundgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.onaysizurundgw.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.onaysizurundgw.Location = new System.Drawing.Point(6, 41);
            this.onaysizurundgw.Name = "onaysizurundgw";
            this.onaysizurundgw.Size = new System.Drawing.Size(848, 193);
            this.onaysizurundgw.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.parareddbtn);
            this.tabPage4.Controls.Add(this.uyeenvgoster2);
            this.tabPage4.Controls.Add(this.paraonaybtn);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.onaysizparadgw);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1152, 504);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Para Onayı";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // parareddbtn
            // 
            this.parareddbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.parareddbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.parareddbtn.ForeColor = System.Drawing.Color.White;
            this.parareddbtn.Location = new System.Drawing.Point(876, 153);
            this.parareddbtn.Name = "parareddbtn";
            this.parareddbtn.Size = new System.Drawing.Size(238, 59);
            this.parareddbtn.TabIndex = 14;
            this.parareddbtn.Text = "BAKİYE TALEBİNİ REDDET";
            this.parareddbtn.UseVisualStyleBackColor = false;
            this.parareddbtn.Click += new System.EventHandler(this.parareddbtn_Click);
            // 
            // paraonaybtn
            // 
            this.paraonaybtn.BackColor = System.Drawing.Color.Lime;
            this.paraonaybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.paraonaybtn.ForeColor = System.Drawing.Color.White;
            this.paraonaybtn.Location = new System.Drawing.Point(876, 56);
            this.paraonaybtn.Name = "paraonaybtn";
            this.paraonaybtn.Size = new System.Drawing.Size(238, 59);
            this.paraonaybtn.TabIndex = 13;
            this.paraonaybtn.Text = "BAKİYE TALEBİNİ ONAYLA";
            this.paraonaybtn.UseVisualStyleBackColor = false;
            this.paraonaybtn.Click += new System.EventHandler(this.paraonaybtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(6, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "ÜYELERİN ENVANTER BİLGİSİ";
            // 
            // uyeenvgoster2
            // 
            this.uyeenvgoster2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uyeenvgoster2.Location = new System.Drawing.Point(6, 276);
            this.uyeenvgoster2.Name = "uyeenvgoster2";
            this.uyeenvgoster2.Size = new System.Drawing.Size(848, 193);
            this.uyeenvgoster2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(6, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "BAKİYE YÜKLEME ONAYLARI :";
            // 
            // onaysizparadgw
            // 
            this.onaysizparadgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.onaysizparadgw.Location = new System.Drawing.Point(6, 41);
            this.onaysizparadgw.Name = "onaysizparadgw";
            this.onaysizparadgw.Size = new System.Drawing.Size(848, 193);
            this.onaysizparadgw.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(1032, 420);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 49);
            this.button2.TabIndex = 31;
            this.button2.Text = "ÇIKIŞ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Crimson;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(1034, 420);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 49);
            this.button4.TabIndex = 31;
            this.button4.Text = "ÇIKIŞ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Crimson;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(1031, 420);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 49);
            this.button5.TabIndex = 31;
            this.button5.Text = "ÇIKIŞ";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // admin_ekrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 535);
            this.Controls.Add(this.tabControl1);
            this.Name = "admin_ekrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admin_ekrani";
            this.Load += new System.EventHandler(this.admin_ekrani_Load);
            ((System.ComponentModel.ISupportInitialize)(this.admindgw)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminilandgw)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uyeenvgoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onaysizurundgw)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uyeenvgoster2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onaysizparadgw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView admindgw;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView adminilandgw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button urunreddetbtn;
        private System.Windows.Forms.Button urunonaylabtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView uyeenvgoster;
        private System.Windows.Forms.Label bekleyenurunonaydgw;
        private System.Windows.Forms.DataGridView onaysizurundgw;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button parareddbtn;
        private System.Windows.Forms.Button paraonaybtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView uyeenvgoster2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView onaysizparadgw;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}