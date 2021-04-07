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
    public class SectorDAO : ISector
    {
        public int insert(string pDsSector)
        {
            int iReturn = 0;
            SqlConnection sqlCon = DBLibrary.OpenConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "sp_sector_insert";
                    sqlCmd.Parameters.AddWithValue("@DsSector", pDsSector);

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

        public bool update(SectorDTO oSector)
        {
            bool bReturn = false;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_sector_update";
                sqlCmd.Parameters.AddWithValue("@IdSector", oSector.idSector);
                sqlCmd.Parameters.AddWithValue("@DsSector", oSector.dsSector);

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

        public bool delete(int pIdSector)
        {
            bool bReturn = false;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_sector_delete";
                sqlCmd.Parameters.AddWithValue("@IdSector", pIdSector);

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

        public List<SectorDTO> listSector()
        {
            List<SectorDTO> oReturn = new List<SectorDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_sector_listar";

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    SectorDTO oSector = new SectorDTO();

                    oSector.idSector = int.Parse(oData["idSector"].ToString());
                    oSector.dsSector = oData["dsSector"].ToString();

                    oReturn.Add(oSector);
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

        public List<SectorDTO> getSectorByID(int pIdSector)
        {
            List<SectorDTO> oReturn = new List<SectorDTO>();
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_sector_consultar";
                sqlCmd.Parameters.AddWithValue("@IdSector", pIdSector);

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    SectorDTO oSector = new SectorDTO();

                    oSector.idSector = int.Parse(oData["idSector"].ToString());
                    oSector.dsSector = oData["dsSector"].ToString();

                    oReturn.Add(oSector);
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