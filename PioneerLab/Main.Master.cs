using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Web;

namespace PioneerLab
{
	// Token: 0x02000011 RID: 17
	public partial class Main : MasterPage
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00006720 File Offset: 0x00004920
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (base.Session["CurrentUser"] == null)
				{
					string str = "?redUri=" + base.Request.Url.ToString();
					base.Response.Redirect("~/Login.aspx" + str);
					return;
				}
				ADMUsers admusers = base.Session["CurrentUser"] as ADMUsers;
				this.UserName.InnerText = admusers.EName;
				RolesDB rolesDB = new RolesDB();
				new UserRolesDB();
				List<ADMRoles> list = (from i in rolesDB.GetAll()
				where i.UserType == Convert.ToInt32(base.Session["UserType"])
				select i).ToList<ADMRoles>();
				List<ADMCategoryMaster> list2 = new List<ADMCategoryMaster>();
				if (Convert.ToInt32(base.Session["UserType"]) == 1)
				{
					UsersDB usersDB = new UsersDB();
					ADMUsers admusers2 = base.Session["CurrentUser"] as ADMUsers;
					int userID = admusers2.UserID;
					ADMUsers byID = usersDB.GetByID(userID);
					List<ADMUserRoles> list3 = byID.ADMUserRoles.ToList<ADMUserRoles>();
					for (int k = 0; k < list3.Count; k++)
					{
						CategoryMasterDB categoryMasterDB = new CategoryMasterDB();
						ADMCategoryMaster master = categoryMasterDB.GetByID(list3[k].ADMRoles.ADMCategoryMaster.CategoryMasterID);
						if (!list2.Exists((ADMCategoryMaster x) => x.CategoryMasterID == master.CategoryMasterID))
						{
							list2.Add(master);
						}
					}
					this.FillSideMenu(list2, list3);
					this.FillNotifications();
					return;
				}
				for (int j = 0; j < list.Count; j++)
				{
					CategoryMasterDB categoryMasterDB2 = new CategoryMasterDB();
					ADMCategoryMaster byID2 = categoryMasterDB2.GetByID(Convert.ToInt32(list[j].FKModuleID));
					list2.Add(byID2);
				}
				List<ViewUserRolesList> userTypeRoles = rolesDB.GetUserTypeRoles(Convert.ToInt32(base.Session["UserType"]));
				this.FillSideMenu(list2, userTypeRoles);
				this.FillNotifications();
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000692C File Offset: 0x00004B2C
		private void FillSideMenu(List<ADMCategoryMaster> List, List<ViewUserRolesList> userList)
		{
			AdminDB adminDB = new AdminDB();
			LinksDB linksDB = new LinksDB();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(string.Format("<li class=''><a href='../Default.aspx'><i class='menu-icon fa fa-tachometer'></i><span class='menu-text'>Home </span></a><b class='arrow'></b></li>", new object[0]));
			List<ADMCategoryMaster> list = (from i in List
			orderby i.OrderNo
			select i).ToList<ADMCategoryMaster>();
			if (list.Count > 0)
			{
				foreach (ADMCategoryMaster admcategoryMaster in list)
				{
					stringBuilder.AppendLine(string.Format("<li class=''><a href='#' class='dropdown-toggle'><i class='menu-icon fa fa-desktop'></i><span class='menu-text'>{0}</span><b class='arrow fa fa-angle-down'></b></a><b class='arrow'></b><ul class='submenu'>", admcategoryMaster.CategoryMasterNameEn));
					List<ADMLinkCategory> linkCategoryByCatMaster = adminDB.GetLinkCategoryByCatMaster(admcategoryMaster.CategoryMasterID);
					if (linkCategoryByCatMaster.Count > 0)
					{
						foreach (ADMLinkCategory admlinkCategory in linkCategoryByCatMaster)
						{
							List<ADMLinks> linksByCategoryforUserRoles = linksDB.GetLinksByCategoryforUserRoles(userList, admlinkCategory.LinkCategoryID);
							if (linksByCategoryforUserRoles.Count > 0)
							{
								stringBuilder.AppendLine(string.Format("<li class=''><a href='#' class='dropdown-toggle'><i class='menu-icon fa fa-caret-right'></i>{0}<b class='arrow fa fa-angle-down'></b></a><b class='arrow'></b><ul class='submenu'>", admlinkCategory.LinkCategoryEName));
							}
							if (linksByCategoryforUserRoles.Count > 0)
							{
								foreach (ADMLinks admlinks in linksByCategoryforUserRoles)
								{
									if (admlinkCategory.LinkCategoryEName.Trim().ToLower() == "reports")
									{
										stringBuilder.AppendLine(string.Format("<li class=''><a href='{0}' target='_blank'><i class='menu-icon fa fa-caret-right'></i>{1}</a><b class='arrow'></b></li>", admlinks.Url, admlinks.LinksEName));
									}
									else
									{
										stringBuilder.AppendLine(string.Format("<li class=''><a href='{0}'><i class='menu-icon fa fa-caret-right'></i>{1}</a><b class='arrow'></b></li>", admlinks.Url, admlinks.LinksEName));
									}
								}
							}
							if (linksByCategoryforUserRoles.Count > 0)
							{
								stringBuilder.AppendLine("</ul></li>");
							}
						}
					}
					stringBuilder.AppendLine("</ul></li>");
				}
			}
			this.navList.InnerHtml = stringBuilder.ToString();
		} 

