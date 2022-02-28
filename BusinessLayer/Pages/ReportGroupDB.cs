using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Pages
{
	public class ReportGroupDB : DBBase<ReportGroup, List<ReportGroup>, int>
	{
		public override List<ReportGroup> GetAll()
		{
			return ((IEnumerable<ReportGroup>)dbContext.ReportGroup).ToList();
		}

		public override ReportGroup GetByID(int id)
		{
			return ((IQueryable<ReportGroup>)dbContext.ReportGroup).FirstOrDefault((ReportGroup j) => j.GroupID == id);
		}

		public override bool Insert(ReportGroup entity, out string message)
		{
			message = "";
			try
			{
				dbContext.ReportGroup.Add(entity);
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

		public override bool Update(ReportGroup entity, out string message)
		{
			message = "";
			try
			{
				ReportGroup byID = GetByID(entity.GroupID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<ReportGroup>(byID);
				val.State = (EntityState)16;
				val.CurrentValues.SetValues((object)entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "UpdateError";
				return false;
			}
			catch (Exception)
			{
				message = "";
				return false;
			}
		}

		public override bool Delete(ReportGroup entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<ReportGroup>(entity).State = (EntityState)8;
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "DeleteError";
				return false;
			}
			catch (Exception)
			{
				message = "DeleteError";
				return false;
			}
		}

		public bool Insert(ReportGroup entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(ReportGroup entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(ReportGroup entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public string GetNewSerial()
		{
			string maxGroupNumber = GetMaxGroupNumber();
			string str = ((int.Parse(maxGroupNumber) <= 0) ? "1" : (Convert.ToInt32(maxGroupNumber) + 1).ToString());
			return str = "0" + str;
		}

		private string GetMaxGroupNumber()
		{
			int? num = ((IQueryable<ReportGroup>)dbContext.ReportGroup).Max((Expression<Func<ReportGroup, int?>>)((ReportGroup entity) => entity.GroupID));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).GroupNumber;
				if (text == null)
				{
					text = "0";
				}
				return text;
			}
			return "0";
		}
	}
}
