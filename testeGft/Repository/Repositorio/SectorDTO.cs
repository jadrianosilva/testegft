using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositorio
{
    public class SectorDTO
    {
		private int _idSector;
		private String _dsSector;

		public int idSector
		{
			get { return _idSector; }
			set { _idSector = value; }
		}

		public String dsSector
		{
			get { return _dsSector; }
			set { _dsSector = value; }
		}
	}
}
