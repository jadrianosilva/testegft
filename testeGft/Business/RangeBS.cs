using System;
using System.Collections.Generic;
using System.Text;
using Dados.DAO;
using Repository.Repositorio;
using Interfaces.Interfaces;

namespace Business
{
    public class RangeBS : IRangeBS
    {
        public int insert(List<RangeDTO> pRange)
        {
            int iReturn = 0;
            RangeDAO oRange = new RangeDAO();

            try
            {
                foreach (RangeDTO pItem in pRange)
                {
                    iReturn = oRange.insert(pItem);

                    if (iReturn == 0)
                    {
                        throw new Exception("Ocorreu um erro ao inserir o Range de valores");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return iReturn;
        }

        public bool update(List<RangeDTO> pRange)
        {
            bool bReturn = false;
            RangeDAO oRange = new RangeDAO();

            try
            {
                foreach (RangeDTO pItem in pRange)
                {
                    if (pItem.idRange == 0)
                    {
                        throw new Exception("Código do Range não informado.");
                    }

                    bReturn = oRange.update(pItem);

                    if (!bReturn)
                    {
                        throw new Exception("Ocorreu um erro ao atualizar o Range de valores");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return bReturn;
        }

        public bool delete(int pIdRange)
        {
            bool bReturn = false;
            RangeDAO oRange = new RangeDAO();
            TradeCategoryDAO oTrade = new TradeCategoryDAO();
            List<TradeCategoryDTO> oListTrade = new List<TradeCategoryDTO>();

            try
            {
                if (pIdRange == 0)
                {
                    throw new Exception("Código do Range não informado.");
                }

                oListTrade = oTrade.GetTradeCategoriesByRange(pIdRange);
                if (oListTrade.Count > 0)
                {
                    throw new Exception("Não será possível excluir o Range, pois existem registros atrelados a ele.");
                }

                bReturn = oRange.delete(pIdRange);

                if (!bReturn)
                {
                    throw new Exception("Ocorreu um erro ao excluir o Range de valores");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }


            return bReturn;
        }

        public List<RangeDTO> listCategory()
        {
            RangeDAO oRange = new RangeDAO();
            List<RangeDTO> oListReturn = new List<RangeDTO>();

            try
            {
                oListReturn = oRange.listRange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return oListReturn;
        }

        public List<RangeDTO> getCategoryByID(int pIdRange)
        {
            RangeDAO oRange = new RangeDAO();
            List<RangeDTO> oListReturn = new List<RangeDTO>();

            try
            {
                if (pIdRange == 0)
                {
                    throw new Exception("Código do Range não informado.");
                }

                oListReturn = oRange.getRangeByID(pIdRange);
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
