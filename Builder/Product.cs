using System;
using System.Collections.Generic;
using System.Text;

namespace BYT_zad_ind_14.Builder
{
    public class Product
    {
        private string name;
        private readonly List<string> parts = new List<string>();

        public Product(string name = "")
        {
            this.name = name;
        }

        public string GetName() 
        {
            return name;
        }
        public void SetName(string name) 
        {
            this.name = name;
        }

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct "+name+" Parts -------");
            foreach (string part in parts)
                Console.WriteLine(part);
        }

        public override string ToString() 
        {
            string reviewProduct = "\nProduct " + name + " Parts -------";
            foreach (string part in parts) reviewProduct += "\n" + part;
            return reviewProduct;
        }
    }
}
