using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylabusApp
{
    internal class SubUnit
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual Unit ParentUnit   { get; set; }
        public string Name { get; set; }

    }
}
