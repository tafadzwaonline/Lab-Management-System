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
	// Token: 0x02000042 RID: 66
	public class ProjectInfo : Page
	{
		// Token: 0x060002B4 RID: 692 RVA: 0x00017BAC File Offset: 0x00015DAC
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				int num = Convert.ToInt32(base.Request["id"]);
				this.lblMasterId.Text = num.ToString();
				this.flProjectsList.DataBind();
				if (num == 0)
				{
					ProjectsListDB projectsListDB = new ProjectsListDB();
					this.txtCode.Text = projectsListDB.GetNewSerial();
				}
			}
			List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/ProjectInfoManage.aspx", long.Parse(this.Session["UserId"].ToString()));
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

		// Token: 0x060002B5 RID: 693 RVA: 0x00017D04 File Offset: 0x00015F04
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				long num = Convert.ToInt64(this.lblMasterId.Text);
				if (num > 0L)
				{
					if (this.lblEdite.Text == "True")
					{
						this.ProjectsListDS.Update();
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
					this.ProjectsListDS.Insert();
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
				if (ex.InnerException != null)
				{
					this.LblError.Text = ex.InnerException.Message;
				}
				else
				{
					this.LblError.Text = ex.Message;
				}
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x000038FF File Offset: 0x00001AFF
		protected void ProjectsListDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			e.InputParameters["entity"] = this.GetMasterEntity(0);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00003918 File Offset: 0x00001B18
		protected void ProjectsListDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been saved successfully!";
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00017E74 File Offset: 0x00016074
		protected void ProjectsListDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
		{
			int masterID = Convert.ToInt32(this.lblMasterId.Text);
			e.InputParameters["entity"] = this.GetMasterEntity(masterID);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00017EAC File Offset: 0x000160AC
		private ProjectsList GetMasterEntity(int MasterID)
		{
			ProjectsList projectsList;
			if (MasterID > 0)
			{
				projectsList = new ProjectsListDB().GetByID(MasterID);
			}
			else
			{
				projectsList = new ProjectsList();
			}
			projectsList.ProjectID = MasterID;
			projectsList.ProjectCode = this.txtCode.Text;
			projectsList.ProjectName = this.txtName.Text;
			projectsList.AshghalCode = this.txtAshghalCode.Text;
			projectsList.StartDate = (DateTime?)this.dtStartDate.Value;
			projectsList.EndDate = (DateTime?)this.dtEndDate.Value;
			projectsList.ProjectLocation = this.txtLocation.Text;
			projectsList.FKProjectTypeID = Convert.ToInt32(this.cmbProjectTypeID.Value);
			projectsList.ProjectConsultant = this.txtProjectConsultant.Text;
			projectsList.FKContractorID = new int?(Convert.ToInt32(this.cmbContractorID.Value));
			projectsList.ProjectOwner = this.txtProjectOwner.Text;
			projectsList.IsClosed = this.IsClosed.Checked;
			return projectsList;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00003954 File Offset: 0x00001B54
		protected void ProjectsListDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
		{
			this.divmsg.Attributes["class"] = "alert alert-success";
			this.LblError.ForeColor = Color.Green;
			this.LblError.Text = "Data has been Updated successfully!";
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00003990 File Offset: 0x00001B90
		protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("ProjectInfoManage.aspx");
		}

		// Token: 0x0400044F RID: 1103
		protected HtmlGenericControl ultitle;

		// Token: 0x04000450 RID: 1104
		protected ASPxLabel lblView;

		// Token: 0x04000451 RID: 1105
		protected ASPxLabel lblEdite;

		// Token: 0x04000452 RID: 1106
		protected ASPxLabel lblDelete;

		// Token: 0x04000453 RID: 1107
		protected ASPxLabel lblAdd;

		// Token: 0x04000454 RID: 1108
		protected ASPxButton BtnSave;

		// Token: 0x04000455 RID: 1109
		protected ASPxButton BtnBack;

		// Token: 0x04000456 RID: 1110
		protected HtmlGenericControl divmsg;

		// Token: 0x04000457 RID: 1111
		protected ASPxLabel LblError;

		// Token: 0x04000458 RID: 1112
		protected ASPxValidationSummary ASPxValidationSummary1;

		// Token: 0x04000459 RID: 1113
		protected ASPxLabel lblMasterId;

		// Token: 0x0400045A RID: 1114
		protected ASPxFormLayout flProjectsList;

		// Token: 0x0400045B RID: 1115
		protected ASPxCheckBox IsClosed;

		// Token: 0x0400045C RID: 1116
		protected ASPxTextBox txtCode;

		// Token: 0x0400045D RID: 1117
		protected ASPxTextBox txtAshghalCode;

		// Token: 0x0400045E RID: 1118
		protected ASPxDateEdit dtStartDate;

		// Token: 0x0400045F RID: 1119
		protected ASPxDateEdit dtEndDate;

		// Token: 0x04000460 RID: 1120
		protected ASPxTextBox txtName;

		// Token: 0x04000461 RID: 1121
		protected ASPxTextBox txtLocation;

		// Token: 0x04000462 RID: 1122
		protected ASPxComboBox cmbProjectTypeID;

		// Token: 0x04000463 RID: 1123
		protected ASPxTextBox txtProjectConsultant;

		// Token: 0x04000464 RID: 1124
		protected ASPxComboBox cmbContractorID;

		// Token: 0x04000465 RID: 1125
		protected ASPxTextBox txtProjectOwner;

		// Token: 0x04000466 RID: 1126
		protected ObjectDataSource ProjectsListDS;

		// Token: 0x04000467 RID: 1127
		protected ObjectDataSource ProjectsTypesDS;

		// Token: 0x04000468 RID: 1128
		protected ObjectDataSource ContractorsListDS;
	}
}
