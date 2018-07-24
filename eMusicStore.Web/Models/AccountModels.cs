using System.ComponentModel.DataAnnotations;

namespace eMusicStore.Web.Models
{

    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "{0}是必填项")]
        [DataType(DataType.Password)]
        [Display(Name = "旧密码")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(100, ErrorMessage = "{0}字符长度最少{2}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认新密码不一致.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessage = "请填写{0}")]
        [Display(Name = "登录账号")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请填写{0}")]
        [DataType(DataType.Password)]
        [Display(Name = "登录密码")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "{0}是必填项")]
        [Display(Name = "登录账户")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0}是必填项")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "{0}格式不正确")]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(100, ErrorMessage = "{0}字符长度最少{2}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "登录密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "登录密码和确认密码不一致.")]
        public string ConfirmPassword { get; set; }
    }
}
