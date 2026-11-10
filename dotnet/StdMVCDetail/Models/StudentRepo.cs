namespace StdMVCDetail.Models
{
    public static class StudentRepo
    {
        private static List<Student> Students = new List<Student>();
        private static int nextId = 1;

        static StudentRepo()
        {
            Students.Add(new Student { Id = 1, Name = "saugat", RollNo = "CS1001", Dept = "CS", Semester = 6 });
            Students.Add(new Student { Id = 2, Name = "ello", RollNo = "ART1002", Dept = "ART", Semester = 5 });
            Students.Add(new Student { Id = 3, Name = "mello", RollNo = "ENG1003", Dept = "ENG", Semester = 3 });
            nextId = 4;
        }

        public static List<Student> GetAll()
        {
            return Students;
        }

        public static Student GetById(int id)
        {
            Student found = null;
            foreach (Student s in Students)
            {
                if (s.Id == id)
                {
                    found = s;
                }
            }
            return found;
        }

        public static void Add(Student s)
        {
            s.Id = nextId;
            nextId++;
            Students.Add(s);
        }

        public static void Update(Student s)
        {
            Student old = GetById(s.Id);
            if (old != null)
            {
                old.Name = s.Name;
                old.RollNo = s.RollNo;
                old.Dept = s.Dept;
                old.Semester = s.Semester;
            }
        }

        public static void Delete(int id)
        {
            Student s = GetById(id);
            if (s != null)
            {
                Students.Remove(s);
            }
        }
    }
}
