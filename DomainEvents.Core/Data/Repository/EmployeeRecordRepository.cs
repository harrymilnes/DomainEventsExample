using System.Linq;
using DomainEvents.Core.Data.Context;
using DomainEvents.Core.Data.Entities;
using DomainEvents.Core.DomainEvents;

namespace DomainEvents.Core.Data.Repository
{
    public class EmployeeRecordRepository : IEmployeeRecordRepository
    {
        
        private readonly EfContext _efContext;

        public EmployeeRecordRepository(EfContext efContext)
        {
            _efContext = efContext;
        }

        public EmployeeRecord Create()
        {
            var employeeRecord = EmployeeRecord.Create("Freshly created employeeRecord");
            employeeRecord.DomainEvents.Add(AuditDomainEvent.Create("Created"));
            _efContext.EmployeeRecord.Add(employeeRecord);
            _efContext.SaveChanges();
            return employeeRecord;
        }

        public EmployeeRecord Update()
        {
            var employeeRecord = _efContext.EmployeeRecord.First();
            employeeRecord.Update("Updated");
            _efContext.SaveChanges();
            return employeeRecord;
        }

        public EmployeeRecord Delete()
        {
            var employeeRecord = _efContext.EmployeeRecord.First();
            employeeRecord.Delete(); 
            _efContext.SaveChanges();
            return employeeRecord;  
        }
    }
}