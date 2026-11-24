using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylabusApp
{
    internal class Subject //: IDisposable 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int Semester   { get; set; }

        public virtual  ICollection<Unit> Units { get; set; }

         public ICollection<Student> Students { get; set; }

        //public void Dispose()
        //{
        //    Console.WriteLine(  "האוביקט התנקה מהזיכרון" );
        //}
    }
}
