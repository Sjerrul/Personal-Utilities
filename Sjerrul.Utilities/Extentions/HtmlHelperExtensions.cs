using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Sjerrul.Utilities.Extentions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ShortenText(this HtmlHelper htmlHelper, string text, int numberOfCharacters)
        {
            return ShortenText(htmlHelper, text, numberOfCharacters, "...", "span");
        }

        public static MvcHtmlString ShortenText(this HtmlHelper htmlHelper, string text, int numberOfCharacters, string htmlElement)
        {
            return ShortenText(htmlHelper, text, numberOfCharacters, "...", htmlElement);
        }

        public static MvcHtmlString ShortenText(this HtmlHelper htmlHelper, string text, int numberOfCharacters, string endWith, string htmlElement)
        {
            TagBuilder tag = new TagBuilder(htmlElement);
            tag.Attributes.Add("title", text);
            tag.InnerHtml = text.MaxLength(numberOfCharacters, endWith);

            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString ImageLink(this HtmlHelper htmlHelper, string imageUrl, string actionName, string controllerName)
        {
            return ImageLink(htmlHelper, imageUrl, actionName, controllerName, null, null, String.Empty);
        }

        public static MvcHtmlString ImageLink(this HtmlHelper htmlHelper, string imageUrl, string actionName, string controllerName, object routevalues)
        {
            return ImageLink(htmlHelper, imageUrl, actionName, controllerName, routevalues, null, String.Empty);
        }

        public static MvcHtmlString ImageLink(this HtmlHelper htmlHelper, string imageUrl, string actionName, string controllerName, object routevalues, object htmlAttributes, string altText)
        {
            TagBuilder tag = new TagBuilder("img");
            tag.MergeAttribute("src", imageUrl);

            if (!String.IsNullOrWhiteSpace(altText))
            {
                tag.MergeAttribute("alt", altText);
                tag.MergeAttribute("title", altText);
            }

            string replacementText = "[replaceme]";
            var link = htmlHelper.ActionLink(
                replacementText,
                actionName,
                controllerName,
                routevalues,
                htmlAttributes).ToString();

            return MvcHtmlString.Create(link.Replace(replacementText, tag.ToString(TagRenderMode.SelfClosing)));
        }

        public static string ApplicationVersion(this HtmlHelper htmlHelper)
        {
            try
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return version.ToString();
            }
            catch
            {
                return "?.?.?.?";
            }
        }
    }
}
