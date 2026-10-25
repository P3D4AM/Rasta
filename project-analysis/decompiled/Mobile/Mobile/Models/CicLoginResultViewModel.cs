namespace Mobile.Models;

public class CicLoginResultViewModel
{
	public string token { get; set; }

	public string FullName { get; set; }

	public int UserId { get; set; }

	public int RollId { get; set; }

	public string RollName { get; set; }

	public string MobImeiCode { get; set; }

	public bool? CallerIdDeActiveFromMobile { get; set; }
}
