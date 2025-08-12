using WPF_study.Interfaces;
using WPF_study.Models;

namespace WPF_study.Services
{
    class GangnamguPupulationService : IDatabase<GangnamguPopulation>
    {
        private readonly WpfprojectDatabaseContext _dbContext;

        public GangnamguPupulationService(WpfprojectDatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }
        public void Create(GangnamguPopulation entity)
        {
            _dbContext?.GangnamguPopulations.Add(entity);
            _dbContext?.SaveChanges();
        }

        public void Delete(int? id)
        {
            var vaildData = _dbContext.GangnamguPopulations.FirstOrDefault(x => x.Id == id);
            if (vaildData != null) {
                _dbContext?.GangnamguPopulations.Remove(vaildData);
                _dbContext?.SaveChanges();
            }
        }

        public List<GangnamguPopulation> Get()
        {
            return _dbContext?.GangnamguPopulations?.ToList();
        }

        public GangnamguPopulation? GetDetail(int? id)
        {
            var vaildData = _dbContext?.GangnamguPopulations.FirstOrDefault(y => y.Id == id);
            if (vaildData != null)
            {
                return vaildData;
            }

            return null;
        }

        public void Update(GangnamguPopulation entity)
        {
            _dbContext?.GangnamguPopulations.Update(entity);
            _dbContext?.SaveChanges();
        }
    }
}
