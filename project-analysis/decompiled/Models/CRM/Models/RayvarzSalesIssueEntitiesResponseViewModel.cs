using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzSalesIssueEntitiesResponseViewModel
{
	public long? salesJournalId { get; set; }

	public long? webDocTypeId { get; set; }

	public long? proFormaDocNo { get; set; }

	public long? issueDocNo { get; set; }

	public long? deliveryDocNo { get; set; }

	public long? salesFiscalYearId { get; set; }

	public long? docNo { get; set; }

	public string docDate { get; set; }

	public long? proFormaId { get; set; }

	public long? salesDocProduceTypeId { get; set; }

	public long? parentIssueDocId { get; set; }

	public long? parentFactorId { get; set; }

	public List<RayvarzSalesIssueItemEntitiesResponseViewModel> salesJournalItems { get; set; }

	public string rayGuid { get; set; }

	public bool? hasErrors { get; set; }
}
