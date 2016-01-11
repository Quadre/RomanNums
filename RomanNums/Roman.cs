using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RomanNums
{
    public class Roman:IRoman
    {

        #region Static data
        private Dictionary<char, int> mapping = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
        #endregion      

        public int Covnvert(string str)
        {
            if (!isCompliant(str))
            {
                throw new FormatException("Error: Invalid string supplied, string should contain only 'IVXCLMD' chars.");
            }

            int result = 0;
            int prev = 0;
            int cur = 0;

            try
            {
                for (int i = str.Length-1; i >= 0; i--)
                {
                    cur = Map(char.ToUpper(str[i]));
                    result += (cur >= prev ? cur : -cur);                    
                    prev = cur;
                }
            }
            catch (Exception ex)
            {
                throw new OverflowException("Error: Number is either too big or too small.", ex);
            }

            return result;
        }

        private int Map(char UpCaseKey)
        {
            if (mapping.ContainsKey(UpCaseKey))
            {
                return mapping[UpCaseKey];
            }
            else
            {
                throw new FormatException("Error:  Invalid string supplied, string should contain only 'IVXLCDM' chars.");
            }
        }

        public bool isCompliant(string str)
        {
            Regex r = new Regex("[^ivxlcdm]+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return (!r.IsMatch(str) && str.Length >0);
        }
    }
}
