using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.Model;
using DAL;

namespace Gridview_CRUD
{
    public partial class Gridview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            StudentInfo studentInfo = new StudentInfo()
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Course = ddlCourse.SelectedItem.Value,
                Age = Convert.ToInt32(txtAge.Text)
            };
            bool status; ;
            string data = new BLL.BLLGridviewCRUD().CreateStudent(studentInfo, out status);
            if (status)
            {
                lblMessage.Text = data.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                BindGridview();
                txtName.Text = "";
                txtEmail.Text = "";
                ddlCourse.SelectedIndex=-1;
                txtAge.Text = "";
            }
            else
            {
                lblMessage.Text = data.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void BindGridview()
        {
            object data = new BLL.BLLGridviewCRUD().ReadStudent();
            if (data is string)
            {
                lblMessage.Text = data.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                gvStudent.DataSource = data;
                gvStudent.DataBind();
            }
        }

        protected void gvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStudent.EditIndex = e.NewEditIndex;
            BindGridview();
        }

        protected void gvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudent.EditIndex = -1;
            BindGridview();
        }

        protected void gvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            StudentInfo studentInfo = new StudentInfo()
            {
                Name = ((TextBox)gvStudent.Rows[e.RowIndex].Cells[1].Controls[0]).Text,
                Email = ((TextBox)gvStudent.Rows[e.RowIndex].Cells[2].Controls[0]).Text,
                Course = ((TextBox)gvStudent.Rows[e.RowIndex].Cells[3].Controls[0]).Text,
                Age = Convert.ToInt32(((TextBox)gvStudent.Rows[e.RowIndex].Cells[4].Controls[0]).Text)
            };
            int StudentId = Convert.ToInt32(gvStudent.DataKeys[e.RowIndex].Value);
            bool status;
            string data = new BLL.BLLGridviewCRUD().UpdateStudent(studentInfo, StudentId, out status);
            if (status)
            {
                lblMessage.Text = data.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                gvStudent.EditIndex = 0;
                BindGridview();
            }
            else
            {
                lblMessage.Text = data.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string data = new BLL.BLLGridviewCRUD().DeleteStudent(Convert.ToInt32(gvStudent.DataKeys[e.RowIndex].Value), out bool status);
            if (status)
            {
                lblMessage.Text = data.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                BindGridview();
            }
            else
            {
                lblMessage.Text = data.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                gvStudent.DataBind();
            }
        }

        protected void gvStudent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find Delete button
                LinkButton btnDelete = (LinkButton)e.Row.Cells[5].Controls[2];

                btnDelete.OnClientClick =
                    "return confirm('Are you sure you want to delete this record?');";
            }
        }
    }
}