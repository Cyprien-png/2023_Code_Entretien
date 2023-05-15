using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine
{
    public class Article
    {
        private string _name;
        private string _code;
        private int _quantity;
        private float _price;

        public Article(string name, string code, int quantity, float price)
        {
            _name = name;
            _code = code;
            _quantity = quantity;
            _price = price;
        }

       
        public string getName() { return _name; }

        public string getCode() { return _code; }

        public int getQuantity() { return _quantity; }

        public void setQuantity(int quantity) { _quantity = quantity; }

        public float getPrice() { return _price; }
    }
}
