using System;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Extensions;

namespace PioneerLab
{
	// Token: 0x0200004E RID: 78
	public class ReportStorageWebExtension1 : ReportStorageWebExtension
	{
		// Token: 0x0600030D RID: 781 RVA: 0x00003CAD File Offset: 0x00001EAD
		public override bool CanSetData(string url)
		{
			return base.CanSetData(url);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00003CB6 File Offset: 0x00001EB6
		public override bool IsValidUrl(string url)
		{
			return base.IsValidUrl(url);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00003CBF File Offset: 0x00001EBF
		public override byte[] GetData(string url)
		{
			return base.GetData(url);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00003CC8 File Offset: 0x00001EC8
		public override Dictionary<string, string> GetUrls()
		{
			return base.GetUrls();
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00003CD0 File Offset: 0x00001ED0
		public override void SetData(XtraReport report, string url)
		{
			base.SetData(report, url);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00003CDA File Offset: 0x00001EDA
		public override string SetNewData(XtraReport report, string defaultUrl)
		{
			return base.SetNewData(report, defaultUrl);
		}
	}
}
