using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDockApp
{
    public class Person
    {
        // 名前
        public string Name { get; set; }
        // 性別
        public Gender Gender { get; set; }
        // 認証済みユーザーかどうか
        public bool AuthMember { get; set; }

        public Uri Link { get; set; }
    }
}
