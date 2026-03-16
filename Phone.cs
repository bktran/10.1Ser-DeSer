using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._1Ser_DeSer
{
    public class Phone
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public Phone(string brand, string model, float price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }
        public Phone()
        {

        }
    }
}
