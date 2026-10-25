using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintDyFormRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public List<CRMspDyPrintFormViewModel> NotUsed_ListPrintDyForm { get; set; }

	public List<FieldValueItemViewModel> NotUsed_ListFieldValue { get; set; }

	public List<CRMspDyPrintFormDetails_Result> NotUsed_ListPrintFormDetails { get; set; }

	public byte[] SignatureFirstUser { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureChekerUser { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public List<CRMspDyPrintFormFieldValues_Result> NotUsed_ListPrintFormFieldValues { get; set; }

	public List<CRMspDyPrintFormFieldMasterValueDetails_Result> NotUsed_ListPrintFormFieldMasterValueDetails { get; set; }

	public List<WSspRpt_PrintVerificationRequestDetails_Result> NotUsed_ListPrintDyFormVerificationRequestDetails { get; set; }

	public List<WSspRpt_PrintPreOrder_Result> ListPrintPreOrder { get; set; }

	public List<WSspSelectPreOrderItemSpecificationByItemId_Result> ListPrintPreOrderItemSpecification { get; set; }

	public List<WSspRpt_PrintPreOrderPayments_Result> ListPrintPreOrderPayments { get; set; }

	public byte[] PreOrderSignatureFirstUser { get; set; }

	public byte[] PreOrderSignatureLastEditUser { get; set; }

	public byte[] PreOrderSignatureReferUser { get; set; }

	public byte[] PreOrderSignatureVerifierUser { get; set; }

	public WSspRpt_PrintPreOrderById_Result PrintPreOrder { get; set; }

	public List<PordLinkAccDataViewModel> NotUsed_ListLinkAccData { get; set; }

	public List<PayLinkAccDataViewModel> NotUsed_ListPayLinkAccData { get; set; }

	public bool? PordActNotShowFinancialInfo { get; set; }
}
