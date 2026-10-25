using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CRM.Models;

public class SignatureManagerViewNodel
{
	public string Title { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string Body { get; set; }
}
