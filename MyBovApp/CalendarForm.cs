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
    public partial class CalendarForm : Form
    {
        public CalendarForm()
        {
            InitializeComponent();

            MaximumSize = new Size(800, 500);
            MinimumSize = new Size(800, 500);

            DataTable tableBike = DatabaseManager.TableBike.Download();
            DataTable tableCustomer = DatabaseManager.TableCustomer.Download();
            DataTable tableEmployee = DatabaseManager.TableEmployee.Download();
            var buildForm = new Calendar_BuildForm();

            buildForm.MonthCalendar.DateSelected += (s, e) =>
            {
                buildForm.TextBoxes[0].Text = "";
                buildForm.Labels[0].Text = e.Start.ToShortDateString();

                foreach (DataRow dataRow in tableBike.Rows)
                {
                    Console.Out.WriteLine($"{dataRow["model"]} {dataRow["assemblingdate"]}");
                    if (!dataRow["assemblingdate"].Equals(System.DBNull.Value))
                        if (Convert.ToDateTime(dataRow["assemblingdate"]).ToString("yyyy-MM-dd") == e.Start.ToString("yyyy-MM-dd"))
                            buildForm.TextBoxes[0].Text += $"[{dataRow["id"]}] model : {dataRow["model"]}, maker : {dataRow["employee"]}\r\n";
                }
            };

            buildForm.Buttons[0].Click += (s, e) =>
            {
                this.Hide();
                var mainForm = new MainForm();
                mainForm.ShowDialog();
                this.Close();
            };

            buildForm.Buttons[1].Click += (s, e) =>
            {
                if (buildForm.TextBoxes[1].Text == "")
                    MessageBox.Show("Enter an ID !");
                else
                {
                    foreach (DataRow rowBike in tableBike.Rows)
                        if ((int)rowBike["id"] == Convert.ToInt32(buildForm.TextBoxes[1].Text))
                            foreach (DataRow rowCustomer in tableCustomer.Rows)
                                if ((int)rowBike["idcustomer"] == (int)rowCustomer["id"])
                                    buildForm.Labels[2].Text = $"Result\n\r - Id : {rowBike["id"]}\r\n - Model : {rowBike["model"]}\n\r - Creation date : {Convert.ToDateTime(rowBike["creationdate"]).ToString("yyyy-MM-dd")}\r\n - Assembling date : {Convert.ToDateTime(rowBike["assemblingdate"]).ToString("yyyy-MM-dd")}\r\n - Customer : {rowCustomer["firstname"]} {rowCustomer["lastname"]}\r\n - Maker : {rowBike["employee"]}";

                    if (buildForm.Labels[2].Text == "Result")
                        MessageBox.Show("This ID doesn't exist !");
                }
            };

            buildForm.Buttons[2].Click += (s, e) =>
            {
                if (buildForm.ComboBox.Text.Length != 0)
                    try
                    {
                        DatabaseManager.TableBike.Update("bike_employee", $"'{buildForm.ComboBox.Text}'", Convert.ToInt32(buildForm.TextBoxes[1].Text));
                        MessageBox.Show("Maker added !");
                        this.Hide();
                        var calendarForm = new CalendarForm();
                        calendarForm.ShowDialog();
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Search an ID first !");
                    }
                else
                    MessageBox.Show("Chosse a maker !");
            };


            foreach (DataRow rowEmployee in tableEmployee.Rows)
                if ((string)rowEmployee["status"] == "maker")
                    buildForm.ComboBox.Items.Add($"{rowEmployee["firstname"]} {rowEmployee["lastname"]}");

            foreach (Label label in buildForm.Labels)
                Controls.Add(label);
            foreach (Button button in buildForm.Buttons)
                Controls.Add(button);
            foreach (TextBox textBox in buildForm.TextBoxes)
                Controls.Add(textBox);

            Controls.Add(buildForm.ComboBox);
            Controls.Add(buildForm.MonthCalendar);
        }
    }
}
