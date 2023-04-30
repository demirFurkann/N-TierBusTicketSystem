using Project.BLL.Repositories.ConcRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WFAUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _customRep = new CustomerRepository();
            _prodRepository = new ProductRepository();
            _empRep = new EmployeeRepository();
            _ordRep = new OrderRepository();
        }
        CustomerRepository _customRep;
        EmployeeRepository _empRep;
        ProductRepository _prodRepository;
        OrderRepository _ordRep;

        private void btnMusteriKayit_Click(object sender, EventArgs e)
        {
            try
            {
                Customer c = new Customer();
                c.FirstName = txtIsim.Text;
                c.LastName = txtSoyIsim.Text;
                c.TckNo = mskTc.Text;
                c.Email = txtEmail.Text;
                c.PhoneNo = mskTel.Text;
                c.Gender = comboBox1.Text;




                _customRep.Add(c);
                MessageBox.Show("Yolcu Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btnKaptanKaydet_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.EmployeeNo = txtKaptanNo.Text;
            emp.FullName = txtKaptanAdSoyad.Text;
            emp.Number = txtKaptanNo.Text;

            _empRep.Add(emp);

            MessageBox.Show("Kaptan Bilgileri Sisteme Kaydedildi...");

        }

        private void btnSeferKayit_Click(object sender, EventArgs e)
        {
            Product p = new Product();

            p.JourneyNo = txtSeferNo.Text;
            p.Departure = txtKalkis.Text;
            p.Arrival = txtVaris.Text;
            p.Hour = mskSaat.Text;
            p.Date = mskTarih.Text;
            p.Captain = txtKaptan.Text;
            p.UnitPrice = Convert.ToDecimal(txtFiyat.Text);

            _prodRepository.Add(p);

            MessageBox.Show("Sefer Kaydı Açıldı...");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SeferListele();
        }
        List<Product> SeferListele()
        {
            return _prodRepository.GetAll();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtRezervasyonSeferNo.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();


        }
        Button _secilenButton; Color originalColor; bool isButtonClicked = false;
        private void btn1_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = (sender as Button).Text;
            _secilenButton = (Button)sender;

            Button clickedButton = (Button)sender;
            originalColor = clickedButton.BackColor;

            if (isButtonClicked)
            {
                clickedButton.BackColor = originalColor;
            }
            else
            {
                clickedButton.BackColor = Color.Gray;
            }

            isButtonClicked = !isButtonClicked;
        }

        Product _secilenProductNo;
        private void btnRezervasyonYap_Click(object sender, EventArgs e)
        {
            Order ord = new Order();
            ord.TicketNo = txtRezervasyonSeferNo.Text;
            ord.SeatNumber = txtKoltukNo.Text;

            Customer existingCustomer = _customRep.FirstOrDefault(c => c.TckNo == mskRezervasyonTc.Text);
            if (existingCustomer != null)
            {
                ord.Customer = existingCustomer;
            }
            else
            {
                ord.Customer = new Customer { TckNo = mskRezervasyonTc.Text };
            }

            if (txtKoltukNo.Text != null)
            {
                _secilenButton.BackColor = Color.Red;
            }

            _ordRep.Add(ord);









        }


    }
}
