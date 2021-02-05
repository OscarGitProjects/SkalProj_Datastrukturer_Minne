using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public class ValidateParanthesis
    {
        public static int FindIndexOfToken(char chToken, string strText, int iStartIndex)
        {
            int iIndex = -1;

            for(int i = iStartIndex; i < strText.Length; i++)
            {
                if(strText[i] == chToken)
                {
                    iIndex = i;
                    break;
                }
            }

            return iIndex;
        }
    }
}
