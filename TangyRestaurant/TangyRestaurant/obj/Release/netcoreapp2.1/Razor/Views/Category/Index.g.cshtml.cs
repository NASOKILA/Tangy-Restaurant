#pragma checksum "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba992cae4d54f4021db22b654acb8dfe6c099096"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_Index), @"mvc.1.0.view", @"/Views/Category/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Category/Index.cshtml", typeof(AspNetCore.Views_Category_Index))]
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
#line 1 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\_ViewImports.cshtml"
using TangyRestaurant;

#line default
#line hidden
#line 2 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\_ViewImports.cshtml"
using TangyRestaurant.Models;

#line default
#line hidden
#line 3 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\_ViewImports.cshtml"
using TangyRestaurant.TagHelpers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba992cae4d54f4021db22b654acb8dfe6c099096", @"/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99b8f6aec2c07f23ba6da62b0ec4800bddf4107b", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<TangyRestaurant.Models.Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Category\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(94, 44, true);
            WriteLiteral("\r\n<h2>Category List</h2>\r\n<hr />\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(139, 51, false);
#line 10 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Category\Index.cshtml"
Write(await Html.PartialAsync("_CreateButtonPartialView"));

#line default
#line hidden
            EndContext();
            BeginContext(190, 294, true);
            WriteLiteral(@" 

<br />
<br />

<div class=""form-border"">
    <br/>
    <table class=""table table-hover"">
        <thead>
            <tr>
                <th>Name</th>
                <th>Display Order</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 26 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Category\Index.cshtml"
             foreach (var category in Model)
            {

#line default
#line hidden
            BeginContext(545, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(592, 13, false);
#line 29 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Category\Index.cshtml"
                   Write(category.Name);

#line default
#line hidden
            EndContext();
            BeginContext(605, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(637, 21, false);
#line 30 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Category\Index.cshtml"
                   Write(category.DisplayOrder);

#line default
#line hidden
            EndContext();
            BeginContext(658, 57, true);
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(716, 63, false);
#line 32 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Category\Index.cshtml"
                   Write(await Html.PartialAsync("_TableButtonPartialView", category.Id));

#line default
#line hidden
            EndContext();
            BeginContext(779, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 35 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Category\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(846, 33, true);
            WriteLiteral("        </tbody> \r\n    </table>\r\n");
            EndContext();
#line 38 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Category\Index.cshtml"
     if (Model.Count < 1)
    {

#line default
#line hidden
            BeginContext(913, 41, true);
            WriteLiteral("        <p>No categories in db. . .</p>\r\n");
            EndContext();
#line 41 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Category\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(961, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<TangyRestaurant.Models.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591