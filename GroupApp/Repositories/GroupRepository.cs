using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GroupApp.DomainModel;
using GroupApp.Helper;
using GroupApp.IRepositories;

namespace GroupApp.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        public Group Add(Group Group)
        {
            string strSQL = "[dbo].[Insert_Group]";
            string connStr = appConfig.ConnectionString;

            SqlConnection connection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(strSQL, connection) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@param_GroupID", SqlDbType.Int)).Direction = ParameterDirection.Output;           
            cmd.Parameters.Add(new SqlParameter("@param_Description", SqlDbType.NVarChar)).Value = Group.Description;
            cmd.Parameters.Add(new SqlParameter("@param_Email", SqlDbType.NVarChar)).Value = Group.Email;
            cmd.Parameters.Add(new SqlParameter("@param_FriendlyName", SqlDbType.NVarChar)).Value = Group.FriendlyName;
            cmd.Parameters.Add(new SqlParameter("@param_GroupGUID", SqlDbType.UniqueIdentifier)).Value = Group.GroupGUID;
            cmd.Parameters.Add(new SqlParameter("@param_LogonName", SqlDbType.NVarChar)).Value = Group.LogonName;
            cmd.Parameters.Add(new SqlParameter("@param_Name", SqlDbType.NVarChar)).Value = Group.Name;
            cmd.Parameters.Add(new SqlParameter("@param_Notes", SqlDbType.NVarChar)).Value = Group.Notes;

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                Group.GroupID = int.Parse(cmd.Parameters["@param_GroupID"].Value.ToString());
                connection.Close();
                return Group;
            }
            catch (Exception ex)
            {                
                return null;
            }
        }

        public IEnumerable<Group> GetAll()
        {
            var Group = FillAll();
            if (Group != null)
            {
                return Group;
            }
            return null;
        }
        private IEnumerable<Group> FillAll()
        {
            try
            {
                string strSQL = "[dbo].[GetAllGroups]";                
                string connStr = appConfig.ConnectionString;
                SqlConnection connection = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(strSQL, connection) { CommandType = CommandType.StoredProcedure };

                try
                {
                    connection.Open();
                    IDataReader reader = cmd.ExecuteReader();                    
                    List<Group> items = new List<Group>();
                    DataMapper Mapper = new DataMapper();
                    items = Mapper.MapData<Group>(reader);
                    connection.Close();
                    return items;               
                }
                catch (Exception)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                
            }
            return null;
        }
        public bool Delete(int ID)
        {
            try
            {
                string strSQL = "[dbo].[Delete_Group]";
                string connStr = appConfig.ConnectionString;

                SqlConnection connection = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(strSQL, connection) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add(new SqlParameter("@param_GroupID", SqlDbType.Int)).Value = ID;
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;                    
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Group Get(int Id)
        {
            var Group = GetGroup();
            if (Group != null)
            {
                return Group;
            }
            return null;
        }
        private Group GetGroup() {
            try
            {
                string strSQL = "[dbo].[GetGroupByID]";
                string connStr = appConfig.ConnectionString;
                SqlConnection connection = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(strSQL, connection) { CommandType = CommandType.StoredProcedure };
                try
                {
                    connection.Open();
                    IDataReader reader = cmd.ExecuteReader();                    
                    List<Group> items = new List<Group>();
                    DataMapper Mapper = new DataMapper();
                    items = Mapper.MapData<Group>(reader);
                    connection.Close();
                    return items.FirstOrDefault();         
                }
                catch (Exception)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
       

        public bool Update(Group Group)
        {
            try
            {
                string strSQL = "[dbo].[Update_Group]";
                string connStr = appConfig.ConnectionString;

                SqlConnection connection = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(strSQL, connection) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add(new SqlParameter("@param_GroupID", SqlDbType.Int)).Value = Group.GroupID;
                cmd.Parameters.Add(new SqlParameter("@param_Description", SqlDbType.NVarChar)).Value = Group.Description;
                cmd.Parameters.Add(new SqlParameter("@param_Email", SqlDbType.NVarChar)).Value = Group.Email;
                cmd.Parameters.Add(new SqlParameter("@param_FriendlyName", SqlDbType.NVarChar)).Value = Group.FriendlyName;
                cmd.Parameters.Add(new SqlParameter("@param_GroupGUID", SqlDbType.UniqueIdentifier)).Value = Group.GroupGUID;
                cmd.Parameters.Add(new SqlParameter("@param_LogonName", SqlDbType.NVarChar)).Value = Group.LogonName;
                cmd.Parameters.Add(new SqlParameter("@param_Name", SqlDbType.NVarChar)).Value = Group.Name;
                cmd.Parameters.Add(new SqlParameter("@param_Notes", SqlDbType.NVarChar)).Value = Group.Notes;
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;               
            }
        }
    }
}
