#pragma checksum "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88e7aa401fa830e620a41aa8822554eff684a6ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Resena_CrearResena), @"mvc.1.0.view", @"/Views/Resena/CrearResena.cshtml")]
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
#line 1 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml"
using Dominio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88e7aa401fa830e620a41aa8822554eff684a6ae", @"/Views/Resena/CrearResena.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1680e4c2dae9db882b1a5517ba32251d62911bd7", @"/Views/_ViewImports.cshtml")]
    public class Views_Resena_CrearResena : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12\">\r\n            <h1>Crear Reseña</h1>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-12\">\r\n");
#nullable restore
#line 12 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml"
             if (ViewBag.mensaje != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-warning\">\r\n                    <div>\r\n                        ");
#nullable restore
#line 16 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml"
                   Write(ViewBag.Mensaje);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 19 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88e7aa401fa830e620a41aa8822554eff684a6ae5845", async() => {
                WriteLiteral(@"
                <div class=""form-group"">
                    <label for=""txtTitulo"">Título</label>
                    <input id=""txtTitulo"" class=""form-control"" name=""titulo"" type=""text"" placeholder=""Partido emocionante"" required />
                </div>
                <div class=""form-group"">
                    <label for=""txtContenido"">Contenido</label>
                    <textarea id=""txtContenido"" class=""form-control"" name=""contenido"" rows=""10"" cols=""50"" placeholder=""Descripción del partido"" required></textarea>
                </div>
                <div class=""form-group"">
                    <label for=""txtPartido"">Partido</label>
                    <select id=""txtPartido"" name=""partidoId"" class=""form-control"" required>
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88e7aa401fa830e620a41aa8822554eff684a6ae6920", async() => {
                    WriteLiteral("Seleccione un partido");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 33 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml"
                         foreach (Partido p in Administradora.Instance.Partidos)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88e7aa401fa830e620a41aa8822554eff684a6ae8502", async() => {
#nullable restore
#line 35 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml"
                                             Write(p.TituloToString());

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml"
                               WriteLiteral(p.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 36 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </select>\r\n                </div>\r\n                <input type=\"hidden\" name=\"periodistaId\"");
                BeginWriteAttribute("value", " value=\"", 1701, "\"", 1741, 1);
#nullable restore
#line 39 "C:\Users\Fabricio Barrios\source\repos\Obligatorio1\webApp\Views\Resena\CrearResena.cshtml"
WriteAttributeValue("", 1709, Context.Session.GetString("Id"), 1709, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <button type=\"submit\" class=\"btn btn-primary\">Crear</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591