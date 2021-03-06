﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Albion.Parsers
{
#pragma warning disable 1591
    [PhraseParser]
    public class IntParser : TypeParser<int>
    {
        public override int Coeff { get { return 100; } }

        public override IEnumerable<string> Examples
        {
            get
            {
                yield return "8";
                yield return "11";
                yield return "eight hundred and twenty-one";
            }
        }

        protected override bool TryParse(string s, out int res)
        {
            res = -1;

            // Try to parse simply
            int o;

            if (int.TryParse(s, out o))
            {
                res = o;
                return true;
            }
            else // Try to parse strings
            {
                int? _o = Converters.Number(s);

                if (_o == null)
                {
                    return false;
                }
                else
                {
                    res = _o.Value;
                    return true;
                }
            }
        }
    }
}
