using System.Collections.Generic;
using System.Drawing;
using CRM.Resources;
using CRMIdeal.Classes.Common;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class ImportExcel
{
	public class DyForm
	{
		public class DyFormStaticFieldsViewModel
		{
			public bool? IsActive { get; set; }

			public int SysPartId { get; set; }

			public string SysPartIds { get; set; }

			public string SysPartName { get; set; }

			public string SysPartTitle { get; set; }

			public string FieldName { get; set; }

			public string FieldTitle { get; set; }

			public int FieldTypeId { get; set; }

			public string FieldType { get; set; }

			public string FieldTypeTitle { get; set; }

			public long? FieldMaxLen { get; set; }

			public bool? IsRequired { get; set; }
		}

		public static List<DyFormStaticFieldsViewModel> GetDyFormStaticFields()
		{
			List<DyFormStaticFieldsViewModel> list = new List<DyFormStaticFieldsViewModel>();
			if (Center.HaveModule)
			{
				list.Add(new DyFormStaticFieldsViewModel
				{
					SysPartId = -1,
					SysPartIds = "-1",
					SysPartName = "",
					SysPartTitle = "",
					FieldName = "CenterCode",
					FieldTitle = Labels.CenterCode,
					FieldTypeId = 1,
					FieldType = "text",
					FieldTypeTitle = Labels.Text,
					IsRequired = true
				});
			}
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 10,
				SysPartIds = "10",
				SysPartName = "Cmp",
				SysPartTitle = Labels.Company,
				FieldName = "cmpCode",
				FieldTitle = Labels.DyFormImportExcelCmpCode,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 10,
				SysPartIds = "10",
				SysPartName = "Cmp",
				SysPartTitle = Labels.Company,
				FieldName = "cmpNumber",
				FieldTitle = Labels.DyFormImportExcelCmpNumber,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 11,
				SysPartIds = "10,11",
				SysPartName = "Prs",
				SysPartTitle = Labels.CompanyPerson,
				FieldName = "prsMobile",
				FieldTitle = Labels.DyFormImportExcelPrsMobile,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 11,
				SysPartIds = "10,11",
				SysPartName = "Prs",
				SysPartTitle = Labels.prsNationalCode,
				FieldName = "prsNationalCode",
				FieldTitle = Labels.DyFormImportExcelPrsNationalCode,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 12,
				SysPartIds = "10,12",
				SysPartName = "Prj",
				SysPartTitle = Labels.prjTitle,
				FieldName = "prjTitle",
				FieldTitle = Labels.DyFormImportExcelPrjTitle,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 12,
				SysPartIds = "10,12",
				SysPartName = "Prj",
				SysPartTitle = Labels.prjPostFix,
				FieldName = "prjPostFix",
				FieldTitle = Labels.DyFormImportExcelPrjPostFix,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 13,
				SysPartIds = "10,11,12,13",
				SysPartName = "Cnvs",
				SysPartTitle = Labels.Conversation,
				FieldName = "ConversationID",
				FieldTitle = Labels.DyFormImportExcelConversationID,
				FieldTypeId = 2,
				FieldType = "numeric",
				FieldTypeTitle = Labels.Numeric
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 20,
				SysPartIds = "10,11,12,20",
				SysPartName = "Pord",
				SysPartTitle = Labels.PreOrder,
				FieldName = "pordNumber",
				FieldTitle = Labels.DyFormImportExcelPordNumber,
				FieldTypeId = 2,
				FieldType = "numeric",
				FieldTypeTitle = Labels.Numeric
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 30,
				SysPartIds = "10,11,12,30",
				SysPartName = "Ord",
				SysPartTitle = Labels.Order,
				FieldName = "ordNumber",
				FieldTitle = Labels.DyFormImportExcelOrdNumber,
				FieldTypeId = 2,
				FieldType = "numeric",
				FieldTypeTitle = Labels.Numeric
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 40,
				SysPartIds = "10,11,12,40",
				SysPartName = "Bord",
				SysPartTitle = Labels.BuyOrder,
				FieldName = "bordNumber",
				FieldTitle = Labels.DyFormImportExcelBordNumber,
				FieldTypeId = 2,
				FieldType = "numeric",
				FieldTypeTitle = Labels.Numeric
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 45,
				SysPartIds = "10,11,12,45",
				SysPartName = "stsup",
				SysPartTitle = Labels.StockSupply,
				FieldName = "stsupNumber",
				FieldTitle = Labels.DyFormImportExcelStsupNumber,
				FieldTypeId = 2,
				FieldType = "numeric",
				FieldTypeTitle = Labels.Numeric
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 50,
				SysPartIds = "10,11,12,50",
				SysPartName = "SLetter",
				SysPartTitle = Labels.lblSendLetter,
				FieldName = "LetterNumber",
				FieldTitle = Labels.DyFormImportExcelLetterNumber,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 51,
				SysPartIds = "10,11,12,51",
				SysPartName = "RLetter",
				SysPartTitle = Labels.lblReceiveletter,
				FieldName = "LetterNumber",
				FieldTitle = Labels.DyFormImportExcelLetterNumber,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 60,
				SysPartIds = "10,11,12,60",
				SysPartName = "Doc",
				SysPartTitle = Labels.lblDoc,
				FieldName = "DocNumber",
				FieldTitle = Labels.DyFormImportExcelDocNumber,
				FieldTypeId = 2,
				FieldType = "numeric",
				FieldTypeTitle = Labels.Numeric
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 61,
				SysPartIds = "10,11,12,61",
				SysPartName = "Draft",
				SysPartTitle = Labels.lblDraft,
				FieldName = "DocNumber",
				FieldTitle = Labels.DyFormImportExcelDraftNumber,
				FieldTypeId = 2,
				FieldType = "numeric",
				FieldTypeTitle = Labels.Numeric
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 62,
				SysPartIds = "10,11,12,62",
				SysPartName = "Movement",
				SysPartTitle = Labels.lblMoveMent,
				FieldName = "DocNumber",
				FieldTitle = Labels.DyFormImportExcelMovementNumber,
				FieldTypeId = 2,
				FieldType = "numeric",
				FieldTypeTitle = Labels.Numeric
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 70,
				SysPartIds = "70",
				SysPartName = "Prd",
				SysPartTitle = Labels.Product,
				FieldName = "PrdCode",
				FieldTitle = Labels.DyFormImportExcelPrdCode,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 105,
				SysPartIds = "10,105",
				SysPartName = "CmsPage",
				SysPartTitle = Labels.CMS,
				FieldName = "PageName",
				FieldTitle = Labels.DyFormImportExcelPageName,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 140,
				SysPartIds = "140",
				SysPartName = "User",
				SysPartTitle = Labels.User,
				FieldName = "UserName",
				FieldTitle = Labels.UserName,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 140,
				SysPartIds = "140",
				SysPartName = "User",
				SysPartTitle = Labels.User,
				FieldName = "UserMobile",
				FieldTitle = Labels.Mobile,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			list.Add(new DyFormStaticFieldsViewModel
			{
				SysPartId = 140,
				SysPartIds = "140",
				SysPartName = "User",
				SysPartTitle = Labels.User,
				FieldName = "UserPersCode",
				FieldTitle = Labels.PersCode,
				FieldTypeId = 1,
				FieldType = "text",
				FieldTypeTitle = Labels.Text
			});
			return list;
		}

		public static string GetDyFormStaticFields(bool? asJson)
		{
			string result = "";
			if (asJson.GetValueOrDefault())
			{
				result = JsonConvert.SerializeObject(GetDyFormStaticFields());
			}
			return result;
		}
	}

	public static Color _ImportExcel_Head_BackColor = Public.HexToColorObject("0272a6");

	public static Color _ImportExcel_Head_ForeColor = Public.HexToColorObject("ffffff");

	public static Color _ImportExcel_Head_BackColor_Required = Public.HexToColorObject("cd4747");
}
