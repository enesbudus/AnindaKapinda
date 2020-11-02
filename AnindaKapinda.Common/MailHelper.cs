using AnindaKapinda.Model;
using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace AnindaKapinda.Common
{
   public class MailHelper
    {
        public static bool SendMail(Kullanici user)
        {
            try
            {
                MailAddress fromAddress = new MailAddress("anindakapindaankara@gmail.com");
                MailAddress toAddress = new MailAddress(user.Mail);

                MailMessage message = new MailMessage();
                message.Subject = "Anında Kapında Üyelik Daveti";
                message.Body = $"<p>Anında Kapında sistemine davet edildiniz. Kullanıcı hesabınız aşagaki bilgilerle oluşturulmuştur. Linke tıklayarak giriş yapabilirsiniz.</p><p>Ad : {user.Adi}</p><p>Soyad : {user.Soyadi}</p><p>Mail : {user.Mail}</p><p>{user.Sifre}</p><p><a href='http://localhost:65095/Account/Activate?code={user.AktivasyonKodu}'>Giriş yapmak için tıklayın</a></p>";
                message.IsBodyHtml = true;
                message.From = fromAddress;
                message.To.Add(toAddress);

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("anindakapindaankara@gmail.com","bilgeadam") ;
                smtp.EnableSsl = true;

                smtp.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
