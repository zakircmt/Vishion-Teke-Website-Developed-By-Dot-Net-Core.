#pragma checksum "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b36612847c62cadd68125e9e63543860b19f207"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Detail), @"mvc.1.0.view", @"/Views/Product/Detail.cshtml")]
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
#line 1 "F:\Website Develop\VisionTake\VisionTake\Views\_ViewImports.cshtml"
using VisionTake;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Website Develop\VisionTake\VisionTake\Views\_ViewImports.cshtml"
using VisionTake.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b36612847c62cadd68125e9e63543860b19f207", @"/Views/Product/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7650b73f47691663073f3af0a81928acbf20e0af", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VisionTake.Entities.TblProduct>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- ======= Breadcrumbs ======= -->
<section id=""breadcrumbs"" class=""breadcrumbs"">
    <div class=""container"">

        <div class=""d-flex justify-content-between align-items-center"">
            <h2>Products</h2>
            <ol>
                <li><a");
            BeginWriteAttribute("href", " href=\"", 391, "\"", 425, 1);
#nullable restore
#line 14 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
WriteAttributeValue("", 398, Url.Action("Index","Home"), 398, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Home</a></li>\r\n                <li><a");
            BeginWriteAttribute("href", " href=\"", 464, "\"", 501, 1);
#nullable restore
#line 15 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
WriteAttributeValue("", 471, Url.Action("Index","Product"), 471, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Products</a></li>
                <li>Details</li>
            </ol>
        </div>

    </div>
</section><!-- End Breadcrumbs -->
<!-- ======= Blog Single Section ======= -->
<section id=""blog"" class=""blog"">
    <div class=""container"" data-aos=""fade-up"">

        <div class=""row"">

            <div class=""col-lg-8 entries"">

                <article class=""entry entry-single"">

                    <div class=""entry-img"">
                        <img");
            BeginWriteAttribute("src", " src=\"", 975, "\"", 1023, 1);
#nullable restore
#line 33 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
WriteAttributeValue("", 981, Url.Content("~/Images/" + Model.ImageUrl), 981, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1024, "\"", 1030, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\">\r\n                    </div>\r\n\r\n                    <h2 class=\"entry-title\">\r\n                        <a href=\"#\">Product Name : ");
#nullable restore
#line 37 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
                                              Write(Model.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </h2>\r\n                    <h3 class=\"entry-title\">\r\n                        <a href=\"#\">Model : ");
#nullable restore
#line 40 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
                                       Write(Model.ProductModel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </h3>\r\n                    <div class=\"entry-meta\">\r\n                        <ul>\r\n                            <li class=\"d-flex align-items-center\"><i class=\"bi bi-person\"></i> <a");
            BeginWriteAttribute("href", " href=\"", 1545, "\"", 1579, 1);
#nullable restore
#line 44 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
WriteAttributeValue("", 1552, Url.Action("Index","Home"), 1552, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Vision Teke</a></li>\r\n                            <li class=\"d-flex align-items-center\"><i class=\"bi bi-clock\"></i> <a");
            BeginWriteAttribute("href", " href=\"", 1699, "\"", 1733, 1);
#nullable restore
#line 45 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
WriteAttributeValue("", 1706, Url.Action("Index","Home"), 1706, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><time datetime=\"2020-01-01\">");
#nullable restore
#line 45 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
                                                                                                                                                           Write(Model.TimeStamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</time></a></li>\r\n                        </ul>\r\n                    </div>\r\n\r\n                    <div class=\"entry-content\">\r\n                        <p>\r\n                            ");
#nullable restore
#line 51 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
                       Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </p>
                    </div>

                    <div class=""entry-footer"">
                        <i class=""bi bi-folder""></i>
                        <ul class=""cats"">
                            <li><a href=""#"">3D Printing</a></li>
                        </ul>

                        <i class=""bi bi-tags""></i>
                        <ul class=""tags"">
                            <li><a href=""#"">Brest Surgery</a></li>
                            <li><a href=""#"">Cardiothoracic Surgery</a></li>
                            <li><a href=""#"">Gynecological Department</a></li>
                        </ul>
                    </div>

                </article><!-- End blog entry -->

                <div class=""blog-comments"">

                    <div class=""reply-form"">
                        <h4>Request For Quote</h4>
                        <p>Enter Your Valid Information for Later Connecting</p>
                        <p style=""color:red"">");
#nullable restore
#line 76 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
                                        Write(ViewBag.message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b36612847c62cadd68125e9e63543860b19f2079778", async() => {
                WriteLiteral(@"
                            <div class=""row"">
                                <div class=""col-md-6 form-group"">
                                    <input name=""name"" type=""text"" class=""form-control"" placeholder=""Your Name*"">
                                </div>
                                <div class=""col-md-6 form-group"">
                                    <input name=""Email"" type=""text"" class=""form-control"" placeholder=""Your Email*"">
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col form-group"">
                                    <input name=""MobileNo"" type=""text"" class=""form-control"" placeholder=""Mobile Number"">
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col form-group"">
                                    <textarea name=""Message"" class=""form-cont");
                WriteLiteral("rol\" placeholder=\"Your Message*\"></textarea>\r\n                                </div>\r\n                            </div>\r\n                            <button type=\"submit\" class=\"btn btn-primary\">Post Comment</button>\r\n\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 77 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
AddHtmlAttributeValue("", 3063, Url.Action("Create","TblContacts"), 3063, 35, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                    </div>

                </div><!-- End blog comments -->

            </div><!-- End blog entries list -->

            <div class=""col-lg-4"">

                <div class=""sidebar"">

                    <h3 class=""sidebar-title"">Related Product</h3>
                    <div class=""sidebar-item recent-posts"">
");
#nullable restore
#line 112 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
                         foreach (var item in ViewBag.product)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"post-item clearfix\">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 4925, "\"", 4972, 1);
#nullable restore
#line 115 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
WriteAttributeValue("", 4931, Url.Content("~/Images/" + item.ImageUrl), 4931, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 4973, "\"", 4979, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <h4><a");
            BeginWriteAttribute("href", " href=\"", 5021, "\"", 5077, 1);
#nullable restore
#line 116 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
WriteAttributeValue("", 5028, Url.Action("Detail","Product",new { ID=item.ID}), 5028, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 116 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
                                                                                           Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h4>\r\n                                <time datetime=\"2020-01-01\">Jan 1, 2020</time>\r\n                            </div>\r\n");
#nullable restore
#line 119 "F:\Website Develop\VisionTake\VisionTake\Views\Product\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div><!-- End sidebar recent posts-->\r\n\r\n                </div><!-- End sidebar -->\r\n\r\n            </div><!-- End blog sidebar -->\r\n\r\n        </div>\r\n\r\n    </div>\r\n</section><!-- End Blog Single Section -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VisionTake.Entities.TblProduct> Html { get; private set; }
    }
}
#pragma warning restore 1591
