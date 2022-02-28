using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class WorkOrderInvoiceDB : DBBase<WorkOrderInvoice, List<WorkOrderInvoice>, long>
	{
		public override List<WorkOrderInvoice> GetAll()
		{
			return ((IEnumerable<WorkOrderInvoice>)dbContext.WorkOrderInvoice).ToList();
		}

		public override WorkOrderInvoice GetByID(long id)
		{
			return ((IQueryable<WorkOrderInvoice>)dbContext.WorkOrderInvoice).FirstOrDefault((WorkOrderInvoice j) => j.WorkOrderInvoiceId == id);
		}

		public override bool Insert(WorkOrderInvoice entity, out string message)
		{
			message = "";
			try
			{
				dbContext.WorkOrderInvoice.Add(entity);
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

		public override bool Update(WorkOrderInvoice entity, out string message)
		{
			message = "";
			try
			{
				WorkOrderInvoice byID = GetByID(entity.WorkOrderInvoiceId);
				DbEntityEntry val = ((DbContext)dbContext).Entry<WorkOrderInvoice>(byID);
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

		public override bool Delete(WorkOrderInvoice entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<WorkOrderInvoice>(entity).State = (EntityState)8;
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

		public bool Insert(WorkOrderInvoice entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(WorkOrderInvoice entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(WorkOrderInvoice entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<WorkOrderInvoice> GetByMasterID(long masterId)
		{
			return ((IQueryable<WorkOrderInvoice>)dbContext.WorkOrderInvoice).Where((WorkOrderInvoice x) => x.FkInvoiceId == masterId).ToList();
		}
	}
}
