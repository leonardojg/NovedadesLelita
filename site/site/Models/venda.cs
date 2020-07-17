using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace site.Models
{
    public class Venda
    {
        [BindNever]
        public int VendaId { get; set; }

        public List<DetalhesVenda> DetalhesVenda { get; set; }

        [Required(ErrorMessage = "Entrar com su nombre")]
        [Display(Name = "Primer nombre")]
        [StringLength(50)]
        public string PrimeiroNome { get; set; }

        [Required(ErrorMessage = "Entrar com su Apellido")]
        [Display(Name = "Apellido")]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Dirección")]
        [StringLength(100)]
        [Display(Name = "Calle")]
        public string Endereco1 { get; set; }

        [Display(Name = "Complemento")]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Código Postal")]
        [Display(Name = "CEP")]
        [StringLength(15, MinimumLength = 4)]
        public string CEP { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        
        [StringLength(50)]
        public string Pais { get; set; }

        
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Su correo electronico no está en el formato correcto!")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal TotalVenda { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime DataVenda { get; set; }
    }
}

