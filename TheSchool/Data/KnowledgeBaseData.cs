using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheSchool.Entities;

namespace TheSchool.Data
{
    public class KnowledgeBaseData : Services.IDataService<KnowledgeBaseItem>, Services.IQueryService<KnowledgeBaseItem>
    {
        WisperoDbContext _context;

        #region Constructors
        public KnowledgeBaseData(WisperoDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods
        public void Add(KnowledgeBaseItem entity)
        {
            //TODO: Implement Adding mechanism for KnowledgeBaseItems.
            _context.KnowledgeBaseItems.Add(entity);
            CommitChanges();
            
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            //TODO: Implement Deleting mechanism for KnowledgeBaseItems.
            //var elementToEliminate = this.Get(id);
             _context.KnowledgeBaseItems.Remove(this.Get(id));

            CommitChanges();
            
        }

        public void Edit(KnowledgeBaseItem entity)
        {
            //TODO: Implement Editing mechanism for KnowledgeBaseItems.
            //This need to handle concurrency. As long as rowversions are the same then persist changes.
            var oldItem = this.Get(entity.Id);
            
            if(oldItem.RowVersion == entity.RowVersion)
            {
                oldItem.Query = entity.Query;
                oldItem.Answer = entity.Answer;
            }

            CommitChanges();

        }

        public KnowledgeBaseItem Get(int id)
        {
            return _context.KnowledgeBaseItems.FirstOrDefault(x => x.Id == id);
            
        }

        public List<KnowledgeBaseItem> GetAll()
        {
            //TODO: Implement Getting ALL mechanism for KnowledgeBaseItems.
            return _context.KnowledgeBaseItems.ToList();
            
        }

        public List<KnowledgeBaseItem> GetByFilter(Expression<Func<KnowledgeBaseItem, bool>> expression)
        {
            //TODO: Implement Getting by Filter mechanism for KnowledgeBaseItems.
            var itemsFiltered = _context.KnowledgeBaseItems.Where(expression).ToList();
            return itemsFiltered;
        }

        #endregion
    }
}
