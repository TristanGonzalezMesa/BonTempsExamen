#pragma checksum "D:\XAMPP\htdocs\Labs\BonTempsExamen\BonTempsBeta\BonTemps\Views\Reserveringen\Components\MenuReserveringen\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c66c9199e3ecad6d291ea946769c295e786258c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reserveringen_Components_MenuReserveringen_Default), @"mvc.1.0.view", @"/Views/Reserveringen/Components/MenuReserveringen/Default.cshtml")]
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
#line 1 "D:\XAMPP\htdocs\Labs\BonTempsExamen\BonTempsBeta\BonTemps\Views\_ViewImports.cshtml"
using BonTemps;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\XAMPP\htdocs\Labs\BonTempsExamen\BonTempsBeta\BonTemps\Views\_ViewImports.cshtml"
using BonTemps.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c66c9199e3ecad6d291ea946769c295e786258c", @"/Views/Reserveringen/Components/MenuReserveringen/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e35921926b862f81a32059a3c3aa187d8e9ebf4a", @"/Views/_ViewImports.cshtml")]
    public class Views_Reserveringen_Components_MenuReserveringen_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BonTemps.Models.ReserveringMenu>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h4>Menus</h4>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 8 "D:\XAMPP\htdocs\Labs\BonTempsExamen\BonTempsBeta\BonTemps\Views\Reserveringen\Components\MenuReserveringen\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.Menu.Naam));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 11 "D:\XAMPP\htdocs\Labs\BonTempsExamen\BonTempsBeta\BonTemps\Views\Reserveringen\Components\MenuReserveringen\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.Menu.Prijs));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 17 "D:\XAMPP\htdocs\Labs\BonTempsExamen\BonTempsBeta\BonTemps\Views\Reserveringen\Components\MenuReserveringen\Default.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 21 "D:\XAMPP\htdocs\Labs\BonTempsExamen\BonTempsBeta\BonTemps\Views\Reserveringen\Components\MenuReserveringen\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.Menu.Naam));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 24 "D:\XAMPP\htdocs\Labs\BonTempsExamen\BonTempsBeta\BonTemps\Views\Reserveringen\Components\MenuReserveringen\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.Menu.Prijs));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 27 "D:\XAMPP\htdocs\Labs\BonTempsExamen\BonTempsBeta\BonTemps\Views\Reserveringen\Components\MenuReserveringen\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BonTemps.Models.ReserveringMenu>> Html { get; private set; }
    }
}
#pragma warning restore 1591
