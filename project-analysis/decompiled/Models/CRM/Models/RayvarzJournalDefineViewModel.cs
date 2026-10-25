using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzJournalDefineViewModel
{
	public long? BranchId { get; set; }

	public long? FiscalYearId { get; set; }

	public long? DocNo { get; set; }

	public string raySysId { get; set; }

	public long? systemVoucherItemTypeId { get; set; }

	public long? error { get; set; }

	public bool? allowChange { get; set; }

	public bool? senderFlag { get; set; }

	public string SenderKey { get; set; }

	public string traceKey { get; set; }

	public List<RayvarzJournalCashDefineViewModel> JournalCashs { get; set; }

	public string DocDate { get; set; }

	public long? CashJournalTypeId { get; set; }

	public long? DocGroupId { get; set; }

	public long? ReceiverId { get; set; }

	public string Remark { get; set; }

	public string RemarkEn { get; set; }

	public string LetterNo { get; set; }

	public string LetterDate { get; set; }

	public string Series { get; set; }

	public long? SystemVoucherItemSeries { get; set; }
}
