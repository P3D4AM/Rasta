using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class BankMobCallbackViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "lblTrackingCode")]
	public string TrackingNumber { get; set; }

	public string ErrorMessage { get; set; }
}
