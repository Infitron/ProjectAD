using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class UpgradeResponse
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public DateTime DateCreated { get; set; }
        public int Status { get; set; }
        public int VerificationStatus { get; set; }
        public string UpgradeDecision { get; set; }
        public int UpgradeRequestId { get; set; }
    }
}
