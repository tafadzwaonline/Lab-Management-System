using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class RSSDetailsDB : DBBase<RSSDetails, List<RSSDetails>, long>
	{
		public override List<RSSDetails> GetAll()
		{
			return ((IEnumerable<RSSDetails>)dbContext.RSSDetails).ToList();
		}

		public override RSSDetails GetByID(long id)
		{
			return ((IQueryable<RSSDetails>)dbContext.RSSDetails).FirstOrDefault((RSSDetails j) => j.RSSDteailsId == id);
		}

		public override bool Insert(RSSDetails entity, out string message)
		{
			message = "";
			try
			{
				dbContext.RSSDetails.Add(entity);
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

		public override bool Update(RSSDetails entity, out string message)
		{
			message = "";
			try
			{
				RSSDetails byID = GetByID(entity.RSSDteailsId);
				DbEntityEntry val = ((DbContext)dbContext).Entry<RSSDetails>(byID);
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

		public override bool Delete(RSSDetails entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<RSSDetails>(entity).State = (EntityState)8;
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

		public bool Insert(RSSDetails entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(RSSDetails entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(RSSDetails entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<RSSDetails> GetByMasterIDWithSession(long masterId)
		{
			List<RSSDetails> list;
			if (masterId > 0)
			{
				list = ((IQueryable<RSSDetails>)dbContext.RSSDetails).Where((RSSDetails j) => j.FkRSSMasterId == masterId).ToList();
			}
			else
			{
				object obj = HttpContext.Current.Session["EnquiryDetailsList"];
				if (obj == null)
				{
					list = new List<RSSDetails>();
					HttpContext.Current.Session["EnquiryDetailsList"] = list;
				}
				else
				{
					list = obj as List<RSSDetails>;
				}
			}
			return list;
		}

		public List<RSSDetails> GetByMaster(long masterId)
		{
			return ((IQueryable<RSSDetails>)dbContext.RSSDetails).Where((RSSDetails j) => j.FkRSSMasterId == masterId).ToList();
		}

		public List<RSSDetails> GetByMasterIDFromSession(long masterId, long JobOrderMasterID)
		{
			object obj = HttpContext.Current.Session["RSSDetails"];
			List<RSSDetails> result;
			if (obj == null)
			{
				if (JobOrderMasterID > 0)
				{
					if (masterId > 0)
					{
						result = ((IQueryable<RSSDetails>)dbContext.RSSDetails).Where((RSSDetails j) => j.FkRSSMasterId == masterId).ToList();
					}
					else
					{
						result = new List<RSSDetails>();
					}
					foreach (RSSDetails item in result)
					{
						item.IsSelected = true;
						item.IsEnabled = true;
					}
					List<JobOrderDetails> byMasterIDWithSession = new JobOrderDetailsDB().GetByMasterIDWithSession(JobOrderMasterID);
					byMasterIDWithSession.RemoveAll((JobOrderDetails x) => result.Select((RSSDetails s) => s.FkTestId).ToList().Contains(x.FKTestID));
					byMasterIDWithSession.RemoveAll((JobOrderDetails x) => x.PriceUnitList.UnitType == 1);
					foreach (JobOrderDetails item2 in byMasterIDWithSession)
					{
						TestsList byID = new TestsListDB().GetByID(item2.FKTestID);
						RSSDetails rSSDetails = new RSSDetails();
						rSSDetails.RSSDteailsId = ((result.Count > 0) ? (result.Max((RSSDetails x) => x.RSSDteailsId) + 1) : 1);
						rSSDetails.FkTestId = item2.FKTestID;
						if (byID.IsSiteTest && item2.Price.HasValue)
						{
							rSSDetails.IsEnabled = true;
						}
						else
						{
							rSSDetails.IsEnabled = false;
						}
						result.Add(rSSDetails);
					}
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = obj as List<RSSDetails>;
			}
			HttpContext.Current.Session["RSSDetails"] = result;
			return result;
		}

		public bool UpdateToSession(RSSDetails entity)
		{
			object obj = HttpContext.Current.Session["RSSDetails"];
			if (obj != null)
			{
				List<RSSDetails> list = obj as List<RSSDetails>;
				list.First((RSSDetails x) => x.RSSDteailsId == entity.RSSDteailsId);
				HttpContext.Current.Session["SelectedRSSDetails"] = list;
			}
			return true;
		}
	}
}
