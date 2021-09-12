using Pet.Business.Core.Models;
using Pet.Business.Models.Fornecedores.Validations;
using Pet.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Business.Models.Fornecedores
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }


        /*   EF Relations   */
        public ICollection<Produto> Produtos { get; set; }


    }
}
