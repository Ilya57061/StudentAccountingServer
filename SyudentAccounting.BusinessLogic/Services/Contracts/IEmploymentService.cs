﻿using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IEmploymentService
    {
        void Create(Employment employment);
        IEnumerable<Employment> Get();
        Employment Get(int id);
        Employment GetByParticipants(int participantsId);
        void Edit(Employment employment);
        void Delete(int id);
    }
}
