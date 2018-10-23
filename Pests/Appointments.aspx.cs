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
    public partial class Appointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["ID"] == null)
            {
                ButtonUpdate.Enabled = false;
                ButtonCreate.Enabled = false;
                ButtonDelete.Enabled = false;
            }
            UpdateGridView();
        }

        public void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select * from appointments where CustomerID = @CustomerID";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmd.Parameters["@CustomerID"].Value = int.Parse((string)Session["ID"]);

                rdr = cmd.ExecuteReader();
                GridViewPests.DataSource = rdr;
                GridViewPests.DataBind();
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

        protected void GridViewPests_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxTime.Text = GridViewPests.SelectedRow.Cells[1].Text;
            TextBoxPest.Text = GridViewPests.SelectedRow.Cells[2].Text;
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            string sqlsel = "update appointments set AppointmentTime = @AppointmentTime, Pest = @Pest where AppointmentTime = @AppointmentTime";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);
                cmd.Parameters.Add("@AppointmentTime", SqlDbType.Date);
                cmd.Parameters.Add("@Pest", SqlDbType.Int);
                cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar);

                cmd.Parameters["@AppointmentTime"].Value = Convert.ToDateTime(TextBoxTime.Text);
                cmd.Parameters["@CustomerID"].Value = int.Parse((string)Session["ID"]);
                cmd.Parameters["@Pest"].Value = int.Parse(TextBoxPest.Text);

                cmd.ExecuteNonQuery();
                UpdateGridView();
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

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "insert into appointments (AppointmentTime, Pest, CustomerID) values (@AppointmentTime, @Pest, @CustomerID)";
            //int count = 0;

            //try
            //{
            //    conn.Open();

            //    cmd = conn.CreateCommand();
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandText = "CountDays";

            //    SqlParameter in1 = cmd.Parameters.Add("@AppointmentTime", SqlDbType.DateTime);
            //    in1.Direction = ParameterDirection.Input;
            //    in1.Value = Convert.ToDateTime(TextBoxTime.Text);

            //    SqlParameter returnval = cmd.Parameters.Add("return_value", SqlDbType.Int);
            //    returnval.Direction = ParameterDirection.ReturnValue;

            //    rdr = cmd.ExecuteReader();
            //    rdr.Close();

            //    count = (int)cmd.Parameters["return_value"].Value;

            //}
            //catch (Exception ex)
            //{
            //    Label1.Text = ex.Message;
            //}
            //finally
            //{
            //    conn.Close();
            //}

            //if (count < 5)
            //{
                try
                {
                    conn.Open();

                    cmd = new SqlCommand(sqlsel, conn);
                    cmd.Parameters.Add("@AppointmentTime", SqlDbType.Date);
                    cmd.Parameters.Add("@Pest", SqlDbType.Int);
                    cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar);

                    cmd.Parameters["@AppointmentTime"].Value = Convert.ToDateTime(TextBoxTime.Text);
                    cmd.Parameters["@CustomerID"].Value = int.Parse((string)Session["ID"]);
                    cmd.Parameters["@Pest"].Value = int.Parse(TextBoxPest.Text);

                    cmd.ExecuteNonQuery();
                    UpdateGridView();
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            //} else
            //{
            //    Label1.Text = "Only 4 appointments per day is allowed";
            //}


        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            string sqlsel = "delete from appointments where AppointmentTime = @AppointmentTime";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);
                cmd.Parameters.Add("@AppointmentTime", SqlDbType.DateTime);

                cmd.Parameters["@AppointmentTime"].Value = Convert.ToDateTime(GridViewPests.SelectedRow.Cells[1].Text);

                cmd.ExecuteNonQuery();

                UpdateGridView();
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
    }
}