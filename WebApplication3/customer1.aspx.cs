using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class customer1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["milestone3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("ShowProductsbyPrice", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            //IF the output is a table, then we can read the records one at a time
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            TableRow tr = new TableRow();
            TableCell tc6 = new TableCell();
            tc6.Text = "Serial no.";
            tr.Cells.Add(tc6);


            TableCell tc = new TableCell();
            tc.Text = "Product";
            tr.Cells.Add(tc);
            TableCell tc1 = new TableCell();
            tc1.Text = "Price";
            tr.Cells.Add(tc1);
            TableCell tc2 = new TableCell();
            tc2.Text = "color";
            tr.Cells.Add(tc2);
            TableCell tc3 = new TableCell();
            tc3.Text = "category";
            tr.Cells.Add(tc3);
            TableCell tc5 = new TableCell();
            tc5.Text = "available";
            tr.Cells.Add(tc5);


            TableCell tc4 = new TableCell();
            tc4.Text = "discription";
            tr.Cells.Add(tc4);



            Table1.Rows.Add(tr);
            int row = 1;




            while (rdr.Read())

            {
                TableRow trr = new TableRow();


                //Get the value of the attribute name in the Company table
                string ProductName = rdr.GetString(rdr.GetOrdinal("product_name"));
                //Get the value of the attribute field in the Company table
                decimal Price = rdr.GetDecimal(rdr.GetOrdinal("final_price"));
                int serialno = rdr.GetInt32(rdr.GetOrdinal("serial_no"));
                string color = rdr.GetString(rdr.GetOrdinal("color"));
                string description = rdr.GetString(rdr.GetOrdinal("product_description"));
                string category = rdr.GetString(rdr.GetOrdinal("category"));
                bool available = rdr.GetBoolean(rdr.GetOrdinal("available"));






                Label lbl_serial = new Label();
                lbl_serial.Text = serialno +"";
                lbl_serial.ID = "s" + row;
                //form1.Controls.Add(lbl_ProductName);
                TableCell tcc6 = new TableCell();
                tcc6.Text = lbl_serial.Text;
                trr.Cells.Add(tcc6);




                //Create a new label and add it to the HTML form
                Label lbl_ProductName = new Label();
                lbl_ProductName.Text = ProductName + "&nbsp;&nbsp;&nbsp;&nbsp;";
               
                //form1.Controls.Add(lbl_ProductName);
                TableCell tcc = new TableCell();
                tcc.Text = lbl_ProductName.Text;
                trr.Cells.Add(tcc);










                Label lbl_price = new Label();
                lbl_price.Text = Price + "&nbsp;&nbsp;&nbsp;&nbsp;";

                //form1.Controls.Add(lbl_price);
                TableCell tcc1 = new TableCell();
                tcc1.Text = lbl_price.Text;
                trr.Cells.Add(tcc1);



                Label lbl_color = new Label();
                lbl_color.Text = color + "&nbsp;&nbsp;&nbsp;&nbsp;";
                // form1.Controls.Add(lbl_color);

                TableCell tcc2 = new TableCell();
                tcc2.Text = lbl_color.Text;
                trr.Cells.Add(tcc2);

                Label lbl_category = new Label();
                lbl_category.Text = category + "&nbsp;&nbsp;&nbsp;&nbsp;";
                //form1.Controls.Add(lbl_category);
                TableCell tcc3 = new TableCell();
                tcc3.Text = lbl_category.Text;
                trr.Cells.Add(tcc3);




                Label lbl_available = new Label();
                lbl_available.Text = available+"";
                //form1.Controls.Add(lbl_available);
                lbl_available.ID = "a" + row;
                TableCell tcc4 = new TableCell();
                tcc4.Text = lbl_available.Text;
                trr.Cells.Add(tcc4);





                Label lbl_description = new Label();
                lbl_description.Text = description + "&nbsp;&nbsp;&nbsp;&nbsp;";
                //form1.Controls.Add(lbl_description);
                TableCell tcc5 = new TableCell();
                tcc5.Text = lbl_description.Text;
                trr.Cells.Add(tcc5);



                
                TableCell tcc7 = new TableCell();
                trr.Cells.Add(tcc7);
               

                 
                TableCell tcc8 = new TableCell();
                trr.Cells.Add(tcc8);

                TableCell tcc9 = new TableCell();
                trr.Cells.Add(tcc9);

                TableCell tcc10 = new TableCell();
                trr.Cells.Add(tcc10);



                Table1.Rows.Add(trr);










                row++;






                //string field1 = (string)(Session["field1"]);
               // Response.Write(field1);
            }




            for (int j = 1; j < row; j++)
            {

                Button b_addcart = new Button();
                b_addcart.Text = "add to cart";
                b_addcart.ID = "a" + j;
                b_addcart.Click += new EventHandler(this.addBtn_Click);
                Table1.Rows[j].Cells[7].Controls.Add(b_addcart);


                Button b_removecart = new Button();
                b_removecart.Text = "remove from cart";
                b_removecart.ID = "r" + j;

                b_removecart.Click += new EventHandler(this.removeBtn_Click);
                Table1.Rows[j].Cells[8].Controls.Add(b_removecart);

                Button b_addwish = new Button();
                b_addwish.Text = "add product to wishlist";

                b_addwish.ID = "w1" + j;
                TextBox t_addwish = new TextBox();
                t_addwish.ID = "ta" + j;
               
                b_addwish.Click += new EventHandler(this.b_addwish);
                Table1.Rows[j].Cells[9].Controls.Add(b_addwish);
                Table1.Rows[j].Cells[9].Controls.Add(t_addwish);


                Button b_removewish = new Button();
                b_removewish.Text = "Remove product from  wishlist";

                b_removewish.ID = "w2" + j;

                b_removewish.Click += new EventHandler(this.b_removewish);
                TextBox t_removewish = new TextBox();
                t_removewish.ID = "tr" + j;
                Table1.Rows[j].Cells[10].Controls.Add(t_removewish);

                Table1.Rows[j].Cells[10].Controls.Add(b_removewish);
                Table1.Rows[j].Cells[10].Controls.Add(t_removewish);






            }






           


            for (int j = 0; j < row; j++)
            {

                Table1.Rows[j].Cells[0].Visible = false;


            }

            for (int j = 0; j < row; j++)
            {

                Table1.Rows[j].Cells[5].Visible = false;


            }



        }

        protected void b_removewish(object sender, EventArgs e)

        {


            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["milestone3"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("removefromWishlist", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;




            Button button = (Button)sender;
            char buttonId = button.ID[2];

            //int numrow = (int)(buttonId - '0');
            int numrow = System.Globalization.CharUnicodeInfo.GetDecimalDigitValue(buttonId);

            string serial = (Table1.Rows[numrow].Cells[0]).Text;
            string id = "tr" + numrow;

            TextBox n = (TextBox)FindControl(id);
            string name = n.Text;

            int serialf = 1 * Convert.ToInt32(serial);

            string user = (string)(Session["currentuser"]);


            cmd.Parameters.Add(new SqlParameter("@customername", user));
            cmd.Parameters.Add(new SqlParameter("@serial", serialf));
            cmd.Parameters.Add(new SqlParameter("@wishlistname", name));
            if (string.IsNullOrWhiteSpace(name))
            {
                Response.Write("Please enter the name of wishlist you want to remove from it the product");

            }
            else
            {




                //Executing the SQLCommand
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }





















        }

        protected void b_addwish(object sender, EventArgs e)
        {


            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["milestone3"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("AddtoWishlist", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;




            Button button = (Button)sender;
            char buttonId = button.ID[2];

            //int numrow = (int)(buttonId - '0');
            int numrow = System.Globalization.CharUnicodeInfo.GetDecimalDigitValue(buttonId);

            string serial = (Table1.Rows[numrow].Cells[0]).Text;
            string id = "ta" + numrow;

            TextBox n = (TextBox)FindControl(id);
            string name = n.Text;

            int serialf = 1 * Convert.ToInt32(serial);

            string user = (string)(Session["currentuser"]);


            cmd.Parameters.Add(new SqlParameter("@customername", user));
            cmd.Parameters.Add(new SqlParameter("@serial", serialf));
            cmd.Parameters.Add(new SqlParameter("@wishlistname", name));
            if (string.IsNullOrWhiteSpace(name))
            {
                Response.Write("Please enter the name of wish list you want to add  from it the product");

            }
            else
            {




                try
                {

                    //Executing the SQLCommand
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    Response.Write("you have already added this product on this wishlist before");
                }

            }





        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["milestone3"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("addToCart", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;




            Button button = (Button)sender;
            char buttonId = button.ID[1];

            //int numrow = (int)(buttonId - '0');
            int numrow = System.Globalization.CharUnicodeInfo.GetDecimalDigitValue(buttonId);

            string serial = (Table1.Rows[numrow].Cells[0]).Text;

            string avaiable = (Table1.Rows[numrow].Cells[5]).Text;

            int serialf = 1 * Convert.ToInt32(serial);

            string user = (string)(Session["currentuser"]);


            cmd.Parameters.Add(new SqlParameter("@customername", user));
            cmd.Parameters.Add(new SqlParameter("@serial", serialf));


            try
            {

                if (avaiable.ToString().Equals("False"))
                {
                    Response.Write("This product is not available");
                }




                else
                {
                    //Executing the SQLCommand
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch
            {
                Response.Write("you have already added this product before");
            }




        }

        protected void removeBtn_Click(object sender, EventArgs e)
        {
           


            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["milestone3"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("removefromCart", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;




            Button button = (Button)sender;
            char buttonId = button.ID[1];

            //int numrow = (int)(buttonId - '0');
            int numrow = System.Globalization.CharUnicodeInfo.GetDecimalDigitValue(buttonId);

           string serial = (Table1.Rows[numrow].Cells[0]).Text;


            int serialf = 1 * Convert.ToInt32(serial);


            string user = (string)(Session["currentuser"]);


            cmd.Parameters.Add(new SqlParameter("@customername", user));
            cmd.Parameters.Add(new SqlParameter("@serial", serialf));
           

            //Executing the SQLCommand
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();












        }


        protected void createw_Click(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["milestone3"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("createWishlist", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            string wishlistname = lwish.Text;
            string user = (string)(Session["currentuser"]);


            cmd.Parameters.Add(new SqlParameter("@customername", user));
            cmd.Parameters.Add(new SqlParameter("@name", wishlistname));
           


            if (string.IsNullOrWhiteSpace(wishlistname) )
            {
                Response.Write("Please enter the name");

            }
            else
            {


                try
                {

                    //Executing the SQLCommand
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    Response.Write("you have already entered this name before");
                }



            }

        }

        protected void creditadd_Click(object sender, EventArgs e)
        {
            // Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["milestone3"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("AddCreditCard", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            string creditno_ = creditno.Text;
            string cvv_ = cvv.Text;
            string date_ = expirydate.Text;
            string user = (string)(Session["currentuser"]);


            cmd.Parameters.Add(new SqlParameter("@customername", user));
            cmd.Parameters.Add(new SqlParameter("@creditcardnumber", creditno_));
            cmd.Parameters.Add(new SqlParameter("@expirydate", date_));
            cmd.Parameters.Add(new SqlParameter("@cvv", cvv_));



            if (string.IsNullOrWhiteSpace(creditno_) || string.IsNullOrWhiteSpace(cvv_) || string.IsNullOrWhiteSpace(date_))
            {
                Response.Write("one of the input is empty ");

            }
            else
            {



                try
                {

                    //Executing the SQLCommand
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    Response.Write("you have already entered this creidt card before");
                }



            }






        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Response.Redirect(".aspx", true);
        }
    }

}
    