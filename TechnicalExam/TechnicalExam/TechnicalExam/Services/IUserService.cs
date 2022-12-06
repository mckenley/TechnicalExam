using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalExam.Models;

namespace TechnicalExam.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers();
    }
}
