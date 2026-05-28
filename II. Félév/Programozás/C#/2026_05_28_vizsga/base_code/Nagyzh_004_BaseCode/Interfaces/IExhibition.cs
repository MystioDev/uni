using Nagyzh_004_BaseCode.Models;

namespace Nagyzh_004_BaseCode.Interfaces
{
    internal interface IExhibition
    {
        void Load<TArtifact>(string filename) where TArtifact : Artifact;
        void Display();
        Artifact Get(string id);
        List<Artifact> FindValueables(int minimumValue);
        void ProcessDonations(Donations donations);
        void PrintCurrentShowcase();
        int CalculateHonoraryFee(Donations donations);
        void Save<TArtifact>(string filename, bool isOnDisplay) where TArtifact : Artifact;
    }
}