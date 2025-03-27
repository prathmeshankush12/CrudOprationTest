using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Productss
{
	public partial class CrudOp : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				GetProducts();
			}
		}

	    SqlConnection Con = new SqlConnection("Data Source=DESKTOP-57GEKTS;Initial Catalog=Products;Integrated Security=True;");
        protected void Btn1_Click(object sender, EventArgs e)
        {
			int ProductId = int.Parse(TextBox1.Text);
			string ProductName = TextBox2.Text;
			int CategoryId = int.Parse(TextBox3.Text);
			string CategoryName = TextBox4.Text;
			Con.Open();
			SqlCommand cmd = new SqlCommand("Insert Into products values('"+TextBox2.Text+"','"+TextBox3.Text+"','"+TextBox4.Text+"')",Con);
			cmd.ExecuteNonQuery();
			ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Insert');", true);
			Con.Close();

			TextBox1.Text = " ";
			TextBox2.Text = " ";
			TextBox3.Text = " ";
			TextBox4.Text = " ";
			GetProducts();
		}

		protected void Btn2_Click(object sender, EventArgs e)
		{
			int ProductId = int.Parse(TextBox1.Text);
			string ProductName = TextBox2.Text;
			int CategoryId = int.Parse(TextBox3.Text);
			string CategoryName = TextBox4.Text;
			Con.Open();
			SqlCommand cmd = new SqlCommand("Update products set ProductId='"+ TextBox1.Text+"', ProductName= '" + TextBox2.Text + "', CategoryId='" + TextBox3.Text + "',CategoryName='" + TextBox4.Text + "'", Con);
			cmd.ExecuteNonQuery();
			ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Update');", true);
			Con.Close();
			GetProducts();
		}

		protected void Btn3_Click(object sender, EventArgs e)
		{
			int ProductId = int.Parse(TextBox1.Text);
			string ProductName = TextBox2.Text;
			int CategoryId = int.Parse(TextBox3.Text);
			string CategoryName = TextBox4.Text;
			Con.Open();
			SqlCommand cmd = new SqlCommand("Delete products where ProductId = '" + TextBox1.Text+ "'", Con);
			cmd.ExecuteNonQuery();
			ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Delete');", true);
			Con.Close();
			GetProducts();
		}

		protected void Btn4_Click(object sender, EventArgs e)
		{
			SqlCommand cmd = new SqlCommand("Select * from products WHERE ProductId ", Con);
			cmd.Parameters.AddWithValue("ProductId ", int.Parse(TextBox1.Text));
			SqlDataAdapter d = new SqlDataAdapter(cmd);
			DataTable t = new DataTable();
			d.Fill(t);
			GridView1.DataSource = t;
			GridView1.DataBind();
		}
		void GetProducts()
		{

			SqlCommand cmd = new SqlCommand("Select * from products", Con);
			SqlDataAdapter d = new SqlDataAdapter(cmd);
			DataTable t = new DataTable();
			d.Fill(t);
			GridView1.DataSource = t;
			GridView1.DataBind();
		}
	}
}