namespace SkalProj_Datastrukturer_Minne
{
    /// <summary>
    /// Klass med information om ett tecken och dess position i ex en array
    /// </summary>
    public class Token
    {
        public char TokenChar { get; set; }
        public int TokenCharIndex { get; set; } = -1;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="chToken">Tecken ex. {</param>     
        public Token(char chToken)
        {
            TokenChar = chToken;
        }


        public override string ToString()
        {
            return $"{TokenChar} ({TokenCharIndex})";
        }
    }
}
