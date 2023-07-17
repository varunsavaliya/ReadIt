using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadIt.Entities.ViewModels.Common
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
