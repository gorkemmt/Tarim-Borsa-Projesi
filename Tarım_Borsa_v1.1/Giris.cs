using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;        //Veritabanı kullanabilmek için OLEDB kütüphanesini ekliyoruz
using System.IO;        //giriş çıkış işlemleri için İO kütüphanesini ekledik

namespace Tarım_Borsa_v1._1
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=personel.accdb");        //Veritabanı dosya yolunu oluşturdurk

        public static string kullaniciadi, parola, yetki;        //formlar arası veri aktarımında kullanılan değişkenler oluştu
        

        private void Form1_Load(object sender, EventArgs e)        //FORM 1 in LOAD kısmı içinde bazı görüntü ve sınırlama kodlarını yazdık
        {
            this.Text = "Giriş Ekranı";  // menü başlığı
            this.AcceptButton = oturumac;
            kayitkimlik.MaxLength = 11;  //textbox karakter sınırlaması 
            kayittelno.MaxLength = 11;

        }

        private void kayit_sayfa_temizle()        //Gerektiğinde kullanmak için kayıt olma sayfasını temizleyen fonksiyon oluşturuldu
        {
            kayitad.Clear();
            kayitsoyad.Clear();
            kayitkullaniciad.Clear();
            kayitparola.Clear();
            kayitkimlik.Clear();
            kayittelno.Clear();
            kayitmail.Clear();
            kayitadres.Clear();

        }

        private void yenienvanterolustur()         //Yeni oluşturulan kullanıcılara otomatik olarak boş bir envanter oluşturulmasını sağlayan fonksiyonu oluşturduk
        {

            baglantim.Open();        //Veritabanı bağlantısını açtık

            OleDbCommand ekleenvanter = new OleDbCommand("insert into envanterler values ('" + kayitkullaniciad.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')", baglantim);        //İNSERT komutu kullanara envanterler tablosuna kayıt eklemesi yaptık

            ekleenvanter.ExecuteNonQuery(); //eklenenvanter isimli sorgunun sonuclarını access veritabanına  işlenmesini sağladık.

            baglantim.Close();        //Veritabanı bağlantısını kapattık

            MessageBox.Show("yeni kullanıcı boş envanteri oluşturuldu");        //işlemi uyarı ile bildirdik 

        }




        private void oturumac_Click(object sender, EventArgs e)         //OTURUM AÇ BUTONU TIKLADNDIĞINDA YAPILACAK İŞLEMLER
        {
            bool durum = false;

            baglantim.Open();        //bağlantıyı oluşturduk
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar", baglantim);          //veritabanında bulundan kullanicilar tablosunun bilgilerini çektik
            OleDbDataReader kayitoku = selectsorgu.ExecuteReader();          // gelen bilgiler geçici olarak bellekte datareader da saklanacak

            while (kayitoku.Read())
            {
                if (yöneticiradiobuton.Checked == true)         //hangi türde kullanıcı girişi yapılacağını if yapısı ve radiobuton sayesinde ayırdık
                {
                    if (kayitoku["kullaniciadi"].ToString() == kullaniciadialtxtbox.Text && kayitoku["parola"].ToString() == parolaaltxtbox.Text && kayitoku["yetki"].ToString() == "yonetici")         //veritabanından çekilen bilgiler ile giriş ekranındaki bilgilerin doğruluğu kontrol edildi
                    {
                        durum = true;

                        kullaniciadi = kayitoku.GetValue(0).ToString();
                        parola = kayitoku.GetValue(1).ToString();
                        yetki = kayitoku.GetValue(2).ToString();

                        this.Hide();
                        admin_ekrani adminform = new admin_ekrani();   //bilgiler doğruluğunda giriş sayfası gizlendi ve admin ekranı açılması sağlandı
                        adminform.Show();
                        break;
                    }
                }

                if (kullaniciradiobuton.Checked == true)
                {
                    if (kayitoku["kullaniciadi"].ToString() == kullaniciadialtxtbox.Text && kayitoku["parola"].ToString() == parolaaltxtbox.Text && kayitoku["yetki"].ToString() == "kullanıcı")
                    {
                        durum = true;

                        kullaniciadi = kayitoku.GetValue(0).ToString();
                        parola = kayitoku.GetValue(1).ToString();
                        yetki = kayitoku.GetValue(2).ToString();

                        this.Hide();
                        kullanici_ekrani userform = new kullanici_ekrani();         //bilgiler doğruluğunda giriş sayfası gizlendi ve kullanıcı ekranı açılması sağlandı
                        userform.Show();
                        break;
                    }
                }

            }
            if (durum == false)         //bilgilerin yanlış girilmesi durumunda kullanıcıya bir uyarı verildi 
            {
                MessageBox.Show("hatalı giriş oturum açılamadı");
            }

            baglantim.Close();

        }

        private void button1_Click(object sender, EventArgs e)          //HESAP OLUŞTUR BUTONU TIKLANDIĞINDA YAPILACAK İŞLEMLER
        {
            bool kayitkontrol = false;

            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where kullaniciadi='" + kayitkullaniciad.Text + "'", baglantim);  //veritabanından kullanıcı adı ile uyuşan bilgileri getirdik ve admin kullanıcısının göreceği KULLANICILAR sayfasına yazdırdık
            OleDbDataReader kayitoku = selectsorgu.ExecuteReader();  // gelen bilgiler geçici olarak bellekte datareader da saklanacak->select sorgusunun sonucları burada tutuldu

            while (kayitoku.Read())
            {
                kayitkontrol = true;  //zaten sisteme üye bir kullanıcıya rastlarsa kayıtkontrol değişkeni true cevirdik
                break;
            }

            baglantim.Close();

            if (kayitkontrol == false)   //yeni kullanıcı ise aşağıdaki işlemler gerçekleşecek
            {

                if (kayitad.Text != "" && kayitsoyad.Text != "" && kayitkullaniciad.Text != "" && kayitparola.Text != "" && kayitkimlik.Text != "" && kayittelno.Text != "" && kayitmail.Text != "" && kayitadres.Text != "")  //kayıt bilgilerinin eksik girilmemesi için kontrol ettirdik
                {
                    yetki = "kullanıcı";

                    
                        baglantim.Open();
                        OleDbCommand ekledata = new OleDbCommand("insert into kullanicilar values ('" + kayitkullaniciad.Text + "','" + kayitparola.Text + "','" + yetki + "','" + kayitad.Text + "','" + kayitsoyad.Text + "','" + kayitkimlik.Text + "','" + kayittelno.Text + "','" + kayitmail.Text + "','" + kayitadres.Text + "')", baglantim);  //insert ile kullanıcılar tablosuna yeni kullanıcımızı eklettik.
                        ekledata.ExecuteNonQuery(); //ekle komutu isimli sorgunun sonuclarını access e  işlettik
                        baglantim.Close();

                        MessageBox.Show("kullanıcı kaydı oluşturuldu");

                        yenienvanterolustur();      //yeni kullanıcı için envarnter oluşturma ve kayıt sayfasını temizleyen fonksiyonları çağırdık
                        kayit_sayfa_temizle();
                    
                }
                else
                {
                    MessageBox.Show("eksik bilgi girişiyaptınız formu kontrol ediniz");   //eksik bilgi girişinde kullanıcıya uyarı gösterdik
                }

            }
            else
            {
                MessageBox.Show("bu kullanıcı adı zaten kayıtlı kullanıcı oluşturulamadı");   //zaten kayıtlı bir kullanıcının bilgisi kullanılmışşsa uyarı verdik
            }
        }


    }
}
