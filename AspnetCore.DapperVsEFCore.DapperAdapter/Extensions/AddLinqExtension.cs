using System;
using System.Collections.Generic;

namespace AspnetCore.DapperVsEFCore.DapperAdapter.Extensions
{
    public static class AddLinqExtension
    {
        public static void Add<T>(this List<T> source, T novoItem, Predicate<T> condicaoVerifaSeExiste)
        {
            if (novoItem != null && !source.Exists(condicaoVerifaSeExiste))
            {
                source.Add(novoItem);
            }
        }
    }
}
