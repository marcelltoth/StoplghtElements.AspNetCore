using Microsoft.AspNetCore.Http;

namespace StoplightElements.AspNetCore
{
    public class ServeOpenApiDocumentOptions
    {
        public ServeOpenApiDocumentOptions(OpenApiFile apiDescription)
        {
            ApiDescription = apiDescription;
        }

        public PathString Path { get; set; } = "/openapi.yaml";
        public OpenApiFile ApiDescription { get; }
    }
}
