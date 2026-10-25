using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsHomePageSectionItemsMetadata
{
	[Key]
	public int HomePageSectionItemId { get; set; }

	public int HomePageSectionId { get; set; }

	public int? SectionItemPrdId { get; set; }

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
}
