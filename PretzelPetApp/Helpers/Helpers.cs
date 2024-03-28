using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PretzelPetApp.Helpers
{
    public static class Kısalt
    {
        public static string MakeShorter(string text, int maksLength)
        {
            if(text.Length <= maksLength)
            {
                return text;
            }
            else
            {
                return text.Substring(0, maksLength) + "..";
            }
        }
        

    }
}
