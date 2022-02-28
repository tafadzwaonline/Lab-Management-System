using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PioneerLab.Pages
{
    public class SessionAttachedFilesDB : DBBase<AttachedFiles, List<AttachedFiles>, long>
    {
        public override List<AttachedFiles> GetAll()
        {
            List<AttachedFiles> attachedFiles = new List<AttachedFiles>();
            HttpContext context = HttpContext.Current;
            if (context.Session["NewSRAttachment"] != null)
            {
                attachedFiles = (List<AttachedFiles>)context.Session["NewSRAttachment"];
            }

            return attachedFiles;
        }

        public override AttachedFiles GetByID(long id)
        {
            List<AttachedFiles> attachedFiles = new List<AttachedFiles>();
            HttpContext context = HttpContext.Current;

            if (context.Session["NewSRAttachment"] != null)
            {
                attachedFiles = (List<AttachedFiles>)context.Session["NewSRAttachment"];
            }

            return attachedFiles.FirstOrDefault((AttachedFiles j) => j.FileID == id);
        }

        public override bool Insert(AttachedFiles entity, out string message)
        {
            message = "";
            try
            {
                List<AttachedFiles> attachedFiles = new List<AttachedFiles>();
                HttpContext context = HttpContext.Current;

                if (context.Session["NewSRAttachment"] != null)
                {
                    attachedFiles = (List<AttachedFiles>)context.Session["NewSRAttachment"];
                    entity.FileID = attachedFiles.Count + 1;
                }
                else
                    entity.FileID = 1;

                attachedFiles.Add(entity);
                context.Session["NewSRAttachment"] = attachedFiles;
            
                if (context.Session["NewSRAttachment"] != null)
                {
                    return true;
                }

                message = "InsertError";
                return false;
            }
            catch (Exception ex)
            {
                message = "InsertError";
                return false;
            }
        }

        public override bool Update(AttachedFiles entity, out string message)
        {
            message = "";
            return false;
            //bool result;
            //try
            //{
            //    AttachedFiles byID = this.GetByID(entity.FileID);
            //    DbEntityEntry dbEntityEntry = this.dbContext.Entry<AttachedFiles>(byID);
            //    dbEntityEntry.State = EntityState.Modified;
            //    dbEntityEntry.CurrentValues.SetValues(entity);
            //    if (this.dbContext.SaveChanges() > 0)
            //    {
            //        result = true;
            //    }
            //    else
            //    {
            //        message = "UpdateError";
            //        result = false;
            //    }
            //}
            //catch (Exception)
            //{
            //    message = "";
            //    result = false;
            //}
            //return result;
        }

        public override bool Delete(AttachedFiles entity, out string message)
        {
            message = "";
            bool result;
            try
            {
                List<AttachedFiles> attachedFiles = new List<AttachedFiles>();
                HttpContext context = HttpContext.Current;

                if (context.Session["NewSRAttachment"] != null)
                {
                    attachedFiles = (List<AttachedFiles>)context.Session["NewSRAttachment"];
                }

                attachedFiles.Remove(entity);
                context.Session["NewSRAttachment"] = attachedFiles;
                result = true;
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

        public bool Delete(AttachedFiles entity)
        {
            string message = "";
            if (Delete(entity, out message))
            {
                return true;
            }
            throw new Exception(message);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int GetAttachmentsCount(long transID, int transTypeID)
        {
            List<AttachedFiles> attachedFiles = new List<AttachedFiles>();
            HttpContext context = HttpContext.Current;
            if (context.Session["NewSRAttachment"] != null)
            {
                attachedFiles = (List<AttachedFiles>)context.Session["NewSRAttachment"];
            }

            return attachedFiles.Count((AttachedFiles entity) => entity.FKTransID == transID && entity.FKTransTypeID == transTypeID);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<AttachedFiles> GetAttachmentsWithNew(long transID, int transTypeID)
        {
            List<AttachedFiles> attachedFiles = new List<AttachedFiles>();
            HttpContext context = HttpContext.Current;
            if (context.Session["NewSRAttachment"] != null)
            {
                attachedFiles = (List<AttachedFiles>)context.Session["NewSRAttachment"];
            }

            var list = attachedFiles.Where((AttachedFiles x) => x.FKTransTypeID == transTypeID && x.FKTransID == transID).ToList();
            return list;
        }

        //public int DeleteData(AttachedFiles AttachedFiles)
        //{
        //    List<AttachedFiles> list = new List<AttachedFiles>();
        //    List<AttachedFiles> list2 = new List<AttachedFiles>();
        //    long num = 0L;
        //    if (HttpContext.Current.Session["_appattachTransID"] != null)
        //    {
        //        num = long.Parse(HttpContext.Current.Session["_appattachTransID"].ToString());
        //    }
        //    if (HttpContext.Current.Session["_appattachfiles"] != null)
        //    {
        //        list = (List<AttachedFiles>)HttpContext.Current.Session["_appattachfiles"];
        //    }
        //    if (HttpContext.Current.Session["_appattachUnsavedfiles"] != null)
        //    {
        //        list2 = (List<AttachedFiles>)HttpContext.Current.Session["_appattachUnsavedfiles"];
        //    }
        //    if (list.Count > 0)
        //    {
        //        AttachedFiles item = list.First((AttachedFiles x) => x.FileID == AttachedFiles.FileID);
        //        list.Remove(item);
        //        if (list2.Count((AttachedFiles x) => x.FileID == AttachedFiles.FileID) > 0)
        //        {
        //            list2.Remove(list2.First((AttachedFiles x) => x.FileID == AttachedFiles.FileID));
        //        }
        //        else if (num != 0L)
        //        {
        //            AttachedFiles = this.GetByID(AttachedFiles.FileID);
        //            DbEntityEntry dbEntityEntry = this.dbContext.Entry<AttachedFiles>(AttachedFiles);
        //            dbEntityEntry.State = EntityState.Deleted;
        //            int num2 = this.dbContext.SaveChanges();
        //            if (num2 == 0)
        //            {
        //                list.Add(item);
        //                return num2;
        //            }
        //        }
        //        HttpContext.Current.Session["_appattachfiles"] = list;
        //        HttpContext.Current.Session["_appattachUnsavedfiles"] = list2;
        //        return 1;
        //    }
        //    return 0;
        //}
    }
}
