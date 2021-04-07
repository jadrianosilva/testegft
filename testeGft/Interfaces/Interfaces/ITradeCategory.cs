using System;
using System.Collections.Generic;
using System.Text;
using Repository.Repositorio;

namespace Interfaces.Interfaces
{
    public interface ITradeCategory
    {
        List<TradeCategoryDTO> GetTradeCategories();
        List<TradeCategoryDTO> GetTradeCategories(int pidCategory);
        List<TradeCategoryDTO> GetTradeCategories(int pidCategory, int pidRange, int pidSector);
        List<TradeCategoryDTO> GetTradeCategoriesByRange(int pidRange);
        List<TradeCategoryDTO> GetTradeCategoriesBySector(int pidSector);
        bool insTradeCategories(int pidCategory, int pidRange, int pidSector);
        bool delTradeCategories(int pidCategory, int pidRange, int pidSector);
    }
}