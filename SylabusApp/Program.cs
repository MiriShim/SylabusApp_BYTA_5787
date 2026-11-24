using Microsoft.EntityFrameworkCore;

namespace SylabusApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var list = GetUnits(1);
        foreach (var unit in list)
        {
            Console.WriteLine(unit);


            SylabusContext ctx = new SylabusContext();

            if (!ctx.Database.EnsureCreated())
                Console.WriteLine("DB has been exists");
            else
                Console.WriteLine("DB is created now");

            Subject cSharpSubject = new Subject() { SubjectName = "CSharp" };
            //ctx.Subjects.Add(cSharpSubject);
            //ctx.SaveChanges();

            Console.WriteLine("Please type new subject name");
            AddSubject2(new Subject()
            {
                Semester = new Random().Next(1, 4),
                SubjectName = Console.ReadLine()
            });

            DeleteSubject(cSharpSubject);
            DeleteSubject(subId: 1);
            DeleteSubject();

            //CRUD ::: create. read.update.delete.


            // Console.WriteLine("Hello, World!");

            // Subject cSharpSubject = new Subject() { SubjectName = "CSharp" };

            // Unit u = new Unit() {Name="Reflection" };
            // u.Subject= cSharpSubject;

            // Unit u2 = new() { Name = "Generic", Subject = cSharpSubject };


            // Subject java = new Subject() { SubjectName = "Java" };
            // java.Units.Add(new Unit() { Name = "משתנים" });
            // java.Units.Add(new Unit() { Name = "לולאות" });

            //Unit arrays = new Unit() { Name = "מערכים" } ;
            // java.Units.Add(arrays);

            // arrays.SubUnits.Add(new SubUnit() { Name = "מערכים חד ממדיים" });
            // arrays.SubUnits.Add(new SubUnit() { Name = "מערכים דו ממדיים" });


            //u.Name = "EFCore";

            //u.Subject.Id = 88;

            //u.Subject = new Subject();
            //u.Subject.SubjectName = "C#";

            //u.Subject = new  () { Id = 1, SubjectName = "reflection", Semester = 4 };
        }
    }

    public async static void AddSubject(Subject newSubject)
    {
        using (SylabusContext ctx = new())
        {
            ctx.Subjects.Add(newSubject);

            int rows = ctx.SaveChanges();

            Console.WriteLine($"{rows} lines modified");

            //Task<int> taskSaving=  ctx.SaveChangesAsync();
            //Console.WriteLine(  $"{taskSaving.Result } lines modified");
            ////.............
            ////.............
            ////.............
            ////.............
        }


        // using (Subject s = new()) ;
    }


    public static void AddSubject2(Subject newSubject)
    {
        try
        {
            using SylabusContext ctx = new();

            ctx.Subjects.Add(newSubject);

            int rows = ctx.SaveChanges();

            Console.WriteLine($"{rows} lines modified");
        }
        catch (InvalidDataException ie)
        {
            Console.WriteLine($"Error: נתוני לא חוקיים {ie.Message} {ie.Data.Count}::");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    public static void DeleteSubject(Subject subject = null, int subId = 0)
    {
        if (subject == null && subId == 0)
            throw new Exception("חובה לשלוח לפחות פרמטר אחד");
        int idToDelete = 0;
        if (subId != 0)
            idToDelete = subId;
        else if (subject != null)
            idToDelete = subject.Id;

        try
        {
            using SylabusContext ctx = new();
            if (subId != 0)
            {
                // Subject  entity = ctx.Subjects.Find(subId);
                var entity = ctx.Subjects.Find(idToDelete);

                if (entity != null)
                {
                    ctx.Subjects.Remove(entity);
                    ctx.SaveChanges();
                }
            }
        }
        catch
        {
            Console.WriteLine("Cannot delete"); ;
        }
}

    /// <summary>
    /// מחיקה יעילה יותר: עם גישה אחת ל- DB
    /// אבל קצת מסוכנת
    /// </summary>
    /// <param name="id"></param>
 public void DeleteWithoutFetching(int id)
    {
        try
        {
            using SylabusContext ctx = new();

            var entity = new Subject { Id = id };

            ctx.Subjects.Attach(entity);
            ctx.Subjects.Remove(entity);
             
            ctx.SaveChanges();
        }
        catch
        { 
        }
    }

    /// <summary>
    /// lesson 3
    /// </summary>
    /// <param name="subjecttId"></param>
    /// <returns></returns>
    public static List<Unit > GetUnits(int subjecttId)
    {
        try
        {
            using SylabusContext ctx = new();

            List<Unit> l = ctx.Units.Include(s=>s.Subject ).Where(u=>u.SubjectId==subjecttId ).ToList ( );

            return l;   
            
        }
        catch (InvalidDataException ie)
        {
            Console.WriteLine($"Error: נתוני לא חוקיים {ie.Message} {ie.Data.Count}::");
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return null;
        }

    }
}

