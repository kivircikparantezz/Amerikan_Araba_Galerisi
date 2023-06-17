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
    public partial class FrmAraba : Form
    {
        public FrmAraba()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Araba Araba { get; set; }

        public bool Guncelleme { get; set; } = false;

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(txtMarka)) return;
            if (!ErrorControl(nmFiyat)) return;
            if (!ErrorControl(nmAdet)) return;
            if (!ErrorControl(txtDetay)) return;
            DialogResult = DialogResult.OK;

            Araba.Marka = txtMarka.Text;
            Araba.Fiyat = (double)nmFiyat.Value;
            Araba.Adet = (double)nmAdet.Value;
            Araba.Detay = txtDetay.Text;
        }

        private bool ErrorControl(Control c)
        {
            if (c is TextBox)
            {
                if (c.Text == "")
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

            if (c is NumericUpDown)
            {
                if (((NumericUpDown)c).Value == 0)
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

        private void FrmAraba_Load(object sender, EventArgs e)
        {
            txtID.Text = Araba.ID.ToString();
            if (Guncelleme)
            {
                txtMarka.Text = Araba.Marka;
                nmFiyat.Value = (decimal)Araba.Fiyat;
                nmAdet.Value = (decimal)Araba.Adet;
                txtDetay.Text = Araba.Detay;
            }
        }
    }
}
