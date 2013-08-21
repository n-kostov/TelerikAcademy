using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApi_FileUpload.Controllers
{
    public class FileController : ApiController
    {
        //    // GET api/values
        //    public IEnumerable<string> Get()
        //    {
        //        return new string[] { "value1", "value2" };
        //    }

        //    // GET api/values/5
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage result = null;
            var localFilePath = HttpContext.Current.Server.MapPath("~/" + id);

            // check if parameter is valid
            if (String.IsNullOrEmpty(id))
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
                // check if file exists on the server
            else if (!File.Exists(localFilePath))
            {
                result = Request.CreateResponse(HttpStatusCode.Gone);
            }
            else
            {// serve the file to the client
                result = Request.CreateResponse( HttpStatusCode.OK);
                result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = id;
            }

            return result;
        }

        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            // Check if files are available
            if (httpRequest.Files.Count > 0)
            {
                var files = new List<string>();

                // interate the files and save on the server
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    postedFile.SaveAs( filePath);

                    files.Add(filePath);
                }

                // return result
               result = Request.CreateResponse(HttpStatusCode.Created, files);
            }
            else
            {
                // return BadRequest (no file(s) available)
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;
        }

        // PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}