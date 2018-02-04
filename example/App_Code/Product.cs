using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{

    public int product_id, category_id;
    public String name, description, image;

    public Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Product(int product_id, String name, String description, String image, int category_id)
    {
        this.product_id = product_id;
        this.name = name;
        this.description = description;
        this.image = image;
        this.category_id = category_id;
    }
}