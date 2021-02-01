using System;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public enum MenuType
    {
        NA = 0,
        EXAMINELIST = 1,
        EXAMINEQUEUE = 2
    }


    /// <summary>
    /// Factory klass som skapar texten till en meny
    /// Vilken meny som skall skapas bestäms av enum MenuType
    /// </summary>
    public class MenuFactory
    {
        public static string GetMenu(MenuType menuType)
        {
            StringBuilder strBuilder = new StringBuilder();
            string strMenu = String.Empty;

            switch (menuType)
            {
                case MenuType.EXAMINELIST:
                    strBuilder.Append("Skriv + framför den text som ni vill lägga till");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv - framför den text som ni vill radera");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 0 för att återgå till huvudmenyn");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 1 för att visa listan");
                    strMenu = strBuilder.ToString();
                    break;
                case MenuType.EXAMINEQUEUE:
                    strBuilder.Append("Skriv + framför ert namn för att ställa er i kön");
                    strBuilder.Append(System.Environment.NewLine);
                    //strBuilder.Append("Skriv - framför ert namn för att lämna kön");
                    //strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 0 för att återgå till huvudmenyn");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 1 för att visa kön");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 2 för att tabort en person från kön");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 3 för att visa en simulerad kö");
                    strMenu = strBuilder.ToString();
                    break;
            }

            return strMenu;
        }
    }
}