#pragma checksum "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad6aeb36a0711624916176ead94f340ee258a4b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(VoorraadSysteem.Views.Store.Views_Store_Details), @"mvc.1.0.view", @"/Views/Store/Details.cshtml")]
namespace VoorraadSysteem.Views.Store
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
#line 1 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\_ViewImports.cshtml"
using VoorraadSysteem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\_ViewImports.cshtml"
using VoorraadSysteem.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad6aeb36a0711624916176ead94f340ee258a4b2", @"/Views/Store/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99cf85fdb8c91cbcab37d9c9eaef549e945da7b4", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Store_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VoorraadSysteem.ViewModels.StoreDetailsViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
  
	ViewData["title"] = "Winkel details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" tickets</h1>\r\n\r\n<table>\r\n\t<thead>\r\n\t\t<tr>\r\n\t\t\t<th class=\"col-md-4\">\r\n\t\t\t\t");
#nullable restore
#line 13 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Tickets.First().User.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t</th>\r\n\t\t\t<th class=\"col-md-4\">\r\n\t\t\t\t");
#nullable restore
#line 16 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Tickets.First().PurchaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t</th>\r\n\t\t\t<th class=\"col-md-4\">\r\n\t\t\t\t");
#nullable restore
#line 19 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Tickets.First().Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t</th>\r\n\t\t</tr>\r\n\t</thead>\r\n\t<tbody>\r\n");
#nullable restore
#line 24 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
         foreach (var ticket in Model.Tickets)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<tr>\r\n\t\t\t\t<td class=\"col-md-4\">\r\n\t\t\t\t\t");
#nullable restore
#line 28 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
               Write(ticket.User.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td class=\"col-md-4\">\r\n\t\t\t\t\t");
#nullable restore
#line 31 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
               Write(ticket.PurchaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\r\n\t\t\t\t</td>\r\n\t\t\t\t<td class=\"col-md-4\">\r\n\t\t\t\t\t");
#nullable restore
#line 34 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
               Write(ticket.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n");
            WriteLiteral("\t\t\t</tr>\r\n");
#nullable restore
#line 40 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\r\n</table>\r\n\r\n");
#nullable restore
#line 44 "C:\Users\gamingpc\Downloads\VoorraadSysteem\VoorraadSysteem\Views\Store\Details.cshtml"
Write(Html.ActionLink("Terug", "Index", "Store"));

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VoorraadSysteem.ViewModels.StoreDetailsViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
