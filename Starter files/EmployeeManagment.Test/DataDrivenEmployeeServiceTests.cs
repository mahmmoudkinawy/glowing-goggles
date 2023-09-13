using EmployeeManagement.DataAccess.Entities;
using EmployeeManagment.Test.Fixtures;

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

}
