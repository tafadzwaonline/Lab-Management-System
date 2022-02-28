using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class LabsListDB : DBBase<LabsList, List<LabsList>, int>
	{
		public override List<LabsList> GetAll()
		{
			return ((IEnumerable<LabsList>)dbContext.LabsList).ToList();
		}

		public override LabsList GetByID(int id)
		{
			return ((IQueryable<LabsList>)dbContext.LabsList).FirstOrDefault((LabsList j) => j.LabID == id);
		}

		public override bool Insert(LabsList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.LabsList.Add(entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "InsertError";
				return false;
			}
			catch (Exception)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(LabsList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				LabsList byID = this.GetByID(entity.LabID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<LabsList>(byID);
				dbEntityEntry.State = EntityState.Modified;
				dbEntityEntry.CurrentValues.SetValues(entity);
				if (this.dbContext.SaveChanges() > 0)
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

		// Token: 0x0600090D RID: 2317 RVA: 0x00027B44 File Offset: 0x00025D44
		public override bool Delete(LabsList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<LabsList>(entity).State = EntityState.Deleted;
				if (this.dbContext.SaveChanges() > 0)
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


		public bool Insert(LabsList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(LabsList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(LabsList entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}
	}
}
