using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BusinessLayer
{
	// Token: 0x02000003 RID: 3
	public class ActSysAdminEntities : DbContext
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000020B8 File Offset: 0x000002B8
		public ActSysAdminEntities() : base("name=ActSysAdminEntities")
		{
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020C5 File Offset: 0x000002C5
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			throw new UnintentionalCodeFirstException();
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020CC File Offset: 0x000002CC
		// (set) Token: 0x0600000F RID: 15 RVA: 0x000020D4 File Offset: 0x000002D4
		public virtual DbSet<ADMCategoryMaster> ADMCategoryMaster { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000020DD File Offset: 0x000002DD
		// (set) Token: 0x06000011 RID: 17 RVA: 0x000020E5 File Offset: 0x000002E5
		public virtual DbSet<ADMLinkCategory> ADMLinkCategory { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000020EE File Offset: 0x000002EE
		// (set) Token: 0x06000013 RID: 19 RVA: 0x000020F6 File Offset: 0x000002F6
		public virtual DbSet<ADMLinks> ADMLinks { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000020FF File Offset: 0x000002FF
		// (set) Token: 0x06000015 RID: 21 RVA: 0x00002107 File Offset: 0x00000307
		public virtual DbSet<ADMModules> ADMModules { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002110 File Offset: 0x00000310
		// (set) Token: 0x06000017 RID: 23 RVA: 0x00002118 File Offset: 0x00000318
		public virtual DbSet<ADMOption> ADMOption { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002121 File Offset: 0x00000321
		// (set) Token: 0x06000019 RID: 25 RVA: 0x00002129 File Offset: 0x00000329
		public virtual DbSet<ADMReportPages> ADMReportPages { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002132 File Offset: 0x00000332
		// (set) Token: 0x0600001B RID: 27 RVA: 0x0000213A File Offset: 0x0000033A
		public virtual DbSet<ADMReports> ADMReports { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002143 File Offset: 0x00000343
		// (set) Token: 0x0600001D RID: 29 RVA: 0x0000214B File Offset: 0x0000034B
		public virtual DbSet<ADMReportsCategory> ADMReportsCategory { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002154 File Offset: 0x00000354
		// (set) Token: 0x0600001F RID: 31 RVA: 0x0000215C File Offset: 0x0000035C
		public virtual DbSet<ADMRoleLink> ADMRoleLink { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002165 File Offset: 0x00000365
		// (set) Token: 0x06000021 RID: 33 RVA: 0x0000216D File Offset: 0x0000036D
		public virtual DbSet<ADMRoleLinkOptions> ADMRoleLinkOptions { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002176 File Offset: 0x00000376
		// (set) Token: 0x06000023 RID: 35 RVA: 0x0000217E File Offset: 0x0000037E
		public virtual DbSet<ADMRoles> ADMRoles { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002187 File Offset: 0x00000387
		// (set) Token: 0x06000025 RID: 37 RVA: 0x0000218F File Offset: 0x0000038F
		public virtual DbSet<ADMUserRoles> ADMUserRoles { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002198 File Offset: 0x00000398
		// (set) Token: 0x06000027 RID: 39 RVA: 0x000021A0 File Offset: 0x000003A0
		public virtual DbSet<ADMUsers> ADMUsers { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000021A9 File Offset: 0x000003A9
		// (set) Token: 0x06000029 RID: 41 RVA: 0x000021B1 File Offset: 0x000003B1
		public virtual DbSet<ViewUserRolesList> ViewUserRolesList { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000021BA File Offset: 0x000003BA
		// (set) Token: 0x0600002B RID: 43 RVA: 0x000021C2 File Offset: 0x000003C2
		public virtual DbSet<RoleLinkOptionView> RoleLinkOptionView { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000021CB File Offset: 0x000003CB
		// (set) Token: 0x0600002D RID: 45 RVA: 0x000021D3 File Offset: 0x000003D3
		public virtual DbSet<ADMDatabases> ADMDatabases { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000021DC File Offset: 0x000003DC
		// (set) Token: 0x0600002F RID: 47 RVA: 0x000021E4 File Offset: 0x000003E4
		public virtual DbSet<UserLinkOptionsView> UserLinkOptionsView { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000021ED File Offset: 0x000003ED
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000021F5 File Offset: 0x000003F5
		public virtual DbSet<ADMUserSettings> ADMUserSettings { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000021FE File Offset: 0x000003FE
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002206 File Offset: 0x00000406
		public virtual DbSet<ADMAppSettings> ADMAppSettings { get; set; }
	}
}
