using System;

namespace CRM.Models;

public class CRMspCmsSelectHomePageSectionItemsBySectionId_Result
{
	public int HomePageSectionItemId { get; set; }

	public int HomePageSectionId { get; set; }

	public int? SectionItemPrdId { get; set; }

	public string SectionItemPrd { get; set; }

	public DateTime? SectionItemShowExpDate { get; set; }

	public bool? SectionItemIsActive { get; set; }

	public int? SectionItemOrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public int? SectionItemSysPartId { get; set; }

	public string SectionItemSysPartTitle { get; set; }

	public int? SectionItemObjId { get; set; }

	public string SectionItemObjName { get; set; }

	public int? SectionItemLinkType { get; set; }
}
