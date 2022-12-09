using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Common.Exceptions
{
    public static class ExceptionsFactory
    {
        /// <summary>
        /// Use this method to create instance of the DbObjectIsNullException class indirectly
        /// </summary>
        /// <param name="methodName">
        /// Name of the method in which exception occured
        /// </param>
        /// <param name="message">
        /// The error message that explains the reason for the exception
        /// </param>
        /// <returns>
        /// Instance of DbObjectIsNullException, needed if object that was retrieved from DB is null
        /// </returns>
        public static DbObjectIsNullException DbObjectIsNullException(string methodName, string message)
        {
            return new DbObjectIsNullException(methodName, message);
        }

        // You need to implement your Custom InvalidArgumentException
        public static Exception InvArgException(string paramName)
        {
            throw new NotImplementedException();
        }
    }
}
