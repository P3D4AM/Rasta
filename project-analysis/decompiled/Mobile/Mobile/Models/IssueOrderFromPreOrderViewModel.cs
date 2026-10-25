namespace Mobile.Models;

public class IssueOrderFromPreOrderViewModel
{
	public int PreOrderId { get; set; }

	public string OrdDate { get; set; }

	public int OrdOprId { get; set; }

	public int OrdPrintFormatId { get; set; }

	public int OrderReferUserId { get; set; }

	public string OrdNote { get; set; }

	public int OrdSettlementTypeId { get; set; }

	public int OrdDefaultSettingId { get; set; }

	public int? LanguageId { get; set; }

	public string OrdNoteLang { get; set; }

	public string PordItemListJson { get; set; }

	public int? OrdProjectId { get; set; }

	public bool? IsTransferFreePay { get; set; }

	public bool? IsTransferFreeComm { get; set; }

	public bool? TransferPreOrderFileToOrder { get; set; }

	public string SelectedFilesDirectoryTypes { get; set; }

	public bool AddPrdValidity { get; set; }

	public string AddPrdValidityPrjTitle { get; set; }

	public int OrdCompanyPersonId { get; set; }

	public int OrdIssueSettingByPrdId { get; set; }

	public int OrdIssueIndexedByPrdId { get; set; }

	public int? CenterId { get; set; }

	public string ValDetails { get; set; }
}
