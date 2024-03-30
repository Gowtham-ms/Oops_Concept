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
    public partial class UserRegistration : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Server=.; Initial Catalog=MySampleDB; Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtName.Text;
            string email = txtEmail.Text;
            string dob = txtDOB.Text;
            conn.Open();
            string query = "Insert into Employee (EmployeeName,Email,DOB) values ('" + username + "','" + email + "','" + dob + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}