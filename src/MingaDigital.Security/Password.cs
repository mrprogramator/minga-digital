using System;
using System.Linq;

namespace MingaDigital.Security
{
    public class Password : IEquatable<Password>
    {
        public Byte[] Hash { get; set; }
        
        public Byte[] Salt { get; set; }
        
        public String Algorithm { get; set; }
        
        public Boolean Equals(Password other) =>
            Algorithm == other.Algorithm
            && Hash.SequenceEqual(other.Hash);
    }
}