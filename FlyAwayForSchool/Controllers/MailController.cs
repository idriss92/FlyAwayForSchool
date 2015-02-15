using FlyAwayForSchool.CodeToUse;
using FlyAwayForSchool.Custom;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FlyAwayForSchool.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /SendMailer/  
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Index(Mail _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress("contacteasyflight@gmail.com");
                mail.Subject = "Validation de Réservation sur Easy Flight";
                string Body = "Bonjour . Votre réservation a bien été pris en compte. N'oubliez pas de vous acquitter des frais de voyage ";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                (mail.From.ToString(), "mamadoudavid");// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);

                
                return View("Index", _objModelMail);
            }
            else
            {
                return View();
            }
        }
    }
}