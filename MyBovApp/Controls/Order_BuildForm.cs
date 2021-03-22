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

namespace MyBovApp.Controls
{
    public partial class Order_BuildForm : Form
    {
        public List<Label> Labels { get; set; }
        public ListView ListView { get; set; }
        public List<Button> Buttons { get; set; }

        public Order_BuildForm()
        {
            Labels = BuildLabels();
            ListView = BuildListView();
            Buttons = BuildButtons();
        }

        private List<Label> BuildLabels()
        {
            var orderLabel = new Label();
            orderLabel.Location = new Point(10, 10);
            orderLabel.Text = "Order :";

            var labels = new List<Label>()
            {
                orderLabel
            };

            return labels;
        }

        private ListView BuildListView()
        {
            var orderBikes = new ListView();
            orderBikes.Bounds = new Rectangle(new Point(10, 40), new Size(240, 200));
            orderBikes.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            orderBikes.View = View.Details;
            orderBikes.LabelEdit = false;

            orderBikes.Columns.Add("Model");
            orderBikes.Columns.Add("Size");
            orderBikes.Columns.Add("Color");
            orderBikes.Columns.Add("Quantity");

            foreach (Bike bike in Program.order.bikes)
            {
                var lvi = new ListViewItem();
                lvi.Text = bike.Model;
                lvi.SubItems.Add(Convert.ToString(bike.Size));
                lvi.SubItems.Add(bike.Color);
                lvi.SubItems.Add(Convert.ToString(bike.Quantity));
                orderBikes.Items.Add(lvi);
            }

            return orderBikes;
        }

        private List<Button> BuildButtons()
        {
            var cancelButton = new Button();
            cancelButton.Text = "Back";
            cancelButton.Location = new Point(10, 270);

            var confirmOrderButton = new Button();
            confirmOrderButton.Text = "Confirm";
            confirmOrderButton.Location = new Point(100, 270);

            var clearOrderButton = new Button();
            clearOrderButton.Text = "Clear order";
            clearOrderButton.Location = new Point(190, 270);

            var buttons = new List<Button>()
            {
                cancelButton,
                confirmOrderButton,
                clearOrderButton
            };

            return buttons;
        }
    }
}
