namespace MyApp
{
    public class Student
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string? fname { get; set; }
        public string? lname { get; set; }
        public double _grade;
        public double grade
        {
            get
            {
                return _grade;
            }

            set
            {
                if (value >= 0 && value <= 20)
                {
                    _grade = value;
                }
                else
                {
                    _grade = 0.00;
                }
            }
        } 
        public Student(string? fname, string? lname) 
        {
            this.Id = _nextId;
            _nextId++;
            this.fname = fname;
            this .lname = lname;
        }

        public static double Average(List<Student> students)
        {
            double sum = 0;
            int cpt = 0;
            if (students is null || students.Count == 0) return 0;
            foreach (Student student in students)
            {
                sum += student.grade;
                cpt++;
            }
            return sum / cpt;
        }
        public static string Search(string? name, List<Student> students)
        {if (name == null)
                return "Please enter a name";
         if (students is null || students.Count == 0)
                return "the list is empty";
        foreach(Student student in students)
            {
                if (name == student.fname || name == student.lname)
                    return $"Student found \n{student}";
            }
            return "Student not found";
        }
        public override string ToString()
        {
            return $" ID: {this.Id}" +
                $"\n First name : {fname}" +
                $"\n Last name : {lname}" +
                $"\n Grade : {_grade}";
        }

    }



}