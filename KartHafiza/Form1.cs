using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KartHafiza
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();
        int i = 0;
        int tutmac;
        int[] kart_sayi = new int[24];
        int[] resim_degeri = new int[12] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        int kart_donus = 0;
        int[] acik_kart = new int[2];
        int bilme_sayisi = 0;

        int donus = 52;
        int[] bilinen_kart = new int[24];
        int number = 0;
        // Resources içerisindeki resimleri dizi haline getirmek için oluşturulan bitmap array
        Bitmap[] myImages = new Bitmap[13];

        // Arayüzdeki kartların hepsini bir dizi haline getirmek için oluşturulan PictureBox array'i
        PictureBox[] PictureBoxs = new PictureBox[24];

        private void baslat_button_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.WindowState = FormWindowState.Maximized;

            for (i = 0; i < 24; i++)
            {
                while (true)
                {
                    tutmac = random.Next(0, 12);
                    if (resim_degeri[tutmac] != 0)
                    {
                        kart_sayi[i] = tutmac;
                        resim_degeri[tutmac]--;
                        break;
                    }
                }
            }

            // Resources içerisindeki resimlerin aktarıldığı dizi
            myImages[0] = new Bitmap(KartHafiza.Properties.Resources.aa);
            myImages[1] = new Bitmap(KartHafiza.Properties.Resources.bb);
            myImages[2] = new Bitmap(KartHafiza.Properties.Resources.cc);
            myImages[3] = new Bitmap(KartHafiza.Properties.Resources.dd);
            myImages[4] = new Bitmap(KartHafiza.Properties.Resources.ee);
            myImages[5] = new Bitmap(KartHafiza.Properties.Resources.ff);
            myImages[6] = new Bitmap(KartHafiza.Properties.Resources.gg);
            myImages[7] = new Bitmap(KartHafiza.Properties.Resources.hh);
            myImages[8] = new Bitmap(KartHafiza.Properties.Resources.jj);
            myImages[9] = new Bitmap(KartHafiza.Properties.Resources.kk);
            myImages[10] = new Bitmap(KartHafiza.Properties.Resources.ll);
            myImages[11] = new Bitmap(KartHafiza.Properties.Resources.mm);
            myImages[12] = new Bitmap(KartHafiza.Properties.Resources.kagit_arka);

            // Kartların hepsinin PictureBoxs dizisine aktarıldığı kısım
            PictureBoxs[0] = kart1;
            PictureBoxs[1] = kart2;
            PictureBoxs[2] = kart3;
            PictureBoxs[3] = kart4;
            PictureBoxs[4] = kart5;
            PictureBoxs[5] = kart6;
            PictureBoxs[6] = kart7;
            PictureBoxs[7] = kart8;
            PictureBoxs[8] = kart9;
            PictureBoxs[9] = kart10;
            PictureBoxs[10] = kart11;
            PictureBoxs[11] = kart12;
            PictureBoxs[12] = kart13;
            PictureBoxs[13] = kart14;
            PictureBoxs[14] = kart15;
            PictureBoxs[15] = kart16;
            PictureBoxs[16] = kart17;
            PictureBoxs[17] = kart18;
            PictureBoxs[18] = kart19;
            PictureBoxs[19] = kart20;
            PictureBoxs[20] = kart21;
            PictureBoxs[21] = kart22;
            PictureBoxs[22] = kart23;
            PictureBoxs[23] = kart24;
            ilk_gosterim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            for (i = 0; i < 24; i++)
            {
                bilinen_kart[i] = 0;
                PictureBoxs[i].Enabled = true;
            }
            for (i = 0; i < 12; i++)
            {
                resim_degeri[i] = 2;
            }
            for (i=0; i < 12; i++)
            {
                resim_degeri[i] = 2;
            }
            panel1.Visible = true;
        }

        private async void ilk_gosterim()
        {

            for (i = 0; i < 24; i++)
            {   
                PictureBoxs[i].Image = myImages[kart_sayi[i]];

            }
            await Task.Delay(5000);
            for (i = 0; i < 24; i++)
            {
                PictureBoxs[i].Image = myImages[12];
            }
        }
        private async void tiklanan_kagit()
        {
            for (i = 0; i < 24; i++)
            {
                PictureBoxs[i].Enabled = false;
            }
            //Kart'a basıldığında ön yüzünü dönmesini sağlayan kısım.
            while (donus > 0)
            {
                PictureBoxs[number].Width = donus * 3;
                donus -= 3;
                await Task.Delay(1);
            }
            donus = 52;
            PictureBoxs[number].Width = 156;
            for (i = 0; i < 24; i++)
            {
                if (bilinen_kart[i] == 1)
                {
                    continue;
                }
                PictureBoxs[i].Enabled = true;
            }


            for (i = 0; i < 12; i++)
            {
                if (kart_sayi[number] == i)
                {
                    PictureBoxs[number].Image = myImages[i];
                    break;
                }
            }

            //Kaçıncı açılan kart olduğu sınanır ve buna göre kıyaslanır.
            if (kart_donus == 0)
            {
                acik_kart[0] = number;
                kart_donus++;
            }
            else if (kart_donus == 1)
            {
                if (kart_sayi[number] == kart_sayi[acik_kart[0]])
                {
                    hamle_label.Text = "Doğru Bildin!";
                    bilme_sayisi++;
                    sayac_label.Text = bilme_sayisi.ToString();

                    if (bilme_sayisi == 12)
                    {
                        bilme_sayisi = 0;
                        sayac_label.Text = bilme_sayisi.ToString();
                        MessageBox.Show("Bu işi biliyorsun.");
                        this.WindowState = FormWindowState.Normal;
                        for (i = 0; i < 24; i++)
                        {
                            bilinen_kart[i] = 0;
                            PictureBoxs[i].Enabled = true;
                        }
                        for (i = 0; i < 12; i++)
                        {
                            resim_degeri[i] = 2;
                        }
                        panel1.Visible = true;
                    }

                    PictureBoxs[number].Enabled = false;
                    bilinen_kart[number] = 1;

                    for (i = 0; i < 24; i++)
                    {
                        if (acik_kart[0] == i)
                        {
                            PictureBoxs[i].Enabled = false;
                            bilinen_kart[i] = 1;
                            break;
                        }
                    }

                }
                else
                {
                    hamle_label.Text = "Yanlış Bildin!";
                    
                    for (i=0; i < 24; i++)
                    {
                        PictureBoxs[i].Enabled=false;
                    }
                    await Task.Delay(1000);
                    for (i = 0; i < 24; i++)
                    {
                        if (bilinen_kart[i] == 1)
                        {
                            continue;
                        }
                        PictureBoxs[i].Enabled = true;
                    }

                    PictureBoxs[number].Image = myImages[12];

                    for (i = 0; i < 24; i++)
                    {
                        if (acik_kart[0] == i)
                        {
                            PictureBoxs[i].Image = myImages[12];
                            break;
                        }
                    }

                }
                kart_donus = 0;
            }
        }

        private void cikis_button_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void kart1_Click(object sender, EventArgs e)
        {
            //Kart'ın ön yüzüne hangi resmin koyulacağını ayarlayan kısım.
            number = 0;
            tiklanan_kagit();
            

        }

        private void kart2_Click(object sender, EventArgs e)
        {
            number = 1;
            tiklanan_kagit();
        }

        private void kart3_Click(object sender, EventArgs e)
        {
            number = 2;
            tiklanan_kagit();
        }


        private void kart4_Click(object sender, EventArgs e)
        {
            number = 3;
            tiklanan_kagit();
        }

        private void kart5_Click(object sender, EventArgs e)
        {
            number = 4;
            tiklanan_kagit();
        }       

        private void kart6_Click(object sender, EventArgs e)
        {
            number = 5;
            tiklanan_kagit();
        }

        private void kart7_Click(object sender, EventArgs e)
        {
            number = 6;
            tiklanan_kagit();
        }

        private void kart8_Click(object sender, EventArgs e)
        {
            number = 7;
            tiklanan_kagit();
        }

        private  void kart9_Click(object sender, EventArgs e)
        {
            number = 8;
            tiklanan_kagit();
        }

        private  void kart10_Click(object sender, EventArgs e)
        {
            number = 9;
            tiklanan_kagit();
        }

        private  void kart11_Click(object sender, EventArgs e)
        {
            number = 10;
            tiklanan_kagit();
        }

        private  void kart12_Click(object sender, EventArgs e)
        {
            number = 11;
            tiklanan_kagit();
        }

        private  void kart13_Click(object sender, EventArgs e)
        {
            number = 12;
            tiklanan_kagit();
        }

        private  void kart14_Click(object sender, EventArgs e)
        {
            number = 13;
            tiklanan_kagit();
        }

        private  void kart15_Click(object sender, EventArgs e)
        {
            number = 14;
            tiklanan_kagit();
        }

        private  void kart16_Click(object sender, EventArgs e)
        {
            number = 15;
            tiklanan_kagit();
        }

        private  void kart17_Click(object sender, EventArgs e)
        {
            number = 16;
            tiklanan_kagit();
        }

        private  void kart18_Click(object sender, EventArgs e)
        {
            number = 17;
            tiklanan_kagit();
        }

        private  void kart19_Click(object sender, EventArgs e)
        {
            number = 18;
            tiklanan_kagit();
        }

        private  void kart20_Click(object sender, EventArgs e)
        {
            number = 19;
            tiklanan_kagit();
        }

        private  void kart21_Click(object sender, EventArgs e)
        {
            number = 20;
            tiklanan_kagit();
        }

        private  void kart22_Click(object sender, EventArgs e)
        {
            number = 21;
            tiklanan_kagit();
        }

        private  void kart23_Click(object sender, EventArgs e)
        {
            number = 22;
            tiklanan_kagit();
        }

        private  void kart24_Click(object sender, EventArgs e)
        {
            number = 23;
            tiklanan_kagit();
        }

    }
}

