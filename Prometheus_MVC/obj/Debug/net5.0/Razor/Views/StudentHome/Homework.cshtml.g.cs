#pragma checksum "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5a77bc267b711680ab6587c2dbeb104005333cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StudentHome_Homework), @"mvc.1.0.view", @"/Views/StudentHome/Homework.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5a77bc267b711680ab6587c2dbeb104005333cc", @"/Views/StudentHome/Homework.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41773d27ae46f50430498d8e08f72ccd7636eb97", @"/Views/_ViewImports.cshtml")]
    public class Views_StudentHome_Homework : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Prometheus_MVC.Models.HomeworkViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Homework", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
 if (ViewBag.Status == "Error")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script>
        window.setTimeout(function () {
            window.location.href = 'https://localhost:44344/StudentHome';
        }, 2000);
    </script>
    <center><h1 style=""color:red"">Some error occured please contact a staff member <br /> Redirecting to Student portal...... </h1></center>
");
#nullable restore
#line 15 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    input::-webkit-outer-spin-button,
    input::-webkit-inner-spin-button {
        -webkit-appearance: none;
        margin: 0;
    }

    a {
        color: aliceblue;
        text-decoration: none;
    }

        a:hover {
            color: aqua;
            text-decoration: none;
        }

   

    .tile {
        width: 1050px;
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

    .btn {
        width: 50%;
        background: none;
        border: 2px solid #DC6180;
        color: #DC6180;
        padding: 5px;
        font-size: 18px;
        cursor: pointer;
        margin");
            WriteLiteral(@": 0px 10px;
        position: relative;
        text-transform: uppercase;
        box-shadow: 0px 0px 8px 0px #000;
        transition: all 0.5s ease-in-out;
        border-radius: 5px;
    }

        .btn:hover {
            color: #fff;
            background-color: #DC6180;
            box-shadow: 0px 0px 0px #000;
        }
</style>
<h1>HomeWorks</h1>
<div onclick=""location.href='https://localhost:44344/StudentHome'"">
    <h4 style=""cursor:pointer;color:gold""><i class=""fas fa-chevron-circle-left""></i> Back</h4>
</div>
<div class=""tile"">
    <br />
    <br />
    <div class=""table-responsive"" style=""overflow-x: hidden;"">

        <table id=""myTable"" class=""table-borderless"" width=""100%"" style=""color:white;margin-left:15px;"">
            <thead>
                <tr>
                    <th>
                        ");
#nullable restore
#line 86 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                   Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 89 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                   Write(Html.DisplayNameFor(model => model.Deadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 92 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                   Write(Html.DisplayNameFor(model => model.ReqTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 95 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                   Write(Html.DisplayNameFor(model => model.LongDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        Priority\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 104 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                  int x = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 105 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 109 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 112 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Deadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 115 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ReqTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 118 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                       Write(Html.DisplayFor(modelItem => item.LongDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 121 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                       Write(x);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5a77bc267b711680ab6587c2dbeb104005333cc10910", async() => {
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
#line 125 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                                                                                WriteLiteral(item.HomeWorkId);

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
            WriteLiteral("\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 128 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
                    x+= 1;
                    
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <br />\r\n    <h5>");
#nullable restore
#line 135 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\StudentHome\Homework.cshtml"
   Write(ViewBag.Plan);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n    <br />\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Prometheus_MVC.Models.HomeworkViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
