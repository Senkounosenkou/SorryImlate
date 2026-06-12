using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorryImlate.Models
{
    public class AttendanceLog
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public int TimetableId { get; set; }
        public DateTime ClassDate { get; set; }
        public string Status { get; set; }
        public int IsApproved { get; set; } // 0:未承認, 1:承認済, 2:却下
        public DateTime CreatedAt { get; set; }

    }
}
