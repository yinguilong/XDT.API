using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XDT.Infrastructure
{
    /// <summary>
    /// url 帮助类
    /// </summary>
    public class UrlHelper
    {
        public static string GetDomainFromUrl(string url)
        {
            string strreg = @"[\.](?<domain>[^\.]+)\.com";
            if (Regex.IsMatch(url, strreg))
            {
                var matche = Regex.Match(url, strreg);
                return matche.Groups["domain"].Value;
            }
            else
                return string.Empty;
        }
    }
}

