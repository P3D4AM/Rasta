using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using CRM.General.Security;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class FoEmail
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static RemoteCertificateValidationCallback _003C_003E9__12_0;

		public static RemoteCertificateValidationCallback _003C_003E9__12_1;

		public static RemoteCertificateValidationCallback _003C_003E9__13_0;

		public static RemoteCertificateValidationCallback _003C_003E9__13_1;

		internal bool _003CSendEmail_003Eb__12_0(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
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

		internal bool _003CSendEmail_003Eb__12_1(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
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

		internal bool _003CSendGeneralEmail_003Eb__13_0(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
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

		internal bool _003CSendGeneralEmail_003Eb__13_1(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
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

	public int? CenterId;

	public int? FoSettingId;

	private static string _useDefaultCredentials = "";

	private static string _enableSsl = "";

	private static string _port = "";

	private bool UseDefaultCredentials
	{
		get
		{
			try
			{
				FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)new CRMSpEntities().FOMobspSelectCrmFoSetting(null, null, CenterId, FoSettingId));
				if (fOMobspSelectCrmFoSetting_Result != null)
				{
					bool result = false;
					bool.TryParse(fOMobspSelectCrmFoSetting_Result.EmailSmtpUseDefaultCredentials.ToString(), out result);
					_useDefaultCredentials = result.ToString();
				}
				return bool.Parse(_useDefaultCredentials);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	private bool EnableSsl
	{
		get
		{
			try
			{
				FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)new CRMSpEntities().FOMobspSelectCrmFoSetting(null, null, CenterId, FoSettingId));
				if (fOMobspSelectCrmFoSetting_Result != null)
				{
					bool result = false;
					bool.TryParse(fOMobspSelectCrmFoSetting_Result.EmailSmtpEnableSSL.ToString(), out result);
					_enableSsl = result.ToString();
				}
				return bool.Parse(_enableSsl);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	private int Port
	{
		get
		{
			try
			{
				FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)new CRMSpEntities().FOMobspSelectCrmFoSetting(null, null, CenterId, FoSettingId));
				if (fOMobspSelectCrmFoSetting_Result != null)
				{
					int result = 0;
					int.TryParse(fOMobspSelectCrmFoSetting_Result.EmailSmtpPort.ToString(), out result);
					_port = result.ToString();
				}
				return int.Parse(_port);
			}
			catch (Exception)
			{
				return 25;
			}
		}
	}

	public FoEmail(int? centerId, int? foSettingId)
	{
		CenterId = centerId;
		FoSettingId = foSettingId;
	}

	public bool SendEmail(EmailSendViewModel item)
	{
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_09c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cf: Expected O, but got Unknown
		//IL_0a42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a49: Expected O, but got Unknown
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_0add: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae8: Expected O, but got Unknown
		//IL_08be: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c8: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef7: Expected O, but got Unknown
		bool flag = false;
		MailAddress mailAddress = null;
		MailAddress mailAddress2 = null;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			if (Enumerable.FirstOrDefault<FOMobspSelectEmailSettingById_Result>((IEnumerable<FOMobspSelectEmailSettingById_Result>)cRMEntities.FOMobspSelectEmailSettingById(item.EmailSettingId)) != null)
			{
				FOMobspSelectEmailUsersInfoById_Result fOMobspSelectEmailUsersInfoById_Result = Enumerable.FirstOrDefault<FOMobspSelectEmailUsersInfoById_Result>((IEnumerable<FOMobspSelectEmailUsersInfoById_Result>)cRMEntities.FOMobspSelectEmailUsersInfoById(item.EmailUsersInfoId));
				if (fOMobspSelectEmailUsersInfoById_Result != null)
				{
					fOMobspSelectEmailUsersInfoById_Result.euPassword = ((!string.IsNullOrEmpty(fOMobspSelectEmailUsersInfoById_Result.euPassword)) ? XorCipher.DecryptByPrivateKey(fOMobspSelectEmailUsersInfoById_Result.euPassword) : string.Empty);
					FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(lCID, result, CenterId, FoSettingId));
					if (fOMobspSelectCrmFoSetting_Result != null)
					{
						if (!item.IsLogEmailAdmin)
						{
							if (fOMobspSelectCrmFoSetting_Result.EmailSendingIsActive.HasValue && fOMobspSelectCrmFoSetting_Result.EmailSendingIsActive.GetValueOrDefault())
							{
								Dictionary<string, string> dictionary = new Dictionary<string, string>();
								Regex val = new Regex("[a-z]:\\\\(?:[^\\\\:]+\\\\)*((?:[^:\\\\]+)\\.\\w+)", (RegexOptions)1);
								List<string> list = new List<string>();
								string text = "";
								string text2 = "";
								ObjectParameter objectParameter = new ObjectParameter("EmailSubjectPatternFormulaResult", "");
								ObjectParameter objectParameter2 = new ObjectParameter("EmailBodyPatternFormulaResult", "");
								CRMEntities cRMEntities2 = cRMEntities;
								int? emailCmpId = item.EmailCmpId;
								int? emailCmpPrsId = item.EmailCmpPrsId;
								string cmpPassword = ((!string.IsNullOrEmpty(item.CmpPassword)) ? item.CmpPassword : "");
								int? foSettingId = fOMobspSelectCrmFoSetting_Result.FoSettingId;
								int? languageID = lCID;
								int? defaultLanguageID = result;
								ObjectParameter emailBodyPatternFormulaResult = objectParameter2;
								cRMEntities2.FOMobspGetEmailPatternFormulaResult(emailCmpId, emailCmpPrsId, cmpPassword, foSettingId, languageID, defaultLanguageID, objectParameter, emailBodyPatternFormulaResult);
								if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
								{
									text = objectParameter.Value.ToString();
								}
								if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
								{
									text2 = string.Format("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\">{0}</div><p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>", objectParameter2.Value.ToString());
									foreach (Match item2 in val.Matches(text2))
									{
										Match val2 = item2;
										string text3 = Guid.NewGuid().ToString();
										text2 = text2.Replace(((Capture)val2).Value, "cid:" + text3);
										dictionary.Add(text3, ((Capture)val2).Value);
									}
									foreach (Match item3 in Regex.Matches(text2, "<img.+?src=[\"'](.+?)[\"'].+?>", (RegexOptions)3))
									{
										string value = ((Capture)item3.Groups[1]).Value;
										if (!list.Contains(value))
										{
											list.Add(value);
										}
									}
								}
								if (fOMobspSelectEmailUsersInfoById_Result.euSMTPUseSsl.GetValueOrDefault())
								{
									using MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient();
									object obj = _003C_003Ec._003C_003E9__12_0;
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
												X509ChainStatus[] chainStatus2 = chain.ChainStatus;
												for (int j = 0; j < chainStatus2.Length; j++)
												{
													X509ChainStatus x509ChainStatus2 = chainStatus2[j];
													if (x509ChainStatus2.Status != X509ChainStatusFlags.RevocationStatusUnknown && x509ChainStatus2.Status != X509ChainStatusFlags.OfflineRevocation)
													{
														return false;
													}
												}
												return true;
											}
											return false;
										};
										_003C_003Ec._003C_003E9__12_0 = val3;
										obj = (object)val3;
									}
									smtpClient.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)obj;
									if (fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465) == 587)
									{
										smtpClient.Connect(fOMobspSelectEmailUsersInfoById_Result.euSMTPServer, fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.StartTls);
									}
									else
									{
										smtpClient.Connect(fOMobspSelectEmailUsersInfoById_Result.euSMTPServer, fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.SslOnConnect);
									}
									smtpClient.Authenticate(fOMobspSelectEmailUsersInfoById_Result.euUserName, fOMobspSelectEmailUsersInfoById_Result.euPassword);
									MimeMessage mimeMessage = new MimeMessage();
									mimeMessage.Bcc.Add(new MailboxAddress((item.EmailCmpPrsName != "") ? item.EmailCmpPrsName : item.EmailAddress, item.EmailAddress));
									mimeMessage.From.Add(new MailboxAddress(fOMobspSelectEmailUsersInfoById_Result.euNikeName, fOMobspSelectEmailUsersInfoById_Result.euNikeEmail));
									mimeMessage.Subject = text;
									mimeMessage.Priority = MessagePriority.Urgent;
									BodyBuilder bodyBuilder = new BodyBuilder();
									bodyBuilder.HtmlBody = text2;
									foreach (string key in dictionary.Keys)
									{
										string mimeMapping = MimeMapping.GetMimeMapping(dictionary[key]);
										LinkedResource linkedResource = new LinkedResource(dictionary[key], mimeMapping);
										linkedResource.ContentId = key;
										linkedResource.ContentType.MediaType = mimeMapping;
										linkedResource.TransferEncoding = TransferEncoding.Base64;
										linkedResource.ContentType.Name = Path.GetFileName(dictionary[key]);
										linkedResource.ContentLink = new Uri("cid:" + key);
									}
									if (list.Count > 0)
									{
										foreach (string item4 in list)
										{
											string text4 = HostingEnvironment.MapPath(item4.Replace("%2F", "/").Replace("%20", " "));
											string text5 = DateTime.Now.ToString("yyyyMMddHHmmss");
											if (!string.IsNullOrWhiteSpace(text4))
											{
												string mimeMapping2 = MimeMapping.GetMimeMapping(text4);
												LinkedResource linkedResource2 = new LinkedResource(text4, mimeMapping2);
												linkedResource2.ContentId = text5;
												linkedResource2.ContentType.MediaType = mimeMapping2;
												linkedResource2.TransferEncoding = TransferEncoding.Base64;
												linkedResource2.ContentType.Name = Path.GetFileName(text4);
												linkedResource2.ContentLink = new Uri("cid:" + text5);
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
									mailAddress = new MailAddress(item.EmailAddress, (item.EmailCmpPrsName != "") ? item.EmailCmpPrsName : item.EmailAddress);
									mailMessage.Bcc.Add(mailAddress);
									mailMessage.From = new MailAddress(fOMobspSelectEmailUsersInfoById_Result.euNikeEmail, fOMobspSelectEmailUsersInfoById_Result.euNikeName);
									mailMessage.Subject = text;
									mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
									mailMessage.Priority = MailPriority.High;
									mailMessage.IsBodyHtml = true;
									mailMessage.BodyEncoding = Encoding.UTF8;
									mailMessage.SubjectEncoding = Encoding.UTF8;
									AlternateView alternateView = AlternateView.CreateAlternateViewFromString(text2, (Encoding)null, "text/html");
									foreach (string key2 in dictionary.Keys)
									{
										string mimeMapping3 = MimeMapping.GetMimeMapping(dictionary[key2]);
										LinkedResource linkedResource3 = new LinkedResource(dictionary[key2], mimeMapping3);
										linkedResource3.ContentId = key2;
										linkedResource3.ContentType.MediaType = mimeMapping3;
										linkedResource3.TransferEncoding = TransferEncoding.Base64;
										linkedResource3.ContentType.Name = Path.GetFileName(dictionary[key2]);
										linkedResource3.ContentLink = new Uri("cid:" + key2);
									}
									if (list.Count > 0)
									{
										foreach (string item5 in list)
										{
											string text6 = HostingEnvironment.MapPath(item5.Replace("%2F", "/").Replace("%20", " "));
											string text7 = DateTime.Now.ToString("yyyyMMddHHmmss");
											if (!string.IsNullOrWhiteSpace(text6))
											{
												string mimeMapping4 = MimeMapping.GetMimeMapping(text6);
												LinkedResource linkedResource4 = new LinkedResource(text6, mimeMapping4);
												linkedResource4.ContentId = text7;
												linkedResource4.ContentType.MediaType = mimeMapping4;
												linkedResource4.TransferEncoding = TransferEncoding.Base64;
												linkedResource4.ContentType.Name = Path.GetFileName(text6);
												linkedResource4.ContentLink = new Uri("cid:" + text7);
												alternateView.LinkedResources.Add(linkedResource4);
											}
										}
									}
									mailMessage.AlternateViews.Add(alternateView);
									System.Net.Mail.SmtpClient smtpClient2 = new System.Net.Mail.SmtpClient();
									smtpClient2.DeliveryMethod = SmtpDeliveryMethod.Network;
									smtpClient2.Host = fOMobspSelectEmailUsersInfoById_Result.euSMTPServer;
									smtpClient2.EnableSsl = EnableSsl;
									smtpClient2.UseDefaultCredentials = UseDefaultCredentials;
									smtpClient2.Credentials = (ICredentialsByHost?)new NetworkCredential(fOMobspSelectEmailUsersInfoById_Result.euUserName, fOMobspSelectEmailUsersInfoById_Result.euPassword);
									smtpClient2.Timeout = 60000;
									smtpClient2.Port = Port;
									smtpClient2.ServicePoint.MaxIdleTime = 1;
									smtpClient2.Send(mailMessage);
									flag = true;
								}
								if (flag && !InsertEmail(text, text2, item.PriorityId, item.EmailUsersInfoId, item.EmailSettingId, item.EmailAddress, item.StatusId, item.EmailCmpId, item.EmailCmpPrsId, item.EmailCmpPrjId, emailCmpName: item.EmailCmpName, emailCmpPrsName: item.EmailCmpPrsName, emailPrsJob: item.EmailPrsJob, cId: CenterId))
								{
									_ = Messages.FOMsgErrorInInsertEmail;
								}
							}
						}
						else
						{
							string text8 = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.FoLogEmailAdminI)) ? fOMobspSelectCrmFoSetting_Result.FoLogEmailAdminI : "");
							string text9 = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.FoLogEmailAdminII)) ? fOMobspSelectCrmFoSetting_Result.FoLogEmailAdminII : "");
							if (text8 != "" || text9 != "")
							{
								Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
								Regex val4 = new Regex("[a-z]:\\\\(?:[^\\\\:]+\\\\)*((?:[^:\\\\]+)\\.\\w+)", (RegexOptions)1);
								string text10 = "";
								string text11 = "";
								text10 = item.EmailSubject;
								text11 = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\"><p>" + item.EmailBody + "</p></div><p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>";
								foreach (Match item6 in val4.Matches(text11))
								{
									Match val5 = item6;
									string text12 = Guid.NewGuid().ToString();
									text11 = text11.Replace(((Capture)val5).Value, "cid:" + text12);
									dictionary2.Add(text12, ((Capture)val5).Value);
								}
								if (fOMobspSelectEmailUsersInfoById_Result.euSMTPUseSsl.GetValueOrDefault())
								{
									using MailKit.Net.Smtp.SmtpClient smtpClient3 = new MailKit.Net.Smtp.SmtpClient();
									object obj2 = _003C_003Ec._003C_003E9__12_1;
									if (obj2 == null)
									{
										RemoteCertificateValidationCallback val6 = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
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
										_003C_003Ec._003C_003E9__12_1 = val6;
										obj2 = (object)val6;
									}
									smtpClient3.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)obj2;
									if (fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465) == 587)
									{
										smtpClient3.Connect(fOMobspSelectEmailUsersInfoById_Result.euSMTPServer, fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.StartTls);
									}
									else
									{
										smtpClient3.Connect(fOMobspSelectEmailUsersInfoById_Result.euSMTPServer, fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.SslOnConnect);
									}
									smtpClient3.Authenticate(fOMobspSelectEmailUsersInfoById_Result.euUserName, fOMobspSelectEmailUsersInfoById_Result.euPassword);
									MimeMessage mimeMessage2 = new MimeMessage();
									if (text8 != "")
									{
										mimeMessage2.Bcc.Add(new MailboxAddress(text8, text8));
									}
									if (text9 != "")
									{
										mimeMessage2.Bcc.Add(new MailboxAddress(text9, text9));
									}
									mimeMessage2.Bcc.Add(new MailboxAddress((item.EmailCmpPrsName != "") ? item.EmailCmpPrsName : item.EmailAddress, item.EmailAddress));
									mimeMessage2.From.Add(new MailboxAddress(fOMobspSelectEmailUsersInfoById_Result.euNikeName, fOMobspSelectEmailUsersInfoById_Result.euNikeEmail));
									mimeMessage2.Subject = text10;
									mimeMessage2.Priority = MessagePriority.Urgent;
									BodyBuilder bodyBuilder2 = new BodyBuilder();
									bodyBuilder2.HtmlBody = text11;
									foreach (string key3 in dictionary2.Keys)
									{
										string mimeMapping5 = MimeMapping.GetMimeMapping(dictionary2[key3]);
										LinkedResource linkedResource5 = new LinkedResource(dictionary2[key3], mimeMapping5);
										linkedResource5.ContentId = key3;
										linkedResource5.ContentType.MediaType = mimeMapping5;
										linkedResource5.TransferEncoding = TransferEncoding.Base64;
										linkedResource5.ContentType.Name = Path.GetFileName(dictionary2[key3]);
										linkedResource5.ContentLink = new Uri("cid:" + key3);
									}
									mimeMessage2.Body = bodyBuilder2.ToMessageBody();
									smtpClient3.Timeout = 60000;
									smtpClient3.Send(mimeMessage2);
									smtpClient3.Dispose();
									flag = true;
								}
								else
								{
									MailMessage mailMessage2 = new MailMessage();
									if (text8 != "")
									{
										mailAddress = new MailAddress(text8, text8);
										mailMessage2.Bcc.Add(mailAddress);
									}
									if (text9 != "")
									{
										mailAddress2 = new MailAddress(text9, text9);
										mailMessage2.Bcc.Add(mailAddress2);
									}
									mailMessage2.From = new MailAddress(fOMobspSelectEmailUsersInfoById_Result.euNikeEmail, fOMobspSelectEmailUsersInfoById_Result.euNikeName);
									mailMessage2.Subject = text10;
									mailMessage2.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
									mailMessage2.Priority = MailPriority.High;
									mailMessage2.IsBodyHtml = true;
									mailMessage2.BodyEncoding = Encoding.UTF8;
									mailMessage2.SubjectEncoding = Encoding.UTF8;
									AlternateView alternateView2 = AlternateView.CreateAlternateViewFromString(text11, (Encoding)null, "text/html");
									foreach (string key4 in dictionary2.Keys)
									{
										string mimeMapping6 = MimeMapping.GetMimeMapping(dictionary2[key4]);
										LinkedResource linkedResource6 = new LinkedResource(dictionary2[key4], mimeMapping6);
										linkedResource6.ContentId = key4;
										linkedResource6.ContentType.MediaType = mimeMapping6;
										linkedResource6.TransferEncoding = TransferEncoding.Base64;
										linkedResource6.ContentType.Name = Path.GetFileName(dictionary2[key4]);
										linkedResource6.ContentLink = new Uri("cid:" + key4);
										alternateView2.LinkedResources.Add(linkedResource6);
									}
									mailMessage2.AlternateViews.Add(alternateView2);
									System.Net.Mail.SmtpClient smtpClient4 = new System.Net.Mail.SmtpClient();
									smtpClient4.DeliveryMethod = SmtpDeliveryMethod.Network;
									smtpClient4.Host = fOMobspSelectEmailUsersInfoById_Result.euSMTPServer;
									smtpClient4.EnableSsl = EnableSsl;
									smtpClient4.UseDefaultCredentials = UseDefaultCredentials;
									smtpClient4.Credentials = (ICredentialsByHost?)new NetworkCredential(fOMobspSelectEmailUsersInfoById_Result.euUserName, fOMobspSelectEmailUsersInfoById_Result.euPassword);
									smtpClient4.Timeout = 60000;
									smtpClient4.Port = Port;
									smtpClient4.ServicePoint.MaxIdleTime = 1;
									smtpClient4.Send(mailMessage2);
									flag = true;
								}
								if (flag)
								{
									if (text8 != "")
									{
										string emailSubject2 = text10;
										string emailBody2 = text11;
										int priorityId2 = item.PriorityId;
										int emailUsersInfoId2 = item.EmailUsersInfoId;
										int emailSettingId2 = item.EmailSettingId;
										int statusId2 = item.StatusId;
										int? centerId = CenterId;
										if (!InsertEmail(emailSubject2, emailBody2, priorityId2, emailUsersInfoId2, emailSettingId2, text8, statusId2, null, null, null, null, null, null, centerId))
										{
											_ = Messages.FOMsgErrorInInsertEmail + " (LogEmailAdminI)";
										}
									}
									if (text9 != "")
									{
										string emailSubject3 = text10;
										string emailBody3 = text11;
										int priorityId3 = item.PriorityId;
										int emailUsersInfoId3 = item.EmailUsersInfoId;
										int emailSettingId3 = item.EmailSettingId;
										int statusId3 = item.StatusId;
										int? centerId = CenterId;
										if (!InsertEmail(emailSubject3, emailBody3, priorityId3, emailUsersInfoId3, emailSettingId3, text9, statusId3, null, null, null, null, null, null, centerId))
										{
											_ = Messages.FOMsgErrorInInsertEmail + " (LogEmailAdminII)";
										}
									}
								}
							}
						}
					}
					else
					{
						_ = Messages.FOMsgErrorInReadingSetting + " (FOSetting)";
					}
				}
				else
				{
					_ = Messages.FOspMsgErrorInReadingEmailSetting + " (SMTP)";
				}
			}
			else
			{
				_ = Messages.FOspMsgErrorInReadingEmailSetting;
			}
		}
		catch (Exception e)
		{
			flag = false;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return flag;
	}

	public bool SendGeneralEmail(EmailSendViewModel item)
	{
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0994: Unknown result type (might be due to invalid IL or missing references)
		//IL_099b: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_0a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a15: Expected O, but got Unknown
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab4: Expected O, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_0e82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8c: Expected O, but got Unknown
		//IL_087a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0884: Expected O, but got Unknown
		bool flag = false;
		MailAddress mailAddress = null;
		MailAddress mailAddress2 = null;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			if (Enumerable.FirstOrDefault<FOMobspSelectEmailSettingById_Result>((IEnumerable<FOMobspSelectEmailSettingById_Result>)cRMEntities.FOMobspSelectEmailSettingById(item.EmailSettingId)) != null)
			{
				FOMobspSelectEmailUsersInfoById_Result fOMobspSelectEmailUsersInfoById_Result = Enumerable.FirstOrDefault<FOMobspSelectEmailUsersInfoById_Result>((IEnumerable<FOMobspSelectEmailUsersInfoById_Result>)cRMEntities.FOMobspSelectEmailUsersInfoById(item.EmailUsersInfoId));
				if (fOMobspSelectEmailUsersInfoById_Result != null)
				{
					fOMobspSelectEmailUsersInfoById_Result.euPassword = ((!string.IsNullOrEmpty(fOMobspSelectEmailUsersInfoById_Result.euPassword)) ? XorCipher.DecryptByPrivateKey(fOMobspSelectEmailUsersInfoById_Result.euPassword) : string.Empty);
					FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(null, null, CenterId, FoSettingId));
					if (fOMobspSelectCrmFoSetting_Result != null)
					{
						if (!item.IsLogEmailAdmin)
						{
							bool result2 = false;
							if (item.EmailSendingIsActive.HasValue)
							{
								bool.TryParse(item.EmailSendingIsActive.ToString(), out result2);
							}
							else
							{
								bool.TryParse(fOMobspSelectCrmFoSetting_Result.EmailSendingIsActive.ToString(), out result2);
							}
							if (result2)
							{
								Dictionary<string, string> dictionary = new Dictionary<string, string>();
								Regex val = new Regex("[a-z]:\\\\(?:[^\\\\:]+\\\\)*((?:[^:\\\\]+)\\.\\w+)", (RegexOptions)1);
								List<string> list = new List<string>();
								string text = "";
								string text2 = "";
								text = item.EmailSubject;
								text2 = string.Format("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\">{0}</div><p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>", item.EmailBody);
								foreach (Match item2 in val.Matches(text2))
								{
									Match val2 = item2;
									string text3 = Guid.NewGuid().ToString();
									text2 = text2.Replace(((Capture)val2).Value, "cid:" + text3);
									dictionary.Add(text3, ((Capture)val2).Value);
								}
								foreach (Match item3 in Regex.Matches(text2, "<img.+?src=[\"'](.+?)[\"'].+?>", (RegexOptions)3))
								{
									string value = ((Capture)item3.Groups[1]).Value;
									if (!list.Contains(value))
									{
										list.Add(value);
									}
								}
								if (fOMobspSelectEmailUsersInfoById_Result.euSMTPUseSsl.GetValueOrDefault())
								{
									using MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient();
									object obj = _003C_003Ec._003C_003E9__13_0;
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
												X509ChainStatus[] chainStatus2 = chain.ChainStatus;
												for (int j = 0; j < chainStatus2.Length; j++)
												{
													X509ChainStatus x509ChainStatus2 = chainStatus2[j];
													if (x509ChainStatus2.Status != X509ChainStatusFlags.RevocationStatusUnknown && x509ChainStatus2.Status != X509ChainStatusFlags.OfflineRevocation)
													{
														return false;
													}
												}
												return true;
											}
											return false;
										};
										_003C_003Ec._003C_003E9__13_0 = val3;
										obj = (object)val3;
									}
									smtpClient.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)obj;
									if (fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465) == 587)
									{
										smtpClient.Connect(fOMobspSelectEmailUsersInfoById_Result.euSMTPServer, fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.StartTls);
									}
									else
									{
										smtpClient.Connect(fOMobspSelectEmailUsersInfoById_Result.euSMTPServer, fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.SslOnConnect);
									}
									smtpClient.Authenticate(fOMobspSelectEmailUsersInfoById_Result.euUserName, fOMobspSelectEmailUsersInfoById_Result.euPassword);
									BodyBuilder bodyBuilder = new BodyBuilder();
									MimeMessage mimeMessage = new MimeMessage();
									mimeMessage.Bcc.Add(new MailboxAddress((item.EmailCmpPrsName != "") ? item.EmailCmpPrsName : item.EmailAddress, item.EmailAddress));
									mimeMessage.From.Add(new MailboxAddress(fOMobspSelectEmailUsersInfoById_Result.euNikeName, fOMobspSelectEmailUsersInfoById_Result.euNikeEmail));
									mimeMessage.Subject = text;
									mimeMessage.Priority = MessagePriority.Urgent;
									bodyBuilder.HtmlBody = text2;
									foreach (string key in dictionary.Keys)
									{
										string mimeMapping = MimeMapping.GetMimeMapping(dictionary[key]);
										LinkedResource linkedResource = new LinkedResource(dictionary[key], mimeMapping);
										linkedResource.ContentId = key;
										linkedResource.ContentType.MediaType = mimeMapping;
										linkedResource.TransferEncoding = TransferEncoding.Base64;
										linkedResource.ContentType.Name = Path.GetFileName(dictionary[key]);
										linkedResource.ContentLink = new Uri("cid:" + key);
									}
									if (list.Count > 0)
									{
										foreach (string item4 in list)
										{
											string text4 = HostingEnvironment.MapPath(item4.Replace("%2F", "/").Replace("%20", " "));
											string text5 = DateTime.Now.ToString("yyyyMMddHHmmss");
											if (!string.IsNullOrWhiteSpace(text4))
											{
												string mimeMapping2 = MimeMapping.GetMimeMapping(text4);
												LinkedResource linkedResource2 = new LinkedResource(text4, mimeMapping2);
												linkedResource2.ContentId = text5;
												linkedResource2.ContentType.MediaType = mimeMapping2;
												linkedResource2.TransferEncoding = TransferEncoding.Base64;
												linkedResource2.ContentType.Name = Path.GetFileName(text4);
												linkedResource2.ContentLink = new Uri("cid:" + text5);
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
									mailAddress = new MailAddress(item.EmailAddress, (item.EmailCmpPrsName != "") ? item.EmailCmpPrsName : item.EmailAddress);
									mailMessage.Bcc.Add(mailAddress);
									mailMessage.From = new MailAddress(fOMobspSelectEmailUsersInfoById_Result.euNikeEmail, fOMobspSelectEmailUsersInfoById_Result.euNikeName);
									mailMessage.Subject = text;
									mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
									mailMessage.Priority = MailPriority.High;
									mailMessage.IsBodyHtml = true;
									mailMessage.BodyEncoding = Encoding.UTF8;
									mailMessage.SubjectEncoding = Encoding.UTF8;
									AlternateView alternateView = AlternateView.CreateAlternateViewFromString(text2, (Encoding)null, "text/html");
									foreach (string key2 in dictionary.Keys)
									{
										string mimeMapping3 = MimeMapping.GetMimeMapping(dictionary[key2]);
										LinkedResource linkedResource3 = new LinkedResource(dictionary[key2], mimeMapping3);
										linkedResource3.ContentId = key2;
										linkedResource3.ContentType.MediaType = mimeMapping3;
										linkedResource3.TransferEncoding = TransferEncoding.Base64;
										linkedResource3.ContentType.Name = Path.GetFileName(dictionary[key2]);
										linkedResource3.ContentLink = new Uri("cid:" + key2);
										alternateView.LinkedResources.Add(linkedResource3);
									}
									if (list.Count > 0)
									{
										foreach (string item5 in list)
										{
											string text6 = HostingEnvironment.MapPath(item5.Replace("%2F", "/").Replace("%20", " "));
											string text7 = DateTime.Now.ToString("yyyyMMddHHmmss");
											if (!string.IsNullOrWhiteSpace(text6))
											{
												string mimeMapping4 = MimeMapping.GetMimeMapping(text6);
												LinkedResource linkedResource4 = new LinkedResource(text6, mimeMapping4);
												linkedResource4.ContentId = text7;
												linkedResource4.ContentType.MediaType = mimeMapping4;
												linkedResource4.TransferEncoding = TransferEncoding.Base64;
												linkedResource4.ContentType.Name = Path.GetFileName(text6);
												linkedResource4.ContentLink = new Uri("cid:" + text7);
												alternateView.LinkedResources.Add(linkedResource4);
											}
										}
									}
									mailMessage.AlternateViews.Add(alternateView);
									System.Net.Mail.SmtpClient smtpClient2 = new System.Net.Mail.SmtpClient();
									smtpClient2.DeliveryMethod = SmtpDeliveryMethod.Network;
									smtpClient2.Host = fOMobspSelectEmailUsersInfoById_Result.euSMTPServer;
									smtpClient2.EnableSsl = fOMobspSelectEmailUsersInfoById_Result.euSMTPUseSsl ?? EnableSsl;
									smtpClient2.UseDefaultCredentials = fOMobspSelectEmailUsersInfoById_Result.euSMTPUseDefCredentials ?? UseDefaultCredentials;
									smtpClient2.Credentials = (ICredentialsByHost?)new NetworkCredential(fOMobspSelectEmailUsersInfoById_Result.euUserName, fOMobspSelectEmailUsersInfoById_Result.euPassword);
									smtpClient2.Port = fOMobspSelectEmailUsersInfoById_Result.euSMTPPort ?? Port;
									smtpClient2.ServicePoint.MaxIdleTime = 1;
									smtpClient2.Send(mailMessage);
									flag = true;
								}
								if (flag && !InsertEmail(text, text2, item.PriorityId, item.EmailUsersInfoId, item.EmailSettingId, item.EmailAddress, item.StatusId, item.EmailCmpId, item.EmailCmpPrsId, item.EmailCmpPrjId, emailCmpName: item.EmailCmpName, emailCmpPrsName: item.EmailCmpPrsName, emailPrsJob: item.EmailPrsJob, cId: item.CId))
								{
									_ = Messages.FOMsgErrorInInsertEmail;
								}
							}
						}
						else
						{
							string text8 = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.FoLogEmailAdminI)) ? fOMobspSelectCrmFoSetting_Result.FoLogEmailAdminI : "");
							string text9 = ((!string.IsNullOrEmpty(fOMobspSelectCrmFoSetting_Result.FoLogEmailAdminII)) ? fOMobspSelectCrmFoSetting_Result.FoLogEmailAdminII : "");
							if (text8 != "" || text9 != "")
							{
								Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
								Regex val4 = new Regex("[a-z]:\\\\(?:[^\\\\:]+\\\\)*((?:[^:\\\\]+)\\.\\w+)", (RegexOptions)1);
								string text10 = "";
								string text11 = "";
								text10 = item.EmailSubject;
								text11 = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /> <div dir=\"rtl\"><p>" + item.EmailBody + "</p></div><p style='display:none;'>" + DateTime.Now.ToString("R") + "</p>";
								foreach (Match item6 in val4.Matches(text11))
								{
									Match val5 = item6;
									string text12 = Guid.NewGuid().ToString();
									text11 = text11.Replace(((Capture)val5).Value, "cid:" + text12);
									dictionary2.Add(text12, ((Capture)val5).Value);
								}
								if (fOMobspSelectEmailUsersInfoById_Result.euSMTPUseSsl.GetValueOrDefault())
								{
									using MailKit.Net.Smtp.SmtpClient smtpClient3 = new MailKit.Net.Smtp.SmtpClient();
									object obj2 = _003C_003Ec._003C_003E9__13_1;
									if (obj2 == null)
									{
										RemoteCertificateValidationCallback val6 = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
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
										_003C_003Ec._003C_003E9__13_1 = val6;
										obj2 = (object)val6;
									}
									smtpClient3.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)obj2;
									if (fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465) == 587)
									{
										smtpClient3.Connect(fOMobspSelectEmailUsersInfoById_Result.euSMTPServer, fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.StartTls);
									}
									else
									{
										smtpClient3.Connect(fOMobspSelectEmailUsersInfoById_Result.euSMTPServer, fOMobspSelectEmailUsersInfoById_Result.euSMTPPort.GetValueOrDefault(465), SecureSocketOptions.SslOnConnect);
									}
									smtpClient3.Authenticate(fOMobspSelectEmailUsersInfoById_Result.euUserName, fOMobspSelectEmailUsersInfoById_Result.euPassword);
									BodyBuilder bodyBuilder2 = new BodyBuilder();
									MimeMessage mimeMessage2 = new MimeMessage();
									if (text8 != "")
									{
										mimeMessage2.Bcc.Add(new MailboxAddress(text8, text8));
									}
									if (text9 != "")
									{
										mimeMessage2.Bcc.Add(new MailboxAddress(text9, text9));
									}
									mimeMessage2.From.Add(new MailboxAddress(fOMobspSelectEmailUsersInfoById_Result.euNikeName, fOMobspSelectEmailUsersInfoById_Result.euNikeEmail));
									mimeMessage2.Subject = text10;
									mimeMessage2.Priority = MessagePriority.Urgent;
									bodyBuilder2.HtmlBody = text11;
									foreach (string key3 in dictionary2.Keys)
									{
										string mimeMapping5 = MimeMapping.GetMimeMapping(dictionary2[key3]);
										LinkedResource linkedResource5 = new LinkedResource(dictionary2[key3], mimeMapping5);
										linkedResource5.ContentId = key3;
										linkedResource5.ContentType.MediaType = mimeMapping5;
										linkedResource5.TransferEncoding = TransferEncoding.Base64;
										linkedResource5.ContentType.Name = Path.GetFileName(dictionary2[key3]);
										linkedResource5.ContentLink = new Uri("cid:" + key3);
									}
									mimeMessage2.Body = bodyBuilder2.ToMessageBody();
									smtpClient3.Timeout = 60000;
									smtpClient3.Send(mimeMessage2);
									smtpClient3.Dispose();
									flag = true;
								}
								else
								{
									MailMessage mailMessage2 = new MailMessage();
									if (text8 != "")
									{
										mailAddress = new MailAddress(text8, text8);
										mailMessage2.Bcc.Add(mailAddress);
									}
									if (text9 != "")
									{
										mailAddress2 = new MailAddress(text9, text9);
										mailMessage2.Bcc.Add(mailAddress2);
									}
									mailMessage2.From = new MailAddress(fOMobspSelectEmailUsersInfoById_Result.euNikeEmail, fOMobspSelectEmailUsersInfoById_Result.euNikeName);
									mailMessage2.Subject = text10;
									mailMessage2.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
									mailMessage2.Priority = MailPriority.High;
									mailMessage2.IsBodyHtml = true;
									mailMessage2.BodyEncoding = Encoding.UTF8;
									mailMessage2.SubjectEncoding = Encoding.UTF8;
									AlternateView alternateView2 = AlternateView.CreateAlternateViewFromString(text11, (Encoding)null, "text/html");
									foreach (string key4 in dictionary2.Keys)
									{
										string mimeMapping6 = MimeMapping.GetMimeMapping(dictionary2[key4]);
										LinkedResource linkedResource6 = new LinkedResource(dictionary2[key4], mimeMapping6);
										linkedResource6.ContentId = key4;
										linkedResource6.ContentType.MediaType = mimeMapping6;
										linkedResource6.TransferEncoding = TransferEncoding.Base64;
										linkedResource6.ContentType.Name = Path.GetFileName(dictionary2[key4]);
										linkedResource6.ContentLink = new Uri("cid:" + key4);
										alternateView2.LinkedResources.Add(linkedResource6);
									}
									mailMessage2.AlternateViews.Add(alternateView2);
									System.Net.Mail.SmtpClient smtpClient4 = new System.Net.Mail.SmtpClient();
									smtpClient4.DeliveryMethod = SmtpDeliveryMethod.Network;
									smtpClient4.Host = fOMobspSelectEmailUsersInfoById_Result.euSMTPServer;
									smtpClient4.EnableSsl = EnableSsl;
									smtpClient4.UseDefaultCredentials = UseDefaultCredentials;
									smtpClient4.Credentials = (ICredentialsByHost?)new NetworkCredential(fOMobspSelectEmailUsersInfoById_Result.euUserName, fOMobspSelectEmailUsersInfoById_Result.euPassword);
									smtpClient4.Port = Port;
									smtpClient4.ServicePoint.MaxIdleTime = 1;
									smtpClient4.Send(mailMessage2);
									flag = true;
								}
								if (flag)
								{
									if (text8 != "")
									{
										string emailSubject2 = text10;
										string emailBody2 = text11;
										int priorityId2 = item.PriorityId;
										int emailUsersInfoId2 = item.EmailUsersInfoId;
										int emailSettingId2 = item.EmailSettingId;
										int statusId2 = item.StatusId;
										int? cId = item.CId;
										if (!InsertEmail(emailSubject2, emailBody2, priorityId2, emailUsersInfoId2, emailSettingId2, text8, statusId2, null, null, null, null, null, null, cId))
										{
											_ = Messages.FOMsgErrorInInsertEmail + " (LogEmailAdminI)";
										}
									}
									if (text9 != "")
									{
										string emailSubject3 = text10;
										string emailBody3 = text11;
										int priorityId3 = item.PriorityId;
										int emailUsersInfoId3 = item.EmailUsersInfoId;
										int emailSettingId3 = item.EmailSettingId;
										int statusId3 = item.StatusId;
										int? cId = item.CId;
										if (!InsertEmail(emailSubject3, emailBody3, priorityId3, emailUsersInfoId3, emailSettingId3, text9, statusId3, null, null, null, null, null, null, cId))
										{
											_ = Messages.FOMsgErrorInInsertEmail + " (LogEmailAdminII)";
										}
									}
								}
							}
						}
					}
					else
					{
						_ = Messages.FOMsgErrorInReadingSetting + " (FOSetting)";
					}
				}
				else
				{
					_ = Messages.FOspMsgErrorInReadingEmailSetting + " (SMTP)";
				}
			}
			else
			{
				_ = Messages.FOspMsgErrorInReadingEmailSetting;
			}
		}
		catch (Exception e)
		{
			flag = false;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return flag;
	}

	private bool InsertEmail(string emailSubject, string emailBody, int priorityId, int emailUsersInfoId, int emailSettingId, string emailAddress, int statusId, int? emailCmpId = null, int? emailCmpPrsId = null, int? emailCmpPrjId = null, string emailCmpPrsName = null, string emailCmpName = null, string emailPrsJob = null, int? cId = null)
	{
		bool result = false;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			if (Enumerable.FirstOrDefault<FOMobspSelectEmailSettingById_Result>((IEnumerable<FOMobspSelectEmailSettingById_Result>)cRMEntities.FOMobspSelectEmailSettingById(emailSettingId)) != null)
			{
				if (Enumerable.FirstOrDefault<FOMobspSelectEmailUsersInfoById_Result>((IEnumerable<FOMobspSelectEmailUsersInfoById_Result>)cRMEntities.FOMobspSelectEmailUsersInfoById(emailUsersInfoId)) != null)
				{
					if (Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(null, null, CenterId, FoSettingId)) != null)
					{
						DateTime now = DateTime.Now;
						DateTime value = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						short.Parse(Financial.Get().Id.ToString());
						short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						_ = Messages.FOTicketErjaShow;
						string appType = Configuration.AppType;
						short.Parse(now.ToString("yyyy", new PersianCulture()));
						DateTimeClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
						now.ToString("HH:mm:ss");
						_ = Labels.FOPersonLabel;
						int value2 = -20;
						if (!string.IsNullOrEmpty(emailSubject) && emailSubject.Length > 500)
						{
							emailSubject = emailSubject.Substring(0, 500);
						}
						ObjectParameter objectParameter = new ObjectParameter("InsertedEmailHeaderId", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("InsertedEmailDetailId", 0);
						ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
						CRMEntities cRMEntities2 = cRMEntities;
						string emailSubject2 = emailSubject;
						int? priorityId2 = priorityId;
						int? emailUsersInfoId2 = emailUsersInfoId;
						int? emailSettingId2 = emailSettingId;
						int? statusId2 = statusId;
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.FOMobspInsertSendedEmail(emailSubject2, emailBody, priorityId2, emailUsersInfoId2, emailSettingId2, emailAddress, emailCmpId, emailCmpPrsId, emailCmpPrjId, emailCmpPrsName, emailCmpName, emailPrsJob, statusId2, value2, value, registerDatePersian, appType, lCID, result2, objectParameter, objectParameter2, objectParameter3, cId));
						int result3 = 0;
						int.TryParse(num.ToString(), out result3);
						if (result3 > 0)
						{
							string text = "";
							if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
							{
								string text2 = objectParameter3.Value.ToString();
								if (text2.IndexOf("ErrorInInsertEmailSendDetail|", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.FOMsgErrorInInsertEmailSendDetail + "-";
								}
								else if (text2.IndexOf("ErrorInInsertEmailSendHeader|", StringComparison.Ordinal) >= 0)
								{
									text = text + Messages.FOMsgErrorInInsertEmailSendHeader + "-";
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
					else
					{
						_ = Messages.FOMsgErrorInReadingSetting + " (FOSetting)";
					}
				}
				else
				{
					_ = Messages.FOspMsgErrorInReadingEmailSetting + " (SMTP)";
				}
			}
			else
			{
				_ = Messages.FOspMsgErrorInReadingEmailSetting;
			}
		}
		catch (Exception e)
		{
			result = false;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return result;
	}
}
