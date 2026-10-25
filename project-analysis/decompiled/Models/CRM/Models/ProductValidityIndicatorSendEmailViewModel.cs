using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CRM.Models;

public class ProductValidityIndicatorSendEmailViewModel
{
	public int EmailUserInfoId { get; set; }

	public int RecieverType { get; set; }

	public string Subject { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string TextBody { get; set; }

	public string OprJson { get; set; }
}
