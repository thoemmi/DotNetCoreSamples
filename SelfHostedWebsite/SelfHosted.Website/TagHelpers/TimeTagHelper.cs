using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace SelfHosted.Website.TagHelpers
{
    [HtmlTargetElement("time")]
    public class TimeTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"<h1>{DateTime.Now.ToShortTimeString()}</h1>");
        }
    }
}
