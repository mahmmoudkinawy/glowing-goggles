using EmployeeManagement;
using EmployeeManagement.DataAccess.Services;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagment.Test;
public class ServiceCollectionTests
{
    [Fact]
    public void RegisterDataServices_Execute_DataServicesAreRegistseted()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    {
                        "ConnectionStrings:EmployeeManagementDB","AnyValueWillDo"
                    }
                })
            .Build();

        // Act
        serviceCollection.RegisterDataServices(configuration);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Assert
        Assert.NotNull(
            serviceProvider.GetService<IEmployeeManagementRepository>());
    }
}
