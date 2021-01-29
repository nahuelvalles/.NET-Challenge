
using Microsoft.AspNetCore.Mvc;
using System;
using TheSchool.Models;

namespace TheSchool.Controllers
{
    public class QuestionController : Controller
    {
        Services.IDataService<Entities.KnowledgeBaseItem> KnowledgeData;
        Services.IQueryService<Entities.KnowledgeBaseItem> KnowledgeQuery;
        readonly AutoMapper.IMapper mapper;

        public QuestionController(Services.IDataService<Entities.KnowledgeBaseItem> knowledgeData, Services.IQueryService<Entities.KnowledgeBaseItem> knowledgeQuery)
        {
            KnowledgeData = knowledgeData;
            KnowledgeQuery = knowledgeQuery;


            //TODO: Implement mapping as needed.
            var cfgManager = new AutoMapper.MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Entities.KnowledgeBaseItem, QuestionAndAnswerEditModel>()
                    .ForMember(x => x.Question, opt => opt.MapFrom(z => z.Query));

                    cfg.CreateMap<QuestionAndAnswerEditModel, Entities.KnowledgeBaseItem>()
                    
                    .ForMember(x => x.Query, opt => opt.MapFrom(z => z.Question));
                });

            mapper = cfgManager.CreateMapper();
        }
        // GET: Question
        public ActionResult Edit(int id)
        {
            var editById = KnowledgeQuery.Get(id);
            var itemMapped = mapper.Map<QuestionAndAnswerEditModel>(editById);
            return View("Edit", itemMapped);

        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionAndAnswerEditModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Implement this part of code to persist changes into database.
                var modelEdit = mapper.Map< Entities.KnowledgeBaseItem > (model);
                KnowledgeData.Edit(modelEdit);
                KnowledgeData.CommitChanges();
                
            }
            return View("Edit", model);
        }
    }
}