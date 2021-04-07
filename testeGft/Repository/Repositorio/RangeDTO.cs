using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositorio
{
    public class RangeDTO
    {
		private int _idRange;
		private Decimal _firstValue;
		private Decimal _lastValue;

		public int idRange
		{
			get { return _idRange; }
			set { _idRange = value; }
		}

		public Decimal firstValue
		{
			get { return _firstValue; }
			set { _firstValue = value; }
		}

		public Decimal lastValue
		{
			get { return _lastValue; }
			set { _lastValue = value; }
		}
	}
}
