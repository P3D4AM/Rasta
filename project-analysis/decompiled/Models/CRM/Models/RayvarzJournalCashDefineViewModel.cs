using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzJournalCashDefineViewModel
{
	public long? BranchId { get; set; }

	public long? FiscalYearId { get; set; }

	public long? DocNo { get; set; }

	public long? DocRow { get; set; }

	public long? CashTypeId { get; set; }

	public long? FundId { get; set; }

	public long? CashCenterId { get; set; }

	public long? ChequeBookId { get; set; }

	public string CashNo { get; set; }

	public string CashDate { get; set; }

	public string ChequePayee { get; set; }

	public long? BankId { get; set; }

	public string BankAccountNo { get; set; }

	public string BankAccountOwner { get; set; }

	public string BankBranchId { get; set; }

	public string PersonId { get; set; }

	public List<RayvarzJournalSubjectDefineViewModel> JournalSubjects { get; set; }
}
