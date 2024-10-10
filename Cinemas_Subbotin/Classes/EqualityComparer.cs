using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas_Subbotin.Classes
{
    public class EqualityComparer
    {
        public bool Equals(KInoteatrContext k1, KInoteatrContext k2)
        {
            if (k1 == null || k2 == null)
                return false;
            else if (k1.Id == k2.Id &&
                k1.Name == k2.Name &&
                k1.Count == k2.Count &&
                k1.CountZal == k2.CountZal)
                return true;
            else
                return false;
        }
    }
}
