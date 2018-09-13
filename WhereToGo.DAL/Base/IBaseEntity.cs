using System;
using System.Collections.Generic;
using System.Text;

namespace WhereToGo.DAL.Base
{
    public interface IBaseEntity
    {
        string Id { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }
    }
}
