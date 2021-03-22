using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBovApp.Controls
{
    public partial class Main_BuildForm : Form
    {
        public List<Button> Buttons { get; set; }

        public Main_BuildForm()
        {
            Buttons = BuildButtons();
        }

        private List<Button> BuildButtons()
        {
            var catalogButton = new Button();
            catalogButton.Text = "Catalog";
            catalogButton.Location = new Point(20, 10);

            var orderButton = new Button();
            orderButton.Text = "Order";
            orderButton.Location = new Point(20, 40);
            
            var databaseButton = new Button();
            databaseButton.Text = "Database";
            databaseButton.Location = new Point(20, 70);
            
            var calendarButton = new Button();
            calendarButton.Text = "Calendar";
            calendarButton.Location = new Point(20, 100);

            var exitButton = new Button();
            exitButton.Text = "Close App";
            exitButton.AutoSize = true;
            exitButton.Location = new Point(20, 130);

            var buttons = new List<Button>()
            {
                catalogButton,
                orderButton,
                databaseButton,
                calendarButton,
                exitButton
            };

            return buttons;
        }
    }
}
