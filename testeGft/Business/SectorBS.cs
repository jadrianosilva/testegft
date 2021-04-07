using System;
using System.Collections.Generic;
using System.Text;
using Dados.DAO;
using Repository.Repositorio;
using Interfaces.Interfaces;

namespace Business
{
    public class SectorBS : ISectorBS
    {
        public int insert(string pDsSector)
        {
            int iReturn = 0;
            SectorDAO oSector = new SectorDAO();

            try
            {
                if (pDsSector.Trim() == "")
                {
                    throw new Exception("Informe a descrição do Setor");
                }

                iReturn = oSector.insert(pDsSector);
                if (iReturn == 0)
                {
                    throw new Exception("Ocorreu um erro ao inserir o setor " + pDsSector);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return iReturn;
        }

        public bool update(List<SectorDTO> pDtoSector)
        {
            bool bReturn = false;
            SectorDAO oSector = new SectorDAO();

            try
            {
                foreach (SectorDTO pItem in pDtoSector)
                {
                    if (pItem.idSector == 0)
                    {
                        throw new Exception("Código do Setor não informado.");
                    }
                    if (pItem.dsSector.Trim() == "")
                    {
                        throw new Exception("Informe a descrição do Setor.");
                    }

                    bReturn = oSector.update(pItem);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return bReturn;
        }

        public bool delete(int pIdSector)
        {
            bool bReturn = false;
            CategoryDAO oCategory = new CategoryDAO();
            TradeCategoryDAO oTrade = new TradeCategoryDAO();
            List<TradeCategoryDTO> oListTrade = new List<TradeCategoryDTO>();

            try
            {
                if (pIdSector == 0)
                {
                    throw new Exception("Código do Setor não informado.");
                }

                oListTrade = oTrade.GetTradeCategoriesBySector(pIdSector);
                if (oListTrade.Count > 0)
                {
                    throw new Exception("Não será possível excluir o Setor, pois existem registros atrelados a ele.");
                }

                bReturn = oCategory.delete(pIdSector);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }


            return bReturn;
        }

        public List<SectorDTO> listSectory()
        {
            SectorDAO oSector = new SectorDAO();
            List<SectorDTO> oListReturn = new List<SectorDTO>();

            try
            {
                oListReturn = oSector.listSector();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return oListReturn;
        }

        public List<SectorDTO> getSectorByID(int pIdSector)
        {
            SectorDAO oSector = new SectorDAO();
            List<SectorDTO> oListReturn = new List<SectorDTO>();

            try
            {
                if (pIdSector == 0)
                {
                    throw new Exception("Código do Setor não informado.");
                }

                oListReturn = oSector.getSectorByID(pIdSector);
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
