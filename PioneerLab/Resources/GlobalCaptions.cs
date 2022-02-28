using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Resources
{
	// Token: 0x02000009 RID: 9
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "11.0.0.0")]
	internal class GlobalCaptions
	{
		// Token: 0x06000048 RID: 72 RVA: 0x000022B0 File Offset: 0x000004B0
		internal GlobalCaptions()
		{
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00006254 File Offset: 0x00004454
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(GlobalCaptions.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Resources.GlobalCaptions", Assembly.Load("App_GlobalResources"));
					GlobalCaptions.resourceMan = resourceManager;
				}
				return GlobalCaptions.resourceMan;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000022B8 File Offset: 0x000004B8
		// (set) Token: 0x0600004B RID: 75 RVA: 0x000022BF File Offset: 0x000004BF
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return GlobalCaptions.resourceCulture;
			}
			set
			{
				GlobalCaptions.resourceCulture = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000022C7 File Offset: 0x000004C7
		internal static string CurrencyNameAr
		{
			get
			{
				return GlobalCaptions.ResourceManager.GetString("CurrencyNameAr", GlobalCaptions.resourceCulture);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000022DD File Offset: 0x000004DD
		internal static string CurrencyNameEn
		{
			get
			{
				return GlobalCaptions.ResourceManager.GetString("CurrencyNameEn", GlobalCaptions.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000022F3 File Offset: 0x000004F3
		internal static string CurrencyRate
		{
			get
			{
				return GlobalCaptions.ResourceManager.GetString("CurrencyRate", GlobalCaptions.resourceCulture);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002309 File Offset: 0x00000509
		internal static string CurrencySympol
		{
			get
			{
				return GlobalCaptions.ResourceManager.GetString("CurrencySympol", GlobalCaptions.resourceCulture);
			}
		}

		// Token: 0x04000045 RID: 69
		private static ResourceManager resourceMan;

		// Token: 0x04000046 RID: 70
		private static CultureInfo resourceCulture;
	}
}
