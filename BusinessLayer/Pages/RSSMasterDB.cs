using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BusinessLayer.Pages
{
	public class RSSMasterDB : DBBase<RSSMaster, List<RSSMaster>, long>
	{
		public override List<RSSMaster> GetAll()
		{
			return ((IQueryable<RSSMaster>)dbContext.RSSMaster).OrderByDescending((RSSMaster x) => x.RSSMasterId).ToList();
		}

		public override RSSMaster GetByID(long id)
		{
			return ((IQueryable<RSSMaster>)dbContext.RSSMaster).FirstOrDefault((RSSMaster j) => j.RSSMasterId == id);
		}

		public override bool Insert(RSSMaster entity, out string message)
		{
			message = "";
			try
			{
				List<RSSDetails> list = (List<RSSDetails>)(entity.RSSDetails = HttpContext.Current.Session["RSSDetList"] as List<RSSDetails>);
				dbContext.RSSMaster.Add(entity);
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

		public override bool Update(RSSMaster entity, out string message)
		{
			message = "";
			try
			{
				RSSMaster byID = GetByID(entity.RSSMasterId);
				List<RSSDetails> SelectedList = HttpContext.Current.Session["RSSDetList"] as List<RSSDetails>;
				if (SelectedList != null)
				{
					List<RSSDetails> CurrentList = new RSSDetailsDB().GetByMaster(entity.RSSMasterId);
					if (CurrentList != null)
					{
						List<RSSDetails> list = CurrentList.Where((RSSDetails x) => !SelectedList.Select((RSSDetails d) => d.FkTestId).Contains(x.FkTestId)).ToList();
						foreach (RSSDetails item in list)
						{
							new RSSDetailsDB().Delete(item.RSSDteailsId, out message);
						}
						foreach (RSSDetails item2 in SelectedList.Where((RSSDetails x) => !CurrentList.Select((RSSDetails d) => d.FkTestId).Contains(x.FkTestId) && x.FkTestId > 0).ToList())
						{
							item2.FkRSSMasterId = entity.RSSMasterId;
							if (!new RSSDetailsDB().Insert(item2, out message))
							{
								throw new Exception(message);
							}
						}
					}
				}
				DbEntityEntry val = ((DbContext)dbContext).Entry<RSSMaster>(byID);
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

		public override bool Delete(RSSMaster entity, out string message)
		{
			message = "";
			try
			{
				List<SampleReceiveList> byRssMasterID = new SampleReceiveListDB().GetByRssMasterID(entity.RSSMasterId);
				if (byRssMasterID.Count > 0)
				{
					throw new Exception("Can't delete,already Used");
				}
				List<RSSDetails> byMaster = new RSSDetailsDB().GetByMaster(entity.RSSMasterId);
				if (byMaster.Count > 0)
				{
					foreach (RSSDetails item in byMaster)
					{
						new RSSDetailsDB().Delete(item.RSSDteailsId, out message);
					}
				}
				((DbContext)dbContext).Entry<RSSMaster>(entity).State = (EntityState)8;
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					return true;
				}
				message = "DeleteError";
				return false;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				return false;
			}
		}

		public bool Insert(RSSMaster entity)
		{
			string message = "";
			object obj = HttpContext.Current.Session["EnquiryDetailsList"];
			if (obj != null)
			{
				List<RSSDetails> list = obj as List<RSSDetails>;
				if (list.Count > 0)
				{
					entity.RSSDetails = list;
				}
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(RSSMaster entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(RSSMaster entity)
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
			string maxEnquiryCode = GetMaxEnquiryCode();
			if (int.Parse(maxEnquiryCode) > 0)
			{
				return (Convert.ToInt32(maxEnquiryCode) + 1).ToString();
			}
			return "1";
		}

		private string GetMaxEnquiryCode()
		{
			long? num = ((IQueryable<RSSMaster>)dbContext.RSSMaster).Max((Expression<Func<RSSMaster, long?>>)((RSSMaster entity) => entity.RSSMasterId));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).RSSNumber;
				if (text == null)
				{
					text = "0";
				}
				return text;
			}
			return "0";
		}

		public List<ViewRSS> GetAllFromView()
		{
			return ((IEnumerable<ViewRSS>)dbContext.ViewRSS).OrderByDescending(x=>x.RSSMasterId).ToList();
            //return ((IQueryable<EnquiryMaster>)dbContext.EnquiryMaster).OrderByDescending((EnquiryMaster x) => x.EnquiryMasterID).ToList();
        }

		public List<RSSMaster> GetNotSampled()
		{
			List<long?> RssId = (from x in (IQueryable<SampleReceiveList>)dbContext.SampleReceiveList
				where x.FKRSSMasterId != null
				select x.FKRSSMasterId).ToList();
			return ((IQueryable<RSSMaster>)dbContext.RSSMaster).Where((RSSMaster j) => !RssId.Contains(j.RSSMasterId)).ToList();
		}
	}
}
