using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class QuotationDetailsDB : DBBase<QuotationDetails, List<QuotationDetails>, long>
	{
		public override List<QuotationDetails> GetAll()
		{
			return ((IEnumerable<QuotationDetails>)dbContext.QuotationDetails).ToList();
		}

		public override QuotationDetails GetByID(long id)
		{
			return ((IQueryable<QuotationDetails>)dbContext.QuotationDetails).FirstOrDefault((QuotationDetails j) => j.QuotationDetailsID == id);
		}

		public override bool Insert(QuotationDetails entity, out string message)
		{
			message = "";
			try
			{
				dbContext.QuotationDetails.Add(entity);
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

		public override bool Update(QuotationDetails entity, out string message)
		{

			message = "";
			bool result;
			try
			{
				QuotationDetails byID = this.GetByID(entity.QuotationDetailsID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<QuotationDetails>(byID);
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

		public override bool Delete(QuotationDetails entity, out string message)
		{
			message = "";
			try
			{
				List<QuotationWorkOrderList> list = new QuotationWorkOrderListDB().GetbyMasterId(entity.QuotationDetailsID);
				if (list.Count > 0)
				{
					foreach (QuotationWorkOrderList item in list)
					{
						new QuotationWorkOrderListDB().Delete(item);
					}
				}
				this.dbContext.Entry<QuotationDetails>(entity).State = EntityState.Deleted;
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

		public bool Insert(QuotationDetails entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(QuotationDetails entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(QuotationDetails entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<QuotationDetails> GetByMasterID(long masterId)
		{
			return ((IQueryable<QuotationDetails>)dbContext.QuotationDetails).Where((QuotationDetails j) => j.FKQuotationMasterID == masterId).ToList();
		}

		public List<ViewQuotationDetails> GetByMasterIDWithSession(long masterId)
		{
			List<ViewQuotationDetails> list;
			if (masterId > 0)
			{
				list = ((IQueryable<ViewQuotationDetails>)dbContext.ViewQuotationDetails).Where((ViewQuotationDetails j) => j.FKQuotationMasterID == masterId).ToList();
			}
			else
			{
				object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
				if (obj == null)
				{
					list = new List<ViewQuotationDetails>();
					HttpContext.Current.Session["ViewQuotationDetailsList"] = list;
				}
				else
				{
					list = obj as List<ViewQuotationDetails>;
				}
			}
			return list.OrderBy((ViewQuotationDetails x) => x.FKEnquiryDetailsID).ToList();
		}

		public bool InsertWithSession(ViewQuotationDetails entity)
		{
			string message = "";
			if (entity.FKQuotationMasterID == 0)
			{
				object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
				List<ViewQuotationDetails> list = ((obj != null) ? (obj as List<ViewQuotationDetails>) : new List<ViewQuotationDetails>());
				entity.QuotationDetailsID = list.Count + 1;
				list.Add(entity);
				HttpContext.Current.Session["ViewQuotationDetailsList"] = list;
				return true;
			}
			QuotationDetails quotationDetails = new QuotationDetails();
			quotationDetails.FKEnquiryDetailsID = entity.FKEnquiryDetailsID;
			quotationDetails.FKMaterialDetailsID = entity.FKMaterialDetailsID;
			quotationDetails.FKMaterialTypeID = entity.FKMaterialTypeID;
			quotationDetails.FKPriceUnitID = entity.FKPriceUnitID;
			quotationDetails.FKQuotationMasterID = entity.FKQuotationMasterID;
			quotationDetails.FKTestID = entity.FKTestID;
			quotationDetails.MinQty = entity.MinQty;
			quotationDetails.Price = entity.Price;
			quotationDetails.Remarks = entity.Remarks;
			if (Insert(quotationDetails, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(ViewQuotationDetails entity)
		{
			string message = "";
			if (entity.FKQuotationMasterID == 0)
			{
				object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
				List<ViewQuotationDetails> list = ((obj == null) ? new List<ViewQuotationDetails>() : (obj as List<ViewQuotationDetails>));
				ViewQuotationDetails viewQuotationDetails = list.First((ViewQuotationDetails x) => x.QuotationDetailsID == entity.QuotationDetailsID);
				viewQuotationDetails.FKPriceUnitID = entity.FKPriceUnitID;
				viewQuotationDetails.Remarks = entity.Remarks;
				HttpContext.Current.Session["ViewQuotationDetailsList"] = list;
				return true;
			}
			QuotationDetails byID = GetByID(entity.QuotationDetailsID);
			byID.FKEnquiryDetailsID = entity.FKEnquiryDetailsID;
			byID.FKMaterialDetailsID = entity.FKMaterialDetailsID;
			byID.FKMaterialTypeID = entity.FKMaterialTypeID;
			byID.FKPriceUnitID = entity.FKPriceUnitID;
			byID.FKQuotationMasterID = entity.FKQuotationMasterID;
			byID.FKTestID = entity.FKTestID;
			byID.MinQty = entity.MinQty;
			byID.Price = entity.Price;
			byID.Remarks = entity.Remarks;
			if (Update(byID, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(ViewQuotationDetails entity, long original_QuotationDetailsID)
		{
			string message = "";
			if (entity.FKQuotationMasterID == 0)
			{
				object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
				List<ViewQuotationDetails> list = ((obj == null) ? new List<ViewQuotationDetails>() : (obj as List<ViewQuotationDetails>));
				ViewQuotationDetails viewQuotationDetails = list.First((ViewQuotationDetails x) => x.QuotationDetailsID == entity.QuotationDetailsID);
				viewQuotationDetails.FKPriceUnitID = entity.FKPriceUnitID;
				viewQuotationDetails.Price = entity.Price;
				viewQuotationDetails.MinQty = entity.MinQty;
				viewQuotationDetails.Remarks = entity.Remarks;
				HttpContext.Current.Session["ViewQuotationDetailsList"] = list;
				return true;
			}
			QuotationDetails byID = GetByID(entity.QuotationDetailsID);
			byID.FKEnquiryDetailsID = entity.FKEnquiryDetailsID;
			byID.FKMaterialDetailsID = entity.FKMaterialDetailsID;
			byID.FKMaterialTypeID = entity.FKMaterialTypeID;
			byID.FKPriceUnitID = entity.FKPriceUnitID;
			byID.FKQuotationMasterID = entity.FKQuotationMasterID;
			byID.FKTestID = entity.FKTestID;
			byID.MinQty = entity.MinQty;
			byID.Price = entity.Price;
			byID.Remarks = entity.Remarks;
			if (Update(byID, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool DeleteWithSession(ViewQuotationDetails entity)
		{
			string message = "";
			if (entity.FKTestID == 0)
			{
				object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
				List<ViewQuotationDetails> list;
				if (obj != null)
				{
					list = obj as List<ViewQuotationDetails>;
					list.RemoveAll((ViewQuotationDetails x) => x.QuotationDetailsID == entity.QuotationDetailsID);
				}
				else
				{
					list = new List<ViewQuotationDetails>();
				}
				HttpContext.Current.Session["ViewQuotationDetailsList"] = list;
				return true;
			}
			QuotationDetails byID = GetByID(entity.QuotationDetailsID);
			if (Delete(byID, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool InsertList(List<ViewQuotationDetails> entityList)
		{
			if (entityList.Count > 0)
			{
				long fKQuotationMasterID = entityList.First().FKQuotationMasterID;
				if (fKQuotationMasterID > 0)
				{
					List<ViewQuotationDetails> CurrentList = GetByMasterIDWithSession(fKQuotationMasterID);
					List<ViewQuotationDetails> list = CurrentList.Where((ViewQuotationDetails x) => !entityList.Select((ViewQuotationDetails d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (ViewQuotationDetails item2 in list)
					{
						QuotationDetails byID = GetByID(item2.QuotationDetailsID);
						Delete(byID);
					}
					foreach (ViewQuotationDetails item3 in entityList.Where((ViewQuotationDetails x) => !CurrentList.Select((ViewQuotationDetails d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						string message = "";
						QuotationDetails quotationDetails = new QuotationDetails();
						quotationDetails.FKEnquiryDetailsID = item3.FKEnquiryDetailsID;
						quotationDetails.FKMaterialDetailsID = item3.FKMaterialDetailsID;
						quotationDetails.FKMaterialTypeID = item3.FKMaterialTypeID;
						quotationDetails.FKPriceUnitID = item3.FKPriceUnitID;
						quotationDetails.FKQuotationMasterID = item3.FKQuotationMasterID;
						quotationDetails.FKTestID = item3.FKTestID;
						quotationDetails.MinQty = item3.MinQty;
						quotationDetails.Price = item3.Price;
						quotationDetails.Remarks = item3.Remarks;
						if (!Insert(quotationDetails, out message))
						{
							throw new Exception(message);
						}
					}
				}
				else
				{
					object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
					List<ViewQuotationDetails> QuotationDetailsList;
					if (obj == null)
					{
						QuotationDetailsList = new List<ViewQuotationDetails>();
					}
					else
					{
						QuotationDetailsList = obj as List<ViewQuotationDetails>;
					}
					List<ViewQuotationDetails> list2 = QuotationDetailsList.Where((ViewQuotationDetails x) => !entityList.Select((ViewQuotationDetails d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (ViewQuotationDetails item in list2)
					{
						List<ViewQuotationDetails> list3 = QuotationDetailsList;
						Predicate<ViewQuotationDetails> match = (ViewQuotationDetails X) => X.FKTestID == item.FKTestID;
						list3.RemoveAll(match);
					}
					foreach (ViewQuotationDetails item4 in entityList.Where((ViewQuotationDetails x) => !QuotationDetailsList.Select((ViewQuotationDetails d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						item4.QuotationDetailsID = QuotationDetailsList.Count + 1;
						QuotationDetailsList.Add(item4);
					}
					HttpContext.Current.Session["ViewQuotationDetailsList"] = QuotationDetailsList;
				}
			}
			return true;
		}

		public List<ViewQuotationDetails> GetByMasterIDFromSession(long masterId)
		{
			object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
			List<ViewQuotationDetails> list = ((obj != null) ? (obj as List<ViewQuotationDetails>) : ((masterId <= 0) ? new List<ViewQuotationDetails>() : ((IQueryable<ViewQuotationDetails>)dbContext.ViewQuotationDetails).Where((ViewQuotationDetails j) => j.FKQuotationMasterID == masterId).ToList()));
			foreach (ViewQuotationDetails item in list)
			{
				if (item.UnitType == 1)
				{
					item.DefaultPrice = null;
					item.MinimumPrice = null;
					item.Price = null;
					item.MinQty = null;
				}
			}
			HttpContext.Current.Session["ViewQuotationDetailsList"] = list;
			return list.OrderBy((ViewQuotationDetails x) => x.FKEnquiryDetailsID).ToList();
		}

		public bool InsertListToSession(List<ViewQuotationDetails> entityList)
		{
			if (entityList.Count > 0)
			{
				long fKQuotationMasterID = entityList.First().FKQuotationMasterID;
				if (fKQuotationMasterID > 0)
				{
					List<ViewQuotationDetails> CurrentList = GetByMasterIDWithSession(fKQuotationMasterID);
					List<ViewQuotationDetails> list = CurrentList.Where((ViewQuotationDetails x) => !entityList.Select((ViewQuotationDetails d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (ViewQuotationDetails item2 in list)
					{
						QuotationDetails byID = GetByID(item2.QuotationDetailsID);
						Delete(byID);
					}
					foreach (ViewQuotationDetails item3 in entityList.Where((ViewQuotationDetails x) => !CurrentList.Select((ViewQuotationDetails d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						string message = "";
						QuotationDetails byID2 = GetByID(item3.QuotationDetailsID);
						if (!Insert(byID2, out message))
						{
							throw new Exception(message);
						}
					}
				}
				else
				{
					object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
					List<ViewQuotationDetails> ViewQuotationDetailsList;
					if (obj == null)
					{
						ViewQuotationDetailsList = new List<ViewQuotationDetails>();
					}
					else
					{
						ViewQuotationDetailsList = obj as List<ViewQuotationDetails>;
					}
					List<ViewQuotationDetails> list2 = ViewQuotationDetailsList.Where((ViewQuotationDetails x) => !entityList.Select((ViewQuotationDetails d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (ViewQuotationDetails item in list2)
					{
						List<ViewQuotationDetails> list3 = ViewQuotationDetailsList;
						Predicate<ViewQuotationDetails> match = (ViewQuotationDetails X) => X.FKTestID == item.FKTestID;
						list3.RemoveAll(match);
					}
					foreach (ViewQuotationDetails item4 in entityList.Where((ViewQuotationDetails x) => !ViewQuotationDetailsList.Select((ViewQuotationDetails d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						item4.QuotationDetailsID = ViewQuotationDetailsList.Count + 1;
						ViewQuotationDetailsList.Add(item4);
					}
					HttpContext.Current.Session["ViewQuotationDetailsList"] = ViewQuotationDetailsList;
				}
			}
			return true;
		}

		public bool UpdateToSession(ViewQuotationDetails entity, long original_QuotationDetailsID)
		{
			object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
			if (obj != null)
			{
				List<ViewQuotationDetails> list = obj as List<ViewQuotationDetails>;
				ViewQuotationDetails updateEntity = list.First((ViewQuotationDetails x) => x.QuotationDetailsID == entity.QuotationDetailsID);
				updateEntity.FKPriceUnitID = entity.FKPriceUnitID;
				updateEntity.Price = entity.Price;
				updateEntity.MinQty = entity.MinQty;
				updateEntity.Remarks = entity.Remarks;
				if (entity.FKQuotationMasterID == 0)
				{
					updateEntity.RowStatus = 1;
				}
				else
				{
					updateEntity.RowStatus = 2;
				}
				HttpContext.Current.Session["ViewQuotationDetailsList"] = list;
				List<ViewQuotationDetails> source = obj as List<ViewQuotationDetails>;
				source.Where((ViewQuotationDetails x) => !x.Price.HasValue).ToList();
				if (source.Count((ViewQuotationDetails x) => x.FKTestID == updateEntity.FKTestID && x.FKPriceUnitID == updateEntity.FKPriceUnitID && x.Price.HasValue && ((x.Price != updateEntity.Price && x.Price.HasValue) || x.MinQty != updateEntity.MinQty)) > 0)
				{
					throw new Exception("List already contain similar service with different Price/Minimum Quantity!");
				}
				return true;
			}
			return true;
		}

		public void CheckList(List<ViewQuotationDetails> DetailsList)
		{
			if (DetailsList.Count((ViewQuotationDetails x) => !x.Price.HasValue) > 0)
			{
				throw new Exception("Price is missing!");
			}
		}

		public bool UpdateDetailsFromSession()
		{
			object obj = HttpContext.Current.Session["ViewQuotationDetailsList"];
			if (obj != null)
			{
				List<ViewQuotationDetails> source = obj as List<ViewQuotationDetails>;
				foreach (ViewQuotationDetails item in source.Where((ViewQuotationDetails x) => x.RowStatus == 1).ToList())
				{
					QuotationDetails quotationDetails = new QuotationDetails();
					quotationDetails.FKEnquiryDetailsID = item.FKEnquiryDetailsID;
					quotationDetails.FKMaterialDetailsID = item.FKMaterialDetailsID;
					quotationDetails.FKMaterialTypeID = item.FKMaterialTypeID;
					quotationDetails.FKPriceUnitID = item.FKPriceUnitID;
					quotationDetails.FKQuotationMasterID = item.FKQuotationMasterID;
					quotationDetails.FKTestID = item.FKTestID;
					quotationDetails.MinQty = item.MinQty;
					quotationDetails.Price = item.Price;
					quotationDetails.Remarks = item.Remarks;
					Insert(quotationDetails);
				}
				foreach (ViewQuotationDetails item2 in source.Where((ViewQuotationDetails x) => x.RowStatus == 2).ToList())
				{
					QuotationDetails byID = GetByID(item2.QuotationDetailsID);
					byID.Price = item2.Price;
					byID.MinQty = item2.MinQty;
					byID.FKPriceUnitID = item2.FKPriceUnitID;
					byID.Remarks = item2.Remarks;
					Update(byID);
				}
				foreach (ViewQuotationDetails item3 in source.Where((ViewQuotationDetails x) => x.RowStatus == 3).ToList())
				{
					QuotationDetails byID2 = GetByID(item3.QuotationDetailsID);
					Delete(byID2);
				}
			}
			HttpContext.Current.Session["ViewQuotationDetailsList"] = null;
			return true;
		}

		public int CheckAllWorkOrderComplted(long masterId)
		{
			return ((IEnumerable<int?>)dbContext.SPValidateExistWorkOrderInJo(masterId)).FirstOrDefault() ?? 0;
		}
	}
}
