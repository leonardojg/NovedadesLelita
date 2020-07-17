using site.Interfaces;
using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Config
{
    public class ConfigProduto : IProdutoRepositorio
    {

        private readonly ICategoriaRepositorio _categoriaRepositorio = new ConfigCategoria();

        public IEnumerable<Produtos> Produtos
        {


            get
            {
                return new List<Produtos>
                {
                    new Produtos {
                        Nome = "Tenis",
                        Preco = 85,
                        DescricaoCurta = "Tenis",
                        DescricaoLonga = "Tenis femeninos diversos colores",
                        Categoria = _categoriaRepositorio.Categorias.First(),
                        ImagemUrl = "https://scontent.fcgh10-1.fna.fbcdn.net/v/t1.0-9/73015914_738504493628254_2498284413936475779_o.jpg?_nc_cat=100&_nc_sid=8bfeb9&_nc_ohc=BjjeejP0Bc8AX9zYGxo&_nc_ht=scontent.fcgh10-1.fna&oh=d3923b0d0f13b0b43a9ef225db680236&oe=5F3616D4",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl = "https://scontent.fcgh10-1.fna.fbcdn.net/v/t1.0-9/75327042_738504480294922_906788500794935945_n.jpg?_nc_cat=105&_nc_sid=8bfeb9&_nc_ohc=3oWFmn-qruIAX_Plt37&_nc_ht=scontent.fcgh10-1.fna&oh=df5af387219914bb1d055300ac7cdb37&oe=5F37CD09"

                    },

                    new Produtos {
                        Nome = "Saia",
                        Preco = 200,
                        DescricaoCurta = "Saia Feminina",
                        DescricaoLonga = "Saia diversos tamanhos e diversas cores",
                        Categoria = _categoriaRepositorio.Categorias.Last(),
                        ImagemUrl = "https://mfrontzek.com/wp-content/uploads/2017/08/Saia-God%C3%AA-Franzida-Floral.png",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl = "https://mfrontzek.com/wp-content/uploads/2017/08/Saia-God%C3%AA-Franzida-Floral.png"

                    },

                };
            }
        }

        public IEnumerable<Produtos> ProdutosMaisVendidos { get; }

        public Produtos GetProdutosById(int produtoId)
        {
            throw new NotImplementedException();
        }
    }
}
