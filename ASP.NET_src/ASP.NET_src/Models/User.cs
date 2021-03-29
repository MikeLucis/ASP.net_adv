using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_src.Models
{
    public class User
    {
        public int ID { get; set; }
        //[Required(ErrorMessage = "请输入收件人姓名")]
        //[Display(Name = "用户名")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "邮箱为必填项")]
        //[RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "请输入正确的电子邮箱地址")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "请输入收货人手机号")]
        //[RegularExpression(@"^1[3458][0-9]{9}$", ErrorMessage = "手机号格式不正确")]
        // 允许空值
        public string PhoneNum { get; set; }

        //[StringLength(16, MinimumLength = 6, ErrorMessage = "密码长度应在6~16位之间")]
        //[System.ComponentModel.DataAnnotations.Compare("ConfimPassWords")]
        ////二次输入密码必须和上次相同
        //public string NewPassWords { get; set; }

        //[DataType(DataType.Password)]
        //[StringLength(16, MinimumLength = 6, ErrorMessage = "密码长度应在6~16位之间")]
        //[System.ComponentModel.DataAnnotations.Compare("NewPassWords")]
        //二次输入密码必须和上次相同
        public string ConfimPassWords { get; set; }//密码长度 6~16位 
    }
}