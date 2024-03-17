using MODiX.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBot.Interfaces
{
    public interface IDataProvider
    {
        Result<string, string>? SetPlayerProfessionAvatar(string profession);
    }
}
