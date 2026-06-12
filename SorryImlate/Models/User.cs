using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorryImlate.Models
{
    public class User
    {
        public int UserId { get; set; }           // 内部識別用ID [cite: 221]
        public string UserCode { get; set; }      // ログインに使用 [cite: 221]
        public string Password { get; set; }      // ハッシュ値 [cite: 221]
        public string Name { get; set; }          // 氏名 [cite: 221]
        public string Role { get; set; }          // 'student' or 'teacher' [cite: 221]

    }
}
