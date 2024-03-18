using AdventureBot.BaseModules;
using AdventureBot.Models;
using MODiX.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBot.Services
{
    public class DiceRollerProviderService: IDisposable
    {
        public Result<List<int>, SystemError<string>> Roll(int dieAmount, int sides)
        {
            List<int> rollResult = new();
            var error = new SystemError<string>();
            Random rnd = new();

            try
            {
                for (int i = 0; i < dieAmount; i++)
                {
                    var die = rnd.Next(1, sides + 1);
                    rollResult.Add(die);
                }

                if (rollResult.Count > 0)
                    return Result<List<int>, SystemError<string>>.Ok(rollResult)!;
            }
            catch(Exception e)
            {
                error.ErrorCode = Guid.NewGuid();
                error.ErrorMessage = e.Message;
                return Result<List<int>, SystemError<string>>.Err(error)!;
            }
            error.ErrorMessage = "something went wrong";
            error.ErrorCode = Guid.NewGuid();
            return Result<List<int>, SystemError<string>>.Err(error)!;
        }

        #region DISPOSE
        public void Dispose()
        {
            DisposableBase disposableBase = new();
            disposableBase.Dispose();
        }
        #endregion
    }
}
