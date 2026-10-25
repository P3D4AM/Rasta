using System;

namespace Mobile.Models;

public class FoGetFormFieldMasterValuesTree
{
	public DateTime FDateTime { get; set; }

	public DateTime TDateTime { get; set; }

	public int FormId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public int? MasterObjectId { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
