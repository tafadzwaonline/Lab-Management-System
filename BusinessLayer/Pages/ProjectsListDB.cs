using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Pages
{
	public class ProjectsListDB : DBBase<ProjectsList, List<ProjectsList>, int>
	{
		public override List<ProjectsList> GetAll()
		{
			return ((IEnumerable<ProjectsList>)dbContext.ProjectsList).ToList();
		}

		public override ProjectsList GetByID(int id)
		{
			return ((IQueryable<ProjectsList>)dbContext.ProjectsList).FirstOrDefault((ProjectsList j) => j.ProjectID == id);
		}

		public override bool Insert(ProjectsList entity, out string message)
		{
			message = "";
			try
			{
				if (!CheckExist(entity.AshghalCode) || entity.AshghalCode == "")
				{
					if (entity.EndDate < entity.StartDate)
					{
						message = "End Date should be greater than Start Date....!";
						return false;
					}
					dbContext.ProjectsList.Add(entity);
					if (((DbContext)dbContext).SaveChanges() > 0)
					{
						return true;
					}
					message = "InsertError";
					return false;
				}
				message = "Ashghal Code is Exist";
				return false;
			}
			catch (Exception)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(ProjectsList entity, out string message)
		{
			message = "";
			try
			{
				ProjectsList byID = GetByID(entity.ProjectID);
				if (!CheckExist(entity.AshghalCode) || entity.AshghalCode == "" || byID.AshghalCode == entity.AshghalCode)
				{
					if (entity.EndDate < entity.StartDate)
					{
						message = "End Date should be greater than Start Date....!";
						return false;
					}
					DbEntityEntry val = ((DbContext)dbContext).Entry<ProjectsList>(byID);
					val.State = (EntityState)16;
					val.CurrentValues.SetValues((object)entity);
					if (((DbContext)dbContext).SaveChanges() > 0)
					{
						return true;
					}
					message = "UpdateError";
					return false;
				}
				message = "Ashghal Code is Exist";
				return false;
			}
			catch (Exception)
			{
				message = "";
				return false;
			}
		}

		public override bool Delete(ProjectsList entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<ProjectsList>(entity).State = (EntityState)8;
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

		public bool Insert(ProjectsList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(ProjectsList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(ProjectsList entity)
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
			string maxValidityCode = GetMaxValidityCode();
			if (maxValidityCode != "0")
			{
				return (Convert.ToInt32(maxValidityCode) + 1).ToString();
			}
			return "1";
		}

		private string GetMaxValidityCode()
		{
			int? num = ((IQueryable<ProjectsList>)dbContext.ProjectsList).Max((Expression<Func<ProjectsList, int?>>)((ProjectsList entity) => entity.ProjectID));
			if (num.HasValue)
			{
				string text = GetByID(num.Value).ProjectCode;
				if (text == null)
				{
					text = "0";
				}
				return text;
			}
			return "0";
		}

		private bool CheckExist(string AshghalCode)
		{
			ProjectsList projectsList = ((IQueryable<ProjectsList>)dbContext.ProjectsList).Where((ProjectsList i) => i.AshghalCode == AshghalCode).FirstOrDefault();
			if (projectsList == null)
			{
				return false;
			}
			return true;
		}
	}
}
