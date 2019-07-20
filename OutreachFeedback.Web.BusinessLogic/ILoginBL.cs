using OutreachFeedback.Web.BusinessEntity;
using System;

namespace OutreachFeedback.Web.BusinessLogic
{
    public interface ILoginBL
    {
        /// <summary>
        /// The Authentication Method for Businnes Layer
        /// </summary>
        /// <param name="userobject"></param>
        /// <returns></returns>
        Users Authenticate(int userid, string password);
    }
}
