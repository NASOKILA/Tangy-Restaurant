#pragma checksum "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ddafb3e27189e09b759d575d36102d1a7be77c14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Manage), @"mvc.1.0.view", @"/Views/Order/Manage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/Manage.cshtml", typeof(AspNetCore.Views_Order_Manage))]
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
#line 6 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
using TangyRestaurant.Utility;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddafb3e27189e09b759d575d36102d1a7be77c14", @"/Views/Order/Manage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99b8f6aec2c07f23ba6da62b0ec4800bddf4107b", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Manage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TangyRestaurant.Models.OrderDetailsViewModel.OrderDetailsViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "InProgress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Ready", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cancel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
  
    ViewData["Title"] = "Manage";

#line default
#line hidden
            BeginContext(123, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(157, 63, true);
            WriteLiteral("\r\n<h2 class=\"text-info\">Manage Order\'s</h2>\r\n<hr />\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(220, 1666, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a859305979047bdb45e00c6e43b8ed5", async() => {
                BeginContext(240, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
#line 14 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
     if (Model.Any(m => m.OrderHeader == null))
    {

#line default
#line hidden
                BeginContext(300, 71, true);
                WriteLiteral("        <h3 class=\"text-danger\">Error... Please try again later.</h3>\r\n");
                EndContext();
#line 17 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
    }
    else
    {
        

#line default
#line hidden
#line 20 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
         if (Model.Count > 0)
        {
            

#line default
#line hidden
#line 22 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
                BeginContext(494, 124, true);
                WriteLiteral("                <div class=\"container col-sm-12 row\">\r\n                    <div class=\"col-sm-10\">\r\n                        ");
                EndContext();
                BeginContext(619, 56, false);
#line 26 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
                   Write(await Html.PartialAsync("_IndividualOrderDetails", item));

#line default
#line hidden
                EndContext();
                BeginContext(675, 113, true);
                WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-sm-2\" style=\"position:relative; top:12px;\">\r\n\r\n");
                EndContext();
#line 30 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
                         if (item.OrderHeader.Status.Equals(SD.StatusSubmitted))
                        {

#line default
#line hidden
                BeginContext(897, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(925, 187, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0fae0c1238f4302a8a06bf54b622bb2", async() => {
                    BeginContext(1061, 42, true);
                    WriteLiteral("<i class=\"fas fa-check\"></i> Start Cooking");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 32 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
                                                                            WriteLiteral(item.OrderHeader.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1112, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 33 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
                        }
                        else if (item.OrderHeader.Status.Equals(SD.StatusInProcess))
                        {

#line default
#line hidden
                BeginContext(1254, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(1282, 192, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae496e71ea1645db9bf6dfc3d85adc6d", async() => {
                    BeginContext(1413, 52, true);
                    WriteLiteral("<i class=\"fas fa-flag-checkered\"></i> Order Prepared");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 36 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
                                                                       WriteLiteral(item.OrderHeader.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1474, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 37 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
                        }

#line default
#line hidden
                BeginContext(1503, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
                BeginContext(1529, 181, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86fd66f74265484193c933f6169e49d4", async() => {
                    BeginContext(1660, 41, true);
                    WriteLiteral("<i class=\"fas fa-times\"></i> Cancel Order");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 39 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
                                                                    WriteLiteral(item.OrderHeader.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1710, 56, true);
                WriteLiteral("\r\n\r\n                    </div>\r\n                </div>\r\n");
                EndContext();
#line 43 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
            }

#line default
#line hidden
#line 43 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
             
        }
        else
        {

#line default
#line hidden
                BeginContext(1817, 44, true);
                WriteLiteral("            <p>No orders in database .</p>\r\n");
                EndContext();
#line 48 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
        }

#line default
#line hidden
#line 48 "C:\Users\Asus\Desktop\Courses\.NET Core MVC 2.0\.NET-Core-Udemy\02.TangyRestaurant\TangyRestaurant\TangyRestaurant\Views\Order\Manage.cshtml"
         
    }

#line default
#line hidden
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1886, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TangyRestaurant.Models.OrderDetailsViewModel.OrderDetailsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
