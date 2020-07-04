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
    public partial class Form2 : Form
    {
        private  DataManager Data;
        public Form2(DataManager dataManager, string str)
        {
            Data = dataManager;
          
            InitializeComponent();
            label1.Text = str;
        }
        IEnumerable<Category> queryable()
        {
            foreach (var dr in Data.Categories)
            {
                if (dr.Name.Contains(textBox1.Text))
                {
                    yield return dr;
                }
            }
        }
        IEnumerable<Producer> queryable2()
        {
            foreach (var dr in Data.Producers)
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
            
               
                if (textBox1.Text.Length==0)
                {
                    throw new Exception("Please enter text");
                }
                if ((label1.Text== "Введите название категории") ? queryable().ToArray().Length > 0 : queryable2().ToArray().Length > 0 )
                {
                    throw new Exception("Is exist");
                }
                if (label1.Text == "Введите название категории")
                {
                    Data.Categories.Add(new Category() { Name = textBox1.Text });
                }  else
                {
                    Data.Producers.Add(new Producer() { Name = textBox1.Text });
                }
                Data.SaveChanges();
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message,"Eror", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
