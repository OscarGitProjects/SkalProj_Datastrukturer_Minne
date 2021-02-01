using System;

namespace SkalProj_Datastrukturer_Minne
{
    /// <summary>
    /// Klass med olika hjälp metoder
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Metoden returnerar ett slumpmässigt valt namn ur en lista med namn
        /// </summary>
        /// <returns>Slumpmässigt valt namn</returns>
        public static string GetRandomName()
        {
            Random random = new Random();
            string strNewName = string.Empty;
            string[] arrNames = {"Kalle Anka", "Knatte", "Kajsa Anka", "Fnatte", "Farmor Anka", "Tjatte", "Joakim von Anka", "Alexander Lukas", "Knase Anka", "Bolivar" };

            // Hämta slumpmässigt id till namn i arrayen
            int iNameId = random.Next(0, arrNames.Length + 1);

            if(iNameId < arrNames.Length)
                strNewName = arrNames[iNameId];

            return strNewName;
        }
    }
}
