using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRental_K_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace VideoRental_K_Project.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        public SqlConnection conn;

        //write the connection sstring to assthe data form one for to the database 
        public String loc = "Data Source=DESKTOP-HKD1BEO\\SQLEXPRESS;Initial Catalog=movie_Store;Integrated Security=True";

        //command are use to excute the command of isnert , delete , update
        public SqlCommand cmd;

        //data reader is used to read thedata from the database table 
        public SqlDataReader DReader;


        [TestMethod()]
        public void Form1Test()
        {

            Form1 obj = new Form1();
            
            DataTable tbl = new DataTable();

        

        conn = new SqlConnection(loc);

            conn.Open();

            cmd = new SqlCommand("select * from Booking", conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();
            if (tbl.Rows.Count > 0)
            {
                Assert.IsTrue(true);
            }
            else {
                Assert.IsTrue(false);
            }

            
        }
    }
}