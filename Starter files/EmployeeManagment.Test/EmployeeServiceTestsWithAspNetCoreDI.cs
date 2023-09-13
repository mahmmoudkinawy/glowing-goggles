//using EmployeeManagment.Test.Fixtures;

//namespace EmployeeManagment.Test;
//public class EmployeeServiceTestsWithAspNetCoreDI
//    : IClassFixture<EmployeeServiceWithAspNetCoreDIFixture>
//{
//    private readonly EmployeeServiceWithAspNetCoreDIFixture _employeeServiceFixture;

//    public EmployeeServiceTestsWithAspNetCoreDI(
//        EmployeeServiceWithAspNetCoreDIFixture employeeServiceFixture)
//    {
//        _employeeServiceFixture = employeeServiceFixture;
//    }


//    [Fact(Skip = "Skipping this one for a problem in the implementation.")]
//    [Trait("Category","Skipped Unit Tests")]
//    public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
//    {
//        // AAA
//        var obligatoryCourse = _employeeServiceFixture
//            .EmployeeManagementRepository
//            .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

//        // Act
//        var internalEmployee = _employeeServiceFixture.EmployeeService
//            .CreateInternalEmployee("Brooklyn", "Cannon");

//        // Assert
//        Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
//    }
//}
