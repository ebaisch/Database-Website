using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Person
/// </summary>
public class Person
{
    int customer_id;

    String name;
    String address;
    String company;
    String city;
    String zipcode;
    String state;
    String country;
    String email;
    String phone;

    String shipping_type;
    String shipping_price;

    String payment_type;
    String card_number;
    String card_exp;
    String csv;

    int payment_id;
    int shipping_id;
    int shipment_id;


    
    public Person()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Person(int customer_id, string name, string address, string company, string city, string zipcode, string state, string country, string email, string phone, string shipping_type, string shipping_price, string payment_type, string card_number, string card_exp, string csv)
    {
        this.Customer_id = customer_id;
        this.Name = name;
        this.Address = address;
        this.Company = company;
        this.City = city;
        this.Zipcode = zipcode;
        this.State = state;
        this.Country = country;
        this.Email = email;
        this.Phone = phone;
        this.Shipping_type = shipping_type;
        this.Shipping_price = shipping_price;
        this.Payment_type = payment_type;
        this.Card_number = card_number;
        this.Card_exp = card_exp;
        this.Csv = csv;
    }

    public int Customer_id { get => customer_id; set => customer_id = value; }
    public string Name { get => name; set => name = value; }
    public string Address { get => address; set => address = value; }
    public string Company { get => company; set => company = value; }
    public string City { get => city; set => city = value; }
    public string Zipcode { get => zipcode; set => zipcode = value; }
    public string State { get => state; set => state = value; }
    public string Country { get => country; set => country = value; }
    public string Email { get => email; set => email = value; }
    public string Phone { get => phone; set => phone = value; }
    public string Shipping_type { get => shipping_type; set => shipping_type = value; }
    public string Shipping_price { get => shipping_price; set => shipping_price = value; }
    public string Payment_type { get => payment_type; set => payment_type = value; }
    public string Card_number { get => card_number; set => card_number = value; }
    public string Card_exp { get => card_exp; set => card_exp = value; }
    public string Csv { get => csv; set => csv = value; }
}