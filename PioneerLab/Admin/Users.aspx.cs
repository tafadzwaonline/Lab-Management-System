using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Admin
{
	// Token: 0x02000007 RID: 7
	public class Users : Page
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00005CA4 File Offset: 0x00003EA4
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.LoadRoles();
				if (Convert.ToInt32(base.Request["Id"]) != 0)
				{
					this.lblUserId.Text = base.Request["Id"];
					this.DisplayData(Convert.ToInt32(base.Request["Id"]));
				}
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005D0C File Offset: 0x00003F0C
		protected void btnSave_Click(object sender, EventArgs e)
		{
			new UsersDB();
			new RolesDB();
			string text = "";
			bool flag = true;
			try
			{
				bool flag2 = false;
				for (int i = 0; i < this.chBoxRoles.Items.Count; i++)
				{
					if (this.chBoxRoles.Items[i].Selected)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					this.LblError.Text = "Select Roles";
					return;
				}
				UsersDB usersDB = new UsersDB();
				ADMUsers admusers = new ADMUsers();
				if (Convert.ToInt32(base.Request["id"]) != 0)
				{
					admusers = usersDB.GetByID(Convert.ToInt32(base.Request["id"]));
				}
				admusers.Code = this.txtCode.Text;
				admusers.EName = this.txtEnglishName.Text;
				admusers.AName = this.txtArabicName.Text;
				admusers.Address = this.txtAddress.Text;
				admusers.Tel = this.txtPhone.Text;
				admusers.Fax = this.txtFax.Text;
				admusers.Mobile = this.txtMobile.Text;
				admusers.IsActive = new bool?(this.ChkIsActive.Checked);
				if (this.txtPassword.Text != "")
				{
					admusers.Password = CryptoHelper.Encrypt(this.txtPassword.Text, "act123");
				}
				UserRolesDB userRolesDB = new UserRolesDB();
				if (Convert.ToInt32(base.Request["id"]) != 0)
				{
					if (!usersDB.Update(admusers, out text))
					{
						this.LblError.Text = "Error in updating!";
						return;
					}
					if (!userRolesDB.DeleteAllUserRoles(admusers.UserID))
					{
						this.LblError.Text = "Error in configuring roles";
						return;
					}
				}
				else if (!usersDB.Insert(admusers, out text))
				{
					this.LblError.Text = "Error in saving!";
					return;
				}
				for (int j = 0; j < this.chBoxRoles.Items.Count; j++)
				{
					if (this.chBoxRoles.Items[j].Selected && !userRolesDB.Insert(new ADMUserRoles
					{
						FKUserID = admusers.UserID,
						FKRoleID = int.Parse(this.chBoxRoles.Items[j].Value.ToString())
					}, out text))
					{
						this.LblError.Text = "Error in saving roles";
						flag = false;
					}
				}
			}
			catch
			{
				this.LblError.Text = "Error in saving!";
			}
			if (flag)
			{
				base.Response.Redirect("UsersManage.aspx");
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002212 File Offset: 0x00000412
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("UsersManage.aspx");
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002224 File Offset: 0x00000424
		private void LoadRoles()
		{
			this.chBoxRoles.DataSource = new RolesDB().GetAll();
			this.chBoxRoles.DataBind();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005FEC File Offset: 0x000041EC
		private void DisplayData(int id)
		{
			ADMUsers byID = new UsersDB().GetByID(id);
			this.txtCode.Text = byID.Code;
			this.txtEnglishName.Text = byID.EName;
			this.txtArabicName.Text = byID.AName;
			this.txtAddress.Text = byID.Address;
			this.txtPhone.Text = byID.Tel;
			this.txtFax.Text = byID.Fax;
			this.txtMobile.Text = byID.Mobile;
			this.txtPassword.Text = CryptoHelper.Decrypt(byID.Password, "act123");
			if (byID.IsActive != null)
			{
				this.ChkIsActive.Checked = byID.IsActive.Value;
			}
			if (byID.IsRemoved)
			{
				this.ChkIsRemoved.Checked = byID.IsRemoved;
			}
			List<ADMUserRoles> byUserId = new UserRolesDB().GetByUserId(byID.UserID);
			for (int i = 0; i < byUserId.Count; i++)
			{
				for (int j = 0; j < this.chBoxRoles.Items.Count; j++)
				{
					if (int.Parse(this.chBoxRoles.Items[j].Value.ToString()) == byUserId[i].FKRoleID)
					{
						this.chBoxRoles.Items[j].Selected = true;
					}
				}
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002246 File Offset: 0x00000446
		protected void GdvADMUserSettings_RowInserting(object sender, ASPxDataInsertingEventArgs e)
		{
			e.NewValues["FKUserID"] = Convert.ToInt32(base.Request["Id"]);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002272 File Offset: 0x00000472
		protected void GdvADMUserSettings_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			e.NewValues["FKUserID"] = Convert.ToInt32(base.Request["Id"]);
		}

		// Token: 0x04000022 RID: 34
		protected HtmlGenericControl ultitle;

		// Token: 0x04000023 RID: 35
		protected ASPxLabel lblUserId;

		// Token: 0x04000024 RID: 36
		protected ASPxButton btnSave;

		// Token: 0x04000025 RID: 37
		protected ASPxButton btnCancel;

		// Token: 0x04000026 RID: 38
		protected ASPxLabel LblError;

		// Token: 0x04000027 RID: 39
		protected ASPxValidationSummary ASPxValidationSummary1;

		// Token: 0x04000028 RID: 40
		protected ASPxLabel lblDate;

		// Token: 0x04000029 RID: 41
		protected ASPxTextBox txtCode;

		// Token: 0x0400002A RID: 42
		protected ASPxLabel lblNotes;

		// Token: 0x0400002B RID: 43
		protected ASPxTextBox txtEnglishName;

		// Token: 0x0400002C RID: 44
		protected ASPxLabel ASPxLabel6;

		// Token: 0x0400002D RID: 45
		protected ASPxTextBox txtArabicName;

		// Token: 0x0400002E RID: 46
		protected ASPxLabel ASPxLabel1;

		// Token: 0x0400002F RID: 47
		protected ASPxTextBox txtAddress;

		// Token: 0x04000030 RID: 48
		protected ASPxLabel ASPxLabel7;

		// Token: 0x04000031 RID: 49
		protected ASPxTextBox txtPhone;

		// Token: 0x04000032 RID: 50
		protected ASPxLabel ASPxLabel2;

		// Token: 0x04000033 RID: 51
		protected ASPxTextBox txtFax;

		// Token: 0x04000034 RID: 52
		protected ASPxLabel ASPxLabel8;

		// Token: 0x04000035 RID: 53
		protected ASPxTextBox txtMobile;

		// Token: 0x04000036 RID: 54
		protected ASPxLabel ASPxLabel3;

		// Token: 0x04000037 RID: 55
		protected ASPxTextBox txtPassword;

		// Token: 0x04000038 RID: 56
		protected ASPxLabel ASPxLabel4;

		// Token: 0x04000039 RID: 57
		protected ASPxCheckBox ChkIsActive;

		// Token: 0x0400003A RID: 58
		protected ASPxLabel ASPxLabel5;

		// Token: 0x0400003B RID: 59
		protected ASPxCheckBox ChkIsRemoved;

		// Token: 0x0400003C RID: 60
		protected ASPxLabel lblRole;

		// Token: 0x0400003D RID: 61
		protected ASPxCheckBoxList chBoxRoles;

		// Token: 0x0400003E RID: 62
		protected ASPxGridView GdvADMUserSettings;

		// Token: 0x0400003F RID: 63
		protected ObjectDataSource ADMUserSettingsDS;

		// Token: 0x04000040 RID: 64
		protected ObjectDataSource SettingsNameDS;
	}
}
