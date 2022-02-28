using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class SampleReceiveTestInvoiceDB : DBBase<SampleReceiveTestInvoice, List<SampleReceiveTestInvoice>, long>
	{
		public override List<SampleReceiveTestInvoice> GetAll()
		{
			return ((IEnumerable<SampleReceiveTestInvoice>)dbContext.SampleReceiveTestInvoice).ToList();
		}

		public override SampleReceiveTestInvoice GetByID(long id)
		{
			return ((IQueryable<SampleReceiveTestInvoice>)dbContext.SampleReceiveTestInvoice).FirstOrDefault((SampleReceiveTestInvoice j) => j.SampleReceiveTestInvoiceID == id);
		}

		public override bool Insert(SampleReceiveTestInvoice entity, out string message)
		{
			message = "";
			try
			{
				dbContext.SampleReceiveTestInvoice.Add(entity);
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

		public override bool Update(SampleReceiveTestInvoice entity, out string message)
		{
			message = "";
			try
			{
				SampleReceiveTestInvoice byID = GetByID(entity.SampleReceiveTestInvoiceID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<SampleReceiveTestInvoice>(byID);
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

		public override bool Delete(SampleReceiveTestInvoice entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<SampleReceiveTestInvoice>(entity).State = (EntityState)8;
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

		public bool Insert(SampleReceiveTestInvoice entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(SampleReceiveTestInvoice entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(SampleReceiveTestInvoice entity)
		{
			string message = "";
			if (Delete(entity.SampleReceiveTestInvoiceID, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<SampleReceiveTestInvoice> GetByMasterID(long masterId)
		{
			return ((IQueryable<SampleReceiveTestInvoice>)dbContext.SampleReceiveTestInvoice).Where((SampleReceiveTestInvoice x) => x.FkInvoiceId == masterId).ToList();
		}

		public List<SampleReceiveTestInvoice> GetBySampleID(long SampleId)
		{
			return ((IQueryable<SampleReceiveTestInvoice>)dbContext.SampleReceiveTestInvoice).Where((SampleReceiveTestInvoice x) => x.FkSampleReceiveTestID == SampleId).ToList();
		}
	}
}
