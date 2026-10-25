using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace CRM.General.Security;

public static class HtmlSanitizer
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static MatchEvaluator _003C_003E9__6_0;

		public static MatchEvaluator _003C_003E9__13_0;

		public static MatchEvaluator _003C_003E9__14_0;

		internal string _003CremoveInvalidHtmlTags_003Eb__6_0(Match m)
		{
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Expected O, but got Unknown
			if (!ValidHtmlTags.ContainsKey(((Capture)m.Groups["tag"]).Value.ToLowerInvariant()))
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(((Capture)m).Length);
			Group val = m.Groups["tag_start"];
			Group val2 = m.Groups["tag_end"];
			Group val3 = m.Groups["tag"];
			Group obj = m.Groups["attr"];
			stringBuilder.Append(val.Success ? ((Capture)val).Value : "<");
			stringBuilder.Append(((Capture)val3).Value);
			foreach (Capture capture in obj.Captures)
			{
				Capture val4 = capture;
				int num = val4.Value.IndexOf('=');
				if (num >= 1)
				{
					string item = val4.Value.Substring(0, num).ToLowerInvariant();
					if (ValidHtmlTags[((Capture)val3).Value.ToLowerInvariant()].Contains(item))
					{
						stringBuilder.Append(' ');
						stringBuilder.Append(val4.Value);
					}
				}
			}
			stringBuilder.Append(val2.Success ? ((Capture)val2).Value : ">");
			return stringBuilder.ToString();
		}

		internal string _003CremoveInvalidEmailBodyTags_003Eb__13_0(Match m)
		{
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			if (!ValidHtmlTags.ContainsKey(((Capture)m.Groups["tag"]).Value.ToLowerInvariant()))
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(((Capture)m).Length);
			Group val = m.Groups["tag_start"];
			Group val2 = m.Groups["tag_end"];
			Group val3 = m.Groups["tag"];
			Group obj = m.Groups["attr"];
			stringBuilder.Append(val.Success ? ((Capture)val).Value : "<");
			stringBuilder.Append(((Capture)val3).Value);
			foreach (Capture capture in obj.Captures)
			{
				Capture val4 = capture;
				int num = val4.Value.IndexOf('=');
				if (num < 1)
				{
					continue;
				}
				string text = val4.Value.Substring(0, num).Trim().ToLowerInvariant();
				if (!ValidHtmlTags[((Capture)val3).Value.ToLowerInvariant()].Contains(text))
				{
					continue;
				}
				string text2 = val4.Value.Substring(num + 1).Trim();
				text2 = text2.Trim('"', '\'');
				switch (text)
				{
				case "href":
					if (IsDangerousUrl(text2))
					{
						continue;
					}
					break;
				case "src":
					if (IsDangerousUrl(text2) || IsExternalImage(text2))
					{
						continue;
					}
					break;
				case "style":
					if (IsDangerousStyle(text2))
					{
						continue;
					}
					break;
				}
				stringBuilder.Append(' ');
				stringBuilder.Append(text);
				stringBuilder.Append("=\"");
				stringBuilder.Append(WebUtility.HtmlEncode(text2));
				stringBuilder.Append('"');
			}
			stringBuilder.Append(val2.Success ? ((Capture)val2).Value : ">");
			return stringBuilder.ToString();
		}

		internal string _003CFixLinks_003Eb__14_0(Match match)
		{
			string text = ((Capture)match).Value;
			if (!Regex.IsMatch(text, "target\\s*=", (RegexOptions)1))
			{
				text = text.Insert(text.Length - 1, " target=\"_blank\"");
			}
			if (!Regex.IsMatch(text, "rel\\s*=", (RegexOptions)1))
			{
				text = text.Insert(text.Length - 1, " rel=\"noopener noreferrer nofollow\"");
			}
			return text;
		}
	}

	private static readonly Regex ChromeWhiteSpace = new Regex("style=\"white-space\\s*:\\s*pre\\s*;\\s*\"", (RegexOptions)25);

	private static readonly Regex HtmlComments = new Regex("((<!-- )((?!<!-- ).)*( -->))(\r\n)*", (RegexOptions)25);

	private static readonly Regex HtmlTagExpression = new Regex("(?'tag_start'</?)(?'tag'\\w+)((\\s+(?'attr'(?'attr_name'\\w+)(\\s*=\\s*(?:\".*?\"|'.*?'|[^'\">\\s]+)))?)+\\s*|\\s*)(?'tag_end'/?>)", (RegexOptions)25);

	private static readonly Dictionary<string, List<string>> ValidHtmlTags = new Dictionary<string, List<string>>
	{
		{
			"p",
			new List<string>()
		},
		{
			"table",
			new List<string> { "height", "width", "style" }
		},
		{
			"tr",
			new List<string> { "style" }
		},
		{
			"td",
			new List<string> { "style" }
		},
		{
			"tbody",
			new List<string> { "style" }
		},
		{
			"tfoot",
			new List<string> { "style", "class" }
		},
		{
			"th",
			new List<string> { "style" }
		},
		{
			"div",
			new List<string> { "dir", "align", "style" }
		},
		{
			"span",
			new List<string> { "dir", "color", "align", "style" }
		},
		{
			"pre",
			new List<string> { "language", "name" }
		},
		{
			"strong",
			new List<string>()
		},
		{
			"br",
			new List<string>()
		},
		{
			"label",
			new List<string> { "style", "class" }
		},
		{
			"font",
			new List<string> { "style", "class", "color", "face", "size" }
		},
		{
			"h1",
			new List<string>()
		},
		{
			"h2",
			new List<string>()
		},
		{
			"h3",
			new List<string>()
		},
		{
			"h4",
			new List<string>()
		},
		{
			"h5",
			new List<string>()
		},
		{
			"h6",
			new List<string>()
		},
		{
			"blockquote",
			new List<string> { "style", "class" }
		},
		{
			"b",
			new List<string>()
		},
		{
			"hr",
			new List<string>()
		},
		{
			"em",
			new List<string>()
		},
		{
			"i",
			new List<string>()
		},
		{
			"u",
			new List<string>()
		},
		{
			"strike",
			new List<string>()
		},
		{
			"ol",
			new List<string>()
		},
		{
			"ul",
			new List<string>()
		},
		{
			"li",
			new List<string>()
		},
		{
			"a",
			new List<string> { "href", "style" }
		},
		{
			"img",
			new List<string> { "src", "height", "width", "alt", "style" }
		},
		{
			"q",
			new List<string> { "cite" }
		},
		{
			"cite",
			new List<string>()
		},
		{
			"abbr",
			new List<string>()
		},
		{
			"acronym",
			new List<string>()
		},
		{
			"del",
			new List<string>()
		},
		{
			"ins",
			new List<string>()
		}
	};

	private static readonly string[] DangerousProtocols = new string[5] { "javascript:", "vbscript:", "data:", "file:", "about:" };

	private static readonly string[] DangerousStyles = new string[10] { "expression(", "javascript:", "vbscript:", "behavior:", "@import", "data:", "url(", "-moz-binding", "file:", "about:" };

	private static string cleanHtml(this string html)
	{
		html = ChromeWhiteSpace.Replace(html, string.Empty);
		html = HtmlComments.Replace(html, string.Empty);
		return html;
	}

	public static string ToSafeHtml(this string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		text = text.cleanHtml();
		text = text.removeInvalidHtmlTags();
		return text.ApplyModeratePersianRules();
	}

	private static string removeInvalidHtmlTags(this string text)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		Regex htmlTagExpression = HtmlTagExpression;
		object obj = _003C_003Ec._003C_003E9__6_0;
		if (obj == null)
		{
			MatchEvaluator val = delegate(Match m)
			{
				//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c0: Expected O, but got Unknown
				if (!ValidHtmlTags.ContainsKey(((Capture)m.Groups["tag"]).Value.ToLowerInvariant()))
				{
					return string.Empty;
				}
				StringBuilder stringBuilder = new StringBuilder(((Capture)m).Length);
				Group val2 = m.Groups["tag_start"];
				Group val3 = m.Groups["tag_end"];
				Group val4 = m.Groups["tag"];
				Group obj2 = m.Groups["attr"];
				stringBuilder.Append(val2.Success ? ((Capture)val2).Value : "<");
				stringBuilder.Append(((Capture)val4).Value);
				foreach (Capture capture in obj2.Captures)
				{
					Capture val5 = capture;
					int num = val5.Value.IndexOf('=');
					if (num >= 1)
					{
						string item = val5.Value.Substring(0, num).ToLowerInvariant();
						if (ValidHtmlTags[((Capture)val4).Value.ToLowerInvariant()].Contains(item))
						{
							stringBuilder.Append(' ');
							stringBuilder.Append(val5.Value);
						}
					}
				}
				stringBuilder.Append(val3.Success ? ((Capture)val3).Value : ">");
				return stringBuilder.ToString();
			};
			_003C_003Ec._003C_003E9__6_0 = val;
			obj = (object)val;
		}
		return htmlTagExpression.Replace(text, (MatchEvaluator)obj);
	}

	private static bool IsDangerousUrl(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return false;
		}
		value = value.Trim().Trim('"', '\'').ToLowerInvariant();
		return Enumerable.Any<string>((IEnumerable<string>)DangerousProtocols, (Func<string, bool>)value.StartsWith);
	}

	private static bool IsDangerousStyle(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return false;
		}
		value = value.ToLowerInvariant();
		return Enumerable.Any<string>((IEnumerable<string>)DangerousStyles, (Func<string, bool>)value.Contains);
	}

	private static string RemoveDangerousBlocks(string html)
	{
		if (string.IsNullOrWhiteSpace(html))
		{
			return html;
		}
		string[] array = new string[21]
		{
			"script", "iframe", "object", "embed", "form", "input", "button", "textarea", "select", "option",
			"meta", "link", "base", "style", "svg", "math", "canvas", "video", "audio", "template",
			"noscript"
		};
		foreach (string text in array)
		{
			html = Regex.Replace(html, "<\\s*" + text + "\\b[^>]*>.*?<\\s*/\\s*" + text + "\\s*>", "", (RegexOptions)17);
			html = Regex.Replace(html, "<\\s*" + text + "\\b[^>]*/?>", "", (RegexOptions)1);
		}
		return html;
	}

	public static string ToSafeEmailBodyHtml(this string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return string.Empty;
		}
		text = RemoveDangerousBlocks(text);
		text = text.cleanHtml();
		text = text.removeInvalidEmailBodyTags();
		text = FixLinks(text);
		return text.ApplyModeratePersianRules();
	}

	private static string removeInvalidEmailBodyTags(this string text)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		Regex htmlTagExpression = HtmlTagExpression;
		object obj = _003C_003Ec._003C_003E9__13_0;
		if (obj == null)
		{
			MatchEvaluator val = delegate(Match m)
			{
				//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c3: Expected O, but got Unknown
				if (!ValidHtmlTags.ContainsKey(((Capture)m.Groups["tag"]).Value.ToLowerInvariant()))
				{
					return string.Empty;
				}
				StringBuilder stringBuilder = new StringBuilder(((Capture)m).Length);
				Group val2 = m.Groups["tag_start"];
				Group val3 = m.Groups["tag_end"];
				Group val4 = m.Groups["tag"];
				Group obj2 = m.Groups["attr"];
				stringBuilder.Append(val2.Success ? ((Capture)val2).Value : "<");
				stringBuilder.Append(((Capture)val4).Value);
				foreach (Capture capture in obj2.Captures)
				{
					Capture val5 = capture;
					int num = val5.Value.IndexOf('=');
					if (num >= 1)
					{
						string text2 = val5.Value.Substring(0, num).Trim().ToLowerInvariant();
						if (ValidHtmlTags[((Capture)val4).Value.ToLowerInvariant()].Contains(text2))
						{
							string text3 = val5.Value.Substring(num + 1).Trim();
							text3 = text3.Trim('"', '\'');
							switch (text2)
							{
							case "href":
								if (IsDangerousUrl(text3))
								{
									continue;
								}
								break;
							case "src":
								if (IsDangerousUrl(text3) || IsExternalImage(text3))
								{
									continue;
								}
								break;
							case "style":
								if (IsDangerousStyle(text3))
								{
									continue;
								}
								break;
							}
							stringBuilder.Append(' ');
							stringBuilder.Append(text2);
							stringBuilder.Append("=\"");
							stringBuilder.Append(WebUtility.HtmlEncode(text3));
							stringBuilder.Append('"');
						}
					}
				}
				stringBuilder.Append(val3.Success ? ((Capture)val3).Value : ">");
				return stringBuilder.ToString();
			};
			_003C_003Ec._003C_003E9__13_0 = val;
			obj = (object)val;
		}
		return htmlTagExpression.Replace(text, (MatchEvaluator)obj);
	}

	private static string FixLinks(string html)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		object obj = _003C_003Ec._003C_003E9__14_0;
		if (obj == null)
		{
			MatchEvaluator val = delegate(Match match)
			{
				string text = ((Capture)match).Value;
				if (!Regex.IsMatch(text, "target\\s*=", (RegexOptions)1))
				{
					text = text.Insert(text.Length - 1, " target=\"_blank\"");
				}
				if (!Regex.IsMatch(text, "rel\\s*=", (RegexOptions)1))
				{
					text = text.Insert(text.Length - 1, " rel=\"noopener noreferrer nofollow\"");
				}
				return text;
			};
			_003C_003Ec._003C_003E9__14_0 = val;
			obj = (object)val;
		}
		return Regex.Replace(html, "<a\\b([^>]*)>", (MatchEvaluator)obj, (RegexOptions)1);
	}

	private static bool IsExternalImage(string src)
	{
		if (string.IsNullOrWhiteSpace(src))
		{
			return false;
		}
		src = src.ToLowerInvariant();
		if (!src.StartsWith("http://"))
		{
			return src.StartsWith("https://");
		}
		return true;
	}
}
