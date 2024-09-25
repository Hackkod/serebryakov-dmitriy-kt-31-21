namespace DmitriySerebryakovKt_31_21.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int AcademicDegreeId { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
        public List<Discipline> Disciplines { get; set; } = new List<Discipline>();
        public int? TeachingLoadId { get; set; }
        public TeachingLoad TeachingLoad { get; set; }
    }
}
