using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ASP.NET_src.Models
{
    public class TeacherUser
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "请输入教师号码")]
        [DisplayName("教师号码*")]
        public string TeacherNumber { get; set; }

        [Required(ErrorMessage = "请输入教师名称")]
        [DisplayName("教师名称*")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "密码长度应在8~20位之间")]
        [DisplayName("密码*")]
        public string Password { get; set; }

        [DisplayName("性别")]
        [StringLength(2)]
        public string Gender { get; set; }

        [DisplayName("专业名称")]
        public string ProfessionalTitle { get; set; }

        [Required(ErrorMessage = "邮箱为必填项")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "请输入正确的电子邮箱地址")]
        [DisplayName("电子邮件*")]
        public string Email { get; set; }

        [DisplayName("QQ号码")]
        public string QQ { get; set; }

        [Required(ErrorMessage = "请输入收货人手机号")]
        [RegularExpression(@"^1[3458][0-9]{9}$", ErrorMessage = "手机号格式不正确")]
        [DisplayName("电话号码*")]
        public string Telephone { get; set; }
    }
}