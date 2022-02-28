using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Pages;
using DevExpress.Web;

namespace PioneerLab.Pages
{
	// Token: 0x02000014 RID: 20
	public class Attachments : Page
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00002776 File Offset: 0x00000976
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00002788 File Offset: 0x00000988
		public int TransactionTypeID
		{
			get
			{
				return int.Parse(this.lblTransTypeID.Text);
			}
			set
			{
				this.lblTransTypeID.Text = value.ToString();
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x000073E0 File Offset: 0x000055E0
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x0000279C File Offset: 0x0000099C
		public long TransactionID
		{
			get
			{
				if (this.Session[this._attachTransIDSessionString] != null)
				{
					return long.Parse(this.Session[this._attachTransIDSessionString].ToString());
				}
				return long.Parse(this.lblTransID.Text);
			}
			set
			{
				this.Session[this._attachTransIDSessionString] = value.ToString();
				this.lblTransID.Text = value.ToString();
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x000027C8 File Offset: 0x000009C8
		// (set) Token: 0x060000AA RID: 170 RVA: 0x000027D5 File Offset: 0x000009D5
		public string UploadDirectory
		{
			get
			{
				return this.lblUploadDirectory.Text;
			}
			set
			{
				this.lblUploadDirectory.Text = value;
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000742C File Offset: 0x0000562C
		protected void Page_Load(object sender, EventArgs e)
		{
			AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
			if (!base.IsPostBack)
			{
				this.Session[this._fileListSessionString] = null;
				this.Session[this._unSavedFileListSessionString] = null;
				this.lblTransTypeID.Text = base.Request["TransTypeID"];
				this.TransactionID = long.Parse(base.Request["TransID"].ToString());
				this.txtKeywords.Text = attachedFilesDB.GetKeywords(this.TransactionID, this.TransactionTypeID);
				this.gdvfiles.DataBind();
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000074D4 File Offset: 0x000056D4
		protected void btnAttachmentSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.Session[this._fileListSessionString] != null)
				{
					foreach (AttachedFiles attachedFiles in ((List<AttachedFiles>)this.Session[this._fileListSessionString]))
					{
						attachedFiles.Keywords = this.txtKeywords.Text;
					}
				}
				string text = this.SaveAttachments();
				if (text == "")
				{
					this.divmsg.Attributes["class"] = "alert alert-success";
					this.LblError.ForeColor = Color.Green;
					this.LblError.Text = "Attachments saved successfully!";
					base.Response.Write("<script language='javascript'> {window.close();}</script>");
				}
				else
				{
					this.divmsg.Attributes["class"] = "alert alert-danger";
					this.LblError.ForeColor = Color.Red;
					this.LblError.Text = text;
				}
			}
			catch (Exception ex)
			{
				this.divmsg.Attributes["class"] = "alert alert-danger";
				this.LblError.ForeColor = Color.Red;
				this.LblError.Text = ex.Message;
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00002071 File Offset: 0x00000271
		protected void btnAttachmentClose_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000027E3 File Offset: 0x000009E3
		protected void AttachmentPopup_Load(object sender, EventArgs e)
		{
			this.gdvfiles.DataBind();
			this.gdvfiles.ClientVisible = (this.gdvfiles.VisibleRowCount != 0);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00007638 File Offset: 0x00005838
		protected void UploadControl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
		{
			string fileName = e.UploadedFile.FileName;
			string text = (e.UploadedFile.ContentLength / 1024L).ToString() + " KB";
			byte[] fileBytes = e.UploadedFile.FileBytes;
			AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
			attachedFilesDB.Insert(new AttachedFiles
			{
				FileContent = fileBytes,
				FileExtention = e.UploadedFile.ContentType,
				FileName = fileName,
				FileSize = text,
				FileUrl = "",
				FKTransID = long.Parse(base.Request["TransID"].ToString()),
				FKTransTypeID = int.Parse(base.Request["TransTypeID"].ToString()),
				IsUrl = false,
				Keywords = ""
			});
			this.gdvfiles.DataBind();
			e.CallbackData = fileName + "|" + text;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000280C File Offset: 0x00000A0C
		protected void gdvfiles_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
		{
			(sender as ASPxGridView).DataBind();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00007744 File Offset: 0x00005944
		protected void gdvfiles_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
		{
            if (e.CommandArgs.CommandName == "download")
            {
                AttachedFiles attachedFiles = new AttachedFiles();
                int num = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
                object commandSource = e.CommandSource;
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                attachedFiles = attachedFilesDB.GetByID((long)num);
                if (attachedFiles != null)
                {
                    string fileUrl = attachedFiles.FileUrl;
                    string str = attachedFiles.FileName.Replace(" ", "_");
                    byte[] fileContent = attachedFiles.FileContent;
                    base.Response.Clear();
                    base.Response.ClearHeaders();
                    base.Response.AddHeader("Content-Type", "Application/octet-stream");
                    base.Response.AddHeader("Content-Length", fileContent.Length.ToString());
                    base.Response.AddHeader("Content-Disposition", "attachment;   filename=" + str);
                    base.Response.BinaryWrite(fileContent);
                    base.Response.Flush();
                    base.Response.End();
                }
            }
            else if (e.CommandArgs.CommandName == "delete")
            {
                AttachedFiles attachedFiles = new AttachedFiles();
                int num = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
                object commandSource = e.CommandSource;
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                attachedFiles = attachedFilesDB.GetByID((long)num);
                if (attachedFiles != null)
                {
                    bool result = attachedFilesDB.Delete(attachedFiles);
                    this.ClearSessions();
                    this.gdvfiles.DataBind();
                }
            }
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00007850 File Offset: 0x00005A50
		public List<AttachedFiles> GetAttachmentList()
		{
			List<AttachedFiles> result = new List<AttachedFiles>();
			if (this.Session[this._fileListSessionString] != null)
			{
				result = (List<AttachedFiles>)this.Session[this._fileListSessionString];
			}
			return result;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00007890 File Offset: 0x00005A90
		public string SaveAttachments()
		{
			AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
			string result = "";
			if (this.TransactionID != 0L && this.TransactionTypeID != 0)
			{
				List<AttachedFiles> attachmentList = this.GetAttachmentList();
				if (attachmentList.Count > 0)
				{
					result = attachedFilesDB.SaveAttachments(attachmentList, this.TransactionID);
					this.ClearSessions();
				}
			}
			else
			{
				result = "Set 'TransactionID' before calling 'SaveAttachments()' Method.";
			}
			return result;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000078E8 File Offset: 0x00005AE8
		public string DeleteAllAttachments()
		{
			AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
			string result;
			if (this.TransactionID != 0L && this.TransactionTypeID != 0)
			{
				result = attachedFilesDB.DeleteAll(this.TransactionID, this.TransactionTypeID);
			}
			else
			{
				result = "Set 'TransactionID' before calling 'DeleteAllAttachments()' Method.";
			}
			return result;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00007930 File Offset: 0x00005B30
		private void AddToGrid(string name, string sizeText)
		{
			object obj = this.Session[this._unSavedFileListSessionString];
			if (this.Session[this._fileListSessionString] != null)
			{
				string a = "";
				List<AttachedFiles> list = (List<AttachedFiles>)this.Session[this._fileListSessionString];
				AttachedFiles attachedFiles = new AttachedFiles();
				attachedFiles.FileName = name;
				attachedFiles.FileSize = sizeText;
				attachedFiles.FKTransTypeID = this.TransactionTypeID;
				attachedFiles.FKTransID = this.TransactionID;
				attachedFiles.Keywords = this.txtKeywords.Text;
				if (this.TransactionID == 0L)
				{
					attachedFiles.FileID = (long)(list.Count + 1);
				}
				else
				{
					AttachedFiles attachedFiles2 = attachedFiles;
					long fileID;
					if (list.Count <= 0)
					{
						fileID = 1L;
					}
					else
					{
						fileID = list.Max((AttachedFiles x) => x.FileID) + 1L;
					}
					attachedFiles2.FileID = fileID;
				}
				if (a == "")
				{
					list.Add(attachedFiles);
				}
				if (obj == null)
				{
					obj = new List<AttachedFiles>();
				}
				((List<AttachedFiles>)obj).Add(attachedFiles);
				this.Session[this._unSavedFileListSessionString] = obj;
			}
			this.gdvfiles.DataBind();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00007A5C File Offset: 0x00005C5C
		private void UpdateKeywords(List<AttachedFiles> files)
		{
			AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
			string text = "";
			foreach (AttachedFiles attachedFiles in files)
			{
				attachedFiles.Keywords = this.txtKeywords.Text;
				if (this.TransactionID != 0L)
				{
					attachedFilesDB.Update(attachedFiles, out text);
				}
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00007AD4 File Offset: 0x00005CD4
		private void InsertItems(List<AttachedFiles> unsavedfiles)
		{
			AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
			string text = "";
			foreach (AttachedFiles entity in unsavedfiles)
			{
				if (this.TransactionID != 0L)
				{
					attachedFilesDB.Insert(entity, out text);
				}
			}
			this.Session[this._unSavedFileListSessionString] = null;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00007B50 File Offset: 0x00005D50
		private void RemoveUnsavedItems()
		{
			object obj = this.Session[this._unSavedFileListSessionString];
			object obj2 = this.Session[this._fileListSessionString];
			if (obj != null)
			{
				using (List<AttachedFiles>.Enumerator enumerator = ((List<AttachedFiles>)obj).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						AttachedFiles file = enumerator.Current;
						((List<AttachedFiles>)obj2).Remove(((List<AttachedFiles>)obj2).FirstOrDefault((AttachedFiles x) => x.FileID == file.FileID));
					}
				}
			}
			this.Session[this._unSavedFileListSessionString] = null;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00002819 File Offset: 0x00000A19
		public void ClearSessions()
		{
			this.Session[this._fileListSessionString] = null;
			this.Session[this._attachTransIDSessionString] = null;
			this.Session[this._unSavedFileListSessionString] = null;
		}

		// Token: 0x04000083 RID: 131
		private string _fileListSessionString = "_appattachfiles";

		// Token: 0x04000084 RID: 132
		private string _attachTransIDSessionString = "_appattachTransID";

		// Token: 0x04000085 RID: 133
		private string _unSavedFileListSessionString = "_appattachUnsavedfiles";

		// Token: 0x04000086 RID: 134
		protected HtmlForm form1;

		// Token: 0x04000087 RID: 135
		protected ASPxLabel lblTransID;

		// Token: 0x04000088 RID: 136
		protected ASPxLabel lblTransTypeID;

		// Token: 0x04000089 RID: 137
		protected ASPxLabel lblUploadDirectory;

		// Token: 0x0400008A RID: 138
		protected HtmlGenericControl divmsg;

		// Token: 0x0400008B RID: 139
		protected ASPxLabel LblError;

		// Token: 0x0400008C RID: 140
		protected ASPxLabel lblKeywordsText;

		// Token: 0x0400008D RID: 141
		protected ASPxMemo txtKeywords;

		// Token: 0x0400008E RID: 142
		protected ASPxUploadControl UploadControl;

		// Token: 0x0400008F RID: 143
		protected ASPxLabel AllowedFileExtensionsLabel;

		// Token: 0x04000090 RID: 144
		protected ASPxLabel MaxFileSizeLabel;

		// Token: 0x04000091 RID: 145
		protected ASPxRoundPanel FilContents;

		// Token: 0x04000092 RID: 146
		protected ASPxGridView gdvfiles;

		// Token: 0x04000093 RID: 147
		protected ASPxButton btnAttachmentSave;

		// Token: 0x04000094 RID: 148
		protected ASPxButton btnAttachmentClose;

		// Token: 0x04000095 RID: 149
		protected ObjectDataSource TransactionAttachmentsDS;
	}
}
