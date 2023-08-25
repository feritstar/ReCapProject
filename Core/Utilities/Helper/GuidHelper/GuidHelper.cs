using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helper.GuidHelper
{
    public class GuidHelper
    {
        /// <summary>
        /// GUID => Global Unique Identifier
        /// </summary>
        /// <returns></returns>
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
