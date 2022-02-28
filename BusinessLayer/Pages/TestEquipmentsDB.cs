using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class TestEquipmentsDB : DBBase<TestEquipments, List<TestEquipments>, int>
	{
		public override List<TestEquipments> GetAll()
		{
			return ((IEnumerable<TestEquipments>)dbContext.TestEquipments).ToList();
		}

		public override TestEquipments GetByID(int id)
		{
			return ((IQueryable<TestEquipments>)dbContext.TestEquipments).FirstOrDefault((TestEquipments j) => j.TestEquipmentID == id);
		}

		public override bool Insert(TestEquipments entity, out string message)
		{
			message = "";
			try
			{
				dbContext.TestEquipments.Add(entity);
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

		public override bool Update(TestEquipments entity, out string message)
		{
			message = "";
			try
			{
				TestEquipments byID = GetByID(entity.TestEquipmentID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<TestEquipments>(byID);
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

		public override bool Delete(TestEquipments entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<TestEquipments>(entity).State = (EntityState)8;
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

		public bool Insert(TestEquipments entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(TestEquipments entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(TestEquipments entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<TestEquipments> GetByMasterID(int masterId)
		{
			return ((IQueryable<TestEquipments>)dbContext.TestEquipments).Where((TestEquipments j) => j.FKTestID == masterId).ToList();
		}

		public bool UpdateList(List<TestEquipments> entityList)
		{
			if (entityList.Count > 0)
			{
				int fKTestID = entityList.First().FKTestID;
				List<TestEquipments> CurrentList = GetByMasterID(fKTestID);
				List<TestEquipments> list = CurrentList.Where((TestEquipments x) => !entityList.Select((TestEquipments d) => d.FKEquipmentID).Contains(x.FKEquipmentID)).ToList();
				foreach (TestEquipments item in list)
				{
					Delete(item);
				}
				foreach (TestEquipments item2 in entityList.Where((TestEquipments x) => !CurrentList.Select((TestEquipments d) => d.FKEquipmentID).Contains(x.FKEquipmentID) && x.FKEquipmentID > 0).ToList())
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
	}
}
