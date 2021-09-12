using Pet.Business.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Business.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        //interface para persistir qualquer entidade fazendo o CRUD e outras 
        //mais especializadas..
        //TEntity = representa a entidade...´*Generico
        //IDisposable pra faer o Dispose dos objetos
        //só vai ser representado, quem herdade de Entity

        Task Adicionar(TEntity entity);
        Task <TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();//retorna inteiro, numero de linhas afetadas no banco..
    }
}
