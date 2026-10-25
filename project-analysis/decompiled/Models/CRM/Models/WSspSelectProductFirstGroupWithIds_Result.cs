using System;

namespace CRM.Models;

public class WSspSelectProductFirstGroupWithIds_Result
{
	public int PrdFirstGroupID { get; set; }

	public string FGCode { get; set; }

	public string FGName { get; set; }

	public string FGDescription { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string FGNameEn { get; set; }

	public Guid? GUId { get; set; }

	public bool? FGInactiveInSale { get; set; }

	public bool? FGInactiveInBuy { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? PrdGroupMustExistInPreOrder { get; set; }

	public int? FGLinkAccGroupId { get; set; }

	public string FGLinkAccGroupCode { get; set; }

	public string FGLinkAccGroupIdStr { get; set; }

	public int? FGOrderView { get; set; }

	public bool? FGSHPIsActive { get; set; }

	public string FGLinkAccGroupName { get; set; }

	public string TspFGIndentify { get; set; }

	public string TspFGName { get; set; }

	public DateTime? FGLinkAccFirstTransferDate { get; set; }

	public DateTime? FGLinkAccLastTransferDate { get; set; }

	public string FGLinkAccData { get; set; }

	public string FGSHPName { get; set; }

	public string FGSeoTitle { get; set; }

	public string FGSeoDescription { get; set; }

	public string FGSeoHttpEquiv { get; set; }

	public string FGSeoExpires { get; set; }

	public bool? FGSeoGoogleNotranslate { get; set; }

	public string FGSeoDistribution { get; set; }

	public string FGSeoRobots { get; set; }

	public string FGSeoRating { get; set; }

	public string FGSeoAuthor { get; set; }

	public bool? FGSeoIsUseSocialNetwork { get; set; }

	public int? FGSeoMobileOptimized { get; set; }

	public string FGSeoCopyright { get; set; }

	public bool? FGSeoUseDefault { get; set; }

	public string FGSeoKeywords { get; set; }

	public string FGSeoFAQ { get; set; }

	public bool? FGSeoIsActive { get; set; }
}
