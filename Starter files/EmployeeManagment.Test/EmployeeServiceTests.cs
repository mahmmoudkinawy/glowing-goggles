using EmployeeManagement.Business.EventArguments;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagment.Test.Fixtures;
using Xunit.Abstractions;

namespace EmployeeManagment.Test;

[Collection("EmployeeServiceCollection")]
public class EmployeeServiceTests // : IClassFixture<EmployeeServiceFixture>
{
    private readonly EmployeeServiceFixture _employeeServiceFixture;
    private readonly ITestOutputHelper _testOutputHelper;

    public EmployeeServiceTests(EmployeeServiceFixture employeeServiceFixture,
        ITestOutputHelper testOutputHelper)
    {
        _employeeServiceFixture = employeeServiceFixture ?? 
            throw new ArgumentNullException(nameof(employeeServiceFixture));
        _testOutputHelper = testOutputHelper ??
            throw new ArgumentNullException(nameof(testOutputHelper));
    }

    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
    {
        // AAA
        var obligatoryCourse = _employeeServiceFixture.EmployeeManagementTestDataRepository
            .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

        // Act
        var internalEmployee = _employeeServiceFixture.EmployeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        _testOutputHelper.WriteLine($"Employee after Act: " +
            $"{internalEmployee.FirstName} {internalEmployee.LastName}");

        internalEmployee.AttendedCourses
            .ForEach(c => 
                _testOutputHelper.WriteLine($"Attended course: {c.Id} {c.Title}"));

        // Assert
        Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
    }

    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicate()
    {
        // AAA

        // Act
        var internalEmployee = _employeeServiceFixture.EmployeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        Assert.Contains(
            internalEmployee.AttendedCourses,
            course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
    }

    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicateTwo()
    {
        // AAA

        // Act
        var internalEmployee = _employeeServiceFixture.EmployeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        Assert.Contains(
            internalEmployee.AttendedCourses,
            course => course.Id == Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));
    }

    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicateThree()
    {
        // AAA

        var obligatoryCourses = _employeeServiceFixture
            .EmployeeManagementTestDataRepository
            .GetCourses(
                Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        // Act
        var internalEmployee = _employeeServiceFixture
            .EmployeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
    }

    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_AttendedCoursesMustBeBeNew()
    {
        // AAA

        var obligatoryCourses = _employeeServiceFixture.EmployeeManagementTestDataRepository
            .GetCourses(
                Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        // Act
        var internalEmployee = _employeeServiceFixture.EmployeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        // foreach (var course in internalEmployee.AttendedCourses)
        // {
        //     Assert.False(course.IsNew);
        // }

        Assert.All(
            internalEmployee.AttendedCourses,
            course => Assert.False(course.IsNew));
    }


    [Fact]
    public async Task CreateInternalEmployee_InternalEmployeeCreated_AttendedCoursesMustBeBeNew_Async()
    {
        // AAA

        var obligatoryCourses = await _employeeServiceFixture
            .EmployeeManagementTestDataRepository
            .GetCoursesAsync(
                Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        // Act
        var internalEmployee = await _employeeServiceFixture
            .EmployeeService
            .CreateInternalEmployeeAsync("Brooklyn", "Cannon");

        // Assert
        // foreach (var course in internalEmployee.AttendedCourses)
        // {
        //     Assert.False(course.IsNew);
        // }

        Assert.All<Course>(
            internalEmployee.AttendedCourses,
            course => Assert.False(course.IsNew));
    }

    [Fact]
    public async Task GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown()
    {
        var internalEmployee = new InternalEmployee(
            "Brooklyn", "Cannon", 5, 3000, false, 1);

        // Act
        await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
             async () => await _employeeServiceFixture.EmployeeService
                .GiveRaiseAsync(internalEmployee, 50));
    }

    [Fact]
    public void NotifyOfAbsence_EmployeeIsAbsent_OnEmployeeIsAbsentMustBeTriggered()
    {
        var employeeService = _employeeServiceFixture.EmployeeService;

        var internalEmployee = new InternalEmployee(
            "Brooklyn", "Cannon", 5, 3000, false, 1);

        // Act & Assert
        Assert.Raises<EmployeeIsAbsentEventArgs>(
            handler => employeeService.EmployeeIsAbsent += handler,
            handler => employeeService.EmployeeIsAbsent -= handler,
            () => employeeService.NotifyOfAbsence(internalEmployee));

    }


}
