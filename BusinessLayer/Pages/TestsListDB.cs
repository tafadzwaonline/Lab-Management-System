using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class TestsListDB : DBBase<TestsList, List<TestsList>, int>
	{
		public override List<TestsList> GetAll()
		{
			return ((IEnumerable<TestsList>)dbContext.TestsList).ToList();
		}

		public override TestsList GetByID(int id)
		{
			return ((IQueryable<TestsList>)dbContext.TestsList).FirstOrDefault((TestsList j) => j.TestID == id);
		}

		public override bool Insert(TestsList entity, out string message)
		{
			message = "";
			try
			{
				dbContext.TestsList.Add(entity);
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

		public override bool Update(TestsList entity, out string message)
		{
			message = "";
			try
			{
				TestsList byID = GetByID(entity.TestID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<TestsList>(byID);
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

		public override bool Delete(TestsList entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<TestsList>(entity).State =(EntityState)8;
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

		public bool Insert(TestsList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(TestsList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(TestsList entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<string> GetWorkformWorksheetList()
		{
			object obj = HttpContext.Current.Session["WorkformWorksheetList"];
			if (obj == null)
			{
				obj = new List<string>();
			}
			return obj as List<string>;
		}

		public List<string> GetReportWorksheetList()
		{
			object obj = HttpContext.Current.Session["ReportWorksheetList"];
			if (obj == null)
			{
				obj = new List<string>();
			}
			return obj as List<string>;
		}

		public List<TestsList> GetAllServiceByMaterial(int? MaterialTypeID, int? MaterialDetailsID)
		{
			if (MaterialTypeID.HasValue)
			{
				List<int> testIDList = new List<int>();
				List<MaterialsDetails> byFKMaterialTypeID = new MaterialsDetailsDB().GetByFKMaterialTypeID(MaterialTypeID.Value);
				if (MaterialDetailsID.HasValue)
				{
					byFKMaterialTypeID.RemoveAll((MaterialsDetails x) => x.MaterialDetailsID != MaterialDetailsID.Value);
				}
				List<MaterialsDetailsTests> list = new List<MaterialsDetailsTests>();
				foreach (MaterialsDetails item in byFKMaterialTypeID)
				{
					list.AddRange(item.MaterialsDetailsTests.ToList());
				}
				testIDList = list.Select((MaterialsDetailsTests x) => x.FKTestID).Distinct().ToList();
				return ((IQueryable<TestsList>)dbContext.TestsList).Where((TestsList x) => testIDList.Contains(x.TestID)).ToList();
			}
			return GetAll();
		}

		public List<TestsList> GetAllServiceByMaterial(int? MaterialTypeID, int? MaterialDetailsID, int? FKPriceUnitID)
		{
			if (MaterialTypeID.HasValue)
			{
				List<int> testIDList = new List<int>();
				List<MaterialsDetails> byFKMaterialTypeID = new MaterialsDetailsDB().GetByFKMaterialTypeID(MaterialTypeID.Value);
				if (MaterialDetailsID.HasValue)
				{
					byFKMaterialTypeID.RemoveAll((MaterialsDetails x) => x.MaterialDetailsID != MaterialDetailsID.Value);
				}
				List<MaterialsDetailsTests> list = new List<MaterialsDetailsTests>();
				foreach (MaterialsDetails item in byFKMaterialTypeID)
				{
					list.AddRange(item.MaterialsDetailsTests.ToList());
				}
				if (FKPriceUnitID.HasValue)
				{
					List<int> TestPrices2 = (from x in new TestPricesDB().GetAll()
						where x.FKPriceUnitID == FKPriceUnitID
						select x.FKTestID).ToList();
					testIDList = list.Select((MaterialsDetailsTests x) => x.FKTestID).Distinct().ToList();
					return ((IQueryable<TestsList>)dbContext.TestsList).Where((TestsList x) => testIDList.Contains(x.TestID) && TestPrices2.Contains(x.TestID)).ToList();
				}
				testIDList = list.Select((MaterialsDetailsTests x) => x.FKTestID).Distinct().ToList();
				return ((IQueryable<TestsList>)dbContext.TestsList).Where((TestsList x) => testIDList.Contains(x.TestID)).ToList();
			}
			if (FKPriceUnitID.HasValue)
			{
				List<int> TestPrices = (from x in new TestPricesDB().GetAll()
					where x.FKPriceUnitID == FKPriceUnitID
					select x.FKTestID).ToList();
				return (from x in GetAll()
					where TestPrices.Contains(x.TestID)
					select x).ToList();
			}
			return GetAll();
		}
	}
}
