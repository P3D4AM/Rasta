namespace Mobile.Models;

public class MobspSelectProductPicture_Result
{
	public int PrdPictureID { get; set; }

	public int PrdId { get; set; }

	public byte[] PrdFirstPic { get; set; }

	public string PrdFirstPicDesc { get; set; }

	public byte[] PrdSecondPic { get; set; }

	public string PrdSecondPicDesc { get; set; }

	public byte[] PrdThirdPic { get; set; }

	public string PrdThirdPicDesc { get; set; }

	public byte[] PrdFourthPic { get; set; }

	public string PrdFourthPicDesc { get; set; }

	public byte[] PrdFifthPic { get; set; }

	public string PrdFifthPicDesc { get; set; }

	public string Description { get; set; }
}
