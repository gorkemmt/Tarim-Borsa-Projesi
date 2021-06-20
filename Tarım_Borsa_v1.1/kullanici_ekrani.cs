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
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace Tarım_Borsa_v1._1
{
    public partial class kullanici_ekrani : Form
    {
        public kullanici_ekrani()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=personel.accdb");

        private static int ilanno = 0, paratalepno = 0, uruntalepno = 0,emirno=0,kayitno=0;     //program içerisinde tablolarda artırımlı olarak kullanacağımız sıralama değerleri oluşturulur.

        private void kullanici_ekrani_Load(object sender, EventArgs e)      //KULLANICI LOAD EKRANINDA YAPILACAK ATAMA VE İŞLEMLER
        {
            this.Text = "Kullanıcı İşlemleri";
            oturumbilgilabel.Text = Giris.kullaniciadi;
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
            emiruruncmbbox.Items.Add("pamuk");
            emiruruncmbbox.Items.Add("arpa");
            emiruruncmbbox.Items.Add("buğday");
            emiruruncmbbox.Items.Add("petrol");
            emiruruncmbbox.Items.Add("yulaf");
            Raporurunsec.Items.Add("pamuk");
            Raporurunsec.Items.Add("arpa");
            Raporurunsec.Items.Add("buğday");
            Raporurunsec.Items.Add("petrol");
            Raporurunsec.Items.Add("yulaf");
            parabirimicmbbox.Items.Add("Türk Lirası");
            parabirimicmbbox.Items.Add("Euro");
            parabirimicmbbox.Items.Add("Dolar");
            parabirimicmbbox.Items.Add("Sterlin");
            rapordenemedgw.Hide();
            emirlerdgw.Hide();
            tabloadiyaz.Text = "Güncel İlanlar :";
            
            tabControl1.ItemSize = new Size(0, 1);      //tabcontrol sekme başlıkları gizlendi
            tabControl1.SizeMode = TabSizeMode.Fixed;


            envanter_getir();       //kullanıcının envanter bilgisi çekildi ve gösterildi
            ilanlari_goster();      //satışta olan ilanlar gösterildi
            emirlistekontrol();
            emirgoster();
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
                petrolyaz.Text = kayitoku.GetValue(5).ToString();//envanter bilgisi yazdırıldı
                yulafyaz.Text = kayitoku.GetValue(6).ToString();
                    


                break;

            }
            if (envanter_arama_durum == false)
            {
                MessageBox.Show("kullanıcıya ait envanter bilgisi bulunamadı!");
            }

            baglantim.Close();

        }

        private void emirgoster()       //KULLANICININ KENDİSİNE AİT BEKLEYEN ALIM EMİRLERİNİ TABLOYA GETİREN FONKSİYON----YENİ
        {
            baglantim.Open();

            OleDbDataAdapter emir_listele = new OleDbDataAdapter("select kullaniciadi AS [KULLANICI ADI],urunturu AS [ÜRÜN TÜRÜ],urunmiktari AS [MİKTAR BİLGİSİ],urunfiyati as [BİRİM FİYATI ],emirno AS [EMİR NUMARASI],emirdurum AS [DURUMU],emirsaati AS [OLUŞUM SAATİ] from emirler where kullaniciadi='"+ oturumbilgilabel.Text+"' Order By emirno ASC", baglantim);   //emirler tablosundan kullanıcıya ait olan emirleri tabloya getirir 

            DataSet dsbellek = new DataSet();

            emir_listele.Fill(dsbellek);

            emirlerdgw.DataSource = dsbellek.Tables[0]; //gelen verileri tabloya yazar

            baglantim.Close();
        }

        private void ilan_ekle()        //İLAN OLUŞTURMA FONSKSİYONU
        {


            double toplamfiyat = 0;
            if (satismiktar.Text == "" || satisfiyat.Text == "" || urunseccmb1.SelectedIndex == -1) //ürün satarken bilgilerin eksik girilmemesi için if ile kontrol ettirdim
            {
                MessageBox.Show("eksik seçim yaptınız değer giriniz (ilan verilemedi!)");
            }
            else
            {
                
                toplamfiyat = Convert.ToDouble(satismiktar.Text) * Convert.ToDouble(satisfiyat.Text);     //ilanın tamamının fiyatı oluştu

                baglantim.Open();

                OleDbCommand satiskomutu = new OleDbCommand("insert into ilanlar values('" + oturumbilgilabel.Text + "','" + urunseccmb1.Text + "','" + satismiktar.Text + "','" + satisfiyat.Text + "','" + ilanno + "','" + toplamfiyat + "')", baglantim);       //girilen verilerde ilanlar tablosunda yeni kayıt oluşturuluyor
                satiskomutu.ExecuteNonQuery();

                ilanno++;       // ilan numarası artılıyor ilanların farklı numaralara sahip olması için

                baglantim.Close();

                MessageBox.Show("ürünler ilana eklendi");
            }
        }

        private void alinan_urun_ekle(string urunturu, double alinanmiktar, double odenenfiyat)     // ÜRÜN SATIN ALINDIĞINDA ALAN KİŞİNİN BİLGİLERİNİ GÜNCELLEYEN FONKSİYON
        {

            odenenfiyat =(Convert.ToDouble(hesapparayaz.Text)-odenenfiyat);      //ürün satın alan kişinin elinde kalacak olan para hesaplandı

            if (urunturu == "pamuk")            //satın alınan ürüne göre envanter artırılıyor ve parası eksiliyor;
            {
                alinanmiktar += Convert.ToDouble(pamukyaz.Text);
                OleDbCommand ilanalımenvguncelle = new OleDbCommand("update envanterler set pamuk='" + alinanmiktar + "',para='" + odenenfiyat + "' where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                ilanalımenvguncelle.ExecuteNonQuery();
            }
            else if (urunturu == "arpa")
            {
                alinanmiktar += Convert.ToDouble(arpayaz.Text);
                OleDbCommand ilanalımenvguncelle = new OleDbCommand("update envanterler set arpa='" + alinanmiktar + "',para='" + odenenfiyat + "' where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                ilanalımenvguncelle.ExecuteNonQuery();
            }
            else if (urunturu == "buğday")
            {
                alinanmiktar += Convert.ToDouble(bugdayyaz.Text);
                OleDbCommand ilanalımenvguncelle = new OleDbCommand("update envanterler set bugday='" + alinanmiktar + "',para='" + odenenfiyat + "' where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                ilanalımenvguncelle.ExecuteNonQuery();
            }
            else if (urunturu == "petrol")
            {
                alinanmiktar += Convert.ToDouble(petrolyaz.Text);
                OleDbCommand ilanalımenvguncelle = new OleDbCommand("update envanterler set petrol='" + alinanmiktar + "',para='" + odenenfiyat + "' where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                ilanalımenvguncelle.ExecuteNonQuery();
            }
            else if (urunturu == "yulaf")
            {
                alinanmiktar += Convert.ToDouble(yulafyaz.Text);
                OleDbCommand ilanalımenvguncelle = new OleDbCommand("update envanterler set yulaf='" + alinanmiktar + "',para='" + odenenfiyat + "' where kullaniciadi='" + oturumbilgilabel.Text + "'", baglantim);
                ilanalımenvguncelle.ExecuteNonQuery();
            }
          
        }

        private void satilan_urun_para_ekle(string kisi, double eklenenpara)        //SATİLAN İLANIN PARASINI SATICIYA EKLEYEN FONKSİYON
        {
            double olanpara = 0;

            OleDbCommand sorgu = new OleDbCommand("select * from envanterler where kullaniciadi='"+kisi+"'", baglantim);        //satıcı kişinin envanter bilgisine erişiliyor
            OleDbDataReader kayitoku = sorgu.ExecuteReader();

            while (kayitoku.Read())
            {

            olanpara = Convert.ToDouble( kayitoku.GetValue(1).ToString());


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

                OleDbCommand paratalepkomutu = new OleDbCommand("insert into paratalep values('" + oturumbilgilabel.Text + "','" + paragirtbox.Text + "','onaysiz','" + paratalepno + "','"+parabirimicmbbox.Text+"')", baglantim);
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

        private void urun_satin_al(int alinacakmiktar,string alinacakurun)      //ÜRÜN SATIN ALIMINDA KULLANILACAK FONKSİYON---YENİLENDİ
        {
            
            bool ucuz_Arama_durumu = false;
            int   ilanmiktar = 0, kalan = 0,ilandakimiktar=0; ;
            double odenecekfiyat = 0,yüzde1;


            OleDbCommand ilanucuzbul = new OleDbCommand("select * from ilanlar where urun='" + alinacakurun + "'Order By fiyat ASC ", baglantim);       //istenilen ürün türündeki ilanlar fiyata göe azdan çok a doğru sıralanıryor

            OleDbDataReader kayitoku = ilanucuzbul.ExecuteReader();



            while (kayitoku.Read())
            {
                ucuz_Arama_durumu = true;

                int sililanno = Int32.Parse(kayitoku.GetValue(4).ToString());   //ilanın tüm ürünleri alınırsa silinebilmesi için ilan numarası alınıyor


               
                if (Int32.Parse(kayitoku.GetValue(2).ToString()) > alinacakmiktar)          //alınacak ürünün miktarının ilandaki miktara göre daha az, eşit ,daha fazla miktarda olması if ile kontrol ediliyor
                    {

                    odenecekfiyat = Convert.ToDouble(kayitoku.GetValue(3).ToString()) * alinacakmiktar;
                    yüzde1 = (odenecekfiyat / 100) * 1;             //ilandaki ürüne ödenecek fiyatın yüzde 1 i alınır ve yüzde1 değişkenine yazılır--->yeni
                    
                    

                    if (odenecekfiyat <= Convert.ToDouble(hesapparayaz.Text)) { 

                         ilanmiktar = Int32.Parse(kayitoku.GetValue(2).ToString());
                         ilanmiktar -= alinacakmiktar;              //ilandaki ürün miktarı alınıyor ve satış sonrası kalacak ürün miktarı değeri bulunuyor


                         OleDbCommand ilanyenimiktar = new OleDbCommand("update ilanlar set miktar='" + ilanmiktar + "' where ilanno='" + kayitoku.GetValue(4).ToString() + "'", baglantim);
                         ilanyenimiktar.ExecuteNonQuery();      //ilanda satış sonrası kalacak ürün miktarı ilan bilgisi içinde güncelleniyor


                         satilan_urun_para_ekle(kayitoku.GetValue(0).ToString(), odenecekfiyat);        //ürün alış verişi sırasında aktarılan para ve ürünleri envanterlere ekleyecek fonksiyonlar çağırılıyoz ve parametreleri veriliyor
                        komisyon_al(yüzde1);                //---->yeni KOMİSYON AL FONKSİYONUNA ALINAN ÜRÜN ÜCERİTİN YÜZDE 1 LİK KISMI GÖNDERİLİR
                         alinan_urun_ekle(alinacakurun, alinacakmiktar, odenecekfiyat+yüzde1);

                        ilan_kayit(oturumbilgilabel.Text,kayitoku.GetValue(0).ToString(),alinacakurun,Convert.ToDouble(kayitoku.GetValue(3)), alinacakmiktar);
                         
                         MessageBox.Show("satın alma başarılı ürün alındı,para verildi");


                         

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

                    odenecekfiyat = Convert.ToDouble(kayitoku.GetValue(3).ToString()) * alinacakmiktar;
                    yüzde1 = (odenecekfiyat / 100) * 1;


                    if (odenecekfiyat <= Convert.ToDouble(hesapparayaz.Text))
                    {

                         satilan_urun_para_ekle(kayitoku.GetValue(0).ToString(), odenecekfiyat);
                        komisyon_al(yüzde1);
                        alinan_urun_ekle(alinacakurun, alinacakmiktar, odenecekfiyat+yüzde1);

                        ilan_kayit(oturumbilgilabel.Text, kayitoku.GetValue(0).ToString(), alinacakurun, Convert.ToDouble(kayitoku.GetValue(3)), alinacakmiktar);


                        OleDbCommand silsorgu = new OleDbCommand("delete from ilanlar where ilanno='" + sililanno + "'", baglantim);       //ilan numarası kullanılaarak tükenmiş ilan siliniyor 
                         silsorgu.ExecuteNonQuery();


                        
                          MessageBox.Show("satın alma başarılı ürün alındı,para verildi");


                         

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



                    odenecekfiyat = Convert.ToDouble(kayitoku.GetValue(2).ToString()) * Convert.ToDouble(kayitoku.GetValue(3).ToString());
                    yüzde1 = (odenecekfiyat / 100) * 1;


                    if (odenecekfiyat <= Convert.ToDouble(hesapparayaz.Text))
                    {

                          satilan_urun_para_ekle(kayitoku.GetValue(0).ToString(), odenecekfiyat);
                        komisyon_al(yüzde1);
                        alinan_urun_ekle(alinacakurun, ilandakimiktar, odenecekfiyat+yüzde1);

                        ilan_kayit(oturumbilgilabel.Text, kayitoku.GetValue(0).ToString(), alinacakurun, Convert.ToDouble(kayitoku.GetValue(3)), Convert.ToInt32(kayitoku.GetValue(2)));

                        OleDbCommand silsorgu = new OleDbCommand("delete from ilanlar where ilanno='" + sililanno + "'", baglantim);
                          silsorgu.ExecuteNonQuery();

                          
                          MessageBox.Show("satın alma başarılı ürün alındı,para verildi");

                         
                        
                    
                         urun_satin_al(kalan,alinacakurun);
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
            
        }

        private void komisyon_al(double komisyonpara)           //MUHASEBE KULLANICISINA %1 KOMİSYON ÖDENMESİNİ SAĞLAYAN FONKSİYONDUR --->YENİ
        {
            double muhasebepara;
            OleDbCommand muhasebesorgu = new OleDbCommand("select * from envanterler where kullaniciadi='Muhasebe_kullanıcısı'", baglantim);       //muhasebecinin envanter bilgisine erişip o anki para miktarını okuyoruz

            OleDbDataReader muhasebekayitoku = muhasebesorgu.ExecuteReader();
            muhasebekayitoku.Read();

            
            muhasebepara =Convert.ToDouble( muhasebekayitoku.GetValue(1));      //daha sonra zaten var olan parası ile yeni gelen komisyon ücretini birleştirdik
            muhasebepara += komisyonpara;

            OleDbCommand guncellekomisyon = new OleDbCommand(" update envanterler set para='" + muhasebepara + "'where kullaniciadi='Muhasebe_kullanıcısı'", baglantim);        //oluşan yeni para+komisyon bilgisini muhasebe hesabına para bilgisi olarak kaydettik
            guncellekomisyon.ExecuteNonQuery();


        }

        private void emirekle()         //KULLANICILARIN O ANDA OLMAYAN ÜRÜNDEN VEYA İSTEDİĞİ FİYATTA OLMADIĞINDA O ÜRÜN İÇİN ALIM EMİRİ OLUŞTURMASINI SAĞLAYAN FONKSİYON   YENİ
        {
            string alinacakurun = emiruruncmbbox.Text;
            double emirfiyati = Convert.ToDouble( emirfiyat.Text);
            bool ucuz_Arama_durumu = false;

            

            baglantim.Open();

            OleDbCommand ilanucuzbul = new OleDbCommand("select * from ilanlar where urun='" + alinacakurun + "'Order By fiyat ASC ", baglantim);       //ilanlar tablosuna erişilip emir verilen türde ürün satışı varmı ona bakılıyor

            OleDbDataReader kayitoku = ilanucuzbul.ExecuteReader();

            while (kayitoku.Read())
            {
                ucuz_Arama_durumu = true;

                    if(emirfiyati >= Convert.ToDouble(kayitoku.GetValue(3).ToString()))     //eğer ilan fiyatı emir verilen fiyattan daha düşükse yani ucuz ise
                    {
                    int yenimiktar =Convert.ToInt32( emirmiktar.Text);
                    urun_satin_al(yenimiktar, emiruruncmbbox.Text);     //uygun şartlar olduğunda satin alma fonksiyonuna yönlendiriliyor

                    }
                    else        //eğer emirin alım fiyatı ilandakinde daha az ise yani ilan fiyatı pahalı gelir ise girilen emir bilgileri bekleyen emirler kısmına kaydedilir 
                    {

                    OleDbCommand ekleemir = new OleDbCommand("insert into emirler values ('" + oturumbilgilabel.Text + "','" + emiruruncmbbox.Text + "','" + emirfiyat.Text + "','" + emirmiktar.Text + "','" + emirno + "','" + "bekliyor"+ "','"+ DateTime.Now.ToLongTimeString() + "')", baglantim);  //insert ile kullanıcılar tablosuna yeni emiri eklettik.
                    ekleemir.ExecuteNonQuery(); //ekleemir  komutu isimli sorgunun sonuclarını access e  işlettik

                    MessageBox.Show("istenilen fiyatta ürün ilanı yok emir beklemeye alındı");     //emirin oluşturulduğuna göre kullanıcıya bilgi verildi 

                    emirno++;

                    }      

            }
            
            if (ucuz_Arama_durumu == false)         //eğer ilk ürün ilanı ile emirin ürün türü karşılaştırıldığında o türde ürün bulunamazsa aşağıdaki if sorgusuna girer
            {

                OleDbCommand ekleemir = new OleDbCommand("insert into emirler values ('" + oturumbilgilabel.Text + "','" + emiruruncmbbox.Text + "','" + emirfiyat.Text + "','" + emirmiktar.Text + "','" + emirno + "','" + "bekliyor" + "','" + DateTime.Now.ToLongTimeString() + "')", baglantim);  //insert ile kullanıcılar tablosuna yeni emiri eklettik.
                ekleemir.ExecuteNonQuery(); //ekleemir komutu isimli sorgunun sonuclarını access e  işlettik

                MessageBox.Show("bu türde ürün ilanı yok emir beklemeye alındı");       //kullanıcıya bu türde ürün ilanı olmadığını ve emir oluşturulduğu bilgisi verildi
                emirno++;
                

            }
            baglantim.Close();
            ilanlari_goster();
            envanter_getir();
            emirgoster();
        }

        private void ilan_kayit(string aliciad,string saticiad,string urunad,double fiyat,int miktar)           //YAPILAN ALIM-SATIM İŞLEMLERİ ESKİİSLEMLER TABLOSUNA KAYIT ETTİRİLİR---YENİ
        {
            OleDbCommand islemkayit = new OleDbCommand("insert into eskiislemler values ('" + aliciad + "','" + saticiad + "','" + urunad + "','" + fiyat + "','" + miktar + "','" + DateTime.Now.ToShortDateString() + "','" + kayitno + "')", baglantim);             //gerekli bilgiler veritabanında eskiislemlerin tutulduğu tabloya kaydedilir
            islemkayit.ExecuteNonQuery();

            kayitno++;

        }

        private void emirlistekontrol()  // EMİRLER LİSTESİNDE ARTIK GEÇERLİ EMİR VARSA ALIM SATIMI GERÇEKLEŞMESİ İÇİN KONTROL ETTİREN FONKSİYON ----YENİ
        {
            double emirfiyat, ilanfiyat;
            int i,k,emirmiktar,ilanmiktar;
            string emirurunu, ilanurunu;

            baglantim.Open();

            

            for (k = 0; k <= emirno; k++)
            {
                OleDbCommand emirilkbul = new OleDbCommand("select * from emirler where emirno='" + k + "'", baglantim);       //emirler tablodan ilan numarası ile baştan sona döngüye sokulur

                OleDbDataReader emirkayitoku = emirilkbul.ExecuteReader();


                while (emirkayitoku.Read())
                {
                    
                    for (i = 0; i < ilanno; i++)
                    {
                        

                        OleDbCommand ilanucuzbul = new OleDbCommand("select * from ilanlar where ilanno='" + i + "'", baglantim);       //ilanlar ilanno ya göre döngüye girer

                        OleDbDataReader ilankayitoku = ilanucuzbul.ExecuteReader();
                        
                        ilankayitoku.Read();

                      

                        emirurunu = Convert.ToString(emirkayitoku.GetValue(1));     //ürün,fiyat,miktar verileri ilanlar ver emirler arasında uyuşma durumu varmı kontrol edilir
                        ilanurunu = Convert.ToString(ilankayitoku.GetValue(1));
                        emirfiyat = Convert.ToDouble(emirkayitoku.GetValue(2));
                        ilanfiyat = Convert.ToDouble(ilankayitoku.GetValue(3));
                        emirmiktar = Convert.ToInt32(emirkayitoku.GetValue(3));
                        ilanmiktar = Convert.ToInt32(ilankayitoku.GetValue(2));




                        if (emirurunu == ilanurunu && emirfiyat >= ilanfiyat && emirmiktar <= ilanmiktar)       //karşılaştırılan değerler uygunluk durumu sağlanırsa o ilan alıcı tarafından satın alınır ve emir alımı gerçeklerşir
                        {

                            urun_satin_al(Convert.ToInt32(emirkayitoku.GetValue(3)), Convert.ToString(emirkayitoku.GetValue(1)));

                            MessageBox.Show("bekleyen emir alımı gerçekleşti ürün:"+emirurunu);



                            OleDbCommand silemir = new OleDbCommand("delete from emirler where emirno='" + k + "'", baglantim);       //emirno numarası kullanılaarak gerçekleşmiş emirler siliniyor hsta ilanno
                            silemir.ExecuteNonQuery();          //alımı gerçekleşmiş emirler bekleyen emirler tablosunda silinir.

                            MessageBox.Show("emir silindi emirno="+k);
                        }
                    }
                }
            }
            baglantim.Close();
            envanter_getir();       //kullanıcının envanter bilgisi çekildi ve gösterildi
            ilanlari_goster();      //satışta olan ilanlar gösterildi
            emirgoster();

        }

        private void dgwyonetim()       //SEÇİLEN TABCONTROL SEKMESİNE GÖRE GÖSTERİLECEK TABLOLARIN GİZLENME GÖRÜNTÜLENME DURUMUNU GÖSTEREN FONKSİYON ---YENİ
        {
            if (tabControl1.SelectedTab == raporpage)
            {
                emirlerdgw.Hide();
                ilandgw.Hide();
                rapordenemedgw.Show();
                tabloadiyaz.Text = "Geçmiş İşlemler :";
            }
            else
            {
                ilandgw.Show();
                emirlerdgw.Hide();
                rapordenemedgw.Hide();
                tabloadiyaz.Text = "Güncel İlanlar :";
            }
        }

        private void rapor_listele(string baslangıcal,string bitisal,string urunturual) // RAPOR SAYFASINDA SEÇİLEN BİLGİLERE GÖRE ESKİ İŞLEMLERİN KAYIT EDİLDİĞİ TABLODA VERİLERİ ALIP EKRANA GETİRENN FONKSİYON ---YENİ
        {
            string sorgukod="";
            bool secimkontrol = false;
            dgwyonetim();

            baglantim.Open();


            if (sadecealimradiobtn.Checked)     //seçilen alım -satım durumuna göre veritabanında o satırı arayan sorgular yazıldı
            {
                sorgukod = "select islemtarih AS [İŞLEM TARİHİ],urun AS [ÜRÜN TİPİ],fiyat AS [ALIM TUTARI],miktar AS [MİKTAR] from eskiislemler where alici='" + oturumbilgilabel.Text + "' AND urun='" + urunturual + "' AND islemtarih >= '" + baslangictarihsec.Text + "' and islemtarih <= '" + bitistarihsec.Text + "'";
            }
            else if (sadecesatisradiobtn.Checked)
            {
                sorgukod= "select islemtarih AS [İŞLEM TARİHİ],urun AS [ÜRÜN TİPİ],fiyat AS [ALIM TUTARI],miktar AS [MİKTAR] from eskiislemler where satici='" + oturumbilgilabel.Text + "' AND urun='" + urunturual + "' AND islemtarih >= '" + baslangictarihsec.Text + "' and islemtarih <= '" + bitistarihsec.Text + "'";
            }
            else if (alimvesatimradiobtn.Checked)
            {
                sorgukod = "select islemtarih AS [İŞLEM TARİHİ],urun AS [ÜRÜN TİPİ],fiyat AS [ALIM TUTARI],miktar AS [MİKTAR] from eskiislemler where satici='" + oturumbilgilabel.Text + "' OR alici='" + oturumbilgilabel.Text + "' AND urun='" + urunturual + "' AND islemtarih >= '" + baslangictarihsec.Text + "' and islemtarih <= '" + bitistarihsec.Text + "'";
            }
            else        //seçimin boş geçilmemesi için bir uyarı eklendi.
            {
                secimkontrol = true;
                MessageBox.Show("alış/satış durumu seçiniz");
                baglantim.Close();
            }

            if (secimkontrol == false) { 
            OleDbDataAdapter rapordegerbul = new OleDbDataAdapter(sorgukod, baglantim);   //eski ilan bilgileri veritabanından çekildi datagridview e yüklendi
            DataSet dsraporbellek = new DataSet();
            rapordegerbul.Fill(dsraporbellek);

            rapordenemedgw.DataSource = dsraporbellek.Tables[0];    //daha sonrasında getirilen eski ilan bilgileri ekrana yazdırıldı

            baglantim.Close();
            }
        }

        private void cikis()            //GEREKTİĞİNDE TEKRAR KULLANABİLMESİ İÇİN ÇIKIŞ YAPIP GİRİŞ EKRANINA DÖNDÜREN FONKSİYON
        {
            this.Hide();
            Giris girisform = new Giris();
            girisform.Show();
        }




        private void button1_Click(object sender, EventArgs e)      //ÜRÜN SATIN AL BUTONUNA TIKLANDIĞINDA YAPILACAK İŞLEMLER
        {
            baglantim.Open();
            urun_satin_al(Int32.Parse(urunalmiktar.Text),urunsecalcmb.Text);
            baglantim.Close();
            ilanlari_goster();
            envanter_getir();

        }

        private void paraeklebuton_Click(object sender, EventArgs e)        //PARA TALEP ETME BUTONUNA TIKLANDIĞINDA YAPILACAK İŞLEMLER
        {
            para_ekle();
        }

        private void uruneklebtn_Click(object sender, EventArgs e)        //ÜRÜN YÜKLE BUTONUNA TIKLANDIĞINDA YAPILACAK İŞLEMLER
        {
            urun_ekle();
        }

        private void button4_Click(object sender, EventArgs e)          //SEÇİLEN DURUMLARA GÖRE ESKİDEN ALIM-SATIM YAPILMIŞ İŞLEMLERİ LİSTELETEN BUTON---YENİ
        {
            rapor_listele(baslangictarihsec.Text, bitistarihsec.Text, Raporurunsec.Text);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)           //TABCONTROL ÜZERİNDE SEKME DEĞİŞİKLİKLERİ OLDUKÇA HANGİ TABLONUN GÖSTERİLECEĞİNİ KONTROL ETTİREN FOKNKSİYONU ÇAĞIRIYORUZ---YENİ
        {
            dgwyonetim();
        }

        private void raporolustur_Click(object sender, EventArgs e)         //TABLODA LİSTELENMİŞ ESKİ İLANLARI EXCEL TABLOSUNA AKTARDIĞIMIZ BUTON ----YENİ
        {
            
            ExcelPackage package = new ExcelPackage();
            package.Workbook.Worksheets.Add("worksheet1");      //excel sayfası oluşturduk 

            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            var columns = rapordenemedgw.Columns;
            for (int i = 0; i < columns.Count; i++)         //daha sonrasında tablonun başlık satırını yazdırdık ve gerekli öxellikleri atanır.
            {
                worksheet.Cells[1, i + 1].Value = columns[i].HeaderText;
                worksheet.Cells[1, i + 1].AutoFitColumns(1);
                worksheet.Cells[1, i + 1].Style.Font.Bold=true;   
            }

            int rowindex = 2;       //ilanları hangi satırdan yazmaya başlayacağınıgirdik.
            var rows = rapordenemedgw.Rows;

            for (int i = 0; i < rows.Count; i++)        //tablonun ilan satırları excele döngüler kullanılarak aktarılırıyor  
            {
                if(rows[i].Cells[0] != null)
                {
                    for (int j = 0; j < rows[i].Cells.Count; j++)
                    {
                        worksheet.Cells[rowindex, j+1].Value=rows[i].Cells[j].Value;
                        
                    }
                    rowindex++;
                }

            }

            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.Filter = "excel dosyası|*.xlsx";         //dosya yeri seçilmesi ve oluşturulması için gerekli satırlar
            savefiledialog.ShowDialog();

            Stream stream = savefiledialog.OpenFile();
            package.SaveAs(stream);
            stream.Close();

            MessageBox.Show("Excel dosyası oluşturuldu");       //kullanıcıya dosya oluşum durumuna göre kişiye bilgi veriliyor

        }

        private void button5_Click(object sender, EventArgs e)      // butona basıldığında rapor alma sayfasını ekrana getiren buton
        {
            tabControl1.SelectedTab=raporpage;
        }

        private void button10_Click(object sender, EventArgs e)         //butona basıldığında o anda kikişiye ait kayıtlı emirlerin gösterildiği tabloyu ekrana getirir diğer dgw leri gizler
        {
            emirlerdgw.Show();
            ilandgw.Hide();
            rapordenemedgw.Hide();
            tabloadiyaz.Text = "Kayıtlı Emirler :";
        }

        private void button6_Click(object sender, EventArgs e)      // butona basıldığında ürün ve para talebi oluşturma sayfasını ekrana getiren buton
        {
            tabControl1.SelectedTab = taburuntalep;
        }

        private void urunalimsayfabuton_Click(object sender, EventArgs e)      // butona basıldığında ilanları görmeye ve alım yapmaya yarayan sayfayı ekrana getiren buton
        {
            tabControl1.SelectedTab = ilanalımtabpage;
        }

        private void urunsatissayfabuton_Click(object sender, EventArgs e)      // butona basıldığında ürün satmak için ilan oluşturulan sayfayı ekrana getiren buton
        {
            tabControl1.SelectedTab = urunsatistabpage;
        }

        private void emirsayfabuton_Click(object sender, EventArgs e)      // butona basıldığında istenilen türde ilan emiri oluşturmamıza yarayan sayfayı ekrana getiren buton
        {
            tabControl1.SelectedTab = emirkoytabpage;
        }

        private void button3_Click(object sender, EventArgs e)      //ÇIKIŞ TUŞUNDA YAPILACAK İŞLEMLER
        {
            cikis();
        }

        private void button1_Click_1(object sender, EventArgs e)        //butona basıldığında girilen değerlere göre ilanları kontrol ederek yeni emir oluşmasını sağlayan fonksiyonu çağırır
        {
            emirekle();
        }

        private void button2_Click(object sender, EventArgs e)      //YENİ ÜRÜN İLANI OLUŞTURULDUĞUNDA YAPILAN İŞLEMLER
        {


            envanterazalt();

        }

    }
}
