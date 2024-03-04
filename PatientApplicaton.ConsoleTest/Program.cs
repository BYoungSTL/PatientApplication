using System.Text;
using System.Text.Json;

namespace PatientApplicaton.ConsoleTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var handler = new HttpClientHandler
            {
                UseProxy = false
            };
            var client = new HttpClient(handler);
            var patients = GeneratePeople(100);

            var json = JsonSerializer.Serialize(patients);

            using var response = await client.PostAsync("https://localhost:7093/addMany", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
        }


        static List<Patient> GeneratePeople(int count)
        {
            var people = new List<Patient>();
            var random = new Random();

            for (var i = 0; i < count; i++)
            {
                var patient = new Patient
                {
                    Gender = GetRandomGender(random),
                    BirthDate = GetRandomBirthDate(random).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    IsActive = true,
                    Name = new Name
                    {
                        Id = Guid.NewGuid().ToString(),
                        Use = "string",
                        Family = "string",
                        Given = new List<string> { "a" + i, "b" + i }
                    }
                };

                people.Add(patient);
            }

            return people;
        }

        static string GetRandomGender(Random random)
        {
            string[] genders = { "male", "female", "other" };
            return genders[random.Next(0, genders.Length)];
        }

        static DateTime GetRandomBirthDate(Random random)
        {
            var startDate = new DateTime(1970, 1, 1);
            var range = (DateTime.Today - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }
    }

    class Patient
    {
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public bool IsActive { get; set; }
        public Name Name { get; set; } = new Name();
    }

    class Name
    {
        public string Id { get; set; }
        public string Use { get; set; }
        public string Family { get; set; }
        public List<string> Given { get; set; }
    }
}
