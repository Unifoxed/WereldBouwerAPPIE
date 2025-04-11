using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WereldbouwerAPI
{
    public interface IWereldBouwerRepository
    {
        Task<IEnumerable<WereldBouwer>> GetAllAsync();
        Task<WereldBouwer> GetByWereldbouwerIdAsync(string id);
        Task<IEnumerable<WereldBouwer>> GetByUserIdAsync(string id);
        Task<WereldBouwer> AddAsync(WereldBouwer wereldBouwer); // Updated to return Task<WereldBouwer>
        Task UpdateAsync(WereldBouwer wereldBouwer);
        Task DeleteAsync(string id);
    }
}

