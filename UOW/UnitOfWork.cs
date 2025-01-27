using Freelance.Models;
using Freelance.Repositiories;

namespace Freelance.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FreelancerDBContext _context;
        public UnitOfWork(FreelancerDBContext context)
        {
            _context = context;
        }

        private  IFreelanceRepository _freelanceRepository;
        private ISkillsetRepository _skillsetRepository;
        private IHobbyRepository _hobbyRepository;

        public IFreelanceRepository FreelanceRepository
        {
            get
            {
                if (_freelanceRepository == null)
                {
                    _freelanceRepository = new FreelancerRepository(_context);
                }
                return _freelanceRepository;
            }
        }

        public ISkillsetRepository SkillsetRepository
        {
            get
            {
                if (_skillsetRepository == null)
                {
                    _skillsetRepository = new SkillsetRepository(_context);
                }
                return _skillsetRepository;
            }
        }

        public IHobbyRepository HobbyRepository
        {
            get
            {
                if (_hobbyRepository == null)
                {
                    _hobbyRepository = new HobbyRepository(_context);
                }
                return _hobbyRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
