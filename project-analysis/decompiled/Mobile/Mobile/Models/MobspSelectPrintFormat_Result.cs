namespace Mobile.Models;

public class MobspSelectPrintFormat_Result
{
	public int Id { get; set; }

	public string Title { get; set; }

	public int PrintFormatTypeId { get; set; }

	public string PrintFormatType { get; set; }

	public string FileName { get; set; }

	public long? OrderView { get; set; }

	public string FileNameWeb { get; set; }
}
