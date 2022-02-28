using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;

namespace PioneerLab.Admin
{
	// Token: 0x02000005 RID: 5
	public class RolesLinkManage : Page
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00002170 File Offset: 0x00000370
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.GetchecksState();
				this.LoadLinksCategory();
				this.BindGrid();
				return;
			}
			if (this.Error.Visible)
			{
				this.Error.Visible = false;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004E30 File Offset: 0x00003030
		protected override void OnPreInit(EventArgs e)
		{
			base.OnPreInit(e);
			if (this.Session["PreferedLanguage"] != null && this.Session["PreferedLanguage"].ToString() == "True")
			{
				Thread.CurrentThread.CurrentCulture = new CultureInfo("ar-qa");
				Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-qa");
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002071 File Offset: 0x00000271
		protected void PanEditForm_Init(object sender, EventArgs e)
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00004EA0 File Offset: 0x000030A0
		protected void GrdLinks_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.Header)
			{
				CheckBox checkBox = (CheckBox)e.Row.FindControl("chkAllAdd");
				checkBox.Attributes.Add("onclick", string.Concat(new string[]
				{
					"CheckboxSelectAll('",
					checkBox.ClientID,
					"','2','",
					this.GrdLinks.ClientID,
					"')"
				}));
				CheckBox checkBox2 = (CheckBox)e.Row.FindControl("chkAllEdit");
				checkBox2.Attributes.Add("onclick", string.Concat(new string[]
				{
					"CheckboxSelectAll('",
					checkBox2.ClientID,
					"','3','",
					this.GrdLinks.ClientID,
					"')"
				}));
				CheckBox checkBox3 = (CheckBox)e.Row.FindControl("chkAllDelete");
				checkBox3.Attributes.Add("onclick", string.Concat(new string[]
				{
					"CheckboxSelectAll('",
					checkBox3.ClientID,
					"','4','",
					this.GrdLinks.ClientID,
					"')"
				}));
				CheckBox checkBox4 = (CheckBox)e.Row.FindControl("chkAllView");
				checkBox4.Attributes.Add("onclick", string.Concat(new string[]
				{
					"CheckboxSelectAll('",
					checkBox4.ClientID,
					"','5','",
					this.GrdLinks.ClientID,
					"')"
				}));
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				CheckBox checkBox5 = e.Row.FindControl("ChkAdd") as CheckBox;
				CheckBox checkBox6 = e.Row.FindControl("chkEdit") as CheckBox;
				CheckBox checkBox7 = e.Row.FindControl("ChkDelete") as CheckBox;
				CheckBox checkBox8 = e.Row.FindControl("ChkView") as CheckBox;
				CheckBox checkBox9 = e.Row.FindControl("chkSelectRow") as CheckBox;
				checkBox9.Attributes.Add("onclick", string.Concat(new string[]
				{
					"SelectAllRow('",
					checkBox9.ClientID,
					"',",
					(e.Row.RowIndex + 1).ToString(),
					",'",
					this.GrdLinks.ClientID,
					"')"
				}));
				Label label = (Label)e.Row.FindControl("Label1");
				int num = 0;
				int linkId = int.Parse(label.Text);
				if (!string.IsNullOrEmpty(this.ddlRoles.SelectedValue))
				{
					num = int.Parse(this.ddlRoles.SelectedValue);
				}
				if (num > 0)
				{
					RoleLinkOptionViewDB roleLinkOptionViewDB = new RoleLinkOptionViewDB();
					List<RoleLinkOptionView> byRoleIdAndLinkId = roleLinkOptionViewDB.GetByRoleIdAndLinkId(num, linkId);
					List<RoleLinkOptionView> list = byRoleIdAndLinkId.FindAll((RoleLinkOptionView rlv) => rlv.OptionID == 1);
					List<RoleLinkOptionView> list2 = byRoleIdAndLinkId.FindAll((RoleLinkOptionView rlv) => rlv.OptionID == 2);
					List<RoleLinkOptionView> list3 = byRoleIdAndLinkId.FindAll((RoleLinkOptionView rlv) => rlv.OptionID == 3);
					List<RoleLinkOptionView> list4 = byRoleIdAndLinkId.FindAll((RoleLinkOptionView rlv) => rlv.OptionID == 4);
					if (list.Count > 0)
					{
						checkBox5.Checked = true;
					}
					if (list2.Count > 0)
					{
						checkBox6.Checked = true;
					}
					if (list3.Count > 0)
					{
						checkBox7.Checked = true;
					}
					if (list4.Count > 0)
					{
						checkBox8.Checked = true;
					}
					if (checkBox5.Checked && checkBox6.Checked && checkBox7.Checked && checkBox8.Checked)
					{
						checkBox9.Checked = true;
					}
					else
					{
						checkBox9.Checked = false;
					}
					bool[] array = (bool[])this.ViewState["checks"];
					if (!checkBox5.Checked)
					{
						array[0] = checkBox5.Checked;
					}
					if (!checkBox6.Checked)
					{
						array[1] = checkBox6.Checked;
					}
					if (!checkBox7.Checked)
					{
						array[2] = checkBox7.Checked;
					}
					if (!checkBox8.Checked && array[3])
					{
						array[3] = checkBox8.Checked;
					}
					DropDownList dropDownList = (DropDownList)e.Row.FindControl("ddlOrder");
					dropDownList.DataSource = (List<string>)this.ViewState["linkCount"];
					dropDownList.DataBind();
					if (byRoleIdAndLinkId.Count > 0)
					{
						dropDownList.SelectedValue = byRoleIdAndLinkId[0].Arrange.Value.ToString();
					}
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000053B8 File Offset: 0x000035B8
		private void BindGrid()
		{
			LinksDB linksDB = new LinksDB();
			int categoryId = 0;
			int.TryParse(this.ddlLinkCategory.SelectedValue, out categoryId);
			List<ADMLinks> byFKCategoryId = linksDB.GetByFKCategoryId(categoryId);
			List<string> list = new List<string>();
			for (int i = 0; i < byFKCategoryId.Count; i++)
			{
				list.Add((i + 1).ToString());
			}
			this.ViewState["linkCount"] = list;
			this.GrdLinks.DataSource = byFKCategoryId;
			this.GrdLinks.DataBind();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00005440 File Offset: 0x00003640
		private void LoadRoles()
		{
			RolesDB rolesDB = new RolesDB();
			this.ddlRoles.DataSource = rolesDB.GetAll();
			this.ddlRoles.DataBind();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002071 File Offset: 0x00000271
		private void LoadModules()
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00005470 File Offset: 0x00003670
		private void LoadLinksCategory()
		{
			CategoryMasterDB categoryMasterDB = new CategoryMasterDB();
			this.ddlModule.DataSource = categoryMasterDB.GetAll();
			this.ddlModule.DataBind();
			this.ddlModule.Items.Insert(0, new ListItem("Select", "0"));
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000054C0 File Offset: 0x000036C0
		private void GetchecksState()
		{
			bool[] value = new bool[]
			{
				true,
				true,
				true,
				true
			};
			this.ViewState["checks"] = value;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000054F8 File Offset: 0x000036F8
		private void SetchecksState()
		{
			if (this.GrdLinks.Rows.Count > 0)
			{
				bool[] array = (bool[])this.ViewState["checks"];
				CheckBox checkBox = this.GrdLinks.HeaderRow.FindControl("chkAllAdd") as CheckBox;
				CheckBox checkBox2 = this.GrdLinks.HeaderRow.FindControl("chkAllEdit") as CheckBox;
				CheckBox checkBox3 = this.GrdLinks.HeaderRow.FindControl("chkAllDelete") as CheckBox;
				CheckBox checkBox4 = this.GrdLinks.HeaderRow.FindControl("chkAllView") as CheckBox;
				checkBox.Checked = array[0];
				checkBox2.Checked = array[1];
				checkBox3.Checked = array[2];
				checkBox4.Checked = array[3];
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000055C4 File Offset: 0x000037C4
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			new RolesDB();
			this.Error.Visible = false;
			this.LblError.Text = "";
			int num = 0;
			int.TryParse(this.ddlRoles.SelectedValue, out num);
			if (num == 0)
			{
				this.LblError.Text = "Select Role First";
				return;
			}
			try
			{
				foreach (object obj in this.GrdLinks.Rows)
				{
					GridViewRow gridViewRow = (GridViewRow)obj;
					CheckBox checkBox = gridViewRow.FindControl("ChkAdd") as CheckBox;
					CheckBox checkBox2 = gridViewRow.FindControl("chkEdit") as CheckBox;
					CheckBox checkBox3 = gridViewRow.FindControl("ChkDelete") as CheckBox;
					CheckBox checkBox4 = gridViewRow.FindControl("ChkView") as CheckBox;
					DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddlOrder");
					TextBox textBox = gridViewRow.FindControl("TxtLinkName") as TextBox;
					Label label = (Label)gridViewRow.FindControl("Label1");
					int roleLinkId = 0;
					int num2 = int.Parse(label.Text);
					RoleLinksDB roleLinksDB = new RoleLinksDB();
					List<ADMRoleLink> roleLinkByRoleAndLink = roleLinksDB.GetRoleLinkByRoleAndLink(num, num2);
					ADMLinks byID = new LinksDB().GetByID(num2);
					byID.LinksEName = textBox.Text;
					new LinksDB().Update(byID);
					if (roleLinkByRoleAndLink.Count > 0)
					{
						roleLinkId = roleLinkByRoleAndLink[0].RoleLinkID;
					}
					RoleLinkOptionDB roleLinkOptionDB = new RoleLinkOptionDB();
					if (checkBox.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
					{
						string text = "";
						if (roleLinkByRoleAndLink.Count < 1)
						{
							ADMRoleLink admroleLink = new ADMRoleLink();
							admroleLink.FKLinkID = num2;
							admroleLink.FKRoleID = num;
							admroleLink.Arrange = new int?(int.Parse(dropDownList.SelectedValue));
							roleLinksDB.Insert(admroleLink, out text);
							roleLinkId = admroleLink.RoleLinkID;
						}
						else
						{
							roleLinkByRoleAndLink[0].Arrange = new int?(int.Parse(dropDownList.SelectedValue));
							roleLinksDB.Update(roleLinkByRoleAndLink[0], out text);
						}
					}
					roleLinkOptionDB.SaveLinkOptions(roleLinkId, checkBox.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked);
				}
			}
			catch
			{
			}
			this.LblError.Text = "Saved Successfully";
			this.LblError.Visible = true;
			this.Error.Visible = true;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00005884 File Offset: 0x00003A84
		protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
		{
			RolesDB rolesDB = new RolesDB();
			this.ddlRoles.DataSource = rolesDB.GetByModuleId(int.Parse(this.ddlModule.SelectedValue));
			this.ddlRoles.DataBind();
			this.GetLinkCategoryByModule();
			this.BindGrid();
			this.SetchecksState();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000021A6 File Offset: 0x000003A6
		protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.BindGrid();
			this.SetchecksState();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000021B4 File Offset: 0x000003B4
		protected void ddlLinkCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.LblError.Text = "";
			this.BindGrid();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000058D8 File Offset: 0x00003AD8
		private void GetLinkCategoryByModule()
		{
			this.ddlLinkCategory.DataSource = from e in new LinksCategoryDB().GetByCategoryMasterId(int.Parse(this.ddlModule.SelectedValue))
			orderby e.LinkCategoryID
			select e;
			this.ddlLinkCategory.DataBind();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000021CC File Offset: 0x000003CC
		protected void BtnPageCancel_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("../Default.aspx");
		}

		// Token: 0x0400000E RID: 14
		protected HtmlGenericControl ultitle;

		// Token: 0x0400000F RID: 15
		protected ASPxButton btnSave;

		// Token: 0x04000010 RID: 16
		protected ASPxButton btnCancel;

		// Token: 0x04000011 RID: 17
		protected new HtmlGenericControl Error;

		// Token: 0x04000012 RID: 18
		protected ASPxLabel LblError;

		// Token: 0x04000013 RID: 19
		protected DropDownList ddlModule;

		// Token: 0x04000014 RID: 20
		protected DropDownList ddlRoles;

		// Token: 0x04000015 RID: 21
		protected DropDownList ddlLinkCategory;

		// Token: 0x04000016 RID: 22
		protected GridView GrdLinks;

		// Token: 0x04000017 RID: 23
		protected ObjectDataSource UsersDS;
	}
}
