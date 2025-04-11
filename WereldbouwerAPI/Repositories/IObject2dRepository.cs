using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WereldbouwerAPI
{
    public interface IObject2DRepository
    {
        Task<IEnumerable<Object2D>> GetByEnvironmentIdAsync(Guid environmentId);
        Task<Object2D> AddObject2DAsync(Object2D object2D);
        Task DeleteAllByEnvironmentIdAsync(Guid environmentId);
    }
}
