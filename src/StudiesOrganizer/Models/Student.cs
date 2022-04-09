using System;
using System.Collections.Generic;

namespace StudiesOrganizer.Models
{
    public class Student : ModelBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }
        public string FullName => Surname + " " + Name;
    }
}
