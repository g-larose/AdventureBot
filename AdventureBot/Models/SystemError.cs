using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBot.Models
{
    public class SystemError<T>
    {
        public Guid ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