		// Token: 0x06000095 RID: 149 RVA: 0x00006B78 File Offset: 0x00004D78
		private void FillSideMenu(List<ADMCategoryMaster> List, List<ADMUserRoles> userList)
		{
			AdminDB adminDB = new AdminDB();
			LinksDB linksDB = new LinksDB();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(string.Format("<li class=''><a href='../Default.aspx'><i class='menu-icon fa fa-tachometer'></i><span class='menu-text'>Home</span></a><b class='arrow'></b></li>", new object[0]));
			List<ADMCategoryMaster> list = (from i in List
			orderby i.OrderNo
			select i).ToList<ADMCategoryMaster>();
			if (list.Count > 0)
			{
				foreach (ADMCategoryMaster admcategoryMaster in list)
				{
					stringBuilder.AppendLine(string.Format("<li class=''><a href='#' class='dropdown-toggle'><i class='menu-icon fa fa-desktop'></i><span class='menu-text'>{0}</span><b class='arrow fa fa-angle-down'></b></a><b class='arrow'></b><ul class='submenu'>", admcategoryMaster.CategoryMasterNameEn));
					List<ADMLinkCategory> linkCategoryByCatMaster = adminDB.GetLinkCategoryByCatMaster(admcategoryMaster.CategoryMasterID);
					if (linkCategoryByCatMaster.Count > 0)
					{
						foreach (ADMLinkCategory admlinkCategory in linkCategoryByCatMaster)
						{
							List<ADMLinks> linksByCategoryforUserRoles = linksDB.GetLinksByCategoryforUserRoles(userList, admlinkCategory.LinkCategoryID);
							if (linksByCategoryforUserRoles.Count > 0)
							{
								stringBuilder.AppendLine(string.Format("<li class=''><a href='#' class='dropdown-toggle'><i class='menu-icon fa fa-caret-right'></i>{0}<b class='arrow fa fa-angle-down'></b></a><b class='arrow'></b><ul class='submenu'>", admlinkCategory.LinkCategoryEName));
							}
							if (linksByCategoryforUserRoles.Count > 0)
							{
								foreach (ADMLinks admlinks in linksByCategoryforUserRoles)
								{
									if (admlinkCategory.LinkCategoryEName.Trim().ToLower() == "reports")
									{
										stringBuilder.AppendLine(string.Format("<li class=''><a href='{0}' target='_blank'><i class='menu-icon fa fa-caret-right'></i>{1}</a><b class='arrow'></b></li>", admlinks.Url, admlinks.LinksEName));
									}
									else
									{
										stringBuilder.AppendLine(string.Format("<li class=''><a href='{0}'><i class='menu-icon fa fa-caret-right'></i>{1}</a><b class='arrow'></b></li>", admlinks.Url, admlinks.LinksEName));
									}
								}
							}
							if (linksByCategoryforUserRoles.Count > 0)
							{
								stringBuilder.AppendLine("</ul></li>");
							}
						}
					}
					stringBuilder.AppendLine("</ul></li>");
				}
			}
			this.navList.InnerHtml = stringBuilder.ToString();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000026FC File Offset: 0x000008FC
		protected void btnSave_Click(object sender, EventArgs e)
		{
			this.popupClear.ShowOnPageLoad = false;
			this.ChangePassword();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006DC4 File Offset: 0x00004FC4
		private void ChangePassword()
		{
			AdminDB adminDB = new AdminDB();
			ADMUsers admusers = (ADMUsers)base.Session["CurrentUser"];
			if (CryptoHelper.Encrypt(this.Oldpassword.Text, "act123") != admusers.Password)
			{
				ScriptManager.RegisterStartupScript(this.btnSave, typeof(string), "", "alert('Old password is incorrect');", true);
				return;
			}
			int num = (int)base.Session["UserType"];
			int num2 = num;
			if (num2 != 1)
			{
				return;
			}
			if (adminDB.ChangeAdminPassword(admusers.UserID, CryptoHelper.Encrypt(this.NewPassword.Text, "act123")))
			{
				ScriptManager.RegisterStartupScript(this.btnSave, typeof(string), "", "alert('Password changed successfully');window.location.href='../login.aspx';", true);
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00006E90 File Offset: 0x00005090
		private void FillNotifications()
		{
			List<ADMUserSettings> allUserSettings = new ADMUserSettingsDB().GetAllUserSettings(int.Parse(base.Session["UserId"].ToString()));
			foreach (ADMUserSettings admuserSettings in allUserSettings)
			{
				if (admuserSettings.SettingsName == "Job Order Notification" && admuserSettings.SettingsValue != "True")
				{
					this.JobOrder.Attributes["class"] = "hidden";
				}
				if (admuserSettings.SettingsName == "Quotation Notification" && admuserSettings.SettingsValue != "True")
				{
					this.Quotation.Attributes["class"] = "hidden";
				}
				if (admuserSettings.SettingsName == "Enquiry Notification" && admuserSettings.SettingsValue != "True")
				{
					this.Enquiry.Attributes["class"] = "hidden";
				}
			}
			new StringBuilder();
			Convert.ToDecimal(base.Session["StaffId"]);
			Convert.ToDecimal(base.Session["DepId"]);
			List<ViewBendingEnquiryMaster> allPending = new EnquiryMasterDB().GetAllPending();
			List<ViewNewQuotationMaster> allNew = new QuotationMasterDB().GetAllNew();
			List<JobOrderMaster> allPending2 = new JobOrderMasterDB().GetAllPending();
			int count = allPending.Count;
			int count2 = allNew.Count;
			int count3 = allPending2.Count;
			this.QnotiNewCount.InnerText = string.Format("You Have {0} New Pending Quotation{1}", (count2 > 0) ? count2.ToString() : "No", (count2 == 0) ? "s" : "");
			this.JOnotiNewCount.InnerText = string.Format("You Have {0} New Pending Job Order{1}", (count3 > 0) ? count3.ToString() : "No", (count3 == 0) ? "s" : "");
			this.EnqnotiNewCount.InnerText = string.Format("You Have {0} New Pending Enquiry{1}", (count > 0) ? count.ToString() : "No", (count == 0) ? "s" : "");
			if (count > 0)
			{
				this.EnqnotiCount.Attributes["class"] = "badge";
				this.EnqnotiCount.InnerText = count.ToString();
			}
			else
			{
				this.EnqnotiCount.Attributes["class"] = "hidden";
			}
			if (count2 > 0)
			{
				this.QnotiCount.Attributes["class"] = "badge";
				this.QnotiCount.InnerText = count2.ToString();
			}
			else
			{
				this.QnotiCount.Attributes["class"] = "hidden";
			}
			if (count3 > 0)
			{
				this.JOnotiCount.Attributes["class"] = "badge";
				this.JOnotiCount.InnerText = count3.ToString();
			}
			else
			{
				this.JOnotiCount.Attributes["class"] = "hidden";
			}
		}

		// Token: 0x0400005C RID: 92

		// Token: 0x0400005D RID: 93

		// Token: 0x0400005E RID: 94

		// Token: 0x0400005F RID: 95

		// Token: 0x04000060 RID: 96

		// Token: 0x04000061 RID: 97

		// Token: 0x04000062 RID: 98

		// Token: 0x04000063 RID: 99

		// Token: 0x04000064 RID: 100

		// Token: 0x04000065 RID: 101

		// Token: 0x04000066 RID: 102

		// Token: 0x04000067 RID: 103

		// Token: 0x04000068 RID: 104

		// Token: 0x04000069 RID: 105

		// Token: 0x0400006A RID: 106

		// Token: 0x0400006B RID: 107

		// Token: 0x0400006C RID: 108

		// Token: 0x0400006D RID: 109

		// Token: 0x0400006E RID: 110

		// Token: 0x0400006F RID: 111

		// Token: 0x04000070 RID: 112

		// Token: 0x04000071 RID: 113

		// Token: 0x04000072 RID: 114

		// Token: 0x04000073 RID: 115

		// Token: 0x04000074 RID: 116

		// Token: 0x04000075 RID: 117

		// Token: 0x04000076 RID: 118
	}
}
