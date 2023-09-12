using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagment.Test;
public class EmployeeTests
{
    [Fact]
    public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameIsConcatenation()
    {
        var employee = new InternalEmployee(
            "Md", "Kinawy", 0, 2500, false, 1);

        employee.FirstName = "Kevin";
        employee.LastName = "DOCKX";

        Assert.Equal("Kevin Dockx", employee.FullName, ignoreCase: true);
    }

    [Fact]
    public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameStartsWithFirstName()
    {
        var employee = new InternalEmployee(
            "Md", "Kinawy", 0, 2500, false, 1);

        employee.FirstName = "Kevin";
        employee.LastName = "Dockx";

        Assert.StartsWith(employee.FirstName, employee.FullName);
    }

    [Fact]
    public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameEndsWithLastName()
    {
        var employee = new InternalEmployee(
            "Md", "Kinawy", 0, 2500, false, 1);

        employee.FirstName = "Kevin";
        employee.LastName = "Dockx";

        Assert.EndsWith(employee.LastName, employee.FullName);
    }

    [Fact]
    public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameContainsPartOfConcatination()
    {
        var employee = new InternalEmployee(
            "Md", "Kinawy", 0, 2500, false, 1);

        employee.FirstName = "Kevin";
        employee.LastName = "Dockx";

        Assert.Contains("in", employee.FullName);
    }


    [Fact]
    public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameSoundsLikeConcatenation()
    {
        var employee = new InternalEmployee(
            "Kevin", "Dockx", 0, 2500, false, 1);

        employee.FirstName = "Lucia";
        employee.LastName = "Shelton";

        Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", employee.FullName);
    }

}
