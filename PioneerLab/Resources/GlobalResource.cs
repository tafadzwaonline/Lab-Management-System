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
	// Token: 0x0200000B RID: 11
	[DebuggerNonUserCode]
	[GeneratedCode("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "11.0.0.0")]
	[CompilerGenerated]
	internal class GlobalResource
	{
		// Token: 0x06000069 RID: 105 RVA: 0x000022B0 File Offset: 0x000004B0
		internal GlobalResource()
		{
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600006A RID: 106 RVA: 0x000062CC File Offset: 0x000044CC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(GlobalResource.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Resources.GlobalResource", Assembly.Load("App_GlobalResources"));
					GlobalResource.resourceMan = resourceManager;
				}
				return GlobalResource.resourceMan;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600006B RID: 107 RVA: 0x000024FC File Offset: 0x000006FC
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00002503 File Offset: 0x00000703
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return GlobalResource.resourceCulture;
			}
			set
			{
				GlobalResource.resourceCulture = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600006D RID: 109 RVA: 0x0000250B File Offset: 0x0000070B
		internal static string align
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("align", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002521 File Offset: 0x00000721
		internal static string BtnAddNew
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnAddNew", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002537 File Offset: 0x00000737
		internal static string BtnApply
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnApply", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000070 RID: 112 RVA: 0x0000254D File Offset: 0x0000074D
		internal static string BtnCancel
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnCancel", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002563 File Offset: 0x00000763
		internal static string BtnConfirm
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnConfirm", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002579 File Offset: 0x00000779
		internal static string BtnDelete
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnDelete", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000073 RID: 115 RVA: 0x0000258F File Offset: 0x0000078F
		internal static string BtnEdit
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnEdit", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000025A5 File Offset: 0x000007A5
		internal static string BtnGenerate
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnGenerate", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000075 RID: 117 RVA: 0x000025BB File Offset: 0x000007BB
		internal static string BtnPrint
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnPrint", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000076 RID: 118 RVA: 0x000025D1 File Offset: 0x000007D1
		internal static string BtnSave
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnSave", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000077 RID: 119 RVA: 0x000025E7 File Offset: 0x000007E7
		internal static string BtnSearch
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnSearch", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000025FD File Offset: 0x000007FD
		internal static string BtnSelect
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("BtnSelect", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00002613 File Offset: 0x00000813
		internal static string EditFormNew
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("EditFormNew", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00002629 File Offset: 0x00000829
		internal static string EditFormUpdate
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("EditFormUpdate", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600007B RID: 123 RVA: 0x0000263F File Offset: 0x0000083F
		internal static string ErrorTitle
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("ErrorTitle", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00002655 File Offset: 0x00000855
		internal static string GridClearFilterText
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("GridClearFilterText", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600007D RID: 125 RVA: 0x0000266B File Offset: 0x0000086B
		internal static string GridConfirmDelete
		{
			get
			{
				return GlobalResource.ResourceManager.GetString("GridConfirmDelete", GlobalResource.resourceCulture);
			}
		}

		// Token: 0x04000049 RID: 73
		private static ResourceManager resourceMan;

		// Token: 0x0400004A RID: 74
		private static CultureInfo resourceCulture;
	}
}
