#pragma checksum "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65962bb869f40ce3652695bbc105ef40e0e1c9c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CourseViewModels_Details), @"mvc.1.0.view", @"/Views/CourseViewModels/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65962bb869f40ce3652695bbc105ef40e0e1c9c1", @"/Views/CourseViewModels/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41773d27ae46f50430498d8e08f72ccd7636eb97", @"/Views/_ViewImports.cshtml")]
    public class Views_CourseViewModels_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Prometheus_MVC.Models.CourseViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .wrap {
        align-self: center;
        margin: 50px auto 0 auto;
        width: 100%;
        display: flex;
        align-content: center;
        align-items: center;
        justify-content: space-evenly;
        max-width: 1500px;
    }

    .tile {
        width: 500px;
        height: 380px;
        margin: 10px;
        background-color: #99aeff;
        background-image: linear-gradient(to bottom right,#0F2027, #2C5364);
        display: inline-block;
        background-size: cover;
        position: relative;
        cursor: pointer;
        transition: all 0.4s ease-out;
        padding-left: 10px;
        padding-top: 5px;
        box-shadow: 0px 35px 77px -17px rgba(0,0,0,0.44);
        overflow: hidden;
        color: white;
        font-family: 'Roboto';
    }

        .tile:hover {
            /*   background-color:#99aeff; */
            box-shadow: 0px 35px 77px -17px rgba(0,0,0,0.64);
            transform: scale(1.05);
        }

       ");
            WriteLiteral(@"     .tile:hover img {
                opacity: 0.2;
            }

    table th, table td {
        text-align: center;
    }

    th {
        background-color: #203A43;
        color: #fff;
    }

    table tr:nth-child(even) {
        background-color: #3b6473;
        color: #fff;
    }

    table tr:nth-child(odd) {
        background-color: #fff;
        color: #203A43;
    }
</style>
<h1>Course Details</h1>

<div class=""wrap"">
    <div class=""tile"">
        <h4>Course Details for ID: ");
#nullable restore
#line 71 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                              Write(Model.CourseId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <hr />\r\n        <dl class=\"row\">\r\n            <dt class=\"col-sm-2\">\r\n                Name\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 78 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
           Write(Html.DisplayFor(model => model.CourseName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 81 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 84 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
           Write(Html.DisplayFor(model => model.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 87 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 90 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
           Write(Html.DisplayFor(model => model.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 93 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 96 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                   string value;

#line default
#line hidden
#nullable disable
#nullable restore
#line 97 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                 if (Convert.ToBoolean(Model.Status)) { value = "Active"; }
                else { value = "Inactive"; }

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
#nullable restore
#line 99 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
           Write(value);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n    <div>\r\n        <div>\r\n");
#nullable restore
#line 105 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
             if (Model.Homework.Count() <= 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 style=\"color: white; background-color: #203A43\">No homeworks in this course</h6>\r\n");
#nullable restore
#line 108 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
            }
            else
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 style=\"color: white; background-color: #203A43\"> Homeworks in this course</h6>\r\n");
            WriteLiteral(@"                <table class=""table-hover"" width=""225px"">
                    <thead>
                        <tr>
                            <th>
                                HW Given
                            </th>
                            <th>Given By</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 124 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                         foreach (var item in Model.Homework)
                        {
                            string location = "https://localhost:44344/Homework/Details/" + Convert.ToInt32(item.HomeWorkId).ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr style=\"cursor: pointer;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3775, "\"", 3810, 3);
            WriteAttributeValue("", 3785, "location.href=\'", 3785, 15, true);
#nullable restore
#line 127 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
WriteAttributeValue("", 3800, location, 3800, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3809, "\'", 3809, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <td>\r\n                                    ");
#nullable restore
#line 129 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                               Write(Convert.ToInt32(item.HomeWorkId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 132 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 135 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 138 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <br />\r\n        <div>\r\n");
#nullable restore
#line 142 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
             if (Model.Teacher.Count() <= 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 style=\"color: white; background-color: #203A43\">No Teachers Assigned to this course</h6>\r\n");
#nullable restore
#line 145 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 style=\"color: white; background-color: #203A43\"> Teachers teaching this course</h6>\r\n");
            WriteLiteral(@"                <table class=""table-hover"" width=""225px"">
                    <thead>
                        <tr>
                            <th>
                                Teacher ID
                            </th>
                            <th>
                                Name
                            </th>
");
            WriteLiteral("                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 163 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                         foreach (var item in Model.Teacher)
                        {
                            string location = "https://localhost:44344/Teacher/Details/" + Convert.ToInt32(item.TeacherId).ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr style=\"cursor: pointer;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5382, "\"", 5417, 3);
            WriteAttributeValue("", 5392, "location.href=\'", 5392, 15, true);
#nullable restore
#line 166 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
WriteAttributeValue("", 5407, location, 5407, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5416, "\'", 5416, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <td>\r\n                                    ");
#nullable restore
#line 168 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                               Write(Convert.ToInt32(item.TeacherId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 171 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                               Write(item.Fname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 171 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                                           Write(item.Lname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 174 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 177 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n        <br />\r\n        <div>\r\n\r\n");
#nullable restore
#line 183 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
             if (Model.Student.Count() <= 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 style=\"color: white; background-color: #203A43\">No student has enrolled yet</h6>\r\n");
#nullable restore
#line 186 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <h6 style=""color: white; background-color: #203A43""> Students Enrolled to this course</h6>
                <br />
                <table class=""table-hover"" width=""225px"">
                    <thead>
                        <tr>
                            <th>
                                Student ID
                            </th>
                            <th>
                                Name
                            </th>
");
            WriteLiteral("                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 204 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                         foreach (var item in Model.Student)
                        {
                            string location = "https://localhost:44344/Student/Details/" + Convert.ToInt32(item.StudentId).ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr style=\"cursor: pointer;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6985, "\"", 7020, 3);
            WriteAttributeValue("", 6995, "location.href=\'", 6995, 15, true);
#nullable restore
#line 207 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
WriteAttributeValue("", 7010, location, 7010, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7019, "\'", 7019, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <td>\r\n                                    ");
#nullable restore
#line 209 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                               Write(Convert.ToInt32(item.StudentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 212 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                               Write(item.Fname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 212 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                                           Write(item.Lname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 215 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 218 "C:\Users\Navpreet Singh\Source\Repos\Prometheus 2.0\Prometheus_MVC\Views\CourseViewModels\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n<div>\r\n    <a href=\"javascript:history.back()\">Go Back </a>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Prometheus_MVC.Models.CourseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
