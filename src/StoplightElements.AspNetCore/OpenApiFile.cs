using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace StoplightElements.AspNetCore
{
    public class OpenApiFile
    {
        private OpenApiFile(string content)
        {
            Content = content;
        }

        public static OpenApiFile FromString(string contents) => new OpenApiFile(contents);

        public static OpenApiFile FromStaticFile(string path)
        {
            return new OpenApiFile(File.ReadAllText(path));
        }

        public static OpenApiFile FromEmbeddedResource(string fileName, Assembly? searchInAssembly = null)
        {
            var assembly = searchInAssembly ?? Assembly.GetCallingAssembly();
            var possibleResourceNames = assembly.GetManifestResourceNames()
                .Where(str => str.EndsWith(fileName)).ToList();

            if (possibleResourceNames.Count > 1)
                throw new ArgumentException(
                    "The specified filename is ambiguous. Please specify a full resource identifier in the form: Your.NameSpace.FolderName.FileName.extension");

            var resourceName = possibleResourceNames.FirstOrDefault() ?? throw new ArgumentException(
                "The specified file or resource was not found. Double check the provided name, and make sure to define your file as an EmbeddedResource in your project file.");

            using var stream = assembly.GetManifestResourceStream(resourceName) ?? throw new InvalidOperationException($"Unable to open resource stream {resourceName}");
            using var reader = new StreamReader(stream);
            return new OpenApiFile(reader.ReadToEnd());
        }

        public string Content { get; }
    }
}
