using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Data;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Pages
{
	// Token: 0x02000021 RID: 33
	public class PaymentInfo : Page
	{
		// Token: 0x0600011E RID: 286 RVA: 0x0000A34C File Offset: 0x0000854C
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/InvoiceManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
				this.Session["InvoiceSelectedSession"] = null;
				if (base.Request["mode"] != null && base.Request["mode"] == "Convert")
				{
					this.cmbJobOrderMaster.Value = Convert.ToInt64(base.Request["id"]);
					JobOrderMaster byID = new JobOrderMasterDB().GetByID(Convert.ToInt64(base.Request["id"]));
					this.cmbFKCustomerID.Value = byID.FKCustomerID;
					this.cmbJobOrderMaster.ClientEnabled = false;
					this.GdvInvoice.DataBind();
					this.dtPaymentDate.Value = DateTime.Today;
					this.txtReferenceNumber.Text = new PaymentMasterDB().GetNewSerial();
					this.cmbPaymentType.Value = 0;
					this.cmbPaymentType.ClientEnabled = false;
					return;
				}
				if (base.Request["mode"] != null && base.Request["mode"] == "NewLinkAdvanced")
				{
					this.cmbPaymentType.SelectedIndex = 1;
					this.cmbPaymentType.ClientEnabled = false;
					this.GdvInvoiceSelected.ClientVisible = false;
					this.GdvInvoice.ClientVisible = false;
					this.dtPaymentDate.Value = DateTime.Today;
					this.cmbJobOrderMaster.ClientEnabled = true;
					if (base.Request["id"] != null)
					{
						int num = Convert.ToInt32(base.Request["id"]);
						if (num > 0)
						{
							this.lblMasterId.Text = num.ToString();
							this.flPayment.DataBind();
							return;
						}
					}
				}
				else
				{
					int num2 = Convert.ToInt32(base.Request["id"]);
					if (num2 > 0)
					{
						this.lblMasterId.Text = num2.ToString();
						this.flPayment.DataBind();
						this.GdvInvoice.DataBind();
						this.txtPaidAmount.ClientEnabled = false;
						this.cmbPaymentType.Enabled = false;
						this.txtReferenceNumber.Enabled = false;
						return;
					}
					this.dtPaymentDate.Value = DateTime.Today;
				}
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000A6AC File Offset: 0x000088AC
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			if (base.Request["mode"] != null && (base.Request["mode"] == "LinkAdvanced" || base.Request["mode"] == "ViewLinkAdvanced" || base.Request["mode"] == "NewLinkAdvanced"))
			{
				base.Response.Redirect("PaymentInAdvanceManage.aspx");
				return;
			}
			base.Response.Redirect("PaymentManage.aspx");
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00002071 File Offset: 0x00000271
		protected void cmbFKCustomerID_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000A740 File Offset: 0x00008940
		protected void btnSave_Click(object sender, EventArgs e)
		{
			string text = "";
			try
			{
				long num = Convert.ToInt64(this.lblMasterId.Text);
				if (num == 0L)
				{
					if (this.lblAdd.Text == "True")
					{
						if (this.cmbPaymentType.Value.ToString() == "0")
						{
							string text2 = "0";
							if (this.GdvInvoiceSelected.GetTotalSummaryValue(this.GdvInvoiceSelected.TotalSummary["PaidAmount", SummaryItemType.Sum]) != null)
							{
								text2 = this.GdvInvoiceSelected.GetTotalSummaryValue(this.GdvInvoiceSelected.TotalSummary["PaidAmount", SummaryItemType.Sum]).ToString();
							}
							if (decimal.Parse(this.txtPaidAmount.Value.ToString()) == decimal.Parse(text2.ToString()))
							{
								this.PaymentDS.Insert();
								if (base.Request["mode"] != null && (base.Request["mode"] == "LinkAdvanced" || base.Request["mode"] == "ViewLinkAdvanced" || base.Request["mode"] == "NewLinkAdvanced"))
								{
									base.Response.Redirect("PaymentInAdvanceManage.aspx");
								}
								else
								{
									base.Response.Redirect("PaymentManage.aspx");
								}
							}
							else
							{
								this.btnSave.Enabled = false;
								this.divmsg.Attributes["class"] = "alert alert-info";
								this.LblErrorMessage.ForeColor = Color.Red;
								this.LblErrorMessage.Text = "Paid Amount Should Equal to  Total of invoices";
							}
						}
						else
						{
							this.PaymentDS.Insert();
							if (base.Request["mode"] != null && (base.Request["mode"] == "LinkAdvanced" || base.Request["mode"] == "ViewLinkAdvanced" || base.Request["mode"] == "NewLinkAdvanced"))
							{
								base.Response.Redirect("PaymentInAdvanceManage.aspx");
							}
							else
							{
								base.Response.Redirect("PaymentManage.aspx");
							}
						}
					}
					else
					{
						this.btnSave.Enabled = false;
						this.divmsg.Attributes["class"] = "alert alert-info";
						this.LblErrorMessage.ForeColor = Color.Red;
						this.LblErrorMessage.Text = "You dont have permission to Add";
					}
				}
				else if (this.lblEdite.Text == "True")
				{
					string text3 = "0";
					if (this.GdvInvoiceSelected.GetTotalSummaryValue(this.GdvInvoiceSelected.TotalSummary["PaidAmount", SummaryItemType.Sum]) != null)
					{
						text3 = this.GdvInvoiceSelected.GetTotalSummaryValue(this.GdvInvoiceSelected.TotalSummary["PaidAmount", SummaryItemType.Sum]).ToString();
					}
					object obj = HttpContext.Current.Session["InvoiceSelectedSession"];
					if (decimal.Parse(this.txtPaidAmount.Value.ToString()) == decimal.Parse(text3.ToString()) || obj == null)
					{
						List<PaymentDetails> list = new List<PaymentDetails>();
						if (obj != null)
						{
							List<ViewInvoicesBalance> list2 = obj as List<ViewInvoicesBalance>;
							if (list2.Count > 0)
							{
								foreach (ViewInvoicesBalance viewInvoicesBalance in list2)
								{
									list.Add(new PaymentDetails
									{
										FKInvoiceId = viewInvoicesBalance.InvoiceId,
										PaidAmount = viewInvoicesBalance.PaidAmount,
										PaymentDetID = (long)(list.Count + 1)
									});
								}
							}
						}
						PaymentMaster masterEntity = this.GetMasterEntity(int.Parse(this.lblMasterId.Text));
						new PaymentMasterDB().UpdateWithDetails(masterEntity, list, out text);
						if (base.Request["mode"] != null && (base.Request["mode"] == "LinkAdvanced" || base.Request["mode"] == "ViewLinkAdvanced" || base.Request["mode"] == "NewLinkAdvanced"))
						{
							base.Response.Redirect("PaymentInAdvanceManage.aspx");
						}
						else
						{
							base.Response.Redirect("PaymentManage.aspx");
						}
					}
					else
					{
						this.btnSave.Enabled = false;
						this.divmsg.Attributes["class"] = "alert alert-info";
						this.LblErrorMessage.ForeColor = Color.Red;
						this.LblErrorMessage.Text = "Paid Amount Should Equal to  Total of invoices";
					}
				}
				else
				{
					this.btnSave.Enabled = false;
					this.divmsg.Attributes["class"] = "alert alert-info";
					this.LblErrorMessage.ForeColor = Color.Red;
					this.LblErrorMessage.Text = "You dont have permission to Edit";
				}
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblErrorMessage.ForeColor = Color.Red;
				this.LblErrorMessage.Text = ex.Message;
				if (ex.InnerException != null)
				{
					this.LblErrorMessage.Text = ex.InnerException.Message;
				}
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000AD00 File Offset: 0x00008F00
		protected void gdvInvoice_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
		{
			if ((this.cmbPaymentType.Value.ToString() == "0" || base.Request["mode"] == "LinkAdvanced") && e.CommandArgs.CommandName == "cmdSelect")
			{
				long detailsId = Convert.ToInt64(e.CommandArgs.CommandArgument);
				ViewInvoicesBalance viewInvoicesBalance = (ViewInvoicesBalance)this.GdvInvoice.GetRow(e.VisibleIndex);
				List<ViewInvoicesBalance> list = (List<ViewInvoicesBalance>)this.Session["InvoiceSelectedSession"];
				decimal num;
				if (this.txtPaidAmount.Text != "")
				{
					num = Convert.ToDecimal(this.txtPaidAmount.Value);
				}
				else
				{
					num = 0m;
				}
				try
				{
					string text = this.GdvInvoiceSelected.GetTotalSummaryValue(this.GdvInvoiceSelected.TotalSummary["PaidAmount", SummaryItemType.Sum]).ToString();
					if (text != null)
					{
						num -= decimal.Parse(text);
					}
				}
				catch
				{
				}
				this.Session["PaidAmount"] = num;
				if (viewInvoicesBalance.InvoiceBalance <= num)
				{
					viewInvoicesBalance.PaidAmount = viewInvoicesBalance.InvoiceBalance.Value;
				}
				if (viewInvoicesBalance.InvoiceBalance > num && num != 0m)
				{
					viewInvoicesBalance.PaidAmount = num;
				}
				if (list == null)
				{
					list = new List<ViewInvoicesBalance>();
				}
				if (list.Count((ViewInvoicesBalance detail) => detail.InvoiceId == detailsId) > 0)
				{
					return;
				}
				if (num > 0m)
				{
					list.Insert(list.Count, viewInvoicesBalance);
					this.Session["InvoiceSelectedSession"] = list;
					this.GdvInvoiceSelected.DataBind();
				}
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvInvoiceSelected_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00002071 File Offset: 0x00000271
		protected void GdvInvoiceSelected_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
		{
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00002C67 File Offset: 0x00000E67
		protected void PaymentDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetMasterEntity(0);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00002C80 File Offset: 0x00000E80
		protected void PaymentDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblErrorMessage.ForeColor = Color.Green;
			this.LblErrorMessage.Text = "Data has been saved successfully!";
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00002CBC File Offset: 0x00000EBC
		protected void PaymentDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetMasterEntity(int.Parse(this.lblMasterId.Text));
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00002C80 File Offset: 0x00000E80
		protected void PaymentDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblErrorMessage.ForeColor = Color.Green;
			this.LblErrorMessage.Text = "Data has been saved successfully!";
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000AF10 File Offset: 0x00009110
		private PaymentMaster GetMasterEntity(int MasterID)
		{
			PaymentMaster paymentMaster;
			if (MasterID > 0)
			{
				paymentMaster = new PaymentMasterDB().GetByID((long)MasterID);
				paymentMaster.ReferenceNumber = this.txtReferenceNumber.Text;
			}
			else
			{
				paymentMaster = new PaymentMaster();
				paymentMaster.ReferenceNumber = new PaymentMasterDB().GetNewSerial();
				UsersDB usersDB = new UsersDB();
				ADMUsers admusers = this.Session["CurrentUser"] as ADMUsers;
				int userID = admusers.UserID;
				ADMUsers byID = usersDB.GetByID(userID);
				paymentMaster.ReceivedBy = byID.EName;
			}
			long num = long.Parse(this.cmbJobOrderMaster.Value.ToString());
			paymentMaster.FKJobOrderMasterID = new long?(num);
			JobOrderMaster byID2 = new JobOrderMasterDB().GetByID(num);
			paymentMaster.FKCustomerID = new int?(byID2.FKCustomerID);
			paymentMaster.PaymentAmount = decimal.Parse(this.txtPaidAmount.Value.ToString());
			paymentMaster.PaymentDate = this.dtPaymentDate.Date;
			paymentMaster.PaymentType = int.Parse(this.cmbPaymentType.Value.ToString());
			paymentMaster.Remarks = this.txtRemarks.Text;
			return paymentMaster;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00002CE4 File Offset: 0x00000EE4
		protected void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbPaymentType.Value.ToString() == "1")
			{
				this.Session["InvoiceSelectedSession"] = null;
				this.GdvInvoiceSelected.DataBind();
			}
		}

		// Token: 0x04000153 RID: 339
		protected HtmlGenericControl ultitle;

		// Token: 0x04000154 RID: 340
		protected ASPxLabel lblView;

		// Token: 0x04000155 RID: 341
		protected ASPxLabel lblEdite;

		// Token: 0x04000156 RID: 342
		protected ASPxLabel lblDelete;

		// Token: 0x04000157 RID: 343
		protected ASPxLabel lblAdd;

		// Token: 0x04000158 RID: 344
		protected ASPxLabel lblAlowUpdate;

		// Token: 0x04000159 RID: 345
		protected ASPxButton btnSave;

		// Token: 0x0400015A RID: 346
		protected ASPxButton btnCancel;

		// Token: 0x0400015B RID: 347
		protected HtmlGenericControl divmsg;

		// Token: 0x0400015C RID: 348
		protected ASPxLabel LblErrorMessage;

		// Token: 0x0400015D RID: 349
		protected ASPxLabel lblMasterId;

		// Token: 0x0400015E RID: 350
		protected ASPxLabel lblQid;

		// Token: 0x0400015F RID: 351
		protected ASPxFormLayout flPayment;

		// Token: 0x04000160 RID: 352
		protected ASPxTextBox txtReferenceNumber;

		// Token: 0x04000161 RID: 353
		protected ASPxDateEdit dtPaymentDate;

		// Token: 0x04000162 RID: 354
		protected ASPxComboBox cmbJobOrderMaster;

		// Token: 0x04000163 RID: 355
		protected ASPxSpinEdit txtPaidAmount;

		// Token: 0x04000164 RID: 356
		protected ASPxComboBox cmbPaymentType;

		// Token: 0x04000165 RID: 357
		protected ASPxComboBox cmbFKCustomerID;

		// Token: 0x04000166 RID: 358
		protected ASPxMemo txtRemarks;

		// Token: 0x04000167 RID: 359
		protected ASPxGridView GdvInvoice;

		// Token: 0x04000168 RID: 360
		protected ASPxGridView GdvInvoiceSelected;

		// Token: 0x04000169 RID: 361
		protected ObjectDataSource CustomersListDS;

		// Token: 0x0400016A RID: 362
		protected ObjectDataSource PaymentDS;

		// Token: 0x0400016B RID: 363
		protected ObjectDataSource InvoiceDS;

		// Token: 0x0400016C RID: 364
		protected ObjectDataSource SelectedInvoiceDS;

		// Token: 0x0400016D RID: 365
		protected ObjectDataSource JobOrderDS;

		// Token: 0x0400016E RID: 366
		protected ObjectDataSource JobOrderMasterDS;
	}
}
