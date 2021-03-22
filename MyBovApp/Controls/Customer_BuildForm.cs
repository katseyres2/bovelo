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
    public partial class Customer_BuildForm : Form
    {
        public List<Label> Labels { get; set; }
        public List<TextBox> TextBoxes { get; set; }
        public List<Button> Buttons { get; set; }

        public Customer_BuildForm()
        {
            Labels = BuildLabels();
            TextBoxes = BuildTextBoxes();
            Buttons = BuildButtons();
        }

        public List<Label> BuildLabels()
        {
            var isCustomerLabel = new Label();
            isCustomerLabel.Text = "Are you still registered ?";
            isCustomerLabel.AutoSize = true;
            isCustomerLabel.Location = new Point(10, 10);

            var signInLabel = new Label();
            signInLabel.Text = "Search your name : ";
            signInLabel.Location = new Point(10, 150);

            var customerSearchLabel = new Label();
            customerSearchLabel.Visible = false;
            customerSearchLabel.Text = "hello !";
            customerSearchLabel.Location = new Point(10, 180);
            customerSearchLabel.AutoSize = true;

            List<Label> labels = new List<Label>()
            {
                isCustomerLabel,
                signInLabel,
                customerSearchLabel
            };

            return labels;
        }

        public List<TextBox> BuildTextBoxes()
        {
            var signInInput = new TextBox();
            signInInput.Location = new Point(130, 150);

            var allCustomersTable = new TextBox();
            allCustomersTable.Location = new Point(120, 40);
            allCustomersTable.Size = new Size(250, 100);
            allCustomersTable.Multiline = true;
            allCustomersTable.Visible = false;
            allCustomersTable.ScrollBars = ScrollBars.Vertical;

            DataTable table = DatabaseManager.TableCustomer.Download();
            foreach (DataRow row in table.Rows)
            {
                allCustomersTable.Text += $"[{row["id"]}] {row["firstname"]} {row["lastname"]}\r\n";
            }

            List<TextBox> textBoxes = new List<TextBox>()
            {
                signInInput,
                allCustomersTable
            };

            return textBoxes;
        }

        public List<Button> BuildButtons()
        {
            var signUpButton = new Button();
            signUpButton.Text = "Sign up !";
            signUpButton.Location = new Point(150, 5);
            signUpButton.AutoSize = true;

            var signInButton = new Button();
            signInButton.Text = "Select";
            signInButton.Location = new Point(240, 150);

            var allCustomersButton = new Button();
            allCustomersButton.Text = "Show all customers";
            allCustomersButton.Location = new Point(10, 40);
            allCustomersButton.AutoSize = true;

            var confirmCustomerButton = new Button();
            confirmCustomerButton.Text = "Confirm";
            confirmCustomerButton.Location = new Point(100, 210);

            var cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.Location = new Point(10, 210);

            List<Button> buttons = new List<Button>()
            {
                signUpButton,
                signInButton,
                allCustomersButton,
                confirmCustomerButton,
                cancelButton
            };

            return buttons;
        }
    }
}
