using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Twitter280
{
    public static class HtmlExt
    {
        public static MvcHtmlString ActionImage(this HtmlHelper helper, String controller, String action, Object parameters, String src, String alt = "", String title = "")
        {
            TagBuilder tagBuilder = new TagBuilder("img");
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            String url = urlHelper.Action(action, controller, parameters);
            String imgUrl = urlHelper.Content(src);
            String image = "";
            StringBuilder html = new StringBuilder();

            // build the image tag.
            tagBuilder.MergeAttribute("src", imgUrl);
            tagBuilder.MergeAttribute("alt", alt);
            tagBuilder.MergeAttribute("title", title);
            image = tagBuilder.ToString(TagRenderMode.SelfClosing);

            html.Append("<a href=\"");
            html.Append(url);
            html.Append("\">");
            html.Append(image);
            html.Append("</a>");

            return MvcHtmlString.Create(html.ToString());
        }
    }
}