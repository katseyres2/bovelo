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
    public partial class CustomerRegister_BuildForm : Form
    {
        public List<Label> Labels { get; set; }
        public List<TextBox> TextBoxes { get; set; }
        public List<Button> Buttons { get; set; }

        public CustomerRegister_BuildForm()
        {
            Labels = BuildLabels();
            TextBoxes = BuildTextBoxes();
            Buttons = BuildButtons();
        }

        public List<Label> BuildLabels()
        {
            var firstnameLabel = new Label();
            firstnameLabel.Text = "First name";
            firstnameLabel.Location = new Point(10, 10);

            var lastnameLabel = new Label();
            lastnameLabel.Text = "Last name";
            lastnameLabel.Location = new Point(10, 50);

            var emailLabel = new Label();
            emailLabel.Text = "Email Address";
            emailLabel.Location = new Point(10, 90);

            var phoneLabel = new Label();
            phoneLabel.Text = "Phone Number";
            phoneLabel.Location = new Point(10, 130);

            var countryLabel = new Label();
            countryLabel.Text = "Country";
            countryLabel.Location = new Point(10, 170);

            var zipLabel = new Label();
            zipLabel.Text = "Zip Code";
            zipLabel.Location = new Point(10, 210);

            var cityLabel = new Label();
            cityLabel.Text = "City";
            cityLabel.Location = new Point(10, 250);

            var streetLabel = new Label();
            streetLabel.Text = "Street";
            streetLabel.Location = new Point(10, 290);

            var houseLabel = new Label();
            houseLabel.Text = "House Number";
            houseLabel.Location = new Point(10, 330);

            var labels = new List<Label>()
            {
                firstnameLabel,
                lastnameLabel,
                emailLabel,
                phoneLabel,
                countryLabel,
                zipLabel,
                cityLabel,
                streetLabel,
                houseLabel
            };

            return labels;
        }
    
        public List<TextBox> BuildTextBoxes()
        {
            var firstnameInput = new TextBox();
            firstnameInput.Location = new Point(110, 10);

            var lastnameInput = new TextBox();
            lastnameInput.Location = new Point(110, 50);

            var emailInput = new TextBox();
            emailInput.Location = new Point(110, 90);

            var phoneInput = new TextBox();
            phoneInput.Location = new Point(110, 130);

            var countryInput = new TextBox();
            countryInput.Location = new Point(110, 170);

            var zipInput = new TextBox();
            zipInput.Location = new Point(110, 210);

            var cityInput = new TextBox();
            cityInput.Location = new Point(110, 250);

            var streetInput = new TextBox();
            streetInput.Location = new Point(110, 290);

            var houseInput = new TextBox();
            houseInput.Location = new Point(110, 330);

            var textBoxes = new List<TextBox>()
            {
                firstnameInput,
                lastnameInput,
                emailInput,
                phoneInput,
                countryInput,
                zipInput,
                cityInput,
                streetInput,
                houseInput
            };

            return textBoxes;
        }
    
        public List<Button> BuildButtons()
        {
            var confirmButton = new Button();
            confirmButton.Text = "Create customer !";
            confirmButton.Location = new Point(110, 370);
            confirmButton.AutoSize = true;

            var cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.Location = new Point(10, 370);

            var buttons = new List<Button>()
            {
                confirmButton,
                cancelButton
            };

            return buttons;
        }
    }
}
