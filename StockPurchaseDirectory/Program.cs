using System;
using System.Collections.Generic;

namespace StockPurchaseDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            var stocks = new Dictionary<string, string>();
            stocks.Add("GME", "GameStop");
            stocks.Add("AMC", "AMC");
            stocks.Add("PLUG", "Plug Power");

            var purchases = new List<(string ticker, int shares, double price)>();
            purchases.Add((ticker: "GME", shares: 100, price: 40));
            purchases.Add((ticker: "GME", shares: 58, price: 120));
            purchases.Add((ticker: "GME", shares: 3, price: 420));
            purchases.Add((ticker: "AMC", shares: 70, price: 10));
            purchases.Add((ticker: "AMC", shares: 58, price: 20));
            purchases.Add((ticker: "AMC", shares: 9, price: 40));
            purchases.Add((ticker: "PLUG", shares: 80, price: 5.70));
            purchases.Add((ticker: "PLUG", shares: 158, price: 3.92));
            purchases.Add((ticker: "PLUG", shares: 12, price: 15.39));

            var aggregatedPurchases = new Dictionary<string, int>();
            foreach (var stock in stocks)
            {
                foreach ((string ticker, int shares, double price) purchase in purchases)
                {
                    if (stock.Key == purchase.ticker)
                    {
                        if (!aggregatedPurchases.ContainsKey(stock.Value))
                        {
                            aggregatedPurchases.Add(stock.Value, (int)(purchase.shares * purchase.price));

                        } else
                        {
                            aggregatedPurchases[stock.Value] += (int)(purchase.shares * purchase.price);
                        }
                   }
                }
            }
            foreach (var agPur in aggregatedPurchases)
            {
                Console.WriteLine($"{agPur.Key}: {agPur.Value}");
            }
        }
    }
}
