using DmitriySerebryakovKt_31_21.Models;

namespace DmitriySerebryakovKt_31_21.Tests
{
    public class DepartmentTests
    {
        [Fact]
        public void IsValidDepartmentName_KT_True()
        {
            //arrange
            var testDepartment = new Department
            {
                DepartmentName = "KT"
            };

            //act
            var result = testDepartment.IsValidDepartmentName();

            //assert
            Assert.True(result);
        }
    }
}