using System;
using System.Collections;
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
        private string _devTime;
        private float[] _hours = new float[24];


        public Machine() {
            _change = 0;
            _balance = 0;
            _devTime = string.Empty;
            _articles = new List<Article>();
        }

        private string GetTime()
        {
            DateTime currentTime = DateTime.Now;
            string isoTime = currentTime.ToString("yyyy-MM-ddTHH:mm:ss");
            return isoTime;
        }

        public int getHour(string Date)
        {
            DateTime dateTime = DateTime.Parse(Date);
            int hour = int.Parse(dateTime.ToString("HH"));
            return hour;
        }

        public void setTime(string time) { _devTime = time; }

        public void AddArticle(Article article) { _articles.Add(article); }


        public string choose(string code)
        {
            string message = string.Empty;
            string time = string.Empty;


            if (_devTime.Length > 0){
                time = _devTime;
            }
            else{
                time = GetTime();
            }

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

                        //index corresponds to the time
                        _hours[getHour(time)] += article.getPrice();
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

        public string getBestHours()
        {
            string message = string.Empty;

            //create a temp copy of _hours and sort it DESC (most profitable hour)
            float[] sortedHours = (float[])_hours.Clone();
            Array.Sort(sortedHours);
            Array.Reverse(sortedHours);

            //then keep the 3 most profitable and find their indexes (index = hour when the money was collected)
            for (int i = 0; i < 3; i++)
            {
                int hour = 0;
                for (; hour < 24; hour++) { if (sortedHours[i] == _hours[hour]) { break; } }

                message = message + "Hour " + hour + " generated a revenue of " + sortedHours[i].ToString("0.00") + "\n";
            }
           
            return message;
        }
    }
}
