#region parts
#define PART1 //Műtárgyak adatszerkezete	(6 pont)
#define PART2 //ToString metódusok és konstruktorok a macskákban	(4 pont)
#define PART3 //IExhibition interfészt megvalósító osztály létrehozása	(2 pont)
#define PART4 //Load metódus	(4 pont)
#define PART5 //Display és Get metódusok	(4 pont)
#define PART6 //FindValueables metódus	(2 pont)
#define PART7 //Donations osztály felépítése és LoadDonations metódus	(6 pont)
#define PART8 //ProcessDonations metódus	(2 pont)
#define PART9 //PrintCurrentShowcase metódus	(2 pont)
#define PART10 //CalculateHonoraryFee metódus	(4 pont)
#define PART11 //Save metódus (4 pont)
#endregion

using Nagyzh_004_BaseCode.Interfaces;
using Nagyzh_004_BaseCode.Models;
using System.Reflection;
using System.Text.Json;

namespace Nagyzh_004_BaseCode
{
    internal class Program
    {
        static Donations LoadDonations(string fileName)
        {
            try
            {
                string fileContent = File.ReadAllText(fileName);

                var jsonData = JsonSerializer.Deserialize<Donations>(fileContent);

                if (jsonData == null)
                {
                    throw new Exception("JSON empty data! " + fileName);
                }

                return jsonData as Donations;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        static void Main()
        {
#if PART1
            Console.WriteLine();
            Console.WriteLine("----PART1 START----");

            var baseClassType = typeof(Artifact);
            var childClassTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => !p.IsAbstract && p.IsSubclassOf(baseClassType))
                .ToList();

            Console.WriteLine($"Van-e szarmaztatva gyerekosztaly az absztrakt ososztalybol: {childClassTypes.Any()}");

            Console.WriteLine("----PART1 END----");
#endif
#if PART2
            Console.WriteLine();
            Console.WriteLine("----PART2 START----");

            var paintingType = GetClassType(childClassTypes.Where(type => GetConstructorParameterCount(type) == 4).ToList(), typeof(int), 3);
            var sculptureType = GetClassType(childClassTypes.Where(type => GetConstructorParameterCount(type) == 3).ToList(), typeof(int), 2);
            var vaseType = GetClassType(childClassTypes.Where(type => GetConstructorParameterCount(type) == 3).ToList(), typeof(string), 2);



            Console.WriteLine($"A festmenyek osztalya megvalositva-e a megfelelo konstruktorokkal: {paintingType != null && HasNParameterConstructor(paintingType, 4) && HasNParameterConstructor(paintingType, 0)}");
            Console.WriteLine($"A szobrok osztalya megvalositva-e a megfelelo konstruktorokkal: {sculptureType != null && HasNParameterConstructor(sculptureType, 3) && HasNParameterConstructor(sculptureType, 0)}");
            Console.WriteLine($"A vazak osztalya megvalositva-e a megfelelo konstruktorokkal: {vaseType != null && HasNParameterConstructor(vaseType, 3) && HasNParameterConstructor(vaseType, 0)}");

            if (paintingType == null || sculptureType == null || vaseType == null)
            {
                Console.WriteLine("NINCS MINDEN GYEREOSZTALY MEGVALOSITVA MEGFELELOEN!");
                return;
            }

            Console.WriteLine($"A {paintingType} osztalyban felul van-e definialva a ToString metodus: {paintingType.GetMethod("ToString").DeclaringType == paintingType}");
            Console.WriteLine($"A {sculptureType} osztalyban felul van-e definialva a ToString metodus: {sculptureType.GetMethod("ToString").DeclaringType == sculptureType}");
            Console.WriteLine($"A {vaseType} osztalyban felul van-e definialva a ToString metodus: {vaseType.GetMethod("ToString").DeclaringType == vaseType}");

            Console.WriteLine("----PART2 END----");
#endif
#if PART3
            Console.WriteLine();
            Console.WriteLine("----PART3 START----");

            var interfaceType = typeof(IExhibition);
            var exhibitionClassType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .FirstOrDefault(p => !p.IsInterface && interfaceType.IsAssignableFrom(p));

            Console.WriteLine($"Az IExhibition interfesz implementalva van-e: {exhibitionClassType != default}");

            if (exhibitionClassType == default)
            {
                Console.WriteLine($"Az IExhibition INTERFESZ NINCS IMPLEMENTALVA");
                return;
            }

            var exhibition = (IExhibition)Activator.CreateInstance(exhibitionClassType);
            Console.WriteLine($"Az IExhibition interfeszt implementalo {exhibitionClassType} peldanyositasa sikeres-e: {exhibition != default}");

            Console.WriteLine("----PART3 END----");
#endif
#if PART4
            Console.WriteLine();
            Console.WriteLine("----PART4 START----");
            MethodInfo loadMethod = typeof(IExhibition).GetMethod("Load");

            Console.WriteLine($"A Load metodus letezik-e a {exhibitionClassType} osztalyban: {loadMethod != null}");
            if (loadMethod == null)
            {
                Console.WriteLine($"A LOAD METHOD NEM LETEZIK");
                return;
            }

            Console.WriteLine("Az adatok betoltese a json fajlokbol...");
            loadMethod.MakeGenericMethod(new Type[] { paintingType }).Invoke(exhibition, new object[] { "paintings.json" });
            loadMethod.MakeGenericMethod(new Type[] { sculptureType }).Invoke(exhibition, new object[] { "sculptures.json" });
            loadMethod.MakeGenericMethod(new Type[] { vaseType }).Invoke(exhibition, new object[] { "vases.json" });
            Console.WriteLine("Az adatok betoltese lefutott");
            Console.WriteLine("----PART4 END----");
#endif
#if PART5
            Console.WriteLine();
            Console.WriteLine("----PART5 START----");

            Console.WriteLine("Display metodus ellenorzese:");
            exhibition.Display();

            Console.WriteLine();
            Console.WriteLine("Get metodus ellenorzese:");
            Console.WriteLine($"Id C1234LH: {exhibition.Get("NMB124")}");
            Console.WriteLine($"Id C0235LH: {exhibition.Get("54M155")}");
            Console.WriteLine($"Id C9812LR: {exhibition.Get("LM11N7")}");
            Console.WriteLine($"Id C0011LR: {exhibition.Get("RE4354")}");
            Console.WriteLine($"Id C8436C: {exhibition.Get("M82VP0")}");

            Console.WriteLine("----PART5 END----");
#endif
#if PART6
            Console.WriteLine();
            Console.WriteLine("----PART6 START----");

            Console.WriteLine("A 12 millió forint, vagy drágább tárgyak:");
            var atleast12M = exhibition.FindValueables(12000000);
            PrintArtifacts(atleast12M);

            Console.WriteLine("----PART6 END----");
#endif
#if PART7
            Console.WriteLine();
            Console.WriteLine("----PART7 START----");

            var donations1 = LoadDonations("donations1.json");
            var donations2 = LoadDonations("donations2.json");
            var donations3 = LoadDonations("donations3.json");

            Console.WriteLine($"donations1.json fájlbol az donations1 objektum letrejott-e: {donations1 != null}");
            Console.WriteLine($"donations2.json fájlbol az donations2 objektum letrejott-e: {donations2 != null}");
            Console.WriteLine($"donations3.json fájlbol az donations3 objektum letrejott-e: {donations3 != null}");

            Console.WriteLine("----PART7 END----");
#endif
#if PART8
            Console.WriteLine();
            Console.WriteLine("----PART8 START----");

            Console.WriteLine("A műtárgyak listája a kölcsönzések feldolgozása után:");
            exhibition.ProcessDonations(donations1);
            exhibition.ProcessDonations(donations2);
            exhibition.ProcessDonations(donations3);
            exhibition.Display();

            Console.WriteLine("----PART8 END----");
#endif
#if PART9
            Console.WriteLine();
            Console.WriteLine("----PART9 START----");

            Console.WriteLine("A regisztrált műtárgyak listája:");
            exhibition.PrintCurrentShowcase();

            Console.WriteLine("----PART9 END----");
#endif
#if PART10
            Console.WriteLine();
            Console.WriteLine("----PART10 START----");

            Console.WriteLine($"A donations1 adomány tiszteletdíja: {exhibition.CalculateHonoraryFee(donations1)} forint");
            Console.WriteLine($"A donations2 adomány tiszteletdíja: {exhibition.CalculateHonoraryFee(donations2)} forint");
            Console.WriteLine($"A donations3 adomány tiszteletdíja: {exhibition.CalculateHonoraryFee(donations3)} forint");

            Console.WriteLine("----PART10 END----");
#endif
#if PART11
            Console.WriteLine();
            Console.WriteLine("----PART11 START----");

            MethodInfo saveMethod = typeof(IExhibition).GetMethod("Save");

            Console.WriteLine($"A Save metodus letezik-e a {exhibitionClassType} osztalyban: {saveMethod != null}");
            if (saveMethod == null)
            {
                Console.WriteLine($"A SAVE METODUS NEM LETEZIK");
                return;
            }

            Console.WriteLine("Az adatok kimentese a json fajlokba...");
            saveMethod.MakeGenericMethod(new Type[] { paintingType }).Invoke(exhibition, new object[] { "paintings_out.json", false });
            saveMethod.MakeGenericMethod(new Type[] { sculptureType }).Invoke(exhibition, new object[] { "sculptures_out.json", true });
            saveMethod.MakeGenericMethod(new Type[] { vaseType }).Invoke(exhibition, new object[] { "vases_out.json", true });
            Console.WriteLine("Az adatok kimentese lefutott");

            Console.WriteLine("----PART11 END----");
#endif
        }

        static Type GetClassType(List<Type> classTypes, Type propertyType, int propertyCount)
        {
            foreach (var type in classTypes)
            {
                var propertyTypes = type.GetProperties().Select(p => p.PropertyType).ToList();
                if (propertyTypes.Count(t => t == propertyType) == propertyCount)
                {
                    return type;
                }
            }
            return null;
        }

        static int GetConstructorParameterCount(Type type)
        {
            var constructors = type.GetConstructors();
            return constructors.Max(c => c.GetParameters().Length);
        }

        static bool HasNParameterConstructor(Type type, int parameterCount)
        {
            var constructors = type.GetConstructors();
            return constructors.Any(c => c.GetParameters().Length == parameterCount);
        }

        static void PrintArtifacts(List<Artifact> artifacts)
        {
            foreach (var artifact in artifacts)
            {
                Console.WriteLine(artifact);
            }
        }
    }
}