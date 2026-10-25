using System;

namespace CRM.Models;

public class CRMspSelectCenterWithId_Result
{
	public int CenterID { get; set; }

	public string CenterName { get; set; }

	public string CenterName_Lang { get; set; }

	public string CenterDesc { get; set; }

	public string CenterDesc_Lang { get; set; }

	public bool? CenterInActive { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public byte[] CenterPicture { get; set; }

	public int? ParentId { get; set; }

	public string ParentCenterName { get; set; }

	public string CenterCode { get; set; }

	public string CenterSeoTitle { get; set; }

	public string CenterSeoTitle_Lang { get; set; }

	public string CenterSeoDescription { get; set; }

	public string CenterSeoDescription_Lang { get; set; }

	public string CenterSeoHttpEquiv { get; set; }

	public string CenterSeoExpires { get; set; }

	public bool? CenterSeoGoogleNotranslate { get; set; }

	public string CenterSeoDistribution { get; set; }

	public string CenterSeoRobots { get; set; }

	public string CenterSeoRating { get; set; }

	public string CenterSeoAuthor { get; set; }

	public string CenterSeoAuthor_Lang { get; set; }

	public bool? CenterSeoIsUseSocialNetwork { get; set; }

	public int? CenterSeoMobileOptimized { get; set; }

	public string CenterSeoCopyright { get; set; }

	public string CenterSeoCopyright_Lang { get; set; }

	public bool? CenterSeoUseDefault { get; set; }

	public string CenterSeoKeywords { get; set; }

	public string CenterSeoKeywords_Lang { get; set; }

	public string CenterSeoFAQ { get; set; }

	public string CenterSeoFAQ_Lang { get; set; }

	public bool? CenterSeoIsActive { get; set; }
}
