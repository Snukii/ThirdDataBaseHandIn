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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            try
            {
                conn.Open();

                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LoginProcedure";

                SqlParameter in1 = cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                in1.Direction = ParameterDirection.Input;
                in1.Value = TextBoxEmail.Text;

                SqlParameter in2 = cmd.Parameters.Add("@Password", SqlDbType.NVarChar);
                in2.Direction = ParameterDirection.Input;
                in2.Value = TextBoxPassword.Text;

                SqlParameter out1 = cmd.Parameters.Add("@ID", SqlDbType.Int);
                out1.Direction = ParameterDirection.Output;

                SqlParameter returnval = cmd.Parameters.Add("return_value", SqlDbType.Int);
                returnval.Direction = ParameterDirection.ReturnValue;

                rdr = cmd.ExecuteReader();
                rdr.Close();

                Session["ID"] = Convert.ToString(cmd.Parameters["@ID"].Value);

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["ID"] = null;
        }
    }
}