using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace CRMIdeal.Classes.Common;

public static class FileSignatureValidator
{
	private static readonly Dictionary<string, List<byte[]>> Signatures = new Dictionary<string, List<byte[]>>(StringComparer.OrdinalIgnoreCase)
	{
		{
			"jpg",
			new List<byte[]> { new byte[3] { 255, 216, 255 } }
		},
		{
			"jpeg",
			new List<byte[]> { new byte[3] { 255, 216, 255 } }
		},
		{
			"png",
			new List<byte[]> { new byte[8] { 137, 80, 78, 71, 13, 10, 26, 10 } }
		},
		{
			"gif",
			new List<byte[]>
			{
				Encoding.ASCII.GetBytes("GIF87a"),
				Encoding.ASCII.GetBytes("GIF89a")
			}
		},
		{
			"bmp",
			new List<byte[]> { new byte[2] { 66, 77 } }
		},
		{
			"tif",
			new List<byte[]>
			{
				new byte[4] { 73, 73, 42, 0 },
				new byte[4] { 77, 77, 0, 42 }
			}
		},
		{
			"tiff",
			new List<byte[]>
			{
				new byte[4] { 73, 73, 42, 0 },
				new byte[4] { 77, 77, 0, 42 }
			}
		},
		{
			"pdf",
			new List<byte[]> { Encoding.ASCII.GetBytes("%PDF") }
		},
		{
			"zip",
			new List<byte[]>
			{
				new byte[4] { 80, 75, 3, 4 },
				new byte[4] { 80, 75, 5, 6 },
				new byte[4] { 80, 75, 7, 8 }
			}
		},
		{
			"docx",
			new List<byte[]>
			{
				new byte[4] { 80, 75, 3, 4 },
				new byte[4] { 80, 75, 5, 6 },
				new byte[4] { 80, 75, 7, 8 }
			}
		},
		{
			"xlsx",
			new List<byte[]>
			{
				new byte[4] { 80, 75, 3, 4 },
				new byte[4] { 80, 75, 5, 6 },
				new byte[4] { 80, 75, 7, 8 }
			}
		},
		{
			"pptx",
			new List<byte[]>
			{
				new byte[4] { 80, 75, 3, 4 },
				new byte[4] { 80, 75, 5, 6 },
				new byte[4] { 80, 75, 7, 8 }
			}
		},
		{
			"doc",
			new List<byte[]> { new byte[4] { 208, 207, 17, 224 } }
		},
		{
			"xls",
			new List<byte[]>
			{
				new byte[4] { 208, 207, 17, 224 },
				new byte[4] { 80, 75, 3, 4 },
				new byte[4] { 80, 75, 5, 6 },
				new byte[4] { 80, 75, 7, 8 }
			}
		},
		{
			"ppt",
			new List<byte[]> { new byte[4] { 208, 207, 17, 224 } }
		},
		{
			"rar",
			new List<byte[]>
			{
				new byte[7] { 82, 97, 114, 33, 26, 7, 0 },
				new byte[8] { 82, 97, 114, 33, 26, 7, 1, 0 }
			}
		},
		{
			"7z",
			new List<byte[]> { new byte[6] { 55, 122, 188, 175, 39, 28 } }
		}
	};

	public static bool IsValidFileSignature(string filePath)
	{
		if (!File.Exists(filePath))
		{
			return false;
		}
		byte[] buffer = new byte[16];
		using (FileStream fileStream = File.OpenRead(filePath))
		{
			fileStream.Read(buffer, 0, buffer.Length);
		}
		bool flag = StartsWith(buffer, new byte[4] { 208, 207, 17, 224 });
		if (StartsWith(buffer, new byte[4] { 80, 75, 3, 4 }) || StartsWith(buffer, new byte[4] { 80, 75, 5, 6 }) || StartsWith(buffer, new byte[4] { 80, 75, 7, 8 }))
		{
			return ValidateOpenXml(filePath);
		}
		if (flag)
		{
			return true;
		}
		string key = Path.GetExtension(filePath).TrimStart(new char[1] { '.' }).ToLowerInvariant();
		if (!Signatures.TryGetValue(key, out var value))
		{
			return true;
		}
		return Enumerable.Any<byte[]>((IEnumerable<byte[]>)value, (Func<byte[], bool>)((byte[] x) => StartsWith(buffer, x)));
	}

	private static bool StartsWith(byte[] buffer, byte[] signature)
	{
		if (buffer.Length < signature.Length)
		{
			return false;
		}
		for (int i = 0; i < signature.Length; i++)
		{
			if (buffer[i] != signature[i])
			{
				return false;
			}
		}
		return true;
	}

