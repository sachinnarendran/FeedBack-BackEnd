using System;
using System.Collections.Generic;
using System.Text;

namespace OutreachFeedback.Web.BusinessLogic
{
    public interface IFileUploadBL
    {
        int SaveFileContent(object file,string filename);
    }
}
