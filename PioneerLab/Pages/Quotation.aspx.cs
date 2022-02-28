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
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace PioneerLab.Pages
{
	// Token: 0x02000039 RID: 57
	public class Quotation : Page
	{
		// Token: 0x0600021B RID: 539 RVA: 0x00012EB0 File Offset: 0x000110B0
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/QuotationManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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
                popupWorkOrder.ShowOnPageLoad = false;

                string.IsNullOrEmpty(this.Session["WorkOrderNumber"] as string).ToString();
				if (HttpContext.Current.Session["WorkOrderNumber"] == null)
				{
					this.Session["WorkOrderNumber"] = new QuotationWorkOrderListDB().GetMaxWorkOrderNo();
				}
				this.GdvQuotationDetailsList.JSProperties["cpError"] = "";
				this.GdvQuotationDetailsList.JSProperties["cpDeleteError"] = "";
				this.Session["ViewQuotationDetailsList"] = null;
				this.Session["NewQuotationDetailsID"] = null;
				int num = Convert.ToInt32(base.Request["id"]);
				this.lblMasterId.Text = num.ToString();
				this.flQuotationMaster.DataBind();
				if (num > 0)
				{
					this.ShowTotal();
					this.cmbFKEnquiryMasterID.ReadOnly = true;
					if (base.Request["mode"] != null && base.Request["mode"] == "confirm" && this.cmbStatusID.Value.ToString() == "0")
					{
						this.divConfirmSection.Visible = true;
					}
					if (base.Request["mode"] != null && base.Request["mode"] == "revise")
					{
						this.txtQuotationNo.Text = new QuotationMasterDB().GetNewQuotationNo(Convert.ToInt64(this.cmbFKEnquiryMasterID.Value));
						this.dtEntryDate.Value = DateTime.Today;
						this.Qid.Text = this.lblMasterId.Text;
						this.BtnSave.Text = "Save Revision";
					}
					if (base.Request["mode"] != null && base.Request["mode"] == "View")
					{
						this.BtnSave.ClientEnabled = false;
						this.BtnSave.Visible = false;
						return;
					}
				}
				else
				{
					this.dtEntryDate.Text = DateTime.Now.ToString("dd MMM yyyy hh:mm tt");
					this.txtQuotationNo.Text = new QuotationMasterDB().GetNewQuotationNo(0L);
					if (base.Request["cid"] != null)
					{
						this.cmbStatusID.Value = 0;
						this.cmbFKEnquiryMasterID.Value = Convert.ToInt64(base.Request["cid"]);
						this.cmbFKEnquiryMasterID_SelectedIndexChanged(this.cmbFKEnquiryMasterID, new EventArgs());
					}
				}
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00013270 File Offset: 0x00011470
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				this.GdvQuotationDetailsList.UpdateEdit();
				object obj = this.Session["ViewQuotationDetailsList"];
				if (base.Request["mode"] != null && base.Request["mode"] == "revise")
				{
					this.SaveAsNewVersion();
				}
				else
				{
					long num = Convert.ToInt64(this.lblMasterId.Text);
					if (num > 0L)
					{
						this.ShowTotal();
						if (this.lblEdite.Text == "True")
						{
							this.QuotationMasterDS.Update();
							base.Response.Redirect("QuotationManage.aspx", false);
						}
						else
						{
							this.BtnSave.Enabled = false;
							this.divmsg.Attributes["class"] = "alert alert-info";
							this.LblError.ForeColor = Color.Red;
							this.LblError.Text = "You dont have permission to Update";
						}
					}
					else
					{
						this.ShowTotal();
						if (this.lblAdd.Text == "True")
						{
							this.QuotationMasterDS.Insert();
							base.Response.Redirect("QuotationManage.aspx", false);
						}
						else
						{
							this.BtnSave.Enabled = false;
							this.divmsg.Attributes["class"] = "alert alert-info";
							this.LblError.ForeColor = Color.Red;
							this.LblError.Text = "You dont have permission to Add";
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message;
				if (ex.InnerException != null)
				{
					this.LblError.Text = ex.InnerException.Message;
				}
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000336D File Offset: 0x0000156D
		protected void QuotationMasterDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetMasterEntity(0);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00003386 File Offset: 0x00001586
		protected void QuotationMasterDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been saved successfully!";
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00013474 File Offset: 0x00011674
		protected void QuotationMasterDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int masterID = Convert.ToInt32(this.lblMasterId.Text);
			e.InputParameters["entity"] = this.GetMasterEntity(masterID);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x000134AC File Offset: 0x000116AC
		private QuotationMaster GetMasterEntity(int MasterID)
		{
			QuotationMaster quotationMaster;
			if (MasterID > 0)
			{
				quotationMaster = new QuotationMasterDB().GetByID((long)MasterID);
				if (this.Session["action"] != null)
				{
					quotationMaster.StatusID = Convert.ToInt32(this.Session["action"]);
				}
				if (quotationMaster.StatusID == 1)
				{
					ADMUsers admusers = this.Session["CurrentUser"] as ADMUsers;
					quotationMaster.ApprovedBy = admusers.EName;
				}
			}
			else
			{
				quotationMaster = new QuotationMaster();
				quotationMaster.QuotationNo = new QuotationMasterDB().GetNewQuotationNo(Convert.ToInt64(this.cmbFKEnquiryMasterID.Value));
				quotationMaster.IsActive = true;
				quotationMaster.IsAddedTojo = new bool?(false);
			}
			quotationMaster.TransactionDate = DateTime.Today;
			quotationMaster.EntryDate = (DateTime)this.dtEntryDate.Value;
			quotationMaster.ExpiryDate = new DateTime?(this.dtEntryDate.Date.AddDays((double)Convert.ToInt32(this.txtExpireIn.Value)));
			quotationMaster.FKEnquiryMasterID = new long?(Convert.ToInt64(this.cmbFKEnquiryMasterID.Value));
			quotationMaster.FKCustomerID = Convert.ToInt32(this.cmbFKCustomerID.Value);
			quotationMaster.FKProjectID = Convert.ToInt32(this.cmbFKProjectID.Value);
			quotationMaster.FKTermsConditionsID = (int?)this.cmbFKTermsConditionsID.Value;
			quotationMaster.PaymentTerms = this.cmbPaymentTerms.Text;
			quotationMaster.Remarks = this.txtRemarks.Text;
			quotationMaster.ShowTotal = this.cbShowTotal.Checked;
			return quotationMaster;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00013640 File Offset: 0x00011840
		protected void QuotationMasterDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			if (this.Session["action"] != null)
			{
				this.Session["action"] = null;
				base.Response.Redirect("QuotationManage.aspx");
			}
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000033C2 File Offset: 0x000015C2
		protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("QuotationManage.aspx");
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000136BC File Offset: 0x000118BC
		protected void GdvQuotationDetailsList_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
		{
			if (e.NewValues["FKTestID"] != null && e.NewValues["FKPriceUnitID"] != null)
			{
				TestPrices priceUnitByTestAndUnitID = new TestPricesDB().GetPriceUnitByTestAndUnitID(Convert.ToInt32(e.NewValues["FKTestID"]), Convert.ToInt32(e.NewValues["FKPriceUnitID"]));
				if (Convert.ToDecimal(e.NewValues["Price"]) < priceUnitByTestAndUnitID.MinimumPrice && e.NewValues["Price"] != null)
				{
					this.lblWarning.Text = "Warning: This quotation contains one or more services with price less than the minimum price!";
				}
				else
				{
					this.lblWarning.Visible = false;
				}
				this.Session["NewQuotationDetailsID"] = e.Keys["QuotationDetailsID"];
				this.Session["NewFKTestID"] = e.NewValues["FKTestID"];
				this.Session["FKMaterialTypeID"] = e.NewValues["FKMaterialTypeID"];
				this.Session["FKMaterialDetailsID"] = e.NewValues["FKMaterialDetailsID"];
				this.Session["NewFKPriceUnitID"] = e.NewValues["FKPriceUnitID"];
				this.Session["NewPrice"] = e.NewValues["Price"];
				this.Session["NewMinQty"] = e.NewValues["MinQty"];
				this.Session["NewRemarks"] = ((e.NewValues["Remarks"] == null) ? "" : e.NewValues["Remarks"]);
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000138AC File Offset: 0x00011AAC
		protected void QuotationDetailsDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			if (this.Session["NewQuotationDetailsID"] != null)
			{
				long fkquotationMasterID = Convert.ToInt64(this.lblMasterId.Text);
				ViewQuotationDetails viewQuotationDetails = new ViewQuotationDetails();
				viewQuotationDetails.QuotationDetailsID = (long)Convert.ToInt32(this.Session["NewQuotationDetailsID"]);
				viewQuotationDetails.FKQuotationMasterID = fkquotationMasterID;
				viewQuotationDetails.FKTestID = Convert.ToInt32(this.Session["NewFKTestID"]);
				viewQuotationDetails.FKMaterialTypeID = new int?(Convert.ToInt32(this.Session["FKMaterialTypeID"]));
				viewQuotationDetails.FKMaterialDetailsID = new int?(Convert.ToInt32(this.Session["FKMaterialDetailsID"]));
				viewQuotationDetails.FKPriceUnitID = Convert.ToInt32(this.Session["NewFKPriceUnitID"]);
				if ((from x in new TestPricesDB().GetFromViewTestPrices()
				where x.PriceUnitID == Convert.ToInt32(this.Session["NewFKPriceUnitID"])
				select x).FirstOrDefault<ViewTestPrices>().UnitType == 1)
				{
					viewQuotationDetails.Price = null;
					viewQuotationDetails.MinQty = null;
				}
				else
				{
					viewQuotationDetails.Price = (decimal?)this.Session["NewPrice"];
					viewQuotationDetails.MinQty = (decimal?)this.Session["NewMinQty"];
				}
				viewQuotationDetails.Remarks = this.Session["NewRemarks"].ToString();
				e.InputParameters["entity"] = viewQuotationDetails;
				e.InputParameters["original_QuotationDetailsID"] = Convert.ToInt32(this.Session["NewQuotationDetailsID"]);
				this.Session["NewQuotationDetailsID"] = null;
				this.Session["NewFKTestID"] = null;
				this.Session["FKMaterialTypeID"] = null;
				this.Session["FKMaterialDetailsID"] = null;
				this.Session["NewFKPriceUnitID"] = null;
				this.Session["NewPrice"] = null;
				this.Session["NewMinQty"] = null;
				this.Session["NewRemarks"] = null;
				return;
			}
			e.Cancel = true;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00013B04 File Offset: 0x00011D04
		protected void GdvLabTestsList_DataBound(object sender, EventArgs e)
		{
			List<ViewQuotationDetails> source = this.QuotationDetailsDS.Select() as List<ViewQuotationDetails>;
			List<int> list = (from x in source
			select x.FKTestID).ToList<int>();
			foreach (int num in list)
			{
				this.GdvLabTestsList.Selection.SelectRowByKey(num);
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00013B9C File Offset: 0x00011D9C
		protected void cmbFKEnquiryMasterID_SelectedIndexChanged(object sender, EventArgs e)
		{
			long num = Convert.ToInt64(this.cmbFKEnquiryMasterID.Value);
			EnquiryMaster byID = new EnquiryMasterDB().GetByID(num);
			this.cmbFKCustomerID.Value = byID.FKCustomerID;
			this.cmbFKProjectID.Value = byID.FKProjectID;
			List<EnquiryDetails> byMasterIDWithSession = new EnquiryDetailsDB().GetByMasterIDWithSession(num);
			List<ViewQuotationDetails> list = new List<ViewQuotationDetails>();
			TestPricesDB testPricesDB = new TestPricesDB();
			foreach (EnquiryDetails enquiryDetails in byMasterIDWithSession)
			{
				ViewQuotationDetails viewQuotationDetails = new ViewQuotationDetails();
				viewQuotationDetails.QuotationDetailsID = (long)(list.Count + 1);
				viewQuotationDetails.FKEnquiryDetailsID = new long?(enquiryDetails.EnquiryDetailsID);
				viewQuotationDetails.FKTestID = enquiryDetails.FKTestID;
				viewQuotationDetails.TestName = new TestsListDB().GetByID(enquiryDetails.FKTestID).TestName;
				viewQuotationDetails.StandardNumber = new TestsListDB().GetByID(enquiryDetails.FKTestID).StandardNumber;
				if (enquiryDetails.FKMaterialTypeID != null)
				{
					viewQuotationDetails.MaterialsTypesName = (new MaterialsTypesDB().GetByID(enquiryDetails.FKMaterialTypeID.Value).MaterialName ?? "");
				}
				if (enquiryDetails.FKMaterialDetailsID != null)
				{
					viewQuotationDetails.MaterialsDetailsName = (new MaterialsDetailsDB().GetByID(enquiryDetails.FKMaterialDetailsID.Value).MaterialName ?? "");
				}
				viewQuotationDetails.FKMaterialTypeID = enquiryDetails.FKMaterialTypeID;
				viewQuotationDetails.FKMaterialDetailsID = enquiryDetails.FKMaterialDetailsID;
				viewQuotationDetails.FKPriceUnitID = enquiryDetails.FKPriceUnitID;
				viewQuotationDetails.Remarks = enquiryDetails.Remarks;
				viewQuotationDetails.DefaultPrice = testPricesDB.GetPriceUnitByTestAndUnitID(enquiryDetails.FKTestID, enquiryDetails.FKPriceUnitID)?.DefaultPrice;
				viewQuotationDetails.MinimumPrice = testPricesDB.GetPriceUnitByTestAndUnitID(enquiryDetails.FKTestID, enquiryDetails.FKPriceUnitID)?.MinimumPrice;
				viewQuotationDetails.UnitType = testPricesDB.GetPriceUnitByTestAndUnitID(enquiryDetails.FKTestID, enquiryDetails.FKPriceUnitID)?.PriceUnitList.UnitType;
				if (viewQuotationDetails.UnitType == 1)
				{
					viewQuotationDetails.DefaultPrice = null;
					viewQuotationDetails.MinimumPrice = null;
				}
				viewQuotationDetails.Price = null;
				viewQuotationDetails.MinQty = new decimal?(1m);
				list.Add(viewQuotationDetails);
			}
			this.Session["ViewQuotationDetailsList"] = list;
			this.GdvQuotationDetailsList.DataBind();
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00013E78 File Offset: 0x00012078
		protected void SaveAsNewVersion()
		{
			try
			{
				object obj = this.Session["ViewQuotationDetailsList"];
				if (obj != null)
				{
					List<ViewQuotationDetails> list = new List<ViewQuotationDetails>();
					List<QuotationWorkOrderList> list2 = new List<QuotationWorkOrderList>();
					foreach (ViewQuotationDetails viewQuotationDetails in (obj as List<ViewQuotationDetails>))
					{
						list.Add(new ViewQuotationDetails
						{
							QuotationDetailsID = viewQuotationDetails.QuotationDetailsID,
							FKEnquiryDetailsID = viewQuotationDetails.FKEnquiryDetailsID,
							FKTestID = viewQuotationDetails.FKTestID,
							FKMaterialTypeID = viewQuotationDetails.FKMaterialTypeID,
							FKMaterialDetailsID = viewQuotationDetails.FKMaterialDetailsID,
							FKPriceUnitID = viewQuotationDetails.FKPriceUnitID,
							Price = viewQuotationDetails.Price,
							MinQty = viewQuotationDetails.MinQty,
							Remarks = viewQuotationDetails.Remarks,
							MinimumPrice = viewQuotationDetails.MinimumPrice,
							DefaultPrice = viewQuotationDetails.DefaultPrice
						});
						List<QuotationWorkOrderList> collection = new QuotationWorkOrderListDB().GetbyMasterId(viewQuotationDetails.QuotationDetailsID);
						list2.AddRange(collection);
					}
					this.Session["ViewQuotationDetailsList"] = list;
					this.Session["QuotationWorkOrderList"] = list2;
				}
				this.QuotationMasterDS.Insert();
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message;
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0001403C File Offset: 0x0001223C
		protected void GdvQuotationDetailsList_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
		{
			if (this.FlageSave != 1)
			{
				if (e.CellType == GridViewTableCommandCellType.Data && e.ButtonID == "btnWorkOrder")
				{
					int id = Convert.ToInt32(this.GdvQuotationDetailsList.GetRowValues(e.VisibleIndex, new string[]
					{
						"FKPriceUnitID"
					}));
					PriceUnitList byID = new PriceUnitListDB().GetByID(id);
					if (byID != null && byID.UnitType == 0)
					{
						e.Visible = DefaultBoolean.False;
					}
				}
				if (e.ButtonID == "btnWarning")
				{
					decimal d = Convert.ToDecimal(this.GdvQuotationDetailsList.GetRowValues(e.VisibleIndex, new string[]
					{
						"Price"
					}));
					decimal d2 = Convert.ToDecimal(this.GdvQuotationDetailsList.GetRowValues(e.VisibleIndex, new string[]
					{
						"MinimumPrice"
					}));
					if (d < d2 && this.GdvQuotationDetailsList.GetRowValues(e.VisibleIndex, new string[]
					{
						"Price"
					}) != null)
					{
						e.Visible = DefaultBoolean.True;
						this.GdvQuotationDetailsList.JSProperties["cpDeleteError"] = "Warning: This quotation contains one or more services with price less than its minimum price!";
						this.lblWarning.Text = "Warning: This quotation contains one or more services with price less than its minimum price!";
					}
				}
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00014198 File Offset: 0x00012398
		protected void lstTests_DataBound(object sender, EventArgs e)
		{
			ASPxCheckBoxList aspxCheckBoxList = (ASPxCheckBoxList)sender;
			List<ViewQuotationDetails> source = this.QuotationDetailsDS.Select() as List<ViewQuotationDetails>;
			List<int> list = (from x in source
			select x.FKTestID).ToList<int>();
			for (int i = 0; i < aspxCheckBoxList.Items.Count; i++)
			{
				aspxCheckBoxList.Items[i].Selected = list.Contains((int)aspxCheckBoxList.Items[i].Value);
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000033D4 File Offset: 0x000015D4
		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			this.QuotationDetailsDS.Insert();
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0001422C File Offset: 0x0001242C
		protected void QuotationDetailsDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int num = Convert.ToInt32(this.lblMasterId.Text);
			List<object> selectedFieldValues = this.GdvLabTestsList.GetSelectedFieldValues(new string[]
			{
				"TestID"
			});
			List<QuotationDetails> list = new List<QuotationDetails>();
			foreach (object value in selectedFieldValues)
			{
				QuotationDetails quotationDetails = new QuotationDetails();
				quotationDetails.FKQuotationMasterID = (long)num;
				quotationDetails.FKTestID = Convert.ToInt32(value);
				quotationDetails.FKPriceUnitID = new TestPricesDB().GetFirstPriceUnitByTestID(quotationDetails.FKTestID).FKPriceUnitID;
				list.Add(quotationDetails);
			}
			if (list.Count == 0)
			{
				list.Add(new QuotationDetails
				{
					FKQuotationMasterID = (long)num,
					FKTestID = 0
				});
			}
			e.InputParameters["entityList"] = list;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000033E2 File Offset: 0x000015E2
		protected void QuotationDetailsDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.popTestLists.ShowOnPageLoad = false;
			this.GdvQuotationDetailsList.DataBind();
		}

		// Token: 0x0600022D RID: 557 RVA: 0x000033FB File Offset: 0x000015FB
		protected void popTestLists_WindowCallback(object source, PopupWindowCallbackArgs e)
		{
			this.lstTests.DataBind();
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00014328 File Offset: 0x00012528
		protected void GdvQuotationDetailsList_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
		{
			if (this.FlageSave != 1)
			{
				if (e.Column.FieldName != "FKPriceUnitID")
				{
					return;
				}
				ASPxComboBox aspxComboBox = (ASPxComboBox)e.Editor;
				aspxComboBox.ClientInstanceName = "PriceUnitEditor";
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00014370 File Offset: 0x00012570
		protected void Action_Click(object sender, EventArgs e)
		{
			this.FlageSave = 1;
			this.GdvQuotationDetailsList.UpdateEdit();
			try
			{
				if ((sender as ASPxButton).ID == "btnApprove")
				{
					int num = 1;
					int num2 = new QuotationDetailsDB().CheckAllWorkOrderComplted(long.Parse(this.lblMasterId.Text));
					if (num2 > 0)
					{
						this.popAlert.ShowOnPageLoad = true;
						throw new Exception("Work order mandatory");
					}
					this.Session["action"] = num;
					this.QuotationMasterDS.Update();
				}
				else
				{
					int num = 2;
					this.Session["action"] = num;
					this.QuotationMasterDS.Update();
				}
			}
			catch (Exception ex)
			{
				this.lblMessageError.Visible = true;
				this.lblMessageError.Text = ex.Message;
				base.ClientScript.RegisterStartupScript(typeof(Page), ex.Message, "window.close();", true);
				ScriptManager.RegisterClientScriptBlock(this, base.GetType(), "alertMessage", "alert(ex.Message)", true);
				this.popAlert.ShowOnPageLoad = true;
			}
		}

		// Token: 0x06000230 RID: 560 RVA: 0x000144A0 File Offset: 0x000126A0
		protected void flQuotationMaster_DataBound(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(this.lblMasterId.Text);
			if (num > 0 && (base.Request["mode"] == null || base.Request["mode"] == "confirm"))
			{
				this.txtExpireIn.Value = (this.dtExpiryDate.Date - this.dtEntryDate.Date).Days;
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00002071 File Offset: 0x00000271
		protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00014524 File Offset: 0x00012724
		protected void OnItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
		{
			if (this.FlageSave != 1)
			{
				int id;
				if (e.Value == null || !int.TryParse(e.Value.ToString(), out id))
				{
					return;
				}
				ASPxComboBox aspxComboBox = source as ASPxComboBox;
				aspxComboBox.DataSource = from x in new TestPricesDB().GetFromViewTestPrices()
				where x.PriceUnitID == id
				select x;
				aspxComboBox.DataBind();
			}
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00014590 File Offset: 0x00012790
		protected void OnItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
		{
			if (this.FlageSave != 1)
			{
				ASPxComboBox aspxComboBox = source as ASPxComboBox;
				int currentTest = this.GetCurrentTest();
				List<PriceUnitList> testPriceUnitList;
				if (currentTest > -1)
				{
					testPriceUnitList = new TestPricesDB().GetTestPriceUnitList(currentTest);
				}
				else
				{
					testPriceUnitList = new TestPricesDB().GetTestPriceUnitList(0);
				}
				aspxComboBox.DataSource = testPriceUnitList;
				aspxComboBox.DataBind();
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x000145E0 File Offset: 0x000127E0
		private int GetCurrentTest()
		{
			object value = null;
			if (this.hf.TryGet("CurrentTest", out value))
			{
				return Convert.ToInt32(value);
			}
			return -1;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00002071 File Offset: 0x00000271
		protected void flRefresh_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0001460C File Offset: 0x0001280C
		protected void btnUpdateWorkOrder_Click(object sender, EventArgs e)
		{
			long num = Convert.ToInt64(this.sid.Text);
			if (num > 0L)
			{
				this.WorkOrderListDS.Update();
				return;
			}
            else
            {
                this.WorkOrderListDS.Insert();

            }
            Response.Redirect(Request.RawUrl);
        }

		// Token: 0x06000237 RID: 567 RVA: 0x00003408 File Offset: 0x00001608
		protected void WorkOrderListDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetWorkOrderEntity();
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00003408 File Offset: 0x00001608
		protected void WorkOrderListDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetWorkOrderEntity();
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00014648 File Offset: 0x00012848
		private QuotationWorkOrderList GetWorkOrderEntity()
		{
			long num = Convert.ToInt64(this.sid.Text);
			long fkquotationMasterID = Convert.ToInt64(this.lblMasterId.Text);
			QuotationWorkOrderList quotationWorkOrderList;
			if (num > 0L)
			{
				quotationWorkOrderList = new QuotationWorkOrderListDB().GetByIDFromSession(num);
			}
			else
			{
				quotationWorkOrderList = new QuotationWorkOrderList();
				quotationWorkOrderList.WorkOrderNo = new QuotationWorkOrderListDB().GetWorkOrderNo();
				quotationWorkOrderList.TransDate = new DateTime?(DateTime.Now);
			}
			quotationWorkOrderList.FkQuotationDetailsID = new long?(Convert.ToInt64(this.Qid.Text));
			quotationWorkOrderList.StartDate = (DateTime?)this.dtStartDate.Value;
			quotationWorkOrderList.EndDate = (DateTime?)this.dtEndDate.Value;
			quotationWorkOrderList.SiteName = this.txtSiteName.Text;
			quotationWorkOrderList.ShiftStatus = (int?)this.cmbShiftStatus.Value;
			quotationWorkOrderList.RegularWorkHrs = (decimal?)this.txtRegularWorkHrs.Value;
			quotationWorkOrderList.RamadanWorkHrs = (decimal?)this.txtRamadanWorkHrs.Value;
			quotationWorkOrderList.MonthlyRate = (decimal?)this.txtMonthlyRate.Value;
			quotationWorkOrderList.UnitOfAddition = this.txtUnitOfAddition.Text;
			quotationWorkOrderList.ExtraWorkHourRate = (decimal?)this.txtExtraWorkHourRate.Value;
			quotationWorkOrderList.NightShiftPerc = (decimal?)this.txtNightShiftPerc.Value;
			quotationWorkOrderList.Description = this.txtDescription.Text;
			quotationWorkOrderList.FKQuotationMasterID = fkquotationMasterID;
			return quotationWorkOrderList;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00003420 File Offset: 0x00001620
		protected void GdvWorkOrderList_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
		{
			this.GdvWorkOrderList.DataBind();
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000147B8 File Offset: 0x000129B8
		public void ShowTotal()
		{
			decimal d = 0m;
			if (this.cbShowTotal.Checked)
			{
				object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
				if (obj != null)
				{
					List<ViewQuotationDetails> list = obj as List<ViewQuotationDetails>;
					foreach (ViewQuotationDetails viewQuotationDetails in list)
					{
						if (viewQuotationDetails.Price != null)
						{
							d += viewQuotationDetails.Price.Value;
						}
					}
				}
				this.lblTotalQuotaion.Text = d.ToString();
				return;
			}
			this.lblTotalQuotaion.Text = "";
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00014880 File Offset: 0x00012A80
		public void ClearPage()
		{
			this.txtExpireIn.Text = "";
			this.txtExtraWorkHourRate.Text = "";
			this.txtMonthlyRate.Text = "";
			this.txtNightShiftPerc.Text = "";
			this.txtQuotationNo.Text = "";
			this.txtRamadanWorkHrs.Text = "";
			this.txtRegularWorkHrs.Text = "";
			this.txtRemarks.Text = "";
			this.txtSiteName.Text = "";
			this.txtUnitOfAddition.Text = "";
			this.txtWorkOrderNo.Text = "";
			this.cmbFKCustomerID.SelectedIndex = -1;
			this.cmbFKEnquiryMasterID.SelectedIndex = -1;
			this.cmbFKProjectID.SelectedIndex = -1;
			this.cmbFKTermsConditionsID.SelectedIndex = -1;
			this.cmbPaymentTerms.SelectedIndex = -1;
			this.cmbShiftStatus.SelectedIndex = -1;
			this.cmbStatusID.SelectedIndex = -1;
			this.cbShowTotal.Checked = false;
			this.Session["ViewQuotationDetailsList"] = null;
			this.GdvQuotationDetailsList.DataBind();
			this.lblTotalQuotaion.Text = "";
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000149CC File Offset: 0x00012BCC
		protected void btnWorkOrder_Init(object sender, EventArgs e)
		{
			ASPxButton aspxButton = sender as ASPxButton;
			GridViewDataItemTemplateContainer gridViewDataItemTemplateContainer = aspxButton.NamingContainer as GridViewDataItemTemplateContainer;
			aspxButton.ClientInstanceName = string.Format("btn{0}", gridViewDataItemTemplateContainer.VisibleIndex);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000342D File Offset: 0x0000162D
		protected void popupWorkOrder_WindowCallback(object source, PopupWindowCallbackArgs e)
		{
			int.Parse(this.Qid.Text);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00014A08 File Offset: 0x00012C08
		protected void clearWorkOrder()
		{
			this.txtDescription.Text = "";
			this.dtTransDate.Value = null;
			this.dtEndDate.Value = null;
			this.dtStartDate.Value = null;
			this.txtSiteName.Text = "";
			this.cmbShiftStatus.SelectedIndex = -1;
			this.txtRegularWorkHrs.Value = null;
			this.txtRamadanWorkHrs.Value = null;
			this.txtMonthlyRate.Value = null;
			this.txtUnitOfAddition.Value = null;
			this.txtExtraWorkHourRate.Value = null;
			this.txtNightShiftPerc.Value = null;
		}

		// Token: 0x0400033E RID: 830
		private int FlageSave;

		// Token: 0x0400033F RID: 831
		protected HtmlGenericControl ultitle;

		// Token: 0x04000340 RID: 832
		protected ASPxLabel lblView;

		// Token: 0x04000341 RID: 833
		protected ASPxLabel lblEdite;

		// Token: 0x04000342 RID: 834
		protected ASPxLabel lblDelete;

		// Token: 0x04000343 RID: 835
		protected ASPxLabel lblAdd;

		// Token: 0x04000344 RID: 836
		protected ASPxButton BtnSave;

		// Token: 0x04000345 RID: 837
		protected ASPxButton BtnBack;

		// Token: 0x04000346 RID: 838
		protected HtmlGenericControl divmsg;

		// Token: 0x04000347 RID: 839
		protected ASPxLabel LblError;

		// Token: 0x04000348 RID: 840
		protected ASPxValidationSummary ASPxValidationSummary1;

		// Token: 0x04000349 RID: 841
		protected ASPxLabel lblMasterId;

		// Token: 0x0400034A RID: 842
		protected ASPxFormLayout flQuotationMaster;

		// Token: 0x0400034B RID: 843
		protected ASPxTextBox txtQuotationNo;

		// Token: 0x0400034C RID: 844
		protected ASPxDateEdit dtEntryDate;

		// Token: 0x0400034D RID: 845
		protected ASPxSpinEdit txtExpireIn;

		// Token: 0x0400034E RID: 846
		protected ASPxDateEdit dtExpiryDate;

		// Token: 0x0400034F RID: 847
		protected ASPxComboBox cmbFKEnquiryMasterID;

		// Token: 0x04000350 RID: 848
		protected ASPxComboBox cmbFKCustomerID;

		// Token: 0x04000351 RID: 849
		protected ASPxComboBox cmbFKProjectID;

		// Token: 0x04000352 RID: 850
		protected ASPxMemo txtRemarks;

		// Token: 0x04000353 RID: 851
		protected ASPxComboBox cmbStatusID;

		// Token: 0x04000354 RID: 852
		protected ASPxComboBox cmbPaymentTerms;

		// Token: 0x04000355 RID: 853
		protected ASPxComboBox cmbFKTermsConditionsID;

		// Token: 0x04000356 RID: 854
		protected ASPxCheckBox cbShowTotal;

		// Token: 0x04000357 RID: 855
		protected ASPxButton btnAddNewDetail;

		// Token: 0x04000358 RID: 856
		protected ASPxHiddenField hf;

		// Token: 0x04000359 RID: 857
		protected ASPxGridView GdvQuotationDetailsList;

		// Token: 0x0400035A RID: 858
		protected GridViewCommandColumnCustomButton btnWarning;

		// Token: 0x0400035B RID: 859
		protected GridViewCommandColumnCustomButton btnError;

		// Token: 0x0400035C RID: 860
		protected ASPxLabel lblTotalQuotaion;

		// Token: 0x0400035D RID: 861
		protected ASPxLabel lblWarning;

		// Token: 0x0400035E RID: 862
		protected ASPxLabel lblcpError;

		// Token: 0x0400035F RID: 863
		protected ASPxLoadingPanel ASPxLoadingPanel1;

		// Token: 0x04000360 RID: 864
		protected HtmlGenericControl divConfirmSection;

		// Token: 0x04000361 RID: 865
		protected ASPxButton btnApprove;

		// Token: 0x04000362 RID: 866
		protected ASPxButton btnReject;

		// Token: 0x04000363 RID: 867
		protected ASPxLabel lblMessageError;

		// Token: 0x04000364 RID: 868
		protected ASPxLabel lblErrorMessage;

		// Token: 0x04000365 RID: 869
		protected ASPxPopupControl popTestLists;

		// Token: 0x04000366 RID: 870
		protected PopupControlContentControl PopupControlContentControl;

		// Token: 0x04000367 RID: 871
		protected ASPxCheckBoxList lstTests;

		// Token: 0x04000368 RID: 872
		protected ASPxGridView GdvLabTestsList;

		// Token: 0x04000369 RID: 873
		protected ASPxPopupControl popAlert;

		// Token: 0x0400036A RID: 874
		protected PopupControlContentControl PopupControlContentControl2;

		// Token: 0x0400036B RID: 875
		protected ASPxLabel lblmessage;

		// Token: 0x0400036C RID: 876
		protected ASPxPopupControl popupWorkOrder;

		// Token: 0x0400036D RID: 877
		protected PopupControlContentControl PopupControlContentControl1;

		// Token: 0x0400036E RID: 878
		protected ASPxValidationSummary ASPxValidationSummary2;

		// Token: 0x0400036F RID: 879
		protected ASPxTextBox vi;

		// Token: 0x04000370 RID: 880
		protected ASPxTextBox Qid;

		// Token: 0x04000371 RID: 881
		protected ASPxTextBox sid;

		// Token: 0x04000372 RID: 882
		protected ASPxButton flRefresh;

		// Token: 0x04000373 RID: 883
		protected ASPxCallbackPanel cpnl;

		// Token: 0x04000374 RID: 884
		protected ASPxFormLayout flWorkOrder;

		// Token: 0x04000375 RID: 885
		protected ASPxTextBox txtWorkOrderNo;

		// Token: 0x04000376 RID: 886
		protected ASPxDateEdit dtTransDate;

		// Token: 0x04000377 RID: 887
		protected ASPxDateEdit dtStartDate;

		// Token: 0x04000378 RID: 888
		protected ASPxDateEdit dtEndDate;

		// Token: 0x04000379 RID: 889
		protected ASPxTextBox txtSiteName;

		// Token: 0x0400037A RID: 890
		protected ASPxComboBox cmbShiftStatus;

		// Token: 0x0400037B RID: 891
		protected ASPxSpinEdit txtRegularWorkHrs;

		// Token: 0x0400037C RID: 892
		protected ASPxSpinEdit txtRamadanWorkHrs;

		// Token: 0x0400037D RID: 893
		protected ASPxSpinEdit txtMonthlyRate;

		// Token: 0x0400037E RID: 894
		protected ASPxTextBox txtUnitOfAddition;

		// Token: 0x0400037F RID: 895
		protected ASPxSpinEdit txtExtraWorkHourRate;

		// Token: 0x04000380 RID: 896
		protected ASPxSpinEdit txtNightShiftPerc;

		// Token: 0x04000381 RID: 897
		protected ASPxTextBox txtDescription;

		// Token: 0x04000382 RID: 898
		protected ASPxButton btnUpdateWorkOrder;

		// Token: 0x04000383 RID: 899
		protected ASPxButton btnCancelUpdateWorkOrder;

		// Token: 0x04000384 RID: 900
		protected ASPxGridView GdvWorkOrderList;

		// Token: 0x04000385 RID: 901
		protected GridViewCommandColumnCustomButton WorkOrderEdit;

		// Token: 0x04000386 RID: 902
		protected ObjectDataSource EnquiryMasterDS;

		// Token: 0x04000387 RID: 903
		protected ObjectDataSource CustomersListDS;

		// Token: 0x04000388 RID: 904
		protected ObjectDataSource ProjectsListDS;

		// Token: 0x04000389 RID: 905
		protected ObjectDataSource MaterialsTypesDS;

		// Token: 0x0400038A RID: 906
		protected ObjectDataSource AllMaterialsListDS;

		// Token: 0x0400038B RID: 907
		protected ObjectDataSource MaterialsListDS;

		// Token: 0x0400038C RID: 908
		protected ObjectDataSource PaymentTermsDS;

		// Token: 0x0400038D RID: 909
		protected ObjectDataSource TermsConditionsDS;

		// Token: 0x0400038E RID: 910
		protected ObjectDataSource QuotationMasterDS;

		// Token: 0x0400038F RID: 911
		protected ObjectDataSource PriceUnitListDS;

		// Token: 0x04000390 RID: 912
		protected ObjectDataSource TestPriceUnitListDS;

		// Token: 0x04000391 RID: 913
		protected ObjectDataSource TestsListDS;

		// Token: 0x04000392 RID: 914
		protected ObjectDataSource QuotationDetailsDS;

		// Token: 0x04000393 RID: 915
		protected ObjectDataSource WorkOrderDS;

		// Token: 0x04000394 RID: 916
		protected ObjectDataSource WorkOrderListDS;
	}
}
