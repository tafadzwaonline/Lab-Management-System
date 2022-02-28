using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Pages
{
	public class InvoiceDB : DBBase<Invoice, List<Invoice>, long>
	{
		public override List<Invoice> GetAll()
		{
			return (from x in ((IEnumerable<Invoice>)dbContext.Invoice).ToList()
				orderby x.InvoiceId descending
				select x).ToList();
		}

		public override Invoice GetByID(long id)
		{
			return ((IQueryable<Invoice>)dbContext.Invoice).FirstOrDefault((Invoice j) => j.InvoiceId == id);
		}

		public override bool Insert(Invoice entity, out string message)
		{
			message = "";
			try
			{
				if (CheckExist(entity.InvoiceNumber))
				{
					message = "The invoice number is present";
					return false;
				}
				dbContext.Invoice.Add(entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					if (entity.WorkOrderInvoice != null)
					{
						foreach (WorkOrderInvoice item in entity.WorkOrderInvoice)
						{
							List<WorkOrderTimeSheet> byWorkOrderByDate = new WorkOrderTimeSheetDB().GetByWorkOrderByDate(item.StartDate, item.EndDate, item.FkWorkOrderId);
							foreach (WorkOrderTimeSheet item2 in byWorkOrderByDate)
							{
								item2.IsInvoiced = true;
								item2.InvoiceNumber = entity.InvoiceNumber;
								new WorkOrderTimeSheetDB().Update(item2);
							}
						}
					}
					if (entity.SampleReceiveTestInvoice != null)
					{
						foreach (SampleReceiveTestInvoice item3 in entity.SampleReceiveTestInvoice)
						{
							SampleReceiveTestList byID = new SampleReceiveTestListDB().GetByID(item3.FkSampleReceiveTestID);
							byID.IsInvoiced = true;
							new SampleReceiveTestListDB().Update(byID);
						}
					}
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

		public override bool Update(Invoice entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				Invoice byID = this.GetByID(entity.InvoiceId);
				if (this.CheckExist(entity.InvoiceNumber) && entity.InvoiceNumber != byID.InvoiceNumber)
				{
					message = "The invoice number is present";
					result = false;
				}
				else
				{
					DbEntityEntry dbEntityEntry = this.dbContext.Entry<Invoice>(byID);
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
			}
			catch (Exception)
			{
				message = "";
				result = false;
			}
			return result;
		}

		public override bool Delete(Invoice entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				List<PaymentDetails> byInvoiceID = new PaymentDetailsDB().GetByInvoiceID(entity.InvoiceId);
				if (byInvoiceID.Count <= 0)
				{
					this.dbContext.Invoice.Attach(entity);
					this.dbContext.Entry<Invoice>(entity).State = EntityState.Deleted;
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
				else
				{
					message = "This Invoice Linked With payment ";
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

		public bool Insert(Invoice entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(Invoice entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(Invoice entity)
		{
			string message = "";
			List<WorkOrderInvoice> byMasterID = new WorkOrderInvoiceDB().GetByMasterID(entity.InvoiceId);
			foreach (WorkOrderInvoice item in byMasterID)
			{
				List<WorkOrderTimeSheet> byWorkOrderByDate = new WorkOrderTimeSheetDB().GetByWorkOrderByDate(item.StartDate, item.EndDate, item.FkWorkOrderId);
				foreach (WorkOrderTimeSheet item2 in byWorkOrderByDate)
				{
					item2.IsInvoiced = false;
					item2.InvoiceNumber = "";
					new WorkOrderTimeSheetDB().Update(item2);
				}
				new WorkOrderInvoiceDB().Delete(item.WorkOrderInvoiceId, out message);
			}
			List<SampleReceiveTestInvoice> byMasterID2 = new SampleReceiveTestInvoiceDB().GetByMasterID(entity.InvoiceId);
			foreach (SampleReceiveTestInvoice item3 in byMasterID2)
			{
				new SampleReceiveTestInvoiceDB().Delete(item3);
				SampleReceiveTestList byID = new SampleReceiveTestListDB().GetByID(item3.FkSampleReceiveTestID);
				byID.IsInvoiced = false;
				new SampleReceiveTestListDB().Update(byID);
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(ViewGelAllInvoice entity)
		{
			string message = "";
			List<WorkOrderInvoice> byMasterID = new WorkOrderInvoiceDB().GetByMasterID(entity.InvoiceId);
			foreach (WorkOrderInvoice item in byMasterID)
			{
				List<WorkOrderTimeSheet> byWorkOrderByDate = new WorkOrderTimeSheetDB().GetByWorkOrderByDate(item.StartDate, item.EndDate, item.FkWorkOrderId);
				foreach (WorkOrderTimeSheet item2 in byWorkOrderByDate)
				{
					item2.IsInvoiced = false;
					item2.InvoiceNumber = "";
					new WorkOrderTimeSheetDB().Update(item2);
				}
				new WorkOrderInvoiceDB().Delete(item.WorkOrderInvoiceId, out message);
			}
			List<SampleReceiveTestInvoice> byMasterID2 = new SampleReceiveTestInvoiceDB().GetByMasterID(entity.InvoiceId);
			foreach (SampleReceiveTestInvoice item3 in byMasterID2)
			{
				new SampleReceiveTestInvoiceDB().Delete(item3);
				SampleReceiveTestList byID = new SampleReceiveTestListDB().GetByID(item3.FkSampleReceiveTestID);
				byID.IsInvoiced = false;
				new SampleReceiveTestListDB().Update(byID);
			}
			Invoice byID2 = GetByID(entity.InvoiceId);
			if (Delete(byID2, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

        public string GetNewSerial()
        {
            string maxInvoiceNo = GetMaxInvoiceNo();
            if (!maxInvoiceNo.Contains("INV-"))
                maxInvoiceNo = "INV-6000";
            else
            {
                string[] splittedInvNo = maxInvoiceNo.Split('-');
                int invNo = Convert.ToInt32(splittedInvNo[1]) + 1;
                maxInvoiceNo = "INV-" + invNo;
            }
            return maxInvoiceNo;
        }

		public string GetlastSerial()
		{
			return GetMaxInvoiceNo();
		}

		private string GetMaxInvoiceNo()
		{
			long? num = ((IQueryable<Invoice>)dbContext.Invoice).Max((Expression<Func<Invoice, long?>>)((Invoice entity) => entity.InvoiceId));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).InvoiceNumber;
				if (text == null)
				{
					text = "0";
				}
				return text;
			}
			return "0";
		}

		public bool CheckExist(string InvoiceNumber)
		{
			Invoice invoice = ((IQueryable<Invoice>)dbContext.Invoice).Where((Invoice i) => i.InvoiceNumber == InvoiceNumber).FirstOrDefault();
			if (invoice == null)
			{
				return false;
			}
			return true;
		}

		public List<ViewInvoicesBalance> GetViewInvoicesBalanceByCustomerId(int CustomerID)
		{
			return (from x in (IQueryable<ViewInvoicesBalance>)dbContext.ViewInvoicesBalance
				where x.FKCustomerID == CustomerID && x.NetAmount != (decimal?)x.PaidAmount
				orderby x.InvoiceId descending
				select x).ToList();
		}

		public List<ViewInvoicesBalance> GetViewInvoicesBalanceByJobOrderId(int JobOrderMasterID)
		{
			return (from x in (IQueryable<ViewInvoicesBalance>)dbContext.ViewInvoicesBalance
				where x.FKJobOrderMasterID == (long)JobOrderMasterID && x.NetAmount != (decimal?)x.PaidAmount
				orderby x.InvoiceId descending
				select x).ToList();
		}

		public List<ViewGelAllInvoice> GetAllFromView()
		{
			return (from x in ((IEnumerable<ViewGelAllInvoice>)dbContext.ViewGelAllInvoice).ToList()
				orderby x.InvoiceId descending
				select x).ToList();
		}
	}
}
