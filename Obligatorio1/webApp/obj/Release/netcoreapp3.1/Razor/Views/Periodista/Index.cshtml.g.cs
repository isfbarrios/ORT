#pragma checksum "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Periodista\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b01ca4bb60791faf94e32b95a50fde581b0f0171"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Periodista_Index), @"mvc.1.0.view", @"/Views/Periodista/Index.cshtml")]
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
#line 1 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\_ViewImports.cshtml"
using webApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\_ViewImports.cshtml"
using webApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Periodista\Index.cshtml"
using Dominio;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b01ca4bb60791faf94e32b95a50fde581b0f0171", @"/Views/Periodista/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1680e4c2dae9db882b1a5517ba32251d62911bd7", @"/Views/_ViewImports.cshtml")]
    public class Views_Periodista_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Periodista>>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-12"">
            <h1>Periodistas</h1>
        </div>
        <div class=""col-12 col-sm-12"">
            <div class=""container-fluid my-3"">
                <div class=""row"">
                    <div class=""col-12 col-sm-12"">
                        <h4>Opciones de filtrado</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-12 col-sm-12"">
            <table class=""table table-striped table-hover"">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Mail</th>
                        <th>Reseñas</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 32 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Periodista\Index.cshtml"
                     foreach (Periodista p in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 35 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Periodista\Index.cshtml"
                           Write(p.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 36 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Periodista\Index.cshtml"
                           Write(p.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 37 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Periodista\Index.cshtml"
                           Write(p.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 38 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Periodista\Index.cshtml"
                           Write(p.Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b01ca4bb60791faf94e32b95a50fde581b0f01715777", async() => {
                WriteLiteral("Ver");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1331, "~/Resena/MostrarResenas/", 1331, 24, true);
#nullable restore
#line 40 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Periodista\Index.cshtml"
AddHtmlAttributeValue("", 1355, p.Id, 1355, 5, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 43 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Periodista\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Periodista>> Html { get; private set; }
    }
}
#pragma warning restore 1591
