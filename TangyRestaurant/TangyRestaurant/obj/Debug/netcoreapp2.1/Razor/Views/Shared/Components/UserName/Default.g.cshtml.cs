#pragma checksum "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\Components\UserName\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "145bc0a2153eb2e5c8a5b29165e27464b07f8327"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserName_Default), @"mvc.1.0.view", @"/Views/Shared/Components/UserName/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/UserName/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_UserName_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"145bc0a2153eb2e5c8a5b29165e27464b07f8327", @"/Views/Shared/Components/UserName/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99b8f6aec2c07f23ba6da62b0ec4800bddf4107b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_UserName_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TangyRestaurant.Models.ApplicationUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(104, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\Components\UserName\Default.cshtml"
  
    //This is the view for our ViewComponent, we will use it insade the _LoginPartial
    //we specify the model that we will pass to it

    ViewData["Title"] = "Default";
    string fullname = string.Empty;

    ApplicationUser currentUser = null;
    if (Model == null)
    {
        currentUser = _db.Users.First(u => u.Email == this.User.Identity.Name) as ApplicationUser;
        fullname = currentUser.FirstName + " " + currentUser.LastName;

    }
    else
    {
        fullname = Model.FirstName + " " + Model.LastName;
    }

#line default
#line hidden
            BeginContext(666, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 26 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\Components\UserName\Default.cshtml"
 if (Model == null)
{
    if (currentUser != null)
    {
        

#line default
#line hidden
            BeginContext(740, 8, false);
#line 30 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\Components\UserName\Default.cshtml"
   Write(fullname);

#line default
#line hidden
            EndContext();
            BeginContext(748, 30, true);
            WriteLiteral(" <i class=\"far fa-user\"></i>\r\n");
            EndContext();
#line 31 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\Components\UserName\Default.cshtml"
    }
}
else
{
    

#line default
#line hidden
            BeginContext(802, 8, false);
#line 35 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\Components\UserName\Default.cshtml"
Write(fullname);

#line default
#line hidden
            EndContext();
            BeginContext(810, 30, true);
            WriteLiteral(" <i class=\"far fa-user\"></i>\r\n");
            EndContext();
#line 36 "C:\Users\Asus\Desktop\projects\Tangy Restaurant\Tangy-Restaurant\TangyRestaurant\TangyRestaurant\Views\Shared\Components\UserName\Default.cshtml"
}

#line default
#line hidden
            BeginContext(843, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public TangyRestaurant.Data.ApplicationDbContext _db { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TangyRestaurant.Models.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
