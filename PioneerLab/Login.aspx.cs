using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;

// Token: 0x02000010 RID: 16
public class Login : Page
{
	// Token: 0x0600008D RID: 141 RVA: 0x00006330 File Offset: 0x00004530
	protected void Page_Load(object sender, EventArgs e)
	{
		this.ddlUserType.Items[0].Attributes.CssStyle.Add("margin-right", "100px");
		if (!base.IsPostBack)
		{
			this.Session.Abandon();
			this.GetAllADMDatabasesDB();
			this.ddlDatabases.DataBind();
			this.ddlDatabases.SelectedIndex = 0;
			this.ddlUserType.SelectedIndex = 0;
		}
		//string text = "";
		//new AppSettingsDB().CheckActivation(out text);
	}

    // Token: 0x0600008E RID: 142 RVA: 0x000063B8 File Offset: 0x000045B8
    protected void loginButton_ServerClick(object sender, EventArgs e)
    {
        this.Session["LoggedDatabaseId"] = this.ddlDatabases.SelectedValue;
        this.Session["DataBaseName"] = this.GetADMDatabasesDBName();
        DatabasesDB databasesDB = new DatabasesDB();
        this.lblerror.Visible = false;
        AdminDB adminDB = new AdminDB();
        List<ADMUsers> aDMUsers = adminDB.UserLogin(this.txtUser.Value.Trim(), CryptoHelper.Encrypt(this.txtPass.Value, "act123"), Convert.ToInt32(this.ddlUserType.SelectedValue));
        if (aDMUsers.Count <= 0)
        {
            this.lblerror.Text = "Invalid Credentials";
            this.lblerror.Visible = true;
            this.txtPass.Value = "";
            return;
        }
        this.Session["CurrentUser"] = aDMUsers[0];
        this.Session["AcademicYear"] = databasesDB.GetByDesc(this.ddlDatabases.SelectedItem.Text);
        this.Session["LoggedDatabaseId"] = this.ddlDatabases.SelectedValue;
        this.Session["UserType"] = 1;
        this.Session["UserId"] = aDMUsers[0].UserID;
        this.Session["DataBaseName"] = this.GetADMDatabasesDBName();
        Convert.ToInt32(this.Session["AcademicYear"]);
        DateTime date = DateTime.Now.Date;
        if (this.Session["requsedurl"] != null)
        {
            string url = this.Session["requsedurl"].ToString();
            this.Session["requsedurl"] = null;
            base.Response.Redirect(url);
            return;
        }
        if (base.Request["redUri"] != null)
        {
            base.Response.Redirect(base.Request["redUri"]);
            return;
        }
        base.Response.Redirect("Default.aspx");
    }

    // Token: 0x0600008F RID: 143 RVA: 0x0000269C File Offset: 0x0000089C
    protected void ddlDatabases_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.Session["LoggedDatabaseId"] = this.ddlDatabases.SelectedValue;
		this.Session["DataBaseName"] = this.GetADMDatabasesDBName();
	}

	// Token: 0x06000090 RID: 144 RVA: 0x000065D8 File Offset: 0x000047D8
	public bool GetAllADMDatabasesDB()
	{
		SqlConnection sqlConnection = new SqlConnection();
		sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AdminDB"].ToString();
		string cmdText = "select * from ADMDatabases order by DatabaseId desc ";
		SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
		bool result;
		try
		{
			sqlConnection.Open();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(this.dataTable);
			this.ddlDatabases.DataSource = this.dataTable;
			this.ddlDatabases.DataBind();
			sqlConnection.Close();
			sqlDataAdapter.Dispose();
			result = true;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00006674 File Offset: 0x00004874
	public string GetADMDatabasesDBName()
	{
		string result = "";
		SqlConnection sqlConnection = new SqlConnection();
		sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AdminDB"].ToString();
		string cmdText = " select DataBaseName from ADMDatabases where DatabaseId=@DatabaseId";
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		int num = int.Parse(this.Session["LoggedDatabaseId"].ToString());
		sqlCommand.Parameters.AddWithValue("@DatabaseId", num);
		try
		{
			sqlConnection.Open();
			object obj = sqlCommand.ExecuteScalar();
			if (obj != null)
			{
				result = obj.ToString();
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
		return result;
	}

	// Token: 0x04000052 RID: 82
	private string _ConnectionStringBACK_RESTORE = ConfigurationManager.ConnectionStrings["AdminDB"].ToString();

	// Token: 0x04000053 RID: 83
	private DataTable dataTable = new DataTable();

	// Token: 0x04000054 RID: 84
	protected HtmlForm loginFrom;

	// Token: 0x04000055 RID: 85
	protected RadioButtonList ddlUserType;

	// Token: 0x04000056 RID: 86
	protected HtmlInputText txtUser;

	// Token: 0x04000057 RID: 87
	protected HtmlInputPassword txtPass;

	// Token: 0x04000058 RID: 88
	protected DropDownList ddlDatabases;

	// Token: 0x04000059 RID: 89
	protected Label lblerror;

	// Token: 0x0400005A RID: 90
	protected HtmlButton loginButton;

	// Token: 0x0400005B RID: 91
	protected ObjectDataSource DatabasesDS;
}
