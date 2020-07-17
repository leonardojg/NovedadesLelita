using Microsoft.AspNetCore.Mvc;
using site.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Config
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepositorio _categoriaRep;
        public CategoriaMenu(ICategoriaRepositorio repcat)
        {
            _categoriaRep = repcat;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRep.Categorias.OrderBy(p => p.NomeCategoria);
            return View(categorias);
        }
    }
}
