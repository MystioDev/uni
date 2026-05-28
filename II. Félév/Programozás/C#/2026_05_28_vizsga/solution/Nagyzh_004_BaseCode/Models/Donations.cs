namespace Nagyzh_004_BaseCode.Models
{
    internal class Donations
    {
        public required string OwnerName { get; set; }

        public required List<GiftedArtifacts> Items { get; set; } = new List<GiftedArtifacts>();
    }
}
