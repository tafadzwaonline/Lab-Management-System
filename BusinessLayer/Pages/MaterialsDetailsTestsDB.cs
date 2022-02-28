using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class MaterialsDetailsTestsDB : DBBase<MaterialsDetailsTests, List<MaterialsDetailsTests>, int>
	{
		public override List<MaterialsDetailsTests> GetAll()
		{
			return ((IEnumerable<MaterialsDetailsTests>)dbContext.MaterialsDetailsTests).ToList();
		}

		public override MaterialsDetailsTests GetByID(int id)
		{
			return ((IQueryable<MaterialsDetailsTests>)dbContext.MaterialsDetailsTests).FirstOrDefault((MaterialsDetailsTests j) => j.MaterialTestID == id);
		}

		public override bool Insert(MaterialsDetailsTests entity, out string message)
		{
			message = "";
			try
			{
				dbContext.MaterialsDetailsTests.Add(entity);
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

		public override bool Update(MaterialsDetailsTests entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				MaterialsDetailsTests byID = this.GetByID(entity.MaterialTestID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<MaterialsDetailsTests>(byID);
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

		// Token: 0x06000839 RID: 2105 RVA: 0x0002239C File Offset: 0x0002059C
		public override bool Delete(MaterialsDetailsTests entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<MaterialsDetailsTests>(entity).State = EntityState.Deleted;
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


		public List<MaterialsDetailsTests> GetByFKMaterialDetailsID(int FKMaterialDetailsID)
		{
			return ((IQueryable<MaterialsDetailsTests>)dbContext.MaterialsDetailsTests).Where((MaterialsDetailsTests e) => e.FKMaterialDetailsID == FKMaterialDetailsID).ToList();
		}

		public List<MaterialsDetailsTests> GetByFKMaterialDetailsIDWithSession(int FKMaterialDetailsID)
		{
			if (FKMaterialDetailsID > 0)
			{
				return ((IQueryable<MaterialsDetailsTests>)dbContext.MaterialsDetailsTests).Where((MaterialsDetailsTests e) => e.FKMaterialDetailsID == FKMaterialDetailsID).ToList();
			}
			object obj = HttpContext.Current.Session["MaterialsDetailsTestsList"];
			List<MaterialsDetailsTests> list;
			if (obj == null)
			{
				list = new List<MaterialsDetailsTests>();
				HttpContext.Current.Session["MaterialsDetailsTestsList"] = list;
			}
			else
			{
				list = obj as List<MaterialsDetailsTests>;
			}
			return list;
		}

		public bool Insert(MaterialsDetailsTests entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(MaterialsDetailsTests entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(MaterialsDetailsTests entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateList(List<MaterialsDetailsTests> entityList)
		{
			if (entityList.Count > 0)
			{
				int fKMaterialDetailsID = entityList.First().FKMaterialDetailsID;
				if (fKMaterialDetailsID > 0)
				{
					List<MaterialsDetailsTests> CurrentList = GetByFKMaterialDetailsID(fKMaterialDetailsID);
					List<MaterialsDetailsTests> list = CurrentList.Where((MaterialsDetailsTests x) => !entityList.Select((MaterialsDetailsTests d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (MaterialsDetailsTests item2 in list)
					{
						Delete(item2);
					}
					foreach (MaterialsDetailsTests item3 in entityList.Where((MaterialsDetailsTests x) => !CurrentList.Select((MaterialsDetailsTests d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
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
					object obj = HttpContext.Current.Session["MaterialsDetailsTestsList"];
					List<MaterialsDetailsTests> MaterialsDetailsTestsList;
					if (obj == null)
					{
						MaterialsDetailsTestsList = new List<MaterialsDetailsTests>();
					}
					else
					{
						MaterialsDetailsTestsList = obj as List<MaterialsDetailsTests>;
					}
					List<MaterialsDetailsTests> list2 = MaterialsDetailsTestsList.Where((MaterialsDetailsTests x) => !entityList.Select((MaterialsDetailsTests d) => d.FKTestID).Contains(x.FKTestID)).ToList();
					foreach (MaterialsDetailsTests item in list2)
					{
						List<MaterialsDetailsTests> list3 = MaterialsDetailsTestsList;
						Predicate<MaterialsDetailsTests> match = (MaterialsDetailsTests X) => X.FKTestID == item.FKTestID;
						list3.RemoveAll(match);
					}
					foreach (MaterialsDetailsTests item4 in entityList.Where((MaterialsDetailsTests x) => !MaterialsDetailsTestsList.Select((MaterialsDetailsTests d) => d.FKTestID).Contains(x.FKTestID) && x.FKTestID > 0).ToList())
					{
						item4.MaterialTestID = MaterialsDetailsTestsList.Count + 1;
						MaterialsDetailsTestsList.Add(item4);
					}
					HttpContext.Current.Session["MaterialsDetailsTestsList"] = MaterialsDetailsTestsList;
				}
			}
			return true;
		}
	}
}
