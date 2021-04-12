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
    public class RangeDAO: IRange
    {
        public int insert(RangeDTO oRange)
        {
            int iReturn = 0;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_range_insert";
                sqlCmd.Parameters.AddWithValue("@FirstValue", oRange.firstValue.ToString());
                sqlCmd.Parameters.AddWithValue("@LastValue", oRange.lastValue.ToString());

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

        public bool update(RangeDTO oRange)
        {
            bool bReturn = false;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_range_update";
                sqlCmd.Parameters.AddWithValue("@IdRange", oRange.idRange.ToString());
                sqlCmd.Parameters.AddWithValue("@FirstValue", oRange.firstValue.ToString());
                sqlCmd.Parameters.AddWithValue("@LastValue", oRange.lastValue.ToString());

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

        public bool delete(int pIdRange)
        {
            bool bReturn = false;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {                
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_range_delete";
                sqlCmd.Parameters.AddWithValue("@dRange", pIdRange);

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

        public List<RangeDTO> listRange()
        {
            List<RangeDTO> oReturn = new List<RangeDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_range_listar";

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    RangeDTO oRange = new RangeDTO();
                    oRange.idRange = int.Parse(oData["idRange"].ToString());
                    oRange.firstValue = decimal.Parse(oData["firstValue"].ToString());
                    oRange.lastValue = decimal.Parse(oData["lastValue"].ToString());

                    oReturn.Add(oRange);
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

        public List<RangeDTO> getRangeByID(int pIdRange)
        {
            List<RangeDTO> oReturn = new List<RangeDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_range_consultar";
                sqlCmd.Parameters.AddWithValue("@IdRange", pIdRange);

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {                   
                    RangeDTO oRange = new RangeDTO();
                    oRange.idRange = pIdRange;
                    oRange.firstValue = decimal.Parse(oData["firstValue"].ToString());
                    oRange.lastValue = decimal.Parse(oData["lastValue"].ToString());

                    oReturn.Add(oRange);
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
