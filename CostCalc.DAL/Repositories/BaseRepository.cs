using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added
using NLog;
using CostCalc.Helper.ExceptionHandling;
using CostCalc.DAL.Interfaces;
using CostCalc.DAL.EF;

namespace CostCalc.DAL.Repositories
{
    /// <summary>
    /// Base Repository Implementation, All Repositories must Inherit this Class
    /// </summary>
    public abstract class BaseRepository<Domain, IdType> : IBaseRepository<Domain, IdType>, IDisposable
    {
        /// <summary>
        /// Used to Log Unhandled Exceptions
        /// </summary>
        protected Logger _Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Used to Get or Set All User Displayed Errors
        /// </summary>
        protected GlobalErrors _GlobalErrors;

        protected CostCalculatorDBEntities _DbContext;

        public BaseRepository(GlobalErrors globalErrors)
        {
            _GlobalErrors = globalErrors;
            _GlobalErrors.DefaultErrorLayer = ErrorLayer.DAL;

            _DbContext = new CostCalculatorDBEntities();
        }

        /// <summary>
        /// Use with UnitOfWork Block only
        /// </summary>
        /// <param name="uowDbContext">dbContext from UnitOfWork Object</param>
        /// <param name="globalErrors"></param>
        public BaseRepository(CostCalculatorDBEntities uowDbContext, GlobalErrors globalErrors)
        {
            _GlobalErrors = globalErrors;
            _GlobalErrors.DefaultErrorLayer = ErrorLayer.DAL;

            _DbContext = uowDbContext;
        }

        public abstract void Add(Domain domain);
        public abstract void Update(Domain domain);
        public abstract void Delete(Domain domain);
        public abstract Domain GetById(IdType id);

        public void Save()
        {
            _DbContext.SaveChanges();
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }
    }
}
