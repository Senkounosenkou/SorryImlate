using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorryImlate.Models
{
    public class DelayEvidence
    {
        public int EvidenceId { get; set; }
        public int LogId { get; set; }
        public string ImagePath { get; set; }
        public string EvidenceUrl { get; set; }
    }
}
