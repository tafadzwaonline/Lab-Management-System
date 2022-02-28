using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer
{
	// Token: 0x02000029 RID: 41
	[DataObject(true)]
	public abstract class DBGeneric<T, C, IDT> where T : class where C : DbContext, new()
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000259 RID: 601 RVA: 0x000075B8 File Offset: 0x000057B8
		// (set) Token: 0x0600025A RID: 602 RVA: 0x000075C0 File Offset: 0x000057C0
		public C Context
		{
			get
			{
				return this._entities;
			}
			set
			{
				this._entities = value;
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000075CC File Offset: 0x000057CC
		[DataObjectMethod(DataObjectMethodType.Select)]
		public virtual List<T> GetAll()
		{
			return this._entities.Set<T>().ToList<T>();
		}

		// Token: 0x0600025C RID: 604
		[DataObjectMethod(DataObjectMethodType.Select)]
		public abstract T GetByID(IDT id);

		// Token: 0x0600025D RID: 605 RVA: 0x000075F4 File Offset: 0x000057F4
		[DataObjectMethod(DataObjectMethodType.Insert)]
		public virtual bool Insert(T entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this._entities.Set<T>().Add(entity);
				if (this.Save())
				{
					result = true;
				}
				else
				{
					message = "InsertError";
					result = false;
				}
			}
			catch (Exception)
			{
				message = "InsertError";
				result = false;
			}
			return result;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00007654 File Offset: 0x00005854
		[DataObjectMethod(DataObjectMethodType.Update)]
		public virtual bool Update(T entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this._entities.Entry<T>(entity).State = EntityState.Modified;
				if (this.Save())
				{
					result = true;
				}
				else
				{
					message = "UpdateError";
					result = false;
				}
			}
			catch (Exception)
			{
				message = "";
				result = false;
			}
			return result;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000076B8 File Offset: 0x000058B8
		public bool Delete(IDT id, out string message)
		{
			return this.Delete(this.GetByID(id), out message);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000076C8 File Offset: 0x000058C8
		[DataObjectMethod(DataObjectMethodType.Delete)]
		public virtual bool Delete(T entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this._entities.Entry<T>(entity).State = EntityState.Deleted;
				if (this.Save())
				{
					result = true;
				}
				else
				{
					message = "DeleteError";
					result = false;
				}
			}
			catch (Exception)
			{
				message = "DeleteError";
				result = false;
			}
			return result;
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00007728 File Offset: 0x00005928
		public static string ConnectionString
		{
			get
			{
				return ConfigurationManager.ConnectionStrings["LabSysEntities"].ConnectionString;
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00007740 File Offset: 0x00005940
		public List<T> FindBy(Expression<Func<T, bool>> predicate)
		{
			return this._entities.Set<T>().Where(predicate).ToList<T>();
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000776B File Offset: 0x0000596B
		public virtual bool Save()
		{
			return this._entities.SaveChanges() > 0;
		}

		// Token: 0x040000F1 RID: 241
		private C _entities = Activator.CreateInstance<C>();
	}
}
