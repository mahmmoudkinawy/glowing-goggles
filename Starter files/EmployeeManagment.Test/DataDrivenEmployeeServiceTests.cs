using EmployeeManagement.DataAccess.Entities;
using EmployeeManagment.Test.Fixtures;
using EmployeeManagment.Test.TestData;

namespace EmployeeManagment.Test;

[Collection("EmployeeServiceCollection")]
public class DataDrivenEmployeeServiceTests // : IClassFixture<EmployeeServiceFixture>
{
    private readonly EmployeeServiceFixture _employeeServiceFixture;

    public DataDrivenEmployeeServiceTests(EmployeeServiceFixture employeeServiceFixture)
    {
        _employeeServiceFixture = employeeServiceFixture ??
            throw new ArgumentNullException(nameof(employeeServiceFixture));
    }

    [Fact]
    public async Task GiveRaise_MinimumRaiseGiven_EmployeeMinimumRaiseGivenMustBeTrue()
    {
        var internalEmployee = new InternalEmployee(
            "Brooklyn", "Cannon", 5, 3000, false, 1);

        await _employeeServiceFixture
            .EmployeeService.GiveRaiseAsync(internalEmployee, 100);

        Assert.True(internalEmployee.MinimumRaiseGiven);
    }

    [Fact]
    public async Task GiveRaise_MinimumRaiseGiven_EmployeeMinimumRaiseGivenMustBeFalse()
    {
        var internalEmployee = new InternalEmployee(
            "Brooklyn", "Cannon", 5, 3000, false, 1);

        await _employeeServiceFixture
            .EmployeeService.GiveRaiseAsync(internalEmployee, 200);

        Assert.False(internalEmployee.MinimumRaiseGiven);
    }

    [Theory]
    [InlineData("37e03ca7-c730-4351-834c-b66f280cdb01")]
    [InlineData("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")]
    public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse(Guid courseId)
    {
        // AAA

        // Act
        var internalEmployee = _employeeServiceFixture.EmployeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        Assert.Contains(
            internalEmployee.AttendedCourses,
            course => course.Id == courseId);
    }

    public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithProperty
    {
        get
        {
            return new List<object[]>
            {
                new object[] { 100, true },
                new object[] { 200, false }
            };
        }
    }
    public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithMethod(
        int testDataInstancesToProvide)
    {
        var testData = new List<object[]>
            {
                new object[] { 100, true },
                new object[] { 200, false }
            };

        return testData.Take(testDataInstancesToProvide);
    }

    public static TheoryData<int, bool> StronglyTypedExampleTestDataForGiveRaise_WithProperty
    {
        get
        {
            return new TheoryData<int, bool>
            {
                { 100, true },
                { 200, false }
            };
        }
    }

    [Theory]
    [ClassData(typeof(StronglyTypedEmployeeServiceTestData_FromFile))]
    //[ClassData(typeof(StronglyTypedEmployeeServiceTestData))]
    // [MemberData(nameof(ExampleTestDataForGiveRaise_WithMethod), 100)]
    // [InlineData(100, true)]
    // [InlineData(200, false)]
    public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseGivenGivenMatchesValue(
        int raiseGiven, bool expectedValueForMinimumRaiseGiven)
    {
        var internalEmployee = new InternalEmployee(
            "Brooklyn", "Cannon", 5, 3000, false, 1);

        await _employeeServiceFixture
            .EmployeeService.GiveRaiseAsync(internalEmployee, raiseGiven);

        Assert.Equal(expectedValueForMinimumRaiseGiven, internalEmployee.MinimumRaiseGiven);
    }


}
