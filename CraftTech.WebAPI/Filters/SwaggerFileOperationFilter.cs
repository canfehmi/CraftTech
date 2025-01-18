using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CraftTech.WebAPI.Filters
{
    public class SwaggerFileOperationFilter:IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.RequestBody != null)
            {
                foreach (var content in operation.RequestBody.Content)
                {
                    if (content.Key == "multipart/form-data")
                    {
                        operation.RequestBody.Content[content.Key].Schema.Properties.Add("file", new OpenApiSchema
                        {
                            Type = "string",
                            Format = "binary"
                        });
                    }
                }
            }
        }
    }
}
