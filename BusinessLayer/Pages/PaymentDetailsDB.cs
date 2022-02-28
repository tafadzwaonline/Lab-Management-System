using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class PaymentDetailsDB : DBBase<PaymentDetails, List<PaymentDetails>, long>
	{
		public override List<PaymentDetails> GetAll()
		{
			return ((IEnumerable<PaymentDetails>)dbContext.PaymentDetails).ToList();
		}

		public override PaymentDetails GetByID(long id)
		{
			return ((IQueryable<PaymentDetails>)dbContext.PaymentDetails).FirstOrDefault((PaymentDetails j) => j.PaymentDetID == id);
		}

		public override bool Insert(PaymentDetails entity, out string message)
		{
			message = "";
			try
			{
				dbContext.PaymentDetails.Add(entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					new SampleReceiveTestListDB().UpdateInvoiceedFromSession();
					new WorkOrderListDB().UpdateInvoiceedFromSession();
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

		public override bool Update(PaymentDetails entity, out string message)
		{
			message = "";
			try
			{
				PaymentDetails byID = GetByID(entity.PaymentDetID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<PaymentDetails>(byID);
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

		public override bool Delete(PaymentDetails entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<PaymentDetails>(entity).State = (EntityState)8;
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

		public bool Insert(PaymentDetails entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(PaymentDetails entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(PaymentDetails entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<PaymentDetails> GetByMasterID(long id)
		{
			return ((IQueryable<PaymentDetails>)dbContext.PaymentDetails).Where((PaymentDetails j) => j.FKPaymentID == id).ToList();
		}

		public List<PaymentDetails> GetByInvoiceID(long id)
		{
			return ((IQueryable<PaymentDetails>)dbContext.PaymentDetails).Where((PaymentDetails j) => j.FKInvoiceId == id).ToList();
		}

		public bool UpdateToSession(ViewInvoicesBalance entity)
		{
			object obj = HttpContext.Current.Session["InvoiceSelectedSession"];
			if (obj != null)
			{
				List<ViewInvoicesBalance> list = obj as List<ViewInvoicesBalance>;
				ViewInvoicesBalance viewInvoicesBalance = list.First((ViewInvoicesBalance x) => x.InvoiceId == entity.InvoiceId);
				decimal num = decimal.Parse(HttpContext.Current.Session["PaidAmount"].ToString());
				if (entity.PaidAmount <= num)
				{
					viewInvoicesBalance.PaidAmount = entity.PaidAmount;
				}
				if (entity.PaidAmount > num && num != 0m)
				{
					viewInvoicesBalance.PaidAmount = num;
				}
				HttpContext.Current.Session["InvoiceSelectedSession"] = list;
			}
			return true;
		}

		public bool DeleteToSession(ViewInvoicesBalance entity)
		{
			object obj = HttpContext.Current.Session["InvoiceSelectedSession"];
			List<ViewInvoicesBalance> list;
			if (obj != null)
			{
				list = obj as List<ViewInvoicesBalance>;
				list.RemoveAll((ViewInvoicesBalance x) => x.InvoiceId == entity.InvoiceId);
			}
			else
			{
				list = new List<ViewInvoicesBalance>();
			}
			HttpContext.Current.Session["InvoiceSelectedSession"] = list;
			return true;
		}

		public List<ViewInvoicesBalance> GetInvoicesFromSession(int MasterId)
		{
			if (MasterId != 0)
			{
				PaymentMaster byID = new PaymentMasterDB().GetByID(MasterId);
				if (byID.PaymentType == 0 || byID.PaymentDetails.Count > 0)
				{
					List<ViewInvoicesBalance> list = new List<ViewInvoicesBalance>();
					List<PaymentDetails> list2 = new PaymentDetailsDB().GetByMasterID(MasterId).ToList();
					{
						foreach (PaymentDetails item in list2)
						{
							ViewInvoicesBalance viewInvoicesBalance = ((IQueryable<ViewInvoicesBalance>)dbContext.ViewInvoicesBalance).Where((ViewInvoicesBalance x) => x.InvoiceId == item.FKInvoiceId).FirstOrDefault();
							viewInvoicesBalance.PaidAmount = item.PaidAmount;
							list.Add(viewInvoicesBalance);
						}
						return list;
					}
				}
				object obj = HttpContext.Current.Session["InvoiceSelectedSession"];
				return obj as List<ViewInvoicesBalance>;
			}
			object obj2 = HttpContext.Current.Session["InvoiceSelectedSession"];
			return obj2 as List<ViewInvoicesBalance>;
		}
	}
}
