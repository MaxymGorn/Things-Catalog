using Catalog.Migrations;
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
    public partial class Form1 : Form
    {
        DataManager dataManager;
        public Form1()
        {
            InitializeComponent();
            dataManager = new DataManager();
            Init();
            numericUpDown1.Maximum = 100000;
        }
        private void Init()
        {
            //Random r = new Random();
            //for(int i=0; i < 10; i++)
            //{
            //    dataManager.Categories.Add(new Category() { Name = $"{i}-pr" });
            //    dataManager.Producers.Add(new Producer() { Name=$"{i}-producers"});
            //    dataManager.Products.Add(new Product() { 
            //        Name=$"{i}-product",
            //        Cost=r.Next(1000,100000),
            //        Count=r.Next(0,1000),
            //        CategoryId=i+1,
            //        ProducerId=i+1 }
            //    );
            //}
            dataManager.SaveChanges();
            listView1.Items.Clear();
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            comboBox1.Items.Add("All");
            comboBox3.Items.Add("All");
            foreach (var el in dataManager.Categories)
            {
                comboBox1.Items.Add(el.Name);
            }
            foreach(var el in dataManager.Producers)
            {
                comboBox3.Items.Add(el.Name);
            }
            foreach(var el in dataManager.Products)
            {
                var item = listView1.Items.Add(el.Id.ToString());
                item.SubItems.Add(el.Name.ToString());
                item.SubItems.Add(GetCatId( el.CategoryId));
                item.SubItems.Add(GetPrId(el.CategoryId));
                item.SubItems.Add(el.Cost.ToString());
                item.SubItems.Add(el.Count.ToString());
            }
            if(comboBox1.Items.Count>0)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
            }
        
        }
        string? GetCatId(int id)
        {
            return comboBox1?.Items[id+1]?.ToString();   
            return null;
        }
        string? GetPrId(int id)
        {
            return comboBox3?.Items[id+1]?.ToString();
            return null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var good= dataManager.Products.ToList();
            
            try
            {
                if (comboBox1.SelectedIndex != 0) {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                good = good.Where(p => comboBox1.Text == GetCatId(p.Id)).ToList();

            }
            finally
            {
                try
                {
                    if (comboBox3.SelectedIndex != 0)
                    {
                        throw new Exception();
                    }
                 
                }
                catch (Exception)
                {
                    good = good.Where(p => comboBox3.Text == GetPrId(p.Id)).ToList();

                }
                finally
                {
                    try
                    {
                        if (numericUpDown1.Value != 0)
                        {
                            throw new Exception();
                        }

                    }
                    catch (Exception)
                    {
                        good = good.Where(p => numericUpDown1.Value <p.Cost).ToList();

                    }
                }
                listView1.Items.Clear();
                foreach (var el in good)
                {
                    var item = listView1.Items.Add(el.Id.ToString());
                    item.SubItems.Add(el.Name.ToString());
                    item.SubItems.Add(GetCatId(el.CategoryId));
                    item.SubItems.Add(GetPrId(el.CategoryId));
                    item.SubItems.Add(el.Cost.ToString());
                    item.SubItems.Add(el.Count.ToString());
                }

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dataManager, "Введите название категории");
           
            if (DialogResult.OK == form2.ShowDialog())
            {
                Init();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dataManager, "Введите название производителя");

            if (DialogResult.OK == form2.ShowDialog())
            {
                Init();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataManager.Categories.Remove( dataManager.Categories.ToList()[comboBox1.SelectedIndex-1]);
            dataManager.SaveChanges();
            Init();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataManager.Producers.Remove(dataManager.Producers.ToList()[comboBox3.SelectedIndex - 1]);
            dataManager.SaveChanges();
            Init();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int selected = listView1.SelectedIndices[0]; 
            dataManager.Products.Remove(dataManager.Products.ToList()[selected]);
            dataManager.SaveChanges();
            Init();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(dataManager);

            if (DialogResult.OK == form3.ShowDialog())
            {
                Init();
            }
           
        }
    }
}
