using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace testowyKolos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxTablesList.Items.Add("clients");
            comboBoxTablesList.Items.Add("products");
            comboBoxTablesList.Items.Add("orders");
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            using (var bazaDanych = new bazaKlientow())
            {
                string column1 = textBox1.Text.ToString();
                string column2 = textBox2.Text.ToString();
                
                string choosenOption = comboBoxTablesList.SelectedItem.ToString();
                
                switch (choosenOption)
                {
                    case "orders":
                        int id = 0;

                        try
                        {
                            id = Int32.Parse(column2);
                        }
                        catch
                        {
                            MessageBox.Show("Wpisano nieodpowiednią wartość ID");
                        }
                        
                        if ( id != 0 )
                        {
                            try
                            {
                                bazaDanych.Add(new orders() { count = column1, productId = id });
                                bazaDanych.SaveChanges();
                                MessageBox.Show("Dodano rekord");
                                clearData(sender, e);
                            }
                            catch
                            {
                                MessageBox.Show("Sprawdź czy podana wartość jest prawidłowa");
                            }
                        }
                        break;
                    case "products":
                        try
                        {
                            bazaDanych.Add(new products() {  name = column1, price = column2 });
                            bazaDanych.SaveChanges();
                            MessageBox.Show("Dodano rekord");
                            clearData(sender, e);
                        }
                        catch 
                        {
                            MessageBox.Show("Wystąpił błąd");
                        }
                        break;
                    case "clients":
                        try
                        {
                            bazaDanych.Add(new clients() {  name = column1, email = column2});
                            bazaDanych.SaveChanges();
                            MessageBox.Show("Dodano rekord");
                            clearData(sender, e);
                            
                        }
                        catch 
                        {
                            MessageBox.Show("Wystąpił błąd");
                        }
                        break;
                    default:
                        MessageBox.Show("Nie wybrano odpowiedniej wartości.");
                        break;
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            clearData(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void comboBoxTablesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            
            string choosenOption = comboBoxTablesList.SelectedItem.ToString();
            Console.WriteLine(choosenOption);
            using (var strukturaDanych = new bazaKlientow())
            {
                switch (choosenOption)
                {
                    case "orders":
                        dataGridView1.Columns.Add("count", "Ilość");
                        dataGridView1.Columns.Add("productId", "Id produktu");
                        
                        label1.Text = "Ilość";
                        label2.Text = "Id produktu";

                        foreach (var order in strukturaDanych.orders)
                        {
                            dataGridView1.Rows.Add( order.count, order.productId );
                        }
                        break;
                    case "products":
                        dataGridView1.Columns.Add("name", "Nazwa");
                        dataGridView1.Columns.Add("price", "Cena produktu");
                        dataGridView1.Columns.Add("price", "id produktu (potrzebne do relacji)");
                        
                        label1.Text = "Nazwa";
                        label2.Text = "Cena produktu";

                        foreach (var product in strukturaDanych.products)
                        {
                            dataGridView1.Rows.Add( product.name, product.price, product.productId );
                        }
                        break;
                    case "clients":
                        dataGridView1.Columns.Add("name", "Nazwa klienta");
                        dataGridView1.Columns.Add("email", "Email do kontaktu");
                        
                        label1.Text = "Nazwa klienta";
                        label2.Text = "Email do kontaktu";

                        foreach (var client in strukturaDanych.clients)
                        {
                            dataGridView1.Rows.Add( client.name, client.email );
                        }
                        break;
                }
            }
        }

        private void comboBoxTablesList_Click(object sender, EventArgs e)
        {
            try
            {
                string choosenOption = comboBoxTablesList.SelectedItem.ToString();
                Debug.WriteLine(choosenOption);
            }
            catch
            {
                
            }
        }

        private void comboBoxTablesList_SelectedValueChanged(object sender, EventArgs e)
        {
        }
        
        private void clearData(object sender, EventArgs e)
        {
            string[] tables = {"orders", "clients", "products"};
            string choosenOption = comboBoxTablesList.SelectedItem.ToString();
            
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            
            if (tables.Contains(choosenOption))
            {
                comboBoxTablesList_SelectedIndexChanged(sender, e);
            }
        }
    }
}
