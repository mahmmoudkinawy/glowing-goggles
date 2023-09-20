﻿using EmployeeManagement.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagment.Test;
public class CheckShowStatisticsHeaderTests
{
    [Fact]
    public void OnActionExecuting_InvokeWithoutShowStatisticsHeader_ReturnBadRequestResult()
    {
        // Arrange
        var checkShowStatisticsHeaderActionFilter =
            new CheckShowStatisticsHeader();

        var httpContext = new DefaultHttpContext();

        var actionContext = new ActionContext(httpContext, new(), new(), new());
        var actionExecutingContext = new ActionExecutingContext(actionContext,
            new List<IFilterMetadata>(),
            new Dictionary<string, object?>(),
            controller: null!);

        // Act
        checkShowStatisticsHeaderActionFilter.OnActionExecuting(actionExecutingContext);

        // Assert
        Assert.IsType<BadRequestResult>(actionExecutingContext.Result);
    }

}
