using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pests
{
    public partial class Home : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqlsel = "select * from Pests";

        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterWelcome.DataBind();
            Show();
        }

        public void Show()
        {

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();
                RepeaterWelcome.DataSource = rdr;
                RepeaterWelcome.DataBind();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonSignUp_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            sqlsel = "insert into Customers (FirstName, LastName, Address, Zip, City, Password, Email, Phone) values (@FirstName, @LastName, @Address, @Zip, @City, @Password, @Email, @Phone)";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Zip", SqlDbType.Int);
                cmd.Parameters.Add("@City", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);

                cmd.Parameters["@FirstName"].Value = TextBoxFirst.Text;
                cmd.Parameters["@LastName"].Value = TextBoxlast.Text;
                cmd.Parameters["@Address"].Value = TextBoxAddress.Text;
                cmd.Parameters["@Zip"].Value = int.Parse(TextBoxZip.Text);
                cmd.Parameters["@City"].Value = TextBoxCity.Text;
                cmd.Parameters["@Password"].Value = TextBoxPassword.Text;
                cmd.Parameters["@Email"].Value = TextBoxEmail.Text;
                cmd.Parameters["@Phone"].Value = TextBoxPhone.Text;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}