#pragma checksum "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d3a44ff1c0ed55fadc30ac8b4615e6893abe4cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StudentHome_Courses), @"mvc.1.0.view", @"/Views/StudentHome/Courses.cshtml")]
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
#line 1 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\_ViewImports.cshtml"
using Prometheus_MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\_ViewImports.cshtml"
using Prometheus_MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d3a44ff1c0ed55fadc30ac8b4615e6893abe4cb", @"/Views/StudentHome/Courses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41773d27ae46f50430498d8e08f72ccd7636eb97", @"/Views/_ViewImports.cshtml")]
    public class Views_StudentHome_Courses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Prometheus_MVC.Models.CourseViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Courses", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml"
  
    ViewData["Title"] = "Courses";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    a{
        color:aliceblue;
        text-decoration:none;
    }
        a:hover {
            color: aqua;
            text-decoration: none;
        }
    
    .tile {
        width: 1000px;
        margin: 10px;
        background-color: #99aeff;
        background-image: linear-gradient(to bottom right,#b92b27, #1565c0);
        display: inline-block;
        background-size: cover;
        position: relative;
        cursor: pointer;
        transition: all 0.4s ease-out;
        box-shadow: 0px 35px 77px -17px rgba(0,0,0,0.44);
        overflow: hidden;
        color: white;
        font-family: 'Roboto';
    }
</style>
<h1>Courses</h1>
<div onclick=""location.href='javascript:history.back()'"">
    <h4 style=""cursor:pointer;color:gold""><i class=""fas fa-chevron-circle-left""></i> Back</h4>
</div>
<div class=""tile"">

        <div class=""table-responsive"" style=""overflow-x: hidden;"">
            <table id=""myTable"" class=""table-borderless"" width=""100%"" style=""col");
            WriteLiteral("or:white;margin-left:40px;\">\r\n\r\n                <thead>\r\n                    <tr>\r\n                        <th>\r\n                            ");
#nullable restore
#line 46 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml"
                       Write(Html.DisplayNameFor(model => model.CourseName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 49 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml"
                       Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 52 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml"
                       Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody id=\"myTableBody\">\r\n");
#nullable restore
#line 58 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 62 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CourseName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 65 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml"
                           Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 68 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml"
                           Write(Html.DisplayFor(modelItem => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d3a44ff1c0ed55fadc30ac8b4615e6893abe4cb8123", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml"
                                                                                   WriteLiteral(item.CourseId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Courses.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n\r\n\r\n            </table>\r\n\r\n            \r\n        </div>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Prometheus_MVC.Models.CourseViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
