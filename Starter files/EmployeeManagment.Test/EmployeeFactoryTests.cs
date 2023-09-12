using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagment.Test;
public class EmployeeFactoryTests
{
    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
    {
        var employeeFactory = new EmployeeFactory();

        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");

        Assert.Equal(2500, employee.Salary);
    }

    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
    {
        var employeeFactory = new EmployeeFactory();

        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");

        Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500);
    }

    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500Alternative()
    {
        var employeeFactory = new EmployeeFactory();

        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");

        Assert.True(employee.Salary >= 2500, "Salary not in acceptable range.");
        Assert.True(employee.Salary <= 3500);
    }

    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWithInRange()
    {
        var employeeFactory = new EmployeeFactory();

        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");

        Assert.InRange(employee.Salary, 2500, 3500);
    }

    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_PrecisionExample()
    {
        var employeeFactory = new EmployeeFactory();

        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");
        employee.Salary = 2500.123m;

        Assert.Equal(2500, employee.Salary, precision: 0);
    }

    [Fact]
    public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
    {
        var factory = new EmployeeFactory();

        var employee = factory.CreateEmployee("Kevin", "Dockx", "Marvin", true);

        Assert.IsType<ExternalEmployee>(employee);
        // Assert.IsAssignableFrom<Employee>(employee);
    }
}
