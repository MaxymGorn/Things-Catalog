using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalog
{
    public partial class Form3 : Form
    {
        private DataManager Data;
        public Form3(DataManager dataManager)
        {
            this.Data = dataManager;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        IEnumerable<Product> queryable2()
        {
            foreach (var dr in Data.Products)
            {
                if (dr.Name.Contains(textBox1.Text))
                {
                    yield return dr;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text.Length==0)
                {
                    throw new Exception();
                }
                if (queryable2().ToArray().Length > 0)
                {
                    throw new Exception();
                }
                if(comboBox1.SelectedItem==null || comboBox2.SelectedItem==null )
                {
                    throw new Exception();
                }
              
                Data.Products.Add(new Product() { Name = textBox1.Text, Cost = numericUpDown1.Value, 
                    Count = int.Parse(numericUpDown2.Value.ToString()), CategoryId = comboBox1.SelectedIndex, ProducerId=comboBox2.SelectedIndex });
                Data.SaveChanges();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (var el in Data.Categories)
            {
                comboBox1.Items.Add(el.Name);
            }
            foreach (var el in Data.Producers)
            {
                comboBox2.Items.Add(el.Name);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
