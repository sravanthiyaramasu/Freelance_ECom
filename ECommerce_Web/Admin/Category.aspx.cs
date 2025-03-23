﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce_Web.Admin
{
	public partial class Category : System.Web.UI.Page
	{
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter sda;
		DataTable dt;
		protected void Page_Load(object sender, EventArgs e)
		{
			Session["breadCrumbTitle"] = "Manage Category";
			Session["breadCrumbPage"] = "Category";
			lblMsg.Visible = false;
			getCategories();

		}
		void getCategories()
		{
			con = new SqlConnection(Utils.getConnection());
			cmd = new SqlCommand("[dbo].[Category_Crud]", con);
			cmd.Parameters.AddWithValue("@Action","GETALL");
			cmd.CommandType = CommandType.StoredProcedure;
			sda = new SqlDataAdapter(cmd);
			dt = new DataTable();
			sda.Fill(dt);
			rCategory.DataSource = dt;
			rCategory.DataBind();
		}


        protected void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
			string actionName = string.Empty;
			string imagepath = string.Empty;
			string fileExtension = string.Empty;
			bool isValidToExecute = false;
			int categoryId = Convert.ToInt32(hfCategoryId.Value);
			con = new SqlConnection(Utils.getConnection());
			cmd = new SqlCommand("[dbo].[Category_Crud]", con);			
			cmd.Parameters.AddWithValue("@Action", categoryId == 0 ? "INSERT" : "UPDATE");
			cmd.Parameters.AddWithValue("@CategoryId", categoryId);
			cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text.Trim());
			cmd.Parameters.AddWithValue("@IsActive", cbIsActive.Checked);
			if(fuCategoryImage.HasFile)
			{
				if(Utils.isValidExtension(fuCategoryImage.FileName))
				{
					string newImageName = Utils.getUniqueId();
					fileExtension = Path.GetExtension(fuCategoryImage.FileName);
					imagepath = "Images/Category/" + newImageName.ToString() + fileExtension;
					fuCategoryImage.PostedFile.SaveAs(Server.MapPath(imagepath));
					cmd.Parameters.AddWithValue("@CategoryImageUrl", imagepath);
					isValidToExecute = true;
				}
				else
				{
					lblMsg.Visible = true;
					lblMsg.Text = "please select .jpg, .jpeg or .png image";
					lblMsg.CssClass = "alert alert-danger";
					isValidToExecute= false;
				}
			}
			else
			{
				isValidToExecute = true;
			}
			if (isValidToExecute)
			{
				cmd.CommandType = CommandType.StoredProcedure;
				try
				{
					con.Open();
					cmd.ExecuteNonQuery();
					actionName = categoryId == 0 ? "inserted" : "updated";
					lblMsg.Visible = true;
					lblMsg.Text = "Category"+" " + actionName +" "+ "successfully!";
					lblMsg.CssClass = "alert alert-success";
					getCategories();
					clear();
				}
				catch (Exception ex)
				{
					lblMsg.Visible = true;
					lblMsg.Text = "Error-" + ex.Message;
					lblMsg.CssClass = "alert alert-danger";
				}
				finally { con.Close(); }
			}
		}

		protected void btnClear_Click(object sender, EventArgs e)
		{
			clear();
		}
		void clear()
		{
			txtCategoryName.Text = string.Empty;
			cbIsActive.Checked = false;
			hfCategoryId.Value = "0";
			btnAddOrUpdate.Text = "Add";
			imagePreview.ImageUrl = string.Empty;

		}

		protected void rCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			lblMsg.Visible = false;
			if (e.CommandName == "edit")
			{
				con = new SqlConnection(Utils.getConnection());
				cmd = new SqlCommand("[dbo].[Category_Crud]", con);
				cmd.Parameters.AddWithValue("@Action", "GETBYID");
				cmd.Parameters.AddWithValue("@CategoryId", e.CommandArgument);
				cmd.CommandType = CommandType.StoredProcedure;
				sda = new SqlDataAdapter(cmd);
				dt = new DataTable();
				sda.Fill(dt);
				txtCategoryName.Text = dt.Rows[0]["CategoryName"].ToString();
				cbIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
				imagePreview.ImageUrl = string.IsNullOrEmpty(dt.Rows[0]["CategoryImageUrl"].ToString()) ? "../Images/No_image.png" : string.Format("../{0}", dt.Rows[0]["CategoryImageUrl"]);
				imagePreview.Height = 200;
				imagePreview.Width = 200;
				hfCategoryId.Value = dt.Rows[0]["CategoryId"].ToString();
				btnAddOrUpdate.Text = "Update";
			}
			else if (e.CommandName == "delete")
			{
				con = new SqlConnection(Utils.getConnection());
				cmd = new SqlCommand("[dbo].[Category_Crud]", con);
				cmd.Parameters.AddWithValue("@Action", "DELETE");
				cmd.Parameters.AddWithValue("@CategoryId", e.CommandArgument);
				cmd.CommandType = CommandType.StoredProcedure;
				try
				{
					con.Open();
					cmd.ExecuteNonQuery();					
					lblMsg.Visible = true;
					lblMsg.Text = "Category deleted successfully!";
					lblMsg.CssClass = "alert alert-success";
					getCategories();
					
				}
				catch (Exception ex)
				{
					lblMsg.Visible = true;
					lblMsg.Text = "Error-" + ex.Message;
					lblMsg.CssClass = "alert alert-danger";
				}
				finally { con.Close(); }

			}
		}
	}
}