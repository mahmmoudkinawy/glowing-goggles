﻿using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagment.Test;
public class EmployeeFactoryTests
{
    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
    {
        var employeeFactory = new EmployeeFactory();

        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");

        Assert.Equal(2_500, employee.Salary);
    }
}