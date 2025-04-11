using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WereldbouwerAPI
{
    public interface IObject2DRepository
    {
        Task<IEnumerable<Object2D>> GetByEnvironmentIdAsync(string environmentId);
        Task<Object2D> AddObject2DAsync(Object2D object2D);
        Task DeleteAllByEnvironmentIdAsync(string environmentId);
    }
}
