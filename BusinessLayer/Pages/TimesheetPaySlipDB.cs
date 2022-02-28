using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class TimesheetPaySlipDB : DBBase<TimesheetPaySlip, List<TimesheetPaySlip>, long>
	{
		public override List<TimesheetPaySlip> GetAll()
		{
			return ((IEnumerable<TimesheetPaySlip>)dbContext.TimesheetPaySlip).ToList();
		}

		public override TimesheetPaySlip GetByID(long id)
		{
			return ((IQueryable<TimesheetPaySlip>)dbContext.TimesheetPaySlip).FirstOrDefault((TimesheetPaySlip j) => j.PaySlipID == id);
		}

		public override bool Insert(TimesheetPaySlip entity, out string message)
		{
			message = "";
			try
			{
				dbContext.TimesheetPaySlip.Add(entity);
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

		public override bool Update(TimesheetPaySlip entity, out string message)
		{
			message = "";
			try
			{
				TimesheetPaySlip byID = GetByID(entity.PaySlipID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<TimesheetPaySlip>(byID);
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

		public override bool Delete(TimesheetPaySlip entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<TimesheetPaySlip>(entity).State = (EntityState)8;
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

		public bool Insert(TimesheetPaySlip entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(TimesheetPaySlip entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(TimesheetPaySlip entity)
		{
			string message = "";
			if (Delete(entity.PaySlipID, out message))
			{
				return true;
			}
			throw new Exception(message);
		}
	}
}
