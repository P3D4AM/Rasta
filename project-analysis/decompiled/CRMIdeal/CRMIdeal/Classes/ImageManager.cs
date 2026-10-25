using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using CRM.General.IO;
using CRMIdeal.Classes.Common;

namespace CRMIdeal.Classes;

public class ImageManager
{
	public class ImageParam
	{
		private string _FileExtension = "png";

		private int _MinSizeForCompress = 150;

		public bool? EnableChangeQuality { get; set; }

		public byte[] Bytes { get; set; }

		public string FolderPath { get; set; }

		public string FilePath { get; set; }

		public string DestPath { get; set; }

		public string FileName { get; set; }

		public string FileExtension
		{
			get
			{
				return _FileExtension;
			}
			set
			{
				_FileExtension = value;
			}
		}

		public int MinSizeForCompress
		{
			get
			{
				return _MinSizeForCompress;
			}
			set
			{
				_MinSizeForCompress = value;
			}
		}

		public int CustomHeight { get; set; }

		public int CustomWidth { get; set; }

		public HttpPostedFileBase HttpPostedFileBase_Var { get; set; }

		public bool WithThread { get; set; }

		public MemoryStream Stream { get; set; }
	}

	public class ImgInfo
	{
		public string DirectoryName { get; set; }

		public string FullName { get; set; }

		public string Name { get; set; }

		public string Ext { get; set; }

		public bool IsReadOnly { get; set; }

		public long Size { get; set; }

		public string SizeShort { get; set; }

		public DirectoryInfo Directory { get; set; }

		public bool Exists { get; set; }

		public DateTime CreationTime { get; set; }

		public DateTime LastAccessTime { get; set; }

		public DateTime LastWriteTime { get; set; }

		public bool IsDone { get; set; }

		public string ErrorMessage { get; set; }
	}

	private static bool _ImageCompressTemp_AccessGenerated;

	public static void CompressFile(ImageParam p)
	{
		MainCompress(p);
	}

