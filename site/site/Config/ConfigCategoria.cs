using site.Interfaces;
using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Config
{
    public class ConfigCategoria : ICategoriaRepositorio
    {
        public IEnumerable<Categoria> Categorias
        {
            get
            {
                return new List<Categoria>
                {
                    new Categoria { NomeCategoria = "Masculino", Descricao = "Todos los Productos Masculinos" },
                    new Categoria { NomeCategoria = "Feminino", Descricao = "Todos los Productos Femininos" },
                    new Categoria { NomeCategoria = "Niños", Descricao = "Todos los Productos de Niños" },
                };
            }
        }
    }
}
