using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using CRM.General.Calendar;

namespace CRM.General.Utilities;

public class CEmail : IDisposable
{
	private const string ClassName = "CEmail";

	private string _hostSendingEmail = "";

	private string _hostSendingEmailPassword = "";

	private string _hostSMTP = "";

	private string _hostPOP3 = "";

	private string _DomainEmail = "";

	private string _Domain = "";

	private bool _allowSending;

	public bool AllowSending
	{
		set
		{
			_allowSending = value;
		}
	}

	public string HostSendingEmail
	{
		set
		{
			_hostSendingEmail = value;
		}
	}

	public string HostSendingEmailPassword
	{
		set
		{
			_hostSendingEmailPassword = value;
		}
	}

	public string HostSMTP
	{
		set
		{
			_hostSMTP = value;
		}
	}

	public string HostPOP3
	{
		set
		{
			_hostPOP3 = value;
		}
	}

	public string DomainEmail
	{
		set
		{
			_DomainEmail = value;
		}
	}

	public string Domain
	{
		set
		{
			_Domain = value;
		}
	}

	public void Dispose()
	{
		_allowSending = false;
	}

	public string Make_Main_Body(string strBody, string logoPath)
	{
		return "<div align='center'>    <table align='center' width='100%' cellpadding='0' cellspacing='0' border='0' style='border-collapse: collapse;'>        <tr>           <td align='center'>                <br /><br />                <table dir='rtl' align='center' width='90%' style='border-collapse: collapse;' border='0' cellpadding='0' cellspacing='0'>                    <tr>                        <td valign='top' width='100%' style='background-color: #FFFFFF; border: solid 1px #999999; border-collapse: collapse;' align='center'>                            <table align='center' width='90%' border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse;'>                                <tr><td colspan='2' height='30px'></td></tr>                                <tr>                                    <td align='right'><img align='middle' border='0' src='" + logoPath + "' /></td>                                    <td align='left'>&nbsp;</td>                               </tr>                                <tr><td align='center' colspan='2'><hr size='1' color='#87A9D1' /></td></tr>                                <tr>                                    <td>&nbsp;</td>                                    <td align='left'><span style='font-family: Tahoma; font-size: 9pt; color: #3C8EA1;'><span style='color: #B7363A;'>زمان ارسال:</span>&nbsp;" + PersianDate.GetCurrentTextDate + "&nbsp;&nbsp;-&nbsp;&nbsp;" + DateTime.Now.ToString("HH:mm") + "</span></td>                                </tr>                                <tr><td colspan='2' height='10px'></td></tr>                                <tr>                                    <td dir='rtl' align='right' valign='top' style='padding: 20px 20px 20px 20px; text-align: justify; line-height: 23px;' colspan='2'>" + strBody + "                                    </td>                                </tr>                                <tr><td colspan='2' height='10px'></td></tr>                                <tr><td align='center' colspan='2'><hr size='1' color='#87A9D1' /></td></tr>                                <tr><td dir='ltr' align='center' colspan='2' height='40px' style='font-family: Tahoma; font-size: 8pt; color: #000000;'>Copyright © " + DateTime.Now.Year + " By <strong>" + _DomainEmail + "</strong> . All right reserved.</td></tr>                            </table>                        </td>                    </tr>                </table>            </td>        </tr>    </table></div>";
	}

	public bool Send_Email(string[] arrEmail, string strSubject, string strBody)
	{
		return Send_Email(arrEmail, strSubject, strBody, null);
	}

	public bool Send_Email(string[] arrEmail, string strSubject, string strBody, List<object[]> attachments)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		bool result = false;
		if (_allowSending)
		{
			string text = "";
			try
			{
				for (int i = 0; i < arrEmail.Length; i++)
				{
					if (arrEmail[i].Trim() != "")
					{
						if (text != "")
						{
							text += ",";
						}
						text += arrEmail[i].Trim();
					}
				}
				NetworkCredential credentials = new NetworkCredential(_hostSendingEmail, _hostSendingEmailPassword);
				SmtpClient smtpClient = new SmtpClient();
				smtpClient.Credentials = (ICredentialsByHost?)(object)credentials;
				smtpClient.Host = _hostSMTP;
				MailMessage mailMessage = new MailMessage();
				mailMessage.From = new MailAddress(_hostSendingEmail);
				mailMessage.To.Add(text);
				mailMessage.Subject = strSubject;
				mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
				mailMessage.Priority = MailPriority.High;
				mailMessage.IsBodyHtml = true;
				mailMessage.Body = strBody;
				mailMessage.BodyEncoding = Encoding.UTF8;
				mailMessage.SubjectEncoding = Encoding.UTF8;
				if (attachments != null)
				{
					foreach (object[] attachment2 in attachments)
					{
						string text2 = attachment2[0].ToString();
						Attachment attachment = (Attachment)attachment2[1];
						ContentDisposition? contentDisposition = attachment.ContentDisposition;
						contentDisposition.CreationDate = File.GetCreationTime(attachment.Name);
						contentDisposition.ModificationDate = File.GetLastWriteTime(text2);
						contentDisposition.ReadDate = File.GetLastAccessTime(text2);
						contentDisposition.FileName = Path.GetFileName(text2);
						contentDisposition.Size = new FileInfo(text2).Length;
						contentDisposition.DispositionType = "attachment";
						mailMessage.Attachments.Add(attachment);
					}
				}
				smtpClient.Send(mailMessage);
				result = true;
			}
			catch (SmtpException)
			{
				result = false;
			}
			catch (Exception)
			{
				result = false;
			}
		}
		return result;
	}
}
