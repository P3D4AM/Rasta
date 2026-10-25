namespace Mobile.Models;

public class CrmInternalMessage_Lang
{
	public int CrmInternalMessageLangID { get; set; }

	public int InternalMessageID { get; set; }

	public int LanguageID { get; set; }

	public string msgSubject { get; set; }

	public string msgBody { get; set; }
}
