using Amerikan_Araba_Galerisi.BL;
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
    public partial class Arabalar : Form
    {
        public Arabalar()
        {
            InitializeComponent();
        }

        private void btnArabaEkle_Click(object sender, EventArgs e)
        {
            FrmAraba frm = new FrmAraba()
            {
                Text = "Araba Ekle",
                Araba = new Araba() { ID = Guid.NewGuid() },

            };
        tekrar:
            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.ArabaEkle(frm.Araba);

                if (b)
                {
                    DataSet ds = BLogic.ArabaGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;
            }
        }



        private void btnArabaDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];

            FrmAraba frmAraba = new FrmAraba()
            {
                Text = "Araba Güncelle",
                Guncelleme = true,
                Araba = new Araba()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Marka = row.Cells[1].Value.ToString(),
                    Fiyat = double.Parse(row.Cells[2].Value.ToString()),
                    Adet = double.Parse(row.Cells[4].Value.ToString()),
                    Detay = row.Cells[3].Value.ToString(),
                },
            };

            var sonuc = frmAraba.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.ArabaGüncelle(frmAraba.Araba);

                if (b)
                {
                    row.Cells[1].Value = frmAraba.Araba.Marka;
                    row.Cells[2].Value = frmAraba.Araba.Fiyat;
                    row.Cells[4].Value = frmAraba.Araba.Adet;
                    row.Cells[3].Value = frmAraba.Araba.Detay;
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.ArabaGetir(search.Text);
            if (ds != null)
                dataGridView2.DataSource = ds.Tables[0];
        }

        private void btnArabaSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();


            var sonuc = MessageBox.Show("Seçili Kayıt silinsin mi?", "Silmeyi Onayla",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.ArabaSil(ID);

                if (b)
                {
                    DataSet ds = BLogic.ArabaGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }
            }
        }

        private void Arabalar_Load(object sender, EventArgs e)
        {
            DataSet ds2 = BLogic.ArabaGetir("");
            if (ds2 != null)
                dataGridView2.DataSource = ds2.Tables[0];
        }

        public Araba Araba { get; set; }
        private void btnTamam_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];

                Araba = new Araba()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Marka = row.Cells[1].Value.ToString(),
                    Fiyat = double.Parse(row.Cells[2].Value.ToString()),
                    Detay = row.Cells[3].Value.ToString(),
                    Adet = double.Parse(row.Cells[4].Value.ToString()),
                    
                };

            DialogResult = DialogResult.OK;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
