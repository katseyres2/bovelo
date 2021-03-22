using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class Order
    {
        public List<Bike> bikes = new List<Bike>();

        public Order() { }

        public void AddBike(Bike bike)
        {
            bikes.Add(bike);
        }

        public void Display()
        {
            foreach (Bike bike in bikes)
            {
                Console.Out.WriteLine($"model : {bike.Model}, color : {bike.Color}, size : {bike.Size}, size : {bike.Quantity}");
            }
        }

        public void Clear()
        {
            bikes.Clear();
        }
    }
}
