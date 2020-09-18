using FitOl.Domain.Entities;
using FitOl.Repository.Abstract;
using FitOl.Repository.Concrete.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Repositories
{
    public class EfThatDayRepository : EfGenericRepository<ThatDay>, IThatDayRepository
    {
        public EfThatDayRepository(SportDatabaseContext context) : base(context)
        {
        }
        public SportDatabaseContext DatabaseContext
        {
            get { return _context as SportDatabaseContext; }
        }
    }
}
