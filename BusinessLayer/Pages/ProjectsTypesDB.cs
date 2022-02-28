using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class ProjectsTypesDB : DBBase<ProjectsTypes, List<ProjectsTypes>, int>
	{
		public override List<ProjectsTypes> GetAll()
		{
			return ((IEnumerable<ProjectsTypes>)dbContext.ProjectsTypes).ToList();
		}

		public override ProjectsTypes GetByID(int id)
		{
			return ((IQueryable<ProjectsTypes>)dbContext.ProjectsTypes).FirstOrDefault((ProjectsTypes j) => j.ProjectTypeID == id);
		}

		public override bool Insert(ProjectsTypes entity, out string message)
		{
			message = "";
			try
			{
				dbContext.ProjectsTypes.Add(entity);
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

		public override bool Update(ProjectsTypes entity, out string message)
		{
			message = "";
			try
			{
				ProjectsTypes byID = GetByID(entity.ProjectTypeID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<ProjectsTypes>(byID);
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

		public override bool Delete(ProjectsTypes entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<ProjectsTypes>(entity).State = (EntityState)8;
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

		public bool Insert(ProjectsTypes entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(ProjectsTypes entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(ProjectsTypes entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}
	}
}
