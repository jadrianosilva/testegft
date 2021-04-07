using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositorio
{
	public class CategoryDTO
	{
		private int _idCategory;
		private String _dsCategory;

		public int idCategory
		{
			get { return _idCategory; }
			set { _idCategory = value; }
		}

		public String dsCategory
		{
			get { return _dsCategory; }
			set { _dsCategory = value; }
		}
	}
}
