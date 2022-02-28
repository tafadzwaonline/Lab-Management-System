using System;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;

namespace BusinessLayer
{
	// Token: 0x02000028 RID: 40
	[DataObject(true)]
	public abstract class DBBase<T, TCollection, IDT> : IRequiresSessionState
	{
		// Token: 0x06000250 RID: 592
		[DataObjectMethod(DataObjectMethodType.Select)]
		public abstract TCollection GetAll();

		// Token: 0x06000251 RID: 593
		[DataObjectMethod(DataObjectMethodType.Select)]
		public abstract T GetByID(IDT id);

		// Token: 0x06000252 RID: 594
		[DataObjectMethod(DataObjectMethodType.Insert)]
		public abstract bool Insert(T entity, out string message);

		// Token: 0x06000253 RID: 595
		[DataObjectMethod(DataObjectMethodType.Update)]
		public abstract bool Update(T entity, out string message);

		// Token: 0x06000254 RID: 596 RVA: 0x00007481 File Offset: 0x00005681
		public bool Delete(IDT id, out string message)
		{
			return this.Delete(this.GetByID(id), out message);
		}

		// Token: 0x06000255 RID: 597
		[DataObjectMethod(DataObjectMethodType.Delete)]
		public abstract bool Delete(T entity, out string message);

		// Token: 0x06000256 RID: 598 RVA: 0x00007494 File Offset: 0x00005694
		[WebMethod(EnableSession = true)]
		public static string ConnectionStringMethod()
		{
			string text = ConfigurationManager.ConnectionStrings["LabSysEntities"].ConnectionString;
			if (HttpContext.Current.Session != null)
			{
				if (HttpContext.Current.Session["DataBaseName"] != null)
				{
					string newValue = HttpContext.Current.Session["DataBaseName"].ToString();
					text = text.Replace("DBName", newValue);
				}
				else
				{
					string str = "?redUri=" + HttpContext.Current.Request.Url.ToString();
					HttpContext.Current.Response.Redirect("~/Login.aspx" + str);
				}
				return text;
			}
			return text;
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00007540 File Offset: 0x00005740
		public static string ConnectionString
		{
			get
			{
				string text = ConfigurationManager.ConnectionStrings["LabSysEntities"].ConnectionString;
				if (HttpContext.Current.Session["DataBaseName"] != null)
				{
					string newValue = HttpContext.Current.Session["DataBaseName"].ToString();
					text = text.Replace("DBName", newValue);
				}
				return text;
			}
		}

		// Token: 0x040000F0 RID: 240
		public LabSysEntities dbContext = new LabSysEntities(DBBase<T, TCollection, IDT>.ConnectionStringMethod());
	}
}
