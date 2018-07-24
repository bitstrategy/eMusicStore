using eMusicStore.Web.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace eMusicStore.Web.Controllers
{
    public class AccountController : Controller
    {
        private void MigrateShoppingCart(string userName)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.MigrateCart(userName);
            Session[ShoppingCart.CartSessionKey] = userName;
        }
        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    MigrateShoppingCart(model.UserName);
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/", StringComparison.Ordinal)
                        && !returnUrl.StartsWith("//", StringComparison.Ordinal) && !returnUrl.StartsWith("/\\", StringComparison.Ordinal))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码不正确");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, "question", "answer", true, null, out createStatus);
                if (createStatus == MembershipCreateStatus.Success)
                {
                    MigrateShoppingCart(model.UserName);
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "当前密码不正确或新密码无效.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "登录账户已经被注册了，请重新输入不同的登录账户";

                case MembershipCreateStatus.DuplicateEmail:
                    return "邮箱地址已经被注册了，请重新输入不同的邮箱地址";

                case MembershipCreateStatus.InvalidPassword:
                    return "密码设置不正确，不符合密码规则";

                case MembershipCreateStatus.InvalidEmail:
                    return "邮箱地址格式设置不正确";

                case MembershipCreateStatus.InvalidAnswer:
                    return "密码提示问题答案的格式设置不正确。";

                case MembershipCreateStatus.InvalidQuestion:
                    return "密码提示问题的格式设置不正确";

                case MembershipCreateStatus.InvalidUserName:
                    return "在数据库中未找到用户名";

                case MembershipCreateStatus.ProviderError:
                    return "提供程序返回一个未由其他 System.Web.Security.MembershipCreateStatus 枚举值描述的错误";

                case MembershipCreateStatus.UserRejected:
                    return "因为提供程序定义的某个原因而未创建用户";

                default:
                    return "未知错误，请将错误记录并联系系统管理员";
            }
        }
        #endregion
    }
}