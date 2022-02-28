using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using DevExpress.Web;

namespace PioneerLab.Pages
{
	// Token: 0x02000045 RID: 69
	public class CustomerInfo : Page
	{
		// Token: 0x060002CC RID: 716 RVA: 0x00018338 File Offset: 0x00016538
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				int num = Convert.ToInt32(base.Request["id"]);
				this.lblMasterId.Text = num.ToString();
				this.flCustomersList.DataBind();
			}
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/CustomerInfoManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060002CD RID: 717 RVA: 0x00018474 File Offset: 0x00016674
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				long num = Convert.ToInt64(this.lblMasterId.Text);
				if (num > 0L)
				{
					if (this.lblEdite.Text == "True")
					{
						this.CustomersListDS.Update();
						this.Clear();
					}
					else
					{
						this.BtnSave.Enabled = false;
						this.divmsg.Attributes["class"] = "alert alert-danger";
						this.LblError.ForeColor = Color.Red;
						this.LblError.Text = "You dont have permission to Update";
					}
				}
				else if (this.lblAdd.Text == "True")
				{
					this.CustomersListDS.Insert();
					this.Clear();
				}
				else
				{
					this.BtnSave.Enabled = false;
					this.divmsg.Attributes["class"] = "alert alert-danger";
					this.LblError.ForeColor = Color.Red;
					this.LblError.Text = "You dont have permission to Add";
				}
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message;
				if (ex.InnerException != null)
				{
					this.divmsg.Attributes["class"] = "alert alert-danger";
					this.LblError.ForeColor = Color.Red;
					this.LblError.Text = ex.InnerException.Message;
				}
			}
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00018628 File Offset: 0x00016828
		protected void CustomersListDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			CustomersList customersList = new CustomersList();
			customersList.CustomerCode = this.txtCode.Text;
			customersList.CustomerName = this.txtName.Text;
			customersList.PhoneNumber = this.txtTel.Text;
			customersList.FaxNumber = this.txtFax.Text;
			customersList.POBox = this.txtPOBox.Text;
			customersList.Email = this.txtEmail.Text;
			customersList.website = this.txtwebsite.Text;
			customersList.ContactName = this.txtContactName.Text;
			customersList.ContactMobileNumber = this.txtContactMobileNumber.Text;
			customersList.Address = this.txtAddress.Text;
			customersList.PaymentMode = Convert.ToInt32(this.cmbPaymentMode.Value);
			customersList.IsLocked = this.IsLocked.Checked;
			e.InputParameters["entity"] = customersList;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00003A74 File Offset: 0x00001C74
		protected void CustomersListDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been saved successfully!";
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00018720 File Offset: 0x00016920
		protected void CustomersListDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int customerID = Convert.ToInt32(this.lblMasterId.Text);
			CustomersList customersList = new CustomersList();
			customersList.CustomerID = customerID;
			customersList.CustomerCode = this.txtCode.Text;
			customersList.CustomerName = this.txtName.Text;
			customersList.PhoneNumber = this.txtTel.Text;
			customersList.FaxNumber = this.txtFax.Text;
			customersList.POBox = this.txtPOBox.Text;
			customersList.Email = this.txtEmail.Text;
			customersList.website = this.txtwebsite.Text;
			customersList.ContactName = this.txtContactName.Text;
			customersList.ContactMobileNumber = this.txtContactMobileNumber.Text;
			customersList.Address = this.txtAddress.Text;
			customersList.PaymentMode = Convert.ToInt32(this.cmbPaymentMode.Value);
			customersList.IsLocked = this.IsLocked.Checked;
			e.InputParameters["entity"] = customersList;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00003AB0 File Offset: 0x00001CB0
		protected void CustomersListDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00003AEC File Offset: 0x00001CEC
		protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("CustomerInfoManage.aspx");
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00018830 File Offset: 0x00016A30
		public void Clear()
		{
			this.txtAddress.Text = "";
			this.txtCode.Text = "";
			this.txtContactMobileNumber.Text = "";
			this.txtEmail.Text = "";
			this.txtFax.Text = "";
			this.txtContactName.Text = "";
			this.txtName.Text = "";
			this.txtPOBox.Text = "";
			this.txtwebsite.Text = "";
			this.txtTel.Text = "";
			this.IsLocked.Checked = false;
			this.cmbPaymentMode.SelectedIndex = -1;
		}

		// Token: 0x0400047D RID: 1149
		protected HtmlGenericControl ultitle;

		// Token: 0x0400047E RID: 1150
		protected ASPxLabel lblView;

		// Token: 0x0400047F RID: 1151
		protected ASPxLabel lblEdite;

		// Token: 0x04000480 RID: 1152
		protected ASPxLabel lblDelete;

		// Token: 0x04000481 RID: 1153
		protected ASPxLabel lblAdd;

		// Token: 0x04000482 RID: 1154
		protected ASPxButton BtnSave;

		// Token: 0x04000483 RID: 1155
		protected ASPxButton BtnBack;

		// Token: 0x04000484 RID: 1156
		protected HtmlGenericControl divmsg;

		// Token: 0x04000485 RID: 1157
		protected ASPxLabel LblError;

		// Token: 0x04000486 RID: 1158
		protected ASPxValidationSummary ASPxValidationSummary1;

		// Token: 0x04000487 RID: 1159
		protected ASPxLabel lblMasterId;

		// Token: 0x04000488 RID: 1160
		protected ASPxFormLayout flCustomersList;

		// Token: 0x04000489 RID: 1161
		protected ASPxCheckBox IsLocked;

		// Token: 0x0400048A RID: 1162
		protected ASPxTextBox txtCode;

		// Token: 0x0400048B RID: 1163
		protected ASPxTextBox txtName;

		// Token: 0x0400048C RID: 1164
		protected ASPxTextBox txtTel;

		// Token: 0x0400048D RID: 1165
		protected ASPxTextBox txtFax;

		// Token: 0x0400048E RID: 1166
		protected ASPxTextBox txtPOBox;

		// Token: 0x0400048F RID: 1167
		protected ASPxTextBox txtEmail;

		// Token: 0x04000490 RID: 1168
		protected ASPxTextBox txtwebsite;

		// Token: 0x04000491 RID: 1169
		protected ASPxTextBox txtContactName;

		// Token: 0x04000492 RID: 1170
		protected ASPxTextBox txtContactMobileNumber;

		// Token: 0x04000493 RID: 1171
		protected ASPxTextBox txtAddress;

		// Token: 0x04000494 RID: 1172
		protected ASPxComboBox cmbPaymentMode;

		// Token: 0x04000495 RID: 1173
		protected ObjectDataSource CustomersListDS;
	}
}
