using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        private BindingSource showProductList;
        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[]
            {
                "Beverages", "Bread/Bakery", "Canned/Jarred Goods", "Dairy", "Frozen Goods", "Meat", "Personal Care", "Others"
            };
           
            foreach (string Category in ListOfProductCategory)
            {
                cbCategory.Items.Add(Category);
            }

        }

        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    throw new Exception("Invalid product name");
                }
                return name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return string.Empty; 
            }
        }

        public int Quantity(string qty)
        {
            try
            {
                if (!Regex.IsMatch(qty, @"^[0-9]"))
                {
                    throw new Exception("Invalid quantity");
                }
                return Convert.ToInt32(qty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return 0; 
            }
        }

        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    throw new Exception("Invalid selling price");
                }
                return Convert.ToDouble(price);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return 0.0; 
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
