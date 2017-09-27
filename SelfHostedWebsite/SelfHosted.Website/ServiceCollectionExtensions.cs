using Microsoft.AspNetCore.Mvc.Razor;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SelfHosted.Website
{
    public static class ServiceCollectionExtensions
    {
        public static RazorViewEngineOptions AddViews(this RazorViewEngineOptions options)
        {
            options.FileProviders.Add(new EmbeddedFileProvider(typeof(ServiceCollectionExtensions).GetTypeInfo().Assembly, "SelfHosted.Website"));
            return options;
        }

        public static RazorViewEngineOptions AddCompilationAssemblies(this RazorViewEngineOptions options)
        {
            var myAssemblies = AppDomain
               .CurrentDomain
               .GetAssemblies()
               .Where(x => !x.IsDynamic)
               .Concat(new[] { // additional assemblies used in Razor pages:
                        typeof(HtmlString).Assembly, // Microsoft.AspNetCore.Html.Abstractions
                        typeof(IViewLocalizer).Assembly, // Microsoft.AspNetCore.Mvc.Localization
                        typeof(IRequestCultureFeature).Assembly, // Microsoft.AspNetCore.Localization
               })
               .Select(x => MetadataReference.CreateFromFile(x.Location))
               .ToArray();

            var previous = options.CompilationCallback;

            options.CompilationCallback = context =>
            {
                previous?.Invoke(context);
                context.Compilation = context.Compilation.AddReferences(myAssemblies);
            };

            return options;
        }

        public static IServiceCollection AddStaticFiles(this IServiceCollection collection)
        {
            // static files are embedded resources in the "wwwroot" folder
            collection.Configure<StaticFileOptions>(options =>
            {
                options.FileProvider = new EmbeddedFileProvider(typeof(Startup).Assembly, typeof(Startup).Namespace + ".wwwroot");
            });

            return collection;
        }

    }
}
