using Freelance.Repositiories;

namespace Freelance.UOW
{
    public interface IUnitOfWork
    {
        IFreelanceRepository FreelanceRepository { get; }
        ISkillsetRepository SkillsetRepository { get; }
        IHobbyRepository HobbyRepository { get; }
        void SaveChanges();
    }
}
