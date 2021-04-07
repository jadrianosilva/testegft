using System;
using System.Collections.Generic;
using System.Text;
using Repository.Repositorio;

namespace Interfaces.Interfaces
{
    public interface ITrade
    {
        int insert(TradeDTO oTrade);
        bool update(TradeDTO oTrade);
        bool delete(int pIdTrade);
        List<TradeDTO> listTrade();
        List<TradeDTO> getTradeByID(int pIdTrade);
        string getSectorTrade(TradeDTO pTrade);
    }
}
