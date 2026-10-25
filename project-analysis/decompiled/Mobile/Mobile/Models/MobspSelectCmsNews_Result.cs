using System;

namespace Mobile.Models;

public class MobspSelectCmsNews_Result
{
	public int NewsId { get; set; }

	public int NewsGroupId { get; set; }

	public string NewsGroup { get; set; }

	public string HeadLine { get; set; }

	public string Title { get; set; }

	public string NewsSummery { get; set; }

	public DateTime PublishDateTime { get; set; }

	public bool? IsTopNews { get; set; }

	public string NewsBody { get; set; }
}
