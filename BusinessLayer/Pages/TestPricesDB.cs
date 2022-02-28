using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class TestPricesDB : DBBase<TestPrices, List<TestPrices>, int>
	{
		public override List<TestPrices> GetAll()
		{
			return ((IEnumerable<TestPrices>)dbContext.TestPrices).ToList();
		}

		public override TestPrices GetByID(int id)
		{
			return ((IQueryable<TestPrices>)dbContext.TestPrices).FirstOrDefault((TestPrices j) => j.TestPriceID == id);
		}

		public override bool Insert(TestPrices entity, out string message)
		{
			message = "";
			try
			{
				dbContext.TestPrices.Add(entity);
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

		public override bool Update(TestPrices entity, out string message)
		{
			message = "";
			try
			{
				TestPrices byID = GetByID(entity.TestPriceID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<TestPrices>(byID);
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

		public override bool Delete(TestPrices entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<TestPrices>(entity).State = (EntityState)8;
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

		public bool Insert(TestPrices entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(TestPrices entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(TestPrices entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<TestPrices> GetByMasterIDWithSession(int masterId)
		{
			List<TestPrices> list;
			if (masterId > 0)
			{
				list = ((IQueryable<TestPrices>)dbContext.TestPrices).Where((TestPrices j) => j.FKTestID == masterId).ToList();
			}
			else
			{
				object obj = HttpContext.Current.Session["TestPricesList"];
				if (obj == null)
				{
					list = new List<TestPrices>();
					HttpContext.Current.Session["TestPricesList"] = list;
				}
				else
				{
					list = obj as List<TestPrices>;
				}
			}
			return list;
		}

		public bool InsertWithSession(TestPrices entity)
		{
			string message = "";
			List<TestPrices> byMasterIDWithSession = GetByMasterIDWithSession(entity.FKTestID);
			foreach (TestPrices item in byMasterIDWithSession)
			{
				if (item.FKPriceUnitID == entity.FKPriceUnitID)
				{
					message = "Cant repeate Unit  in same Test";
					throw new Exception(message);
				}
			}
			decimal? defaultPrice = entity.DefaultPrice;
			if (defaultPrice.GetValueOrDefault() >= 0m && defaultPrice.HasValue)
			{
				decimal? minimumPrice = entity.MinimumPrice;
				if (minimumPrice.GetValueOrDefault() >= 0m && minimumPrice.HasValue)
				{
					if (entity.DefaultPrice >= entity.MinimumPrice)
					{
						if (entity.FKTestID == 0)
						{
							object obj = HttpContext.Current.Session["TestPricesList"];
							List<TestPrices> list = ((obj != null) ? (obj as List<TestPrices>) : new List<TestPrices>());
							entity.TestPriceID = list.Count + 1;
							list.Add(entity);
							HttpContext.Current.Session["TestPricesList"] = list;
							return true;
						}
						if (Insert(entity, out message))
						{
							return true;
						}
						throw new Exception(message);
					}
					message = "Default price should be same or more than Minimum price";
					throw new Exception(message);
				}
			}
			message = "Negative Numbers Not Accepted In Default Price and Minimum Price ";
			throw new Exception(message);
		}

		public bool UpdateWithSession(TestPrices entity)
		{
			string message = "";
			decimal? defaultPrice = entity.DefaultPrice;
			if (defaultPrice.GetValueOrDefault() >= 0m && defaultPrice.HasValue)
			{
				decimal? minimumPrice = entity.MinimumPrice;
				if (minimumPrice.GetValueOrDefault() >= 0m && minimumPrice.HasValue)
				{
					if (entity.DefaultPrice >= entity.MinimumPrice)
					{
						if (entity.FKTestID == 0)
						{
							object obj = HttpContext.Current.Session["TestPricesList"];
							List<TestPrices> list = ((obj == null) ? new List<TestPrices>() : (obj as List<TestPrices>));
							TestPrices testPrices = list.First((TestPrices x) => x.TestPriceID == entity.TestPriceID);
							testPrices.FKPriceUnitID = entity.FKPriceUnitID;
							testPrices.DefaultPrice = entity.DefaultPrice;
							testPrices.MinimumPrice = entity.MinimumPrice;
							HttpContext.Current.Session["TestPricesList"] = list;
							return true;
						}
						if (Update(entity, out message))
						{
							return true;
						}
						throw new Exception(message);
					}
					message = "Default price should be same or more than Minimum price";
					throw new Exception(message);
				}
			}
			message = "Negative Numbers Not Accepted In Default Price and Minimum Price ";
			throw new Exception(message);
		}

		public bool DeleteWithSession(TestPrices entity)
		{
			string message = "";
			if (int.Parse(HttpContext.Current.Session["lblMasterId"].ToString()) == 0)
			{
				object obj = HttpContext.Current.Session["TestPricesList"];
				List<TestPrices> list;
				if (obj != null)
				{
					list = obj as List<TestPrices>;
					list.RemoveAll((TestPrices x) => x.TestPriceID == entity.TestPriceID);
				}
				else
				{
					list = new List<TestPrices>();
				}
				HttpContext.Current.Session["TestPricesList"] = list;
				return true;
			}
			entity = GetByID(entity.TestPriceID);
			int? num = ((IEnumerable<int?>)dbContext.SPValidateUnitPriceExist(entity.FKPriceUnitID, entity.FKTestID)).FirstOrDefault();
			if (num.HasValue && int.Parse(num.ToString()) > 0)
			{
				message = "this unit is used !";
				throw new Exception(message);
			}
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public TestPrices GetFirstPriceUnitByTestID(int TestID)
		{
			return ((IQueryable<TestPrices>)dbContext.TestPrices).First((TestPrices x) => x.FKTestID == TestID);
		}

		public List<PriceUnitList> GetTestPriceUnitList(int TestID)
		{
			List<TestPrices> source = ((IQueryable<TestPrices>)dbContext.TestPrices).Where((TestPrices x) => x.FKTestID == TestID).ToList();
			List<int> testPriceUnitIds = source.Select((TestPrices y) => y.FKPriceUnitID).Distinct().ToList();
			List<PriceUnitList> list = ((IQueryable<PriceUnitList>)dbContext.PriceUnitList).Where((PriceUnitList x) => testPriceUnitIds.Contains(x.PriceUnitID)).ToList();
			foreach (PriceUnitList item in list)
			{
				Func<TestPrices, bool> predicate = (TestPrices x) => x.FKPriceUnitID == item.PriceUnitID;
				decimal value = source.FirstOrDefault(predicate).MinimumPrice.Value;
				decimal value2 = source.FirstOrDefault((TestPrices x) => x.FKPriceUnitID == item.PriceUnitID).DefaultPrice.Value;
				item.MinimumPrice = value;
				item.DefaultPrice = value2;
			}
			return list;
		}

		public TestPrices GetPriceUnitByTestAndUnitID(int TestID, int PriceUnitID)
		{
			return ((IQueryable<TestPrices>)dbContext.TestPrices).FirstOrDefault((TestPrices x) => x.FKTestID == TestID && x.FKPriceUnitID == PriceUnitID);
		}
        
        public List<ViewTestPrices> GetFromViewTestPrices()
		{
			return ((IEnumerable<ViewTestPrices>)dbContext.ViewTestPrices).ToList();
		}
	}
}
