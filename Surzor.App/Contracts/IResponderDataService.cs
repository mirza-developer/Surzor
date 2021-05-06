using Surzor.App.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Surzor.App.Contracts
{
    public interface IResponderDataService
    {
        Task<ICollection<ResponderListViewModel>> GetAllResponders();
    }
}
