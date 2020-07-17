using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.ViewModels
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }
        public decimal CarrinhoTotal { get; set; }
    }
}
