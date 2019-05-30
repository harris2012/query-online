using Savory.QueryOnline.Controllers.Request;
using Savory.QueryOnline.Controllers.Response;
using Savory.QueryOnline.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Savory.QueryOnline.Controllers
{
    public class ExecutionController : ApiController
    {
        [HttpPost]
        public ExecuteResponse Execute(ExecuteRequest request)
        {
            ExecuteResponse response = new ExecuteResponse();

            List<Header> headers = new List<Header>();
            for (int i = 0; i < 4; i++)
            {
                Header header = new Header();
                header.Title = $"T{i + 1}";
                headers.Add(header);
            }
            response.HeaderList = headers;

            List<List<string>> rows = new List<List<string>>();
            for (int i = 0; i < 68; i++)
            {
                List<string> row = new List<string>();

                for (int ij = 0; ij < 4; ij++)
                {
                    row.Add($"C-{i}-{ij}");
                }

                rows.Add(row);
            }
            response.RowList = rows;

            response.Message = request.Command;

            response.Status = 1;
            return response;
        }
    }
}