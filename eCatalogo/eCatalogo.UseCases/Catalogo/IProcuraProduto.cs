using eCatalogo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalogo.UseCases.Catalogo
{
    public interface IProcuraProduto
    {
        IEnumerable<Produto> Execute(string filter = null);
    }
}
