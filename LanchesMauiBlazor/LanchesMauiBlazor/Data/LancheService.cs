using LanchesLibrary;
using LanchesLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanchesMauiBlazor.Data
{
    public class LancheService :ILancheService
    {

        public async Task<IEnumerable<Lanche>> LoadLanchesAsync()
        {
            await Task.Delay(1000);
            var lanches = new[]
            {
        new Lanche("Cheese Burger", "Pão e Hamburger tradicional com queijo"),
        new Lanche("Cheese Salada", "Pão e Hamburger tradicional com queijo e alface"),
        new Lanche("Cheese Salada Egg", "Pão e Hamburger tradicional com queijo e alface e ovo"),
        new Lanche("Misto Quente", "Pão de forma, presunto e queijo"),
        new Lanche("Bauru", "Pão de forma, presunto, queijo, tomate e queijo"),
        };
            return lanches;
        }
    }
}
