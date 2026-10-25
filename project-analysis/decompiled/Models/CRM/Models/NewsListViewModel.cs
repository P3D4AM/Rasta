namespace CRM.Models;

public class NewsListViewModel
{
	public int newsCurrentId { get; set; }

	public string fromDate { get; set; }

	public string toDate { get; set; }

	public bool? isNewsTop { get; set; }

	public int? newsGroupId { get; set; }

	public int? newsId { get; set; }
}
