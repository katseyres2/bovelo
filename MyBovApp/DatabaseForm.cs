using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBovApp
{
    public partial class DatabaseForm : Form
    {
        public DatabaseForm()
        {
            InitializeComponent();

            var button = new Button();
            button.Text = "back";
            button.Click += (s, e) =>
            {
                this.Hide();
                var mainForm = new MainForm();
                mainForm.ShowDialog();
                this.Close();
            };

            Controls.Add(button);
        }
    }
}
