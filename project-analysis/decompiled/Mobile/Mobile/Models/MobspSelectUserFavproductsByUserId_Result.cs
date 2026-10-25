namespace Mobile.Models;

public class MobspSelectUserFavproductsByUserId_Result
{
	public int UserFavproductId { get; set; }

	public string FavprdTitle { get; set; }

	public string FavprdDesc { get; set; }

	public bool? FavprdInActive { get; set; }

	public long? OrderView { get; set; }
}
