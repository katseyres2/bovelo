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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            MaximumSize = new Size(400, 230);
            MinimumSize = new Size(400, 230);

            var buildForm = new Main_BuildForm();

            foreach (Button button in buildForm.Buttons)
            {
                if (button.Text == "Catalog")
                    button.Click += (s, e) =>
                    {
                        this.Hide();
                        var catalogForm = new CatalogForm();
                        catalogForm.ShowDialog();
                        this.Close();
                    };
                else if (button.Text == "Order")
                    button.Click += (s, e) =>
                    {
                        this.Hide();
                        var orderForm = new OrderForm();
                        orderForm.ShowDialog();
                        this.Close();
                    };
                else if (button.Text == "Database")
                    button.Click += (s, e) =>
                    {
                        this.Hide();
                        var databaseForm = new DatabaseForm();
                        databaseForm.ShowDialog();
                        this.Close();
                    };
                else if (button.Text == "Calendar")
                    button.Click += (s, e) =>
                    {
                        this.Hide();
                        var calendarForm = new CalendarForm();
                        calendarForm.ShowDialog();
                        this.Close();
                    };
                else if (button.Text == "Close App")
                    button.Click += (s, e) => this.Close();

                Controls.Add(button);
            }
        }
    }
}
