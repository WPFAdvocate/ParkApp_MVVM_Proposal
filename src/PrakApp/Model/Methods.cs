using PrakApp.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PrakApp.Model
{
	class Methods
	{
        public static string getAccess(string user)
        {
            string accessLvl = string.Empty;
            using (SqlConnection con = new SqlConnection(Settings.Default.Users))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Users WHERE Username='" + user + "'", con)) //fix query
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())//test
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                accessLvl = reader["AccessLevel"].ToString();
                            }
                        }
                        return accessLvl;
                    }

                }
            }
        }

        public static string getName(string user)
        {
            string name = string.Empty;
            using (SqlConnection con = new SqlConnection(Settings.Default.Users))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT name FROM dbo.Users WHERE Username='" + user + "'", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())//test
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                name = reader["name"].ToString();
                            }
                        }
                        return name;
                    }

                }
            }
        }
    }
}