	private static bool ValidateOfficeDocument(string filePath, string ext)
	{
		if (!ext.Equals("docx", StringComparison.OrdinalIgnoreCase) && !ext.Equals("xlsx", StringComparison.OrdinalIgnoreCase) && !ext.Equals("pptx", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		try
		{
			using ZipArchive zipArchive = ZipFile.OpenRead(filePath);
			ReadOnlyCollection<ZipArchiveEntry> entries = zipArchive.Entries;
			if (!Enumerable.Any<ZipArchiveEntry>((IEnumerable<ZipArchiveEntry>)entries, (Func<ZipArchiveEntry, bool>)((ZipArchiveEntry x) => x.FullName.Equals("[Content_Types].xml", StringComparison.OrdinalIgnoreCase))))
			{
				return false;
			}
			switch (ext.ToLowerInvariant())
			{
			case "docx":
				if (!Enumerable.Any<ZipArchiveEntry>((IEnumerable<ZipArchiveEntry>)entries, (Func<ZipArchiveEntry, bool>)((ZipArchiveEntry x) => x.FullName.Equals("word/document.xml", StringComparison.OrdinalIgnoreCase))))
				{
					return false;
				}
				break;
			case "xlsx":
				if (!Enumerable.Any<ZipArchiveEntry>((IEnumerable<ZipArchiveEntry>)entries, (Func<ZipArchiveEntry, bool>)((ZipArchiveEntry x) => x.FullName.Equals("xl/workbook.xml", StringComparison.OrdinalIgnoreCase))))
				{
					return false;
				}
				break;
			case "pptx":
				if (!Enumerable.Any<ZipArchiveEntry>((IEnumerable<ZipArchiveEntry>)entries, (Func<ZipArchiveEntry, bool>)((ZipArchiveEntry x) => x.FullName.Equals("ppt/presentation.xml", StringComparison.OrdinalIgnoreCase))))
				{
					return false;
				}
				break;
			}
			if (Enumerable.Any<ZipArchiveEntry>((IEnumerable<ZipArchiveEntry>)entries, (Func<ZipArchiveEntry, bool>)((ZipArchiveEntry x) => x.FullName.IndexOf("vbaProject.bin", StringComparison.OrdinalIgnoreCase) >= 0)))
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool HasDoubleExtension(string fileName)
	{
		if (string.IsNullOrWhiteSpace(fileName))
		{
			return false;
		}
		string[] array = fileName.Split(new char[1] { '.' });
		if (array.Length < 3)
		{
			return false;
		}
		string item = array[^1];
		if (Configuration.MaliciousFileExtensions.Contains(item))
		{
			return true;
		}
		return false;
	}

	public static bool IsZipBomb(string filePath)
	{
		try
		{
			using ZipArchive zipArchive = ZipFile.OpenRead(filePath);
			long num = 0L;
			long num2 = 0L;
			foreach (ZipArchiveEntry entry in zipArchive.Entries)
			{
				num += entry.CompressedLength;
				num2 += entry.Length;
			}
			if (num == 0L)
			{
				return true;
			}
			if ((double)num2 / (double)num > 100.0)
			{
				return true;
			}
			if (zipArchive.Entries.Count > 10000)
			{
				return true;
			}
			return false;
		}
		catch
		{
			return true;
		}
	}

	private static bool ValidateOpenXml(string filePath)
	{
		try
		{
			using ZipArchive zipArchive = ZipFile.OpenRead(filePath);
			ReadOnlyCollection<ZipArchiveEntry> entries = zipArchive.Entries;
			if (!Enumerable.Any<ZipArchiveEntry>((IEnumerable<ZipArchiveEntry>)entries, (Func<ZipArchiveEntry, bool>)((ZipArchiveEntry x) => x.FullName.Equals("[Content_Types].xml", StringComparison.OrdinalIgnoreCase))))
			{
				return false;
			}
			bool flag = Enumerable.Any<ZipArchiveEntry>((IEnumerable<ZipArchiveEntry>)entries, (Func<ZipArchiveEntry, bool>)((ZipArchiveEntry x) => x.FullName.Equals("word/document.xml", StringComparison.OrdinalIgnoreCase)));
			bool flag2 = Enumerable.Any<ZipArchiveEntry>((IEnumerable<ZipArchiveEntry>)entries, (Func<ZipArchiveEntry, bool>)((ZipArchiveEntry x) => x.FullName.Equals("xl/workbook.xml", StringComparison.OrdinalIgnoreCase)));
			bool flag3 = Enumerable.Any<ZipArchiveEntry>((IEnumerable<ZipArchiveEntry>)entries, (Func<ZipArchiveEntry, bool>)((ZipArchiveEntry x) => x.FullName.Equals("ppt/presentation.xml", StringComparison.OrdinalIgnoreCase)));
			if (!(flag || flag2 || flag3))
			{
				return false;
			}
			if (Enumerable.Any<ZipArchiveEntry>((IEnumerable<ZipArchiveEntry>)entries, (Func<ZipArchiveEntry, bool>)((ZipArchiveEntry x) => x.FullName.IndexOf("vbaProject.bin", StringComparison.OrdinalIgnoreCase) >= 0)))
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}
}
