﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using site.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Models
{
    public class Carrinho
    {

        private readonly ApplicationDbContext _appDbContext;
        private Carrinho(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string CarrinhoId { get; set; }
        public List<CarrinhoItem> CarrinhoItens { get; set; }



        //MÉTODOS DA CLASSE

        public static Carrinho GetCarrinho(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string carId = session.GetString("CarId") ?? Guid.NewGuid().ToString();

            session.SetString("CarId", carId);

            return new Carrinho(context) { CarrinhoId = carId };
        }



        public void AddToCarrinho(Produtos produto, int quant)
        {
            var carrinhoItem =
                    _appDbContext.CarrinhoItens.SingleOrDefault(
                        s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoId == CarrinhoId);

            if (carrinhoItem == null)
            {
                carrinhoItem = new CarrinhoItem
                {
                    CarrinhoId = CarrinhoId,
                    Produto = produto,
                    Quantidade = 1
                };

                _appDbContext.CarrinhoItens.Add(carrinhoItem);
            }
            else
            {
                carrinhoItem.Quantidade++;
            }
            _appDbContext.SaveChanges();
        }




        public int RemoveCarrinho(Produtos produto)
        {
            var carrinhoItem =
                    _appDbContext.CarrinhoItens.SingleOrDefault(
                        s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoId == CarrinhoId);

            var localQuant = 0;

            if (carrinhoItem != null)
            {
                if (carrinhoItem.Quantidade > 1)
                {
                    carrinhoItem.Quantidade--;
                    localQuant = carrinhoItem.Quantidade;
                }
                else
                {
                    _appDbContext.CarrinhoItens.Remove(carrinhoItem);
                }
            }

            _appDbContext.SaveChanges();

            return localQuant;
        }



        public List<CarrinhoItem> GetCarrinhoItens()
        {
            return CarrinhoItens ??
                   (CarrinhoItens =
                       _appDbContext.CarrinhoItens.Where(c => c.CarrinhoId == CarrinhoId)
                           .Include(s => s.Produto)
                           .ToList());
        }


        public void LimparCarrinho()
        {
            var carItens = _appDbContext
                .CarrinhoItens
                .Where(car => car.CarrinhoId == CarrinhoId);

            _appDbContext.CarrinhoItens.RemoveRange(carItens);

            _appDbContext.SaveChanges();
        }

        public decimal GetCarrinhoTotal()
        {
            var total = _appDbContext.CarrinhoItens.Where(c => c.CarrinhoId == CarrinhoId)
                .Select(c => c.Produto.Preco * c.Quantidade).Sum();
            return total;
        }

    }
}
