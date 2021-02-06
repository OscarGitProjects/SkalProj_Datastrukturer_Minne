using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public class CheckParanthesis
    {

        #region CheckParanthesis
            /// <summary>
            /// 
            /// </summary>
            public void RunCheckParanthesis()
            {
                /*
                 * Use this method to check if the paranthesis in a string is Correct or incorrect.
                 * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
                 * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
                 */

                bool bValidInput = false;
                bool bRun = true;
                string strInput = String.Empty;

                do
                {
                    // Rensa
                    strInput = String.Empty;
                    Console.Clear();

                    // Visa menyn
                    Console.WriteLine(MenuFactory.GetMenu(MenuType.CHECKPARANTHESIS));

                    strInput = Console.ReadLine();

                    if (!String.IsNullOrWhiteSpace(strInput))
                    {
                        strInput = strInput.Trim();
                        if (strInput.StartsWith('0'))
                        {// Användaren vill avsluta och återgå till huvudmenyn

                            //Console.ReadLine();
                            bRun = false;
                        }
                        else if (strInput.StartsWith('1'))
                        {
                            Simulation();

                            Console.WriteLine("Enter för att gå vidare");
                            Console.ReadLine();
                        }
                        else
                        {
                            bValidInput = CheckIfValidParantheses(strInput);
                            if (bValidInput == false)
                                Console.WriteLine(strInput + " * Not valid input *");
                            else
                                Console.WriteLine(strInput + " * Valid input *");


                            Console.WriteLine("Enter för att gå vidare");
                            Console.ReadLine();
                        }
                    }

                } while (bRun);

            }


            /// <summary>
            /// Metoden kör test av lite test data
            /// </summary>
            /// <returns></returns>
            private bool Simulation()
            {
                bool bValidInput;
                Console.WriteLine("Testar med färdig testdata");
                string strText = "{([])}";
                //Console.WriteLine(strText);
                bValidInput = CheckIfValidParantheses(strText);
                if (bValidInput == false)
                    Console.WriteLine(strText + " * Not valid input *");
                else
                    Console.WriteLine(strText + " * Valid input *");



                strText = "({)}";
                //Console.WriteLine(strText);
                bValidInput = CheckIfValidParantheses(strText);
                if (bValidInput == false)
                    Console.WriteLine(strText + " * Not valid input *");
                else
                    Console.WriteLine(strText + " * Valid input *");



                strText = "Kalle was here";
                //Console.WriteLine(strText);
                bValidInput = CheckIfValidParantheses(strText);
                if (bValidInput == false)
                    Console.WriteLine(strText + " * Not valid input *");
                else
                    Console.WriteLine(strText + " * Valid input *");



                strText = ")";
                //Console.WriteLine(strText);
                bValidInput = CheckIfValidParantheses(strText);
                if (bValidInput == false)
                    Console.WriteLine(strText + " * Not valid input *");
                else
                    Console.WriteLine(strText + " * Valid input *");



                strText = "";
                //Console.WriteLine(strText);
                bValidInput = CheckIfValidParantheses(strText);
                if (bValidInput == false)
                    Console.WriteLine(strText + " * Not valid input *");
                else
                    Console.WriteLine(strText + " * Valid input *");



                strText = string.Format("List<int>{0}list = new List<int>(){{2, 3, 4}};", " ");
                //Console.WriteLine(strText);
                bValidInput = CheckIfValidParantheses(strText);
                if (bValidInput == false)
                    Console.WriteLine(strText + " * Not valid input *");
                else
                    Console.WriteLine(strText + " * Valid input *");



                strText = string.Format("List<int>{0}list = new List<int>){{2, 3, 4}};", " ");
                //Console.WriteLine(strText);
                bValidInput = CheckIfValidParantheses(strText);
                if (bValidInput == false)
                    Console.WriteLine(strText + " * Not valid input *");
                else
                    Console.WriteLine(strText + " * Valid input *");

                return bValidInput;
            }


            /// <summary>
            /// Metoden kontrollerar att paranteserna (, {, eller [ har korrekt stängande paranteser], } eller )
            /// </summary>
            /// <param name="strText">Texten som skall valideras</param>
            /// <returns>true om texten har giltigt format. Annars returneras false</returns>
            private bool CheckIfValidParantheses(string strText)
            {
                bool bValidText = true;
                bool bMatchingToken = false;

                Stack<Token> stackTokens = new Stack<Token>();
                strText = strText?.Trim();

                char chToken;
                Token newToken;

                for (int i = 0; i < strText.Length; i++)
                {
                    bMatchingToken = true;
                    chToken = strText[i];

                    switch (chToken)
                    {
                        case '(':   // Vi har start parantes. Spara undan i en stack
                            newToken = new Token('(');
                            newToken.TokenCharIndex = i;
                            stackTokens.Push(newToken);
                            break;
                        case '{':   // Vi har start parantes. Spara undan i en stack
                            newToken = new Token('{');
                            newToken.TokenCharIndex = i;
                            stackTokens.Push(newToken);
                            break;
                        case '[':   // Vi har start parantes. Spara undan i en stack
                            newToken = new Token('[');
                            newToken.TokenCharIndex = i;
                            stackTokens.Push(newToken);
                            break;
                        case ')':   // Vi har slutet på en parantes. Hämta senaste start parantes från stacken och kontrollera att dom matchar varandra

                            // Om vi har en avslutande parantes men inte en tidigare sparad startande parantes är texten ogiltig
                            if(stackTokens.IsEmpty())
                                return false;

                            bMatchingToken = IsMatchingToken(stackTokens.Peek().TokenChar, chToken);

                            if (bMatchingToken)
                                stackTokens.Pop();
                            break;
                        case '}':   // Vi har slutet på en parantes. Hämta senaste start parantes från stacken och kontrollera att dom matchar varandra

                            // Om vi har en avslutande parantes men inte en tidigare sparad startande parantes är texten ogiltig
                            if (stackTokens.IsEmpty())
                                return false;

                            bMatchingToken = IsMatchingToken(stackTokens.Peek().TokenChar, chToken);

                            if (bMatchingToken)
                                stackTokens.Pop();
                            break;
                        case ']':   // Vi har slutet på en parantes. Hämta senaste start parantes från stacken och kontrollera att dom matchar varandra

                            // Om vi har en avslutande parantes men inte en tidigare sparad startande parantes är texten ogiltig
                            if (stackTokens.IsEmpty())
                                return false;

                            bMatchingToken = IsMatchingToken(stackTokens.Peek().TokenChar, chToken);

                            if (bMatchingToken)
                                stackTokens.Pop();
                            break;
                    }

                    if (bMatchingToken == false)
                        return false;
                }

                if(strText.Length > 0)
                    if (stackTokens.Count > 0)
                        bValidText = false;

                return bValidText;
            }


            /// <summary>
            /// Metoden testar om chEndToken är avslutande parantes ex. )]} att chStartToken innehåller motsvarande start parantesen ex. ([{
            /// </summary>
            /// <param name="chStartToken">Start parantes ex. ([{</param>
            /// <param name="chEndToken">Avslutande parantes ex. )]}</param>        
            /// <returns>true om Startande och avslutande parantes matchar varandra. Annars returneras false</returns>
            private bool IsMatchingToken(char chStartToken, char chEndToken)
            {
                bool bMatchingToken = false;

                if (chEndToken == ')')
                    if (chStartToken == '(')
                        return true;

                if (chEndToken == '}')
                    if (chStartToken == '{')
                        return true;

                if (chEndToken == ']')
                    if (chStartToken == '[')
                        return true;

                return bMatchingToken;
            }


            /// <summary>
            /// Metoden skriver ut information till console
            /// </summary>
            /// <param name="q">Token som vi skall skriva ut information om</param>
            private void PrintToConsole(IEnumerable<Token> q)
            {
                StringBuilder strBuilder = new StringBuilder();

                int iCount = 0;
                foreach (Token token in q)
                {
                    strBuilder.Append(System.Environment.NewLine);
                    strBuilder.Append(token);
                    iCount++;
                }

                strBuilder.Insert(0, $"Följande Tokens finns ({iCount}).");
                Console.WriteLine(strBuilder.ToString());
            }

        #endregion  // End of region CheckParanthesis

    }
}
