#pragma checksum "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fde621bfde900008ed9445d17e91480ab2f0e3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Index), @"mvc.1.0.view", @"/Views/Blog/Index.cshtml")]
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
#line 1 "F:\Backend Devmaster\AppManager\AppManager\Views\_ViewImports.cshtml"
using AppManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Backend Devmaster\AppManager\AppManager\Views\_ViewImports.cshtml"
using AppManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fde621bfde900008ed9445d17e91480ab2f0e3d", @"/Views/Blog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39bdf4e2eeb9182a14600fe5d339bdb2f9540938", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
  
    ViewData["Title"] = "Blog";
    int pageCount = (int)ViewBag.pageCount;
    int pageNumber = (int)ViewBag.pageNumber;
    int pageSize = (int)ViewBag.pageSize;
    int stt = pageSize * pageNumber - (pageSize - 1);
    var arg = ViewBag.arg;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""breadcrumb-section set-bg"" data-setbg=""/img/breadcrumb.jpg"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12 text-center"">
                <div class=""breadcrumb__text"">
                    <h2>Blog</h2>
                    <div class=""breadcrumb__option"">
                        <a href=""/Home/Index"">Home</a>
                        <span>Blog</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Breadcrumb Section End -->

<!-- Blog Section Begin -->
<section class=""blog spad"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-4 col-md-5"">
                <div class=""blog__sidebar"">
                    <div class=""blog__sidebar__search"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fde621bfde900008ed9445d17e91480ab2f0e3d4846", async() => {
                WriteLiteral("\r\n                            <input type=\"text\" placeholder=\"Search...\">\r\n                            <button type=\"submit\"><span class=\"icon_search\"></span></button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    <div class=""blog__sidebar__item"">
                        <h4>Categories</h4>
                        <ul id=""blog-category"">
                            <li><a href=""#"">All</a></li>
                            <li><a href=""#"">Beauty (20)</a></li>
                            <li><a href=""#"">Food (5)</a></li>
                            <li><a href=""#"">Life Style (9)</a></li>
                            <li><a href=""#"">Travel (10)</a></li>
                        </ul>
                    </div>
                    <div class=""blog__sidebar__item"">
                        <h4>Recent News</h4>
                        <div class=""blog__sidebar__recent"" id=""recent-news"">
                            <a href=""#"" class=""blog__sidebar__recent__item"">
                                <div class=""blog__sidebar__recent__item__pic"">
                                    <img src=""img/blog/sidebar/sr-1.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 2297, "\"", 2303, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                </div>
                                <div class=""blog__sidebar__recent__item__text"">
                                    <h6>09 Kinds Of Vegetables<br /> Protect The Liver</h6>
                                    <span>MAR 05, 2019</span>
                                </div>
                            </a>
                            <a href=""#"" class=""blog__sidebar__recent__item"">
                                <div class=""blog__sidebar__recent__item__pic"">
                                    <img src=""img/blog/sidebar/sr-2.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 2888, "\"", 2894, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                </div>
                                <div class=""blog__sidebar__recent__item__text"">
                                    <h6>Tips You To Balance<br /> Nutrition Meal Day</h6>
                                    <span>MAR 05, 2019</span>
                                </div>
                            </a>
                            <a href=""#"" class=""blog__sidebar__recent__item"">
                                <div class=""blog__sidebar__recent__item__pic"">
                                    <img src=""img/blog/sidebar/sr-3.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 3477, "\"", 3483, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                </div>
                                <div class=""blog__sidebar__recent__item__text"">
                                    <h6>4 Principles Help You Lose <br />Weight With Vegetables</h6>
                                    <span>MAR 05, 2019</span>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class=""blog__sidebar__item"">
                        <h4>Search By</h4>
                        <div class=""blog__sidebar__item__tags"" id=""tags"">
                            <a href=""#"">Apple</a>
                            <a href=""#"">Beauty</a>
                            <a href=""#"">Vegetables</a>
                            <a href=""#"">Fruit</a>
                            <a href=""#"">Healthy Food</a>
                            <a href=""#"">Lifestyle</a>
                        </div>
                    </div>
                </div>
            </div>
");
            WriteLiteral("            <div class=\"col-lg-8 col-md-7\">\r\n                <div class=\"row\">\r\n");
#nullable restore
#line 96 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
                      
                        foreach(var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                             <div class=\"col-lg-6 col-md-6 col-sm-6\">\r\n                                <div class=\"blog__item\">\r\n                                    <div class=\"blog__item__pic\">\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 4931, "\"", 4961, 1);
#nullable restore
#line 102 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
WriteAttributeValue("", 4937, item.PostAvatarFilePath, 4937, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 4962, "\"", 4968, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 360px; height: 260px"">
                                    </div>
                                    <div class=""blog__item__text"">
                                        <ul>
                                            <li><i class=""fa fa-calendar-o""></i> ");
#nullable restore
#line 106 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
                                                                            Write(item.CreatedDate.ToString("MMM d, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                            <li><i class=\"fa fa-comment-o\"></i> 5</li>\r\n                                        </ul>\r\n                                        <h5><a");
            BeginWriteAttribute("href", " href=\"", 5476, "\"", 5511, 2);
            WriteAttributeValue("", 5483, "/BlogDetail/Post?id=", 5483, 20, true);
#nullable restore
#line 109 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5503, item.Id, 5503, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 109 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
                                                                              Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h5>\r\n                                        <p>");
#nullable restore
#line 110 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
                                      Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 5643, "\"", 5678, 2);
            WriteAttributeValue("", 5650, "/BlogDetail/Post?id=", 5650, 20, true);
#nullable restore
#line 111 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5670, item.Id, 5670, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"blog__btn\">READ MORE <span class=\"arrow_right\"></span></a>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 115 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-lg-12\">\r\n                        <div class=\"product__pagination\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 6051, "\"", 6116, 4);
            WriteAttributeValue("", 6058, "/Blog/Index?arg=", 6058, 16, true);
#nullable restore
#line 119 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
WriteAttributeValue("", 6074, arg, 6074, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6078, "&&pageNumber=", 6078, 13, true);
#nullable restore
#line 119 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
WriteAttributeValue("", 6091, Math.Max(pageNumber-1,1), 6091, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-long-arrow-left\"></i></a>\r\n");
#nullable restore
#line 120 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
                              
                                for (int i = 1; i <= pageCount; ++i)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 6336, "\"", 6378, 4);
            WriteAttributeValue("", 6343, "/Blog/Index?arg=", 6343, 16, true);
#nullable restore
#line 123 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
WriteAttributeValue("", 6359, arg, 6359, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6363, "&&pageNumber=", 6363, 13, true);
#nullable restore
#line 123 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
WriteAttributeValue("", 6376, i, 6376, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 123 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
                                                                             Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 124 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 6484, "\"", 6557, 4);
            WriteAttributeValue("", 6491, "/Blog/Index?arg=", 6491, 16, true);
#nullable restore
#line 126 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
WriteAttributeValue("", 6507, arg, 6507, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6511, "&&pageNumber=", 6511, 13, true);
#nullable restore
#line 126 "F:\Backend Devmaster\AppManager\AppManager\Views\Blog\Index.cshtml"
WriteAttributeValue("", 6524, Math.Min(pageNumber+1,pageCount), 6524, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-long-arrow-right\"></i></a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- Blog Section End -->\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        // category của blog
        $.ajax({
            url: ""/Blog/GetCategoryBlog"",
            type: ""GET"",
            dataType: ""json"",
            beforeSend: function(){},
            success: function(data){
                $('#blog-category').html('');
                $('#blog-category').append('<li><a href=""/Blog/Index"">All</a></li>');
                data.forEach(function (item,index){
                    let row = `<li><a href=""/Blog/Index?arg=${item.id}"">${item.name} (${item.postQuantity})</a></li>`;
                    $('#blog-category').append(row);
                })
                console.log( $('#blog-category').html())
            },
            error: function(){},
            complete: function(){}
        });

        // tin tức mới nhất
        $.ajax({
            url: ""/Blog/GetRecentNews"",
            type: ""GET"",
            dataType: ""json"",
            beforeSend: function(){},
            success: function(data){
                $('#r");
                WriteLiteral(@"ecent-news').html('');
                data.forEach(function (item,index){
                    var words = item.title.split("" "");
                    var a = """", b = """";
                    for (let i = 0; i < parseInt((words.length+1)/2); ++i){
                        a += words[i].charAt(0).toUpperCase() + words[i].substring(1) + "" "";
                    }
                    for (let i = parseInt((words.length+1)/2); i < words.length; ++i){
                        b += words[i].charAt(0).toUpperCase() + words[i].substring(1) + "" "";
                    }
                    let date = new Intl.DateTimeFormat('en-GB', { dateStyle: 'full'}).format(new Date(Date.parse(item.createdDate)));
                    let row = `<a href=""/BlogDetail/Post?id=${item.id}"" class=""blog__sidebar__recent__item"">
                                    <div class=""blog__sidebar__recent__item__pic"">
                                        <img src=""${item.postAvatarFilePath}"" style=""width:70px; height:70px;"" alt="""">
  ");
                WriteLiteral(@"                                  </div>
                                    <div class=""blog__sidebar__recent__item__text"">
                                        <h6>${a}<br /> ${b}</h6>
                                        <span>${date}</span>
                                    </div>
                                </a>`;
                    $('#recent-news').append(row);
                });
            },
            error: function(){},
            complete: function(){}
        });

        // tags
        $.ajax({
            url: ""/Blog/GetAllTags"",
            type: ""GET"",
            dataType: ""json"",
            beforeSend: function(){},
            success: function(data){
                $('#tags').html('');
                data.forEach(function (item,index){
                    let row = `<a href=""/Blog/Index?arg=${item.slug}"">${item.name}</a>`;
                    $('#tags').append(row);
                })
            },
            error: function(){},
        ");
                WriteLiteral("    complete: function(){}\r\n        });\r\n\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
