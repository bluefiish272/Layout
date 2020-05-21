using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class News
    {
        public string Category { get; set; } //隸屬的分類 (先保留)
        public Guid Uid { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Status { get; set; } //要改成enum，因為狀態是固定的定義
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
