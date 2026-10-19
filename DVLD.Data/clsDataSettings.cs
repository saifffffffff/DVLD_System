using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_Data
{
    internal static class clsDataSettings
    {
        public static string ConncetionString = "Server=.;Database=DVLD;Trusted_Connection=True;";

        private static readonly string[] CountriesNames = {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Antigua and Barbuda",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bhutan",
            "Bolivia",
            "Bosnia and Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Burkina Faso",
            "Burundi",
            "Cabo Verde",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Central African Republic",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Comoros",
            "Congo",
            "Costa Rica",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Democratic Republic of the Congo",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Eswatini",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Greece",
            "Grenada",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland",
            "Italy",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Marshall Islands",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Micronesia",
            "Moldova",
            "Monaco",
            "Mongolia",
            "Montenegro",
            "Morocco",
            "Mozambique",
            "Myanmar",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "North Korea",
            "North Macedonia",
            "Norway",
            "Oman",
            "Pakistan",
            "Palau",
            "Palestine",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Poland",
            "Portugal",
            "Qatar",
            "Romania",
            "Russia",
            "Rwanda",
            "Saint Kitts and Nevis",
            "Saint Lucia",
            "Saint Vincent and the Grenadines",
            "Samoa",
            "San Marino",
            "Sao Tome and Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South Korea",
            "South Sudan",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Suriname",
            "Sweden",
            "Switzerland",
            "Syria",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Timor-Leste",
            "Togo",
            "Tonga",
            "Trinidad and Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Tuvalu",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United States",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Vatican City",
            "Venezuela",
            "Vietnam",
            "Yemen",
            "Zambia",
            "Zimbabwe"
        };

        static clsDataSettings()
        {
            const string MasterConnectionString = "Server=.;Database=master;Trusted_Connection=True;";

            bool databaseExists;
            using (SqlConnection connection = new SqlConnection(MasterConnectionString))
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE name = 'DVLD';", connection))
            {
                connection.Open();
                databaseExists = (int)command.ExecuteScalar() > 0;

                if (!databaseExists)
                {
                        ExecuteSchema(connection);
                        SeedCountries();
                        SeedDefaultAdmin();
                }
            }

            

        }

        private static void SeedCountries()
        {
            using (SqlConnection connection = new SqlConnection(ConncetionString))
            {
                connection.Open();

                
                // one parameter per name keeps the SQL free of escaping concerns
                string placeholders = string.Join(", ", CountriesNames.Select(country => $"('{country}')"));
                
                string query = $"INSERT INTO Countries (CountryName) VALUES {placeholders}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void SeedDefaultAdmin()
        {
            const string Query = @"
        INSERT INTO People ([NationalNo], [FirstName], [SecondName], [ThirdName], [LastName],
                                    [DateOfBirth], [Gendor], [Address], [Phone], [Email],
                                    [NationalityCountryID], [ImagePath])
        VALUES (@NationalNo, @FirstName, @SecondName, NULL, @LastName,
                @DateOfBirth, @Gendor, @Address, @Phone, NULL,
                (SELECT CountryID FROM Countries WHERE CountryName = @CountryName), NULL);

        INSERT INTO Users ([PersonID], [UserName], [Password], [IsActive])
        VALUES ((SELECT [PersonID] FROM [dbo].[People] WHERE [NationalNo] = @NationalNo),
                @UserName, @Password, 1);";

            using (SqlConnection connection = new SqlConnection(ConncetionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@UserName", "admin");
                command.Parameters.AddWithValue("@Password", "admin");
                command.Parameters.AddWithValue("@NationalNo", "10000000");
                command.Parameters.AddWithValue("@FirstName", "System");
                command.Parameters.AddWithValue("@SecondName", "Admin");
                command.Parameters.AddWithValue("@LastName", "istrator");
                command.Parameters.AddWithValue("@DateOfBirth", new DateTime(1990, 1, 1));
                command.Parameters.AddWithValue("@Gendor", 0);
                command.Parameters.AddWithValue("@Address", "N/A");
                command.Parameters.AddWithValue("@Phone", "N/A");
                command.Parameters.AddWithValue("@CountryName", "Jordan");

                command.ExecuteNonQuery();
            }
        }

        private static void ExecuteSchema(SqlConnection connection)
        {
            Assembly assembly = typeof(clsDataSettings).Assembly;
            string schema;

            using (Stream stream = assembly.GetManifestResourceStream("DVLD_Data.script.sql"))
            using (StreamReader reader = new StreamReader(stream))
                schema = reader.ReadToEnd();

            // split on GO batch separators, tolerating either LF or CRLF line endings
            string[] batches = Regex.Split(schema, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            foreach (string batch in batches)
            {
                string sql = batch.Trim();

                if (sql.Length == 0)
                    continue;

                using (SqlCommand command = new SqlCommand(sql, connection))
                    command.ExecuteNonQuery();
            }
        }
    }
}
    

