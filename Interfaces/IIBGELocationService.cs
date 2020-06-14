using System.Collections.Generic;
using System.Threading.Tasks;
using LocationFunction.Models;

namespace LocationFunction.Interfaces
{
    public interface IIBGELocationService
    {
        Task<IEnumerable<IBGEState>> GetStates();
    }
}