#pragma checksum "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\Cadastro\ExcluirRegistroEmpresa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f35f6467c8d6b12c9aedf79b6225df361ecf79d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cadastro_ExcluirRegistroEmpresa), @"mvc.1.0.view", @"/Views/Cadastro/ExcluirRegistroEmpresa.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cadastro/ExcluirRegistroEmpresa.cshtml", typeof(AspNetCore.Views_Cadastro_ExcluirRegistroEmpresa))]
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
#line 1 "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\_ViewImports.cshtml"
using BOVINE_WEIGHT;

#line default
#line hidden
#line 2 "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\_ViewImports.cshtml"
using BOVINE_WEIGHT.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f35f6467c8d6b12c9aedf79b6225df361ecf79d", @"/Views/Cadastro/ExcluirRegistroEmpresa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67e344d6a3b1af09bc0d95163bd07c10782a689b", @"/Views/_ViewImports.cshtml")]
    public class Views_Cadastro_ExcluirRegistroEmpresa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 314, true);
            WriteLiteral(@"
    <style>
        body {
            background-color: #81080A;
        }
    </style>

    <div class=""container"" style=""background-color:rgba(239,239,239,0.95); border-radius:25px; padding:15px;width:400px;"">

        <h3>Deseja Excluir a Empresa Selecionada?</h3>
        <p><strong>Data:</strong> ");
            EndContext();
            BeginContext(315, 32, false);
#line 11 "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\Cadastro\ExcluirRegistroEmpresa.cshtml"
                             Write(ViewBag.Registro.Data.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(347, 40, true);
            WriteLiteral("</p>\r\n        <p><strong>CNPJ:</strong> ");
            EndContext();
            BeginContext(388, 35, false);
#line 12 "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\Cadastro\ExcluirRegistroEmpresa.cshtml"
                             Write(ViewBag.Registro.CpfCnpj.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(423, 43, true);
            WriteLiteral("</p>\r\n        <p><strong>Empresa:</strong> ");
            EndContext();
            BeginContext(467, 37, false);
#line 13 "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\Cadastro\ExcluirRegistroEmpresa.cshtml"
                                Write(ViewBag.Registro.Descricao.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(504, 44, true);
            WriteLiteral("</p>\r\n        <p><strong>Endereco:</strong> ");
            EndContext();
            BeginContext(549, 36, false);
#line 14 "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\Cadastro\ExcluirRegistroEmpresa.cshtml"
                                 Write(ViewBag.Registro.Endereco.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(585, 42, true);
            WriteLiteral("</p>\r\n        <p><strong>Cidade:</strong> ");
            EndContext();
            BeginContext(628, 34, false);
#line 15 "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\Cadastro\ExcluirRegistroEmpresa.cshtml"
                               Write(ViewBag.Registro.Cidade.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(662, 38, true);
            WriteLiteral("</p>\r\n        <p><strong>Uf:</strong> ");
            EndContext();
            BeginContext(701, 30, false);
#line 16 "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\Cadastro\ExcluirRegistroEmpresa.cshtml"
                           Write(ViewBag.Registro.Uf.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(731, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 17 "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\Cadastro\ExcluirRegistroEmpresa.cshtml"
          
            var vId = 0;

            try
            {
                vId = int.Parse(ViewBag.Registro.Id.ToString());
            }
            catch { }
        

#line default
#line hidden
            BeginContext(924, 446, true);
            WriteLiteral(@"        <div class=""container"" style=""background-color:rgba(239,239,239,0.95); border-radius:10px; padding:20px;width:350px;"">
            <table class=""table table-bordered"">
                <tbody>
                    <tr>
                        <td style=""width:50px""><button type=""button"" onclick=""Cancelar()"" class=""btn btn-block btn-default"">Cancelar</button></td>
                        <td style=""width:50px""> <button type=""button""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1370, "\"", 1393, 3);
            WriteAttributeValue("", 1380, "Excluir(", 1380, 8, true);
#line 31 "E:\Projetos\RAEC_ASPNETCORE\BOVINE_WEIGHT\BOVINE_WEIGHT\Views\Cadastro\ExcluirRegistroEmpresa.cshtml"
WriteAttributeValue("", 1388, vId, 1388, 4, false);

#line default
#line hidden
            WriteAttributeValue("", 1392, ")", 1392, 1, true);
            EndWriteAttribute();
            BeginContext(1394, 152, true);
            WriteLiteral(" class=\"btn btn-block btn-danger\">Excluir</button></td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n\r\n\r\n");
            EndContext();
            BeginContext(1911, 250, true);
            WriteLiteral("    </div>\r\n    <script>\r\n        function Excluir(id) {\r\n            window.location.href = \"../ExcluirEmpresa/\" + id;\r\n\r\n        }\r\n        function Cancelar() {\r\n            window.location.href = \"../IndexEmpresa\";\r\n        }\r\n\r\n    </script>\r\n\r\n");
            EndContext();
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
