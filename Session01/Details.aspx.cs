using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Session01
{
    public partial class Details : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Server=.; Initial Catalog=MySampleDB; Integrated Security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGridView();
        }
        protected void BindGridView()
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("CrudOperations", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", "READ");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDetails.DataSource = ds;
                    gvDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                //SendMailErrorEventArgs(ex);
            }
            finally
            {
                conn.Close();
            }
        }
        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetails.EditIndex = e.NewEditIndex;
            BindGridView();
        }
        protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetails.EditIndex = -1;
            BindGridView();
        }

        protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int EmployeeID = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["EmployeeID"].ToString());
            TextBox txtEditedEmpName = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtEmployeeName");
            TextBox txtEditedEmail = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtEmail");
            TextBox txtEditedDOB = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtDOB");
            CrudOperations("UPDATE", txtEditedEmpName.Text, txtEditedEmail.Text, txtEditedDOB.Text, EmployeeID);

        }
        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int EmployeeID = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["EmployeeID"].ToString());
            CrudOperations("DELETE", "", "", "", EmployeeID);
        }
        protected void CrudOperations(string status, string EmployeeName, string Email, string DOB, int EmployeeID)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("CrudOperations", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (status == "Insert")
            {
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@DOB", DOB);
            }
            else if (status == "UPDATE")
            {
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            }
            else if (status == "DELETE")
            {
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            }
            cmd.ExecuteNonQuery();
            gvDetails.EditIndex = -1;
            conn.Close();
            BindGridView();
        }

    }
}