using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class Assignment2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-LTE8ELEI;Integrated Security=SSPI;database=ibmdb");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindgrid();
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Bindgrid();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox inempname = (TextBox)GridView1.FooterRow.FindControl("txtEname");
                TextBox insalary = (TextBox)GridView1.FooterRow.FindControl("txtSalary");

                con.Open();
                String strcmd = "insert into Emp (empname,salary) values('" + inempname.Text + "'," + insalary.Text + ")";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Bindgrid();
                    lblMsg.BackColor = System.Drawing.Color.Green;
                    lblMsg.ForeColor = System.Drawing.Color.White;
                    lblMsg.Text = "Added Successfully";
                }
                else
                {
                    lblMsg.BackColor = System.Drawing.Color.Red;
                    lblMsg.ForeColor = System.Drawing.Color.White;
                    lblMsg.Text = "Error While Adding row";
                }
                con.Close();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Bindgrid();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string inempid = GridView1.DataKeys[e.RowIndex].Values["Empid"].ToString();
            TextBox inempname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditEname");
            TextBox insalary = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditSalary");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Emp set EmpName='" + inempname.Text + "', Salary=" + insalary.Text + " where empid=" + inempid, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {

                lblMsg.BackColor = System.Drawing.Color.Green;
                lblMsg.ForeColor = System.Drawing.Color.White;
                lblMsg.Text = "Updated Successfully";
                GridView1.EditIndex = -1;
                Bindgrid();
            }
            else
            {
                lblMsg.BackColor = System.Drawing.Color.Red;
                lblMsg.ForeColor = System.Drawing.Color.White;
                lblMsg.Text = "Error While Adding row";
            }
            con.Close();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string inempid = GridView1.DataKeys[e.RowIndex].Values["Empid"].ToString();
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete from Emp where Empid=" + inempid, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {

                lblMsg.BackColor = System.Drawing.Color.Green;
                lblMsg.ForeColor = System.Drawing.Color.White;
                lblMsg.Text = "Deleted Successfully";
                Bindgrid();
            }
            else
            {
                lblMsg.BackColor = System.Drawing.Color.Red;
                lblMsg.ForeColor = System.Drawing.Color.White;
                lblMsg.Text = "Error While Adding row";
            }
            con.Close();
        }
        protected void Bindgrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Emp", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();

                int columcount = GridView1.Rows[0].Cells.Count;
                lblMsg.Text = "No Data Found";

            }
        }
    }
}