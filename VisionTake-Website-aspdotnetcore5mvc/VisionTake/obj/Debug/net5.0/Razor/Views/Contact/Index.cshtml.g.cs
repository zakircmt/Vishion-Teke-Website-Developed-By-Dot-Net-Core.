#pragma checksum "F:\Website Develop\VisionTake\VisionTake\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abdd3478fdd20b50e4516c1a8198a2daf2dbf618"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abdd3478fdd20b50e4516c1a8198a2daf2dbf618", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7650b73f47691663073f3af0a81928acbf20e0af", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VisionTake.Entities.TblAddress>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("php-email-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "F:\Website Develop\VisionTake\VisionTake\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- ======= Breadcrumbs ======= -->
<section id=""breadcrumbs"" class=""breadcrumbs"">
    <div class=""container"">

        <div class=""d-flex justify-content-between align-items-center"">
            <h2>Contact</h2>
            <ol>
                <li><a");
            BeginWriteAttribute("href", " href=\"", 402, "\"", 422, 1);
#nullable restore
#line 14 "F:\Website Develop\VisionTake\VisionTake\Views\Contact\Index.cshtml"
WriteAttributeValue("", 409, Url.Action(), 409, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Home</a></li>
                <li>Contact</li>
            </ol>
        </div>

    </div>
</section><!-- End Breadcrumbs -->
<!-- ======= Contact Section ======= -->
<div class=""map-section"">
    <iframe style=""border:0; width: 100%; height: 350px;"" src=""https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12097.433213460943!2d-74.0062269!3d40.7101282!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xb89d1fe6bc499443!2sDowntown+Conference+Center!5e0!3m2!1smk!2sbg!4v1539943755621"" frameborder=""0"" allowfullscreen></iframe>
</div>

    <section id=""contact"" class=""contact"">
        <div class=""container"">
");
#nullable restore
#line 28 "F:\Website Develop\VisionTake\VisionTake\Views\Contact\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""row justify-content-center"" data-aos=""fade-up"">

                    <div class=""col-lg-10"">

                        <div class=""info-wrap"">
                            <div class=""row"">

                                <div class=""col-lg-4 info"">
                                    <i class=""bi bi-geo-alt""></i>
                                    <h4>Location:</h4>
                                    <p>");
#nullable restore
#line 40 "F:\Website Develop\VisionTake\VisionTake\Views\Contact\Index.cshtml"
                                  Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </div>

                                <div class=""col-lg-4 info mt-4 mt-lg-0"">
                                    <i class=""bi bi-envelope""></i>
                                    <h4>Email:</h4>
                                    <p>");
#nullable restore
#line 46 "F:\Website Develop\VisionTake\VisionTake\Views\Contact\Index.cshtml"
                                  Write(item.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </div>

                                <div class=""col-lg-4 info mt-4 mt-lg-0"">
                                    <i class=""bi bi-phone""></i>
                                    <h4>Call:</h4>
                                    <p>");
#nullable restore
#line 52 "F:\Website Develop\VisionTake\VisionTake\Views\Contact\Index.cshtml"
                                  Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n\r\n\r\n                            </div>\r\n                        </div>\r\n\r\n                    </div>\r\n\r\n                </div>\r\n");
#nullable restore
#line 62 "F:\Website Develop\VisionTake\VisionTake\Views\Contact\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row mt-5 justify-content-center\" data-aos=\"fade-up\">\r\n                <div class=\"col-lg-10\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "abdd3478fdd20b50e4516c1a8198a2daf2dbf6188221", async() => {
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-md-6 form-group"">
                                <input type=""text"" name=""Name"" class=""form-control"" id=""name"" placeholder=""Your Name"" required>
                            </div>
                            <div class=""col-md-6 form-group mt-3 mt-md-0"">
                                <input type=""email"" class=""form-control"" name=""Email"" id=""email"" placeholder=""Your Email"" required>
                            </div>
                        </div>
                        <div class=""form-group mt-3"">
                            <input type=""text"" class=""form-control"" name=""MobileNo"" id=""subject"" placeholder=""MobileNo"" required>
                        </div>
                        <div class=""form-group mt-3"">
                            <textarea class=""form-control"" name=""Message"" rows=""5"" placeholder=""Message"" required></textarea>
                        </div>
                        <div class=""my-3"">");
                WriteLiteral(@"
                            <div class=""loading"">Loading</div>
                            <div class=""error-message""></div>
                            <div class=""sent-message"">Your message has been sent. Thank you!</div>
                        </div>
                        <div class=""text-center""><button type=""submit"">Send Message</button></div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 65 "F:\Website Develop\VisionTake\VisionTake\Views\Contact\Index.cshtml"
AddHtmlAttributeValue("", 2496, Url.Action("Create","TblContacts"), 2496, 35, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n    </section><!-- End Contact Section -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VisionTake.Entities.TblAddress>> Html { get; private set; }
    }
}
#pragma warning restore 1591
