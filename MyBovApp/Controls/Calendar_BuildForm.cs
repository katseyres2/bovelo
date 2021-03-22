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
    public partial class Calendar_BuildForm : Form
    {
        public List<Label> Labels { get; set; }
        public List<Button> Buttons { get; set; }
        public List<TextBox> TextBoxes { get; set; }
        public MonthCalendar MonthCalendar { get; set; }
        public ComboBox ComboBox { get; set; }

        public Calendar_BuildForm()
        {
            Labels = BuildLabels();
            Buttons = BuildButtons();
            TextBoxes = BuildTextBox();
            MonthCalendar = BuildCalendar();
            ComboBox = BuildComboBox();
        }

        private List<Label> BuildLabels()
        {
            var dateSelectedLabel = new Label();
            dateSelectedLabel.Text = "No date selected";
            dateSelectedLabel.Location = new Point(40, 220);

            var searchBikeWithoutDateLabel = new Label();
            searchBikeWithoutDateLabel.Text = "Search a bike [with the ID]";
            searchBikeWithoutDateLabel.AutoSize = true;
            searchBikeWithoutDateLabel.Location = new Point(300, 40);

            var resultSearchLabel = new Label();
            resultSearchLabel.Text = "Result";
            resultSearchLabel.Location = new Point(300, 90);
            resultSearchLabel.AutoSize = true;

            var addMakerLabel = new Label();
            addMakerLabel.Text = "Add a maker";
            addMakerLabel.Location = new Point(530, 40);

            var labels = new List<Label>()
            {
                dateSelectedLabel,
                searchBikeWithoutDateLabel,
                resultSearchLabel,
                addMakerLabel
            };

            return labels;
        }

        private List<Button> BuildButtons()
        {
            var backButton = new Button();
            backButton.Text = "Back";
            backButton.Location = new Point(40, 380);

            var searchButton = new Button();
            searchButton.Text = "Search";
            searchButton.Location = new Point(410, 59);

            var addMakerToBike = new Button();
            addMakerToBike.Text = "Confirm";
            addMakerToBike.Location = new Point(670, 69);

            var buttons = new List<Button>()
            {
                backButton,
                searchButton,
                addMakerToBike
            };

            return buttons;
        }

        private List<TextBox> BuildTextBox()
        {
            DataTable tableBike = DatabaseManager.TableBike.Download();
            DataTable tableCustomer = DatabaseManager.TableCustomer.Download();

            var dailyBikesTextBox = new TextBox();
            dailyBikesTextBox.Location = new Point(40, 250);
            dailyBikesTextBox.Size = new Size(600, 110);
            dailyBikesTextBox.Multiline = true;
            dailyBikesTextBox.ScrollBars = ScrollBars.Vertical;
            dailyBikesTextBox.ReadOnly = true;

            var searchBikeByIdTextBox = new TextBox();
            searchBikeByIdTextBox.ScrollBars = ScrollBars.None;
            searchBikeByIdTextBox.Location = new Point(300, 60);

            var textBoxes = new List<TextBox>()
            {
                dailyBikesTextBox,
                searchBikeByIdTextBox
            };

            return textBoxes;
        }

        private MonthCalendar BuildCalendar()
        {
            var monthCalendar = new MonthCalendar();
            monthCalendar.FirstDayOfWeek = Day.Monday;
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Location = new Point(40, 40);

            return monthCalendar;
        }

        private ComboBox BuildComboBox()
        {
            DataTable tableEmployee = DatabaseManager.TableEmployee.Download();

            var makerComboBox = new ComboBox();
            makerComboBox.Location = new Point(530, 70);
            makerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            return makerComboBox;
        }
    }
}
