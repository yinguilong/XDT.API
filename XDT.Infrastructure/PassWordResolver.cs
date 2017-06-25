using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;

namespace XDT.Infrastructure
{
    public class PassWordResolver 
    {
        protected  string ResolveCore(string source)
        {
            if (!string.IsNullOrEmpty(source))
                return CryptHelper.Encrypto(source);
            else
                return string.Empty;
        }
    }
}