﻿using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagment.Test;
public class CourseTests
{

    [Fact]
    public void CourseConstructor_ConstructCourse_IsNewMustBeTrue()
    {
        // AAA
        // Arrange

        // Act
        var course = new Course("test one");

        // Assert
        Assert.True(course.IsNew);
    }

}
