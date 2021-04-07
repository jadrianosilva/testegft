using System;
using System.Collections.Generic;
using System.Text;
using Dados.DAO;
using Repository.Repositorio;
using Interfaces.Interfaces;

namespace Business
{
    public class CategoryBS: ICategoryBS
    {
        public int insert(string pDsCategory)
        {
            int iReturn = 0;
            CategoryDAO oCategory = new CategoryDAO();

            try
            {
                if (pDsCategory.Trim() == "")
                {
                    throw new Exception("Informe a descrição da categoria");
                }

                iReturn = oCategory.insert(pDsCategory);
                if (iReturn == 0)
                {
                    throw new Exception("Ocorreu um erro ao inserir a categoria " + pDsCategory);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return iReturn;
        }

        public bool update(List<CategoryDTO> pDtoCategory)
        {
            bool bReturn = false;
            CategoryDAO oCategory = new CategoryDAO();

            try
            {
                foreach(CategoryDTO pItem in pDtoCategory)
                {
                    if(pItem.idCategory == 0)
                    {
                        throw new Exception("Código da categoria não informado.");
                    }
                    if(pItem.dsCategory.Trim() == "")
                    {
                        throw new Exception("Informe a descrição da categoria.");
                    }

                    bReturn = oCategory.update(pItem);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return bReturn;
        }

        public bool delete(int pIdCategory)
        {
            bool bReturn = false;
            CategoryDAO oCategory = new CategoryDAO();
            TradeCategoryDAO oTrade = new TradeCategoryDAO();
            List<TradeCategoryDTO> oListTrade = new List<TradeCategoryDTO>();

            try
            {
                if (pIdCategory == 0)
                {
                    throw new Exception("Código da categoria não informado.");
                }

                oListTrade = oTrade.GetTradeCategories(pIdCategory);
                if(oListTrade.Count > 0)
                {
                    throw new Exception("Não será possível excluir a categoria, pois existem registros atrelados a ela.");
                }

                bReturn = oCategory.delete(pIdCategory);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }


            return bReturn;
        }

        public List<CategoryDTO> listCategory()
        {
            CategoryDAO oCategory = new CategoryDAO();
            List<CategoryDTO> oListReturn = new List<CategoryDTO>();

            try
            {
                oListReturn = oCategory.listCategory();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return oListReturn;
        }

        public List<CategoryDTO> getCategoryByID(int pIdCategory)
        {
            CategoryDAO oCategory = new CategoryDAO();
            List<CategoryDTO> oListReturn = new List<CategoryDTO>();

            try
            {
                if (pIdCategory == 0)
                {
                    throw new Exception("Código da categoria não informado.");
                }

                oListReturn = oCategory.getCategoryByID(pIdCategory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return oListReturn;
        }
    }
}
