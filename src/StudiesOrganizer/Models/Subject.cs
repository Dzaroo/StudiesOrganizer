using System.Collections.Generic;

namespace StudiesOrganizer.Models
{
    public class Subject : ModelBase
    {
        public string Name { get; set; }
        public short StudySemester { get; set; }
        public string LecturerFullName { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }
    }
}
