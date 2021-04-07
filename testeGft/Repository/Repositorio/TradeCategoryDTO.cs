using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositorio
{
    public class TradeCategoryDTO
    {
		private int _idRange;
		private int _idCategory;
		private string _dsCategory;
		private int _idSector;
		private string _dsSector;

		public int idRange
		{
			get { return _idRange; }
			set { _idRange = value; }
		}
		public int idCategory
		{
			get { return _idCategory; }
			set { _idCategory = value; }
		}
		public string dsCategory
		{
			get { return _dsCategory; }
			set { _dsCategory = value; }
		}
		public int idSector
		{
			get { return _idSector; }
			set { _idSector = value; }
		}
		public string dsSector
		{
			get { return _dsSector; }
			set { _dsSector = value; }
		}
	}
	}
}
