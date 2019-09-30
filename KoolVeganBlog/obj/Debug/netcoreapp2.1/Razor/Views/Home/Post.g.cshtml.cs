#pragma checksum "C:\Users\sbenh\source\repos\KoolVeganBlog\KoolVeganBlog\Views\Home\Post.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2d841819ccd4523ee52cf3ad722b74e1851eebd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Post), @"mvc.1.0.view", @"/Views/Home/Post.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Post.cshtml", typeof(AspNetCore.Views_Home_Post))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\sbenh\source\repos\KoolVeganBlog\KoolVeganBlog\Views\_ViewImports.cshtml"
using KoolVeganBlog;

#line default
#line hidden
#line 2 "C:\Users\sbenh\source\repos\KoolVeganBlog\KoolVeganBlog\Views\_ViewImports.cshtml"
using KoolVeganBlog.Models;

#line default
#line hidden
#line 3 "C:\Users\sbenh\source\repos\KoolVeganBlog\KoolVeganBlog\Views\_ViewImports.cshtml"
using KoolVeganBlog.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2d841819ccd4523ee52cf3ad722b74e1851eebd", @"/Views/Home/Post.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cdef870eb2886d81d00eee7d1d881cce1499c0a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Post : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Post>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\sbenh\source\repos\KoolVeganBlog\KoolVeganBlog\Views\Home\Post.cshtml"
  
    ViewBag.Title = Model.Title;
    ViewBag.Description = Model.Description;
    ViewBag.Keywords = $"{Model.Tags?.Replace(",", "")} {Model.Category}";

#line default
#line hidden
            BeginContext(176, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(183, 11, false);
#line 8 "C:\Users\sbenh\source\repos\KoolVeganBlog\KoolVeganBlog\Views\Home\Post.cshtml"
Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(194, 9, true);
            WriteLiteral("</h2>\r\n\r\n");
            EndContext();
#line 10 "C:\Users\sbenh\source\repos\KoolVeganBlog\KoolVeganBlog\Views\Home\Post.cshtml"
 if (!String.IsNullOrEmpty(Model.Image))
{
    var image_path = $"/Image/{Model.Image}";

#line default
#line hidden
            BeginContext(295, 8, true);
            WriteLiteral("    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 303, "\"", 320, 1);
#line 13 "C:\Users\sbenh\source\repos\KoolVeganBlog\KoolVeganBlog\Views\Home\Post.cshtml"
WriteAttributeValue("", 309, image_path, 309, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(321, 17, true);
            WriteLiteral(" width=\"300\" />\r\n");
            EndContext();
#line 14 "C:\Users\sbenh\source\repos\KoolVeganBlog\KoolVeganBlog\Views\Home\Post.cshtml"
}

#line default
#line hidden
            BeginContext(341, 29, true);
            WriteLiteral("<div class=\"post-body\">\r\n    ");
            EndContext();
            BeginContext(371, 20, false);
#line 16 "C:\Users\sbenh\source\repos\KoolVeganBlog\KoolVeganBlog\Views\Home\Post.cshtml"
Write(Html.Raw(Model.Body));

#line default
#line hidden
            EndContext();
            BeginContext(391, 14, true);
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Post> Html { get; private set; }
    }
}
#pragma warning restore 1591
