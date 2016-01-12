using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace RomanNums
{
    public class MockRoman : IRoman
    {
        #region Static data
        private Dictionary<string, int> MapNums = new Dictionary<string, int>()
        {
            { "viii"      ,8     },
            { "ix"        ,9     },
            { "xviii"     ,18    },
            { "xlvi"      ,46    },
            { "lXXV"      ,75    },
            { "XCII"      ,92    },
            { "IC"        ,99    },
            { "CDXLI"    ,441   },
            { "DCXCV"    ,695   },
            { "DCCIL"    ,749   },
            { "MCMLXXXiv",1984  },
            { "MCMXLIV"  ,1944  }
        };

        private Dictionary<string, bool> MapChecks = new Dictionary<string, bool>()
        {
            { ""          ,false},
            { "-1"        ,false},
            { "12v"       ,false},
            { "vii V"     ,false},
            { "viii"      ,true },
            { "ix"        ,true },
            { "xviii"     ,true },
            { "xlvi"      ,true },
            { "lXXV"      ,true },
            { "XCII"      ,true },
            { "IC"        ,true },
            { "CDXLI"    ,true },
            { "DCXCV"    ,true },
            { "DCCIL"    ,true },
            { "MCMLXXXiv",true },
            { "MCMXLIV"  ,true } 
        };
        #endregion 


        public int Convert(string str)
        {
            if (MapNums.ContainsKey(str))
            {
                return MapNums[str];
            }
            else if (str == new string('M', 2147483))
            {
                throw new OverflowException("Error: Number is either to big or to small."); // too big number
            }
            else {
                throw new FormatException("Invalid string supplied, string should contain only 'IVXLCDM' chars."); // wrong char
            }
        }

        public bool IsCompliant(string str)
        {
            if (MapChecks.ContainsKey(str))
            {
                return MapChecks[str];
            }
            else {
                return false;
            }
        }
    }
}
