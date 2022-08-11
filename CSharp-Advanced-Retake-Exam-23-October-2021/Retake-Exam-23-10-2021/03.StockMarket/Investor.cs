using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> data;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;        
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
        public decimal MoneyToInvest
        {
            get { return moneyToInvest; }
            set { moneyToInvest = value; }
        }
        public string BrokerName
        {
            get { return brokerName; }
            set { brokerName = value; }
        }        
        public int Count
        {
            get
            {
                return data.Count;
            }
            private set { }
        }
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            data = new List<Stock>();
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization >= 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                data.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = data.FirstOrDefault(x => x.CompanyName == companyName);
            if (stock.CompanyName == null)
            {                
                return $"{companyName} does not exist.";
            }
            if (sellPrice <= stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            data.Remove(stock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            Stock stock = data.FirstOrDefault(x => x.CompanyName == companyName);
            return stock;
        }
        public Stock FindBiggestCompany()
        {
            Stock stock = data.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
            return stock;
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {fullName} with a broker {brokerName} has stocks:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
