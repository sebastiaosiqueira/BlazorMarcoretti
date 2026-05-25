using eCatalogo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalogo.UseCases.Catalogo
{
    public interface IExibeProduto
    {
        Produto Execute(int id);
    }
}
