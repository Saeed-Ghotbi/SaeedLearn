using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Domain;

namespace SaeedLearn.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
        private readonly SaeedLearnDbContext _dbContext;

        public CategoryRepository(SaeedLearnDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
