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
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Satis Satis { get; set; }

        public bool Güncelleme { get; set; } = false;




        private void btnTamam_Click(object sender, EventArgs e)
        {   
            if(nmFiyat.Value == 0)
            {
                errorProvider1.SetError(nmFiyat, "Lütfen Fiyat Giriniz");
                nmFiyat.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(nmFiyat, "");
            }

            Satis.Tarih = dtpTarih.Value;
            Satis.Fiyat = (double)nmFiyat.Value;
            Satis.ArabaID = Guid.Parse( txtAraba.Text);
            Satis.MusteriID = Guid.Parse(txtMusteri.Text);

            DialogResult= DialogResult.OK;
        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {
            txtID.Text = Satis.ID.ToString();
            if (Güncelleme)
            {
                txtMusteri.Text = Satis.MusteriID.ToString();
                txtAraba.Text = Satis.ArabaID.ToString();
                nmFiyat.Value = (decimal)Satis.Fiyat;
                dtpTarih.Value = Satis.Tarih;
            }
        }

        private void btnMüşteriSeç_Click(object sender, EventArgs e)
        {
            Müşteriler frm = new Müşteriler();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                //Musteri = frm.Musteri;
                txtMusteri.Text = frm.Musteri.ID.ToString();
            }
        }

        private void btnArabaSeç_Click(object sender, EventArgs e)
        {
            Arabalar frm = new Arabalar();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Araba = frm.Araba;
                txtAraba.Text = frm.Araba.ID.ToString();
            }
        }
    }
}
