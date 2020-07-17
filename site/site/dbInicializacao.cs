using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using site.Data;
using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site
{
    public class dbInicializacao
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            ApplicationDbContext context =
                serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Categorias.Any())
            {
                context.Categorias.AddRange(Categorias.Select(c => c.Value));
            }

            if (!context.Produtos.Any())
            {
                context.AddRange
                (
                    new Produtos
                    {
                        Nome = "Tenis",
                        Preco = 250,
                        DescricaoCurta = "Tenis",
                        DescricaoLonga = "Tenis Masculino diversas cores",
                        Categoria = Categorias["Masculino"],
                        ImagemUrl = "/images/camisa.jpg",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl = "/images/camisap.jpg"

                    },

                    new Produtos
                    {
                        Nome = "Vestido",
                        Preco = 200,
                        DescricaoCurta = "Vestido Curto",
                        DescricaoLonga = "Vestido diversos tamanhos e diversas cores",
                        Categoria = Categorias["Feminino"],
                        ImagemUrl = "/images/vestido.jpg",
                        EmEstoque = true,
                        Ativo = false,
                        ImagemMiniaturaUrl = "/images/vestidop.jpg"

                    },

                     new Produtos
                     {
                         Nome = "Blusa",
                         Preco = 150,
                         DescricaoCurta = "Blusa Feminina",
                         DescricaoLonga = "Blusas de diversos tamanhos e cores",
                         Categoria = Categorias["Feminino"],
                         ImagemUrl = "/images/blusa.png",
                         EmEstoque = true,
                         Ativo = true,
                         ImagemMiniaturaUrl = "/images/blusap.png"

                     },

                       new Produtos
                       {
                           Nome = "Tenis1",
                           Preco = 150,
                           DescricaoCurta = "Bermuda Masculina",
                           DescricaoLonga = "Bermuda de diversos tamanhos e cores",
                           Categoria = Categorias["Masculino"],
                           ImagemUrl = "/images/bermuda.jpg",
                           EmEstoque = true,
                           Ativo = true,
                           ImagemMiniaturaUrl = "/images/bermudap.jpg"

                       },

                        new Produtos
                        {
                            Nome = "Camisa Social",
                            Preco = 350,
                            DescricaoCurta = "Camisa Social Manga Longa",
                            DescricaoLonga = "Camisa Social Manga Longa de diversos tamanhos",
                            Categoria = Categorias["Masculino"],
                            ImagemUrl = "/images/camisasocial.jpg",
                            EmEstoque = true,
                            Ativo = true,
                            ImagemMiniaturaUrl = "/images/camisasocialp.jpg"

                        },


                         new Produtos
                         {
                             Nome = "Jaqueta",
                             Preco = 350,
                             DescricaoCurta = "Jaqueta Feminina",
                             DescricaoLonga = "Jaqueta Feminina Manga Longa de diversos tamanhos",
                             Categoria = Categorias["Feminino"],
                             ImagemUrl = "/images/jaqueta.png",
                             EmEstoque = true,
                             Ativo = true,
                             ImagemMiniaturaUrl = "/images/jaquetap.png"

                         },


                         new Produtos
                         {
                             Nome = "Terno",
                             Preco = 350,
                             DescricaoCurta = "Terno Slim",
                             DescricaoLonga = "Terno Slim de diversos tamanhos",
                             Categoria = Categorias["Masculino"],
                             ImagemUrl = "/images/terno.jpg",
                             EmEstoque = true,
                             Ativo = true,
                             ImagemMiniaturaUrl = "/images/ternop.jpg"

                         }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Categoria> categorias;
        public static Dictionary<string, Categoria> Categorias
        {
            get
            {
                if (categorias == null)
                {
                    var generoList = new Categoria[]
                    {
                    new Categoria { NomeCategoria = "Masculino", Descricao = "Todos los Productos Masculinos" },
                    new Categoria { NomeCategoria = "Femenino", Descricao = "Todos los Productos Femeninos" },
                    new Categoria { NomeCategoria = "Niños", Descricao = "Todos los Productos de Niños" }
                    };

                    categorias = new Dictionary<string, Categoria>();

                    foreach (Categoria genero in generoList)
                    {
                        categorias.Add(genero.NomeCategoria, genero);
                    }
                }

                return categorias;
            }
        }
    }
}
