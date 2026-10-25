using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Hosting;
using ActiveUp.Net.Mail;
using ActiveUp.Net.Security;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Security;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace CRMIdeal.Classes.Helper;

public class Email
{
	public class FolderReceiveInfo
	{
		public EmailspSelectEmailReceiveFolders_Result Folder { get; set; }

		public Mailbox Mailbox { get; set; }

		public MessageCollection Messages { get; set; }

		public long MaxUId { get; set; }
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static RemoteCertificateValidationCallback _003C_003E9__3_0;

		public static Func<int, object> _003C_003E9__16_0;

		public static Func<EmailspSelectEmailReceiveFolders_Result, bool> _003C_003E9__16_1;

		public static Func<int, object> _003C_003E9__18_0;

		public static RemoteCertificateValidationCallback _003C_003E9__19_0;

		internal bool _003CCreateConnectedPop3Client_003Eb__3_0(object s, X509Certificate c, X509Chain h, SslPolicyErrors e)
		{
			return true;
		}

		internal object _003CReceiveAllEmailForAccount_003Eb__16_0(int _)
		{
			return new object();
		}

		internal bool _003CReceiveAllEmailForAccount_003Eb__16_1(EmailspSelectEmailReceiveFolders_Result x)
		{
			return x.FolderName.ToLower() == "inbox";
		}

		internal object _003CReceiveCountAllEmailForAccount_003Eb__18_0(int _)
		{
			return new object();
		}

		internal bool _003CSendEmailCmpFoLogin_003Eb__19_0(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Invalid comparison between Unknown and I4
			if ((int)sslPolicyErrors == 0)
			{
				return true;
			}
			if ((int)sslPolicyErrors == 4)
			{
				X509ChainStatus[] chainStatus = chain.ChainStatus;
				for (int i = 0; i < chainStatus.Length; i++)
				{
					X509ChainStatus x509ChainStatus = chainStatus[i];
					if (x509ChainStatus.Status != X509ChainStatusFlags.RevocationStatusUnknown && x509ChainStatus.Status != X509ChainStatusFlags.OfflineRevocation)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}

	private static readonly ConcurrentDictionary<int, object> AccountLocks = new ConcurrentDictionary<int, object>();

	private static readonly object _lockEmailReceiveLog = new object();

	public static Imap4Client CreateConnectedImapClient(int emailUsersInfoId, EmailspSelectEmailUsersInfoById_Result emailInfo, ref string message)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			if (emailInfo == null || (emailInfo != null && emailInfo.EmailUsersInfoId == 0))
			{
				emailInfo = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)cRMSpEntities.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
			}
			if (emailInfo == null)
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				WriteEmailReceiveLog(" CreateConnectedImapClient()=> Error connect to mail server:" + message, emailUsersInfoId);
				return null;
			}
			string euIMAPServer = emailInfo.euIMAPServer;
			string euUserName = emailInfo.euUserName;
			string text = ((!string.IsNullOrEmpty(emailInfo.euPassword)) ? XorCipher.DecryptByPrivateKey(emailInfo.euPassword) : string.Empty);
			bool valueOrDefault = emailInfo.euIMAPUseSsl.GetValueOrDefault();
			int valueOrDefault2 = emailInfo.euIMAPPort.GetValueOrDefault();
			if (string.IsNullOrWhiteSpace(euIMAPServer) || string.IsNullOrWhiteSpace(euUserName) || string.IsNullOrWhiteSpace(text))
			{
				message = Messages.msgErrorInReadingEmailSetting;
				WriteEmailReceiveLog(" CreateConnectedImapClient()=> Error connect to IMAP:" + message, emailUsersInfoId);
				return null;
			}
			Imap4Client imap4Client = new Imap4Client();
			try
			{
				if (valueOrDefault)
				{
					if (valueOrDefault2 > 0)
					{
						SslHandShake sslHandShake = new SslHandShake(euIMAPServer, (SslProtocols)3072);
						imap4Client.ConnectSsl(euIMAPServer, valueOrDefault2, sslHandShake);
					}
					else
					{
						imap4Client.ConnectSsl(euIMAPServer);
					}
				}
				else if (valueOrDefault2 > 0)
				{
					imap4Client.Connect(euIMAPServer, valueOrDefault2);
				}
				else
				{
					imap4Client.Connect(euIMAPServer);
				}
				try
				{
					imap4Client.Login(euUserName, text);
				}
				catch (Imap4Exception ex)
				{
					string text2 = ex.Message ?? string.Empty;
					if (!text2.Contains("Unexpected ')'") && !text2.Contains("Unexpected '('") && !text2.Contains("BAD") && !text2.Contains("syntax"))
					{
						throw;
					}
					string password = "\"" + text.Replace("\"", "\\\"") + "\"";
					imap4Client.Login(euUserName, password);
				}
				return imap4Client;
			}
			catch
			{
				try
				{
					if (imap4Client.IsConnected)
					{
						imap4Client.Disconnect();
					}
				}
				catch
				{
				}
				throw;
			}
		}
		catch (Exception ex2)
		{
			Logs.LogError(ex2, "");
			message = "IMAP connection failed: " + ex2.Message;
			WriteEmailReceiveLog(" CreateConnectedImapClient()=> Error connect to mail server:" + message, emailUsersInfoId);
			return null;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
	}

