using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Member
    {
        public string Category { get; set; } //隸屬的分類 (公司或群組的概念)
        public string CompanyId { get; set; } //公司ID，用於查出對應的公司資訊
        public string UserId { get; set; } //使用者ID，用於查出對應的使用者資訊
        public string AccessToken { get; set; } //第三方驗證的存取token
        public string ID { get; set; }
        
        [Required(ErrorMessage = "請輸入您的大名")]
        public string Name { get; set; }
        [Required(ErrorMessage ="請輸入信箱")]
        [EmailAddress]
        public string Account { get; set; } //初期先用mail當帳號
        public string Password { get; set; } //初期先用mail當帳號
        public string MobilePhone { get; set; }
        public string RegisterMail { get; set; } //註冊用的信箱
        public string PersonalMail { get; set; }
        public string CompanyMail { get; set; }
        public string Status { get; set; } //要改成enum，因為狀態是固定的定義
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LoginCount { get; set; }
    }
}
