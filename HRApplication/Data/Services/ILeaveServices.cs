using HRApplication.Models;
using System.Numerics;

namespace HRApplication.Data.Services
{
    public interface ILeaveServices
    {
        IEnumerable<Leave> GetAll();

        Leave GetById(int id);
        Task<Leave> Add(Leave leave);
        Task<Leave> Update(Leave leave);

        void Delete(int id);

        void Accepted(int id);

        void Rejected( int id);

        Leave GetPosts(int id);

        void UpdatePost(Leave Leave);

        Task<bool> SavechangesAsync();



        // Task<List<Leave>> GetPostsAsync();
    }
}
