﻿using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Model.DatabaseModels
{
    public class RankBonus
    {
        public int Id { get; set; }
        public int RankId { get; set; }
        public Rank? Rank { get; set; }
        public int BonusId { get; set; }
        public Bonus? Bonus { get; set; }
    }
}
