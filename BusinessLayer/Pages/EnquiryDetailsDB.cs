using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class EnquiryDetailsDB : DBBase<EnquiryDetails, List<EnquiryDetails>, long>
	{
		public override List<EnquiryDetails> GetAll()
		{
			return ((IEnumerable<EnquiryDetails>)dbContext.EnquiryDetails).ToList();
		}

		public override EnquiryDetails GetByID(long id)
		{
			return ((IQueryable<EnquiryDetails>)dbContext.EnquiryDetails).FirstOrDefault((EnquiryDetails j) => j.EnquiryDetailsID == id);
		}

		public override bool Insert(EnquiryDetails entity, out string message)
		{
			message = "";
			try
			{
				dbContext.EnquiryDetails.Add(entity);
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

		public override bool Update(EnquiryDetails entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				EnquiryDetails byID = this.GetByID(entity.EnquiryDetailsID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<EnquiryDetails>(byID);
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

		public override bool Delete(EnquiryDetails entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				List<QuotationDetails> byQuotationDetailsWithEnquiryDetails = this.GetByQuotationDetailsWithEnquiryDetails(entity.EnquiryDetailsID);
				if (byQuotationDetailsWithEnquiryDetails.Count > 0)
				{
					message = "can not delete, alredy converted to Quotation";
					result = false;
				}
				else
				{
					this.dbContext.Entry<EnquiryDetails>(entity).State = EntityState.Deleted;
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
			}
			catch (Exception)
			{
				message = "DeleteError";
				result = false;
			}
			return result;
		}

		public bool Insert(EnquiryDetails entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(EnquiryDetails entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(EnquiryDetails entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<QuotationDetails> GetByQuotationDetailsWithEnquiryDetails(long EnquiryDetailsID)
		{
			return ((IQueryable<QuotationDetails>)dbContext.QuotationDetails).Where((QuotationDetails j) => j.FKEnquiryDetailsID == (long?)EnquiryDetailsID).ToList();
		}

		public List<EnquiryDetails> GetByMasterIDWithSession(long masterId)
		{
			List<EnquiryDetails> list;
			if (masterId > 0)
			{
				list = ((IQueryable<EnquiryDetails>)dbContext.EnquiryDetails).Where((EnquiryDetails j) => j.FKEnquiryMasterID == masterId).ToList();
			}
			else
			{
				object obj = HttpContext.Current.Session["EnquiryDetailsList"];
				if (obj == null)
				{
					list = new List<EnquiryDetails>();
					HttpContext.Current.Session["EnquiryDetailsList"] = list;
				}
				else
				{
					list = obj as List<EnquiryDetails>;
				}
			}
			return list;
		}

		public bool InsertWithSession(EnquiryDetails entity)
		{
			string message = "";
			if (entity.FKEnquiryMasterID == 0)
			{
				object obj = HttpContext.Current.Session["EnquiryDetailsList"];
				List<EnquiryDetails> list = ((obj != null) ? (obj as List<EnquiryDetails>) : new List<EnquiryDetails>());
				entity.EnquiryDetailsID = list.Count + 1;
				list.Add(entity);
				HttpContext.Current.Session["EnquiryDetailsList"] = list;
				return true;
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(EnquiryDetails entity)
		{
			string message = "";
			if (entity.FKEnquiryMasterID == 0)
			{
				object obj = HttpContext.Current.Session["EnquiryDetailsList"];
				List<EnquiryDetails> list = ((obj == null) ? new List<EnquiryDetails>() : (obj as List<EnquiryDetails>));
				EnquiryDetails enquiryDetails = list.First((EnquiryDetails x) => x.EnquiryDetailsID == entity.EnquiryDetailsID);
				enquiryDetails.FKPriceUnitID = entity.FKPriceUnitID;
				enquiryDetails.Remarks = entity.Remarks;
				HttpContext.Current.Session["EnquiryDetailsList"] = list;
				return true;
			}
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(EnquiryDetails entity, long original_EnquiryDetailsID)
		{
			string message = "";
			if (entity.FKEnquiryMasterID == 0)
			{
				object obj = HttpContext.Current.Session["EnquiryDetailsList"];
				List<EnquiryDetails> list = ((obj == null) ? new List<EnquiryDetails>() : (obj as List<EnquiryDetails>));
				EnquiryDetails enquiryDetails = list.First((EnquiryDetails x) => x.EnquiryDetailsID == entity.EnquiryDetailsID);
				enquiryDetails.FKPriceUnitID = entity.FKPriceUnitID;
				enquiryDetails.Remarks = entity.Remarks;
				HttpContext.Current.Session["EnquiryDetailsList"] = list;
				return true;
			}
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool DeleteWithSession(EnquiryDetails entity)
		{
			string message = "";
			if (entity.FKEnquiryMasterID == 0)
			{
				object obj = HttpContext.Current.Session["EnquiryDetailsList"];
				List<EnquiryDetails> list;
				if (obj != null)
				{
					list = obj as List<EnquiryDetails>;
					list.RemoveAll((EnquiryDetails x) => x.EnquiryDetailsID == entity.EnquiryDetailsID);
				}
				else
				{
					list = new List<EnquiryDetails>();
				}
				HttpContext.Current.Session["EnquiryDetailsList"] = list;
				return true;
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool DeleteWithSession(EnquiryDetails entity, long original_EnquiryDetailsID)
		{
			string message = "";
			if (entity.FKEnquiryMasterID == 0)
			{
				object obj = HttpContext.Current.Session["EnquiryDetailsList"];
				List<EnquiryDetails> list;
				if (obj != null)
				{
					list = obj as List<EnquiryDetails>;
					list.RemoveAll((EnquiryDetails x) => x.EnquiryDetailsID == entity.EnquiryDetailsID);
				}
				else
				{
					list = new List<EnquiryDetails>();
				}
				HttpContext.Current.Session["EnquiryDetailsList"] = list;
				return true;
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool InsertList(List<EnquiryDetails> entityList)
		{
			if (entityList.Count > 0)
			{
				long fKEnquiryMasterID = entityList.First().FKEnquiryMasterID;
				if (fKEnquiryMasterID > 0)
				{
					List<EnquiryDetails> byMasterIDWithSession = GetByMasterIDWithSession(fKEnquiryMasterID);
					foreach (EnquiryDetails entity2 in entityList)
					{
						string message = "";
						Func<EnquiryDetails, bool> predicate = (EnquiryDetails x) => x.FKMaterialTypeID == entity2.FKMaterialTypeID && x.FKMaterialDetailsID == entity2.FKMaterialDetailsID && x.FKTestID == entity2.FKTestID && x.FKPriceUnitID == entity2.FKPriceUnitID;
						if (byMasterIDWithSession.Count(predicate) == 0 && entity2.FKTestID > 0 && !Insert(entity2, out message))
						{
							throw new Exception(message);
						}
					}
				}
				else
				{
					object obj = HttpContext.Current.Session["EnquiryDetailsList"];
					List<EnquiryDetails> list = ((obj != null) ? (obj as List<EnquiryDetails>) : new List<EnquiryDetails>());
					foreach (EnquiryDetails entity in entityList)
					{
						Func<EnquiryDetails, bool> predicate2 = (EnquiryDetails x) => x.FKMaterialTypeID == entity.FKMaterialTypeID && x.FKMaterialDetailsID == entity.FKMaterialDetailsID && x.FKTestID == entity.FKTestID && x.FKPriceUnitID == entity.FKPriceUnitID;
						if (list.Count(predicate2) == 0 && entity.FKTestID > 0)
						{
							entity.EnquiryDetailsID = ((list.Count == 0) ? 1 : (list.Max((EnquiryDetails x) => x.EnquiryDetailsID) + 1));
							list.Add(entity);
						}
					}
					HttpContext.Current.Session["EnquiryDetailsList"] = list;
				}
			}
			return true;
		}

		public List<EnquiryDetails> GetByMaster(long masterId)
		{
			return ((IQueryable<EnquiryDetails>)dbContext.EnquiryDetails).Where((EnquiryDetails j) => j.FKEnquiryMasterID == masterId).ToList();
		}
	}
}
