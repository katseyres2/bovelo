using MyLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBovApp.Controls
{
    public class Catalog_BuildForm : MainForm
    {
        public List<Label> Labels { get; set; }
        public List<ComboBox> Inputs { get; set; }
        public List<Button> Buttons { get; set; }
        public List<ListView> DatabasePreview { get; set; }
        public NumericUpDown Quantity { get; set; }

        public Catalog_BuildForm()
        {
            Labels = BuildLabels();
            Inputs = BuildInputs();
            Buttons = BuildButtons();
            DatabasePreview = BuildDatabasePreview();
        }

        private List<Label> BuildLabels()
        {
            var whatAPub = new Label();
            whatAPub.Location = new Point(350, 20);
            whatAPub.Text = "CUSTOM IT";

            var myModelLabel = new Label();
            myModelLabel.Location = new Point(350, 50);
            myModelLabel.Text = "Model";

            var myColorLabel = new Label();
            myColorLabel.Location = new Point(350, 110);
            myColorLabel.Text = "Color";

            var mySizeLabel = new Label();
            mySizeLabel.Location = new Point(350, 170);
            mySizeLabel.Text = "Size";

            var myQuantityLabel = new Label();
            myQuantityLabel.Location = new Point(350, 230);
            myQuantityLabel.Text = "Quantity";

            var myLabels = new List<Label>()
            {
                whatAPub,
                myModelLabel,
                myColorLabel,
                mySizeLabel,
                myQuantityLabel
            };

            return myLabels;
        }
    
        private List<ComboBox> BuildInputs()
        {
            DataTable db = DatabaseManager.TableModelBike.Download();
            List<string> models = new List<string>() { };

            foreach (DataRow row in db.Rows)
            {
                if ((int)row["size"] == 1)
                    models.Add((string)row["name"]);
            }

            var myModelInput = new ComboBox();
            myModelInput.Location = new Point(350, 75);
            myModelInput.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (string model in models)
                myModelInput.Items.Add(model);

            var myColorInput = new ComboBox();
            myColorInput.Location = new Point(350, 135);
            myColorInput.DropDownStyle = ComboBoxStyle.DropDownList;
            List<string> colors = new List<string>()
            {
                "black",
                "white",
                "purple"
            };
            foreach (string color in colors)
                myColorInput.Items.Add(color);

            var mySizeInput = new ComboBox();
            mySizeInput.Location = new Point(350, 195);
            mySizeInput.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (DataRow row in db.Rows)
            {
                if ((string)row["name"] == "city")
                    mySizeInput.Items.Add(row["size"]);
            }

            var myQuantityInput = new NumericUpDown();
            myQuantityInput.Value = 0;
            myQuantityInput.Location = new Point(350, 255);
            myQuantityInput.Maximum = 100;
            Quantity = myQuantityInput;

            var myInputs = new List<ComboBox>()
            {
                myModelInput,
                myColorInput,
                mySizeInput,
            };

            return myInputs;
        }
    
        private List<Button> BuildButtons()
        {
            var submitButton = new Button();
            submitButton.Location = new Point(100, 260);
            submitButton.Text = "Confirm";

            var cancelButton = new Button();
            cancelButton.Location = new Point(10, 260);
            cancelButton.Text = "Back";

            var buttons = new List<Button>()
            {
                submitButton,
                cancelButton
            };

            return buttons;
        }
    
        private List<ListView> BuildDatabasePreview()
        {
            var modelView = new ListView();
            modelView.Bounds = new Rectangle(new Point(10, 10), new Size(100, 200));
            modelView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            modelView.View = View.Details;
            modelView.LabelEdit = false;
            modelView.Scrollable = false;

            modelView.Columns.Add("Model", -2);

            DataTable dataTableModels = DatabaseManager.TableModelBike.Download();

            foreach (DataRow row in dataTableModels.Rows)
                if ((int)row["size"] == 1)
                    modelView.Items.Add(new ListViewItem((string)row["name"]));

            /*-------------------------------------------------------------------*/

            var colorView = new ListView();
            colorView.Bounds = new Rectangle(new Point(120, 10), new Size(100, 200));
            colorView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            colorView.View = View.Details;
            colorView.Scrollable = false;
            colorView.LabelEdit = false;

            colorView.Columns.Add("Color", -2);

            var color_02 = new ListViewItem("white");
            var color_01 = new ListViewItem("black");
            var color_03 = new ListViewItem("purple");

            colorView.Items.AddRange(new ListViewItem[] { color_01, color_02, color_03 });

            /*-------------------------------------------------------------------*/

            var sizeView = new ListView();
            sizeView.Bounds = new Rectangle(new Point(230, 10), new Size(100, 200));
            sizeView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            sizeView.View = View.Details;
            sizeView.Scrollable = false;
            sizeView.LabelEdit = false;

            sizeView.Columns.Add("Size", -2);

            DataTable db = DatabaseManager.TableModelBike.Download();
            foreach (DataRow row in db.Rows)
            {
                if ((string)row["name"] == "city")
                    sizeView.Items.Add(new ListViewItem(row["size"].ToString()));
            }

            /*-------------------------------------------------------------------*/

            var listViews = new List<ListView>()
            {
                modelView,
                colorView,
                sizeView
            };

            return listViews;
        }
    }
}
