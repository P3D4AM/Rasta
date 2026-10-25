using System;

namespace CRM.Models;

public class mct_CRMspSelectTelegBotContact_Result
{
	public int? TelegBotContactId { get; set; }

	public long? ChatId { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string UserName { get; set; }

	public string ContactName { get; set; }

	public string PhoneNumber { get; set; }

	public string Type { get; set; }

	public string Title { get; set; }

	public int? CompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? CompanyPersonId { get; set; }

	public string PersonName { get; set; }

	public byte[] Picture { get; set; }

	public bool? IsActive { get; set; }

	public int? UserId { get; set; }

	public string RegisterUser { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? UnReadMessageCount { get; set; }

	public DateTime? LastMessageDate { get; set; }
}
