using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    /// <summary>
    /// Exctension metoder för Stack klassen
    /// </summary>
    public static class StackExtension
    {
        /// <summary>
        /// Metoden kontrollerar om stack inte innehåller några objekt. Då returneras true. Annars returneras false
        /// </summary>
        /// <param name="stack">Stack som vi vill kontrollera om den inte innehåller några objekt</param>
        /// <returns>true om Stack inte innehåller några objekt eller är null. Annars returneras false</returns>
        public static bool IsEmpty(this Stack<Token> stack)
        {
            bool bEmpty = true;

            if (stack?.Count > 0)
                bEmpty = false;

            return bEmpty;
        }
    }
}