	public static byte[] CompressByte(ImageParam p)
	{
		p.FilePath = SaveFromByte(p);
		if (!string.IsNullOrWhiteSpace(p.FilePath))
		{
			MainCompress(p);
			byte[] result = System.IO.File.ReadAllBytes(p.FilePath);
			try
			{
				System.IO.File.Delete(p.FilePath);
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return result;
		}
		return null;
	}

	public static void CompressFolder(ImageParam p)
	{
		if (string.IsNullOrWhiteSpace(p.FolderPath))
		{
			return;
		}
		foreach (string item in System.IO.Directory.EnumerateFiles(p.FolderPath))
		{
			FileInfo fileInfo = new FileInfo(item);
			p.FilePath = Path.Combine(p.FolderPath, $"{fileInfo.Name}");
			if (!System.IO.File.Exists(p.FilePath) || (!fileInfo.Name.Contains(".png") && !fileInfo.Name.Contains(".jpg")))
			{
				continue;
			}
			if (p.WithThread)
			{
				Task.Factory.StartNew(delegate
				{
					MainCompress(p);
				});
			}
			else
			{
				MainCompress(p);
			}
		}
	}

	public static byte[] CompressHttpPostedFileBase(ImageParam p)
	{
		byte[] result = null;
		try
		{
			if (p.HttpPostedFileBase_Var != null)
			{
				byte[] array = new byte[16384];
				using MemoryStream memoryStream = new MemoryStream();
				int count;
				while ((count = p.HttpPostedFileBase_Var.InputStream.Read(array, 0, array.Length)) > 0)
				{
					memoryStream.Write(array, 0, count);
				}
				p.Bytes = memoryStream.ToArray();
				result = CompressByte(p);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static MemoryStream CompressHttpPostedFileBaseAsStream(ImageParam p)
	{
		MemoryStream result = null;
		try
		{
			if (p.HttpPostedFileBase_Var != null)
			{
				byte[] array = new byte[16384];
				using MemoryStream memoryStream = new MemoryStream();
				int count;
				while ((count = p.HttpPostedFileBase_Var.InputStream.Read(array, 0, array.Length)) > 0)
				{
					memoryStream.Write(array, 0, count);
				}
				p.Bytes = memoryStream.ToArray();
				result = new MemoryStream(CompressByte(p));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static string SaveFromByte(ImageParam p)
	{
		string result = "";
		try
		{
			if (p.Bytes != null)
			{
				if (string.IsNullOrWhiteSpace(p.FolderPath))
				{
					p.FolderPath = "~/Download/ImageCompressTemp";
					string text = HttpContext.Current.Server.MapPath(p.FolderPath);
					if (!System.IO.Directory.Exists(text))
					{
						System.IO.Directory.CreateDirectory(text);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text);
						_ImageCompressTemp_AccessGenerated = true;
					}
					else if (!_ImageCompressTemp_AccessGenerated)
					{
						CRM.General.IO.Directory.SetFullControlForEveryOne(text);
						_ImageCompressTemp_AccessGenerated = true;
					}
				}
				if (string.IsNullOrWhiteSpace(p.FileName))
				{
					p.FileName = Guid.NewGuid().ToString();
				}
				if (string.IsNullOrWhiteSpace(p.FileExtension))
				{
					p.FileExtension = "png";
				}
				string text2 = Path.Combine(HttpContext.Current.Server.MapPath(p.FolderPath), p.FileName) + "." + p.FileExtension;
				System.IO.File.WriteAllBytes(text2, p.Bytes);
				result = text2;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static string SaveFromStream(ImageParam p)
	{
		string result = "";
		try
		{
			if (p.Stream != null)
			{
				byte[] array = new byte[16384];
				using MemoryStream memoryStream = new MemoryStream();
				int count;
				while ((count = p.Stream.Read(array, 0, array.Length)) > 0)
				{
					memoryStream.Write(array, 0, count);
				}
				p.Bytes = memoryStream.ToArray();
				result = SaveFromByte(p);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static string SaveFromHttpPostedFileBase(ImageParam p)
	{
		string result = "";
		try
		{
			if (p.Stream != null)
			{
				byte[] array = new byte[16384];
				using MemoryStream memoryStream = new MemoryStream();
				int count;
				while ((count = p.HttpPostedFileBase_Var.InputStream.Read(array, 0, array.Length)) > 0)
				{
					memoryStream.Write(array, 0, count);
				}
				p.Bytes = memoryStream.ToArray();
				result = SaveFromByte(p);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static string DeleteFile(ImageParam p)
	{
		string result = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(p.FilePath))
			{
				if (p.FilePath.StartsWith("~"))
				{
					p.FilePath = HttpContext.Current.Server.MapPath(p.FilePath);
				}
				if (System.IO.File.Exists(p.FilePath))
				{
					System.IO.File.Delete(p.FilePath);
				}
			}
		}
		catch (Exception ex)
		{
			result = ex.Message;
		}
		return result;
	}

	private static void MainCompress(ImageParam p)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		try
		{
			FileInfo fileInfo = new FileInfo(p.FilePath);
			if (p.MinSizeForCompress > 0 && fileInfo.Length <= p.MinSizeForCompress)
			{
				return;
			}
			Bitmap val = new Bitmap(p.FilePath);
			try
			{
				int num = ((Image)val).Width;
				if (num > 1500)
				{
					num = 1500;
				}
				if (p.CustomWidth > 0 && num > p.CustomWidth)
				{
					num = p.CustomWidth;
				}
				if (p.CustomWidth == -1)
				{
					num = ((Image)val).Width;
				}
				int num2 = ((Image)val).Height;
				if (num2 > 1500)
				{
					num2 = 1500;
				}
				if (p.CustomHeight > 0 && num2 > p.CustomHeight)
				{
					num2 = p.CustomHeight;
				}
				if (p.CustomHeight == -1)
				{
					num2 = ((Image)val).Height;
				}
				long quality = 100L;
				if (p.EnableChangeQuality != false)
				{
					if (fileInfo.Length > 10000000)
					{
						quality = 45L;
					}
					else if (fileInfo.Length > 8500000)
					{
						quality = 15L;
					}
					else if (fileInfo.Length > 6000000)
					{
						quality = 16L;
					}
					else if (fileInfo.Length > 4500000)
					{
						quality = 50L;
					}
					else if (fileInfo.Length > 3000000)
					{
						quality = 51L;
					}
					else if (fileInfo.Length > 1000000)
					{
						quality = 23L;
					}
					else if (fileInfo.Length > 500000)
					{
						quality = 32L;
					}
					else if (fileInfo.Length > 150000)
					{
						quality = 31L;
					}
				}
				string text = p.DestPath;
				if (string.IsNullOrWhiteSpace(text))
				{
					text = p.FilePath + "_tmp";
				}
				Bitmap val2;
				if (p.EnableChangeQuality != false)
				{
					ImageFormat imageFormat = ImageFormat.Jpeg;
					if (!string.IsNullOrWhiteSpace(p.FileExtension))
					{
						switch (p.FileExtension)
						{
						case "png":
							imageFormat = ImageFormat.Png;
							break;
						case "jpg":
						case "jpeg":
							imageFormat = ImageFormat.Jpeg;
							break;
						}
					}
					val2 = ResizeImage((Image)(object)val, num, num2);
					SaveCompressedImage((Image)(object)val2, p.FilePath, text, quality, imageFormat);
				}
				else
				{
					val2 = ResizeImageI((Image)(object)val, num, num2);
					((Image)val2).Save(text);
				}
				((Image)val).Dispose();
				((Image)val2).Dispose();
				if (string.IsNullOrWhiteSpace(p.DestPath))
				{
					if (System.IO.File.Exists(p.FilePath))
					{
						System.IO.File.Delete(p.FilePath);
					}
					System.IO.File.Move(text, p.FilePath);
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
	}

	private static Bitmap ResizeImage(Image image, int width, int height)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		Bitmap val = null;
		try
		{
			Rectangle val2 = default(Rectangle);
			((Rectangle)(ref val2))._002Ector(0, 0, width, height);
			val = new Bitmap(width, height);
			val.SetResolution(image.HorizontalResolution, image.VerticalResolution);
			Graphics val3 = Graphics.FromImage((Image)(object)val);
			try
			{
				val3.CompositingMode = (CompositingMode)1;
				val3.CompositingQuality = (CompositingQuality)2;
				val3.InterpolationMode = (InterpolationMode)7;
				val3.SmoothingMode = (SmoothingMode)2;
				val3.PixelOffsetMode = (PixelOffsetMode)2;
				ImageAttributes val4 = new ImageAttributes();
				try
				{
					val4.SetWrapMode((WrapMode)3);
					val3.DrawImage(image, val2, 0, 0, image.Width, image.Height, (GraphicsUnit)2, val4);
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return val;
	}

	private static Bitmap ResizeImageI(Image image, int width, int height)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		Bitmap val = null;
		try
		{
			Rectangle val2 = default(Rectangle);
			((Rectangle)(ref val2))._002Ector(0, 0, width, height);
			val = new Bitmap(width, height);
			val.SetResolution(image.HorizontalResolution, image.VerticalResolution);
			Graphics val3 = Graphics.FromImage((Image)(object)val);
			try
			{
				val3.CompositingMode = (CompositingMode)1;
				ImageAttributes val4 = new ImageAttributes();
				try
				{
					val4.SetWrapMode((WrapMode)3);
					val3.DrawImage(image, val2, 0, 0, image.Width, image.Height, (GraphicsUnit)2, val4);
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return val;
	}

	private static void SaveCompressedImage(Image img, string filename, string destfilename, long quality = 100L, ImageFormat imageFormat = null)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		try
		{
			if (imageFormat == null)
			{
				imageFormat = ImageFormat.Jpeg;
			}
			EncoderParameter val = new EncoderParameter(Encoder.Quality, quality);
			ImageCodecInfo imageCompressEncoder = GetImageCompressEncoder(ImageFormat.Png);
			EncoderParameters val2 = new EncoderParameters(1);
			val2.Param[0] = val;
			img.Save(destfilename, imageCompressEncoder, val2);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
	}

	private static ImageCodecInfo GetImageCompressEncoder(ImageFormat format)
	{
		try
		{
			ImageCodecInfo[] imageDecoders = ImageCodecInfo.GetImageDecoders();
			foreach (ImageCodecInfo val in imageDecoders)
			{
				if (val.FormatID == format.Guid)
				{
					return val;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return null;
	}

	public static ImgInfo GetFileInfo(string filePath = "", byte[] bytes = null, HttpPostedFileBase filebase = null)
	{
		ImgInfo imgInfo = new ImgInfo();
		try
		{
			bool flag = false;
			if (string.IsNullOrWhiteSpace(filePath))
			{
				if (bytes != null)
				{
					filePath = SaveFromByte(new ImageParam
					{
						Bytes = bytes
					});
					flag = true;
				}
				else if (filebase != null)
				{
					filePath = SaveFromHttpPostedFileBase(new ImageParam
					{
						HttpPostedFileBase_Var = filebase
					});
					flag = true;
				}
			}
			FileInfo fileInfo = new FileInfo(filePath);
			imgInfo.Size = fileInfo.Length;
			imgInfo.SizeShort = GetFileSizeShort(fileInfo.Length);
			imgInfo.LastAccessTime = fileInfo.LastAccessTime;
			imgInfo.LastWriteTime = fileInfo.LastWriteTime;
			imgInfo.Name = fileInfo.Name;
			imgInfo.Ext = fileInfo.Extension;
			imgInfo.Exists = fileInfo.Exists;
			imgInfo.IsReadOnly = fileInfo.IsReadOnly;
			imgInfo.FullName = fileInfo.FullName;
			imgInfo.Directory = fileInfo.Directory;
			imgInfo.DirectoryName = fileInfo.DirectoryName;
			imgInfo.CreationTime = fileInfo.CreationTime;
			imgInfo.IsDone = true;
			if (flag)
			{
				DeleteFile(new ImageParam
				{
					FilePath = filePath
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			imgInfo.IsDone = false;
			imgInfo.ErrorMessage = ex.Message;
			if (!string.IsNullOrWhiteSpace(filePath))
			{
				DeleteFile(new ImageParam
				{
					FilePath = filePath
				});
			}
		}
		return imgInfo;
	}

	public static string GetFileSizeShort(long size = 0L)
	{
		string result = "";
		try
		{
			if (size > 0)
			{
				string[] array = new string[9] { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
				if (size == 0L)
				{
					return $"{null}{0:0.#} {array[0]}";
				}
				double num = Math.Abs((double)size);
				int num2 = (int)Math.Log(num, 1000.0);
				int num3 = ((num2 >= array.Length) ? (array.Length - 1) : num2);
				double num4 = num / Math.Pow(1000.0, num3);
				return string.Format("{0}{1:0.#} {2}", (size < 0) ? "-" : null, num4, array[num3]);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static byte[] ConvertToByte(HttpPostedFileBase file)
	{
		try
		{
			return new BinaryReader(file.InputStream).ReadBytes(file.ContentLength);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			return null;
		}
	}

	public static string ConvertToWebImage(byte[] img = null)
	{
		string result = "";
		try
		{
			if (img != null)
			{
				string text = Convert.ToBase64String(img);
				if (!string.IsNullOrWhiteSpace(text))
				{
					result = "data:image/jpg;base64," + text;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}
}
