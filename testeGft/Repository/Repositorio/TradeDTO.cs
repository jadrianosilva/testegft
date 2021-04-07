using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositorio
{
    public class TradeDTO : SectorDTO
    {
        private int _idTrade;
        private int _idCliente;
        private decimal _tradeValue;

		public int idTrade
		{
			get { return _idTrade; }
			set { _idTrade = value; }
		}
		public int idCliente
		{
			get { return _idCliente; }
			set { _idCliente = value; }
		}

		public Decimal tradeValue
		{
			get { return _tradeValue; }
			set { _tradeValue = value; }
		}
	}
}
