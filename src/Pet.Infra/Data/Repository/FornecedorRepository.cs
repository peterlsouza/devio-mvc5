using Pet.Business.Models.Fornecedores;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using Pet.Infra.Data.Context;

namespace Pet.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }


        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking() //tira o tracking..
                .Include(f => f.Endereco) //incluindo o endereço.. fornecedor + endereço
                .FirstOrDefaultAsync(f => f.Id == id); 
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco) //inclui endereço
                .Include(f => f.Produtos) //inclui produtos
                .FirstOrDefaultAsync(f => f.Id == id);
        }


        //o repositório generico por si só ja exclui qualquer entidade que é passada para ele..
        //neste caso, override para não deletar e apenas mudar para inativo..
        //ideal seria um campo exlcuido setado como true
        public override async Task Remover(Guid id)
        {
            var fornecedor = await ObterPorId(id);
            fornecedor.Ativo = false;

            await Atualizar(fornecedor);

        }
    }
}
