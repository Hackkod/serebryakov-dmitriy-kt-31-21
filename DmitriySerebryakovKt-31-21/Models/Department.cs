using System.Text.RegularExpressions;

namespace DmitriySerebryakovKt_31_21.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public bool IsValidDepartmentName()
        {
            return Regex.IsMatch(DepartmentName, @"\D*");
        }
    }
}
