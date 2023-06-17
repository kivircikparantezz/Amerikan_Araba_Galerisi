using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amerikan_Araba_Galerisi.UI
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Musteri Musteri { get; set; }
        public bool Güncelleme { get; set; } = false;

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if(!ErrrorControl(txtAd)) return;
            if (!ErrrorControl(txtSoyad)) return;
            if (!ErrrorControl(txtTel)) return;
            if (!ErrrorControl(txtMail)) return;
            if (!ErrrorControl(txtAdres)) return;

            Musteri.Ad = txtAd.Text;
            Musteri.Soyad = txtSoyad.Text;
            Musteri.Telefon = txtTel.Text;
            Musteri.Mail = txtMail.Text;
            Musteri.Adres = txtAdres.Text;


            DialogResult = DialogResult.OK;
        }

        

        private bool ErrrorControl(Control c)
        {
            if(c is TextBox)
            {
                if(c.Text == "")
                {
                    errorProvider1.SetError(c, "Eksik Veya Hatalı Bilgi Girdiniz");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;
                }
            }

            if (c is MaskedTextBox)
            {
                if (!((MaskedTextBox)c).MaskFull)
                {
                    errorProvider1.SetError(c, "Eksik Veya Hatalı Bilgi Girdiniz");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;
                }
            }

            return true;
        }

        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            txtID.Text = Musteri.ID.ToString();
            if (Güncelleme)
            {
                txtAd.Text = Musteri.Ad ;
                txtSoyad.Text = Musteri.Soyad;
                txtTel.Text= Musteri.Telefon ;
                txtMail.Text = Musteri.Mail ;
                txtAdres.Text = Musteri.Adres;
            }
        }
    }
}
