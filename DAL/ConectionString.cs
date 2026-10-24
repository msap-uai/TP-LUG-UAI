using System.Configuration;

namespace DAL
{
    static public class ConectionString
    {
        static public string GetConectionString()
        {
            return ConfigurationManager.ConnectionStrings["POLICONSULTORIO"].ConnectionString;
        }
    }
}
