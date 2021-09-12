using Pet.AppMvc.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pet.AppMvc.ViewModels
{
    public class ProdutoViewModel
    {
        //viewmodel é um pattern! ?  de camada de apresentação
        //model pertecence ao negocio..
        //viewmodel pertence a view - a que vai exibir dados na view ou receber para enviar pra controller
        //uma DTO - carrega as informações..

        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("FornecedorId")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Imagem do Produto")]
        public HttpPostedFileBase ImagemUpload { get; set; }

        public string Imagem { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }


        [ScaffoldColumn(false)] //não criar esse campo na hora de gerar a view
        public DateTime DataCadastro { get; set; }


        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        public FornecedorViewModel Fornecedor { get; set; }//fornecedor que representa o produto

        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; } //lista que vai ajudar a escrever o dropdownlist

    }
}