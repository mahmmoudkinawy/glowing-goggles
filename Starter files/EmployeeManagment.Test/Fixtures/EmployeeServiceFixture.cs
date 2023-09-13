using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagment.Test.Services;

namespace EmployeeManagment.Test.Fixtures;
public class EmployeeServiceFixture : IDisposable
{
    public IEmployeeManagementRepository EmployeeManagementTestDataRepository { get; }
    public IEmployeeService EmployeeService { get; }

    public EmployeeServiceFixture()
    {
        EmployeeManagementTestDataRepository =
            new EmployeeManagementTestDataRepository();
        EmployeeService =
            new EmployeeService(
                EmployeeManagementTestDataRepository,
                new EmployeeFactory());
    }

    public void Dispose()
    {
        // clean up the setup code, if required.
    }
}
