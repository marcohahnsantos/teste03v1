#pragma checksum "E:\Util\TESTEA03\TESTEA03\Views\Movimento\Alerta.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f99d50d60f3d36d779573a596484d200dc9cf3a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movimento_Alerta), @"mvc.1.0.view", @"/Views/Movimento/Alerta.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Movimento/Alerta.cshtml", typeof(AspNetCore.Views_Movimento_Alerta))]
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
#line 1 "E:\Util\TESTEA03\TESTEA03\Views\_ViewImports.cshtml"
using TESTEAO3;

#line default
#line hidden
#line 2 "E:\Util\TESTEA03\TESTEA03\Views\_ViewImports.cshtml"
using TESTEAO3.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f99d50d60f3d36d779573a596484d200dc9cf3a6", @"/Views/Movimento/Alerta.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdc010d52917bb55178337061a2349a78c333e64", @"/Views/_ViewImports.cshtml")]
    public class Views_Movimento_Alerta : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 714, true);
            WriteLiteral(@"
<style>
    body {
        background-color: #ffffff;
        ;
    }
</style>

<div class=""container"" style=""background-color:rgba(239,239,239,0.95); border-radius:25px; padding:15px;width:600px;"">

    <h3>Não é Possivel Cadastrar o Veiculo -- Já esta locado </h3>
   
    <div class=""container"" style=""background-color:rgba(239,239,239,0.95); border-radius:10px; padding:20px;width:350px;"">
        <table class=""table table-bordered"">
            <tbody>
                <tr>
                    <td style=""width:50px""><button type=""button"" onclick=""Cancelar()"" class=""btn btn-block btn-default"">OK</button></td>
                </tr>
            </tbody>
        </table>
    </div>


");
            EndContext();
            BeginContext(1075, 133, true);
            WriteLiteral("</div>\r\n<script>\r\n   \r\n    function Cancelar() {\r\n        window.location.href = \"../Movimento/IndexMovimento\";\r\n    }\r\n\r\n</script>\r\n");
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
