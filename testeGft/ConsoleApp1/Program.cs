using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Repository.Repositorio;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TradeBS obj = new TradeBS();
            string sReturn = "";
            List<TradeDTO> oListTrade = new List<TradeDTO>();

            TradeDTO Trade1 = new TradeDTO();
            TradeDTO Trade2 = new TradeDTO();
            TradeDTO Trade3 = new TradeDTO();
            TradeDTO Trade4 = new TradeDTO();

            Trade1.tradeValue = 2000000; Trade1.dsSector = "Private";
            Trade2.tradeValue = 400000; Trade2.dsSector = "Public";
            Trade3.tradeValue = 500000; Trade3.dsSector = "Public";
            Trade4.tradeValue = 3000000; Trade4.dsSector = "Public";

            oListTrade.Add(Trade1); 
            oListTrade.Add(Trade2); 
            oListTrade.Add(Trade3); 
            oListTrade.Add(Trade4);

            sReturn = obj.getSectorTrade(oListTrade);

            Console.WriteLine(sReturn);

        }
    }
}
