using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyBovApp.Controls;
using MyLib;

namespace MyBovApp
{
    public partial class CustomerRegisterForm : Form
    {
        public CustomerRegisterForm()
        {
            InitializeComponent();

            MaximumSize = new Size(350, 450);
            MinimumSize = new Size(350, 450);

            var buildForm = new CustomerRegister_BuildForm();

            foreach (Label label in buildForm.Labels)
                Controls.AddRange(new Label[] { label });
            foreach (TextBox textBox in buildForm.TextBoxes)
                Controls.AddRange(new TextBox[] { textBox });
            
            foreach (Button button in buildForm.Buttons)
            {
                Controls.AddRange(new Button[] { button });
                
                if (button.Text == "Create customer !")
                    button.Click += (s, e) =>
                    {
                        bool isFilled = true;

                        foreach (TextBox textBox in buildForm.TextBoxes)
                            if (textBox.Text == "")
                                isFilled = false;
                                
                        if (isFilled)
                        {
                            List<TextBox> data = buildForm.TextBoxes;
                            DatabaseManager.TableCustomer.Create(data[0].Text, data[1].Text, data[2].Text, data[3].Text, data[4].Text, Convert.ToInt32(data[5].Text), data[6].Text, data[7].Text, Convert.ToInt32(data[8].Text));
                            this.Hide();
                            var customerForm = new CustomerForm();
                            customerForm.ShowDialog();
                            this.Close();
                        }
                        else
                            MessageBox.Show("Fill all fields !");
                    };
                
                if (button.Text == "Cancel")
                {
                    button.Click += (s, e) =>
                    {
                        this.Hide();
                        var customerForm = new CustomerForm();
                        customerForm.ShowDialog();
                        this.Close();
                    };
                }
                
            }
        }
    }
}
