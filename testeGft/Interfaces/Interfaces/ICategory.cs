using System;
using System.Collections.Generic;
using System.Text;
using Repository.Repositorio;

namespace Interfaces.Interfaces
{
    public interface ICategory
    {
        int insert(string pDsCategory);
        bool update(CategoryDTO pDtoCategory);
        bool delete(int pIdCategory);
        List<CategoryDTO> listCategory();
        List<CategoryDTO> getCategoryByID(int pIdCategory);
    }
}
