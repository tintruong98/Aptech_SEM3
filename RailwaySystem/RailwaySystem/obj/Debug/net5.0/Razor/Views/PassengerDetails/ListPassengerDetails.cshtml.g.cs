#pragma checksum "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "492f0b1ea5d81f6a5757df3a6d94c8adc3724667"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PassengerDetails_ListPassengerDetails), @"mvc.1.0.view", @"/Views/PassengerDetails/ListPassengerDetails.cshtml")]
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
#nullable restore
#line 1 "D:\Railway\RailwaySystem\RailwaySystem\Views\_ViewImports.cshtml"
using RailwaySystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Railway\RailwaySystem\RailwaySystem\Views\_ViewImports.cshtml"
using RailwaySystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"492f0b1ea5d81f6a5757df3a6d94c8adc3724667", @"/Views/PassengerDetails/ListPassengerDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94cd98ddd03a7aa9112770b496120acf0c156419", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_PassengerDetails_ListPassengerDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RailwaySystem.Models.PassengerDetails>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListPassengerDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PassengerDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
  
    ViewData["Title"] = "ListPassengerDetails";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3 class=\"alert-success\">List Passenger Details</h3>\r\n<br />\r\n<p>\r\n");
            WriteLiteral("    <a href=\"#\">\r\n        <span class=\"btn btn-primary btn-outline-primary\">Add new</span>\r\n    </a>\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 441, "\"", 476, 1);
#nullable restore
#line 16 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
WriteAttributeValue("", 448, Url.Action("Index", "Home"), 448, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <span class=\"btn btn-success\">Home</span>\r\n    </a>\r\n</p>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "492f0b1ea5d81f6a5757df3a6d94c8adc37246674987", async() => {
                WriteLiteral("\r\n        <label>Search by Name&nbsp;&nbsp;</label>\r\n        <input type=\"text\" name=\"varLocal\" />\r\n        <input type=\"submit\" value=\"Search\" class=\"btn btn-info\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.PNR));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.PhoneNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Source));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Destination));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 49 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Departure));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 52 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.TrainNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 55 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Compartment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 58 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.SeatCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 61 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 67 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 71 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.PNR));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 74 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 77 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 80 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.PhoneNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 83 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Source));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 86 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Destination));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 89 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Departure));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 92 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.TrainNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 95 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Compartment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 98 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.SeatCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 101 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
            WriteLiteral("                ");
#nullable restore
#line 105 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { varLocal = item.PNR }, new { @class = "btn btn-warning" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 106 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { varLocal = item.PNR }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 109 "D:\Railway\RailwaySystem\RailwaySystem\Views\PassengerDetails\ListPassengerDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RailwaySystem.Models.PassengerDetails>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
