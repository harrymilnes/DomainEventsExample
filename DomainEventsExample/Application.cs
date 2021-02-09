using System;
using DomainEvents.Core.Data.Repository;

namespace DomainEventsExample
{
    public class Application
    {
        private readonly IEmployeeRecordRepository _employeeRecordRepository;

        public Application(IEmployeeRecordRepository employeeRecordRepository)
        {
            _employeeRecordRepository = employeeRecordRepository;
        }

        public void Run()
        {
            Console.WriteLine("Create Employee");
            _employeeRecordRepository.Create();
            
            Console.WriteLine("Update Employee");
            _employeeRecordRepository.Update();

            Console.WriteLine("Delete Employee");
            _employeeRecordRepository.Delete();
        }
    }
}