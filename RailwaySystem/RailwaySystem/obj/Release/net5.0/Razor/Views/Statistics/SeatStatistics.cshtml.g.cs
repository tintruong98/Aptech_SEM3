#pragma checksum "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84b2c6887a4837b810de78e088d20b9b9560a40e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Statistics_SeatStatistics), @"mvc.1.0.view", @"/Views/Statistics/SeatStatistics.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84b2c6887a4837b810de78e088d20b9b9560a40e", @"/Views/Statistics/SeatStatistics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94cd98ddd03a7aa9112770b496120acf0c156419", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Statistics_SeatStatistics : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RailwaySystem.Models.TotalSeats>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/TableDisprice.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SeatStatistics", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Statistics", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
  
    ViewData["Title"] = "SeatStatistics";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "84b2c6887a4837b810de78e088d20b9b9560a40e5021", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<h3 class=\"alert-info\">&nbsp;&nbsp;Statistics</h3>\r\n<hr />\r\n\r\n<a");
            BeginWriteAttribute("href", " href=\"", 227, "\"", 272, 1);
#nullable restore
#line 10 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
WriteAttributeValue("", 234, Url.Action("Quantri", "LoginDetails"), 234, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <span class=\"btn btn-outline-success\">Back</span>\r\n</a>\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84b2c6887a4837b810de78e088d20b9b9560a40e6679", async() => {
                WriteLiteral(@"
        <label>From&nbsp;&nbsp;</label>
        <input id=""Text1"" name=""FromDate"" type=""date"" />
        <label>&nbsp;&nbsp;To&nbsp;&nbsp;</label>
        <input id=""Text2"" name=""ToDate"" type=""date"" />
        <input type=""submit"" value=""Select"" class=""btn btn-outline-info"" />
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n<h5 style=\"color:red\">");
#nullable restore
#line 24 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                 Write(ViewBag.msg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n<hr />\r\n\r\n");
#nullable restore
#line 28 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
 if (ViewBag.Fromdate == ViewBag.ToDate)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4 class=\"alert-success text-center\">Statistics of seats sold on ");
#nullable restore
#line 30 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                                                                 Write(ViewBag.Todate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 31 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4 class=\"alert-success text-center\">Statistics of seats sold from day ");
#nullable restore
#line 34 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                                                                       Write(ViewBag.Fromdate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" to day ");
#nullable restore
#line 34 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                                                                                                Write(ViewBag.ToDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n");
#nullable restore
#line 35 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<div class=\"container\">\r\n    <ul class=\"responsive-table\">\r\n        <li class=\"table-header\">\r\n            <div class=\"col col-1\">");
#nullable restore
#line 40 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                              Write(Html.DisplayNameFor(model => model.SeatCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"col col-2\">");
#nullable restore
#line 41 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                              Write(Html.DisplayNameFor(model => model.ClassName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"col col-3\">");
#nullable restore
#line 42 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                              Write(Html.DisplayNameFor(model => model.SeatsTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"col col-4\">");
#nullable restore
#line 43 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                              Write(Html.DisplayNameFor(model => model.PriceTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </li>\r\n");
#nullable restore
#line 45 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"table-row\">\r\n                <div class=\"col col-1\">");
#nullable restore
#line 48 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                                  Write(Html.DisplayFor(modelItem => item.SeatCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"col col-2\">");
#nullable restore
#line 49 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                                  Write(Html.DisplayFor(modelItem => item.ClassName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"col col-2\">");
#nullable restore
#line 50 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                                  Write(Html.DisplayFor(modelItem => item.SeatsTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"col col-3\">\r\n                    ");
#nullable restore
#line 52 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
               Write(Html.DisplayFor(modelItem => item.PriceTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </li>\r\n");
#nullable restore
#line 55 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </ul>
</div>

<table class=""table"" width=""100%"">
    <tbody>
        <tr>
            <td colspan=""3"" align=""center""><a class=""btn btn-info btn-block"" style=""color:white""><strong>Total</strong></a></td>
            <td align=""left""><a class=""btn btn-warning""><strong>");
#nullable restore
#line 63 "D:\Railway\RailwaySystem\RailwaySystem\Views\Statistics\SeatStatistics.cshtml"
                                                           Write(ViewBag.sum);

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;VNĐ</strong></a></td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RailwaySystem.Models.TotalSeats>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
