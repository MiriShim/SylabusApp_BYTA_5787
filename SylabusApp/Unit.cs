using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylabusApp
{  
    internal class Unit
    {

        public int UnitId { get; set; }
        public string Name { get; set; }
        public  string Description   { get; set; }
        public int EstimatedHours { get; set; } //משוער, מוערך

        public int SubjectId { get; set; }

        public virtual  Subject Subject { get; set; }

        public virtual  ICollection<SubUnit>   SubUnits { get; set; }
    }
}
