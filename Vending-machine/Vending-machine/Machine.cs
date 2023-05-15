using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine
{
    public class Machine
    {
        private float _change;
        private float _balance;
        private List<Article> _articles;
        public Article[] Articles { get; set; }

        public Machine() {
            _change = 0;
            _balance = 0;
            _articles = new List<Article>();
        }

        public void AddArticle(Article article) { _articles.Add(article); }

        public Article GetArticle(int index) { return _articles[index]; }


        public string choose(string code)
        {
            string message = string.Empty;

            foreach (Article article in _articles)
            {
                if (article.getCode() == code)
                {
                    if(article.getQuantity() == 0) { 
                        message = "Item "+ article.getName()+ ": Out of stock!"; 

                    } else if (article.getPrice() > _change) { 
                        message = "Not enough money!"; 

                    } else {
                        message = "Vending " + article.getName();
                        article.setQuantity(article.getQuantity() - 1);
                        _change -= article.getPrice();
                        _balance += article.getPrice();
                    }
                }
            }

            if (message == string.Empty) {
                message = "Invalid selection!";
            }

            return message;
        }


        public float getChange() { return _change; }

        public float getBalance() { return _balance; }

        public void insert(float money) { _change += money; }
    }
}
