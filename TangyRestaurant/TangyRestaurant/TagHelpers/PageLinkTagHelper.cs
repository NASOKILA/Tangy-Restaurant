using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TangyRestaurant.Models;

namespace TangyRestaurant.TagHelpers
{
    [HtmlTargetElement("div", Attributes="page-model")]
    public class PageLinkTagHelper : TagHelper //use the .net core class for Tag Helpers
    {
        private IUrlHelperFactory urlHelperFactory; //Builds Urls

        public PageLinkTagHelper(IUrlHelperFactory _urlHelperFactory)
        {
            urlHelperFactory = _urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } // This gives us access to HttpContext, HttpRequest and more

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public bool PageClassesEnabled { get; set; }

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }


        //Here we wil be modifying the main function
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Here we get the URL insade the Url helper
            IUrlHelper urlHelper = this.urlHelperFactory.GetUrlHelper(this.ViewContext);

            //We need a TagBuilder object to make the changes and append some html to it.
            TagBuilder result = new TagBuilder("div"); // we use "div" here because it's our target element.


            //we create our pagination :
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {

                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { productPage = i });

                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                //Here we add the numbers to our pagination
                tag.InnerHtml.Append(i.ToString());

                //Finally we apend it to the result.
                result.InnerHtml.AppendHtml(tag);
            }

            //We append it the the actual output
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}



