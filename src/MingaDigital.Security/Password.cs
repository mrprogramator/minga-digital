using System;

namespace MingaDigital.Security
{
    public class Password
    {
        public Byte[] Hash { get; set; }
        
        public Byte[] Salt { get; set; }
        
        public String Algorithm { get; set; }
    }
}