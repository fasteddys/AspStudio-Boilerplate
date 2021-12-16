using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace AspStudio_Boilerplate
{
    /// <summary>
    /// sub area view location expander
    /// </summary>
    public class SubAreaViewLocationExpander : IViewLocationExpander
    {
        private const string _subArea = "subarea";

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            //check if subarea key contain
            if (context.ActionContext.RouteData.Values.ContainsKey(_subArea))
            {
                string subArea = RazorViewEngine.GetNormalizedRouteValue(context.ActionContext, _subArea);
                IEnumerable<string> subAreaViewLocation = new string[]
                {
                    "/Areas/{2}/"+subArea+"/Views/{1}/{0}.cshtml"
                };

                viewLocations = subAreaViewLocation.Concat(viewLocations);

            }

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            string subArea = string.Empty;
            context.ActionContext.ActionDescriptor.RouteValues.TryGetValue(_subArea, out subArea);

            context.Values[_subArea] = subArea;
        }
    }

}