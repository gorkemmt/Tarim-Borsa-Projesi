using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;   //veritabanı için kütüphane ekliyoruz
using System.IO;

namespace Tarım_Borsa_v1._1
{
    public partial class kullanici_ekrani : Form
    {
        public kullanici_ekrani()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=personel.accdb");

        private static int ilanno = 0, paratalepno = 0, uruntalepno = 0;

        private void kullanici_ekrani_Load(object sender, EventArgs e)      //KULLANICI LOAD EKRANINDA YAPILACAK ATAMA VE İŞLEMLER
        {
            this.Text = "Kullanıcı İşlemleri";
            oturumbilgilabel.Text = Form1.kullaniciadi;
            urunseccmb1.Items.Add("pamuk");
            urunseccmb1.Items.Add("arpa");
            urunseccmb1.Items.Add("buğday");
            urunseccmb1.Items.Add("petrol");        //ürün seçerken kullanılacak itemlar cmbbox lara eklendi
            urunseccmb1.Items.Add("yulaf");
            urunsecalcmb.Items.Add("pamuk");
            urunsecalcmb.Items.Add("arpa");
            urunsecalcmb.Items.Add("buğday");
            urunsecalcmb.Items.Add("petrol");
            urunsecalcmb.Items.Add("yulaf");

            envanter_getir();       //kullanıcının envanter bilgisi çekildi ve gösterildi
            ilanlari_goster();      //satışta olan ilanlar gösterildi

        }

        private void ilanlari_goster()      //SATIŞA ÇIKARILMIŞ ÜRÜN İLANLARI GÖSTEREN FONKSİYON
        {
           
                baglantim.Open();

                OleDbDataAdapter ilan_listele = new OleDbDataAdapter("select kullaniciadi AS [KULLANICI ADI],urun AS [ÜRÜN TÜRÜ],miktar AS [MİKTAR BİLGİSİ],fiyat as [BİRİM FİYATI ],ilanno AS [İLAN NUMARASI],ilantoplamfiyat AS [İLAN FİYATI] from ilanlar  Order By kullaniciadi ASC", baglantim);   //ilanlar veritabanından çekildi datagridview e yüklendi

                DataSet dsbellek = new DataSet();  

                ilan_listele.Fill(dsbellek);  

                ilandgw.DataSource = dsbellek.Tables[0]; 

                baglantim.Close();

        }

