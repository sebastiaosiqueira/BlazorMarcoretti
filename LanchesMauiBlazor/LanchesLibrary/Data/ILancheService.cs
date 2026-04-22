using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanchesLibrary.Data
{
    public  interface ILancheService
    {
        Task<IEnumerable<Lanche>>? LoadLanchesAsync();
    }
}
