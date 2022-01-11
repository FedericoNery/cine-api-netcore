using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<ICollection<T>> GetAll(); //IReadOnlyList<T> es la otra alternativa para no realizar cambios en la lista
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<Unit> Delete(T entity);

        //Acá van las operaciones más generales CRUD básico
    }
}
