using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using EntityState = System.Data.Entity.EntityState;

namespace BusinessLayer.Pages
{
	public class SampleReceiveMaterialTableCustomFieldDB : DBBase<SampleReceiveMaterialTableCustomField, List<SampleReceiveMaterialTableCustomField>, long>
	{
		public override List<SampleReceiveMaterialTableCustomField> GetAll()
		{
			return ((IEnumerable<SampleReceiveMaterialTableCustomField>)dbContext.SampleReceiveMaterialTableCustomField).ToList();
		}

		public override SampleReceiveMaterialTableCustomField GetByID(long id)
		{
			return ((IQueryable<SampleReceiveMaterialTableCustomField>)dbContext.SampleReceiveMaterialTableCustomField).FirstOrDefault((SampleReceiveMaterialTableCustomField j) => (long)j.SampleReceiveTCFLinkID == id);
		}

		public override bool Insert(SampleReceiveMaterialTableCustomField entity, out string message)
		{
			message = "";
			try
			{
				dbContext.SampleReceiveMaterialTableCustomField.Add(entity);
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

		public override bool Update(SampleReceiveMaterialTableCustomField entity, out string message)
		{
			message = "";
			try
			{
				SampleReceiveMaterialTableCustomField byID = GetByID(entity.SampleReceiveTCFLinkID);
				DbEntityEntry val = ((DbContext)dbContext).Entry<SampleReceiveMaterialTableCustomField>(byID);
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

		public override bool Delete(SampleReceiveMaterialTableCustomField entity, out string message)
		{
			message = "";
			try
			{
				SampleReceiveMaterialTableCustomField byID = GetByID(entity.SampleReceiveTCFLinkID);
				((DbContext)dbContext).Entry<SampleReceiveMaterialTableCustomField>(byID).State = (EntityState)8;;
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

		public bool Insert(SampleReceiveMaterialTableCustomField entity)
		{
			string message = "";
			if (Insert(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Update(SampleReceiveMaterialTableCustomField entity)
		{
			string message = "";
			if (Update(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public bool Delete(SampleReceiveMaterialTableCustomField entity)
		{
			string message = "";
			if (Delete(entity, out message))
			{
				return true;
			}
			throw new Exception(message);
		}

		public List<SampleReceiveMaterialTableCustomField> GetSampleReceiveMaterialCustomFieldMaterialTypeID(int FKMaterialTypeID, long SampleID)
		{
			return ((IQueryable<SampleReceiveMaterialTableCustomField>)dbContext.SampleReceiveMaterialTableCustomField).Where((SampleReceiveMaterialTableCustomField x) => x.FkSampleID == (long?)SampleID && x.MaterialTypesCustomFields.FKMaterialTypeID == FKMaterialTypeID && x.MaterialTypesCustomFields.DataType == 5).Distinct().ToList();
		}

		public List<SampleReceiveMaterialTableCustomField> GetNewSampleReceiveMaterialCustomFieldMaterialTypeID(int FKMaterialTypeID, long SampleID)
		{
			List<SampleReceiveMaterialTableCustomField> list = new List<SampleReceiveMaterialTableCustomField>();
			List<MaterialTypesCustomFields> list2 = ((IQueryable<MaterialTypesCustomFields>)dbContext.MaterialTypesCustomFields).Where((MaterialTypesCustomFields x) => x.FKMaterialTypeID == FKMaterialTypeID && x.DataType == 5).Distinct().ToList();
			foreach (MaterialTypesCustomFields item in list2)
			{
				SampleReceiveMaterialTableCustomField sampleReceiveMaterialTableCustomField = new SampleReceiveMaterialTableCustomField();
				sampleReceiveMaterialTableCustomField.FkCustomFieldID = item.CustomFieldID;
				sampleReceiveMaterialTableCustomField.FkSampleID = 0L;
				sampleReceiveMaterialTableCustomField.Value = "";
				sampleReceiveMaterialTableCustomField.SampleReceiveTCFLinkID = list.Count + 1;
				list.Add(sampleReceiveMaterialTableCustomField);
			}
			return list;
		}

		public List<SampleReceiveMaterialTableCustomField> GetTableFieldsByFKMaterialTypeIDWithSession(int FKMaterialTypeID, long SampleID)
		{
			List<SampleReceiveMaterialTableCustomField> list = GetSampleReceiveMaterialCustomFieldMaterialTypeID(FKMaterialTypeID, SampleID).ToList();
			if (list.Count > 0)
			{
				return list;
			}
			object obj = HttpContext.Current.Session["SampleMaterialTableCustomFieldList"];
			if (obj == null && FKMaterialTypeID == 0)
			{
				return new List<SampleReceiveMaterialTableCustomField>();
			}
			if (obj == null && FKMaterialTypeID != 0)
			{
				obj = GetNewSampleReceiveMaterialCustomFieldMaterialTypeID(FKMaterialTypeID, SampleID);
				HttpContext.Current.Session["SampleMaterialTableCustomFieldList"] = obj;
				return ((List<SampleReceiveMaterialTableCustomField>)obj).ToList();
			}
			if (obj != null)
			{
				return ((List<SampleReceiveMaterialTableCustomField>)obj).ToList();
			}
			return list = null;
		}

		public bool UpdateSampleMaterialCustomFieldWithSession(SampleReceiveMaterialTableCustomField entity)
		{
			if (entity.FkSampleID == 0)
			{
				object obj = HttpContext.Current.Session["SampleMaterialTableCustomFieldList"];
				List<SampleReceiveMaterialTableCustomField> list = ((obj == null) ? GetNewSampleReceiveMaterialCustomFieldMaterialTypeID(entity.SampleReceiveList.FKMaterialTypeID.Value, entity.FkSampleID.Value) : (obj as List<SampleReceiveMaterialTableCustomField>));
				SampleReceiveMaterialTableCustomField sampleReceiveMaterialTableCustomField = list.First((SampleReceiveMaterialTableCustomField x) => x.SampleReceiveTCFLinkID == entity.SampleReceiveTCFLinkID);
				sampleReceiveMaterialTableCustomField.Value = entity.Value;
				if (entity.FkSampleID == 0)
				{
					sampleReceiveMaterialTableCustomField.RowStatus = 1;
				}
				HttpContext.Current.Session["SampleMaterialTableCustomFieldList"] = list;
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

		public bool InsertDataWithSession(object entity)
		{
			return true;
		}

		public bool UpdateToSession(SampleReceiveMaterialTableCustomField entity)
		{
			object obj = HttpContext.Current.Session["SampleMaterialTableCustomFieldList"];
			if (obj != null)
			{
				List<SampleReceiveMaterialTableCustomField> list = obj as List<SampleReceiveMaterialTableCustomField>;
				SampleReceiveMaterialTableCustomField sampleReceiveMaterialTableCustomField = list.First((SampleReceiveMaterialTableCustomField x) => x.SampleReceiveTCFLinkID == entity.SampleReceiveTCFLinkID);
				sampleReceiveMaterialTableCustomField.Value = entity.Value;
				sampleReceiveMaterialTableCustomField.FkCustomFieldID = entity.FkCustomFieldID;
				sampleReceiveMaterialTableCustomField.FkSampleID = entity.FkSampleID;
				if (entity.FkSampleID == 0)
				{
					sampleReceiveMaterialTableCustomField.RowStatus = 1;
				}
				else
				{
					sampleReceiveMaterialTableCustomField.RowStatus = 2;
				}
				HttpContext.Current.Session["SampleMaterialTableCustomFieldList"] = list;
			}
			return true;
		}

		public bool UpdateDetailsFromSession(long FkSampleID)
		{
			object obj = HttpContext.Current.Session["SampleMaterialTableCustomFieldList"];
			if (obj != null)
			{
				List<SampleReceiveMaterialTableCustomField> source = obj as List<SampleReceiveMaterialTableCustomField>;
				foreach (SampleReceiveMaterialTableCustomField item in source.Where((SampleReceiveMaterialTableCustomField x) => x.RowStatus == 1).ToList())
				{
					SampleReceiveMaterialTableCustomField sampleReceiveMaterialTableCustomField = new SampleReceiveMaterialTableCustomField();
					sampleReceiveMaterialTableCustomField.FkSampleID = FkSampleID;
					sampleReceiveMaterialTableCustomField.FkCustomFieldID = item.FkCustomFieldID;
					sampleReceiveMaterialTableCustomField.Value = item.Value;
					sampleReceiveMaterialTableCustomField.RowIndex = item.RowIndex;
					Insert(sampleReceiveMaterialTableCustomField);
				}
				foreach (SampleReceiveMaterialTableCustomField item2 in source.Where((SampleReceiveMaterialTableCustomField x) => x.RowStatus == 2).ToList())
				{
					SampleReceiveMaterialTableCustomField byID = GetByID(item2.SampleReceiveTCFLinkID);
					byID.Value = item2.Value;
					Update(byID);
				}
				foreach (SampleReceiveMaterialTableCustomField item3 in source.Where((SampleReceiveMaterialTableCustomField x) => x.RowStatus == 3).ToList())
				{
					SampleReceiveMaterialTableCustomField byID2 = GetByID(item3.SampleReceiveTCFLinkID);
					Delete(byID2);
				}
			}
			HttpContext.Current.Session["SampleMaterialTableCustomFieldList"] = null;
			return true;
		}

		[DataObjectMethod(DataObjectMethodType.Select)]
		public DataTable GetTableCustomFieldDynamicTable(int FKMaterialTypeID, long SampleID)
		{
			List<SampleReceiveMaterialTableCustomField> tableFieldsByFKMaterialTypeIDWithSession = GetTableFieldsByFKMaterialTypeIDWithSession(FKMaterialTypeID, SampleID);
			List<int?> list = tableFieldsByFKMaterialTypeIDWithSession.Select((SampleReceiveMaterialTableCustomField x) => x.RowIndex).Distinct().ToList();
			List<int?> list2 = tableFieldsByFKMaterialTypeIDWithSession.Select((SampleReceiveMaterialTableCustomField x) => x.FkCustomFieldID).Distinct().ToList();
			DataTable dynamicDataTableStructure = GetDynamicDataTableStructure(tableFieldsByFKMaterialTypeIDWithSession);
			foreach (int? item in list)
			{
				int? num = item;
				if (num.HasValue)
				{
					DataRow dataRow = dynamicDataTableStructure.NewRow();
					dataRow["RowIndex"] = item;
					foreach (int? i in list2)
					{
						Func<SampleReceiveMaterialTableCustomField, bool> predicate = (SampleReceiveMaterialTableCustomField x) => x.FkCustomFieldID == i && x.RowIndex == item;
						string value = tableFieldsByFKMaterialTypeIDWithSession.SingleOrDefault(predicate).Value;
						int? num2 = i;
						dataRow[num2.ToString()] = value;
					}
					dynamicDataTableStructure.Rows.Add(dataRow);
				}
				HttpContext.Current.Session["TableCustomFielTable"] = dynamicDataTableStructure;
			}
			return dynamicDataTableStructure;
		}

		private DataTable GetDynamicDataTableStructure(List<SampleReceiveMaterialTableCustomField> SampleReceiveMaterialTableCustomField)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("RowIndex", typeof(int));
			foreach (SampleReceiveMaterialTableCustomField item in SampleReceiveMaterialTableCustomField)
			{
				if (!dataTable.Columns.Contains(item.FkCustomFieldID.ToString()))
				{
					dataTable.Columns.Add(item.FkCustomFieldID.ToString(), typeof(string));
				}
			}
			return dataTable;
		}

		public string getLastRowIndex()
		{
			string text = ((IQueryable<SampleReceiveMaterialTableCustomField>)dbContext.SampleReceiveMaterialTableCustomField).Max((SampleReceiveMaterialTableCustomField entity) => entity.RowIndex).ToString();
			if (text == "")
			{
				text = "1";
			}
			return text;
		}

		public List<SampleReceiveMaterialTableCustomField> GetByRowindex(int rowindex)
		{
			return ((IQueryable<SampleReceiveMaterialTableCustomField>)dbContext.SampleReceiveMaterialTableCustomField).Where((SampleReceiveMaterialTableCustomField j) => j.RowIndex == (int?)rowindex).ToList();
		}

		public List<SampleReceiveMaterialTableCustomField> GetBySampleId(long SampleID)
		{
			return ((IQueryable<SampleReceiveMaterialTableCustomField>)dbContext.SampleReceiveMaterialTableCustomField).Where((SampleReceiveMaterialTableCustomField x) => x.FkSampleID == (long?)SampleID).ToList();
		}
	}
}
