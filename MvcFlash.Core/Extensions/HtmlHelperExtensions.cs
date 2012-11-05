﻿using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcFlash.Core.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Flash<TModel>(this HtmlHelper<TModel> helper)
        {
            var popper = DependencyResolver.Current.GetService<IFlashMessenger>()
                ?? Core.Flash.Instance;

            var builder = new StringBuilder();

            while (popper.Count > 0)
            {
                var message = popper.Pop();
                builder.AppendLine(helper.DisplayFor(m => message).ToString());
            }

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}