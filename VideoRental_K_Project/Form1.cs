using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRental_K_Project
{
    public partial class Form1 : Form
    {
        public int bookID = 0;

        //create the instance of the SQL Connection class
        public SqlConnection conn;
       
        //connection string to access the data form one for to the database 
        public String loc= "Data Source=DESKTOP-G2UGPMF\\SQLEXPRESS;Initial Catalog=movie_Store;Integrated Security=True";

        //command are use to excute the command of isnert , delete , update
        public SqlCommand cmd;

        //data reader is used to read thedata from the database table 
        public SqlDataReader DReader;
        public String flag = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Customer_dataadd_Click(object sender, EventArgs e)
        {
            try {
                if (!Customer_username.Text.Equals("") && !Customer_useremail.Text.Equals("") && !Customer_useraddress.Text.Equals(""))
                {
                    conn = new SqlConnection(loc);
                    conn.Open();
                    String query = "insert into Customer(Name,Email,Address)values(@Name,@Email,@Address)";
                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Name", Customer_username.Text);
                    cmd.Parameters.AddWithValue("@Email", Customer_useremail.Text);
                    cmd.Parameters.AddWithValue("@Address", Customer_useraddress.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Client Data is Stored in the Portal ");
                    Customer_useraddress.Text = "";
                    Customer_useremail.Text = "";
                    Customer_username.Text = "";
                    userid_rental.Text = "";
                }
                else
                {
                    MessageBox.Show("Here you need to fill the details ");
                }


            }
            catch (Exception Ex) {
                MessageBox.Show(Ex.Message);
            }
            
        }

        // code for deleting customer

        private void Customer_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!userid_rental.Text.Equals("") && !Customer_username.Text.Equals("") && !Customer_useremail.Text.Equals("") && !Customer_useraddress.Text.Equals(""))
                {
                    conn = new SqlConnection(loc);
                    conn.Open();
                    String query = "delete from  Customer where userID=@userID";
                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(userid_rental.Text));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Client Data is removed  in the Portal ");
                    Customer_useraddress.Text = "";
                    Customer_useremail.Text = "";
                    Customer_username.Text = "";
                    userid_rental.Text = "";
                }
                else
                {
                    MessageBox.Show("Here you need to select the details ");
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }


        }

        // code for updating customer

        private void Customer_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (!userid_rental.Text.Equals("") && !Customer_username.Text.Equals("") && !Customer_useremail.Text.Equals("") && !Customer_useraddress.Text.Equals(""))
                {
                    conn = new SqlConnection(loc);
                    conn.Open();


                    String query = "update Customer set Name=@Name,Email=@Email,Address=@Address where userID=@userID";
                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(userid_rental.Text));
                    cmd.Parameters.AddWithValue("@Name", Customer_username.Text);
                    cmd.Parameters.AddWithValue("@Email", Customer_useremail.Text);
                    cmd.Parameters.AddWithValue("@Address", Customer_useraddress.Text);


                    
                    
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Client Data is Updated  in the Portal ");
                    Customer_useraddress.Text = "";
                    Customer_useremail.Text = "";
                    Customer_username.Text = "";
                    userid_rental.Text = "";
                }
                else
                {
                    MessageBox.Show("Here you need to select the details ");
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        // code for issuing movie

        private void issuemovie_rental_Click(object sender, EventArgs e)
        {
            try
            {
                if (!userid_rental.Text.Equals("") && !Customer_username.Text.Equals("") && !Customer_useremail.Text.Equals("") && !Customer_useraddress.Text.Equals(""))
                {
                    conn = new SqlConnection(loc);
                    conn.Open();

                    String query = "insert into Booking(userID,VideoID,dateIssue,dateReturn)values(@userID,@videoID,@dateIssue,@dateReturn)";

                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(userid_rental.Text));
                    cmd.Parameters.AddWithValue("@videoID", Convert.ToInt32(videoid_rental.Text));
                    cmd.Parameters.AddWithValue("@dateIssue", dateIssue.Text);
                    cmd.Parameters.AddWithValue("@dateReturn", dateReturn.Text);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Video is issued on the rent");
                    Customer_useraddress.Text = "";
                    Customer_useremail.Text = "";
                    Customer_username.Text = "";
                    userid_rental.Text = "";
                    textBox_copies.Text = "";
                    textBox_plot.Text = "";
                    textBox_production.Text = "";
                    textBox_stars.Text = "";
                    textBox_video_name.Text = "";
                    textBox_year.Text = "";

                }
                else
                {
                    MessageBox.Show("Here you need to fill the details ");
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }


        }

        // retrun movie code

        private void returnmovie_rental_Click(object sender, EventArgs e)
        {
            try { 
            if (!userid_rental.Text.Equals("") && videoid_rental.Text.Equals("") )
            {

                    DataTable tbl = new DataTable();

                    conn = new SqlConnection(loc);

                    conn.Open();

                    cmd = new SqlCommand("select * from video where videoID="+Convert.ToInt32(videoid_rental.Text)+"", conn);

                    DReader = cmd.ExecuteReader();

                    tbl.Load(DReader);

                    conn.Close();

                    int cost=Convert.ToInt32(tbl.Rows[0]["Cost"].ToString());




                    conn = new SqlConnection(loc);
                conn.Open();

                String query = "update Booking set userID=@userID,VideoID=@videoID,dateIssue=@dateIssue,dateReturn=@dateReturn where bookID=@bookID";

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@bookID", bookID);
                cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(userid_rental.Text));
                cmd.Parameters.AddWithValue("@videoID", Convert.ToInt32(videoid_rental.Text));
                cmd.Parameters.AddWithValue("@dateIssue", dateIssue.Text);
                cmd.Parameters.AddWithValue("@dateReturn","Booked");

                cmd.ExecuteNonQuery();
                conn.Close();



                    DateTime current_date = DateTime.Now;

                    //convert the old date from string to Date fromat
                    DateTime prev_date = Convert.ToDateTime(dateIssue.Text);


                    //get the difference in the days fromat
                    String Daysdiff = (current_date - prev_date).TotalDays.ToString();


                    // calculate the round off value 
                    Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));


                    MessageBox.Show("Video is returned  on the store and the Bill is= "+(cost*DaysInterval));
                Customer_useraddress.Text = "";
                Customer_useremail.Text = "";
                Customer_username.Text = "";
                userid_rental.Text = "";
                    textBox_copies.Text = "";
                    textBox_plot.Text = "";
                    textBox_production.Text = "";
                    textBox_stars.Text = "";
                    textBox_video_name.Text = "";
                    textBox_year.Text = "";


                }
                else
            {
                MessageBox.Show("Here you need to fill the details ");
            }


        }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        // delete code for movie rental

        private void Delete_rentalmovie_Click(object sender, EventArgs e)
        {
            try
            {
                if (!userid_rental.Text.Equals("") && videoid_rental.Text.Equals(""))
                {
                    conn = new SqlConnection(loc);
                    conn.Open();

                    String query = "delete Booking  where bookID=@bookID";

                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@bookID", bookID);
                    

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("issued video is removed on the store ");
                    Customer_useraddress.Text = "";
                    Customer_useremail.Text = "";
                    Customer_username.Text = "";
                    userid_rental.Text = "";
                    textBox_copies.Text = "";
                    textBox_plot.Text = "";
                    textBox_production.Text = "";
                    textBox_stars.Text = "";
                    textBox_video_name.Text = "";
                    textBox_year.Text = "";

                }
                else
                {
                    MessageBox.Show("Here you need to fill the details ");
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        // code for adding movie

        private void movie_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textBox_video_name.Text.Equals("") && !textBox_stars.Text.Equals("") && !textBox_year.Text.Equals("") && !textBox_copies.Text.Equals("") && !textBox_plot.Text.Equals(""))
                {
                    conn = new SqlConnection(loc);
                    conn.Open();
                    DateTime dateNow = DateTime.Now;

                    int Currentyear = dateNow.Year;

                    int diffYear = Currentyear - Convert.ToInt32(textBox_year.Text);
                    int cost = 0;
                    // MessageBox.Show(diff.ToString());
                    if (diffYear >= 5)
                    {
                        cost = 2;
                    }
                    if (diffYear >= 0 && diffYear < 5)
                    {
                        cost = 5;
                    }



                    String query = "insert into video(Title,Stars,Year,Copies,Cost,Plot,Production)values(@Title,@Stars,@Year,@Copies,@Cost,@Plot,@Production)";

                    
                    
                    
                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Title", textBox_video_name.Text);
                    cmd.Parameters.AddWithValue("@Stars", textBox_stars.Text);
                    cmd.Parameters.AddWithValue("@Year", textBox_year.Text);
                    cmd.Parameters.AddWithValue("@Copies", textBox_copies.Text);
                    cmd.Parameters.AddWithValue("@Cost", cost);
                    cmd.Parameters.AddWithValue("@Plot", textBox_plot.Text);
                    cmd.Parameters.AddWithValue("@Production",textBox_production.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("video is stored on the store ");
                    Customer_useraddress.Text = "";
                    Customer_useremail.Text = "";
                    Customer_username.Text = "";
                    userid_rental.Text = "";
                    textBox_copies.Text = "";
                    textBox_plot.Text = "";
                    textBox_production.Text = "";
                    textBox_stars.Text = "";
                    textBox_video_name.Text = "";
                    textBox_year.Text = "";

                }
                else
                {
                    MessageBox.Show("Here you need to fill the details ");
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        // updating movie code

        private void update_movie_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textBox_video_name.Text.Equals("") && !textBox_stars.Text.Equals("") && !textBox_year.Text.Equals("") && !textBox_copies.Text.Equals("") && !textBox_plot.Text.Equals(""))
                {
                    conn = new SqlConnection(loc);
                    conn.Open();


                    String query = "Update video set Title=@Title,Stars=@Stars,Year=@Year,Copies=@Copies,Cost=@Cost,Plot=@Plot,Production=@Production where VideoID=@videoID";

                    int cost = 0;
                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@videoID",Convert.ToInt32( videoid_rental.Text));
                    cmd.Parameters.AddWithValue("@Title", textBox_video_name.Text);
                    cmd.Parameters.AddWithValue("@Stars", textBox_stars.Text);
                    cmd.Parameters.AddWithValue("@Year", textBox_year.Text);
                    cmd.Parameters.AddWithValue("@Copies", textBox_copies.Text);
                    cmd.Parameters.AddWithValue("@Cost", cost);
                    cmd.Parameters.AddWithValue("@Plot", textBox_plot.Text);
                    cmd.Parameters.AddWithValue("@Production", textBox_production.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("video is Update on the store ");
                    Customer_useraddress.Text = "";
                    Customer_useremail.Text = "";
                    Customer_username.Text = "";
                    userid_rental.Text = "";
                    textBox_copies.Text = "";
                    textBox_plot.Text = "";
                    textBox_production.Text = "";
                    textBox_stars.Text = "";
                    textBox_video_name.Text = "";
                    textBox_year.Text = "";

                }
                else
                {
                    MessageBox.Show("Here you need to fill the details ");
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void delete_movie_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textBox_video_name.Text.Equals("") && !textBox_stars.Text.Equals("") && !textBox_year.Text.Equals("") && !textBox_copies.Text.Equals("") && !textBox_plot.Text.Equals(""))
                {
                    conn = new SqlConnection(loc);
                    conn.Open();


                    String query = "delete from video  where VideoID=@videoID";

                    int cost = 0;
                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@videoID", Convert.ToInt32(videoid_rental.Text));
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("video is removed on the store ");
                    Customer_useraddress.Text = "";
                    Customer_useremail.Text = "";
                    Customer_username.Text = "";
                    userid_rental.Text = "";

                    textBox_copies.Text = "";
                    textBox_plot.Text = "";
                    textBox_production.Text = "";
                    textBox_stars.Text = "";
                    textBox_video_name.Text = "";
                    textBox_year.Text = "";

                }
                else
                {
                    MessageBox.Show("Here you need to fill the details ");
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }


        // collecting rental info

        private void rental_info_Click(object sender, EventArgs e)
        {
            flag = "R";

            DataTable tbl = new DataTable();

            conn = new SqlConnection(loc);

            conn.Open();

            cmd = new SqlCommand("select * from Booking", conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();
            dataGridView1.DataSource = tbl;
        }

        private void rated_movie_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0, cunt = 0;
            String Title = "";

            


            DataTable tbl = new DataTable();

            conn = new SqlConnection(loc);

            conn.Open();

            cmd = new SqlCommand("select * from Video", conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();


            for (x = 0; x < tbl.Rows.Count; x++)
            {
                DataTable tblrentl = new DataTable();

                conn = new SqlConnection(loc);

                conn.Open();

                cmd = new SqlCommand("select * from Booking where VideoID=" + Convert.ToInt32(tbl.Rows[x]["VideoID"]) + "", conn);

                DReader = cmd.ExecuteReader();

                tblrentl.Load(DReader);

                conn.Close();
                if (tblrentl.Rows.Count > cunt)
                {

                    Title = tbl.Rows[x]["Title"].ToString();
                    cunt = tblrentl.Rows.Count;

                }

            }

            MessageBox.Show("Good Video is " + Title);

        }

        // best customer code

        private void best_customer_Click(object sender, EventArgs e)
        {

            int x = 0, y = 0, cunt = 0;
            String Title = "";

            DataTable tbl = new DataTable();

            conn = new SqlConnection(loc);

            conn.Open();

            cmd = new SqlCommand("select * from Customer", conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();


            for (x = 0; x < tbl.Rows.Count; x++)
            {
                DataTable tblrentl = new DataTable();

                conn = new SqlConnection(loc);

                conn.Open();

                cmd = new SqlCommand("select * from Booking where userID=" + Convert.ToInt32(tbl.Rows[x]["userID"]) + "", conn);

                DReader = cmd.ExecuteReader();

                tblrentl.Load(DReader);

                conn.Close();
                if (tblrentl.Rows.Count > cunt)
                {

                    Title = tbl.Rows[x]["Name"].ToString();
                    cunt = tblrentl.Rows.Count;

                }

            }


            MessageBox.Show("Good Customer  is " + Title);


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flag.Equals("R")) {
                bookID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                userid_rental.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                videoid_rental.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                dateIssue.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            }

            if (flag.Equals("C"))
            {
                userid_rental.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Customer_username.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Customer_useremail.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Customer_useraddress.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }

            if (flag.Equals("M"))
            {
                videoid_rental.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox_video_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox_stars.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox_year.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox_copies.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox_plot.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox_production.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }

            flag = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void user_record_Click(object sender, EventArgs e)
        {
            flag = "C";
            DataTable tbl = new DataTable();

            conn = new SqlConnection(loc);

            conn.Open();

            cmd = new SqlCommand("select * from Customer", conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();
            dataGridView1.DataSource = tbl;
        }

        private void movie_record_Click(object sender, EventArgs e)
        {
            flag = "M";
            DataTable tbl = new DataTable();

            conn = new SqlConnection(loc);

            conn.Open();

            cmd = new SqlCommand("select * from video", conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();
            dataGridView1.DataSource = tbl;
        }
    }
}
