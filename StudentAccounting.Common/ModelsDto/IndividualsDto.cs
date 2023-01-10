﻿
namespace StudentAccounting.Common.ModelsDto
{
    public class IndividualsDto
    {
        public int Id { get; set; }
        public string FIO { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string SocialNetwork { get; set; } = string.Empty;
    }
}
