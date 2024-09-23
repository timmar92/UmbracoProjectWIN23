using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoProjectWIN23.Models;
using System.Net;
using System.Net.Mail;

namespace UmbracoProjectWIN23.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ContactSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }

        public IActionResult HandleSubmit(ContactFormModel form)
        {

            if (!ModelState.IsValid)
            {
                ViewData["name"] = form.Name;
                ViewData["phone"] = form.Phone;
                ViewData["email"] = form.Email;

                ViewData["error_name"] = string.IsNullOrEmpty(form.Name);
                ViewData["error_phone"] = string.IsNullOrEmpty(form.Phone);
                ViewData["error_email"] = string.IsNullOrEmpty(form.Email);

                return CurrentUmbracoPage();
            }

            try
            {
                var smtpClient = new SmtpClient("smtp.mailersend.net")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("MS_JPt8wK@trial-pq3enl6mnd8g2vwr.mlsender.net", "qLGCUWE8zoAmS7iZ"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("MS_JPt8wK@trial-pq3enl6mnd8g2vwr.mlsender.net"),
                    Subject = "New Contact Form Submission",
                    Body = $"Name: {form.Name}, Phone: {form.Phone}, Email: {form.Email}, Option: {form.Option}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(form.Email);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                ViewData["error"] = "There was an error sending the email.";
                return CurrentUmbracoPage();
            }

            ViewData["success"] = "form submitted successfully!";
            return CurrentUmbracoPage();
        }

        public IActionResult HandleServiceForm(ServiceFormModel serviceForm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["name"] = serviceForm.Name;
                ViewData["email"] = serviceForm.Email;
                ViewData["question"] = serviceForm.Question;

                ViewData["error_name"] = string.IsNullOrEmpty(serviceForm.Name);
                ViewData["error_email"] = string.IsNullOrEmpty(serviceForm.Email);
                ViewData["error_question"] = string.IsNullOrEmpty(serviceForm.Question);

                return CurrentUmbracoPage();
            }

            try
            {
                var smtpClient = new SmtpClient("smtp.mailersend.net")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("MS_JPt8wK@trial-pq3enl6mnd8g2vwr.mlsender.net", "qLGCUWE8zoAmS7iZ"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("MS_JPt8wK@trial-pq3enl6mnd8g2vwr.mlsender.net"),
                    Subject = "New Service Form Submission",
                    Body = $"Name: {serviceForm.Name} Email: {serviceForm.Email}, Your question: {serviceForm.Question}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(serviceForm.Email);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                ViewData["error"] = "There was an error sending the email.";
                return CurrentUmbracoPage();
            }

            ViewData["success"] = "form submitted successfully!";
            return CurrentUmbracoPage();
        }

        public IActionResult HandleHomePageForm(HomepageFormModel homePageForm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["name"] = homePageForm.Name;
                ViewData["email"] = homePageForm.Email;
                ViewData["phone"] = homePageForm.Phone;

                ViewData["error_name"] = string.IsNullOrEmpty(homePageForm.Name);
                ViewData["error_email"] = string.IsNullOrEmpty(homePageForm.Email);
                ViewData["error_phone"] = string.IsNullOrEmpty(homePageForm.Phone);

                return CurrentUmbracoPage();
            }

            try
            {
                var smtpClient = new SmtpClient("smtp.mailersend.net")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("MS_JPt8wK@trial-pq3enl6mnd8g2vwr.mlsender.net", "qLGCUWE8zoAmS7iZ"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("MS_JPt8wK@trial-pq3enl6mnd8g2vwr.mlsender.net"),
                    Subject = "New Homepage Form Submission",
                    Body = $"Name: {homePageForm.Name} Email: {homePageForm.Email}, Phone: {homePageForm.Phone}, Option: {homePageForm.Option}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(homePageForm.Email);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                ViewData["error"] = "There was an error sending the email.";
                return CurrentUmbracoPage();
            }

            ViewData["success"] = "form submitted successfully!";
            return CurrentUmbracoPage();
        }

        public IActionResult HandleSidebarForm(SidebarFormModel sidebarForm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["email"] = sidebarForm.Email;

                ViewData["error_email"] = string.IsNullOrEmpty(sidebarForm.Email);

                return CurrentUmbracoPage();
            }

            try
            {
                var smtpClient = new SmtpClient("smtp.mailersend.net")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("MS_JPt8wK@trial-pq3enl6mnd8g2vwr.mlsender.net", "qLGCUWE8zoAmS7iZ"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("MS_JPt8wK@trial-pq3enl6mnd8g2vwr.mlsender.net"),
                    Subject = "New Sidebar Form Submission",
                    Body = $"Email: {sidebarForm.Email}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(sidebarForm.Email);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                ViewData["error"] = "There was an error sending the email.";
                return CurrentUmbracoPage();
            }


            ViewData["success"] = "form submitted successfully!";
            return CurrentUmbracoPage();
        }
    }
}
