﻿using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDatabaseContext _context;

        public CustomerService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public IEnumerable<Customer> Get()
        {
            return _context.Customers.ToList();
        }
        public Customer GetName(string name)
        {
            return _context.Customers.FirstOrDefault(x => x.FullName == name);
        }
        public void Edit(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
