using System;

namespace CRM.Models;

public class CRMspCmsSelectHomePageSections_Result
{
	public int HomePageSectionId { get; set; }

	public string SectionTitle { get; set; }

	public string SectionHeader { get; set; }

	public string SectionHeaderStyle { get; set; }

	public string SectionHeaderScript { get; set; }

	public string SectionHeaderPosition { get; set; }

	public string SectionBgColor { get; set; }

	public bool? SectionIsActive { get; set; }

	public int? SectionOrderView { get; set; }

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
}
