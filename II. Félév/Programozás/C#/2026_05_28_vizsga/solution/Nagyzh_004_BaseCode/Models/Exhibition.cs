using Nagyzh_004_BaseCode.Interfaces;
using System.Text.Json;

namespace Nagyzh_004_BaseCode.Models
{
    internal class Exhibition : IExhibition
    {
        public List<Artifact> Artifacts { get; set; } = new List<Artifact>();

        public Exhibition() { }
        public void Load<TArtifact>(string filename) where TArtifact : Artifact
        {
            try
            {
                string fileContent = File.ReadAllText(filename);

                var jsonData = JsonSerializer.Deserialize<List<TArtifact>>(fileContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
                if (jsonData == null)
                {
                    throw new Exception("JSON data is empty! " + filename);
                }

                Artifacts.AddRange(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Display()
        {
            foreach (Artifact artifactItem in Artifacts)
            {
                Console.WriteLine(artifactItem.ToString());
            }
        }

        public Artifact Get(string id)
        {
            foreach (Artifact artifactItem in Artifacts)
            {
                if (artifactItem.Id != id) continue;

                return artifactItem;
            }

            return null;
        }

        public List<Artifact> FindValueables(int minimumValue)
        {
            List<Artifact> temp = new List<Artifact>();

            foreach (Artifact artifactItem in Artifacts)
            {
                if (artifactItem.Value < minimumValue) continue;

                temp.Add(artifactItem);
            }

            return temp;
        }

        public void ProcessDonations(Donations donations)
        {
            foreach (GiftedArtifacts giftedItem in donations.Items)
            {
                foreach (Artifact artifactItem in Artifacts)
                {
                    if (artifactItem.Id != giftedItem.ArtifactId) continue;

                    artifactItem.IsExhibited = true;
                }
            }
        }

        public void PrintCurrentShowcase()
        {
            foreach (Artifact artifactItem in Artifacts)
            {
                if (!artifactItem.IsExhibited) continue;

                Console.WriteLine(artifactItem.ToString());
            }
        }

        public int CalculateHonoraryFee(Donations donations)
        {
            int price = 0;

            foreach (GiftedArtifacts giftedArtifactItem in donations.Items)
            {
                Artifact artifact = Get(giftedArtifactItem.ArtifactId);

                if (artifact is Painting) price += 10_000;
                if (artifact is Sculpture) price += 50_000;
                if (artifact is Vase) price += 5_000;

                double calculatedPrice = (artifact.Value * 0.0001) * giftedArtifactItem.Days;
                price += Convert.ToInt32(Math.Round(calculatedPrice));
            }

            return price;
        }

        public void Save<TArtifact>(string filename, bool isOnDisplay) where TArtifact : Artifact
        {
            List<TArtifact> temp = new List<TArtifact>();

            foreach (TArtifact artifact in Artifacts.OfType<TArtifact>().ToList())
            {
                if (artifact.IsExhibited != isOnDisplay) continue;

                temp.Add(artifact);
            }

            try
            {
                string jsonString = JsonSerializer.Serialize(temp, new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true});

                File.WriteAllText(filename, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
