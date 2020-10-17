using Microsoft.AspNetCore.Http;

namespace StoplightElements.AspNetCore
{
    public class StoplightElementsOptions
    {
        public StoplightElementsOptions(string apiDescriptionFileUri)
        {
            ApiDescriptionFileUri = apiDescriptionFileUri;
        }

        public string ApiDescriptionFileUri { get; set; }
    }
}
