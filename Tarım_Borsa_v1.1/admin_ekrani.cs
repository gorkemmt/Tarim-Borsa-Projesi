﻿using System;
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
using System.Xml;

namespace Tarım_Borsa_v1._1
{
    public partial class admin_ekrani : Form
    {
        public admin_ekrani()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=personel.accdb");

        private void admin_ekrani_Load(object sender, EventArgs e)          //ADMİN EKRANININ LOAD KISMINDA GEREKLİ FONKSİYONLARI ÇAĞIRDIK
        {
            this.Text = "Admin İşlemleri";
            kullanici_goster();
            onaysiz_para_talebi_göster();
            ilanlar(); 
            onaysiz_urun_talebi_göster();
            envanter_bilgi_getir();
            kur_getir();

            tabControl1.ItemSize = new Size(0, 1);      //tabcontrol1 sekme başlıkları gizlendi
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        private void kullanici_goster()         // KULLANICI LİSTESİ SAYFASINDA KULLANICI BİLGİLERİNİ GÖSTERMEMİZE YARAYAN FONKSİYON
        {
            
                baglantim.Open();

                OleDbDataAdapter kullanici_listele = new OleDbDataAdapter("select kimlikno AS [TC KİMLİK NO],ad AS [ADI],soyad AS [SOYADI],kullaniciadi AS [KULLANICI ADI],parola AS [PAROLA],yetki AS [YETKİ],telefon AS [TELEFON NO],mail AS [MAİL ADRES],adres AS [ADRES] from kullanicilar Order By ad ASC", baglantim);    //kullanicilar tablosundan bilgileri çektik

                DataSet dsbellek = new DataSet();  //bellek alanı ayırdık

                kullanici_listele.Fill(dsbellek);  //alanı doldurduk 

                admindgw.DataSource = dsbellek.Tables[0];  //dgw nin bilgi alacağı yeri bellekte ayırdığımız dsbellek yeri olarak gösterdik orada ki 0.tabloyu sectik

                baglantim.Close();

        }
  
        private void ilanlar()          //SATIŞTA OLAN İLANLARI GÖSTERMEK İÇİN FONKSİYON
        {
            
                baglantim.Open();

                OleDbDataAdapter ilan_listele = new OleDbDataAdapter("select kullaniciadi AS [KULLANICI ADI],urun AS [ÜRÜN TÜRÜ],miktar AS [MİKTAR BİLGİSİ],fiyat as [BİRİM FİYATI ],ilanno AS [İLAN NUMARASI],ilantoplamfiyat AS [İLAN FİYATI] from ilanlar  Order By kullaniciadi ASC", baglantim);

                DataSet dsbellek = new DataSet();  

                ilan_listele.Fill(dsbellek);  

                adminilandgw.DataSource = dsbellek.Tables[0];  

                baglantim.Close();

        }

        private void onaysiz_para_talebi_göster()       // BAKİYE YÜKLEME TALEPLERİNİ VE DURUMLARI GÖSTERMEK İÇİN FONKSİYON
        {
            
                baglantim.Open();

                OleDbDataAdapter onaysiz_para_ilan_listele = new OleDbDataAdapter("select kullaniciadi AS [KULLANICI ADI],para AS [YÜKLENEN BAKİYE],durum AS [ONAY DURUMU],talepno AS [TALEP NO],parabirim AS [PARA BİRİMİ] from paratalep   Order By kullaniciadi ASC", baglantim);

                DataSet dsbellek1 = new DataSet();  

                onaysiz_para_ilan_listele.Fill(dsbellek1);  

                onaysizparadgw.DataSource = dsbellek1.Tables[0];  

                baglantim.Close();

        }

        private void onaysiz_urun_talebi_göster()       // ÜRÜN YÜKLEME TALEPLERİNİ VE DURUMLARI GÖSTERMEK İÇİN FONKSİYON
        {
            
                baglantim.Open();

                OleDbDataAdapter onaysiz_para_ilan_listele = new OleDbDataAdapter("select kullaniciadi AS [KULLANICI ADI],pamuk AS [PAMUK],arpa AS [ARPA],bugday AS [BUĞDAY],petrol AS [PETROL],yulaf AS [yulaf],durum AS [TALEP DURUMU],talepno AS [TALEP NO] from uruntalep   Order By kullaniciadi ASC", baglantim);

                DataSet dsbellek1 = new DataSet();  

                onaysiz_para_ilan_listele.Fill(dsbellek1);  

                onaysizurundgw.DataSource = dsbellek1.Tables[0];  

                baglantim.Close();

        }

        private void urun_ilan_onayla()         //ÜRÜN YÜKLEME TALEPLERİNİN ONAY DURUMUNU DEĞİŞTİRMEYE YARAYAN FONKSİYON
        {
           
                baglantim.Open();
                OleDbCommand onaykomutu = new OleDbCommand("update uruntalep set durum='onayli' where talepno='" + onaysizurundgw.CurrentRow.Cells[7].Value.ToString() + "'", baglantim);           //update komutu kullanarak veritabanında uruntalep tablosundaki onay durumlarını güncelledik

                onaykomutu.ExecuteNonQuery();
                
                baglantim.Close();
                envanter_bilgi_getir();
                MessageBox.Show("onay işlemi başarılı");
           
        }

        private void parailan_onayla()          //BAKİYE YÜKLEME TALEPLERİNİN ONAY DURUMUNU DEĞİŞTİRMEYE YARAYAN FONKSİYON
        {

                baglantim.Open();
                OleDbCommand onaykomutu = new OleDbCommand("update paratalep set durum='onayli' where talepno='" + onaysizparadgw.CurrentRow.Cells[3].Value.ToString() + "'", baglantim);

                onaykomutu.ExecuteNonQuery();
                
                baglantim.Close();
                envanter_bilgi_getir();
                MessageBox.Show("onay işlemi başarılı");
      
        }

        private void envanter_bilgi_getir()         //ÜYELERİN ENVANTER BİLGİLERİNİ GETİRREN FONKSİYON
        {
            baglantim.Open();

            OleDbDataAdapter envanter_listele = new OleDbDataAdapter("select kullaniciadi AS [KULLANICI ADI],para AS [HESAP BAKİYESİ],pamuk AS [PAMUK],arpa AS [ARPA],bugday AS [BUĞDAY],petrol AS [PETROL],yulaf AS [YULAF] from envanterler Order By kullaniciadi ASC", baglantim);    //envanterler tablosundan bilgileri çektik

            DataSet dsbellek = new DataSet();  

            envanter_listele.Fill(dsbellek);  

            uyeenvgoster.DataSource = dsbellek.Tables[0];
            uyeenvgoster2.DataSource = dsbellek.Tables[0];


            baglantim.Close();
        }

        private void cikis_fonk()       //ÇIKIŞ FONKSİYONU
        {
            this.Hide();
            Giris girisform = new Giris();
            girisform.Show();
        }

        private void kur_getir()       //ANLIK OLARAK DÖVİZ BİLGİSİNİ XML ÜZERİNDEN ALAN FONKSİYON -----YENİ İSTEK
        {
            string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmldoc = new XmlDocument();
            xmldoc.Load(bugun);

            string Dolar = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/BanknoteSelling").InnerXml;    //dolar değişkenine siteüzerinden bilgiyi alıp yazıyoruz
            dolaryaz.Text = string.Format(" {0} ", Dolar).Replace('.', ',');    //admin ekranında kur bilgilerini yazdırıp görülmesini sağladık ve gelen bilginin sorun çıkarmaması için  . ve , değişimini yaptık

            string Euro = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/BanknoteSelling").InnerXml;
            euroyaz.Text = string.Format(" {0} ", Euro).Replace('.', ',');

            string Sterlin = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/BanknoteSelling").InnerXml;
            sterlinyaz.Text = string.Format(" {0} ", Sterlin).Replace('.', ',');

        }




        private void paraonaybtn_Click(object sender, EventArgs e)   //BAKİYE TALEBİNİ YÜKLE BUTONUNUN İŞLEMLERİ----YENİLİK VAR
        {
            double yenipara = 0;
            bool envanter_arama_durum = false;

            baglantim.Open();

            OleDbCommand envantersorgu = new OleDbCommand("select * from envanterler where kullaniciadi='" + onaysizparadgw.CurrentRow.Cells[0].Value + "'", baglantim);    //seçili talebin kullanıcısına ulaştık

            OleDbDataReader kayitoku = envantersorgu.ExecuteReader();


            while (kayitoku.Read())
            {
                envanter_arama_durum = true;

                double anlikkur;
                if (onaysizparadgw.CurrentRow.Cells[4].Value.ToString() == "Dolar") { anlikkur = Convert.ToDouble(dolaryaz.Text); }     //kur bilgisini aldık ve anlikkur değişkenine atadık
                else if (onaysizparadgw.CurrentRow.Cells[4].Value.ToString() == "Euro") { anlikkur = Convert.ToDouble(euroyaz.Text); }
                else if (onaysizparadgw.CurrentRow.Cells[4].Value.ToString() == "Sterlin") { anlikkur = Convert.ToDouble(sterlinyaz.Text); }
                else { anlikkur = 1; }

                yenipara = Convert.ToDouble(onaysizparadgw.CurrentRow.Cells[1].Value.ToString())*anlikkur;        //yenipara değişkenine talepteki para birim miktarı ile döviz birimi üzerinden tl karşılığını hesaplattık  --->yeni
                yenipara += Convert.ToDouble(kayitoku.GetValue(1).ToString());

                OleDbCommand iadekomutu = new OleDbCommand("update envanterler set para='" + yenipara + "' where kullaniciadi='" + onaysizparadgw.CurrentRow.Cells[0].Value + "'", baglantim);
                iadekomutu.ExecuteNonQuery();               //seçili kullanıcının envanterlerine ulaşıp update komutu sayesinde parasını yenipara değişkeninin değerini atadık

                baglantim.Close();

                MessageBox.Show("para talebi başarılı ,bakiye eklendi");

                parailan_onayla();      //ilanın durumunu onaylandı olarak değiştirdik
                onaysiz_para_talebi_göster();       //talepleri gördüğümüz tabloyu yeniledik

                break;

            }
            if (envanter_arama_durum == false)      //eğer hata oluşur ve onaylanamazsa admine uyarı gösterdik 
            {
                MessageBox.Show("bakiye eklenemedi!");
            }

            baglantim.Close();
            onaysiz_para_talebi_göster();

        }      

        private void parareddbtn_Click(object sender, EventArgs e)      //BAKİYE TALEBİ KABUL EDİLMEZSE YAPILACAK İŞLEMLER
        {
            baglantim.Open();

            OleDbCommand silsorgu = new OleDbCommand("delete from paratalep where talepno='" + onaysizparadgw.CurrentRow.Cells[3].Value + "'", baglantim);      //reddedilen bakiye talebi ni veritabanına erişip siliyoruz 
            silsorgu.ExecuteNonQuery();

            MessageBox.Show("reddedilen bakiye talebi silindi");

            baglantim.Close();
            
            onaysiz_para_talebi_göster();       //var olan bakiye taleplerini görmek için tekrar çağırdık
            
        }
          
        private void urunonaylabtn_Click(object sender, EventArgs e)        //ÜRÜN TALEBİNİ ONAYLA BUTONUNA TIKLADNDIĞINDA YAPILACAK İŞLEMLER
        {
            int yenipamuk=0,yeniarpa=0,yeniyulaf=0,yenibugday=0,yenipetrol=0 ;
            bool envanter_arama_durum = false;

            baglantim.Open();

            OleDbCommand envantersorgu = new OleDbCommand("select * from envanterler where kullaniciadi='" + onaysizurundgw.CurrentRow.Cells[0].Value + "'", baglantim);    //seçili kullanıcının envanter bilgisine ulaşıldı 
            OleDbDataReader kayitoku = envantersorgu.ExecuteReader();

            yenipamuk = Int32.Parse(onaysizurundgw.CurrentRow.Cells[1].Value.ToString());
            yeniarpa = Int32.Parse(onaysizurundgw.CurrentRow.Cells[2].Value.ToString());        //kullnaıcının eski urun miktarları alındı
            yenibugday = Int32.Parse(onaysizurundgw.CurrentRow.Cells[3].Value.ToString());
            yenipetrol = Int32.Parse(onaysizurundgw.CurrentRow.Cells[4].Value.ToString());
            yeniyulaf = Int32.Parse(onaysizurundgw.CurrentRow.Cells[5].Value.ToString());



            while (kayitoku.Read())
            {
                envanter_arama_durum = true;

                yenipamuk += Int32.Parse(kayitoku.GetValue(2).ToString());
                yeniarpa += Int32.Parse(kayitoku.GetValue(3).ToString());
                yenibugday += Int32.Parse(kayitoku.GetValue(4).ToString());     //kullanıcının eski urun bilgileri ve yeni eklenen urun bilgileri toplandı
                yenipetrol += Int32.Parse(kayitoku.GetValue(5).ToString());
                yeniyulaf += Int32.Parse(kayitoku.GetValue(6).ToString());

                OleDbCommand iadekomutu = new OleDbCommand("update envanterler set pamuk='" + yenipamuk + "',arpa='" + yeniarpa + "',bugday='" + yenibugday + "',petrol='" + yenipetrol + "',yulaf='" + yeniyulaf + "' where kullaniciadi='" + onaysizurundgw.CurrentRow.Cells[0].Value + "'", baglantim);      //kullanıcının envanter bilgisine yeni urun değerleri update edildi
                iadekomutu.ExecuteNonQuery();

                baglantim.Close();

                MessageBox.Show("ürün kayıt talebi başarılı ,ürünler envantere eklendi");

                urun_ilan_onayla();         //urun talebinin onay durumu değiştirildi ve urun talepleri tablosu yenilendi
                onaysiz_urun_talebi_göster();
                
                break;
                
            }
            if (envanter_arama_durum == false)
            {

                MessageBox.Show("urunler eklenemedi!");     //eğer urunler onaylanamazsa admine uyarı verildi
                onaysiz_urun_talebi_göster();
                
            }

            baglantim.Close();
            
        }

        private void urunreddetbtn_Click(object sender, EventArgs e)        //ÜRÜN TALEBİ REDDEDİLİR İSE YAPILCAK İŞLEM
        {
            baglantim.Open();

            OleDbCommand silsorgu = new OleDbCommand("delete from uruntalep where talepno='" + onaysizurundgw.CurrentRow.Cells[7].Value + "'", baglantim);      //eğer ürün talebi reddedilirse talepler tablosunda silinmesi sağlandı
            silsorgu.ExecuteNonQuery();

            MessageBox.Show("reddedilen ürün talebi silindi");

            baglantim.Close();
            onaysiz_urun_talebi_göster();
            
        }

        private void uruntalepsayfabuton_Click(object sender, EventArgs e)      //ADMİN KULLANICISININ KULLANICILARI VE BİLGİLERİNİ GÖREBİLDİĞİ SAYFAYI GETİRİR.
        {
            tabControl1.SelectedTab = tabkullanıcılar;
        }

        private void button1_Click_1(object sender, EventArgs e)      //ADMİN KULLANICISININ İLANLARI GÖREBİLDİĞİ SAYFAYI GETİRİR.
        {
            tabControl1.SelectedTab = tabilanlar;
        }

        private void button3_Click_1(object sender, EventArgs e)      //ADMİN KULLANICISININ ÜRÜN TALEPLERİNİ ONAYLAMASI VE REDDETMESİ İÇİN KULLANACAĞI SAYFAYI GETİRİR.
        {
            tabControl1.SelectedTab = taburunonay;
        }

        private void button2_Click_1(object sender, EventArgs e)      //ADMİN KULLANICISININ PARA TALEPLERİNİ ONAYLAMASI VE REDDETMESİ İÇİN KULLANACAĞI SAYFAYI GETİRİR.
        {
            tabControl1.SelectedTab = tabparaonay;
        }

        private void button6_Click(object sender, EventArgs e)      //ÇIKIŞ BUTONUNUN İŞLEMLERİNİ ÇAĞIRIR BUTON İÇERİSİNDE
        {
            cikis_fonk();
        }
    }
}
