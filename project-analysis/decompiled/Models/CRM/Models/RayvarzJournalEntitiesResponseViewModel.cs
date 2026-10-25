namespace CRM.Models;

public class RayvarzJournalEntitiesResponseViewModel
{
	public string entityId { get; set; }

	public bool? isSystemVoucherItemSaved { get; set; }

	public bool? isJournalSaved { get; set; }

	public string raySysId { get; set; }

	public long? branchId { get; set; }

	public long? fiscalYearId { get; set; }

	public long? systemVoucherItemTypeId { get; set; }

	public long? systemVoucherItemNo { get; set; }

	public long? journalNo { get; set; }

	public string journalToken { get; set; }

	public string systemVoucherItemToken { get; set; }

	public string senderKey { get; set; }
}
