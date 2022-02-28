using System;
using System.Web.UI;

namespace SMSWebSite
{
	// Token: 0x02000002 RID: 2
	public class ACTPage : Page
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public string align
		{
			get
			{
				return "left";
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002057 File Offset: 0x00000257
		public string Xalign
		{
			get
			{
				return "right";
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000205E File Offset: 0x0000025E
		protected void RedirectToDefault(bool endResponse = true)
		{
			base.Response.Redirect("../Error Page/ErrorPage.aspx", endResponse);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002071 File Offset: 0x00000271
		protected void Page_PreInit(object sender, EventArgs e)
		{
		}
	}
}
