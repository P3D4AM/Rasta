using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductSecondGroupMetadata))]
public class WSProductSecondGroup
{
	public int PrdSecondGroupID { get; set; }

	public int FirstGroupId { get; set; }

	public string SGCode { get; set; }

	public string SGName { get; set; }

	public string SGDescription { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string SGNameEn { get; set; }

	public Guid? GUId { get; set; }

	public bool? SGInactiveInSale { get; set; }

	public bool? SGInactiveInBuy { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? SGLinkAccGroupId { get; set; }

	public string SGLinkAccGroupCode { get; set; }

	public string SGLinkAccGroupIdStr { get; set; }

	public int? SGOrderView { get; set; }

	public bool? SGSHPIsActive { get; set; }

	public string SGLinkAccGroupName { get; set; }

	public string SGLinkAccGroups { get; set; }

	public string TspSGIndentify { get; set; }

	public string TspSGName { get; set; }

	public string SGCompanyGroupIIRateJson { get; set; }

	public DateTime? SGLinkAccFirstTransferDate { get; set; }

	public DateTime? SGLinkAccLastTransferDate { get; set; }

	public string SGLinkAccData { get; set; }

	public string SGSHPName { get; set; }

	public string SGSeoTitle { get; set; }

	public string SGSeoDescription { get; set; }

	public string SGSeoHttpEquiv { get; set; }

	public string SGSeoExpires { get; set; }

	public bool? SGSeoGoogleNotranslate { get; set; }

	public string SGSeoDistribution { get; set; }

	public string SGSeoRobots { get; set; }

	public string SGSeoRating { get; set; }

	public string SGSeoAuthor { get; set; }

	public bool? SGSeoIsUseSocialNetwork { get; set; }

	public int? SGSeoMobileOptimized { get; set; }

	public string SGSeoCopyright { get; set; }

	public bool? SGSeoUseDefault { get; set; }

	public string SGSeoKeywords { get; set; }

	public string SGSeoFAQ { get; set; }

	public bool? SGSeoIsActive { get; set; }

	public virtual ICollection<CrmCmsMenus> CrmCmsMenus { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSCostSheetProducts> WSCostSheetProducts { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSProductFirstGroup WSProductFirstGroup { get; set; }

	public virtual ICollection<WSProductSecondGroup_Lang> WSProductSecondGroup_Lang { get; set; }

	public virtual ICollection<WSProductsUserDiscount> WSProductsUserDiscount { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductSecondGroup()
	{
		CrmCmsMenus = (ICollection<CrmCmsMenus>)new HashSet<CrmCmsMenus>();
		WSCostSheetProducts = (ICollection<WSCostSheetProducts>)new HashSet<WSCostSheetProducts>();
		WSProductSecondGroup_Lang = (ICollection<WSProductSecondGroup_Lang>)new HashSet<WSProductSecondGroup_Lang>();
		WSProductsUserDiscount = (ICollection<WSProductsUserDiscount>)new HashSet<WSProductsUserDiscount>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSProductImportFromExcel = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
	}
}
