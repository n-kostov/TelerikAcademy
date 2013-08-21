using CodeJewels.Models;
using CodeJewels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeJewels.Services.Controllers
{
    public class CodeJewelsController : ApiController
    {
        private readonly IRepository<CodeJewel> codeJewelsRepository;

        public CodeJewelsController(IRepository<CodeJewel> codeJewelsRepository)
        {
            this.codeJewelsRepository = codeJewelsRepository;
        }

        [ActionName("getall")]
        public IEnumerable<CodeJewel> GetAll()
        {
            var codeJewelEntities = codeJewelsRepository.All();
            return codeJewelEntities.ToList();
        }

        [ActionName("get")]
        public CodeJewel GetById(int id)
        {
            var codeJewelEntity = this.codeJewelsRepository.Get(id);
            return codeJewelEntity;
        }

        [ActionName("get")]
        public IEnumerable<CodeJewel> GetBySourceCode(string source)
        {
            var codeJewelEntities = this.codeJewelsRepository.All().Where(x => x.SourceCode == source);
            return codeJewelEntities;
        }

        [ActionName("get")]
        public IEnumerable<CodeJewel> GetByCategoryName(string category)
        {
            var codeJewelEntities = this.codeJewelsRepository.All().Where(x => x.Category.CategoryName == category);
            return codeJewelEntities;
        }

        [ActionName("add")]
        public HttpResponseMessage AddCodeJewel([FromBody] CodeJewel jewel)
        {
            var createdJewel = this.codeJewelsRepository.Add(jewel);
            var response = Request.CreateResponse<CodeJewel>(HttpStatusCode.Created, createdJewel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdJewel.CodeJewelId });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }
    }
}
