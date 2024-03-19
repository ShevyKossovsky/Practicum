﻿using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;
using Server.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;


        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            return await _context.EmployeesList.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int code)
        {
            return _context.EmployeesList.Find(code);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.EmployeesList.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(int code)
        {
            var employee = await _context.EmployeesList.FindAsync(code);
            employee.IsActive = false;
            await _context.SaveChangesAsync();
        }
     
        public async Task<Employee> UpdateEmployeeAsync(int code, Employee employee)
        {
            var updateEmployee=_context.EmployeesList.Find(code);
            updateEmployee = employee;
            await _context.SaveChangesAsync();
            return updateEmployee;
        }
    }
}
