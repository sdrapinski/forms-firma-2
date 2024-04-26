using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Runtime.Remoting.Contexts;

namespace firma
{
    public partial class Form1 : Form
    {
      
        static string conectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Student\Desktop\firma-windows-form-master\firma\firma.mdf;Connect Timeout=30";
        static DataContext bazaDanychFirma = new DataContext(conectionString);

        static Table<FakturaSprzedazy> listaFaktur = bazaDanychFirma.GetTable<FakturaSprzedazy>();
        static Table<Pracownik> listaPracowników = bazaDanychFirma.GetTable<Pracownik>();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lp = from Pracownik in listaPracowników
                     orderby Pracownik.Nazwisko
                     select new
                     {
                         Pracownik.Id,
                         Pracownik.Nazwisko,
                         Pracownik.Imie,
                         Pracownik.Telefon,
                         Pracownik.Email,

                     };
            dataGridView1.DataSource = lp;
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int noweId = listaPracowników.Max(Pracownik => Pracownik.Id) + 1; 
            Pracownik nowyPracownik = new Pracownik
            {
                Id = noweId,
                Imie = "Piotr",
                Nazwisko = "Adamek",
                Email = "P.asa@ads.pl",
                Telefon = "299-300-123",
            };
            listaPracowników.InsertOnSubmit(nowyPracownik);
            bazaDanychFirma.SubmitChanges();
            listaToolStripMenuItem_Click(this, null);
        }

        private void usuniecieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int wiersz = dataGridView1.CurrentRow.Index;
            int idPracownika =int.Parse( dataGridView1.Rows[wiersz].Cells[0].Value.ToString());
            IEnumerable<Pracownik> doSkasowoania = from Pracownik in listaPracowników select Pracownik;
            listaPracowników.DeleteAllOnSubmit(doSkasowoania);
            bazaDanychFirma.SubmitChanges();
            listaToolStripMenuItem_Click(this, null);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int wiersz = dataGridView1.CurrentRow.Index;
            textBoxImie.Text = dataGridView1.Rows[wiersz].Cells[1].Value.ToString();
            textBoxNazwisko.Text = dataGridView1.Rows[wiersz].Cells[2].Value.ToString();
            textBoxEmail.Text = dataGridView1.Rows[wiersz].Cells[3].Value.ToString();
            textBoxTelefon.Text = dataGridView1.Rows[wiersz].Cells[4].Value.ToString();
        }
    }
}
