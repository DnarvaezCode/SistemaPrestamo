#pragma checksum "C:\Users\Dnarvaez\source\repos\SistemaPrestamos\SistemaPrestamos\Views\Comisione\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4134e777a30d2f8a5d90a1fbef9e09b1b2e6a642"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Comisione_Index), @"mvc.1.0.view", @"/Views/Comisione/Index.cshtml")]
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
#line 1 "C:\Users\Dnarvaez\source\repos\SistemaPrestamos\SistemaPrestamos\Views\_ViewImports.cshtml"
using SistemaPrestamos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dnarvaez\source\repos\SistemaPrestamos\SistemaPrestamos\Views\_ViewImports.cshtml"
using SistemaPrestamos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4134e777a30d2f8a5d90a1fbef9e09b1b2e6a642", @"/Views/Comisione/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21a8dc00bc975a63080e0c7883eff91522a60813", @"/Views/_ViewImports.cshtml")]
    public class Views_Comisione_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SistemaPrestamos.Models.DTOs.PrestamoDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger pull-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Mantenimientos/Prestamo.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Dnarvaez\source\repos\SistemaPrestamos\SistemaPrestamos\Views\Comisione\Index.cshtml"
  
    ViewData["Title"] = "Listar";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card"" style=""margin-top:30px"">
    <div class=""card-header bg-dark text-light ml-0 row container"">
        <div class=""col-md-6"">
            <i class=""fa fa-money""></i>&nbsp;Comisiones
        </div>
    </div>
    <div class=""card-body"">
        <div class=""mt-4"">
            <div class=""form-row"">
                <div class=""form-group col-md-6"">
                    <label for=""inputEmail4"">Nombre del Socio</label>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4134e777a30d2f8a5d90a1fbef9e09b1b2e6a6426131", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 17 "C:\Users\Dnarvaez\source\repos\SistemaPrestamos\SistemaPrestamos\Views\Comisione\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Nombre);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group col-md-6\">\r\n                    <label for=\"inputState\">Nº de Préstamos</label>\r\n                    ");
#nullable restore
#line 21 "C:\Users\Dnarvaez\source\repos\SistemaPrestamos\SistemaPrestamos\Views\Comisione\Index.cshtml"
               Write(Html.DropDownList("ComboboxPrestamo", new SelectList(Model.Prestamos, "Id", "Codigo"), "-- Seleccione un número de préstamo--", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    <span class=""text-danger""></span>
                </div>
            </div>
            <div class=""form-row"">
                <div class=""form-group col-md-6"">
                    <label>Monto del Préstamo</label>
                    <input type=""text"" class=""form-control"" id=""txtMontoPrestamo"" readonly>
                </div>
                <div class=""form-group col-md-6"">
                    <label>Estado de la Comisión</label>
                    <input type=""text"" class=""form-control"" id=""txtEstadoComision"" readonly>
                </div>
            </div>
            <div class=""form-row"">
                <div class=""form-group col-md-6"">
                    <label>% Préstamo</label>
                    <input type=""text"" class=""form-control"" id=""txtPorcentaje""
                           onkeypress=""if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;""
                           onchange=""ValidateInput(this)""
                           onb");
            WriteLiteral(@"lur=""ValidateInput(this)"">
                    <span class=""text-danger""></span>
                </div>
                <div class=""form-group col-md-6"">
                    <label>Comisión</label>
                    <input type=""text"" class=""form-control"" id=""txtComision"" readonly>
                </div>
            </div>
            <button type=""button"" class=""btn btn-info pull-right"" id=""btnAgregar"">Agregar</button>
        </div>
        <div class=""mt-5"">
            <table class=""table table-bordered"">
                <thead>
                    <tr>
                        <th>Nº Préstamo</th>
                        <th>Monto del Prestamo</th>
                        <th>% Préstamo</th>
                        <th>Comisión</th>
                        <th>Opciones</th>
                    </tr>
                </thead>
                <tbody id=""comisiones"">
                </tbody>
            </table>
        </div>
        <div class=""btn-group pull-right"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4134e777a30d2f8a5d90a1fbef9e09b1b2e6a64210883", async() => {
                WriteLiteral("Cancelar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("&nbsp;\r\n            <button class=\"btn btn-primary pull-right\">Guardar</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4134e777a30d2f8a5d90a1fbef9e09b1b2e6a64212557", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SistemaPrestamos.Models.DTOs.PrestamoDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
