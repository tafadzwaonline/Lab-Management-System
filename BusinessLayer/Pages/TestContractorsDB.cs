using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class TestContractorsDB : DBBase<TestContractors, List<TestContractors>, int>
	{
		public override List<TestContractors> GetAll()
		{
			return ((IEnumerable<TestContractors>)dbContext.TestContractors).ToList();
		}

		public override TestContractors GetByID(int id)
		{
			return ((IQueryable<TestContractors>)dbContext.TestContractors).FirstOrDefault((TestContractors j) => j.TestContractorsID == id);
		}

		public override bool Insert(TestContractors entity, out string message)
		{
			message = "";
			try
			{
				dbContext.TestContractors.Add(entity);
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

		public override bool Update(TestContractors entity, out string message)
		{
			message = "";
			try
			{
				TestContractors byID = GetByID(entity.TestContractorsID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<TestContractors>(byID);
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

		public override bool Delete(TestContractors entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<TestContractors>(entity).State = (EntityState)8;
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

		public bool Insert(TestContractors entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(TestContractors entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(TestContractors entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<TestContractors> GetByMasterID(int masterId)
		{
			return ((IQueryable<TestContractors>)dbContext.TestContractors).Where((TestContractors j) => j.FKTestID == masterId).ToList();
		}

		public bool UpdateList(List<TestContractors> entityList)
		{
			if (entityList.Count > 0)
			{
				int fKTestID = entityList.First().FKTestID;
				List<TestContractors> CurrentList = GetByMasterID(fKTestID);
				List<TestContractors> list = CurrentList.Where((TestContractors x) => !entityList.Select((TestContractors d) => d.FKSubContractorID).Contains(x.FKSubContractorID)).ToList();
				foreach (TestContractors item in list)
				{
					Delete(item);
				}
				foreach (TestContractors item2 in entityList.Where((TestContractors x) => !CurrentList.Select((TestContractors d) => d.FKSubContractorID).Contains(x.FKSubContractorID) && x.FKSubContractorID > 0).ToList())
				{
					string message = "";
					if (!Insert(item2, out message))
					{
						throw new Exception(message);
					}
				}
			}
			return true;
		}

		public List<SubcontractorsList> GetTestContractorsList(int TestID)
		{
			List<int> testContractorsIds = (from x in (IQueryable<TestContractors>)dbContext.TestContractors
				where x.FKTestID == TestID
				select x into y
				select y.FKSubContractorID).Distinct().ToList();
			return ((IQueryable<SubcontractorsList>)dbContext.SubcontractorsList).Where((SubcontractorsList x) => testContractorsIds.Contains(x.SubContractorID)).ToList();
		}
	}
}
