namespace AddsSystem.Client.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using AddsSystem.DAL;
    using AddsSystem.Common.Constants;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = Infrastructure.ViewBagAbout;
            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = Infrastructure.ViewBagContact;
            return View();
        }

        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                String userId = User.Identity.GetUserId();
                if (userId == null)
                {
                    string fileName = HttpContext.Server.MapPath(@Infrastructure.NoImagePath);

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, Infrastructure.ProfileImagePath);
                }
                // to get the user details to load user Image
                var bdUsers = HttpContext.GetOwinContext().Get<AddsSystemDbContext>();
                var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();

                return new FileContentResult(userImage.UserPhoto, Infrastructure.ProfileImagePath);
            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@Infrastructure.NoImagePath);
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, Infrastructure.ProfileImagePath);
            }
        }
    }
}