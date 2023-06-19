using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Domain;

namespace SaeedLearn.Persistence.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher> , ITeacherRepository
    {
        private readonly SaeedLearnDbContext _dbContext;
        public TeacherRepository(SaeedLearnDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }
    }
}
