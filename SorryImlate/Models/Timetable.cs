using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorryImlate.Models
{
    public class Timetable
    {
        public int TimetableId { get; set; }
        public string DayOfWeek { get; set; }
        public int Period { get; set; }
        public string SubjectName { get; set; }
        public int TeacherId { get; set; }

    }
}
