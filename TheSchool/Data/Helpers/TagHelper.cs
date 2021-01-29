using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSchool.Entities;

namespace TheSchool.Data.Helpers
{
    public static class TagHelper
    {
        public static List<Entities.TagItem> Process(Services.IQueryService<Entities.KnowledgeBaseItem> knowledgeService, out int tagMaxCount)
        {
            var sourceItems = knowledgeService.GetAll();
            return Process(sourceItems, out tagMaxCount);
        }

        public static List<Entities.TagItem> Process(List<Entities.KnowledgeBaseItem> items, out int tagMaxCount)
        {
            //TODO: Based on the list of items you need to rank tags dynamically. 
            //Also, return the max value that will be used for Tag Cloud control.

            //intentar mejorar

            List<TagItem> tags = new List<TagItem>();
            foreach (var tag in items)
            {
                tags.AddRange(tag.Tags.Split(",").Select(x => new TagItem() { Tag = x }));
            }

            
            var results = from t in tags
                          group t by t.Tag into g
                          select new TagItem { Tag = g.Key, Count = g.Count() };

          
            tagMaxCount = results.Count();

            return results.ToList();
         
            

           
        }
    }

}