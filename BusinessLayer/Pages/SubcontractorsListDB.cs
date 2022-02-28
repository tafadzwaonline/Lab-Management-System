using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BusinessLayer.Pages
{
	public class SubcontractorsListDB : DBBase<SubcontractorsList, List<SubcontractorsList>, int>
	{
		public override List<SubcontractorsList> GetAll()
		{
			return ((IEnumerable<SubcontractorsList>)dbContext.SubcontractorsList).ToList();
		}

		public override SubcontractorsList GetByID(int id)
		{
			return ((IQueryable<SubcontractorsList>)dbContext.SubcontractorsList).FirstOrDefault((SubcontractorsList j) => j.SubContractorID == id);
		}

		public override bool Insert(SubcontractorsList entity, out string message)
		{
			message = "";
			int result;
			bool flag = int.TryParse(entity.SubContractorCode, out result);
			try
			{
				if (!CheckExist(entity.SubContractorCode))
				{
					if (flag)
					{
						if (int.Parse(entity.SubContractorCode) > 0)
						{
							dbContext.SubcontractorsList.Add(entity);
							if (((DbContext)dbContext).SaveChanges() > 0)
							{
								return true;
							}
							message = "InsertError";
							return false;
						}
						message = "negative number is  not allow";
						return false;
					}
					message = "alphabets is  not allow";
					return false;
				}
				message = "Dublicate Code Number";
				return false;
			}
			catch (Exception)
			{
				message = "InsertError";
				return false;
			}
		}

		public override bool Update(SubcontractorsList entity, out string message)
		{
			message = "";
			int result;
			bool flag = int.TryParse(entity.SubContractorCode, out result);
			try
			{
				SubcontractorsList byID = GetByID(entity.SubContractorID);
				if (!CheckExist(entity.SubContractorCode) || byID.SubContractorCode == entity.SubContractorCode)
				{
					if (flag)
					{
						if (int.Parse(entity.SubContractorCode) > 0)
						{
							DbEntityEntry val = ((DbContext)dbContext).Entry<SubcontractorsList>(byID);
							val.State = (EntityState)16;
							val.CurrentValues.SetValues((object)entity);
							if (((DbContext)dbContext).SaveChanges() > 0)
							{
								return true;
							}
							message = "UpdateError";
							return false;
						}
						message = "negative number is  not allow";
						return false;
					}
					message = "alphabets is  not allow";
					return false;
				}
				message = "Dublicate Code Number";
				return false;
			}
			catch (Exception)
			{
				message = "";
				return false;
			}
		}

		public override bool Delete(SubcontractorsList entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<SubcontractorsList>(entity).State = (EntityState)8;
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

		public bool Insert(SubcontractorsList entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(SubcontractorsList entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(SubcontractorsList entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		private bool CheckExist(string SubContractorCode)
		{
			SubcontractorsList subcontractorsList = ((IQueryable<SubcontractorsList>)dbContext.SubcontractorsList).FirstOrDefault((SubcontractorsList j) => j.SubContractorCode == SubContractorCode);
			if (subcontractorsList != null)
			{
				return true;
			}
			return false;
		}
	}
}
