using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Common.Exceptions
{
    internal class DbObjectIsNullException : BaseException
    {
        public string MethodName { get; set; }
        public DbObjectIsNullException(string methodName, string message) 
            : base(message)
        {
            MethodName = methodName;
        }
    }
}
