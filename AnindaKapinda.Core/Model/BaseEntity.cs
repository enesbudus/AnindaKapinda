using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Core.Model
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
            CreatedDate = DateTime.Now;
        }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
