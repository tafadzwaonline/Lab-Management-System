using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BusinessLayer.Pages
{
	public class EnquiryMasterDB : DBBase<EnquiryMaster, List<EnquiryMaster>, long>
	{
		public override List<EnquiryMaster> GetAll()
		{
			return ((IQueryable<EnquiryMaster>)dbContext.EnquiryMaster).OrderByDescending((EnquiryMaster x) => x.EnquiryMasterID).ToList();
		}

		public override EnquiryMaster GetByID(long id)
		{
			return ((IQueryable<EnquiryMaster>)dbContext.EnquiryMaster).FirstOrDefault((EnquiryMaster j) => j.EnquiryMasterID == id);
		}

		public override bool Insert(EnquiryMaster entity, out string message)
		{
			message = "";
			try
			{
				dbContext.EnquiryMaster.Add(entity);
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

		public override bool Update(EnquiryMaster entity, out string message)
		{
			message = "";
			bool result = false;
			try
			{
				EnquiryMaster byID = this.GetByID(entity.EnquiryMasterID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<EnquiryMaster>(byID);
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
				return false;
			}
			return result;
		}

		public override bool Delete(EnquiryMaster entity, out string message)
		{
			message = "";
			try
			{
				EnquiryDetailsDB enquiryDetailsDB = new EnquiryDetailsDB();
				List<EnquiryDetails> byMaster = enquiryDetailsDB.GetByMaster(entity.EnquiryMasterID);
				if (byMaster.Count > 0)
				{
					using (List<EnquiryDetails>.Enumerator enumerator = byMaster.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							EnquiryDetails entity2 = enumerator.Current;
							if (!enquiryDetailsDB.Delete(entity2))
							{
								message = "can not delete, alredy converted to Quotation";
								return false;
							}
							new QuotationMasterDB().GetByEnquiryID(entity.EnquiryMasterID);
							this.dbContext.Entry<EnquiryMaster>(entity).State =  EntityState.Deleted;
							if (this.dbContext.SaveChanges() > 0)
							{
								return true;
							}
							message = "DeleteError";
							return false;
						}
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				return false;
			}
		}

		public bool Insert(EnquiryMaster entity)
		{
			string message = "";
			object obj = HttpContext.Current.Session["EnquiryDetailsList"];
			if (obj != null)
			{
				List<EnquiryDetails> list = obj as List<EnquiryDetails>;
				if (list.Count > 0)
				{
					entity.EnquiryDetails = list;
				}
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(EnquiryMaster entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(EnquiryMaster entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<ViewBendingEnquiryMaster> GetAllPending()
		{
			return ((IQueryable<ViewBendingEnquiryMaster>)dbContext.ViewBendingEnquiryMaster).OrderByDescending((ViewBendingEnquiryMaster x) => x.EnquiryMasterID).ToList();
		}

		public string GetNewSerial()
		{
			string maxEnquiryCode = GetMaxEnquiryCode();
			if (int.Parse(maxEnquiryCode) > 0)
			{
				return (Convert.ToInt32(maxEnquiryCode) + 1).ToString();
			}
			return "1";
		}

		private string GetMaxEnquiryCode()
		{
			long? num = ((IQueryable<EnquiryMaster>)dbContext.EnquiryMaster).Max((Expression<Func<EnquiryMaster, long?>>)((EnquiryMaster entity) => entity.EnquiryMasterID));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).EnquiryCode;
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