        private void envanter_getir()       //KULLANICININ ENVANTER BİLGİSİNİ GETİREN FONKSİYON
        {
            bool envanter_arama_durum = false;

            baglantim.Open();

            OleDbCommand envantersorgu = new OleDbCommand("select * from envanterler where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);       //oturum açılmış kullanıcının envanter bilgisi çekildi

            OleDbDataReader kayitoku = envantersorgu.ExecuteReader();

            while (kayitoku.Read())
            {
                envanter_arama_durum = true;
                hesapparayaz.Text = kayitoku.GetValue(1).ToString();
                pamukyaz.Text = kayitoku.GetValue(2).ToString();
                arpayaz.Text = kayitoku.GetValue(3).ToString();
                bugdayyaz.Text = kayitoku.GetValue(4).ToString();
                petrolyaz.Text = kayitoku.GetValue(5).ToString();
                yulafyaz.Text = kayitoku.GetValue(6).ToString();
                hesapparayaz2.Text = kayitoku.GetValue(1).ToString();       //envanter bilgisi yazdırıldı
                pamukyaz2.Text = kayitoku.GetValue(2).ToString();
                arpayaz2.Text = kayitoku.GetValue(3).ToString();
                bugdayyaz2.Text = kayitoku.GetValue(4).ToString();
                petrolyaz2.Text = kayitoku.GetValue(5).ToString();
                yulafyaz2.Text = kayitoku.GetValue(6).ToString();

                break;

            }
            if (envanter_arama_durum == false)
            {
                MessageBox.Show("kullanıcıya ait envanter bilgisi bulunamadı!");
            }

            baglantim.Close();

        }

        private void ilan_ekle()        //İLAN OLUŞTURMA FONSKSİYONU
        {
            int toplamfiyat = 0;
            if (satismiktar.Text == "" || satisfiyat.Text == "" || urunseccmb1.SelectedIndex == -1) //ürün satarken bilgilerin eksik girilmemesi için if ile kontrol ettirdim
            {
                MessageBox.Show("eksik seçim yaptınız değer giriniz (ilan verilemedi!)");
            }
            else
            {
                toplamfiyat = Int32.Parse(satismiktar.Text) * Int32.Parse(satisfiyat.Text);     //ilanın tamamının fiyatı oluştu

                baglantim.Open();

                OleDbCommand satiskomutu = new OleDbCommand("insert into ilanlar values('" + oturumbilgilabel.Text + "','" + urunseccmb1.Text + "','" + satismiktar.Text + "','" + satisfiyat.Text + "','" + ilanno + "','" + toplamfiyat + "')", baglantim);       //girilen verilerde ilanlar tablosunda yeni kayıt oluşturuluyor
                satiskomutu.ExecuteNonQuery();

                ilanno++;       // ilan numarası artılıyor ilanların farklı numaralara sahip olması için

                baglantim.Close();

                MessageBox.Show("ürünler ilana eklendi");
            }
        }

        private void alinan_urun_ekle(string urunturu,int alinanmiktar,int odenenfiyat)     // ÜRÜN SATIN ALINDIĞINDA ALAN KİŞİNİN BİLGİLERİNİ GÜNCELLEYEN FONKSİYON
        {

            odenenfiyat =(Int32.Parse(hesapparayaz.Text)-odenenfiyat);      //ürün satın alan kişinin elinde kalacak olan para hesaplandı

            if (urunturu == "pamuk")            //satın alınan ürüne göre envanter artırılıyor ve parası eksiliyor;
            {
                alinanmiktar +=Int32.Parse(pamukyaz.Text);
                OleDbCommand ilanalımenvguncelle = new OleDbCommand("update envanterler set pamuk='" + alinanmiktar + "',para='" + odenenfiyat + "' where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                ilanalımenvguncelle.ExecuteNonQuery();
            }
            else if (urunturu == "arpa")
            {
                alinanmiktar += Int32.Parse(arpayaz.Text);
                OleDbCommand ilanalımenvguncelle = new OleDbCommand("update envanterler set arpa='" + alinanmiktar + "',para='" + odenenfiyat + "' where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                ilanalımenvguncelle.ExecuteNonQuery();
            }
            else if (urunturu == "bugday")
            {
                alinanmiktar += Int32.Parse(bugdayyaz.Text);
                OleDbCommand ilanalımenvguncelle = new OleDbCommand("update envanterler set bugday='" + alinanmiktar + "',para='" + odenenfiyat + "' where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                ilanalımenvguncelle.ExecuteNonQuery();
            }
            else if (urunturu == "petrol")
            {
                alinanmiktar += Int32.Parse(petrolyaz.Text);
                OleDbCommand ilanalımenvguncelle = new OleDbCommand("update envanterler set petrol='" + alinanmiktar + "',para='" + odenenfiyat + "' where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                ilanalımenvguncelle.ExecuteNonQuery();
            }
            else if (urunturu == "yulaf")
            {
                alinanmiktar += Int32.Parse(yulafyaz.Text);
                OleDbCommand ilanalımenvguncelle = new OleDbCommand("update envanterler set yulaf='" + alinanmiktar + "',para='" + odenenfiyat + "' where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                ilanalımenvguncelle.ExecuteNonQuery();
            }
          
        }

        private void satilan_urun_para_ekle(string kisi,int eklenenpara)        //SATİLAN İLANIN PARASINI SATICIYA EKLEYEN FONKSİYON
        {
            int olanpara = 0;

            OleDbCommand sorgu = new OleDbCommand("select * from envanterler where kullaniciadi='"+kisi+"'", baglantim);        //satıcı kişinin envanter bilgisine erişiliyor
            OleDbDataReader kayitoku = sorgu.ExecuteReader();

            while (kayitoku.Read())
            {

            olanpara =Int32.Parse( kayitoku.GetValue(1).ToString());


            break;
            }
                      
            olanpara += eklenenpara;

            OleDbCommand ilanenvanterazalt = new OleDbCommand("update envanterler set para='" + olanpara + "' where kullaniciadi='" + kisi + "'", baglantim);
            ilanenvanterazalt.ExecuteNonQuery();            //satıcının para bilgisine ilanın fiyatı ekleniyor

        }

        private void envanterazalt()        //ÜRÜN SATAN KİŞİNİN ENVANTERİNDENÜRÜNLERİ AZALTMAYA YARAYAN FONKSİYON
        {
            int deger = 0;

            baglantim.Open();

            if (urunseccmb1.Text == "pamuk" && Int32.Parse(pamukyaz.Text) >= Int32.Parse(satismiktar.Text))     //satılan ürünün türüne göre satıcının envanterinden ürünün miktar bilgisi azaltılıyor
            {
                deger = Int32.Parse(pamukyaz.Text) - Int32.Parse(satismiktar.Text);
                OleDbCommand guncellekomut = new OleDbCommand("update envanterler set pamuk='" + deger + "'where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                guncellekomut.ExecuteNonQuery();
                baglantim.Close();
                ilan_ekle();

            }
            else if (urunseccmb1.Text == "arpa" && Int32.Parse(arpayaz.Text) >= Int32.Parse(satismiktar.Text))
            {
                deger = Int32.Parse(arpayaz.Text) - Int32.Parse(satismiktar.Text);
                OleDbCommand guncellekomut = new OleDbCommand("update envanterler set arpa='" + deger + "'where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                guncellekomut.ExecuteNonQuery();
                baglantim.Close();
                ilan_ekle();
            }
            else if (urunseccmb1.Text == "buğday" && Int32.Parse(bugdayyaz.Text) >= Int32.Parse(satismiktar.Text))
            {
                deger = Int32.Parse(bugdayyaz.Text) - Int32.Parse(satismiktar.Text);
                OleDbCommand guncellekomut = new OleDbCommand("update envanterler set bugday='" + deger + "'where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                guncellekomut.ExecuteNonQuery();
                baglantim.Close();
                ilan_ekle();
            }
            else if (urunseccmb1.Text == "petrol" && Int32.Parse(petrolyaz.Text) >= Int32.Parse(satismiktar.Text))
            {
                deger = Int32.Parse(petrolyaz.Text) - Int32.Parse(satismiktar.Text);
                OleDbCommand guncellekomut = new OleDbCommand("update envanterler set petrol='" + deger + "'where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                guncellekomut.ExecuteNonQuery();
                baglantim.Close();
                ilan_ekle();
            }
            else if (urunseccmb1.Text == "yulaf" && Int32.Parse(yulafyaz.Text) >= Int32.Parse(satismiktar.Text))
            {
                deger = Int32.Parse(yulafyaz.Text) - Int32.Parse(satismiktar.Text);
                OleDbCommand guncellekomut = new OleDbCommand(" update envanterler set yulaf='" + deger + "'where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                guncellekomut.ExecuteNonQuery();
                baglantim.Close();
                ilan_ekle();
            }
            else
            {
                MessageBox.Show("Hata! envanter azalmadı envanterinizdeki üründen fazla satış yapamazsınız");
                baglantim.Close();
            }

            envanter_getir();       //ürün ilanı verme sonrası envanter ve ilanlar bilgisi yenileniyor
            ilanlari_goster();

        }

        private void para_ekle()        //BAKİYE YÜKLEME TALEBİ OLUŞTURULURKEN KULLANILACAK FONKSİYON
        {

            if (paragirtbox.Text == "")
            {
                MessageBox.Show("bakiye miktarı girmediniz istek oluşturulamadı");
            }
            else
            {

                baglantim.Open();

                OleDbCommand paratalepkomutu = new OleDbCommand("insert into paratalep values('" + oturumbilgilabel.Text + "','" + paragirtbox.Text + "','onaysiz','" + paratalepno + "')", baglantim);
                paratalepkomutu.ExecuteNonQuery();      //alınan bilgilerde yeni bir para talebi oluşturulup veritabanına ekleniyor

                paratalepno++;          //taleplerin karışmaması için kullanılan talepno artırılıyor

                baglantim.Close();

                MessageBox.Show("bakiye yükleme talebi oluşturuldu");

            }

        }

        private void urun_ekle()        //ÜRÜN YÜKLEME TALEBİ OLUŞTURULURKEN KULLANILACAK FONKSİYON
        {

            if (pamukgirtbox.Text == "" && arpagirtbox.Text == "" && bugdaygirtbox.Text == "" && petrolgirtbox.Text == "" && yulafgirtbox.Text == "")       //en az bir ürün bilgisi girilmesi kontrol ediliyor
            {
                MessageBox.Show("en az bir ürün bilgisi girmelisiniz");
            }
            else
            {

                baglantim.Open();

                OleDbCommand uruntalepkkomutu = new OleDbCommand("insert into uruntalep values('" + oturumbilgilabel.Text + "','" + pamukgirtbox.Text + "','" + arpagirtbox.Text + "','" + bugdaygirtbox.Text + "','" + petrolgirtbox.Text + "','" + yulafgirtbox.Text + "','onaysiz','" + uruntalepno + "')", baglantim);      //girilen bilgilerde ürün talebi oluşturulup veritabanına ekleniyor
                uruntalepkkomutu.ExecuteNonQuery();

                uruntalepno++;      //taleplerin karışmaması için kullanılan talepno artırılıyor

                baglantim.Close();

                MessageBox.Show("ürün ekleme talebi oluşturuldu");

            }

        }

        private void urun_satin_al(int alinacakmiktar)      //ÜRÜN SATIN ALIMINDA KULLANILACAK FONKSİYON
        {
            string alinacakurun = urunsecalcmb.Text;
            bool ucuz_Arama_durumu = false;
            int  odenecekfiyat = 0, ilanmiktar = 0, kalan = 0,ilandakimiktar=0; ;

            baglantim.Open();

            OleDbCommand ilanucuzbul = new OleDbCommand("select * from ilanlar where urun='" + alinacakurun + "'Order By fiyat ASC ", baglantim);       //istenilen ürün türündeki ilanlar fiyata göe azdan çok a doğru sıralanıryor

            OleDbDataReader kayitoku = ilanucuzbul.ExecuteReader();



            while (kayitoku.Read())
            {
                ucuz_Arama_durumu = true;

                int sililanno = Int32.Parse(kayitoku.GetValue(4).ToString());   //ilanın tüm ürünleri alınırsa silinebilmesi için ilan numarası alınıyor


               
                if (Int32.Parse(kayitoku.GetValue(2).ToString()) > alinacakmiktar)          //alınacak ürünün miktarının ilandaki miktara göre daha az, eşit ,daha fazla miktarda olması if ile kontrol ediliyor
                    {

                    odenecekfiyat = Int32.Parse(kayitoku.GetValue(3).ToString()) * alinacakmiktar;

                    if (odenecekfiyat <= Int32.Parse(hesapparayaz.Text)) { 

                         ilanmiktar = Int32.Parse(kayitoku.GetValue(2).ToString());
                         ilanmiktar -= alinacakmiktar;              //ilandaki ürün miktarı alınıyor ve satış sonrası kalacak ürün miktarı değeri bulunuyor


                         OleDbCommand ilanyenimiktar = new OleDbCommand("update ilanlar set miktar='" + ilanmiktar + "' where ilanno='" + kayitoku.GetValue(4).ToString() + "'", baglantim);
                         ilanyenimiktar.ExecuteNonQuery();      //ilanda satış sonrası kalacak ürün miktarı ilan bilgisi içinde güncelleniyor


                         satilan_urun_para_ekle(kayitoku.GetValue(0).ToString(), odenecekfiyat);        //ürün alış verişi sırasında aktarılan para ve ürünleri envanterlere ekleyecek fonksiyonlar çağırılıyoz ve parametreleri veriliyor
                         alinan_urun_ekle(alinacakurun, alinacakmiktar, odenecekfiyat);


                         baglantim.Close();
                         MessageBox.Show("satın alma başarılı ürün alındı,para verildi");


                         ilanlari_goster();         //satış sonrası ilanlar ve kişi envanterleri yenileniyor
                         envanter_getir();

                          break;
                    }
                    else
                    {
                        MessageBox.Show("hesap bakiyeniz yetersiz daha fazla alım yapamazsınız");
                        break;
                    }

                }

                else if (Int32.Parse(kayitoku.GetValue(2).ToString()) == alinacakmiktar)        //eğer alınacak miktar ilandaki ile eşit ise tüm ilan ürünü alınıyro ve sonrasında ilan siliniyor
                {

                    odenecekfiyat = Int32.Parse(kayitoku.GetValue(3).ToString()) * alinacakmiktar;

                    if (odenecekfiyat <= Int32.Parse(hesapparayaz.Text))
                    {

                         satilan_urun_para_ekle(kayitoku.GetValue(0).ToString(), odenecekfiyat);
                         alinan_urun_ekle(alinacakurun, alinacakmiktar, odenecekfiyat);


                         OleDbCommand silsorgu = new OleDbCommand("delete from ilanlar where ilanno='" + sililanno + "'", baglantim);       //ilan numarası kullanılaarak tükenmiş ilan siliniyor 
                         silsorgu.ExecuteNonQuery();


                         baglantim.Close();
                          MessageBox.Show("satın alma başarılı ürün alındı,para verildi");


                         ilanlari_goster();
                         envanter_getir();

                         break;

                    }
                    else
                    {
                        MessageBox.Show("hesap bakiyeniz yetersiz daha fazla alım yapamazsınız");
                        break;
                    }


                }
                else if (Int32.Parse(kayitoku.GetValue(2).ToString()) < alinacakmiktar)         //eğer ilan miktarından fazla ürün alınmışsa ilk ilan ürünleri aktarılıp o ilan siliniyor ve sonrasında kalan miktar sonraki en ucuz ilandan satılıyor 
                    {

                    ilandakimiktar = Int32.Parse(kayitoku.GetValue(2).ToString());

                    kalan = alinacakmiktar - Int32.Parse(kayitoku.GetValue(2).ToString());



                    odenecekfiyat = Int32.Parse(kayitoku.GetValue(2).ToString()) * Int32.Parse(kayitoku.GetValue(3).ToString());

                    if (odenecekfiyat <= Int32.Parse(hesapparayaz.Text))
                    {

                          satilan_urun_para_ekle(kayitoku.GetValue(0).ToString(), odenecekfiyat);
                          alinan_urun_ekle(alinacakurun, ilandakimiktar, odenecekfiyat);

                          OleDbCommand silsorgu = new OleDbCommand("delete from ilanlar where ilanno='" + sililanno + "'", baglantim);
                          silsorgu.ExecuteNonQuery();

                          baglantim.Close();
                          MessageBox.Show("satın alma başarılı ürün alındı,para verildi");

                         ilanlari_goster();
                         envanter_getir();
                        
                    
                         urun_satin_al(kalan);
                         break;

                    }
                    else
                    {
                        MessageBox.Show("hesap bakiyeniz yetersiz daha fazla alım yapamazsınız");
                        break;
                    }


                }

            }
            if (ucuz_Arama_durumu == false)
            {
                MessageBox.Show("satın alma işlemi başarısız!,ürün bulunamadı");
            }
            baglantim.Close();
        }



        private void button1_Click(object sender, EventArgs e)      //ÜRÜN SATIN AL BUTONUNA TIKLANDIĞINDA YAPILACAK İŞLEMLER
        {

            urun_satin_al(Int32.Parse(urunalmiktar.Text));

        }

        private void paraeklebuton_Click(object sender, EventArgs e)        //PARA TALEP ETME BUTONUNA TIKLANDIĞINDA YAPILACAK İŞLEMLER
        {
            para_ekle();
        }

        private void uruneklebtn_Click(object sender, EventArgs e)        //ÜRÜN YÜKLE BUTONUNA TIKLANDIĞINDA YAPILACAK İŞLEMLER
        {
            urun_ekle();
        }

        private void button3_Click(object sender, EventArgs e)      //ÇIKIŞ TUŞUNDA YAPILACAK İŞLEMLER
        {
            this.Hide();
            Form1 girisform = new Form1();
            girisform.Show();
        }

        private void button2_Click(object sender, EventArgs e)      //YENİ ÜRÜN İLANI OLUŞTURULDUĞUNDA YAPILAN İŞLEMLER
        {


            envanterazalt();

        }

    }
}
