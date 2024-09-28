namespace DmitriySerebryakovKt_31_21.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
