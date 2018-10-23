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
    public partial class Exterminator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["ID"] != "1")
            {
                ButtonUpdate.Enabled = false;
                ButtonCreate.Enabled = false;
                ButtonDelete.Enabled = false;
                ButtonAll.Enabled = false;
                ButtonID.Enabled = false;
                ButtonDay.Enabled = false;
            }

            UpdateGridView();
        }

        public void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select * from pests";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);

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
            TextBoxName.Text = GridViewPests.SelectedRow.Cells[2].Text;
            TextBoxPrice.Text = GridViewPests.SelectedRow.Cells[3].Text;
            TextBoxPicture.Text = GridViewPests.SelectedRow.Cells[4].Text;
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            string sqlsel = "update pests set Name = @Name, Price = @Price, Picture = @Picture where ID = @ID";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Price", SqlDbType.Int);
                cmd.Parameters.Add("@Picture", SqlDbType.NVarChar);

                cmd.Parameters["@ID"].Value = int.Parse(GridViewPests.SelectedRow.Cells[1].Text);
                cmd.Parameters["@Name"].Value = TextBoxName.Text;
                cmd.Parameters["@Price"].Value = int.Parse(TextBoxPrice.Text);
                cmd.Parameters["@Picture"].Value = TextBoxPicture.Text;

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
            string sqlsel = "insert into pests (Name, Price, Picture) values (@Name, @Price, @Picture)";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Price", SqlDbType.Int);
                cmd.Parameters.Add("@Picture", SqlDbType.NVarChar);

                cmd.Parameters["@Name"].Value = TextBoxName.Text;
                cmd.Parameters["@Price"].Value = int.Parse(TextBoxPrice.Text);
                cmd.Parameters["@Picture"].Value = TextBoxPicture.Text;

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

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            string sqlsel = "delete from pests where ID = @ID";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int);

                cmd.Parameters["@ID"].Value = int.Parse(GridViewPests.SelectedRow.Cells[1].Text);

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

        protected void ButtonAll_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select * from appointments";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();
                GridViewAppointments.DataSource = rdr;
                GridViewAppointments.DataBind();
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

        protected void ButtonID_Click(object sender, EventArgs e)
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

                cmd.Parameters["@CustomerID"].Value = int.Parse(TextBoxCustomerID.Text);

                rdr = cmd.ExecuteReader();
                GridViewAppointments.DataSource = rdr;
                GridViewAppointments.DataBind();
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

        protected void ButtonDay_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = localhost; integrated security = true; database = pests");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select * from appointments where AppointmentTime = @AppointmentTime";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlsel, conn);
                cmd.Parameters.Add("@AppointmentTime", SqlDbType.DateTime);

                cmd.Parameters["@AppointmentTime"].Value = Convert.ToDateTime(TextBoxDay.Text);

                rdr = cmd.ExecuteReader();
                GridViewAppointments.DataSource = rdr;
                GridViewAppointments.DataBind();
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