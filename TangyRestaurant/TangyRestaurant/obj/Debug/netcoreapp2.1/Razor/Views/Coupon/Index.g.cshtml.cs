#pragma checksum "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11f7841fb4cee6861e5f43cab999fcfbb4c1699d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Coupon_Index), @"mvc.1.0.view", @"/Views/Coupon/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Coupon/Index.cshtml", typeof(AspNetCore.Views_Coupon_Index))]
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
#line 1 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\_ViewImports.cshtml"
using TangyRestaurant;

#line default
#line hidden
#line 2 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\_ViewImports.cshtml"
using TangyRestaurant.Models;

#line default
#line hidden
#line 3 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\_ViewImports.cshtml"
using TangyRestaurant.TagHelpers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11f7841fb4cee6861e5f43cab999fcfbb4c1699d", @"/Views/Coupon/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99b8f6aec2c07f23ba6da62b0ec4800bddf4107b", @"/Views/_ViewImports.cshtml")]
    public class Views_Coupon_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TangyRestaurant.Models.Coupon>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(92, 45, true);
            WriteLiteral("\r\n<h2>Coupons List</h2>\r\n\r\n<hr />\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(138, 51, false);
#line 11 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
Write(await Html.PartialAsync("_CreateButtonPartialView"));

#line default
#line hidden
            EndContext();
            BeginContext(189, 155, true);
            WriteLiteral("\r\n\r\n<br />\r\n<br />\r\n\r\n<div class=\"form-border\">\r\n    <br />\r\n    <table class=\"table table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th>");
            EndContext();
            BeginContext(345, 32, false);
#line 21 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Name));

#line default
#line hidden
            EndContext();
            BeginContext(377, 27, true);
            WriteLiteral("</th>\r\n                <th>");
            EndContext();
            BeginContext(405, 36, false);
#line 22 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Discount));

#line default
#line hidden
            EndContext();
            BeginContext(441, 27, true);
            WriteLiteral("</th>\r\n                <th>");
            EndContext();
            BeginContext(469, 37, false);
#line 23 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.MinAmount));

#line default
#line hidden
            EndContext();
            BeginContext(506, 27, true);
            WriteLiteral("</th>\r\n                <th>");
            EndContext();
            BeginContext(534, 36, false);
#line 24 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.IsActive));

#line default
#line hidden
            EndContext();
            BeginContext(570, 61, true);
            WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 28 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
             foreach (var coupon in Model)
            {

#line default
#line hidden
            BeginContext(690, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(737, 11, false);
#line 31 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
                   Write(coupon.Name);

#line default
#line hidden
            EndContext();
            BeginContext(748, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(780, 15, false);
#line 32 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
                   Write(coupon.Discount);

#line default
#line hidden
            EndContext();
            BeginContext(795, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(827, 16, false);
#line 33 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
                   Write(coupon.MinAmount);

#line default
#line hidden
            EndContext();
            BeginContext(843, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(875, 15, false);
#line 34 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
                   Write(coupon.IsActive);

#line default
#line hidden
            EndContext();
            BeginContext(890, 57, true);
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(947, 102, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fd2415eb4fe49da93c9e2d10cb0b9d4", async() => {
                BeginContext(1018, 27, true);
                WriteLiteral("<i class=\"fas fa-edit\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 36 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
                                               WriteLiteral(coupon.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1049, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(1075, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8e185d2380b4e2a858eae1e24386b0a", async() => {
                BeginContext(1147, 32, true);
                WriteLiteral("<i class=\"fas fa-trash-alt\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 37 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
                                                 WriteLiteral(coupon.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1183, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 40 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1250, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 43 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
     if (Model.Count() < 1)
    {

#line default
#line hidden
            BeginContext(1318, 38, true);
            WriteLiteral("        <p>No coupons in db. . .</p>\r\n");
            EndContext();
#line 46 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Coupon\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1363, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TangyRestaurant.Models.Coupon>> Html { get; private set; }
    }
}
#pragma warning restore 1591
