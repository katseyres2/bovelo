using System;
using System.Collections.Generic;

namespace MyLib
{
    public class Bike
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }

        public Bike(string model, string color, int size, int quantity) 
        {
            Model = model;
            Size = size;
            Color = color;
            Quantity = quantity;
        }
    }
}
