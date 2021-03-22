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
using System.Globalization;

namespace MyBovApp
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();

            MaximumSize = new Size(400, 300);
            MinimumSize = new Size(400, 300);

            var buildForm = new Customer_BuildForm();

            foreach (Button button in buildForm.Buttons)
            {
                if (button.Text == "Sign up !")
                {
                    button.Click += (s, e) =>
                    {
                        this.Hide();
                        var customerRegisterForm = new CustomerRegisterForm();
                        customerRegisterForm.ShowDialog();
                        this.Close();
                    };
                }
                else if (button.Text == "Show all customers")
                    button.Click += (s, e) => buildForm.TextBoxes[1].Visible = true;
                else if (button.Text == "Select")
                {
                    button.Click += (s, e) =>
                    {
                        DataTable db = DatabaseManager.TableCustomer.Search(buildForm.TextBoxes[0].Text);
                        if (db.Rows.Count != 0)
                        {
                            buildForm.Labels[2].Text = $"{db.Rows[0]["firstname"]} {db.Rows[0]["lastname"]} : {db.Rows[0]["email"]}";
                        }
                        else
                            buildForm.Labels[2].Text = "No customer with this name";

                        buildForm.Labels[2].Visible = true;
                    };
                }
                else if (button.Text == "Cancel")
                {
                    button.Click += (s, e) =>
                    {
                        this.Hide();
                        var orderForm = new OrderForm();
                        orderForm.ShowDialog();
                        this.Close();
                    };
                }
                else if (button.Text == "Confirm")
                    button.Click += (s, e) =>
                    {
                        DataTable dt = DatabaseManager.TableCustomer.Search(buildForm.TextBoxes[0].Text);
                        DataTable tableEmployeeF = DatabaseManager.TableEmployee.Search("employee_status", "'maker'");

                        Console.Out.WriteLine(tableEmployeeF.Rows.Count);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (Bike bike in Program.order.bikes)
                            {
                                for (int j = 0; j < bike.Quantity; j++)
                                {
                                    string model = bike.Model;
                                    string color = bike.Color;
                                    int size = bike.Size;
                                    int quantity = 1;
                                    int idCustomer = (int)dt.Rows[0][0];

                                    var myCalendar = CultureInfo.InvariantCulture.Calendar;
                                    var myDateTime = DateTime.Today;
                                    DataTable tableBike = DatabaseManager.TableBike.Search("bike_assemblingdate", $"'{myDateTime.ToString("yyyy-MM-dd")}'");

                                    {
                                        while (tableBike.Rows.Count == (tableEmployeeF.Rows.Count * 3))
                                        {
                                            myDateTime = myDateTime.AddDays(1);
                                            tableBike = DatabaseManager.TableBike.Search("bike_assemblingdate", $"'{myDateTime.ToString("yyyy-MM-dd")}'");
                                        }

                                        while (Convert.ToString(myCalendar.GetDayOfWeek(myDateTime)) == "Saturday" || Convert.ToString(myCalendar.GetDayOfWeek(myDateTime)) == "Sunday")
                                            myDateTime = myDateTime.AddDays(1);
                                    }

                                    DatabaseManager.TableBike.Create(model, color, size, quantity, idCustomer, DateTime.Now.ToString("yyyy-MM-dd"), myDateTime.ToString("yyyy-MM-dd"));
                                    /*
                                        Il faut parcourir toute la rangée de composants du modèle et si la valeur est différente de null,
                                        alors update la valeur dans le stock 
                                    */
                                    DataTable modelBike = DatabaseManager.TableModelBike.Search(model, size); // One row !
                                    DataTable stockParts = DatabaseManager.TableStockParts.Download(); // All table

                                    foreach (DataRow row in modelBike.Rows)
                                        for (int i = 0; i < stockParts.Rows.Count; i++)
                                            if (!row[i + 3].Equals(System.DBNull.Value)) // Check si les composants existent sur le vélo
                                            {
                                                if (!stockParts.Rows[i][$"{color}stock"].Equals(System.DBNull.Value)) // Check si les composants en stock peuvent être choisie avec une couleur
                                                {
                                                    //Console.Out.WriteLine($"model : {row["name"]}, size : {row["size"]}, quantity : {row[i + 3]} || name of part : {stockParts.Rows[i]["name"]} : {color} ({stockParts.Rows[i][$"{color}stock"]})");
                                                    DatabaseManager.TableStockParts.Update((string)stockParts.Rows[i]["name"], quantity, size, color);
                                                }
                                                else // S'ils n'ont pas de couleur
                                                {
                                                    if(!stockParts.Rows[i]["blackStock"].Equals(System.DBNull.Value))
                                                    {
                                                        //Console.Out.WriteLine($"[BLACK] model : {row["name"]}, size : {row["size"]}, quantity : {row[i + 3]} || name of part : {stockParts.Rows[i]["name"]} : {stockParts.Rows[i]["blacStock"]}");
                                                        DatabaseManager.TableStockParts.Update(stockParts.Rows[i]["name"].ToString(), quantity, size: size, color:"black");
                                                    }
                                                    else if (!stockParts.Rows[i]["noColorStock"].Equals(System.DBNull.Value)) // Check si les composants ne possèdent pas une valeur nulle pour les incolores
                                                    {
                                                        //Console.Out.WriteLine($"[NOCOLOR] model : {row["name"]}, size : {row["size"]}, quantity : {row[i + 3]} || name of part : {stockParts.Rows[i]["name"]} : {stockParts.Rows[i]["noColorstock"]}");
                                                        DatabaseManager.TableStockParts.Update(stockParts.Rows[i]["name"].ToString(), quantity, size:size);
                                                    }

                                                }
                                            }
                                }
                            }

                            MessageBox.Show("Command confirmed !");

                            Program.order.Clear();

                            this.Hide();
                            var mainForm = new MainForm();
                            mainForm.ShowDialog();
                            this.Close();

                        }
                        else
                            MessageBox.Show("Customer not found !");
                    };
                
            }

            foreach (Label label in buildForm.Labels)
                Controls.Add(label);
            foreach (TextBox textBox in buildForm.TextBoxes)
                Controls.Add(textBox);
            foreach (Button button in buildForm.Buttons)
                Controls.Add(button);
        }
    }
}
