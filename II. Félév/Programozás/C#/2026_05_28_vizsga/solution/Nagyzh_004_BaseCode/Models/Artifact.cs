namespace Nagyzh_004_BaseCode.Models
{
    internal class Artifact
    {
        public required string Id { get; set; }
        public required int Value { get; set; }

        public bool IsExhibited { get; set; } = false;
    }
}
