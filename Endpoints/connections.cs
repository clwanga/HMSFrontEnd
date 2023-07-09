namespace InterviewFrontEnd.Endpoints
{
    public class Connections
    {
        public static string BaseURL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_BASE_URLS")["BASE_URL"];

        public static string AddNewPatient = "Registration";
        public static string AddPatientVitals = "";
        public static string Report = "";
        public static string ReportByDate = "";
        public static string AllPatients = "";
        public static string AllVitals = "";
    }
}
