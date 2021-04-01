using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Extensions
{
    public class FileUploadOperation : IOperationFilter
    {


        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
        }
    }
}
