using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyBovApp;
using MyBovApp.Controls;
using MyLib;

namespace MyBovApp
{
    public partial class CatalogForm : Form
    {
        public CatalogForm()
        {
            InitializeComponent();

            MaximumSize = new Size(550, 350);
            MinimumSize = new Size(550, 350);

            var buildForm = new Catalog_BuildForm();

            foreach (var label in buildForm.Labels)
                Controls.Add(label);
            foreach (var input in buildForm.Inputs)
                Controls.Add(input);
            foreach (ListView listView in buildForm.DatabasePreview)
                Controls.Add(listView);
            
            foreach (var button in buildForm.Buttons)
            {
                if (button.Text == "Confirm")
                    button.Click += (s, e) =>
                    {
                        bool inputsFilled = true;

                        foreach (var input in buildForm.Inputs)
                            if (input.Text == "" || buildForm.Quantity.Value < 1)
                                inputsFilled = false;

                        if (inputsFilled)
                        {
                            this.Hide();
                            Program.order.AddBike(new Bike(buildForm.Inputs[0].Text, buildForm.Inputs[1].Text, Convert.ToInt32(buildForm.Inputs[2].Text), Convert.ToInt32(buildForm.Quantity.Value)));
                            //Program.order.Display();
                            var mainForm = new MainForm();
                            mainForm.ShowDialog();
                            this.Close();
                        }
                        else
                            MessageBox.Show("Fill all fields !");
                    };
                else if (button.Text == "Back")
                {
                    button.Click += (s, e) =>
                    {
                        this.Hide();
                        var mainForm = new MainForm();
                        mainForm.ShowDialog();
                        this.Close();
                    };
                }

                Controls.Add(button);
            }

            Controls.Add(buildForm.Quantity);


        }
    }
}
