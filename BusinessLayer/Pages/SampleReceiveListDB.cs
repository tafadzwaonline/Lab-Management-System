using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BusinessLayer.Pages
{
	public class SampleReceiveListDB : DBBase<SampleReceiveList, List<SampleReceiveList>, long>
	{
		public override List<SampleReceiveList> GetAll()
		{
			return ((IQueryable<SampleReceiveList>)dbContext.SampleReceiveList).OrderByDescending((SampleReceiveList x) => x.SampleID).ToList();
		}

		public override SampleReceiveList GetByID(long id)
		{
			return ((IQueryable<SampleReceiveList>)dbContext.SampleReceiveList).FirstOrDefault((SampleReceiveList j) => j.SampleID == id);
		}

		public override bool Insert(SampleReceiveList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.SampleReceiveList.Add(entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
                    if (entity.FKRSSMasterId.HasValue)
					{
						RSSMaster byID = new RSSMasterDB().GetByID(entity.FKRSSMasterId.Value);
						byID.IsSampled = true;
						new RSSMasterDB().Update(byID);
					}
					if (!new ExcelHandlingCLS().GenerateXlsBySampleID(entity.SampleID))
					{
						throw new Exception("Sample Receive Added Sucessfully ,but Workform Excel Faild, Please Add Information Link In Service Information Page ");
					}

                    HttpContext context = HttpContext.Current;
                    context.Session["SampleID"] = entity.SampleID;

                    return true;
				}
				message = "InsertError";
				return false;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				return false;
			}
		}

		public override bool Update(SampleReceiveList entity, out string message)
		{
			message = "";
			try
			{
				SampleReceiveList byID = GetByID(entity.SampleID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<SampleReceiveList>(byID);
				val.State = (EntityState)16;
				val.CurrentValues.SetValues((object)entity);
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					new ExcelHandlingCLS().GenerateXlsBySampleID(entity.SampleID);
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

		public override bool Delete(SampleReceiveList entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<SampleReceiveList>(entity).State = (EntityState)8;
				if (((DbContext)dbContext).SaveChanges() > 0)
				{
					if (entity.FKRSSMasterId.HasValue)
					{
						RSSMaster byID = new RSSMasterDB().GetByID(entity.FKRSSMasterId.Value);
						byID.IsSampled = false;
						new RSSMasterDB().Update(byID);
					}
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

		public bool Insert(SampleReceiveList entity)
		{
			string message = "";
			object obj = HttpContext.Current.Session["SampleReceiveTestList"];
			object obj2 = HttpContext.Current.Session["SampleMaterialCustomFieldList"];
			object obj3 = HttpContext.Current.Session["SampleMaterialTableCustomFieldList"];
			if (obj != null)
			{
				List<SampleReceiveTestList> list = obj as List<SampleReceiveTestList>;
				if (list.Count > 0)
				{
					entity.SampleReceiveTestList = list;
				}
			}
			if (obj2 != null)
			{
				List<SampleReceiveMaterialCustomField> list2 = obj2 as List<SampleReceiveMaterialCustomField>;
				if (list2.Count > 0)
				{
					entity.SampleReceiveMaterialCustomField = list2;
				}
			}
			if (obj3 != null)
			{
				List<SampleReceiveMaterialTableCustomField> list3 = obj3 as List<SampleReceiveMaterialTableCustomField>;
				if (list3.Count > 0)
				{
					entity.SampleReceiveMaterialTableCustomField = list3;
				}
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(SampleReceiveList entity)
		{
			string message = "";
			new SampleReceiveTestListDB().UpdateDetailsFromSession(entity.SampleID);
			new SampleReceiveMaterialTableCustomFieldDB().UpdateDetailsFromSession(entity.SampleID);
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(SampleReceiveList entity)
		{
			string message = "";
			List<SampleReceiveTestList> byMasterID = new SampleReceiveTestListDB().GetByMasterID(entity.SampleID);
			foreach (SampleReceiveTestList item in byMasterID)
			{
				List<SampleReceiveTestInvoice> byMasterID2 = new SampleReceiveTestInvoiceDB().GetByMasterID(item.SampleReceiveTestID);
				if (byMasterID2.Count > 0)
				{
					throw new Exception("Can't delete,already invoiced");
				}
			}
			foreach (SampleReceiveTestList item2 in byMasterID)
			{
				new SampleReceiveTestListDB().Delete(item2.SampleReceiveTestID, out message);
			}
			List<SampleReceiveMaterialCustomField> bySampleId = new SampleReceiveMaterialCustomFieldDB().GetBySampleId(entity.SampleID);
			foreach (SampleReceiveMaterialCustomField item3 in bySampleId)
			{
				new SampleReceiveMaterialCustomFieldDB().Delete(item3.SampleReceiveCFLinkID, out message);
			}
			List<SampleReceiveMaterialTableCustomField> bySampleId2 = new SampleReceiveMaterialTableCustomFieldDB().GetBySampleId(entity.SampleID);
			foreach (SampleReceiveMaterialTableCustomField item4 in bySampleId2)
			{
				new SampleReceiveMaterialTableCustomFieldDB().Delete(item4.SampleReceiveTCFLinkID, out message);
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public string GetNewSerial()
		{
			string maxSampleNumber = GetMaxSampleNumber();
			if (maxSampleNumber != null)
			{
                return maxSampleNumber;
            }
			return "1";
		}

		private string GetMaxSampleNumber()
		{
			long? num = ((IQueryable<SampleReceiveList>)dbContext.SampleReceiveList).Max((Expression<Func<SampleReceiveList, long?>>)((SampleReceiveList entity) => entity.SampleID));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).SampleNo;
				if (text == null)
				{
					text = "0";
				}
                else if (!text.Contains("S-"))
                    text = "S-15000";
                else
                {
                    string[] splittedSampleNo = text.Split('-');
                    int sampleNo = Convert.ToInt32(splittedSampleNo[1]) + 1;
                    text = "S-" + sampleNo;
                }
                return text;
			}
			return "0";
		}

		public List<SampleReceiveList> GetByJobOrderID(long id)
		{
			return (from j in (IQueryable<SampleReceiveList>)dbContext.SampleReceiveList
				where j.FKJobOrderMasterID == (long?)id
				select j into x
				orderby x.SampleID descending
				select x).ToList();
		}

		public List<SampleReceiveList> GetByRssMasterID(long RssMasterID)
		{
			return ((IQueryable<SampleReceiveList>)dbContext.SampleReceiveList).Where((SampleReceiveList j) => j.FKRSSMasterId == (long?)RssMasterID).ToList();
		}

		public ViewN_OFUnPaidBills GetNOfUnpaidBills(long JOMasterID)
		{
			ViewN_OFUnPaidBills viewN_OFUnPaidBills = ((IQueryable<ViewN_OFUnPaidBills>)dbContext.ViewN_OFUnPaidBills).Where((ViewN_OFUnPaidBills j) => j.JobOrderMasterID == JOMasterID).FirstOrDefault();
			if (viewN_OFUnPaidBills == null)
			{
				viewN_OFUnPaidBills = new ViewN_OFUnPaidBills();
			}
			return viewN_OFUnPaidBills;
		}
	}
}