	public static Pop3Client CreateConnectedPop3Client(int emailUsersInfoId, EmailspSelectEmailUsersInfoById_Result emailInfo, ref string message)
	{
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			if (emailInfo == null || (emailInfo != null && emailInfo.EmailUsersInfoId == 0))
			{
				emailInfo = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)cRMSpEntities.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
			}
			if (emailInfo == null)
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				WriteEmailReceiveLog(" CreateConnectedImapClient()=> Error connect to mail server:" + message, emailUsersInfoId);
				return null;
			}
			string euPOP3Server = emailInfo.euPOP3Server;
			string euUserName = emailInfo.euUserName;
			string text = ((!string.IsNullOrEmpty(emailInfo.euPassword)) ? XorCipher.DecryptByPrivateKey(emailInfo.euPassword) : string.Empty);
			bool valueOrDefault = emailInfo.euPOP3UseSsl.GetValueOrDefault();
			int valueOrDefault2 = emailInfo.euPOP3Port.GetValueOrDefault();
			if (string.IsNullOrWhiteSpace(euPOP3Server) || string.IsNullOrWhiteSpace(euUserName) || string.IsNullOrWhiteSpace(text))
			{
				message = Messages.msgErrorInReadingEmailSetting;
				WriteEmailReceiveLog(" CreateConnectedPop3Client()=> Error connect to POP3:" + message, emailUsersInfoId);
				return null;
			}
			Pop3Client pop3Client = new Pop3Client();
			try
			{
				if (valueOrDefault2 > 0 && valueOrDefault)
				{
					pop3Client.CheckCertificateRevocation = false;
					object obj = _003C_003Ec._003C_003E9__3_0;
					if (obj == null)
					{
						RemoteCertificateValidationCallback val = (object s, X509Certificate c, X509Chain h, SslPolicyErrors e) => true;
						_003C_003Ec._003C_003E9__3_0 = val;
						obj = (object)val;
					}
					pop3Client.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)obj;
					pop3Client.Connect(euPOP3Server, valueOrDefault2);
				}
				else if (valueOrDefault2 > 0)
				{
					pop3Client.Connect(euPOP3Server, valueOrDefault2);
				}
				else
				{
					pop3Client.Connect(euPOP3Server);
				}
				try
				{
					pop3Client.Authenticate(euUserName, text);
				}
				catch (Pop3ProtocolException ex)
				{
					string text2 = ex.Message ?? string.Empty;
					if (!text2.Contains("Unexpected ')'") && !text2.Contains("Unexpected '('") && !text2.Contains("BAD") && !text2.Contains("syntax"))
					{
						throw;
					}
					string password = "\"" + text.Replace("\"", "\\\"") + "\"";
					pop3Client.Authenticate(euUserName, password);
				}
				return pop3Client;
			}
			catch
			{
				try
				{
					if (pop3Client.IsConnected)
					{
						pop3Client.Disconnect(quit: true);
					}
				}
				catch
				{
				}
				throw;
			}
		}
		catch (Exception ex2)
		{
			Logs.LogError(ex2, "");
			message = "POP3 connection failed: " + ex2.Message;
			WriteEmailReceiveLog(" CreateConnectedPop3Client()=> Error connect to mail server:" + message, emailUsersInfoId);
			return null;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
	}

	public static void SafeDisconnectMailServer(int euReceiveServerType, Imap4Client imapClient, Pop3Client pop3Client)
	{
		switch (euReceiveServerType)
		{
		case 1:
			if (pop3Client == null)
			{
				return;
			}
			break;
		case 2:
			if (imapClient == null)
			{
				return;
			}
			break;
		}
		try
		{
			switch (euReceiveServerType)
			{
			case 1:
				if (pop3Client.IsConnected)
				{
					pop3Client.Disconnect(quit: true);
				}
				break;
			case 2:
				if (imapClient.IsConnected)
				{
					imapClient.Disconnect();
				}
				break;
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "SafeDisconnectMailServer");
		}
	}

	public static void SaveEmailReceiveFolders(CRMSpEntities _db, int emailUsersInfoId, EmailspSelectEmailUsersInfoById_Result emailInfo, Mailbox folder, DateTime registerDate, string registerDatePersian, short month1, string appType, short year1, int userId, int defLangID, int? parentId = null, Dictionary<string, EmailspSelectEmailReceiveFolders_Result> folderDictionary = null)
	{
		try
		{
			if (emailInfo == null || (emailInfo != null && emailInfo.EmailUsersInfoId == 0))
			{
				emailInfo = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)_db.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
			}
			if (emailInfo == null || folder == null)
			{
				return;
			}
			string name = folder.Name;
			if (string.IsNullOrWhiteSpace(name))
			{
				return;
			}
			bool flag = true;
			int result = 0;
			if (folderDictionary != null)
			{
				string key = $"{parentId.GetValueOrDefault()}|{name}";
				if (folderDictionary.TryGetValue(key, out var value))
				{
					result = value.EmailReceiveFolderId;
					flag = false;
				}
			}
			if (flag)
			{
				ObjectParameter objectParameter = new ObjectParameter("insertedId", typeof(int));
				_db.EmailspInsertEmailReceiveFolders(name, emailInfo.EmailUsersInfoId, userId, registerDate, registerDatePersian, year1, month1, appType, defLangID, parentId, objectParameter);
				if (objectParameter != null && objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
				{
					int.TryParse(objectParameter.Value.ToString(), out result);
				}
			}
			if (result == 0)
			{
				return;
			}
			if (folderDictionary == null)
			{
				folderDictionary = new Dictionary<string, EmailspSelectEmailReceiveFolders_Result>(StringComparer.OrdinalIgnoreCase);
			}
			if (result > 0 && folderDictionary != null && flag)
			{
				string key2 = $"{parentId.GetValueOrDefault()}|{name}";
				if (!folderDictionary.ContainsKey(key2))
				{
					folderDictionary.Add(key2, new EmailspSelectEmailReceiveFolders_Result
					{
						EmailReceiveFolderId = result,
						ParentFolderId = parentId,
						FolderName = name
					});
				}
			}
			if (folder.SubMailboxes == null || ((CollectionBase)folder.SubMailboxes).Count <= 0)
			{
				return;
			}
			foreach (Mailbox item in (CollectionBase)folder.SubMailboxes)
			{
				if (!string.IsNullOrWhiteSpace(item.Name))
				{
					SaveEmailReceiveFolders(_db, emailUsersInfoId, emailInfo, item, registerDate, registerDatePersian, month1, appType, year1, userId, defLangID, result, folderDictionary);
				}
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "");
			string message = ex.Message;
			WriteEmailReceiveLog(" SaveEmailReceiveFolders()=> Error get folder from mail server:" + message, emailUsersInfoId);
		}
	}

	public static bool GetEmailReceiveFolders(int emailUsersInfoId, EmailspSelectEmailUsersInfoById_Result emailInfo, Imap4Client imapClient, ref string message)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		bool result = false;
		try
		{
			if (imapClient == null || !imapClient.IsConnected)
			{
				message = "IMAP connection is not available.";
				return false;
			}
			if (emailInfo == null || (emailInfo != null && emailInfo.EmailUsersInfoId == 0))
			{
				emailInfo = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)cRMSpEntities.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
			}
			if (emailInfo != null)
			{
				Dictionary<string, EmailspSelectEmailReceiveFolders_Result> dictionary = new Dictionary<string, EmailspSelectEmailReceiveFolders_Result>(StringComparer.OrdinalIgnoreCase);
				List<EmailspSelectEmailReceiveFolders_Result> list = Enumerable.ToList<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)cRMSpEntities.EmailspSelectEmailReceiveFolders(emailReceiveFolderId: 0, emailUsersInfoId: emailUsersInfoId, folderName: null));
				if (list != null)
				{
					foreach (EmailspSelectEmailReceiveFolders_Result item in list)
					{
						if (item != null)
						{
							string key = string.Format("{0}|{1}", item.ParentFolderId.GetValueOrDefault(), item.FolderName ?? "");
							if (!dictionary.ContainsKey(key))
							{
								dictionary.Add(key, item);
							}
						}
					}
				}
				if (2 == 2)
				{
					try
					{
						if (imapClient != null)
						{
							MailboxCollection mailboxes = imapClient.Mailboxes;
							if (mailboxes != null)
							{
								DateTime now = DateTime.Now;
								DateTime registerDate = now;
								string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
								short month = short.Parse(now.ToString("MM", new PersianCulture()));
								string appTypeMailServer = Configuration.AppTypeMailServer;
								short year = short.Parse(Financial.Get().Id.ToString());
								int userId = -3;
								if (UserLogin.CurrentUser != null)
								{
									userId = UserLogin.CurrentUser.UserId;
								}
								int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
								if (result2 <= 0)
								{
									result2 = 1065;
								}
								foreach (Mailbox item2 in (CollectionBase)mailboxes)
								{
									if (!string.IsNullOrWhiteSpace(item2.Name))
									{
										SaveEmailReceiveFolders(cRMSpEntities, emailUsersInfoId, emailInfo, item2, registerDate, registerDatePersian, month, appTypeMailServer, year, userId, result2, null, dictionary);
									}
								}
							}
							result = true;
						}
						else
						{
							message = "Not found Imap";
							WriteEmailReceiveLog(" GetEmailReceiveFolders()=> Error get folder from server IMAP:" + message, emailUsersInfoId);
						}
					}
					catch (Imap4Exception ex)
					{
						Logs.LogError(ex, "");
						message = $"Imap4 Error: {ex.Message}";
						WriteEmailReceiveLog(" GetEmailReceiveFolders()=> Error get folder from server IMAP:" + message, emailUsersInfoId);
					}
					catch (Exception ex2)
					{
						Logs.LogError(ex2, "");
						message = $"Failed: {ex2.Message}";
						WriteEmailReceiveLog(" GetEmailReceiveFolders()=> Error get folder from server IMAP:" + message, emailUsersInfoId);
					}
					WriteEmailReceiveLog(" GetEmailReceiveFolders()=> Get folder from server IMAP", emailUsersInfoId);
				}
			}
			else
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				WriteEmailReceiveLog(" GetEmailReceiveFolders()=> Error get folder from mail server:" + message, emailUsersInfoId);
			}
		}
		catch (Exception ex3)
		{
			Logs.LogError(ex3, "");
			message = ex3.Message;
			WriteEmailReceiveLog(" GetEmailReceiveFolders()=> Error get folder from mail server:" + message, emailUsersInfoId);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static long GetMessageCount(int emailUsersInfoId, EmailspSelectEmailUsersInfoById_Result emailInfo, Imap4Client imapClient, Pop3Client pop3Client, string folderName, DateTime fromDate, DateTime toDate, ref string message, ref FolderReceiveInfo folderReceiveInfo, bool useInJob = false, bool noSetDateToQry = false, bool fillFolderInfo = true)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		int num = 0;
		try
		{
			if (emailInfo == null || (emailInfo != null && emailInfo.EmailUsersInfoId == 0))
			{
				emailInfo = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)cRMSpEntities.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
			}
			if (emailInfo != null)
			{
				int num2 = 2;
				if (emailInfo.euReceiveServerType.GetValueOrDefault(2) == 1)
				{
					if (pop3Client == null || !pop3Client.IsConnected || !pop3Client.IsAuthenticated)
					{
						message = "POP3 connection is not available.";
						return 0L;
					}
				}
				else if (imapClient == null || !imapClient.IsConnected)
				{
					message = "IMAP connection is not available.";
					return 0L;
				}
				long result = 0L;
				long result2 = 0L;
				int num3 = 0;
				EmailspSelectEmailReceiveFolderLastUID_Result emailspSelectEmailReceiveFolderLastUID_Result = Enumerable.FirstOrDefault<EmailspSelectEmailReceiveFolderLastUID_Result>((IEnumerable<EmailspSelectEmailReceiveFolderLastUID_Result>)cRMSpIIEntities.EmailspSelectEmailReceiveFolderLastUID(emailUsersInfoId, 0, folderName));
				if (emailspSelectEmailReceiveFolderLastUID_Result != null)
				{
					if (useInJob)
					{
						long.TryParse(emailspSelectEmailReceiveFolderLastUID_Result.LastEmailUID.ToString(), out result);
						_ = emailspSelectEmailReceiveFolderLastUID_Result.LastEmailUIDStr;
					}
					long.TryParse(emailspSelectEmailReceiveFolderLastUID_Result.LastEmailUID.ToString(), out result2);
					if (num3 == 0)
					{
						num3 = emailspSelectEmailReceiveFolderLastUID_Result.EmailReceiveFolderId;
					}
				}
				switch (num2)
				{
				case 2:
					try
					{
						if (imapClient != null)
						{
							Mailbox mailbox = imapClient.SelectMailbox(folderName);
							if (mailbox != null)
							{
								HashSet<string> val = new HashSet<string>((IEqualityComparer<string>)StringComparer.Ordinal);
								List<EmailspSelectEmailReceiveByDate_Result> list = Enumerable.ToList<EmailspSelectEmailReceiveByDate_Result>((IEnumerable<EmailspSelectEmailReceiveByDate_Result>)cRMSpIIEntities.EmailspSelectEmailReceiveByDate(emailUsersInfoId, num3, fromDate, toDate));
								if (list != null && Enumerable.Any<EmailspSelectEmailReceiveByDate_Result>((IEnumerable<EmailspSelectEmailReceiveByDate_Result>)list))
								{
									foreach (EmailspSelectEmailReceiveByDate_Result item in list)
									{
										if (!string.IsNullOrWhiteSpace(item.MessageId))
										{
											val.Add(item.MessageId);
										}
									}
								}
								List<EmailspSelectEmailSendHeaderByDate_Result> list2 = Enumerable.ToList<EmailspSelectEmailSendHeaderByDate_Result>((IEnumerable<EmailspSelectEmailSendHeaderByDate_Result>)cRMSpIIEntities.EmailspSelectEmailSendHeaderByDate(emailUsersInfoId, fromDate, toDate));
								if (list2 != null && Enumerable.Any<EmailspSelectEmailSendHeaderByDate_Result>((IEnumerable<EmailspSelectEmailSendHeaderByDate_Result>)list2))
								{
									foreach (EmailspSelectEmailSendHeaderByDate_Result item2 in list2)
									{
										if (!string.IsNullOrWhiteSpace(item2.ReceiveMessageId))
										{
											val.Add(item2.ReceiveMessageId);
										}
									}
								}
								string text = fromDate.ToString("dd-MMM-yyyy", new CultureInfo("en-US"));
								string text2 = toDate.AddDays(1.0).ToString("dd-MMM-yyyy", new CultureInfo("en-US"));
								Fetch fetch = mailbox.Fetch;
								string query = $"UID {result + 1}:* " + "SINCE " + text + " BEFORE " + text2;
								if (noSetDateToQry)
								{
									query = $"UID {result + 1}:*";
								}
								folderReceiveInfo.Messages = new MessageCollection();
								folderReceiveInfo.Mailbox = mailbox;
								IList<int> list3 = null;
								if (fetch != null && fetch.ParentMailbox != null && fetch.ParentMailbox.MessageCount > 0)
								{
									try
									{
										list3 = mailbox.Search(query);
									}
									catch (Exception)
									{
										query = $"UID {result + 1}:*";
										list3 = mailbox.Search(query);
									}
								}
								int num4 = 0;
								if (list3 != null)
								{
									num4 = list3.Count;
								}
								WriteEmailReceiveLog(" GetMessageCount()=> Get count of UIDL email from mail server IMAP: " + num4, emailUsersInfoId);
								if (list3 != null)
								{
									for (int i = 0; i < list3.Count; i++)
									{
										int messageOrdinal = list3[i];
										long num5 = fetch.Uid(messageOrdinal);
										if (num5 <= result && useInJob)
										{
											continue;
										}
										if (num5 > result2)
										{
											result2 = num5;
										}
										bool flag = true;
										if (val.Count > 0)
										{
											try
											{
												byte[] bytes = fetch.Header(messageOrdinal);
												string @string = Encoding.UTF8.GetString(bytes);
												string text3 = null;
												Match val2 = Regex.Match(@string, "Message-ID:\\s*<(?<id>[^>]+)>", (RegexOptions)1);
												if (((Group)val2).Success)
												{
													text3 = ((Capture)val2.Groups["id"]).Value;
												}
												if (!string.IsNullOrWhiteSpace(text3) && val.Contains(text3))
												{
													flag = false;
													continue;
												}
											}
											catch (Imap4Exception ex3)
											{
												Logs.LogError(ex3, "");
												WriteEmailReceiveLog(" GetMessageCount()=> Error in get message headers email from mail server IMAP: " + ex3.Message, emailUsersInfoId);
											}
										}
										if (fillFolderInfo)
										{
											Message message2 = fetch.MessageObject(messageOrdinal);
											if (val.Count > 0 && message2 != null && !string.IsNullOrWhiteSpace(message2.MessageId) && val.Contains(message2.MessageId))
											{
												flag = false;
											}
											if (flag)
											{
												WriteEmailReceiveLog(" GetMessageCount()=> Not find UIDL In table EmailReceive from mail server IMAP " + num5, emailUsersInfoId);
												folderReceiveInfo.Messages.Add(message2);
											}
										}
										else if (flag)
										{
											num++;
										}
									}
								}
								if (folderReceiveInfo.Messages != null && fillFolderInfo)
								{
									folderReceiveInfo.MaxUId = result2;
									num = ((CollectionBase)folderReceiveInfo.Messages).Count;
								}
							}
							WriteEmailReceiveLog(" GetMessageCount()=> Get message count from server IMAP (foldername=" + folderName + "):" + num, emailUsersInfoId);
						}
						else
						{
							message = "Not found Imap";
							WriteEmailReceiveLog(" GetMessageCount()=> Error in get message count from server IMAP (foldername=" + folderName + "):" + message, emailUsersInfoId);
						}
					}
					catch (Imap4Exception ex4)
					{
						Logs.LogError(ex4, "");
						message = $"Imap4 Error: {ex4.Message}";
						WriteEmailReceiveLog(" GetMessageCount()=> Error in get message count from server IMAP (foldername=" + folderName + "):" + message, emailUsersInfoId);
					}
					catch (Exception ex5)
					{
						Logs.LogError(ex5, "");
						message = $"Failed: {ex5.Message}";
						WriteEmailReceiveLog(" GetMessageCount()=> Error in get message count from server IMAP (foldername=" + folderName + "):" + message, emailUsersInfoId);
					}
					break;
				case 1:
					try
					{
						num = pop3Client.GetMessageCount();
						WriteEmailReceiveLog(" GetMessageCount()=> Get message count from server POP3 (foldername=" + folderName + "):" + num, emailUsersInfoId);
					}
					catch (Exception ex)
					{
						if (pop3Client.IsConnected)
						{
							pop3Client.Disconnect(quit: true);
						}
						Logs.LogError(ex, "");
						message = $"POP3 Error: {ex.Message}";
						WriteEmailReceiveLog(" GetMessageCount()=> Error in get message count from server POP3 (foldername=" + folderName + "):" + message, emailUsersInfoId);
					}
					break;
				}
			}
			else
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				WriteEmailReceiveLog(" GetMessageCount()=> Error in get message count from mail serve (foldername=" + folderName + "):" + message, emailUsersInfoId);
			}
		}
		catch (Exception ex6)
		{
			Logs.LogError(ex6, "");
			message = ex6.Message;
			WriteEmailReceiveLog(" GetMessageCount()=> Error in get message count from mail serve: " + message, emailUsersInfoId);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIIEntities?.Dispose();
		}
		return num;
	}

	public static bool GetEmailReceive(int emailUsersInfoId, EmailspSelectEmailUsersInfoById_Result emailInfo, Imap4Client imapClient, Pop3Client pop3Client, string folderName, int emailReceiveFolderId, DateTime fromDate, DateTime toDate, double totalMsgCount, int getCountMsg, ref string message, bool useInJob = false, bool noSetDateToQry = false, FolderReceiveInfo folderReceiveInfo = null)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		bool result = false;
		try
		{
			WriteEmailReceiveLog(" GetEmailReceive()=> Get email receive from mail server (folder: " + folderName + "): Start ", emailUsersInfoId);
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appTypeMailServer = Configuration.AppTypeMailServer;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int num = -3;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserId;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			long result3 = 0L;
			long result4 = 0L;
			bool flag = false;
			EmailspSelectEmailReceiveFolderLastUID_Result emailspSelectEmailReceiveFolderLastUID_Result = Enumerable.FirstOrDefault<EmailspSelectEmailReceiveFolderLastUID_Result>((IEnumerable<EmailspSelectEmailReceiveFolderLastUID_Result>)cRMSpIIEntities.EmailspSelectEmailReceiveFolderLastUID(emailUsersInfoId, emailReceiveFolderId, folderName));
			if (emailspSelectEmailReceiveFolderLastUID_Result != null)
			{
				if (useInJob)
				{
					long.TryParse(emailspSelectEmailReceiveFolderLastUID_Result.LastEmailUID.ToString(), out result3);
					_ = emailspSelectEmailReceiveFolderLastUID_Result.LastEmailUIDStr;
				}
				long.TryParse(emailspSelectEmailReceiveFolderLastUID_Result.LastEmailUID.ToString(), out result4);
				if (emailReceiveFolderId == 0)
				{
					emailReceiveFolderId = emailspSelectEmailReceiveFolderLastUID_Result.EmailReceiveFolderId;
				}
			}
			if (emailInfo == null || (emailInfo != null && emailInfo.EmailUsersInfoId == 0))
			{
				emailInfo = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)cRMSpEntities.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
			}
			if (emailInfo != null)
			{
				int valueOrDefault = emailInfo.euReceiveServerType.GetValueOrDefault(2);
				if (valueOrDefault == 1)
				{
					if (pop3Client == null || !pop3Client.IsConnected || !pop3Client.IsAuthenticated)
					{
						message = "POP3 connection is not available.";
						return false;
					}
				}
				else if (imapClient == null || !imapClient.IsConnected)
				{
					message = "IMAP connection is not available.";
					return false;
				}
				WriteEmailReceiveLog(" GetEmailReceive()=> OnConnectMailServer()", emailUsersInfoId);
				switch (valueOrDefault)
				{
				case 1:
					try
					{
						int messageCount = pop3Client.GetMessageCount();
						WriteEmailReceiveLog(" GetEmailReceive()=> Get count email from mail server POP3:" + messageCount, emailUsersInfoId);
						if (messageCount <= 0)
						{
							break;
						}
						new List<MimeMessage>();
						HashSet<string> val = new HashSet<string>((IEqualityComparer<string>)StringComparer.Ordinal);
						HashSet<string> val2 = new HashSet<string>((IEqualityComparer<string>)StringComparer.Ordinal);
						List<EmailspSelectEmailReceiveByDate_Result> list = Enumerable.ToList<EmailspSelectEmailReceiveByDate_Result>((IEnumerable<EmailspSelectEmailReceiveByDate_Result>)cRMSpIIEntities.EmailspSelectEmailReceiveByDate(emailUsersInfoId, emailReceiveFolderId, null, null));
						if (list != null && Enumerable.Any<EmailspSelectEmailReceiveByDate_Result>((IEnumerable<EmailspSelectEmailReceiveByDate_Result>)list))
						{
							foreach (EmailspSelectEmailReceiveByDate_Result item in list)
							{
								if (!string.IsNullOrWhiteSpace(item.MessageId))
								{
									val.Add(item.MessageId);
								}
								if (!string.IsNullOrWhiteSpace(item.UID))
								{
									val2.Add(item.UID);
								}
							}
						}
						List<EmailspSelectEmailSendHeaderByDate_Result> list2 = Enumerable.ToList<EmailspSelectEmailSendHeaderByDate_Result>((IEnumerable<EmailspSelectEmailSendHeaderByDate_Result>)cRMSpIIEntities.EmailspSelectEmailSendHeaderByDate(emailUsersInfoId, null, null));
						if (list2 != null && Enumerable.Any<EmailspSelectEmailSendHeaderByDate_Result>((IEnumerable<EmailspSelectEmailSendHeaderByDate_Result>)list2))
						{
							foreach (EmailspSelectEmailSendHeaderByDate_Result item2 in list2)
							{
								if (!string.IsNullOrWhiteSpace(item2.ReceiveMessageId))
								{
									val.Add(item2.ReceiveMessageId);
								}
								if (!string.IsNullOrWhiteSpace(item2.ReceiveUID))
								{
									val2.Add(item2.ReceiveUID);
								}
							}
						}
						IList<string> messageUids = pop3Client.GetMessageUids();
						int num3 = 0;
						if (messageUids != null)
						{
							num3 = messageUids.Count;
						}
						WriteEmailReceiveLog(" GetEmailReceive()=> Get count of UIDL email from mail server POP3: " + num3, emailUsersInfoId);
						List<int> list3 = new List<int>();
						if (messageUids != null)
						{
							for (int j = 0; j < messageUids.Count; j++)
							{
								string text11 = messageUids[j];
								if (!string.IsNullOrWhiteSpace(text11) && val2.Contains(text11))
								{
									continue;
								}
								if (val.Count > 0)
								{
									try
									{
										HeaderList messageHeaders = pop3Client.GetMessageHeaders(j);
										if (messageHeaders != null && Enumerable.Any<MimeKit.Header>((IEnumerable<MimeKit.Header>)messageHeaders))
										{
											string text12 = messageHeaders[HeaderId.MessageId];
											if (!string.IsNullOrWhiteSpace(text12))
											{
												if (text12.StartsWith("<"))
												{
													text12 = text12.TrimStart(new char[1] { '<' });
												}
												if (text12.EndsWith(">"))
												{
													text12 = text12.TrimEnd(new char[1] { '>' });
												}
											}
											if (!string.IsNullOrWhiteSpace(text12) && val.Contains(text12))
											{
												continue;
											}
										}
									}
									catch (Imap4Exception ex4)
									{
										Logs.LogError(ex4, "");
										WriteEmailReceiveLog(" GetEmailReceive()=> Error in get message headers email from mail server POP3: " + ex4.Message, emailUsersInfoId);
										continue;
									}
								}
								WriteEmailReceiveLog(" GetEmailReceive()=> Not find UIDL In table EmailReceive from mail server POP3: " + text11, emailUsersInfoId);
								list3.Add(j);
							}
						}
						if (list3 == null || list3.Count <= 0)
						{
							break;
						}
						int num4 = list3.Count;
						WriteEmailReceiveLog(" GetEmailReceive()=> Count of email from mail server POP3: " + num4, emailUsersInfoId);
						foreach (int item3 in list3)
						{
							string text13 = messageUids[item3];
							MimeMessage message4 = pop3Client.GetMessage(item3);
							WriteEmailReceiveLog(" GetEmailReceive()=> Get one email from mail server POP3 by UIDL: " + text13, emailUsersInfoId);
							ObjectParameter objectParameter3 = new ObjectParameter("insertedEmailReceiveId", 0);
							ObjectParameter objectParameter4 = new ObjectParameter("insertedEmailSendHeaderId", typeof(int));
							DateTime now2 = DateTime.Now;
							string text14 = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
							try
							{
								now2 = message4.Date.DateTime;
								text14 = message4.Date.DateTime.ToString("yyyyMMdd", new PersianCulture());
							}
							catch (Exception ex5)
							{
								now2 = DateTime.Now;
								text14 = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
								Logs.LogError(ex5, "");
							}
							string text15 = "";
							if (message4.Bcc != null)
							{
								foreach (InternetAddress item4 in message4.Bcc)
								{
									if (item4 != null)
									{
										text15 = text15 + item4.Name + ((!string.IsNullOrEmpty(item4.Name)) ? ("(" + item4.Name + ")") : "") + ",";
									}
								}
								if (!string.IsNullOrEmpty(text15) && text15.EndsWith(","))
								{
									text15 = text15.Remove(text15.Length - 1);
								}
							}
							string text16 = "";
							if (message4.Cc != null)
							{
								foreach (InternetAddress item5 in message4.Cc)
								{
									if (item5 != null)
									{
										text16 = text16 + item5.Name + ((!string.IsNullOrEmpty(item5.Name)) ? ("(" + item5.Name + ")") : "") + ",";
									}
								}
								if (!string.IsNullOrEmpty(text16) && text16.EndsWith(","))
								{
									text16 = text16.Remove(text16.Length - 1);
								}
							}
							string text17 = "";
							if (message4.From != null)
							{
								foreach (InternetAddress item6 in message4.From)
								{
									text17 = text17 + item6.Name + ((!string.IsNullOrEmpty(item6.Name)) ? ("(" + item6.Name + ")") : "");
								}
							}
							string text18 = "";
							if (message4.To != null)
							{
								foreach (InternetAddress item7 in message4.To)
								{
									if (item7 != null)
									{
										text18 = text18 + item7.Name + ((!string.IsNullOrEmpty(item7.Name)) ? ("(" + item7.Name + ")") : "") + ",";
									}
								}
								if (!string.IsNullOrEmpty(text18) && text18.EndsWith(","))
								{
									text18 = text18.Remove(text18.Length - 1);
								}
							}
							string text19 = "";
							_ = message4.Priority;
							text19 = message4.Priority.ToString();
							string text20 = "";
							if (!string.IsNullOrWhiteSpace(message4.TextBody))
							{
								text20 = message4.TextBody;
							}
							string text21 = "";
							if (!string.IsNullOrWhiteSpace(message4.HtmlBody))
							{
								text21 = message4.HtmlBody;
							}
							if (!string.IsNullOrWhiteSpace(text21))
							{
								text21 = text21.ToSafeEmailBodyHtml();
							}
							bool flag3 = false;
							if (!string.IsNullOrWhiteSpace(folderName))
							{
								string text22 = folderName.ToUpper();
								if (text22.IndexOf("SENT", StringComparison.Ordinal) >= 0 || text22.IndexOf("SEND", StringComparison.Ordinal) >= 0)
								{
									flag3 = true;
								}
							}
							if (flag3)
							{
								cRMSpIIEntities.EmailspInsertEmailSendByMailServer(message4.Subject, text21, now2, text14, now2, text14, 0, emailInfo.EmailUsersInfoId, null, null, text20, message4.MessageId, text18, now2, text14, now2, text14, text15, text16, null, num, value, text, value3, value2, appTypeMailServer, result2, result2, objectParameter4, text13);
								if (objectParameter4.Value != null)
								{
									int result7 = 0;
									int.TryParse(objectParameter4.Value.ToString(), out result7);
									if (result7 > 0)
									{
										if (message4.Attachments != null)
										{
											GetEmailSendAttachment(null, message4, result7, emailUsersInfoId, folderName, emailReceiveFolderId, ref message, emailInfo, null, pop3Client);
										}
										WriteEmailReceiveLog(" GetEmailReceive()=> Insert email in table(EmailSend) from mail server POP3 by ID:" + result7, emailUsersInfoId);
									}
								}
							}
							else
							{
								cRMSpEntities.EmailspInsertEmailReceive(message4.MessageId, now2, text14, text17, text18, emailInfo.EmailUsersInfoId, text15, text16, message4.Subject, text20, text21, folderName, emailReceiveFolderId, value, text, text19, num, value, text, value3, value2, appTypeMailServer, result2, objectParameter3, text13);
								if (objectParameter3.Value != null)
								{
									int result8 = 0;
									int.TryParse(objectParameter3.Value.ToString(), out result8);
									if (result8 > 0)
									{
										if (message4.Attachments != null)
										{
											GetEmailReceiveAttachments(null, message4, result8, emailUsersInfoId, folderName, emailReceiveFolderId, ref message, emailInfo, null, pop3Client);
										}
										WriteEmailReceiveLog(" GetEmailReceive()=> Insert email in table(EmailReceive) from mail server POP3 by ID:" + result8, emailUsersInfoId);
									}
								}
							}
							num4++;
							int count2 = (int)((double)(num4 * 100) / totalMsgCount);
							ProgressHub.SendMessage(string.Format(Messages.msgRecEmailInfo, text17, text14, folderName), count2, num);
							if (emailInfo.euAutoDeleteReceivedEmail.GetValueOrDefault())
							{
								pop3Client.DeleteMessage(item3);
								WriteEmailReceiveLog(" GetEmailReceive()=> Delete email from mail server POP3 by  UIDL: " + text13, emailUsersInfoId);
							}
						}
					}
					catch (Exception ex6)
					{
						Logs.LogError(ex6, "");
						message = $"POP3 Error: {ex6.Message}";
						WriteEmailReceiveLog(" GetEmailReceive()=> Error get emailfrom mail server POP3:" + message, emailUsersInfoId);
					}
					break;
				case 2:
					try
					{
						if (imapClient != null && folderReceiveInfo != null)
						{
							Mailbox mailbox = folderReceiveInfo.Mailbox;
							result4 = folderReceiveInfo.MaxUId;
							WriteEmailReceiveLog(" GetEmailReceive()=> Select mailbox from mail server IMAP", emailUsersInfoId);
							if (mailbox != null)
							{
								MessageCollection messages = folderReceiveInfo.Messages;
								if (messages != null)
								{
									int num2 = getCountMsg;
									num2 = ((CollectionBase)messages).Count;
									WriteEmailReceiveLog(" GetEmailReceive()=> Count of email from mail server POP3: " + ((CollectionBase)messages).Count, emailUsersInfoId);
									for (int i = 0; i < ((CollectionBase)messages).Count; i++)
									{
										Message message2 = messages[i];
										WriteEmailReceiveLog(" GetEmailReceive()=> Get one email from list by MessageID: " + message2.MessageId, emailUsersInfoId);
										ObjectParameter objectParameter = new ObjectParameter("insertedEmailReceiveId", 0);
										ObjectParameter objectParameter2 = new ObjectParameter("insertedEmailSendHeaderId", typeof(int));
										string text2 = "";
										if (message2.Date == DateTime.MinValue)
										{
											message2.Date = DateTime.Now;
										}
										try
										{
											text2 = message2.Date.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
										}
										catch (Exception)
										{
											text2 = message2.Date.ToString("yyyyMMdd");
										}
										string text3 = "";
										if (message2.Bcc != null)
										{
											foreach (Address item8 in message2.Bcc)
											{
												if (item8 != null)
												{
													text3 = text3 + item8.Email + ((!string.IsNullOrEmpty(item8.Name)) ? ("(" + item8.Name + ")") : "") + ",";
												}
											}
											if (!string.IsNullOrEmpty(text3) && text3.EndsWith(","))
											{
												text3 = text3.Remove(text3.Length - 1);
											}
										}
										string text4 = "";
										if (message2.Cc != null)
										{
											foreach (Address item9 in message2.Cc)
											{
												if (item9 != null)
												{
													text4 = text4 + item9.Email + ((!string.IsNullOrEmpty(item9.Name)) ? ("(" + item9.Name + ")") : "") + ",";
												}
											}
											if (!string.IsNullOrEmpty(text4) && text4.EndsWith(","))
											{
												text4 = text4.Remove(text4.Length - 1);
											}
										}
										string text5 = "";
										if (message2.From != null)
										{
											text5 = text5 + message2.From.Email + ((!string.IsNullOrEmpty(message2.From.Name)) ? ("(" + message2.From.Name + ")") : "");
										}
										string text6 = "";
										if (message2.To != null)
										{
											foreach (Address item10 in message2.To)
											{
												if (item10 != null)
												{
													text6 = text6 + item10.Email + ((!string.IsNullOrEmpty(item10.Name)) ? ("(" + item10.Name + ")") : "") + ",";
												}
											}
											if (!string.IsNullOrEmpty(text6) && text6.EndsWith(","))
											{
												text6 = text6.Remove(text6.Length - 1);
											}
										}
										string text7 = "";
										_ = message2.Priority;
										text7 = message2.Priority.ToString();
										string text8 = "";
										if (message2.BodyText != null)
										{
											text8 = message2.BodyText.Text;
										}
										string text9 = "";
										if (message2.BodyHtml != null)
										{
											text9 = message2.BodyHtml.Text;
										}
										if (!string.IsNullOrWhiteSpace(text9))
										{
											text9 = text9.ToSafeEmailBodyHtml();
										}
										bool flag2 = false;
										if (!string.IsNullOrWhiteSpace(folderName))
										{
											string text10 = folderName.ToUpper();
											if (text10.IndexOf("SENT", StringComparison.Ordinal) >= 0 || text10.IndexOf("SEND", StringComparison.Ordinal) >= 0)
											{
												flag2 = true;
											}
										}
										if (flag2)
										{
											cRMSpIIEntities.EmailspInsertEmailSendByMailServer(message2.Subject, text9, message2.Date, text2, message2.Date, text2, 0, emailInfo.EmailUsersInfoId, null, null, text8, message2.MessageId, text6, message2.Date, text2, message2.Date, text2, text3, text4, null, num, value, text, value3, value2, appTypeMailServer, result2, result2, objectParameter2, null);
											if (objectParameter2.Value != null)
											{
												int result5 = 0;
												int.TryParse(objectParameter2.Value.ToString(), out result5);
												if (result5 > 0)
												{
													flag = true;
													if (message2.Attachments != null)
													{
														GetEmailSendAttachment(message2, null, result5, emailUsersInfoId, folderName, emailReceiveFolderId, ref message, emailInfo, imapClient, null);
													}
													WriteEmailReceiveLog(" GetEmailReceive()=> Insert email in table(EmailSend) from mail server IMAP by ID:" + result5, emailUsersInfoId);
												}
												else
												{
													flag = false;
												}
											}
										}
										else
										{
											cRMSpEntities.EmailspInsertEmailReceive(message2.MessageId, message2.Date, text2, text5, text6, emailInfo.EmailUsersInfoId, text3, text4, message2.Subject, text8, text9, folderName, emailReceiveFolderId, value, text, text7, num, value, text, value3, value2, appTypeMailServer, result2, objectParameter, null);
											if (objectParameter.Value != null)
											{
												int result6 = 0;
												int.TryParse(objectParameter.Value.ToString(), out result6);
												if (result6 > 0)
												{
													flag = true;
													if (message2.Attachments != null)
													{
														GetEmailReceiveAttachments(message2, null, result6, emailUsersInfoId, folderName, emailReceiveFolderId, ref message, emailInfo, imapClient, null);
													}
													WriteEmailReceiveLog(" GetEmailReceive()=> Insert email in table(EmailReceive) from mail server IMAP by ID:" + result6, emailUsersInfoId);
												}
												else
												{
													flag = false;
												}
											}
										}
										if (emailInfo.euAutoDeleteReceivedEmail.GetValueOrDefault())
										{
											Fetch fetch = mailbox.Fetch;
											Message message3 = fetch.MessageObject(i + 1);
											if (message3 != null && message3.MessageId == message2.MessageId)
											{
												mailbox.UidDeleteMessage(fetch.Uid(i + 1), expunge: true);
												WriteEmailReceiveLog(" GetEmailReceive()=> Delete email from mail server IMAP by  UIDL: " + (i + 1), emailUsersInfoId);
											}
										}
										num2++;
										int count = (int)((double)(num2 * 100) / totalMsgCount);
										ProgressHub.SendMessage(string.Format(Messages.msgRecEmailInfo, text5, message2.Date.ToString("yyyy/MM/dd HH:mm:ss"), folderName), count, num);
									}
									if (((CollectionBase)messages).Count <= 0 && result4 > result3)
									{
										flag = true;
									}
								}
								else if (result4 > result3)
								{
									flag = true;
								}
								if (flag)
								{
									cRMSpIIEntities.EmailspUpdateEmailReceiveFolderLastUID(emailReceiveFolderId, result4, "", num, value, text, value3, value2, appTypeMailServer);
									WriteEmailReceiveLog(" GetEmailReceive()=>Update EmailReceiveFolder LastUID from mail server IMAP", emailUsersInfoId);
								}
								result = (string.IsNullOrWhiteSpace(message) ? true : false);
							}
							else
							{
								message = string.Format(Messages.msgErrorIsNotFound, "MailBox");
								WriteEmailReceiveLog(" GetEmailReceive()=> Error get email from IMAP:" + message, emailUsersInfoId);
							}
						}
						else
						{
							message = "Not found Imap";
							WriteEmailReceiveLog(" GetEmailReceive()=> Error get email from IMAP:" + message, emailUsersInfoId);
						}
					}
					catch (Imap4Exception ex2)
					{
						Logs.LogError(ex2, "");
						message = $"Imap4 Error: {ex2.Message}";
						WriteEmailReceiveLog(" GetEmailReceive()=> Error get email from IMAP:" + message, emailUsersInfoId);
					}
					catch (Exception ex3)
					{
						Logs.LogError(ex3, "");
						message = $"Failed: {ex3.Message}";
						WriteEmailReceiveLog(" GetEmailReceive()=> Error get email from IMAP:" + message, emailUsersInfoId);
					}
					finally
					{
						WriteEmailReceiveLog(" GetEmailReceive()=> OnDisconnectMailServer()", emailUsersInfoId);
					}
					break;
				}
				DeleteSrvrEmailAfterDay(emailInfo, imapClient, pop3Client, ref message);
			}
			else
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				WriteEmailReceiveLog(" GetEmailReceive()=> Error get emailfrom mail server:" + message, emailUsersInfoId);
			}
			WriteEmailReceiveLog(" GetEmailReceive()=> Get email receive from mail server (folder: " + folderName + "): End ", emailUsersInfoId);
		}
		catch (Exception ex7)
		{
			Logs.LogError(ex7, "");
			message = ex7.Message;
			WriteEmailReceiveLog(" GetEmailReceive()=> Error get emailfrom mail server:" + message, emailUsersInfoId);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIIEntities?.Dispose();
			WriteEmailReceiveLog(" GetEmailReceive()=> OnDisconnectMailServer()", emailUsersInfoId);
		}
		return result;
	}

	public static bool GetEmailReceiveAttachments(Message msg, MimeMessage pop3Msg, int emailRecId, int emailUsersInfoId, string folderName, int emailReceiveFolderId, ref string message, EmailspSelectEmailUsersInfoById_Result emailInfo, Imap4Client imapClient, Pop3Client pop3Client)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		bool result = false;
		try
		{
			WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Get file from mail server (folder: " + folderName + "): Start ", emailUsersInfoId);
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appTypeMailServer = Configuration.AppTypeMailServer;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int value4 = -3;
			if (UserLogin.CurrentUser != null)
			{
				value4 = UserLogin.CurrentUser.UserId;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			if (emailInfo == null || (emailInfo != null && emailInfo.EmailUsersInfoId == 0))
			{
				emailInfo = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)cRMSpEntities.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
			}
			if (emailInfo != null)
			{
				int valueOrDefault = emailInfo.euReceiveServerType.GetValueOrDefault(2);
				if (valueOrDefault == 1)
				{
					if (pop3Client == null || !pop3Client.IsConnected || !pop3Client.IsAuthenticated)
					{
						message = "POP3 connection is not available.";
						return false;
					}
				}
				else if (imapClient == null || !imapClient.IsConnected)
				{
					message = "IMAP connection is not available.";
					return false;
				}
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string pathFtp = Configuration.PathFtp;
				string userNameFtp = Configuration.UserNameFtp;
				string passwordFtp = Configuration.PasswordFtp;
				bool usePassiveFtp = Configuration.UsePassiveFtp;
				switch (valueOrDefault)
				{
				case 1:
					try
					{
						if (pop3Client != null)
						{
							if (pop3Msg != null)
							{
								if (emailRecId > 0 && pop3Msg.Attachments != null)
								{
									if (Enumerable.Count<MimeEntity>(pop3Msg.Attachments) <= 0)
									{
										return true;
									}
									WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Conut of file from mail server POP3 :" + Enumerable.Count<MimeEntity>(pop3Msg.Attachments), emailUsersInfoId);
									int num2 = 0;
									foreach (MimeEntity attachment in pop3Msg.Attachments)
									{
										num2++;
										if (attachment == null)
										{
											continue;
										}
										string text4 = attachment.ContentDisposition?.FileName ?? attachment?.ContentType.Name;
										_ = attachment.ContentType;
										string mimeType2 = "";
										if (attachment.ContentType != null)
										{
											mimeType2 = attachment.ContentType.MimeType;
										}
										if (IsBlockedAttachment(text4))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text4, emailUsersInfoId);
											continue;
										}
										if (IsSuspiciousDoubleExtension(text4))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text4, emailUsersInfoId);
											continue;
										}
										if (IsBlockedMimeType(mimeType2))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text4, emailUsersInfoId);
											continue;
										}
										string text5 = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
										string[] array2 = (text5 ?? "").Split(new char[1] { '.' });
										string text6 = "";
										if (array2 != null)
										{
											text6 = array2[^1];
										}
										ObjectParameter objectParameter2 = new ObjectParameter("insertedEmailReceiveAttachmentId", 0);
										cRMSpEntities.EmailspInsertEmailReceiveAttachments(emailRecId, attachment.ContentId, text5, "", text6, value4, value, registerDatePersian, value3, value2, appTypeMailServer, result2, objectParameter2);
										int result5 = 0;
										if (objectParameter2.Value != null)
										{
											int.TryParse(objectParameter2.Value.ToString(), out result5);
										}
										if (result5 > 0)
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Inser file in table from mail server POP3 ", emailUsersInfoId);
											string mainDirectoryPath2 = Configuration.MainDirectoryPath;
											string recEmailDirectoryPath2 = Configuration.RecEmailDirectoryPath;
											recEmailDirectoryPath2 = (recEmailDirectoryPath2.EndsWith("/") ? recEmailDirectoryPath2.TrimEnd(new char[1] { '/' }) : recEmailDirectoryPath2);
											bool flag5 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath2, recEmailDirectoryPath2, usePassiveFtp);
											if (!flag5)
											{
												flag5 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, recEmailDirectoryPath2, usePassiveFtp);
											}
											mainDirectoryPath2 = Configuration.MainDirectoryPath + Configuration.RecEmailDirectoryPath;
											bool flag6 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath2, emailReceiveFolderId.ToString(), usePassiveFtp);
											if (!flag6)
											{
												flag6 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath2, emailReceiveFolderId.ToString(), usePassiveFtp);
											}
											mainDirectoryPath2 = Configuration.MainDirectoryPath + Configuration.RecEmailDirectoryPath + emailReceiveFolderId + "/";
											bool flag7 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath2, emailUsersInfoId.ToString(), usePassiveFtp);
											if (!flag7)
											{
												flag7 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath2, emailUsersInfoId.ToString(), usePassiveFtp);
											}
											mainDirectoryPath2 = Configuration.MainDirectoryPath + Configuration.RecEmailDirectoryPath + emailReceiveFolderId + "/" + emailUsersInfoId + "/";
											bool flag8 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath2, emailRecId.ToString(), usePassiveFtp);
											if (!flag8)
											{
												flag8 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath2, emailRecId.ToString(), usePassiveFtp);
											}
											if (flag5 && flag6 && flag7 && flag8)
											{
												string text7 = emailRecId + "-" + result5 + "." + text6;
												mainDirectoryPath2 = Configuration.MainDirectoryPath + Configuration.RecEmailDirectoryPath + emailReceiveFolderId + "/" + emailUsersInfoId + "/" + emailRecId + "/" + text7;
												string text8 = Configuration.HostTempFilesPath + "/" + Configuration.RecEmailDirectoryPath + emailReceiveFolderId + "/" + emailUsersInfoId + "/" + emailRecId;
												text8 = HostingEnvironment.MapPath(text8);
												if (!System.IO.Directory.Exists(text8))
												{
													System.IO.Directory.CreateDirectory(text8);
													CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
												}
												text8 = text8 + "/" + text7;
												if (!System.IO.File.Exists(text8))
												{
													using FileStream stream = System.IO.File.Create(text8);
													if (attachment is MessagePart)
													{
														((MessagePart)attachment).Message.WriteTo(stream);
													}
													else
													{
														((MimeKit.MimePart)attachment).Content.DecodeTo(stream);
													}
												}
												if (System.IO.File.Exists(text8))
												{
													if (!FileSignatureValidator.IsValidFileSignature(text8))
													{
														try
														{
															System.IO.File.Delete(text8);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result5);
														}
														catch (Exception ex10)
														{
															Logs.LogError(ex10, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text4 + " - Attachment rejected (Invalid File Signature): " + text8, emailUsersInfoId);
														continue;
													}
													if (FileSignatureValidator.HasDoubleExtension(text4))
													{
														try
														{
															System.IO.File.Delete(text8);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result5);
														}
														catch (Exception ex11)
														{
															Logs.LogError(ex11, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text4, emailUsersInfoId);
														continue;
													}
													if (Path.GetExtension(text8).Equals(".zip", StringComparison.OrdinalIgnoreCase) && FileSignatureValidator.IsZipBomb(text8))
													{
														try
														{
															System.IO.File.Delete(text8);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result5);
														}
														catch (Exception ex12)
														{
															Logs.LogError(ex12, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text4 + " - Attachment rejected (Invalid File Signature): " + text8, emailUsersInfoId);
														continue;
													}
													if (!WindowsDefenderScanner.Scan(text8, out var result6))
													{
														System.IO.File.Delete(text8);
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text4 + " - Virus Detected : " + result6, emailUsersInfoId);
														continue;
													}
												}
												if (System.IO.File.Exists(text8))
												{
													if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath2, text8, usePassiveFtp))
													{
														cRMSpEntities.EmailspUpdateEmailReceiveAttachments(result5, text5, mainDirectoryPath2, text6, value4, value, registerDatePersian, value3, value2, appTypeMailServer);
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Upload file in fpt from mail server POP3 ", emailUsersInfoId);
														continue;
													}
													Exception ex13 = new Exception(Messages.frmErrorInSendingFile + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + mainDirectoryPath2);
													Logs.LogError(ex13, "");
													try
													{
														cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result5);
													}
													catch (Exception ex14)
													{
														Logs.LogError(ex14, "");
													}
													message = ex13.Message;
													WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Upload file in FTP in mail server POP3:" + message, emailUsersInfoId);
												}
												else
												{
													message = Messages.msgErrorNotFilePath;
													WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Upload file in FTP in mail server POP3:" + message, emailUsersInfoId);
												}
											}
											else
											{
												Exception ex15 = new Exception(Messages.msgErrorCreateFolderInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + mainDirectoryPath2);
												Logs.LogError(ex15, "");
												try
												{
													cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result5);
												}
												catch (Exception ex16)
												{
													Logs.LogError(ex16, "");
												}
												message = Messages.frmErrorInSendingFile + "(" + ex15.Message + ")";
												WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Upload file in FTP in mail server POP3:" + message, emailUsersInfoId);
											}
										}
										else
										{
											message = message + Messages.frmErrorInSendingFile + "( in file:" + num2 + ")";
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Upload file in FTP in mail server POP3:" + message, emailUsersInfoId);
										}
									}
								}
								result = (string.IsNullOrEmpty(message) ? true : false);
							}
							else
							{
								message = string.Format(Messages.msgErrorIsNotFound, "MailBox");
								WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
							}
						}
						else
						{
							message = "Not found Pop3";
							WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
						}
					}
					catch (Pop3CommandException ex17)
					{
						Logs.LogError(ex17, "");
						message = $"Pop3 Error: {ex17.Message}";
						WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
					}
					catch (Pop3ProtocolException ex18)
					{
						Logs.LogError(ex18, "");
						message = $"Pop3 Error: {ex18.Message}";
						WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
					}
					catch (Exception ex19)
					{
						Logs.LogError(ex19, "");
						message = $"Failed: {ex19.Message}";
						WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
					}
					break;
				case 2:
					if (valueOrDefault != 2)
					{
						break;
					}
					try
					{
						if (imapClient != null)
						{
							if (msg != null)
							{
								if (emailRecId > 0 && msg.Attachments != null)
								{
									if (((CollectionBase)msg.Attachments).Count <= 0)
									{
										return true;
									}
									WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Conut of file from mail server IMAP :" + ((CollectionBase)msg.Attachments).Count, emailUsersInfoId);
									int num = 0;
									foreach (ActiveUp.Net.Mail.MimePart item in (CollectionBase)msg.Attachments)
									{
										num++;
										if (item == null)
										{
											continue;
										}
										string contentName = item.ContentName;
										_ = item.ContentType;
										string mimeType = "";
										if (item.ContentType != null)
										{
											mimeType = item.ContentType.MimeType;
										}
										if (IsBlockedAttachment(contentName))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName, emailUsersInfoId);
											continue;
										}
										if (IsSuspiciousDoubleExtension(contentName))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName, emailUsersInfoId);
											continue;
										}
										if (IsBlockedMimeType(mimeType))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName, emailUsersInfoId);
											continue;
										}
										string contentName2 = item.ContentName;
										string[] array = (contentName2 ?? "").Split(new char[1] { '.' });
										string text = "";
										if (array != null)
										{
											text = array[^1];
										}
										ObjectParameter objectParameter = new ObjectParameter("insertedEmailReceiveAttachmentId", 0);
										cRMSpEntities.EmailspInsertEmailReceiveAttachments(emailRecId, item.ContentId, contentName2, "", text, value4, value, registerDatePersian, value3, value2, appTypeMailServer, result2, objectParameter);
										int result3 = 0;
										if (objectParameter.Value != null)
										{
											int.TryParse(objectParameter.Value.ToString(), out result3);
										}
										if (result3 > 0)
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Inser file in table from mail server IMAP ", emailUsersInfoId);
											string mainDirectoryPath = Configuration.MainDirectoryPath;
											string recEmailDirectoryPath = Configuration.RecEmailDirectoryPath;
											recEmailDirectoryPath = (recEmailDirectoryPath.EndsWith("/") ? recEmailDirectoryPath.TrimEnd(new char[1] { '/' }) : recEmailDirectoryPath);
											bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, recEmailDirectoryPath, usePassiveFtp);
											if (!flag)
											{
												flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, recEmailDirectoryPath, usePassiveFtp);
											}
											mainDirectoryPath = Configuration.MainDirectoryPath + Configuration.RecEmailDirectoryPath;
											bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, emailReceiveFolderId.ToString(), usePassiveFtp);
											if (!flag2)
											{
												flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, emailReceiveFolderId.ToString(), usePassiveFtp);
											}
											mainDirectoryPath = Configuration.MainDirectoryPath + Configuration.RecEmailDirectoryPath + emailReceiveFolderId + "/";
											bool flag3 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, emailUsersInfoId.ToString(), usePassiveFtp);
											if (!flag3)
											{
												flag3 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, emailUsersInfoId.ToString(), usePassiveFtp);
											}
											mainDirectoryPath = Configuration.MainDirectoryPath + Configuration.RecEmailDirectoryPath + emailReceiveFolderId + "/" + emailUsersInfoId + "/";
											bool flag4 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, emailRecId.ToString(), usePassiveFtp);
											if (!flag4)
											{
												flag4 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, emailRecId.ToString(), usePassiveFtp);
											}
											if (flag && flag2 && flag3 && flag4)
											{
												string text2 = emailRecId + "-" + result3 + "." + text;
												mainDirectoryPath = Configuration.MainDirectoryPath + Configuration.RecEmailDirectoryPath + emailReceiveFolderId + "/" + emailUsersInfoId + "/" + emailRecId + "/" + text2;
												string text3 = Configuration.HostTempFilesPath + "/" + Configuration.RecEmailDirectoryPath + emailReceiveFolderId + "/" + emailUsersInfoId + "/" + emailRecId;
												text3 = HostingEnvironment.MapPath(text3);
												if (!System.IO.Directory.Exists(text3))
												{
													System.IO.Directory.CreateDirectory(text3);
													CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
												}
												text3 = text3 + "/" + text2;
												if (!System.IO.File.Exists(text3))
												{
													item.StoreToFile(text3);
												}
												if (System.IO.File.Exists(text3))
												{
													if (!FileSignatureValidator.IsValidFileSignature(text3))
													{
														try
														{
															System.IO.File.Delete(text3);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result3);
														}
														catch (Exception ex)
														{
															Logs.LogError(ex, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName + " - Attachment rejected (Invalid File Signature): " + text3, emailUsersInfoId);
														continue;
													}
													if (FileSignatureValidator.HasDoubleExtension(contentName))
													{
														try
														{
															System.IO.File.Delete(text3);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result3);
														}
														catch (Exception ex2)
														{
															Logs.LogError(ex2, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName, emailUsersInfoId);
														continue;
													}
													if (Path.GetExtension(text3).Equals(".zip", StringComparison.OrdinalIgnoreCase) && FileSignatureValidator.IsZipBomb(text3))
													{
														try
														{
															System.IO.File.Delete(text3);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result3);
														}
														catch (Exception ex3)
														{
															Logs.LogError(ex3, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName + " - Attachment rejected (Invalid File Signature): " + text3, emailUsersInfoId);
														continue;
													}
													if (!WindowsDefenderScanner.Scan(text3, out var result4))
													{
														System.IO.File.Delete(text3);
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName + " - Virus Detected : " + result4, emailUsersInfoId);
														continue;
													}
												}
												if (System.IO.File.Exists(text3))
												{
													if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, text3, usePassiveFtp))
													{
														cRMSpEntities.EmailspUpdateEmailReceiveAttachments(result3, contentName2, mainDirectoryPath, text, value4, value, registerDatePersian, value3, value2, appTypeMailServer);
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Upload file in fpt from mail server IMAP ", emailUsersInfoId);
														continue;
													}
													Exception ex4 = new Exception(Messages.frmErrorInSendingFile + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + mainDirectoryPath);
													Logs.LogError(ex4, "");
													try
													{
														cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result3);
													}
													catch (Exception ex5)
													{
														Logs.LogError(ex5, "");
													}
													message = ex4.Message;
													WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Upload file in FTP in mail server IMAP:" + message, emailUsersInfoId);
												}
												else
												{
													message = Messages.msgErrorNotFilePath;
													WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Upload file in FTP in mail server IMAP:" + message, emailUsersInfoId);
												}
											}
											else
											{
												Exception ex6 = new Exception(Messages.msgErrorCreateFolderInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + mainDirectoryPath);
												Logs.LogError(ex6, "");
												try
												{
													cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result3);
												}
												catch (Exception ex7)
												{
													Logs.LogError(ex7, "");
												}
												message = Messages.frmErrorInSendingFile + "(" + ex6.Message + ")";
												WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Upload file in FTP in mail server IMAP:" + message, emailUsersInfoId);
											}
										}
										else
										{
											message = message + Messages.frmErrorInSendingFile + "( in file:" + num + ")";
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server IMAP:" + message, emailUsersInfoId);
										}
									}
								}
								result = (string.IsNullOrEmpty(message) ? true : false);
							}
							else
							{
								message = string.Format(Messages.msgErrorIsNotFound, "MailBox");
								WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server IMAP:" + message, emailUsersInfoId);
							}
						}
						else
						{
							message = "Not found Imap";
							WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server IMAP:" + message, emailUsersInfoId);
						}
					}
					catch (Imap4Exception ex8)
					{
						Logs.LogError(ex8, "");
						message = $"Imap4 Error: {ex8.Message}";
						WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server IMAP:" + message, emailUsersInfoId);
					}
					catch (Exception ex9)
					{
						Logs.LogError(ex9, "");
						message = $"Failed: {ex9.Message}";
						WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server IMAP:" + message, emailUsersInfoId);
					}
					break;
				}
			}
			else
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server:" + message, emailUsersInfoId);
			}
			WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Get file from mail server (folder: " + folderName + "): End ", emailUsersInfoId);
		}
		catch (Exception ex20)
		{
			Logs.LogError(ex20, "");
			message = ex20.Message;
			WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file from mail server:" + message, emailUsersInfoId);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool GetEmailSendAttachment(Message msg, MimeMessage pop3Msg, int emailSendId, int emailUsersInfoId, string folderName, int emailReceiveFolderId, ref string message, EmailspSelectEmailUsersInfoById_Result emailInfo, Imap4Client imapClient, Pop3Client pop3Client)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		bool result = false;
		try
		{
			WriteEmailReceiveLog(" GetEmailSendAttachment()=> Get file from mail server (folder: " + folderName + "): Start ", emailUsersInfoId);
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appTypeMailServer = Configuration.AppTypeMailServer;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int value4 = -3;
			if (UserLogin.CurrentUser != null)
			{
				value4 = UserLogin.CurrentUser.UserId;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			if (emailInfo == null || (emailInfo != null && emailInfo.EmailUsersInfoId == 0))
			{
				emailInfo = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)cRMSpEntities.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
			}
			EmailspSelectEmailSetting_Result emailspSelectEmailSetting_Result = Enumerable.FirstOrDefault<EmailspSelectEmailSetting_Result>((IEnumerable<EmailspSelectEmailSetting_Result>)cRMSpEntities.EmailspSelectEmailSetting("", ""));
			if (emailInfo != null && emailspSelectEmailSetting_Result != null)
			{
				int valueOrDefault = emailInfo.euReceiveServerType.GetValueOrDefault(2);
				if (valueOrDefault == 1)
				{
					if (pop3Client == null || !pop3Client.IsConnected || !pop3Client.IsAuthenticated)
					{
						message = "POP3 connection is not available.";
						return false;
					}
				}
				else if (imapClient == null || !imapClient.IsConnected)
				{
					message = "IMAP connection is not available.";
					return false;
				}
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string pathFtp = Configuration.PathFtp;
				string userNameFtp = Configuration.UserNameFtp;
				string passwordFtp = Configuration.PasswordFtp;
				bool usePassiveFtp = Configuration.UsePassiveFtp;
				switch (valueOrDefault)
				{
				case 1:
					try
					{
						if (pop3Client != null)
						{
							if (pop3Msg != null)
							{
								if (emailSendId > 0 && pop3Msg.Attachments != null)
								{
									if (Enumerable.Count<MimeEntity>(pop3Msg.Attachments) <= 0)
									{
										return true;
									}
									WriteEmailReceiveLog(" GetEmailSendAttachment()=> Conut of file from mail server POP3 :" + Enumerable.Count<MimeEntity>(pop3Msg.Attachments), emailUsersInfoId);
									int num2 = 0;
									foreach (MimeEntity attachment in pop3Msg.Attachments)
									{
										num2++;
										if (attachment == null)
										{
											continue;
										}
										string text7 = attachment.ContentDisposition?.FileName ?? attachment?.ContentType.Name;
										_ = attachment.ContentType;
										string mimeType2 = "";
										if (attachment.ContentType != null)
										{
											mimeType2 = attachment.ContentType.MimeType;
										}
										if (IsBlockedAttachment(text7))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text7, emailUsersInfoId);
											continue;
										}
										if (IsSuspiciousDoubleExtension(text7))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text7, emailUsersInfoId);
											continue;
										}
										if (IsBlockedMimeType(mimeType2))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text7, emailUsersInfoId);
											continue;
										}
										string text8 = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
										string[] array2 = text8.Split(new char[1] { '.' });
										string text9 = "";
										if (array2 != null)
										{
											text9 = array2[^1];
										}
										ObjectParameter objectParameter2 = new ObjectParameter("insertedEmailSendAttachmentId", typeof(int));
										cRMSpIIEntities.EmailspInsertEmailSendAttachmentByMailServer(emailSendId, text8, "", attachment.ContentId, value4, value, registerDatePersian, value3, value2, appTypeMailServer, result2, objectParameter2);
										int result5 = 0;
										if (objectParameter2.Value != null)
										{
											int.TryParse(objectParameter2.Value.ToString(), out result5);
										}
										if (result5 > 0)
										{
											WriteEmailReceiveLog(" GetEmailSendAttachment()=> Inser file in table from mail server POP3 ", emailUsersInfoId);
											string text10 = "";
											string text11 = emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp ?? "";
											if (!text11.StartsWith("/"))
											{
												text11 = "/" + text11;
											}
											if (!text11.EndsWith("/"))
											{
												text11 += "/";
											}
											bool flag5 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, text11, usePassiveFtp);
											if (!flag5)
											{
												flag5 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, text11, usePassiveFtp);
											}
											text10 += text11;
											bool flag6 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, emailReceiveFolderId.ToString(), usePassiveFtp);
											if (!flag6)
											{
												flag6 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, emailReceiveFolderId.ToString(), usePassiveFtp);
											}
											text10 = text10 + emailReceiveFolderId + "/";
											bool flag7 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, emailUsersInfoId.ToString(), usePassiveFtp);
											if (!flag7)
											{
												flag7 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, emailUsersInfoId.ToString(), usePassiveFtp);
											}
											text10 = text10 + emailUsersInfoId + "/";
											bool flag8 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, emailSendId.ToString(), usePassiveFtp);
											if (!flag8)
											{
												flag8 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text10, emailSendId.ToString(), usePassiveFtp);
											}
											if (flag5 && flag6 && flag7 && flag8)
											{
												string text12 = emailSendId + "-" + result5 + "." + text9;
												text10 = text10 + emailSendId + "/" + text12;
												string text13 = Configuration.HostTempFilesPath + text11 + emailReceiveFolderId + "/" + emailUsersInfoId + "/" + emailSendId;
												text13 = HostingEnvironment.MapPath(text13);
												if (!System.IO.Directory.Exists(text13))
												{
													System.IO.Directory.CreateDirectory(text13);
													CRM.General.IO.Directory.SetFullControlForEveryOne(text13);
												}
												text13 = text13 + "/" + text12;
												if (!System.IO.File.Exists(text13))
												{
													using FileStream stream = System.IO.File.Create(text13);
													if (attachment is MessagePart)
													{
														((MessagePart)attachment).Message.WriteTo(stream);
													}
													else
													{
														((MimeKit.MimePart)attachment).Content.DecodeTo(stream);
													}
												}
												if (System.IO.File.Exists(text13))
												{
													if (!FileSignatureValidator.IsValidFileSignature(text13))
													{
														try
														{
															System.IO.File.Delete(text13);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result5);
														}
														catch (Exception ex10)
														{
															Logs.LogError(ex10, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text7 + " - Attachment rejected (Invalid File Signature): " + text13, emailUsersInfoId);
														continue;
													}
													if (FileSignatureValidator.HasDoubleExtension(text7))
													{
														try
														{
															System.IO.File.Delete(text13);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result5);
														}
														catch (Exception ex11)
														{
															Logs.LogError(ex11, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text7, emailUsersInfoId);
														continue;
													}
													if (Path.GetExtension(text13).Equals(".zip", StringComparison.OrdinalIgnoreCase) && FileSignatureValidator.IsZipBomb(text13))
													{
														try
														{
															System.IO.File.Delete(text13);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result5);
														}
														catch (Exception ex12)
														{
															Logs.LogError(ex12, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text7 + " - Attachment rejected (Invalid File Signature): " + text13, emailUsersInfoId);
														continue;
													}
													if (!WindowsDefenderScanner.Scan(text13, out var result6))
													{
														System.IO.File.Delete(text13);
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + text7 + " - Virus Detected : " + result6, emailUsersInfoId);
														continue;
													}
												}
												if (System.IO.File.Exists(text13))
												{
													if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text10, text13, usePassiveFtp))
													{
														string text14 = emailspSelectEmailSetting_Result.EmailsAttachFilePath ?? "";
														if (!text14.EndsWith("\\"))
														{
															text14 += "\\";
														}
														text14 = text14 + emailReceiveFolderId + "\\" + emailUsersInfoId + "\\" + emailSendId + "\\" + text8;
														cRMSpEntities.EmailspUpdateEmailSendAttachment(result5, emailSendId, text8, text14, value, registerDatePersian, appTypeMailServer);
														WriteEmailReceiveLog(" GetEmailSendAttachment()=> Upload file in fpt from mail server POP3 ", emailUsersInfoId);
													}
													else
													{
														Exception ex13 = new Exception(Messages.frmErrorInSendingFile + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text10);
														Logs.LogError(ex13, "");
														try
														{
															cRMSpEntities.EmailspDeleteEmailSendAttachment(result5);
														}
														catch (Exception ex14)
														{
															Logs.LogError(ex14, "");
														}
														message = ex13.Message;
														WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Upload file in FTP in mail server POP3:" + message, emailUsersInfoId);
													}
												}
												else
												{
													message = Messages.msgErrorNotFilePath;
													WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Upload file in FTP in mail server POP3:" + message, emailUsersInfoId);
												}
											}
											else
											{
												Exception ex15 = new Exception(Messages.msgErrorCreateFolderInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text10);
												Logs.LogError(ex15, "");
												try
												{
													cRMSpEntities.EmailspDeleteEmailSendAttachment(result5);
												}
												catch (Exception ex16)
												{
													Logs.LogError(ex16, "");
												}
												message = Messages.frmErrorInSendingFile + "(" + ex15.Message + ")";
												WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Upload file in FTP in mail server POP3:" + message, emailUsersInfoId);
											}
										}
										else
										{
											message = message + Messages.frmErrorInSendingFile + "( in file:" + num2 + ")";
											WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
										}
									}
								}
								result = (string.IsNullOrEmpty(message) ? true : false);
							}
							else
							{
								message = string.Format(Messages.msgErrorIsNotFound, "MailBox");
								WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
							}
						}
						else
						{
							message = "Not found Pop3";
							WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
						}
					}
					catch (Pop3CommandException ex17)
					{
						Logs.LogError(ex17, "");
						message = $"Pop3 Error: {ex17.Message}";
						WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
					}
					catch (Pop3ProtocolException ex18)
					{
						Logs.LogError(ex18, "");
						message = $"Pop3 Error: {ex18.Message}";
						WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
					}
					catch (Exception ex19)
					{
						Logs.LogError(ex19, "");
						message = $"Failed: {ex19.Message}";
						WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server POP3:" + message, emailUsersInfoId);
					}
					break;
				case 2:
					try
					{
						if (imapClient != null)
						{
							if (msg != null)
							{
								if (emailSendId > 0 && msg.Attachments != null)
								{
									if (((CollectionBase)msg.Attachments).Count <= 0)
									{
										return true;
									}
									WriteEmailReceiveLog(" GetEmailSendAttachment()=> Conut of file from mail server IMAP :" + ((CollectionBase)msg.Attachments).Count, emailUsersInfoId);
									int num = 0;
									foreach (ActiveUp.Net.Mail.MimePart item in (CollectionBase)msg.Attachments)
									{
										num++;
										if (item == null)
										{
											continue;
										}
										string contentName = item.ContentName;
										_ = item.ContentType;
										string mimeType = "";
										if (item.ContentType != null)
										{
											mimeType = item.ContentType.MimeType;
										}
										if (IsBlockedAttachment(contentName))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName, emailUsersInfoId);
											continue;
										}
										if (IsSuspiciousDoubleExtension(contentName))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName, emailUsersInfoId);
											continue;
										}
										if (IsBlockedMimeType(mimeType))
										{
											WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName, emailUsersInfoId);
											continue;
										}
										string contentName2 = item.ContentName;
										string[] array = (contentName2 ?? "").Split(new char[1] { '.' });
										string text = "";
										if (array != null)
										{
											text = array[^1];
										}
										ObjectParameter objectParameter = new ObjectParameter("insertedEmailSendAttachmentId", typeof(int));
										cRMSpIIEntities.EmailspInsertEmailSendAttachmentByMailServer(emailSendId, contentName2, "", item.ContentId, value4, value, registerDatePersian, value3, value2, appTypeMailServer, result2, objectParameter);
										int result3 = 0;
										if (objectParameter.Value != null)
										{
											int.TryParse(objectParameter.Value.ToString(), out result3);
										}
										if (result3 > 0)
										{
											WriteEmailReceiveLog(" GetEmailSendAttachment()=> Inser file in table from mail server IMAP ", emailUsersInfoId);
											string text2 = "";
											string text3 = emailspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp ?? "";
											if (!text3.StartsWith("/"))
											{
												text3 = "/" + text3;
											}
											if (!text3.EndsWith("/"))
											{
												text3 += "/";
											}
											bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text2, text3, usePassiveFtp);
											if (!flag)
											{
												flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text2, text3, usePassiveFtp);
											}
											text2 += text3;
											bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text2, emailReceiveFolderId.ToString(), usePassiveFtp);
											if (!flag2)
											{
												flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text2, emailReceiveFolderId.ToString(), usePassiveFtp);
											}
											text2 = text2 + emailReceiveFolderId + "/";
											bool flag3 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text2, emailUsersInfoId.ToString(), usePassiveFtp);
											if (!flag3)
											{
												flag3 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text2, emailUsersInfoId.ToString(), usePassiveFtp);
											}
											text2 = text2 + emailUsersInfoId + "/";
											bool flag4 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text2, emailSendId.ToString(), usePassiveFtp);
											if (!flag4)
											{
												flag4 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text2, emailSendId.ToString(), usePassiveFtp);
											}
											if (flag && flag2 && flag3 && flag4)
											{
												string text4 = emailSendId + "-" + result3 + "." + text;
												text2 = text2 + emailSendId + "/" + text4;
												string text5 = Configuration.HostTempFilesPath + text3 + emailReceiveFolderId + "/" + emailUsersInfoId + "/" + emailSendId;
												text5 = HostingEnvironment.MapPath(text5);
												if (!System.IO.Directory.Exists(text5))
												{
													System.IO.Directory.CreateDirectory(text5);
													CRM.General.IO.Directory.SetFullControlForEveryOne(text5);
												}
												text5 = text5 + "/" + text4;
												if (!System.IO.File.Exists(text5))
												{
													item.StoreToFile(text5);
												}
												if (System.IO.File.Exists(text5))
												{
													if (!FileSignatureValidator.IsValidFileSignature(text5))
													{
														try
														{
															System.IO.File.Delete(text5);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result3);
														}
														catch (Exception ex)
														{
															Logs.LogError(ex, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName + " - Attachment rejected (Invalid File Signature): " + text5, emailUsersInfoId);
														continue;
													}
													if (FileSignatureValidator.HasDoubleExtension(contentName))
													{
														try
														{
															System.IO.File.Delete(text5);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result3);
														}
														catch (Exception ex2)
														{
															Logs.LogError(ex2, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName, emailUsersInfoId);
														continue;
													}
													if (Path.GetExtension(text5).Equals(".zip", StringComparison.OrdinalIgnoreCase) && FileSignatureValidator.IsZipBomb(text5))
													{
														try
														{
															System.IO.File.Delete(text5);
															cRMSpEntities.EmailspDeleteEmailReceiveAttachments(result3);
														}
														catch (Exception ex3)
														{
															Logs.LogError(ex3, "");
														}
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName + " - Attachment rejected (Invalid File Signature): " + text5, emailUsersInfoId);
														continue;
													}
													if (!WindowsDefenderScanner.Scan(text5, out var result4))
													{
														System.IO.File.Delete(text5);
														WriteEmailReceiveLog(" GetEmailReceiveAttachments()=> Error Get file Because this file is virus by name :" + contentName + " - Virus Detected : " + result4, emailUsersInfoId);
														continue;
													}
												}
												if (System.IO.File.Exists(text5))
												{
													if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text2, text5, usePassiveFtp))
													{
														string text6 = emailspSelectEmailSetting_Result.EmailsAttachFilePath ?? "";
														if (!text6.EndsWith("\\"))
														{
															text6 += "\\";
														}
														text6 = text6 + emailReceiveFolderId + "\\" + emailUsersInfoId + "\\" + emailSendId + "\\" + contentName2;
														cRMSpEntities.EmailspUpdateEmailSendAttachment(result3, emailSendId, contentName2, text6, value, registerDatePersian, appTypeMailServer);
														WriteEmailReceiveLog(" GetEmailSendAttachment()=> Upload file in fpt from mail server IMAP ", emailUsersInfoId);
													}
													else
													{
														Exception ex4 = new Exception(Messages.frmErrorInSendingFile + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text2);
														Logs.LogError(ex4, "");
														try
														{
															cRMSpEntities.EmailspDeleteEmailSendAttachment(result3);
														}
														catch (Exception ex5)
														{
															Logs.LogError(ex5, "");
														}
														message = ex4.Message;
														WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Upload file in FTP in mail server IMAP:" + message, emailUsersInfoId);
													}
												}
												else
												{
													message = Messages.msgErrorNotFilePath;
													WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Upload file in FTP in mail server IMAP:" + message, emailUsersInfoId);
												}
											}
											else
											{
												Exception ex6 = new Exception(Messages.msgErrorCreateFolderInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text2);
												Logs.LogError(ex6, "");
												try
												{
													cRMSpEntities.EmailspDeleteEmailSendAttachment(result3);
												}
												catch (Exception ex7)
												{
													Logs.LogError(ex7, "");
												}
												message = Messages.frmErrorInSendingFile + "(" + ex6.Message + ")";
												WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Upload file in FTP in mail server IMAP:" + message, emailUsersInfoId);
											}
										}
										else
										{
											message = message + Messages.frmErrorInSendingFile + "( in file:" + num + ")";
											WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server IMAP:" + message, emailUsersInfoId);
										}
									}
								}
								result = (string.IsNullOrEmpty(message) ? true : false);
							}
							else
							{
								message = string.Format(Messages.msgErrorIsNotFound, "MailBox");
								WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server IMAP:" + message, emailUsersInfoId);
							}
						}
						else
						{
							message = "Not found Imap";
							WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server IMAP:" + message, emailUsersInfoId);
						}
					}
					catch (Imap4Exception ex8)
					{
						Logs.LogError(ex8, "");
						message = $"Imap4 Error: {ex8.Message}";
						WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server IMAP:" + message, emailUsersInfoId);
					}
					catch (Exception ex9)
					{
						Logs.LogError(ex9, "");
						message = $"Failed: {ex9.Message}";
						WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server IMAP:" + message, emailUsersInfoId);
					}
					break;
				}
			}
			else
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server:" + message, emailUsersInfoId);
			}
			WriteEmailReceiveLog(" GetEmailSendAttachment()=> Get file from mail server (folder: " + folderName + "): End ", emailUsersInfoId);
		}
		catch (Exception ex20)
		{
			Logs.LogError(ex20, "");
			message = ex20.Message;
			WriteEmailReceiveLog(" GetEmailSendAttachment()=> Error Get file from mail server:" + message, emailUsersInfoId);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static bool IsBlockedAttachment(string fileName)
	{
		if (string.IsNullOrWhiteSpace(fileName))
		{
			return false;
		}
		string extension = Path.GetExtension(fileName);
		if (string.IsNullOrEmpty(extension))
		{
			return false;
		}
		return Configuration.MaliciousEmailFileExtensions.Contains(extension.TrimStart(new char[1] { '.' }));
	}

	public static bool IsSuspiciousDoubleExtension(string fileName)
	{
		if (string.IsNullOrWhiteSpace(fileName))
		{
			return false;
		}
		string[] array = fileName.ToLowerInvariant().Split(new char[1] { '.' });
		if (array.Length < 3)
		{
			return false;
		}
		string text = array[^1];
		return Configuration.MaliciousEmailFileExtensions.Contains(text);
	}

	public static bool IsBlockedMimeType(string mimeType)
	{
		if (string.IsNullOrWhiteSpace(mimeType))
		{
			return false;
		}
		return Configuration.MaliciousMimeTypes.Contains(mimeType);
	}

	public static bool DeleteSrvrEmailAfterDay(EmailspSelectEmailUsersInfoById_Result emailInfo, Imap4Client imapClient, Pop3Client pop3Client, ref string message)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppTypeMailServer;
			short.Parse(Financial.Get().Id.ToString());
			if (UserLogin.CurrentUser != null)
			{
				_ = UserLogin.CurrentUser.UserId;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (emailInfo != null)
			{
				WriteEmailReceiveLog(" DeleteSrvrEmailAfterDay()=> Get file from mail server : Start ", emailInfo.EmailUsersInfoId);
				int valueOrDefault = emailInfo.euReceiveServerType.GetValueOrDefault(2);
				if (valueOrDefault == 1)
				{
					if (pop3Client == null || !pop3Client.IsConnected || !pop3Client.IsAuthenticated)
					{
						message = "POP3 connection is not available.";
						return false;
					}
				}
				else if (imapClient == null || !imapClient.IsConnected)
				{
					message = "IMAP connection is not available.";
					return false;
				}
				switch (valueOrDefault)
				{
				case 1:
				{
					List<EmailspSelectEmailReceiveForDeleteAfterDay_Result> list2 = Enumerable.ToList<EmailspSelectEmailReceiveForDeleteAfterDay_Result>((IEnumerable<EmailspSelectEmailReceiveForDeleteAfterDay_Result>)cRMSpIEntities.EmailspSelectEmailReceiveForDeleteAfterDay(emailInfo.EmailUsersInfoId, lCID, result2));
					if (list2 == null || list2.Count <= 0)
					{
						break;
					}
					IList<string> messageUids = pop3Client.GetMessageUids();
					foreach (EmailspSelectEmailReceiveForDeleteAfterDay_Result item in list2)
					{
						int num = messageUids.IndexOf(item.MessageId);
						if (num >= 0)
						{
							pop3Client.DeleteMessage(num);
						}
					}
					break;
				}
				case 2:
				{
					List<EmailspSelectEmailReceiveForDeleteAfterDay_Result> list = Enumerable.ToList<EmailspSelectEmailReceiveForDeleteAfterDay_Result>((IEnumerable<EmailspSelectEmailReceiveForDeleteAfterDay_Result>)cRMSpIEntities.EmailspSelectEmailReceiveForDeleteAfterDay(emailInfo.EmailUsersInfoId, lCID, result2));
					if (list == null || list.Count <= 0)
					{
						break;
					}
					foreach (EmailspSelectEmailReceiveForDeleteAfterDay_Result item2 in list)
					{
						Mailbox mailbox = imapClient.Mailboxes[item2.FolderName];
						for (int i = 0; i < mailbox.MessageCount; i++)
						{
							Fetch fetch = mailbox.Fetch;
							Message message2 = fetch.MessageObject(i + 1);
							if (message2 != null && message2.MessageId == item2.MessageId)
							{
								mailbox.UidDeleteMessage(fetch.Uid(i + 1), expunge: true);
							}
						}
					}
					break;
				}
				}
				WriteEmailReceiveLog(" DeleteSrvrEmailAfterDay()=> Get file from mail server : End ", emailInfo.EmailUsersInfoId);
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "");
			WriteEmailReceiveLog(" DeleteSrvrEmailWithId()=> Error delete email from mail server: " + ex.Message, emailInfo.EmailUsersInfoId);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static bool DeleteSrvrEmailWithId(EmailspSelectEmailUsersInfoById_Result emailInfo, Imap4Client imapClient, Pop3Client pop3Client, string messageUId, string folderName, ref string message)
	{
		bool result = false;
		try
		{
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppTypeMailServer;
			short.Parse(Financial.Get().Id.ToString());
			if (UserLogin.CurrentUser != null)
			{
				_ = UserLogin.CurrentUser.UserId;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (emailInfo != null)
			{
				WriteEmailReceiveLog(" DeleteSrvrEmailWithId()=> Get file from mail server (folder: " + folderName + "): Start ", emailInfo.EmailUsersInfoId);
				int valueOrDefault = emailInfo.euReceiveServerType.GetValueOrDefault(2);
				if (valueOrDefault == 1)
				{
					if (pop3Client == null || !pop3Client.IsConnected || !pop3Client.IsAuthenticated)
					{
						message = "POP3 connection is not available.";
						return false;
					}
				}
				else if (imapClient == null || !imapClient.IsConnected)
				{
					message = "IMAP connection is not available.";
					return false;
				}
				switch (valueOrDefault)
				{
				case 1:
				{
					int messageCount = pop3Client.GetMessageCount();
					for (int j = 0; j < messageCount; j++)
					{
						if (pop3Client.GetMessage(j).MessageId == messageUId)
						{
							pop3Client.DeleteMessage(j);
						}
					}
					result = true;
					break;
				}
				case 2:
				{
					Mailbox mailbox = imapClient.Mailboxes[folderName];
					for (int i = 0; i < mailbox.MessageCount; i++)
					{
						Fetch fetch = mailbox.Fetch;
						Message message2 = fetch.MessageObject(i + 1);
						if (message2 != null && message2.MessageId == messageUId)
						{
							mailbox.UidDeleteMessage(fetch.Uid(i + 1), expunge: true);
						}
					}
					result = true;
					break;
				}
				}
				WriteEmailReceiveLog(" DeleteSrvrEmailWithId()=> Get file from mail server (folder: " + folderName + "): End ", emailInfo.EmailUsersInfoId);
			}
		}
		catch (Exception ex)
		{
			Logs.LogError(ex, "");
			WriteEmailReceiveLog(" DeleteSrvrEmailWithId()=> Error delete email from mail server: " + ex.Message, emailInfo.EmailUsersInfoId);
		}
		return result;
	}

	public static bool ReceiveAllEmailForAccount(int emailUsersInfoId, EmailspSelectEmailUsersInfoById_Result emailUserInfo, DateTime fromDate, DateTime toDate, ref string message, bool useInJob = false, bool noSetDateToQry = false)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			if (emailUserInfo == null || (emailUserInfo != null && emailUserInfo.EmailUsersInfoId == 0))
			{
				emailUserInfo = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)cRMSpEntities.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
			}
			if (emailUserInfo != null)
			{
				lock (AccountLocks.GetOrAdd(emailUsersInfoId, (Func<int, object>)((int _) => new object())))
				{
					int valueOrDefault = emailUserInfo.euReceiveServerType.GetValueOrDefault(2);
					switch (valueOrDefault)
					{
					case 1:
					{
						Pop3Client pop3Client = null;
						try
						{
							pop3Client = CreateConnectedPop3Client(emailUsersInfoId, emailUserInfo, ref message);
							if (pop3Client == null || !pop3Client.IsConnected || !pop3Client.IsAuthenticated)
							{
								return false;
							}
							List<EmailspSelectEmailReceiveFolders_Result> list3 = Enumerable.ToList<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)cRMSpEntities.EmailspSelectEmailReceiveFolders(emailUsersInfoId, 0, null));
							if (list3 != null && Enumerable.Any<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)list3))
							{
								list3 = Enumerable.ToList<EmailspSelectEmailReceiveFolders_Result>(Enumerable.Where<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)list3, (Func<EmailspSelectEmailReceiveFolders_Result, bool>)((EmailspSelectEmailReceiveFolders_Result x) => x.FolderName.ToLower() == "inbox")));
							}
							double totalMsgCount = 0.0;
							int num3 = 0;
							if (list3 != null && Enumerable.Any<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)list3))
							{
								foreach (EmailspSelectEmailReceiveFolders_Result item in list3)
								{
									FolderReceiveInfo folderReceiveInfo2 = new FolderReceiveInfo();
									folderReceiveInfo2.Folder = new EmailspSelectEmailReceiveFolders_Result();
									folderReceiveInfo2.Folder = item;
									if (!GetEmailReceive(emailUsersInfoId, emailUserInfo, null, pop3Client, item.FolderName, item.EmailReceiveFolderId, fromDate, toDate, totalMsgCount, num3, ref message, useInJob, noSetDateToQry, folderReceiveInfo2))
									{
										return false;
									}
									int.TryParse(item.AppType, out var result3);
									num3 += result3;
								}
							}
							return true;
						}
						catch (Exception ex2)
						{
							Logs.LogError(ex2, "ReceiveAllEmailForAccount, EmailUsersInfoId=" + emailUsersInfoId);
							message = ex2.Message;
							return false;
						}
						finally
						{
							SafeDisconnectMailServer(valueOrDefault, null, pop3Client);
						}
					}
					case 2:
					{
						Imap4Client imap4Client = null;
						try
						{
							imap4Client = CreateConnectedImapClient(emailUsersInfoId, emailUserInfo, ref message);
							if (imap4Client == null || !imap4Client.IsConnected)
							{
								return false;
							}
							if (!GetEmailReceiveFolders(emailUserInfo.EmailUsersInfoId, emailUserInfo, imap4Client, ref message))
							{
								return false;
							}
							List<EmailspSelectEmailReceiveFolders_Result> list = Enumerable.ToList<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)cRMSpEntities.EmailspSelectEmailReceiveFolders(emailReceiveFolderId: 0, emailUsersInfoId: emailUsersInfoId, folderName: null));
							List<FolderReceiveInfo> list2 = new List<FolderReceiveInfo>();
							double num = 0.0;
							if (list != null && Enumerable.Any<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)list))
							{
								foreach (EmailspSelectEmailReceiveFolders_Result item2 in list)
								{
									if (!string.IsNullOrWhiteSpace(item2.FolderName))
									{
										FolderReceiveInfo folderReceiveInfo = new FolderReceiveInfo();
										folderReceiveInfo.Folder = new EmailspSelectEmailReceiveFolders_Result();
										folderReceiveInfo.Folder = item2;
										long messageCount = GetMessageCount(emailUsersInfoId, emailUserInfo, imap4Client, null, item2.FolderName, fromDate, toDate, ref message, ref folderReceiveInfo, useInJob, noSetDateToQry);
										num += (double)messageCount;
										item2.AppType = messageCount.ToString();
										folderReceiveInfo.Folder.AppType = messageCount.ToString();
										if (messageCount > 0)
										{
											list2.Add(folderReceiveInfo);
										}
									}
								}
							}
							int num2 = 0;
							if (list2 != null && Enumerable.Any<FolderReceiveInfo>((IEnumerable<FolderReceiveInfo>)list2))
							{
								foreach (FolderReceiveInfo item3 in list2)
								{
									EmailspSelectEmailReceiveFolders_Result folder = item3.Folder;
									if (folder != null)
									{
										if (!GetEmailReceive(emailUsersInfoId, emailUserInfo, imap4Client, null, folder.FolderName, folder.EmailReceiveFolderId, fromDate, toDate, num, num2, ref message, useInJob, noSetDateToQry, item3))
										{
											return false;
										}
										int.TryParse(folder.AppType, out var result2);
										num2 += result2;
									}
								}
							}
							return true;
						}
						catch (Exception ex)
						{
							Logs.LogError(ex, "ReceiveAllEmailForAccount, EmailUsersInfoId=" + emailUsersInfoId);
							message = ex.Message;
							return false;
						}
						finally
						{
							SafeDisconnectMailServer(valueOrDefault, imap4Client, null);
						}
					}
					}
				}
			}
			else
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				WriteEmailReceiveLog(" ReceiveAllEmailForAccount()=> Error in get email for emailUsersInfoId " + emailUsersInfoId + " from mail serve: " + message, emailUsersInfoId);
			}
		}
		catch (Exception ex3)
		{
			Logs.LogError(ex3, "");
			message = ex3.Message;
			WriteEmailReceiveLog(" ReceiveAllEmailForAccount()=> Error in get email for emailUsersInfoId " + emailUsersInfoId + " from mail serve: " + message, emailUsersInfoId);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool DeleteEmailForAccount(EmailspSelectEmailUsersInfoById_Result emailInfo, string messageUId, string folderName, ref string message)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			if (emailInfo != null)
			{
				int valueOrDefault = emailInfo.euReceiveServerType.GetValueOrDefault(2);
				switch (valueOrDefault)
				{
				case 1:
				{
					Pop3Client pop3Client = null;
					try
					{
						pop3Client = CreateConnectedPop3Client(emailInfo.EmailUsersInfoId, emailInfo, ref message);
						if (pop3Client == null || !pop3Client.IsConnected || !pop3Client.IsAuthenticated)
						{
							return false;
						}
						result = DeleteSrvrEmailWithId(emailInfo, null, pop3Client, messageUId, folderName, ref message);
						return result;
					}
					catch (Exception ex2)
					{
						Logs.LogError(ex2, "DeleteEmailForAccount, messageUId=" + messageUId);
						message = ex2.Message;
						return false;
					}
					finally
					{
						SafeDisconnectMailServer(valueOrDefault, null, pop3Client);
					}
				}
				case 2:
				{
					Imap4Client imap4Client = null;
					try
					{
						imap4Client = CreateConnectedImapClient(emailInfo.EmailUsersInfoId, emailInfo, ref message);
						if (imap4Client == null || !imap4Client.IsConnected)
						{
							return false;
						}
						result = DeleteSrvrEmailWithId(emailInfo, imap4Client, null, messageUId, folderName, ref message);
						return result;
					}
					catch (Exception ex)
					{
						Logs.LogError(ex, "DeleteEmailForAccount, messageUId=" + messageUId);
						message = ex.Message;
						return false;
					}
					finally
					{
						SafeDisconnectMailServer(valueOrDefault, imap4Client, null);
					}
				}
				}
			}
			else
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				WriteEmailReceiveLog(" DeleteEmailForAccount()=> Error in delete email by messageUId " + messageUId + " from mail serve: " + message, 0);
			}
		}
		catch (Exception ex3)
		{
			Logs.LogError(ex3, "");
			message = ex3.Message;
			WriteEmailReceiveLog(" DeleteEmailForAccount()=> Error in delete email by messageUId " + messageUId + " from mail serve: " + message, 0);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static long ReceiveCountAllEmailForAccount(int emailUsersInfoId, EmailspSelectEmailUsersInfoById_Result emailUserInfo, DateTime fromDate, DateTime toDate, ref string message, bool useInJob = false, bool noSetDateToQry = false, bool fillFolderInfo = false)
	{
		long num = 0L;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			if (emailUserInfo == null || (emailUserInfo != null && emailUserInfo.EmailUsersInfoId == 0))
			{
				emailUserInfo = Enumerable.FirstOrDefault<EmailspSelectEmailUsersInfoById_Result>((IEnumerable<EmailspSelectEmailUsersInfoById_Result>)cRMSpEntities.EmailspSelectEmailUsersInfoById(emailUsersInfoId));
			}
			if (emailUserInfo != null)
			{
				lock (AccountLocks.GetOrAdd(emailUsersInfoId, (Func<int, object>)((int _) => new object())))
				{
					int valueOrDefault = emailUserInfo.euReceiveServerType.GetValueOrDefault(2);
					switch (valueOrDefault)
					{
					case 1:
					{
						Pop3Client pop3Client = null;
						try
						{
							pop3Client = CreateConnectedPop3Client(emailUsersInfoId, emailUserInfo, ref message);
							if (pop3Client == null || !pop3Client.IsConnected || !pop3Client.IsAuthenticated)
							{
								return num;
							}
							List<EmailspSelectEmailReceiveFolders_Result> list2 = Enumerable.ToList<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)cRMSpEntities.EmailspSelectEmailReceiveFolders(emailUsersInfoId, 0, null));
							if (list2 != null && Enumerable.Any<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)list2))
							{
								foreach (EmailspSelectEmailReceiveFolders_Result item in list2)
								{
									if (!string.IsNullOrWhiteSpace(item.FolderName))
									{
										FolderReceiveInfo folderReceiveInfo2 = new FolderReceiveInfo();
										folderReceiveInfo2.Folder = new EmailspSelectEmailReceiveFolders_Result();
										folderReceiveInfo2.Folder = item;
										long messageCount2 = GetMessageCount(emailUsersInfoId, emailUserInfo, null, pop3Client, item.FolderName, fromDate, toDate, ref message, ref folderReceiveInfo2, useInJob, noSetDateToQry, fillFolderInfo);
										if (messageCount2 > 0)
										{
											num += messageCount2;
										}
									}
								}
							}
							return num;
						}
						catch (Exception ex2)
						{
							Logs.LogError(ex2, "ReceiveCountAllEmailForAccount, EmailUsersInfoId=" + emailUsersInfoId);
							message = ex2.Message;
							return 0L;
						}
						finally
						{
							SafeDisconnectMailServer(valueOrDefault, null, pop3Client);
						}
					}
					case 2:
					{
						Imap4Client imap4Client = null;
						try
						{
							imap4Client = CreateConnectedImapClient(emailUsersInfoId, emailUserInfo, ref message);
							if (imap4Client == null || !imap4Client.IsConnected)
							{
								return num;
							}
							if (!GetEmailReceiveFolders(emailUserInfo.EmailUsersInfoId, emailUserInfo, imap4Client, ref message))
							{
								return num;
							}
							List<EmailspSelectEmailReceiveFolders_Result> list = Enumerable.ToList<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)cRMSpEntities.EmailspSelectEmailReceiveFolders(emailReceiveFolderId: 0, emailUsersInfoId: emailUsersInfoId, folderName: null));
							if (list != null && Enumerable.Any<EmailspSelectEmailReceiveFolders_Result>((IEnumerable<EmailspSelectEmailReceiveFolders_Result>)list))
							{
								foreach (EmailspSelectEmailReceiveFolders_Result item2 in list)
								{
									if (!string.IsNullOrWhiteSpace(item2.FolderName))
									{
										FolderReceiveInfo folderReceiveInfo = new FolderReceiveInfo();
										folderReceiveInfo.Folder = new EmailspSelectEmailReceiveFolders_Result();
										folderReceiveInfo.Folder = item2;
										long messageCount = GetMessageCount(emailUsersInfoId, emailUserInfo, imap4Client, null, item2.FolderName, fromDate, toDate, ref message, ref folderReceiveInfo, useInJob, noSetDateToQry, fillFolderInfo);
										if (messageCount > 0)
										{
											num += messageCount;
										}
									}
								}
							}
							return num;
						}
						catch (Exception ex)
						{
							Logs.LogError(ex, "ReceiveCountAllEmailForAccount, EmailUsersInfoId=" + emailUsersInfoId);
							message = ex.Message;
							return 0L;
						}
						finally
						{
							SafeDisconnectMailServer(valueOrDefault, imap4Client, null);
						}
					}
					}
				}
			}
			else
			{
				message = string.Format(Messages.msgErrorIsNotFound, Labels.ReceiveEmailUserEmail);
				WriteEmailReceiveLog(" ReceiveCountAllEmailForAccount()=> Error in get email for emailUsersInfoId " + emailUsersInfoId + " from mail serve: " + message, emailUsersInfoId);
			}
		}
		catch (Exception ex3)
		{
			Logs.LogError(ex3, "");
			message = ex3.Message;
			WriteEmailReceiveLog(" ReceiveCountAllEmailForAccount()=> Error in get email for emailUsersInfoId " + emailUsersInfoId + " from mail serve: " + message, emailUsersInfoId);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return num;
	}

	public bool SendEmailCmpFoLogin(EmailSendFoLoginInfoViewModel emailItem, ref string errorMessage)
	{
		//IL_09e1: Expected O, but got Unknown
		//IL_0a32: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Expected O, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_091c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0926: Expected O, but got Unknown
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		MailAddress mailAddress = null;
		CRMSpEntities cRMSpEntities = null;
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMSpEntities = new CRMSpEntities();
			cRMSpIEntities = new CRMSpIEntities();
			CRMspSelectEmailSendFoSetting_Result cRMspSelectEmailSendFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectEmailSendFoSetting_Result>((IEnumerable<CRMspSelectEmailSendFoSetting_Result>)cRMSpIEntities.CRMspSelectEmailSendFoSetting());
			if (cRMspSelectEmailSendFoSetting_Result != null)
			{
				cRMspSelectEmailSendFoSetting_Result.euPassword = ((!string.IsNullOrEmpty(cRMspSelectEmailSendFoSetting_Result.euPassword)) ? XorCipher.DecryptByPrivateKey(cRMspSelectEmailSendFoSetting_Result.euPassword) : string.Empty);
				if (cRMspSelectEmailSendFoSetting_Result.EmailSendingIsActive.GetValueOrDefault())
				{
					if (!cRMspSelectEmailSendFoSetting_Result.EmailSettingId.HasValue)
					{
						errorMessage = string.Format(Messages.msgErrorNotSetEmailSendFoSetting, Labels.FoSettingEmailSettingId);
					}
					else if (!cRMspSelectEmailSendFoSetting_Result.EmailUserInfoId.HasValue)
					{
						errorMessage = string.Format(Messages.msgErrorNotSetEmailSendFoSetting, Labels.FoSettingEmailUserInfoId);
					}
					else if (string.IsNullOrWhiteSpace(cRMspSelectEmailSendFoSetting_Result.EmailBodyPatternFormulaSendFoInfo))
					{
						errorMessage = string.Format(Messages.msgErrorNotSetEmailSendFoSetting, Labels.FoSettingEmailBodyPatternFormulaSendFoInfo);
					}
					else
					{
						cRMspSelectEmailSendFoSetting_Result.EmailSmtpPort = cRMspSelectEmailSendFoSetting_Result.EmailSmtpPort ?? cRMspSelectEmailSendFoSetting_Result.euSMTPPort.GetValueOrDefault(25);
						int valueOrDefault = cRMspSelectEmailSendFoSetting_Result.EmailSmtpPort.GetValueOrDefault(25);
						cRMspSelectEmailSendFoSetting_Result.euNikeEmail = cRMspSelectEmailSendFoSetting_Result.euNikeEmail ?? cRMspSelectEmailSendFoSetting_Result.euUserName;
						cRMspSelectEmailSendFoSetting_Result.euNikeName = cRMspSelectEmailSendFoSetting_Result.euNikeName ?? cRMspSelectEmailSendFoSetting_Result.euUserName;
						bool enableSsl = ((!cRMspSelectEmailSendFoSetting_Result.EmailSmtpEnableSSL.HasValue) ? cRMspSelectEmailSendFoSetting_Result.euSMTPUseSsl.GetValueOrDefault() : cRMspSelectEmailSendFoSetting_Result.EmailSmtpEnableSSL.GetValueOrDefault());
						bool useDefaultCredentials = ((!cRMspSelectEmailSendFoSetting_Result.EmailSmtpUseDefaultCredentials.HasValue) ? cRMspSelectEmailSendFoSetting_Result.euSMTPUseDefCredentials.GetValueOrDefault() : cRMspSelectEmailSendFoSetting_Result.EmailSmtpUseDefaultCredentials.GetValueOrDefault());
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						Regex val = new Regex("[a-z]:\\\\(?:[^\\\\:]+\\\\)*((?:[^:\\\\]+)\\.\\w+)", (RegexOptions)1);
						List<string> list = new List<string>();
						string text = "";
						string text2 = "";
						ObjectParameter objectParameter = new ObjectParameter("EmailSubjectPatternFormulaSendFoInfoResult", "");
						ObjectParameter objectParameter2 = new ObjectParameter("EmailBodyPatternFormulaSendFoInfoResult", "");
						cRMSpIEntities.CRMspGetEmailPatternFormulaSendFoInfoResult(emailItem.EmailCmpId, emailItem.EmailCmpPrsId.HasValue ? emailItem.EmailCmpPrsId : null, emailItem.CmpPassword ?? "", cRMspSelectEmailSendFoSetting_Result.FoSettingId, lCID, result, objectParameter, objectParameter2);
						if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							text = objectParameter.Value.ToString();
						}
						if (objectParameter2.Value != null && !string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
						{
							text2 = objectParameter2.Value.ToString();
							text2 = ((!Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft) ? ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"ltr\">" + text2 + "</div><p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>") : ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\">" + text2 + "</div><p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>"));
							foreach (Match item in val.Matches(text2))
							{
								Match val2 = item;
								string text3 = System.Guid.NewGuid().ToString();
								text2 = text2.Replace(((Capture)val2).Value, "cid:" + text3);
								dictionary.Add(text3, ((Capture)val2).Value);
							}
							foreach (Match item2 in Regex.Matches(text2, "<img.+?src=[\"'](.+?)[\"'].+?>", (RegexOptions)3))
							{
								string value = ((Capture)item2.Groups[1]).Value;
								if (!list.Contains(value))
								{
									list.Add(value);
								}
							}
						}
						if (cRMspSelectEmailSendFoSetting_Result.euSMTPUseSsl.GetValueOrDefault())
						{
							using MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient();
							object obj = _003C_003Ec._003C_003E9__19_0;
							if (obj == null)
							{
								RemoteCertificateValidationCallback val3 = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
								{
									//IL_0000: Unknown result type (might be due to invalid IL or missing references)
									//IL_0006: Unknown result type (might be due to invalid IL or missing references)
									//IL_0009: Invalid comparison between Unknown and I4
									if ((int)sslPolicyErrors == 0)
									{
										return true;
									}
									if ((int)sslPolicyErrors == 4)
									{
										X509ChainStatus[] chainStatus = chain.ChainStatus;
										for (int i = 0; i < chainStatus.Length; i++)
										{
											X509ChainStatus x509ChainStatus = chainStatus[i];
											if (x509ChainStatus.Status != X509ChainStatusFlags.RevocationStatusUnknown && x509ChainStatus.Status != X509ChainStatusFlags.OfflineRevocation)
											{
												return false;
											}
										}
										return true;
									}
									return false;
								};
								_003C_003Ec._003C_003E9__19_0 = val3;
								obj = (object)val3;
							}
							smtpClient.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)obj;
							if (cRMspSelectEmailSendFoSetting_Result.euSMTPPort.GetValueOrDefault(465) == 587)
							{
								smtpClient.Connect(cRMspSelectEmailSendFoSetting_Result.euSMTPServer, cRMspSelectEmailSendFoSetting_Result.euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.StartTls);
							}
							else
							{
								smtpClient.Connect(cRMspSelectEmailSendFoSetting_Result.euSMTPServer, cRMspSelectEmailSendFoSetting_Result.euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.SslOnConnect);
							}
							smtpClient.Authenticate(cRMspSelectEmailSendFoSetting_Result.euUserName, cRMspSelectEmailSendFoSetting_Result.euPassword);
							MimeMessage mimeMessage = new MimeMessage();
							mimeMessage.Bcc.Add(new MailboxAddress((emailItem.EmailCmpPrsName != "") ? emailItem.EmailCmpPrsName : emailItem.EmailAddress, emailItem.EmailAddress));
							mimeMessage.From.Add(new MailboxAddress(cRMspSelectEmailSendFoSetting_Result.euNikeName, cRMspSelectEmailSendFoSetting_Result.euNikeEmail));
							mimeMessage.To.Add(new MailboxAddress((emailItem.EmailCmpPrsName != "") ? emailItem.EmailCmpPrsName : emailItem.EmailAddress, emailItem.EmailAddress));
							mimeMessage.Subject = text;
							mimeMessage.Priority = MimeKit.MessagePriority.Urgent;
							BodyBuilder bodyBuilder = new BodyBuilder();
							bodyBuilder.HtmlBody = text2;
							foreach (string key in dictionary.Keys)
							{
								bodyBuilder.LinkedResources.Add(dictionary[key]).ContentId = key;
							}
							if (list.Count > 0)
							{
								foreach (string item3 in list)
								{
									string text4 = HostingEnvironment.MapPath(item3.Replace("%2F", "/").Replace("%20", " "));
									string contentId = DateTime.Now.ToString("yyyyMMddHHmmss");
									if (!string.IsNullOrWhiteSpace(text4))
									{
										bodyBuilder.LinkedResources.Add(text4).ContentId = contentId;
									}
								}
							}
							mimeMessage.Body = bodyBuilder.ToMessageBody();
							smtpClient.Timeout = 60000;
							smtpClient.Send(mimeMessage);
							smtpClient.Dispose();
							flag = true;
						}
						else
						{
							MailMessage mailMessage = new MailMessage();
							mailAddress = new MailAddress(emailItem.EmailAddress, (emailItem.EmailCmpPrsName != "") ? emailItem.EmailCmpPrsName : emailItem.EmailAddress);
							mailMessage.Bcc.Add(mailAddress);
							mailMessage.From = new MailAddress(cRMspSelectEmailSendFoSetting_Result.euNikeEmail, cRMspSelectEmailSendFoSetting_Result.euNikeName);
							mailMessage.Subject = text;
							mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
							mailMessage.Priority = MailPriority.High;
							mailMessage.IsBodyHtml = true;
							mailMessage.BodyEncoding = Encoding.UTF8;
							mailMessage.SubjectEncoding = Encoding.UTF8;
							AlternateView alternateView = AlternateView.CreateAlternateViewFromString(text2, (Encoding)null, "text/html");
							foreach (string key2 in dictionary.Keys)
							{
								LinkedResource linkedResource = new LinkedResource(dictionary[key2]);
								linkedResource.ContentId = key2;
								alternateView.LinkedResources.Add(linkedResource);
							}
							if (list.Count > 0)
							{
								foreach (string item4 in list)
								{
									string text5 = HostingEnvironment.MapPath(item4.Replace("%2F", "/").Replace("%20", " "));
									string contentId2 = DateTime.Now.ToString("yyyyMMddHHmmss");
									if (!string.IsNullOrWhiteSpace(text5))
									{
										LinkedResource linkedResource2 = new LinkedResource(text5);
										linkedResource2.ContentId = contentId2;
										alternateView.LinkedResources.Add(linkedResource2);
									}
								}
							}
							mailMessage.AlternateViews.Add(alternateView);
							System.Net.Mail.SmtpClient smtpClient2 = new System.Net.Mail.SmtpClient();
							smtpClient2.DeliveryMethod = SmtpDeliveryMethod.Network;
							smtpClient2.Host = cRMspSelectEmailSendFoSetting_Result.euSMTPServer;
							smtpClient2.EnableSsl = enableSsl;
							smtpClient2.UseDefaultCredentials = useDefaultCredentials;
							smtpClient2.Credentials = (ICredentialsByHost?)new NetworkCredential(cRMspSelectEmailSendFoSetting_Result.euUserName, cRMspSelectEmailSendFoSetting_Result.euPassword);
							smtpClient2.Port = valueOrDefault;
							smtpClient2.ServicePoint.MaxIdleTime = 1;
							smtpClient2.Timeout = 60000;
							smtpClient2.Send(mailMessage);
							flag = true;
						}
						if (flag)
						{
							emailItem.StatusId = 1;
							if (!InsertEmail(text, text2, emailItem.PriorityId, cRMspSelectEmailSendFoSetting_Result.EmailUserInfoId.GetValueOrDefault(), cRMspSelectEmailSendFoSetting_Result.EmailSettingId.GetValueOrDefault(), emailItem.EmailAddress, emailItem.StatusId, emailItem.EmailCmpId, emailItem.EmailCmpPrsId, emailItem.EmailCmpPrjId, emailCmpName: emailItem.EmailCmpName, emailCmpPrsName: emailItem.EmailCmpPrsName, emailPrsJob: emailItem.EmailPrsJob))
							{
								errorMessage = Messages.msgErrorInsertEmailInDatabase;
							}
						}
					}
				}
				else
				{
					errorMessage = Messages.msgErrorInActiveEmailSendFoSetting;
				}
			}
			else
			{
				errorMessage = Messages.msgErrorInReadingEmailSetting;
			}
		}
		catch (SqlException val4)
		{
			SqlException val5 = val4;
			flag = false;
			errorMessage = ((Exception)(object)val5).Message;
			Logs.LogError((Exception)(object)val5, "");
		}
		catch (IOException ex)
		{
			flag = false;
			errorMessage = ex.Message;
			Logs.LogError(ex, "");
		}
		catch (SmtpException ex2)
		{
			flag = false;
			errorMessage = ex2.Message;
			Logs.LogError(ex2, "");
		}
		catch (NetworkInformationException val6)
		{
			NetworkInformationException val7 = val6;
			flag = false;
			errorMessage = ((Exception)(object)val7).Message;
			Logs.LogError((Exception)(object)val7, "");
		}
		catch (Exception ex3)
		{
			flag = false;
			errorMessage = ex3.Message;
			Logs.LogError(ex3, "");
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIEntities?.Dispose();
		}
		return flag;
	}

	private bool InsertEmail(string emailSubject, string emailBody, int priorityId, int emailUsersInfoId, int emailSettingId, string emailAddress, int statusId, int? emailCmpId = null, int? emailCmpPrsId = null, int? emailCmpPrjId = null, string emailCmpPrsName = null, string emailCmpName = null, string emailPrsJob = null)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMSpIEntities = new CRMSpIEntities();
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Messages.FOTicketErjaShow;
			string appType = Configuration.AppType;
			short.Parse(now.ToString("yyyy", new PersianCulture()));
			DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
			now.ToString("HH:mm:ss");
			_ = Labels.FOPersonLabel;
			int userId = UserLogin.CurrentUser.UserId;
			if (!string.IsNullOrEmpty(emailSubject) && emailSubject.Length > 500)
			{
				emailSubject = emailSubject.Substring(0, 500);
			}
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedEmailHeaderId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedEmailDetailId", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			CRMSpIEntities cRMSpIEntities2 = cRMSpIEntities;
			string emailSubject2 = emailSubject;
			int? priorityId2 = priorityId;
			int? emailUsersInfoId2 = emailUsersInfoId;
			int? emailSettingId2 = emailSettingId;
			int? statusId2 = statusId;
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpIEntities2.EmailspInsertSendedEmail(emailSubject2, emailBody, priorityId2, emailUsersInfoId2, emailSettingId2, emailAddress, emailCmpId, emailCmpPrsId, emailCmpPrjId, emailCmpPrsName, emailCmpName, emailPrsJob, statusId2, userId, value, registerDatePersian, appType, lCID, result2, objectParameter, objectParameter2, objectParameter3, (result3 != 0) ? new int?(result3) : null));
			int result4 = 0;
			int.TryParse(num.ToString(), out result4);
			if (result4 > 0)
			{
				string text = "";
				if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
				{
					string text2 = objectParameter3.Value.ToString();
					if (text2.IndexOf("ErrorInInsertEmailSendDetail|", StringComparison.Ordinal) >= 0)
					{
						text = text + Messages.msgErrorInInsertEmailSendDetail + "-";
					}
					else if (text2.IndexOf("ErrorInInsertEmailSendHeader|", StringComparison.Ordinal) >= 0)
					{
						text = text + Messages.msgErrorInInsertEmailSendHeader + "-";
					}
					result = false;
				}
				else
				{
					int num2 = ((objectParameter != null && objectParameter.Value.ToString() != "0") ? int.Parse(objectParameter.Value.ToString()) : 0);
					int num3 = ((objectParameter2 != null && objectParameter2.Value.ToString() != "0") ? int.Parse(objectParameter2.Value.ToString()) : 0);
					result = ((num2 > 0 && num3 > 0) ? true : false);
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			result = false;
			Logs.LogError(ex, "");
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static void WriteEmailReceiveLog(string message, int emailUsersInfoId)
	{
		try
		{
			string value = ApplicationSettings.GetValue("EmailReceiveLogIsActive");
			value = ((!string.IsNullOrWhiteSpace(value)) ? value : "false");
			if (!(value.ToLower() == "true"))
			{
				return;
			}
			string text = "EmailReceiveLog-" + emailUsersInfoId + ".txt";
			string text2 = "~/App_Data/EmailReceiveLog";
			text2 = HostingEnvironment.MapPath(text2);
			if (!System.IO.Directory.Exists(text2))
			{
				System.IO.Directory.CreateDirectory(text2);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
			}
			text2 = text2 + "/" + text;
			HostingEnvironment.MapPath("~/App_Data/log.txt");
			string value2 = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
			lock (_lockEmailReceiveLog)
			{
				using StreamWriter streamWriter = new StreamWriter(text2, append: true);
				streamWriter.WriteLine(value2);
			}
		}
		catch (Imap4Exception ex)
		{
			Logs.LogError(ex, "");
		}
	}
}
