using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DmitriySerebryakovKt_31_21.Models
{
    public class AcademicDegree
    {
        public enum AcademicDegreeNameTypes
        {
            [Display(Name = "Кандидат наук")]
            ScienceCandidate,
            [Display(Name = "Доктор наук")]
            ScienceDoctor,
        }

        public int AcademicDegreeId { get; set; }
        public AcademicDegreeNameTypes AcademicDegreeName { get; }
    }
}
