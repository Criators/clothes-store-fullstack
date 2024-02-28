using Clothes.Store.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Domain.Entities
{
    public class Log
    {
        public Guid LogID { get; set; }

        public string LogLevel { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public DateTime LogDate { get; set; }
    }
}
