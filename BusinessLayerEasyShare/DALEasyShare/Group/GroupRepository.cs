using EntityEasyShare;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEasyShare.Group
{
    public class GroupRepository
    {

        public void CreateGroup(string groupName, List<UserEntity> users)
        {
            using (SqlConnection con = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EasyShare; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
               {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("spc_CreateGroup", con);
                    
                    cmd.Parameters.AddWithValue("@groupName", groupName);
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                        int modified = Convert.ToInt32(cmd.ExecuteScalar());
                        //command.ExecuteNonQuery();
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Count not insert.");
                }


            }
        }
    }
}
