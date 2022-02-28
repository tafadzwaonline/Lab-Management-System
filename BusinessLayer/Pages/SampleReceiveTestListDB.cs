using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EntityState = System.Data.Entity.EntityState;

namespace BusinessLayer.Pages
{
	public class SampleReceiveTestListDB : DBBase<SampleReceiveTestList, List<SampleReceiveTestList>, long>
	{
		public override List<SampleReceiveTestList> GetAll()
		{
			return ((IEnumerable<SampleReceiveTestList>)dbContext.SampleReceiveTestList).ToList();
		}

		public override SampleReceiveTestList GetByID(long id)
		{
			return ((IQueryable<SampleReceiveTestList>)dbContext.SampleReceiveTestList).FirstOrDefault((SampleReceiveTestList j) => j.SampleReceiveTestID == id);
		}

		public override bool Insert(SampleReceiveTestList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.SampleReceiveTestList.Add(entity);
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

		public override bool Update(SampleReceiveTestList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				SampleReceiveTestList byID = this.GetByID(entity.SampleReceiveTestID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<SampleReceiveTestList>(byID);
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

		public override bool Delete(SampleReceiveTestList entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<SampleReceiveTestList>(entity).State = EntityState.Deleted;
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
			catch (Exception)
			{
				message = "DeleteError";
				result = false;
			}
			return result;
		}

		public bool Insert(SampleReceiveTestList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(SampleReceiveTestList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(SampleReceiveTestList entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool DeleteByMasterId(long masterId)
		{
			string message = "";
			List<SampleReceiveTestList> list = ((IQueryable<SampleReceiveTestList>)dbContext.SampleReceiveTestList).Where((SampleReceiveTestList j) => j.FKSampleID == (long?)masterId).ToList();
			foreach (SampleReceiveTestList item in list)
			{
				if (!Delete(item, out message))
				{
					throw new Exception(message);
				}
			}
			return true;
		}

		public List<SampleReceiveTestList> GetByMasterID(long masterId)
		{
			return ((IQueryable<SampleReceiveTestList>)dbContext.SampleReceiveTestList).Where((SampleReceiveTestList j) => j.FKSampleID == (long?)masterId).ToList();
		}

		public List<SampleReceiveTestList> GetByMasterIDWithSession(long masterId)
		{
			List<SampleReceiveTestList> list;
			if (masterId > 0)
			{
				list = ((IQueryable<SampleReceiveTestList>)dbContext.SampleReceiveTestList).Where((SampleReceiveTestList j) => j.FKSampleID == (long?)masterId).ToList();
			}
			else
			{
				object obj = HttpContext.Current.Session["SampleReceiveTestList"];
				if (obj == null)
				{
					list = new List<SampleReceiveTestList>();
					HttpContext.Current.Session["SampleReceiveTestList"] = list;
				}
				else
				{
					list = obj as List<SampleReceiveTestList>;
				}
			}
			return list;
		}

		public bool InsertWithSession(SampleReceiveTestList entity)
		{
			string message = "";
			if (entity.FKSampleID == 0)
			{
				object obj = HttpContext.Current.Session["SampleReceiveTestList"];
				List<SampleReceiveTestList> list = ((obj != null) ? (obj as List<SampleReceiveTestList>) : new List<SampleReceiveTestList>());
				entity.SampleReceiveTestID = list.Count + 1;
				list.Add(entity);
				HttpContext.Current.Session["SampleReceiveTestList"] = list;
				return true;
			}
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(SampleReceiveTestList entity)
		{
			string message = "";
			if (entity.FKSampleID == 0)
			{
				object obj = HttpContext.Current.Session["SampleReceiveTestList"];
				List<SampleReceiveTestList> list = ((obj == null) ? new List<SampleReceiveTestList>() : (obj as List<SampleReceiveTestList>));
				SampleReceiveTestList sampleReceiveTestList = list.First((SampleReceiveTestList x) => x.SampleReceiveTestID == entity.SampleReceiveTestID);
				sampleReceiveTestList.FKPriceUnitID = entity.FKPriceUnitID;
				sampleReceiveTestList.Remarks = entity.Remarks;
				HttpContext.Current.Session["SampleReceiveTestList"] = list;
				return true;
			}
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateWithSession(SampleReceiveTestList entity, long original_SampleReceiveTestListID)
		{
			string message = "";
			if (entity.FKSampleID == 0)
			{
				object obj = HttpContext.Current.Session["SampleReceiveTestList"];
				List<SampleReceiveTestList> list = ((obj == null) ? new List<SampleReceiveTestList>() : (obj as List<SampleReceiveTestList>));
				SampleReceiveTestList sampleReceiveTestList = list.First((SampleReceiveTestList x) => x.SampleReceiveTestID == entity.SampleReceiveTestID);
				sampleReceiveTestList.FKPriceUnitID = entity.FKPriceUnitID;
				sampleReceiveTestList.Price = entity.Price;
				sampleReceiveTestList.Remarks = entity.Remarks;
				HttpContext.Current.Session["SampleReceiveTestList"] = list;
				return true;
			}
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool DeleteWithSession(SampleReceiveTestList entity)
		{
			string message = "";
			int? fKTestID = entity.FKTestID;
			if (fKTestID.GetValueOrDefault() == 0 && fKTestID.HasValue)
			{
				object obj = HttpContext.Current.Session["SampleReceiveTestList"];
				List<SampleReceiveTestList> list;
				if (obj != null)
				{
					list = obj as List<SampleReceiveTestList>;
					list.RemoveAll((SampleReceiveTestList x) => x.SampleReceiveTestID == entity.SampleReceiveTestID);
				}
				else
				{
					list = new List<SampleReceiveTestList>();
				}
				HttpContext.Current.Session["SampleReceiveTestList"] = list;
				return true;
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool InsertList(List<SampleReceiveTestList> entityList)
		{
			if (entityList.Count > 0)
			{
				long value = entityList.First().FKSampleID.Value;
				if (value > 0)
				{
					List<SampleReceiveTestList> CurrentList = GetByMasterIDWithSession(value);
					List<SampleReceiveTestList> list = CurrentList.Where((SampleReceiveTestList x) => !entityList.Select((SampleReceiveTestList d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (SampleReceiveTestList item2 in list)
					{
						Delete(item2);
					}
					foreach (SampleReceiveTestList item3 in entityList.Where((SampleReceiveTestList x) => !CurrentList.Select((SampleReceiveTestList d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						string message = "";
						if (!Insert(item3, out message))
						{
							throw new Exception(message);
						}
					}
				}
				else
				{
					object obj = HttpContext.Current.Session["SampleReceiveTestList"];
					List<SampleReceiveTestList> SampleReceiveTestList;
					if (obj == null)
					{
						SampleReceiveTestList = new List<SampleReceiveTestList>();
					}
					else
					{
						SampleReceiveTestList = obj as List<SampleReceiveTestList>;
					}
					List<SampleReceiveTestList> list2 = SampleReceiveTestList.Where((SampleReceiveTestList x) => !entityList.Select((SampleReceiveTestList d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (SampleReceiveTestList item in list2)
					{
						List<SampleReceiveTestList> list3 = SampleReceiveTestList;
						Predicate<SampleReceiveTestList> match = (SampleReceiveTestList X) => X.FKTestID == item.FKTestID;
						list3.RemoveAll(match);
					}
					foreach (SampleReceiveTestList item4 in entityList.Where((SampleReceiveTestList x) => !SampleReceiveTestList.Select((SampleReceiveTestList d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						item4.SampleReceiveTestID = SampleReceiveTestList.Count + 1;
						SampleReceiveTestList.Add(item4);
					}
					HttpContext.Current.Session["SampleReceiveTestList"] = SampleReceiveTestList;
				}
			}
			return true;
		}

		public List<SampleReceiveTestList> GetByMasterIDFromSession(long masterId, long JobOrderMasterID, int? MaterialTypeID, int? MaterialDetailsID)
		{
			if (MaterialDetailsID.HasValue)
			{
				object obj = HttpContext.Current.Session["SampleReceiveTestList"];
				List<SampleReceiveTestList> result;
				if (obj == null)
				{
					if (masterId > 0)
					{
						result = ((IQueryable<SampleReceiveTestList>)dbContext.SampleReceiveTestList).Where((SampleReceiveTestList j) => j.FKSampleID == (long?)masterId).ToList();
					}
					else
					{
						result = new List<SampleReceiveTestList>();
					}
					List<JobOrderDetails> byMasterIDWithSession = new JobOrderDetailsDB().GetByMasterIDWithSession(JobOrderMasterID);
					foreach (SampleReceiveTestList item2 in result)
					{
						if (item2.IsApproved == true || item2.IsInvoiced)
						{
							item2.IsEnabled = false;
						}
						else
						{
							item2.IsEnabled = true;
						}
						byMasterIDWithSession.FirstOrDefault((JobOrderDetails x) => x.FKTestID == item2.FKTestID);
						if (byMasterIDWithSession.FirstOrDefault((JobOrderDetails x) => x.FKTestID == item2.FKTestID).PriceUnitList.UnitType != 1)
						{
							item2.MinQty = byMasterIDWithSession.FirstOrDefault((JobOrderDetails x) => x.FKTestID == item2.FKTestID).MinQty.Value;
						}
						if (!item2.Price.HasValue && byMasterIDWithSession.FirstOrDefault((JobOrderDetails x) => x.FKTestID == item2.FKTestID && x.FKPriceUnitID == item2.FKPriceUnitID).Price.HasValue)
						{
							item2.Price = byMasterIDWithSession.FirstOrDefault((JobOrderDetails x) => x.FKTestID == item2.FKTestID && x.FKPriceUnitID == item2.FKPriceUnitID).Price ?? 0m;
							item2.RowStatus = 2;
						}
					}
					List<TestsList> allServiceByMaterial = new TestsListDB().GetAllServiceByMaterial(MaterialTypeID, MaterialDetailsID);
					allServiceByMaterial.RemoveAll((TestsList x) => result.Select((SampleReceiveTestList s) => s.FKTestID).ToList().Contains(x.TestID));
					foreach (JobOrderDetails item in byMasterIDWithSession)
					{
                        if (allServiceByMaterial.FirstOrDefault((TestsList x) => x.TestID == item.FKTestID) != null)
						{
							SampleReceiveTestList sampleReceiveTestList = new SampleReceiveTestList();
							sampleReceiveTestList.SampleReceiveTestID = ((result.Count > 0) ? (result.Max((SampleReceiveTestList x) => x.SampleReceiveTestID) + 1) : 1);
							sampleReceiveTestList.FKTestID = item.FKTestID;
							sampleReceiveTestList.Subcontract = item.TestsList.IsSubcontractedTest;
                            if(item.IsEnable == true)
							    sampleReceiveTestList.IsEnabled = true;
                            else
                               sampleReceiveTestList.IsEnabled = false;
                            sampleReceiveTestList.MinQty = item.MinQty ?? 0m;
							sampleReceiveTestList.FKPriceUnitID = item.FKPriceUnitID;
							sampleReceiveTestList.Price = item.Price;
							result.Add(sampleReceiveTestList);
						}
					}
					List<int> JoTestList = byMasterIDWithSession.Select((JobOrderDetails x) => x.FKTestID).ToList();
					allServiceByMaterial.RemoveAll((TestsList x) => JoTestList.Contains(x.TestID));
					foreach (TestsList test in allServiceByMaterial)
					{
						SampleReceiveTestList sampleReceiveTestList2 = new SampleReceiveTestList();
						sampleReceiveTestList2.SampleReceiveTestID = ((result.Count > 0) ? (result.Max((SampleReceiveTestList x) => x.SampleReceiveTestID) + 1) : 1);
						sampleReceiveTestList2.FKTestID = test.TestID;
						sampleReceiveTestList2.Subcontract = test.IsSubcontractedTest;
                        if (byMasterIDWithSession.Count((JobOrderDetails x) => x.FKTestID == test.TestID && x.IsEnable == true) > 0)
						{
							sampleReceiveTestList2.IsEnabled = true;
							if (byMasterIDWithSession.FirstOrDefault((JobOrderDetails x) => x.FKTestID == test.TestID).PriceUnitList.UnitType != 1)
							{
								if (byMasterIDWithSession.FirstOrDefault((JobOrderDetails x) => x.FKTestID == test.TestID).MinQty.HasValue)
								{
									sampleReceiveTestList2.MinQty = byMasterIDWithSession.FirstOrDefault((JobOrderDetails x) => x.FKTestID == test.TestID).MinQty.Value;
								}
								else
								{
									sampleReceiveTestList2.MinQty = 0m;
								}
							}
						}
						else
						{
                            sampleReceiveTestList2.IsEnabled = false;
                        }
						result.Add(sampleReceiveTestList2);
					}
				}
				else
				{
					result = obj as List<SampleReceiveTestList>;
				}
				HttpContext.Current.Session["SampleReceiveTestList"] = result;
				return result;
			}
			return null;
		}

		public bool InsertListToSession(List<SampleReceiveTestList> entityList)
		{
			if (entityList.Count > 0)
			{
				long value = entityList.First().FKSampleID.Value;
				if (value > 0)
				{
					List<SampleReceiveTestList> CurrentList = GetByMasterIDWithSession(value);
					List<SampleReceiveTestList> list = CurrentList.Where((SampleReceiveTestList x) => !entityList.Select((SampleReceiveTestList d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (SampleReceiveTestList item2 in list)
					{
						Delete(item2);
					}
					foreach (SampleReceiveTestList item3 in entityList.Where((SampleReceiveTestList x) => !CurrentList.Select((SampleReceiveTestList d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						string message = "";
						if (!Insert(item3, out message))
						{
							throw new Exception(message);
						}
					}
				}
				else
				{
					object obj = HttpContext.Current.Session["SampleReceiveTestList"];
					List<SampleReceiveTestList> SampleReceiveTestList;
					if (obj == null)
					{
						SampleReceiveTestList = new List<SampleReceiveTestList>();
					}
					else
					{
						SampleReceiveTestList = obj as List<SampleReceiveTestList>;
					}
					List<SampleReceiveTestList> list2 = SampleReceiveTestList.Where((SampleReceiveTestList x) => !entityList.Select((SampleReceiveTestList d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (SampleReceiveTestList item in list2)
					{
						List<SampleReceiveTestList> list3 = SampleReceiveTestList;
						Predicate<SampleReceiveTestList> match = (SampleReceiveTestList X) => X.FKTestID == item.FKTestID;
						list3.RemoveAll(match);
					}
					foreach (SampleReceiveTestList item4 in entityList.Where((SampleReceiveTestList x) => !SampleReceiveTestList.Select((SampleReceiveTestList d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						item4.SampleReceiveTestID = SampleReceiveTestList.Count + 1;
						SampleReceiveTestList.Add(item4);
					}
					HttpContext.Current.Session["SampleReceiveTestList"] = SampleReceiveTestList;
				}
			}
			return true;
		}

		public bool UpdateToSession(SampleReceiveTestList entity, long original_SampleReceiveTestListID)
		{
			object obj = HttpContext.Current.Session["SampleReceiveTestList"];
			if (obj != null)
			{
				List<SampleReceiveTestList> list = obj as List<SampleReceiveTestList>;
				SampleReceiveTestList sampleReceiveTestList = list.First((SampleReceiveTestList x) => x.SampleReceiveTestID == entity.SampleReceiveTestID);
				sampleReceiveTestList.FKPriceUnitID = entity.FKPriceUnitID;
				sampleReceiveTestList.Price = entity.Price;
				sampleReceiveTestList.Remarks = entity.Remarks;
				HttpContext.Current.Session["SampleReceiveTestList"] = list;
			}
			return true;
		}

		public bool UpdateToSession(SampleReceiveTestList entity)
		{
			object obj = HttpContext.Current.Session["SampleReceiveTestList"];
			List<SampleReceiveTestList> list = obj as List<SampleReceiveTestList>;
			if (list.Count > 0)
			{
				SampleReceiveTestList sampleReceiveTestList = list.FirstOrDefault((SampleReceiveTestList x) => x.SampleReceiveTestID == entity.SampleReceiveTestID);
				if (sampleReceiveTestList != null)
				{
					sampleReceiveTestList.Witness = entity.Witness;
					sampleReceiveTestList.WitnessName = entity.WitnessName;
					sampleReceiveTestList.Subcontract = entity.Subcontract;
					sampleReceiveTestList.FKSubContractorID = entity.FKSubContractorID;
					sampleReceiveTestList.Qty = entity.Qty;
					sampleReceiveTestList.Remarks = entity.Remarks;
					sampleReceiveTestList.IsChecked = false;
					sampleReceiveTestList.ApprovedBy = entity.ApprovedBy;
					sampleReceiveTestList.ApprovedDate = entity.ApprovedDate;
					sampleReceiveTestList.CheckedBy = entity.CheckedBy;
					sampleReceiveTestList.CheckedDate = entity.CheckedDate;
					sampleReceiveTestList.IsApproved = false;
					sampleReceiveTestList.IsInvoiced = false;
					if (sampleReceiveTestList.FKSampleID == 0 || !sampleReceiveTestList.FKSampleID.HasValue)
					{
						sampleReceiveTestList.RowStatus = 1;
						int? num = (from x in (IQueryable<TestsList>)dbContext.TestsList
							where (int?)x.TestID == entity.FKTestID
							select x.FkGroupId).FirstOrDefault();
						if (num.HasValue)
						{
							sampleReceiveTestList.ReportNumber = GetNewSerial(num.Value);
						}
						else
						{
							sampleReceiveTestList.ReportNumber = GetNewSerial();
						}
					}
					else
					{
						sampleReceiveTestList.RowStatus = 2;
						sampleReceiveTestList.ReportNumber = GetByID(entity.SampleReceiveTestID).ReportNumber;
					}
					HttpContext.Current.Session["SampleReceiveTestList"] = list;
				}
			}
			return true;
		}

		public bool UpdateDetailsFromSession(long SampleID)
		{
			object obj = HttpContext.Current.Session["SampleReceiveTestList"];
			if (obj != null)
			{
				List<SampleReceiveTestList> entityList = obj as List<SampleReceiveTestList>;
				List<SampleReceiveTestList> CurrentList = GetByMasterID(SampleID);
				List<SampleReceiveTestList> list = CurrentList.Where((SampleReceiveTestList x) => !entityList.Select((SampleReceiveTestList d) => d.FKTestID).Contains(x.FKTestID)).ToList();
				foreach (SampleReceiveTestList item in list)
				{
					Delete(item);
				}
				foreach (SampleReceiveTestList item2 in entityList.Where((SampleReceiveTestList x) => !CurrentList.Select((SampleReceiveTestList d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
				{
					string message = "";
					item2.FKSampleID = SampleID;
					if (!Insert(item2, out message))
					{
						throw new Exception(message);
					}
				}
				foreach (SampleReceiveTestList item3 in entityList.Where((SampleReceiveTestList x) => x.RowStatus == 2).ToList())
				{
					Update(item3);
				}
			}
			HttpContext.Current.Session["SampleReceiveTestList"] = null;
			return true;
		}

		public DataTable GetSampleFieldsBySampleID(long SampleID)
		{
			DataTable dataTable = new DataTable();
			DbConnection connection = this.dbContext.Database.Connection;
			ConnectionState state = connection.State;
			try
			{
				if (state != ConnectionState.Open)
				{
					connection.Open();
				}
				using (DbCommand dbCommand = connection.CreateCommand())
				{
					dbCommand.CommandText = "GetSampleFieldsByID";
					dbCommand.CommandType = CommandType.StoredProcedure;
					dbCommand.Parameters.Clear();
					dbCommand.Parameters.Add(new SqlParameter("SampleID", SampleID));
					using (DbDataReader dbDataReader = dbCommand.ExecuteReader())
					{
						dataTable.Load(dbDataReader);
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			return dataTable;
		}

		public List<ViewSampleReceiveTests> GetPendingCheckedSampleReceiveTests()
		{
			return ((IQueryable<ViewSampleReceiveTests>)dbContext.ViewSampleReceiveTests).Where((ViewSampleReceiveTests x) => x.IsChecked != (bool?)true).ToList();
		}

		public List<ViewSampleReceiveTests> GetPendingApprovedSampleReceiveTests()
		{
			return ((IQueryable<ViewSampleReceiveTests>)dbContext.ViewSampleReceiveTests).Where((ViewSampleReceiveTests x) => x.IsChecked == (bool?)true && x.IsApproved != (bool?)true).ToList();
		}

		public List<ViewSampleReceiveTests> GetViewSampleReceiveTests()
		{
			return ((IQueryable<ViewSampleReceiveTests>)dbContext.ViewSampleReceiveTests).Where((ViewSampleReceiveTests x) => x.IsChecked == (bool?)true && x.IsApproved == (bool?)true).ToList();
		}

		public List<ViewSampleReceiveTests> GetViewSampleReceiveTestsByJobOrderMasterID(DateTime FromDate, DateTime ToDate, int JobOrderMasterID, int masterId)
		{
			if (masterId > 0)
			{
				return ((IQueryable<ViewSampleReceiveTests>)dbContext.ViewSampleReceiveTests).Where((ViewSampleReceiveTests x) => x.JobOrderMasterID == (long?)(long)JobOrderMasterID && x.InvoiceId == (long)masterId).ToList();
			}
			if (FromDate != default(DateTime) && ToDate != default(DateTime))
			{
				return ((IQueryable<ViewSampleReceiveTests>)dbContext.ViewSampleReceiveTests).Where((ViewSampleReceiveTests x) => x.JobOrderMasterID == (long?)(long)JobOrderMasterID && x.IsInvoiced != true && x.InvoiceId == 0 && (DateTime)x.ReceiveDate >= (DateTime)(DateTime?)FromDate && (DateTime)x.ReceiveDate <= (DateTime)(DateTime?)ToDate).ToList();
			}
			return ((IQueryable<ViewSampleReceiveTests>)dbContext.ViewSampleReceiveTests).Where((ViewSampleReceiveTests x) => x.JobOrderMasterID == (long?)(long)JobOrderMasterID && x.IsInvoiced != true && x.InvoiceId == 0).ToList();
		}

		public decimal GetNotSampleReceiveTestsByJobOrderID(long JobOrderMasterID, long FKSampleID)
		{
			List<ViewSampleReceiveTests> list = ((IQueryable<ViewSampleReceiveTests>)dbContext.ViewSampleReceiveTests).Where((ViewSampleReceiveTests x) => x.JobOrderMasterID == (long?)JobOrderMasterID && x.IsInvoiced != true && x.UnitType != (int?)1 && x.FKSampleID != (long?)FKSampleID).ToList();
			decimal result = 0m;
			foreach (ViewSampleReceiveTests item in list)
			{
				if (item.Price.HasValue && item.Qty.HasValue)
				{
					result += item.Price.Value * item.Qty.Value;
				}
			}
			return result;
		}

		public bool UpdateCheckDetails(SampleReceiveTestList entity)
		{
			SampleReceiveTestList sampleReceiveTestList = ((IQueryable<SampleReceiveTestList>)dbContext.SampleReceiveTestList).Where((SampleReceiveTestList x) => x.SampleReceiveTestID == entity.SampleReceiveTestID).FirstOrDefault();
			sampleReceiveTestList.IsChecked = entity.IsChecked;
			if (entity.IsChecked == true)
			{
				sampleReceiveTestList.CheckedBy = long.Parse(HttpContext.Current.Session["UserId"].ToString());
				sampleReceiveTestList.CheckedDate = DateTime.Now;
			}
			if (Update(sampleReceiveTestList))
			{
				return true;
			}
			return false;
		}

		public bool UpdateApproveDetails(SampleReceiveTestList entity)
		{
			SampleReceiveTestList sampleReceiveTestList = ((IQueryable<SampleReceiveTestList>)dbContext.SampleReceiveTestList).Where((SampleReceiveTestList x) => x.SampleReceiveTestID == entity.SampleReceiveTestID).FirstOrDefault();
			sampleReceiveTestList.IsApproved = entity.IsApproved;
			if (entity.IsApproved == true)
			{
				sampleReceiveTestList.ApprovedBy = long.Parse(HttpContext.Current.Session["UserId"].ToString());
				sampleReceiveTestList.ApprovedDate = DateTime.Now;
			}
			if (Update(sampleReceiveTestList))
			{
				return true;
			}
			return false;
		}

		public bool UpdateInvoiceedToSession(ViewSampleReceiveTests entity)
		{
			object obj = HttpContext.Current.Session["SampleReceiveTestListInvoiced"];
			List<SampleReceiveTestList> list = ((obj != null) ? (obj as List<SampleReceiveTestList>) : new List<SampleReceiveTestList>());
			SampleReceiveTestList sampleReceiveTestList = ((IQueryable<SampleReceiveTestList>)dbContext.SampleReceiveTestList).Where((SampleReceiveTestList x) => x.SampleReceiveTestID == entity.SampleReceiveTestID).FirstOrDefault();
			sampleReceiveTestList.IsInvoiced = entity.IsInvoiced;
			list.Add(sampleReceiveTestList);
			HttpContext.Current.Session["SampleReceiveTestListInvoiced"] = list;
			return true;
		}

		public bool UpdateInvoiceedFromSession()
		{
			object obj = HttpContext.Current.Session["SampleReceiveTestListInvoiced"];
			if (obj != null)
			{
				List<SampleReceiveTestList> list = obj as List<SampleReceiveTestList>;
				foreach (SampleReceiveTestList item in list)
				{
					Update(item);
				}
			}
			HttpContext.Current.Session["SampleReceiveTestListInvoiced"] = null;
			return true;
		}

		public int GetNewSerial(int GroupId)
		{
			List<int> TestId = (from x in (IQueryable<TestsList>)dbContext.TestsList
				where x.FkGroupId == (int?)GroupId
				select x.TestID).ToList();
			int num;
			if (TestId.Count > 0)
			{
				object obj = HttpContext.Current.Session["SampleReceiveTestList"];
				List<SampleReceiveTestList> source = obj as List<SampleReceiveTestList>;
				List<SampleReceiveTestList> list = source.Where((SampleReceiveTestList x) => TestId.Contains(x.FKTestID.Value)).ToList();
				if (list.Count > 0)
				{
					SampleReceiveTestList sampleReceiveTestList = list.Where((SampleReceiveTestList x) => x.ReportNumber.HasValue).FirstOrDefault();
					if (sampleReceiveTestList != null)
					{
						return sampleReceiveTestList.ReportNumber.Value;
					}
					num = int.Parse(HttpContext.Current.Session["LastReportNumber"].ToString());
					num++;
					HttpContext.Current.Session["LastReportNumber"] = num;
					return num;
				}
				num = int.Parse(HttpContext.Current.Session["LastReportNumber"].ToString());
				num++;
				HttpContext.Current.Session["LastReportNumber"] = num;
				return num;
			}
			num = int.Parse(HttpContext.Current.Session["LastReportNumber"].ToString());
			num++;
			HttpContext.Current.Session["LastReportNumber"] = num;
			return num;
		}

		public int GetNewSerial()
		{
			if (HttpContext.Current.Session["LastReportNumber"] != null)
			{
				int num = int.Parse(HttpContext.Current.Session["LastReportNumber"].ToString());
				num++;
				HttpContext.Current.Session["LastReportNumber"] = num;
				return num;
			}
			return 0;
		}

		public int GetMaxReportNumber()
		{
			int? num = ((IQueryable<SampleReceiveTestList>)dbContext.SampleReceiveTestList).Max((SampleReceiveTestList entity) => entity.ReportNumber);
			if (num.HasValue)
            {
                if (num.Value < 199999)
                    return 199999; //Adding +1 in next code.
                else
                    return num.Value;
            }
            return 0;
		}
	}
}
