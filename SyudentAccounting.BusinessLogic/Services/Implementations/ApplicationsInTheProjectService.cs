﻿using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class ApplicationsInTheProjectService : IApplicationInTheProjectService
    {
        private readonly ApplicationDatabaseContext _context;
        public ApplicationsInTheProjectService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(ApplicationsInTheProject applicationsInTheProject)
        {
            _context.ApplicationsInTheProjects.Add(applicationsInTheProject);
            _context.SaveChanges();
        }
        public IEnumerable<ApplicationsInTheProject> Get()
        {
            return _context.ApplicationsInTheProjects.ToList();
        }
        public ApplicationsInTheProject GetId(int id)
        {
            return _context.ApplicationsInTheProjects.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(ApplicationsInTheProject applicationsInTheProject)
        {
            _context.ApplicationsInTheProjects.Update(applicationsInTheProject);
            _context.SaveChanges();
        }
        public void Delete(ApplicationsInTheProject applicationsInTheProject)
        {
            _context.ApplicationsInTheProjects.Remove(applicationsInTheProject);
            _context.SaveChanges();
        }
    }
}
