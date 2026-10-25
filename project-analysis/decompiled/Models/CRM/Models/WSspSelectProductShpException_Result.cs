using System;

namespace CRM.Models;

public class WSspSelectProductShpException_Result
{
	public int ProductShpExceptionID { get; set; }

	public int? PrdShpExCId { get; set; }

	public string PrdShpExCenterName { get; set; }

	public int? PrdShpExPrdId { get; set; }

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

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? FPId { get; set; }

	public short? Month1 { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string PrdShpExStockManageType { get; set; }
}
