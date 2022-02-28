using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BusinessLayer.Pages
{
	public class SampleReceiveMaterialCustomFieldDB : DBBase<SampleReceiveMaterialCustomField, List<SampleReceiveMaterialCustomField>, long>
	{
		public override List<SampleReceiveMaterialCustomField> GetAll()
		{
			return ((IEnumerable<SampleReceiveMaterialCustomField>)dbContext.SampleReceiveMaterialCustomField).ToList();
		}

		public override SampleReceiveMaterialCustomField GetByID(long id)
		{
			return ((IQueryable<SampleReceiveMaterialCustomField>)dbContext.SampleReceiveMaterialCustomField).FirstOrDefault((SampleReceiveMaterialCustomField j) => j.SampleReceiveCFLinkID == id);
		}

		public override bool Insert(SampleReceiveMaterialCustomField entity, out string message)
		{
			message = "";
			try
			{
				dbContext.SampleReceiveMaterialCustomField.Add(entity);
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

		public override bool Update(SampleReceiveMaterialCustomField entity, out string message)
		{
			message = "";
			try
			{
				SampleReceiveMaterialCustomField byID = GetByID(entity.SampleReceiveCFLinkID);
				byID.Value = entity.Value;
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

		public override bool Delete(SampleReceiveMaterialCustomField entity, out string message)
		{
			message = "";
			try
			{
				((DbContext)dbContext).Entry<SampleReceiveMaterialCustomField>(entity).State = (EntityState)8;
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

		public bool Insert(SampleReceiveMaterialCustomField entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(SampleReceiveMaterialCustomField entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(SampleReceiveMaterialCustomField entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<SampleReceiveMaterialCustomField> GetSampleReceiveMaterialCustomFieldMaterialTypeID(int FKMaterialTypeID, long SampleID)
		{
			return ((IQueryable<SampleReceiveMaterialCustomField>)dbContext.SampleReceiveMaterialCustomField).Where((SampleReceiveMaterialCustomField x) => x.FkSampleID == SampleID && x.MaterialTypesCustomFields.FKMaterialTypeID == FKMaterialTypeID).Distinct().ToList();
		}

		public List<SampleReceiveMaterialCustomField> GetNewSampleReceiveMaterialCustomFieldMaterialTypeID(int FKMaterialTypeID, long SampleID)
		{
			List<SampleReceiveMaterialCustomField> list = new List<SampleReceiveMaterialCustomField>();
			List<MaterialTypesCustomFields> list2 = ((IQueryable<MaterialTypesCustomFields>)dbContext.MaterialTypesCustomFields).Where((MaterialTypesCustomFields x) => x.FKMaterialTypeID == FKMaterialTypeID && x.DataType != 5).Distinct().ToList();
			foreach (MaterialTypesCustomFields item in list2)
			{
				SampleReceiveMaterialCustomField sampleReceiveMaterialCustomField = new SampleReceiveMaterialCustomField();
				sampleReceiveMaterialCustomField.FkCustomFieldID = item.CustomFieldID;
				sampleReceiveMaterialCustomField.FkSampleID = 0L;
				sampleReceiveMaterialCustomField.Value = null;
				sampleReceiveMaterialCustomField.SampleReceiveCFLinkID = list.Count + 1;
				list.Add(sampleReceiveMaterialCustomField);
			}
			return list;
		}

		public List<SampleReceiveMaterialCustomField> GetNonTableFieldsByFKMaterialTypeIDWithSession(int FKMaterialTypeID, long SampleID)
		{
			if (SampleID > 0)
			{
				return GetSampleReceiveMaterialCustomFieldMaterialTypeID(FKMaterialTypeID, SampleID).ToList();
			}
			object obj = HttpContext.Current.Session["SampleMaterialCustomFieldList"];
			if (obj == null && FKMaterialTypeID == 0)
			{
				return new List<SampleReceiveMaterialCustomField>();
			}
			if (obj == null && FKMaterialTypeID != 0)
			{
				obj = GetNewSampleReceiveMaterialCustomFieldMaterialTypeID(FKMaterialTypeID, SampleID);
				HttpContext.Current.Session["SampleMaterialCustomFieldList"] = obj;
				return ((List<SampleReceiveMaterialCustomField>)obj).ToList();
			}
			if (obj != null)
			{
				return ((List<SampleReceiveMaterialCustomField>)obj).ToList();
			}
			List<SampleReceiveMaterialCustomField> list;
			return list = null;
		}

		public bool UpdateSampleMaterialCustomFieldWithSession(SampleReceiveMaterialCustomField entity)
		{
			if (entity.FkSampleID == 0)
			{
				object obj = HttpContext.Current.Session["SampleMaterialCustomFieldList"];
				List<SampleReceiveMaterialCustomField> list = ((obj == null) ? GetNewSampleReceiveMaterialCustomFieldMaterialTypeID(entity.SampleReceiveList.FKMaterialTypeID.Value, entity.FkSampleID) : (obj as List<SampleReceiveMaterialCustomField>));
				SampleReceiveMaterialCustomField sampleReceiveMaterialCustomField = list.First((SampleReceiveMaterialCustomField x) => x.SampleReceiveCFLinkID == entity.SampleReceiveCFLinkID);
				sampleReceiveMaterialCustomField.Value = entity.Value;
				if (entity.FkSampleID == 0)
				{
					sampleReceiveMaterialCustomField.RowStatus = 1;
				}
				HttpContext.Current.Session["SampleMaterialCustomFieldList"] = list;
				return true;
			}
			entity.RowStatus = 2;
            var message = "";
			if (Update(entity, out  message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool UpdateToSession(SampleReceiveMaterialCustomField entity)
		{
			object obj = HttpContext.Current.Session["SampleMaterialCustomFieldList"];
			if (obj != null)
			{
				List<SampleReceiveMaterialCustomField> list = obj as List<SampleReceiveMaterialCustomField>;
				SampleReceiveMaterialCustomField sampleReceiveMaterialCustomField = list.First((SampleReceiveMaterialCustomField x) => x.SampleReceiveCFLinkID == entity.SampleReceiveCFLinkID);
				sampleReceiveMaterialCustomField.Value = entity.Value;
				sampleReceiveMaterialCustomField.FkCustomFieldID = entity.FkCustomFieldID;
				sampleReceiveMaterialCustomField.FkSampleID = entity.FkSampleID;
				if (entity.FkSampleID == 0)
				{
					sampleReceiveMaterialCustomField.RowStatus = 1;
				}
				else
				{
					sampleReceiveMaterialCustomField.RowStatus = 2;
				}
				HttpContext.Current.Session["SampleMaterialCustomFieldList"] = list;
			}
			return true;
		}

		public bool UpdateDetailsFromSession(long FkSampleID)
		{
			object obj = HttpContext.Current.Session["SampleMaterialCustomFieldList"];
			if (obj != null)
			{
				List<SampleReceiveMaterialCustomField> source = obj as List<SampleReceiveMaterialCustomField>;
				foreach (SampleReceiveMaterialCustomField item in source.Where((SampleReceiveMaterialCustomField x) => x.RowStatus == 1).ToList())
				{
					SampleReceiveMaterialCustomField sampleReceiveMaterialCustomField = new SampleReceiveMaterialCustomField();
					sampleReceiveMaterialCustomField.FkSampleID = FkSampleID;
					sampleReceiveMaterialCustomField.FkCustomFieldID = item.FkCustomFieldID;
					sampleReceiveMaterialCustomField.Value = item.Value;
					Insert(sampleReceiveMaterialCustomField);
				}
				foreach (SampleReceiveMaterialCustomField item2 in source.Where((SampleReceiveMaterialCustomField x) => x.RowStatus == 2).ToList())
				{
					SampleReceiveMaterialCustomField byID = GetByID(item2.SampleReceiveCFLinkID);
					Update(byID);
				}
			}
			HttpContext.Current.Session["SampleMaterialCustomFieldList"] = null;
			return true;
		}

		public List<SampleReceiveMaterialCustomField> GetBySampleId(long SampleID)
		{
			return ((IQueryable<SampleReceiveMaterialCustomField>)dbContext.SampleReceiveMaterialCustomField).Where((SampleReceiveMaterialCustomField x) => x.FkSampleID == SampleID).ToList();
		}
	}
}
