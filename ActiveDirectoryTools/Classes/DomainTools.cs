using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace ActiveDirectoryTools.Classes
{
    class DomainTools
    {
        public static bool isInDomain()
        {
            try
            {
                domain = System.DirectoryServices.ActiveDirectory.Domain.GetCompuetDomain(); 
            }
            finally
            {
                domain = null;
            }
            if (domain == null) domain = false;
            else
            {
                domain = true;
            }
            return domain;
        }

    }
}
