using System;
using System.Web;
using DevExpress.Web;

namespace PioneerLab
{
	// Token: 0x0200000E RID: 14
	public class Global : HttpApplication
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00002071 File Offset: 0x00000271
		protected void Application_Start(object sender, EventArgs e)
		{
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002071 File Offset: 0x00000271
		protected void Session_Start(object sender, EventArgs e)
		{
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00002071 File Offset: 0x00000271
		protected void Application_BeginRequest(object sender, EventArgs e)
		{
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002071 File Offset: 0x00000271
		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002681 File Offset: 0x00000881
		protected void Application_Error(object sender, EventArgs e)
		{
			ASPxWebControl.CallbackError += this.Callback_Error;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00006308 File Offset: 0x00004508
		private void Callback_Error(object sender, EventArgs e)
		{
			Exception lastError = HttpContext.Current.Server.GetLastError();
			ASPxWebControl.SetCallbackErrorMessage(lastError.Message);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00002071 File Offset: 0x00000271
		protected void Session_End(object sender, EventArgs e)
		{
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002071 File Offset: 0x00000271
		protected void Application_End(object sender, EventArgs e)
		{
		}
	}
}
