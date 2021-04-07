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
    public class CategoryDAO: ICategory
    {
        public int insert(string pDsCategory)
        {
            int iReturn = 0;
            SqlConnection sqlCon = DBLibrary.OpenConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_category_insert";
                sqlCmd.Parameters.AddWithValue("@DsCategory", pDsCategory);

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

        public bool update(CategoryDTO pDtoCategory)
        { 
            bool bReturn = false;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_category_update";
                sqlCmd.Parameters.AddWithValue("@IdCategory", pDtoCategory.idCategory);
                sqlCmd.Parameters.AddWithValue("@DsCategory", pDtoCategory.dsCategory);

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

        public bool delete(int pIdCategory)
        {
            bool bReturn = false;
            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_category_delete";
                sqlCmd.Parameters.AddWithValue("@IdCategory", pIdCategory);

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

        public List<CategoryDTO> listCategory()
        {

            List<CategoryDTO> oReturn = new List<CategoryDTO>();

            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_category_listar";

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    CategoryDTO oCategory = new CategoryDTO();

                    oCategory.idCategory = int.Parse(item["idCategory"].ToString());
                    oCategory.dsCategory = int.Parse(item["dsCategory"].ToString());

                    oReturn.Add(oCategory);
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

        public List<CategoryDTO> getCategoryByID(int pIdCategory)
        {
            List<CategoryDTO> oReturn = new List<CategoryDTO>();

            SqlConnection sqlCon = DBLibrary.OpenConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_category_consultar";
                sqlCmd.Parameters.AddWithValue("@IdCategory", pIdCategory);

                var oData = sqlCmd.ExecuteReader();

                while (oData.Read() == true)
                {
                    CategoryDTO oCategory = new CategoryDTO();

                    oCategory.idCategory = int.Parse(item["idCategory"].ToString());
                    oCategory.dsCategory = int.Parse(item["dsCategory"].ToString());

                    oReturn.Add(oCategory);
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
