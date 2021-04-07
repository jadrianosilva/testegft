using System;
using System.Collections.Generic;
using System.Text;
using Repository.Repositorio;
using Interfaces.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace Dados.DAO
{
    public class TradeDAO: ITrade
    {
        public int insert(TradeDTO oTrade)
        {
            int iReturn = 0;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_trade_insert";
                sqlCmd.Parameters.AddWithValue("@IdCliente", oTrade.idCliente.ToString());
                sqlCmd.Parameters.AddWithValue("@TradeValue", oTrade.tradeValue);
                sqlCmd.Parameters.AddWithValue("@IdSector", oTrade.idSector.ToString());

                iReturn = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                sqlCon.Close();
            }

            return iReturn;
        }

        public bool update(TradeDTO oTrade)
        {
            bool bReturn = false;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_trade_update";
                sqlCmd.Parameters.AddWithValue("@IdTrade", oTrade.idTrade);
                sqlCmd.Parameters.AddWithValue("@TradeValue", oTrade.tradeValue);
                sqlCmd.Parameters.AddWithValue("@IdSector", oTrade.idSector.ToString());

                sqlCmd.ExecuteNonQuery();

                bReturn = true;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return bReturn;
        }

        public bool delete(int pIdTrade)
        {
            bool bReturn = false;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_trade_delete";
                sqlCmd.Parameters.AddWithValue("@IdTrade", pIdTrade);

                sqlCmd.ExecuteNonQuery();

                bReturn = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return bReturn;
        }

        public List<TradeDTO> listTrade()
        {
            List<TradeDTO> oReturn = new List<TradeDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_trade_listar";

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    TradeDTO oTrade = new TradeDTO();

                    oTrade.idTrade = int.Parse(oData["idTrade"].ToString());
                    oTrade.idCliente = int.Parse(oData["idCliente"].ToString());
                    oTrade.tradeValue = decimal.Parse(oData["tradeValue"].ToString());
                    oTrade.idSector = int.Parse(oData["idSector"].ToString());
                    oTrade.dsSector = oData["dsSector"].ToString();

                    oReturn.Add(oTrade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return oReturn;
        }

        public List<TradeDTO> getTradeByID(int pIdTrade)
        {
            List<TradeDTO> oReturn = new List<TradeDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_trade_consultar";
                sqlCmd.Parameters.AddWithValue("@IdTrade", pIdTrade);

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    TradeDTO oTrade = new TradeDTO();

                    oTrade.idTrade = int.Parse(oData["idTrade"].ToString());
                    oTrade.idCliente = int.Parse(oData["idCliente"].ToString());
                    oTrade.tradeValue = decimal.Parse(oData["tradeValue"].ToString());
                    oTrade.idSector = int.Parse(oData["idSector"].ToString());
                    oTrade.dsSector = oData["dsSector"].ToString();

                    oReturn.Add(oTrade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return oReturn;
        }

        public List<TradeCategoryDTO> getSectorTrade(TradeDTO pTrade)
        {
            List<TradeCategoryDTO> oReturn = new List<TradeCategoryDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_tradeCategory_sector";
                sqlCmd.Parameters.AddWithValue("@TradeValue", pTrade.tradeValue);
                sqlCmd.Parameters.AddWithValue("@DsSector", pTrade.dsSector);

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    TradeCategoryDTO oTrade = new TradeCategoryDTO();

                    oTrade.dsCategory = oData["dsCategory"].ToString();

                    oReturn.Add(oTrade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return oReturn;
        }
    }
}
