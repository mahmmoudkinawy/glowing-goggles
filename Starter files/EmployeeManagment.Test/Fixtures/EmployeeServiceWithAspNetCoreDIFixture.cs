using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagment.Test.Fixtures;
public class EmployeeServiceWithAspNetCoreDIFixture : IDisposable
{
    private readonly ServiceProvider _serviceProvider;

    public IEmployeeManagementRepository EmployeeManagementRepository
    {
        get
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _serviceProvider.GetService<IEmployeeManagementRepository>();
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    public IEmployeeService EmployeeService
    {
        get
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _serviceProvider.GetService<IEmployeeService>();
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    public EmployeeServiceWithAspNetCoreDIFixture()
    {
        var services = new ServiceCollection();
        services.AddScoped<EmployeeFactory>();
        services.AddScoped<IEmployeeManagementRepository,
            EmployeeManagementRepository>();
        services.AddScoped<IEmployeeService, EmployeeService>();

        _serviceProvider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
