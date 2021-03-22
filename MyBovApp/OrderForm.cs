using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;
using MyBovApp.Controls;

namespace MyBovApp
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();

            MaximumSize = new Size(400, 400);
            MinimumSize = new Size(400, 400);


            var buildForm = new Order_BuildForm();

            foreach (Label label in buildForm.Labels)
                Controls.Add(label);

            foreach (Button button in buildForm.Buttons)
            {
                if (button.Text == "Back")
                    button.Click += (s, e) =>
                    {
                        this.Hide();
                        var mainForm = new MainForm();
                        mainForm.ShowDialog();
                        this.Close();
                    };
                else if (button.Text == "Confirm")
                {
                    button.Click += (s, e) =>
                    {
                        if (Program.order.bikes.Count > 0)
                        {
                            this.Hide();
                            var clientForm = new CustomerForm();
                            clientForm.ShowDialog();
                            this.Close();
                        }
                        else
                            MessageBox.Show("Nothing in the order !");
                    };
                }
                else if (button.Text == "Clear order")
                    button.Click += (s, e) =>
                    {
                        Program.order.Clear();
                        this.Hide();
                        var orderForm = new OrderForm();
                        orderForm.ShowDialog();
                        this.Close();
                    };

                Controls.Add(button);
            }

            Controls.Add(buildForm.ListView);            
        }
    }
}
