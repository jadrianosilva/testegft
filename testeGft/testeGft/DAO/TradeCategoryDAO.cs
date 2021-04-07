using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Repository.Repositorio;
using Interfaces.Interfaces;
using Common;

namespace Dados.DAO
{
    public class TradeCategoryDAO : ITradeCategory
    {
        public List<TradeCategoryDTO> GetTradeCategories()
        {
            List<TradeCategoryDTO> oReturn = new List<TradeCategoryDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = MontaStringSql(0,0,0);

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    TradeCategoryDTO oTrade = new TradeCategoryDTO();

                    oTrade.idCategory = int.Parse(oData["idTrade"].ToString());
                    oTrade.dsCategory = oData["dsCategory"].ToString();
                    oTrade.idRange = int.Parse(oData["idCliente"].ToString());
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

        public List<TradeCategoryDTO> GetTradeCategories(int pidCategory)
        {
            List<TradeCategoryDTO> oReturn = new List<TradeCategoryDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = MontaStringSql(pidCategory, 0, 0);

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    TradeCategoryDTO oTrade = new TradeCategoryDTO();

                    oTrade.idCategory = int.Parse(oData["idTrade"].ToString());
                    oTrade.dsCategory = oData["dsCategory"].ToString();
                    oTrade.idRange = int.Parse(oData["idCliente"].ToString());
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
        public List<TradeCategoryDTO> GetTradeCategories(int pidCategory, int pidRange, int pidSector)
        {
            List<TradeCategoryDTO> oReturn = new List<TradeCategoryDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = MontaStringSql(pidCategory, pidRange, pidSector);

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    TradeCategoryDTO oTrade = new TradeCategoryDTO();

                    oTrade.idCategory = int.Parse(oData["idTrade"].ToString());
                    oTrade.dsCategory = oData["dsCategory"].ToString();
                    oTrade.idRange = int.Parse(oData["idCliente"].ToString());
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
        public List<TradeCategoryDTO> GetTradeCategoriesByRange(int pidRange)
        {
            List<TradeCategoryDTO> oReturn = new List<TradeCategoryDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                using (sqlCon = DBLibrary.OpenConnection())
                {
                    SqlCommand sqlCmd = new SqlCommand();

                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = MontaStringSql(0, pidRange, 0);

                    var oData = sqlCmd.ExecuteReader();

                    while (oData.Read() == true)
                    {
                        TradeCategoryDTO oTrade = new TradeCategoryDTO();

                        oTrade.idCategory = int.Parse(oData["idTrade"].ToString());
                        oTrade.dsCategory = oData["dsCategory"].ToString();
                        oTrade.idRange = int.Parse(oData["idCliente"].ToString());
                        oTrade.idSector = int.Parse(oData["idSector"].ToString());
                        oTrade.dsSector = oData["dsSector"].ToString();

                        oReturn.Add(oTrade);
                    }
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
        public List<TradeCategoryDTO> GetTradeCategoriesBySector(int pidSector)
        {
            List<TradeCategoryDTO> oReturn = new List<TradeCategoryDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = MontaStringSql(0, 0, pidSector);

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    TradeCategoryDTO oTrade = new TradeCategoryDTO();

                    oTrade.idCategory = int.Parse(oData["idTrade"].ToString());
                    oTrade.dsCategory = oData["dsCategory"].ToString();
                    oTrade.idRange = int.Parse(oData["idCliente"].ToString());
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

        public bool insTradeCategories(int pidCategory, int pidRange, int pidSector)
        {
            bool bReturn = false;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_tradeCategory_insert";
                sqlCmd.Parameters.AddWithValue("@IdCategory", pidCategory);
                sqlCmd.Parameters.AddWithValue("@IdRange", pidRange);
                sqlCmd.Parameters.AddWithValue("@IdSector", pidSector);

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
        public bool delTradeCategories(int pidCategory, int pidRange, int pidSector)
        {
            bool bReturn = false;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_tradeCategory_delete";
                sqlCmd.Parameters.AddWithValue("@IdCategory", pidCategory);
                sqlCmd.Parameters.AddWithValue("@IdRange", pidRange);
                sqlCmd.Parameters.AddWithValue("@IdSector", pidSector);

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

        private string MontaStringSql(int pidCategory, int pidRange, int pidSector)
        {
            string sSql = "";
            string sAux = " WHERE ";

            sSql = "SELECT td.idCategory" +
                   "      ,ct.dsCategory" +
                   "      ,td.idSector" +
                   "      ,se.dsSector" +
                   "      ,td.idRange" +
                   "  FROM tbTradeCategory td" +
                   " INNER JOIN tbCategory ct" +
                   "    ON td.idCategory = ct.idCategory" +
                   " INNER JOIN tbSector se" +
                   "    ON td.idSector = se.idSector";

            if(pidCategory > 0)
            {
                sSql += sAux + " td.idCategory " + pidCategory.ToString();
                sAux = " AND ";
            }
            if (pidRange > 0)
            {
                sSql += sAux + " td.idRange " + pidRange.ToString();
                sAux = " AND ";
            }
            if (pidSector > 0)
            {
                sSql += sAux + " td.idSector " + pidSector.ToString();
            }

            return sSql;
        }
    }
}
