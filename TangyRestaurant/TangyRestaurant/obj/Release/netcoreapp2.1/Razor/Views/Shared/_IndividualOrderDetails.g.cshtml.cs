#pragma checksum "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "258935b13769146174d3fb227842d8e7a36bd9b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__IndividualOrderDetails), @"mvc.1.0.view", @"/Views/Shared/_IndividualOrderDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_IndividualOrderDetails.cshtml", typeof(AspNetCore.Views_Shared__IndividualOrderDetails))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"258935b13769146174d3fb227842d8e7a36bd9b4", @"/Views/Shared/_IndividualOrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99b8f6aec2c07f23ba6da62b0ec4800bddf4107b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__IndividualOrderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TangyRestaurant.Models.OrderDetailsViewModel.OrderDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(75, 185, true);
            WriteLiteral("\r\n<div class=\"col-sm-12 row rounded\" style=\"background-color: aliceblue; padding:10px; margin:10px 0px;\">\r\n    <div class=\"col-sm-6\">\r\n        <label class=\"text-danger\">Order Number : ");
            EndContext();
            BeginContext(261, 20, false);
#line 5 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml"
                                             Write(Model.OrderHeader.Id);

#line default
#line hidden
            EndContext();
            BeginContext(281, 24, true);
            WriteLiteral("</label>\r\n        <ul>\r\n");
            EndContext();
#line 7 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml"
             foreach (OrderDetails item in Model.OrderDetailsList)
            {

#line default
#line hidden
            BeginContext(388, 44, true);
            WriteLiteral("                <li>\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 432, "\"", 470, 2);
            WriteAttributeValue("", 439, "/Home/Details/", 439, 14, true);
#line 10 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml"
WriteAttributeValue("", 453, item.MenuItem.Id, 453, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(471, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(474, 18, false);
#line 10 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml"
                                                          Write(item.MenuItem.Name);

#line default
#line hidden
            EndContext();
            BeginContext(493, 3, true);
            WriteLiteral(" x ");
            EndContext();
            BeginContext(498, 10, false);
#line 10 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml"
                                                                                  Write(item.Count);

#line default
#line hidden
            EndContext();
            BeginContext(509, 29, true);
            WriteLiteral("</a>\r\n                </li>\r\n");
            EndContext();
#line 12 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml"
            }

#line default
#line hidden
            BeginContext(553, 281, true);
            WriteLiteral(@"        </ul>
    </div>
    <div class=""col-sm-6"">
        <div class=""row"">
            <div class=""col-sm-2""></div>
            <div class=""col-sm-4"">
                <label>Order Total :</label>
            </div>
            <div class=""col-sm-6"">
                <p>");
            EndContext();
            BeginContext(835, 28, false);
#line 22 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml"
              Write(Model.OrderHeader.OrderTotal);

#line default
#line hidden
            EndContext();
            BeginContext(863, 271, true);
            WriteLiteral(@" </p>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-sm-2""></div>
            <div class=""col-sm-4"">
                <label>PickUp Time :</label>
            </div>
            <div class=""col-sm-6"">
                <p>");
            EndContext();
            BeginContext(1135, 60, false);
#line 32 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml"
              Write(Model.OrderHeader.PickUpTime.ToString("dd/MM/yyyy HH:mm tt"));

#line default
#line hidden
            EndContext();
            BeginContext(1195, 271, true);
            WriteLiteral(@"</p>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-sm-2""></div>
            <div class=""col-sm-4"">
                <label>Order Status :</label>
            </div>
            <div class=""col-sm-6"">
                <p>");
            EndContext();
            BeginContext(1467, 24, false);
#line 42 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml"
              Write(Model.OrderHeader.Status);

#line default
#line hidden
            EndContext();
            BeginContext(1491, 267, true);
            WriteLiteral(@"</p>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-sm-2""></div>
            <div class=""col-sm-4"">
                <label>Comments :</label>
            </div>
            <div class=""col-sm-6"">
                <p>");
            EndContext();
            BeginContext(1759, 26, false);
#line 52 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\_IndividualOrderDetails.cshtml"
              Write(Model.OrderHeader.Comments);

#line default
#line hidden
            EndContext();
            BeginContext(1785, 66, true);
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TangyRestaurant.Models.OrderDetailsViewModel.OrderDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
