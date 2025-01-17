﻿using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class BonusService : IBonusService
    {
        private readonly ApplicationDatabaseContext _context;
        public BonusService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Bonus bonus)
        {
            try
            {
                _context.Bonuses.Add(bonus);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Bonus> Get()
        {
            try
            {
                return _context.Bonuses.Include(x => x.RankBonus).ThenInclude(rb => rb.Rank).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Bonus Get(string name)
        {
            try
            {
                return _context.Bonuses.Include(x => x.RankBonus).ThenInclude(rb => rb.Rank).AsNoTracking().FirstOrDefault(x => x.BonusName == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Bonus Get(int id)
        {
            try
            {
                return _context.Bonuses.Include(x => x.RankBonus).ThenInclude(rb => rb.Rank).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Edit(Bonus bonus)
        {
            try
            {
                _context.Bonuses.Update(bonus);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var bonus = _context.Bonuses.FirstOrDefault(x => x.Id == id);
                _context.Bonuses.Remove(bonus);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Bonus> GetForRank(int rankId)
        {
            var rank = _context.Ranks
                .Include(r => r.RankBonus)
                .ThenInclude(rb => rb.Bonus)
                .SingleOrDefault(r => r.Id == rankId);

            if (rank == null)
            {
                throw new Exception("Rank not found");
            }

            return rank.RankBonus.Select(rb => rb.Bonus).ToList();
        }
    }
}
