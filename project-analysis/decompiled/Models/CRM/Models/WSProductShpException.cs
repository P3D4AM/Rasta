using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductShpExceptionMetadata))]
public class WSProductShpException
{
	public int ProductShpExceptionID { get; set; }

	public int PrdShpExCId { get; set; }

	public int PrdShpExPrdId { get; set; }

	public bool? PrdShpExIsActive { get; set; }

	public string PrdShpExTitle { get; set; }

	public string PrdShpExCode { get; set; }

	public string PrdShpExModel { get; set; }

	public string PrdShpExDescription { get; set; }

	public string PrdShpExDescriptionII { get; set; }

	public int? PrdShpExStockManageTypeId { get; set; }

	public double? PrdShpExStockManualyCount { get; set; }

	public bool? PrdShpExHiddenPriceInNoStock { get; set; }

	public bool? PrdShpExSelfSupplier { get; set; }

	public int? PrdShpExOtherSupplierId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public bool? PrdShpExQtyFromTracing { get; set; }

	public bool? PrdShpExShowLinkedPrd { get; set; }

	public string PrdShpExSeoTitle { get; set; }

	public string PrdShpExSeoDescription { get; set; }

	public string PrdShpExSeoHttpEquiv { get; set; }

	public string PrdShpExSeoExpires { get; set; }

	public bool? PrdShpExSeoGoogleNotranslate { get; set; }

	public string PrdShpExSeoDistribution { get; set; }

	public string PrdShpExSeoRobots { get; set; }

	public string PrdShpExSeoRating { get; set; }

	public string PrdShpExSeoAuthor { get; set; }

	public bool? PrdShpExSeoIsUseSocialNetwork { get; set; }

	public int? PrdShpExSeoMobileOptimized { get; set; }

	public string PrdShpExSeoCopyright { get; set; }

	public bool? PrdShpExSeoUseDefault { get; set; }

	public string PrdShpExSeoKeywords { get; set; }

	public string PrdShpExSeoFAQ { get; set; }

	public bool? PrdShpExSeoIsActive { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSProductShpException_Lang> WSProductShpException_Lang { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductShpException()
	{
		WSProductShpException_Lang = (ICollection<WSProductShpException_Lang>)new HashSet<WSProductShpException_Lang>();
	}
}
