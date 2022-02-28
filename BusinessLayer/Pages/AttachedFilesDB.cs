using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;
using System.Web;

namespace BusinessLayer.Pages
{
	public class AttachedFilesDB : DBBase<AttachedFiles, List<AttachedFiles>, long>
	{
		public override List<AttachedFiles> GetAll()
		{
			return ((IEnumerable<AttachedFiles>)dbContext.AttachedFiles).ToList();
		}

		public override AttachedFiles GetByID(long id)
		{
			return ((IQueryable<AttachedFiles>)dbContext.AttachedFiles).FirstOrDefault((AttachedFiles j) => j.FileID == id);
		}

		public override bool Insert(AttachedFiles entity, out string message)
		{
			message = "";
			try
			{
				dbContext.AttachedFiles.Add(entity);
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

		public override bool Update(AttachedFiles entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				AttachedFiles byID = this.GetByID(entity.FileID);
				DbEntityEntry dbEntityEntry = this.dbContext.Entry<AttachedFiles>(byID);
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

		public override bool Delete(AttachedFiles entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<AttachedFiles>(entity).State = EntityState.Deleted;
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

		public bool Insert(AttachedFiles entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(AttachedFiles entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(AttachedFiles entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public string SaveAttachments(List<AttachedFiles> AttachmentList, long TransactionID)
		{
			string text = "";
			string result;
			using (TransactionScope transactionScope = new TransactionScope())
			{
				this.DeleteAll(TransactionID, AttachmentList.First<AttachedFiles>().FKTransTypeID);
				foreach (AttachedFiles attachedFiles in AttachmentList)
				{
					attachedFiles.FKTransID = TransactionID;
					this.Insert(attachedFiles, out text);
					if (text != "")
					{
						break;
					}
				}
				if (text == "")
				{
					transactionScope.Complete();
				}
				result = text;
			}
			return result;
		}

		public string DeleteAll(long transID, int transTypeID)
		{
			string message = "";
			try
			{
				if (((IQueryable<AttachedFiles>)dbContext.AttachedFiles).Count((AttachedFiles e) => e.FKTransID == transID && e.FKTransTypeID == transTypeID) > 0)
				{
					List<AttachedFiles> list = ((IQueryable<AttachedFiles>)dbContext.AttachedFiles).Where((AttachedFiles e) => e.FKTransID == transID && e.FKTransTypeID == transTypeID).ToList();
					{
						foreach (AttachedFiles item in list)
						{
							Delete(item, out message);
							if (message != "")
							{
								return message;
							}
						}
						return message;
					}
				}
				return message;
			}
			catch
			{
				return "Delete Error";
			}
		}

		[DataObjectMethod(DataObjectMethodType.Select)]
		public int GetAttachmentsCount(long transID, int transTypeID)
		{
			return ((IQueryable<AttachedFiles>)dbContext.AttachedFiles).Count((AttachedFiles entity) => entity.FKTransID == transID && entity.FKTransTypeID == transTypeID);
		}

		[DataObjectMethod(DataObjectMethodType.Select)]
		public List<AttachedFiles> GetAttachmentsWithNew(long transID, int transTypeID)
		{
			return ((IQueryable<AttachedFiles>)dbContext.AttachedFiles).Where((AttachedFiles x) => x.FKTransTypeID == transTypeID && x.FKTransID == transID).ToList();
		}

		public int DeleteData(AttachedFiles AttachedFiles)
		{
			List<AttachedFiles> list = new List<AttachedFiles>();
			List<AttachedFiles> list2 = new List<AttachedFiles>();
			long num = 0L;
			if (HttpContext.Current.Session["_appattachTransID"] != null)
			{
				num = long.Parse(HttpContext.Current.Session["_appattachTransID"].ToString());
			}
			if (HttpContext.Current.Session["_appattachfiles"] != null)
			{
				list = (List<AttachedFiles>)HttpContext.Current.Session["_appattachfiles"];
			}
			if (HttpContext.Current.Session["_appattachUnsavedfiles"] != null)
			{
				list2 = (List<AttachedFiles>)HttpContext.Current.Session["_appattachUnsavedfiles"];
			}
			if (list.Count > 0)
			{
				AttachedFiles item = list.First((AttachedFiles x) => x.FileID == AttachedFiles.FileID);
				list.Remove(item);
				if (list2.Count((AttachedFiles x) => x.FileID == AttachedFiles.FileID) > 0)
				{
					list2.Remove(list2.First((AttachedFiles x) => x.FileID == AttachedFiles.FileID));
				}
				else if (num != 0L)
				{
					AttachedFiles = this.GetByID(AttachedFiles.FileID);
					DbEntityEntry dbEntityEntry = this.dbContext.Entry<AttachedFiles>(AttachedFiles);
					dbEntityEntry.State = EntityState.Deleted;
					int num2 = this.dbContext.SaveChanges();
					if (num2 == 0)
					{
						list.Add(item);
						return num2;
					}
				}
				HttpContext.Current.Session["_appattachfiles"] = list;
				HttpContext.Current.Session["_appattachUnsavedfiles"] = list2;
				return 1;
			}
			return 0;
		}

		public string GetKeywords(long transID, int transTypeID)
		{
			if (((IQueryable<AttachedFiles>)dbContext.AttachedFiles).Count((AttachedFiles e) => e.FKTransID == transID && e.FKTransTypeID == transTypeID) > 0)
			{
				return ((IQueryable<AttachedFiles>)dbContext.AttachedFiles).FirstOrDefault((AttachedFiles e) => e.FKTransID == transID && e.FKTransTypeID == transTypeID).Keywords;
			}
			return "";
		}

		public List<AttachFileTransTypes> getAttachmentTypeByModule(int moduleId)
		{
			return ((IQueryable<AttachFileTransTypes>)dbContext.AttachFileTransTypes).Where((AttachFileTransTypes e) => e.FKModuleID == (int?)moduleId).ToList();
		}
	}
}
