using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Web;

namespace PioneerLab.Pages
{
	// Token: 0x02000017 RID: 23
	public class ContractorInfo : Page
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x00007DD0 File Offset: 0x00005FD0
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				int num = Convert.ToInt32(base.Request["id"]);
				this.lblMasterId.Text = num.ToString();
				this.flContractorsList.DataBind();
				if (num == 0)
				{
					ContractorsListDB contractorsListDB = new ContractorsListDB();
					this.txtCode.Text = contractorsListDB.GetNewSerial();
				}
			}
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/ContractorInfoManage.aspx", long.Parse(this.Session["UserId"].ToString()));
			foreach (UserLinkOptionsView userLinkOptionsView in allOptionsForLink)
			{
				if (userLinkOptionsView.OptionEName == "Add")
				{
					this.lblAdd.Text = "True";
				}
				if (userLinkOptionsView.OptionEName == "Edit")
				{
					this.lblEdite.Text = "True";
				}
				if (userLinkOptionsView.OptionEName == "Delete")
				{
					this.lblDelete.Text = "True";
				}
				if (userLinkOptionsView.OptionEName == "View")
				{
					this.lblView.Text = "True";
				}
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00007F28 File Offset: 0x00006128
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				long num = Convert.ToInt64(this.lblMasterId.Text);
				if (num > 0L)
				{
					if (this.lblEdite.Text == "True")
					{
						this.ContractorsListDS.Update();
						this.Clear();
					}
					else
					{
						this.BtnSave.Enabled = false;
						this.divmsg.Attributes["class"] = "alert alert-info";
						this.LblError.ForeColor = Color.Red;
						this.LblError.Text = "You dont have permission to Update";
					}
				}
				else if (this.lblAdd.Text == "True")
				{
					this.ContractorsListDS.Insert();
					this.Clear();
				}
				else
				{
					this.BtnSave.Enabled = false;
					this.divmsg.Attributes["class"] = "alert alert-info";
					this.LblError.ForeColor = Color.Red;
					this.LblError.Text = "You dont have permission to Add";
				}
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000028EB File Offset: 0x00000AEB
		protected void ContractorsListDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetMasterEntity(0);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00002904 File Offset: 0x00000B04
		protected void ContractorsListDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been saved successfully!";
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00008084 File Offset: 0x00006284
		protected void ContractorsListDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int masterID = Convert.ToInt32(this.lblMasterId.Text);
			e.InputParameters["entity"] = this.GetMasterEntity(masterID);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000080BC File Offset: 0x000062BC
		private ContractorsList GetMasterEntity(int MasterID)
		{
			ContractorsList contractorsList;
			if (MasterID > 0)
			{
				contractorsList = new ContractorsListDB().GetByID(MasterID);
			}
			else
			{
				contractorsList = new ContractorsList();
			}
			contractorsList.ContractorCode = this.txtCode.Text;
			contractorsList.ContractorName = this.txtName.Text;
			contractorsList.ContractorCarrier = this.txtContractorCarrier.Text;
			contractorsList.Location = this.txtLocation.Text;
			contractorsList.GMName = this.txtGMName.Text;
			contractorsList.MobileNumber = this.txtMobileNumber.Text;
			contractorsList.PhoneNumber = this.txtTel.Text;
			contractorsList.FaxNumber = this.txtFax.Text;
			contractorsList.Email = this.txtEmail.Text;
			contractorsList.website = this.txtwebsite.Text;
			contractorsList.Address = this.txtAddress.Text;
			contractorsList.IsLocked = this.IsLocked.Checked;
			contractorsList.ContractorType = (int?)this.cmbContractorType.Value;
			return contractorsList;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00002940 File Offset: 0x00000B40
		protected void ContractorsListDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000297C File Offset: 0x00000B7C
		protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("ContractorInfoManage.aspx");
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000081C4 File Offset: 0x000063C4
		public void Clear()
		{
			this.txtAddress.Text = "";
			this.txtCode.Text = new ContractorsListDB().GetNewSerial();
			this.txtContractorCarrier.Text = "";
			this.txtEmail.Text = "";
			this.txtFax.Text = "";
			this.txtGMName.Text = "";
			this.txtLocation.Text = "";
			this.txtMobileNumber.Text = "";
			this.txtName.Text = "";
			this.txtTel.Text = "";
			this.txtwebsite.Text = "";
			this.IsLocked.Checked = false;
			this.cmbContractorType.SelectedIndex = -1;
		}

		// Token: 0x040000A2 RID: 162
		protected HtmlGenericControl ultitle;

		// Token: 0x040000A3 RID: 163
		protected ASPxLabel lblView;

		// Token: 0x040000A4 RID: 164
		protected ASPxLabel lblEdite;

		// Token: 0x040000A5 RID: 165
		protected ASPxLabel lblDelete;

		// Token: 0x040000A6 RID: 166
		protected ASPxLabel lblAdd;

		// Token: 0x040000A7 RID: 167
		protected ASPxButton BtnSave;

		// Token: 0x040000A8 RID: 168
		protected ASPxButton BtnBack;

		// Token: 0x040000A9 RID: 169
		protected HtmlGenericControl divmsg;

		// Token: 0x040000AA RID: 170
		protected ASPxLabel LblError;

		// Token: 0x040000AB RID: 171
		protected ASPxValidationSummary ASPxValidationSummary1;

		// Token: 0x040000AC RID: 172
		protected ASPxLabel lblMasterId;

		// Token: 0x040000AD RID: 173
		protected ASPxFormLayout flContractorsList;

		// Token: 0x040000AE RID: 174
		protected ASPxCheckBox IsLocked;

		// Token: 0x040000AF RID: 175
		protected ASPxTextBox txtCode;

		// Token: 0x040000B0 RID: 176
		protected ASPxTextBox txtName;

		// Token: 0x040000B1 RID: 177
		protected ASPxTextBox txtContractorCarrier;

		// Token: 0x040000B2 RID: 178
		protected ASPxTextBox txtLocation;

		// Token: 0x040000B3 RID: 179
		protected ASPxTextBox txtGMName;

		// Token: 0x040000B4 RID: 180
		protected ASPxTextBox txtMobileNumber;

		// Token: 0x040000B5 RID: 181
		protected ASPxTextBox txtTel;

		// Token: 0x040000B6 RID: 182
		protected ASPxTextBox txtFax;

		// Token: 0x040000B7 RID: 183
		protected ASPxTextBox txtEmail;

		// Token: 0x040000B8 RID: 184
		protected ASPxTextBox txtwebsite;

		// Token: 0x040000B9 RID: 185
		protected ASPxTextBox txtAddress;

		// Token: 0x040000BA RID: 186
		protected ASPxComboBox cmbContractorType;

		// Token: 0x040000BB RID: 187
		protected ObjectDataSource ContractorsListDS;
	}
}
