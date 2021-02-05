using System;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public enum MenuType
    {
        NA = 0,
        EXAMINELIST = 1,
        EXAMINEQUEUE = 2,
        EXAMINESTACK = 3,
        CHECKPARANTHESIS = 4
    }


    /// <summary>
    /// Factoryklass som skapar texten till en meny
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
                    strBuilder.Append("Skriv + framför ert namn för att ställa er i kö");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 0 för att återgå till huvudmenyn");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 1 för att visa kö");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 2 för att tabort en person från kö");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 3 för att visa en simulerad kö");
                    strMenu = strBuilder.ToString();
                    break;
                case MenuType.EXAMINESTACK:
                    strBuilder.Append("Skriv in en text");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 0 för att återgå till huvudmenyn");
                    strMenu = strBuilder.ToString();
                    break;
                case MenuType.CHECKPARANTHESIS:
                    strBuilder.Append("Skriv in en text ({[ där varje öppnad parantes även skall stängas ]}). Programmet kommer att validera att texten är korrekt");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 0 för att återgå till huvudmenyn");
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append("Skriv 1 för att köre lite olika testdata");
                    strMenu = strBuilder.ToString();
                    break;
            }

            return strMenu;
        }
    }
}