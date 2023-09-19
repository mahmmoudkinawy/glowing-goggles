using AutoMapper;
using EmployeeManagement.Business;
using EmployeeManagement.Controllers;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.MapperProfiles;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagment.Test;
public class InternalEmployeesControllerTests
{
    private readonly InternalEmployeesController _internalEmployeesController;

    public InternalEmployeesControllerTests()
    {
        var employeeServiceMock = new Mock<IEmployeeService>();
        employeeServiceMock.Setup(m => m.FetchInternalEmployeesAsync())
            .ReturnsAsync(new List<InternalEmployee>()
            {
                new InternalEmployee("Megan", "Jones", 2, 3000, false, 2),
                new InternalEmployee("Jaimy", "Johnson", 3, 3400, true, 1),
                new InternalEmployee("Anne", "Adams", 3, 4000, false, 3)
            });
        var mapperConfiguration = new MapperConfiguration(
            cfg => cfg.AddProfile<EmployeeProfile>());
        var mapper = new Mapper(mapperConfiguration);

        _internalEmployeesController = new InternalEmployeesController(
           employeeServiceMock.Object, mapper);
    }

    [Fact]
    public async Task GetInternalEmployees_GetAction_MustReturnOkObjectResult()
    {
        // AAA
        // Arrange
        // Act
        var result = await _internalEmployeesController.GetInternalEmployees();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task GetInternalEmployees_GetAction_MustReturnIEnumerableOfInternalEmployeeDtoAsModelType()
    {
        // Arrange
        // Act
        var result = await _internalEmployeesController.GetInternalEmployees();

        var actionResult = (result.Result as OkObjectResult).Value;

        // Assert
        Assert.IsAssignableFrom<IEnumerable<InternalEmployeeDto>>(actionResult);
    }

    [Fact]
    public async Task GetInternalEmployees_GetAction_MustReturnNumberOfInputtedInternalEmployees()
    {
        // Arrange
        // Act
        var result = await _internalEmployeesController.GetInternalEmployees();

        var employeesDtos = ((result.Result as OkObjectResult).Value);

        // Assert
        Assert.Equal(3, (employeesDtos as IEnumerable<InternalEmployeeDto>).Count());
    }

}
