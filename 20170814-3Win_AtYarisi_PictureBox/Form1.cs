using System;
using System.Media;
using System.Windows.Forms;

namespace _20170814_3Win_AtYarisi_PictureBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
             
            AtDurumDegistir(false);

            //lblFinish.AutoSize = false;
            //lblFinish.BackColor = Color.Yellow;
        }

        /*
         * Eğer ses çalmak istersek using System.Media; kütüphanesini eklememiz gerekiyor.
         * kütüphane içerisindeki SoundPlayer classı kullanılarak çalınacak olan ses dosyası yolu verilir. sonrasında play metotu ile ses çalınır.
         */

        Random r = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            pcAt1.Left += r.Next(1,10);
            pcAt2.Left += r.Next(1, 10);
            pcAt3.Left += r.Next(1, 10);
            pcAt4.Left += r.Next(1, 10);
            pcAt5.Left += r.Next(1, 10);

            AtKontrol(pcAt1);
            AtKontrol(pcAt2);
            AtKontrol(pcAt3);
            AtKontrol(pcAt4);
            AtKontrol(pcAt5);
        }

       void AtKontrol(PictureBox at)
        {
            if (at.Right > lblFinish.Left)
            {
                timer1.Stop();
                AtDurumDegistir(false);
                at.Enabled = true;
                ses.Stop();
                MessageBox.Show(at.Name +" Kazandı !");
            }
        }

        void AtDurumDegistir(bool durum)
        {
            pcAt1.Enabled = pcAt2.Enabled = pcAt3.Enabled = pcAt4.Enabled = pcAt5.Enabled = durum;
        }

        SoundPlayer ses = new SoundPlayer();
        private void yarışıBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            ses.SoundLocation = "kosuses.wav";
            ses.Play();
            AtDurumDegistir(true);
        }

        private void yenidenBaşlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ses.Stop();
            timer1.Enabled = false;
            AtDurumDegistir(false);
            pcAt1.Left = pcAt2.Left = pcAt3.Left = pcAt4.Left = pcAt5.Left = 12;
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkimizda h = new Hakkimizda();
            h.ShowDialog();
        }
    }
}
