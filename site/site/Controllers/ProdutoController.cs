using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using site.Config;
using site.Interfaces;
using site.Models;
using site.ViewModels;

namespace site.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRep, ICategoriaRepositorio categoriaRep)
        {
            _categoriaRepositorio = categoriaRep;
            _produtoRepositorio = produtoRep;
        }

        public ViewResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Produtos> produtos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = _produtoRepositorio.Produtos.OrderBy(p => p.ProdutoId);
                categoriaAtual = "All produtos";
            }
            else
            {
                if (string.Equals("Masculino", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    produtos = _produtoRepositorio.Produtos.Where(p => p.Categoria.NomeCategoria.Equals("Masculino")).OrderBy(p => p.Nome);
                }
                else {
                    produtos = _produtoRepositorio.Produtos.Where(p => p.Categoria.NomeCategoria.Equals("Feminino")).OrderBy(p => p.Nome);
                    categoriaAtual = _categoria;
                }
                
            }

            return View(new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            });
        }


        public ViewResult Details(int produtoId)
        {
            var produto = _produtoRepositorio.Produtos.FirstOrDefault(d => d.ProdutoId == produtoId);
            if (produto == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(produto);
        }


        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Produtos> produtos;
            string catAtual = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                produtos = _produtoRepositorio.Produtos.OrderBy(p => p.ProdutoId);
            }
            else
            {
                produtos = _produtoRepositorio.Produtos.Where(p => p.Nome.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Produto/List.cshtml", new ProdutoListViewModel { Produtos = produtos, CategoriaAtual = "All produtos" });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}