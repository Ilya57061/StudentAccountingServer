﻿using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IScheduleOfСlassesService
    {
        void Create(ScheduleOfСlasses scheduleOfСlasses);
        IEnumerable<ScheduleOfСlasses> Get();
        ScheduleOfСlasses Get(int id);
        void Edit(ScheduleOfСlasses scheduleOfСlasses);
        IEnumerable<ScheduleOfСlasses> GetForCoursesId(int coursesId);
        void Delete(int id);
    }
}
