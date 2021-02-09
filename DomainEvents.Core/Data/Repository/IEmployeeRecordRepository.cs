using DomainEvents.Core.Data.Entities;

namespace DomainEvents.Core.Data.Repository
{
    public interface IEmployeeRecordRepository
    {
        EmployeeRecord Create();
        EmployeeRecord Update();
        EmployeeRecord Delete();
    }
}