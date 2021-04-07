using System;
using System.Collections.Generic;
using System.Text;
using Repository.Repositorio;
using Interfaces.Interfaces;
using Dados.DAO;

namespace Business
{
    public class TradeBS
    {
        public int insert(List<TradeDTO> pTrade)
        {
            int iReturn = 0;
            TradeDAO oTrade = new TradeDAO();
            try
            {
                foreach (TradeDTO pItem in pTrade)
                {
                    if(pItem.tradeValue == 0)
                    {
                        throw new Exception("Valor do Trade não pode ser zero.");
                    }
                    iReturn = oTrade.insert(pItem);

                    if (iReturn == 0)
                    {
                        throw new Exception("Ocorreu um erro ao inserir o Trade");
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

        public bool update(List<TradeDTO> pTrade)
        {
            bool bReturn = false;
            TradeDAO oTrade = new TradeDAO();

            try
            {
                foreach (TradeDTO pItem in pTrade)
                {
                    if (pItem.tradeValue == 0)
                    {
                        throw new Exception("Valor do Trade não pode ser zero.");
                    }
                    bReturn = oTrade.update(pItem);

                    if (!bReturn)
                    {
                        throw new Exception("Ocorreu um erro ao atualizar o Trade");
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

        public bool delete(int pIdTrade)
        {
            bool bReturn = false;

            TradeDAO oTrade = new TradeDAO();

            try
            { 
                if (pIdTrade == 0)
                {
                    throw new Exception("Código do Trade não informado.");
                }
                bReturn = oTrade.delete(pIdTrade);

                if (!bReturn)
                {
                    throw new Exception("Ocorreu um erro ao atualizar o Trade");
                }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return bReturn;
        }

        public List<TradeDTO> listTrade()
        {
            List<TradeDTO> oReturn = new List<TradeDTO>();
            TradeDAO oTrade = new TradeDAO();

            try
            {
                oReturn = oTrade.listTrade();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return oReturn;
        }

        public List<TradeDTO> getTradeByID(int pIdTrade)
        {
            List<TradeDTO> oReturn = new List<TradeDTO>();
            TradeDAO oTrade = new TradeDAO();

            try
            {
                oReturn = oTrade.getTradeByID(pIdTrade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return oReturn;
        }

        public string getSectorTrade(List<TradeDTO>pTrade)
        {
            string sReturn = "";
            TradeDAO oTrade = new TradeDAO();
            List<TradeCategoryDTO> oReturn = new List<TradeCategoryDTO>();

            try
            {
                foreach(TradeDTO pItem in pTrade)
                {
                    oReturn = oTrade.getSectorTrade(pItem);

                    if(oReturn.Count > 0)
                    {
                        foreach (TradeCategoryDTO pRetorno in oReturn)
                        {
                            sReturn += pRetorno.dsCategory = ",";
                        }                        
                    }
                }
                
                if(sReturn.LastIndexOf(",")> -1)
                {
                    sReturn = sReturn.Substring(0, (sReturn.Length - 1));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

            return sReturn;
        }
    }
}
