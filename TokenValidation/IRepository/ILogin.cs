using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenValidation.IRepository
{
    public interface ILogin
    {
        string Builder(string userName);
    }
}
