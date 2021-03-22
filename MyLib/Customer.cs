using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class Customer
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public Customer(string firstname, string lastname, string email, string phoneNumber, string country, int zipCode, string city, string street, int houseNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            PhoneNumber = phoneNumber;
            Country = country;
            ZipCode = zipCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }
    }
}
