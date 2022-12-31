#pragma checksum "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "093a1942b028d9d1da7003abda2b2ed60faef266"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Blog_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Blog/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"093a1942b028d9d1da7003abda2b2ed60faef266", @"/Areas/Admin/Views/Blog/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Dashboard";
    string error = TempData["error"] as string;
    string account = TempData["Account"] as string;
    int pageCount = (int)ViewBag.pageCount;
    int pageNumber = (int)ViewBag.pageNumber;
    int pageSize = (int)ViewBag.pageSize;
    int stt = pageSize * pageNumber - (pageSize - 1);
    string name = ViewBag.name;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content-header"">
    <h1>
        &nbsp;
    </h1>
    <ol class=""breadcrumb"">
        <li><a href=""#""><i class=""fa fa-dashboard""></i> Home</a></li>
        <li><a href=""#"">Blog</a></li>
        <li class=""active"">Tất cả bài viết</li>
    </ol>
</section>

<section class=""content"">
    <div class=""row"">
        <div class=""col-md-3"">
           <div class=""box box-solid"">
                <div class=""box-header with-border"">
                    <h3 class=""box-title"">Thư mục</h3>
                    <div class=""box-tools"">
                    <button type=""button"" class=""btn btn-box-tool"" data-widget=""collapse""><i class=""fa fa-minus""></i>
                    </button>
                    </div>
                </div>
                <div class=""box-body no-padding"">
                    <ul class=""nav nav-pills nav-stacked"" id=""blog-category"">
                       <li>
                            <div class=""input-group input-group-sm"" style=""padding: 1rem;"">
       ");
            WriteLiteral(@"                             <input type=""text"" class=""form-control"" id=""cblog-name"">
                                    <span class=""input-group-btn"">
                                        <button type=""button"" class=""btn btn-info btn-flat"" id=""add-folder"">Thêm</button>
                                    </span>
                                </div>
                        </li>
                    </ul>
                </div>
            <!-- /.box-body -->
            </div>
        </div>
       <div class=""col-md-9"">
          <div class=""box box-primary"">
            <div class=""box-header with-border"">
                <h3 class=""box-title"">Tất cả bài viết</h3>
                <div class=""box-tools pull-right"">
                    <div class=""has-feedback"">
                        <div class=""input-group input-group-sm"" style=""width: 150px;"">
                            <input type=""text"" name=""name"" class=""form-control pull-right"" id=""input-search"" placeholder=""Search""");
            BeginWriteAttribute("value", " value=\"", 2466, "\"", 2479, 1);
#nullable restore
#line 57 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 2474, name, 2474, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <div class=""input-group-btn"">
                                <a href=""###""><button class=""btn btn-default"" id=""form-search""><i class=""fa fa-search""></i></button></a>
                            </div>
                            <input type=""number"" name=""pageNumber"" id=""txtPageNumber"" value=""1"" hidden/>
                        </div>
                    </div>
                </div>
                <!-- /.box-tools -->
            </div>  
            <div class=""tab-content"" style=""margin: 1.5rem"">
");
#nullable restore
#line 68 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                      
                        foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"post\">\r\n                                <div class=\"user-block\">\r\n                                <img class=\"img-circle img-bordered-sm\"");
            BeginWriteAttribute("src", " src=\"", 3309, "\"", 3327, 1);
#nullable restore
#line 73 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3315, item.Avatar, 3315, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"user image\">\r\n                                    <span class=\"username\">\r\n");
#nullable restore
#line 75 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                                          
                                            if (item.Account == account || item.Account == "admin") 
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"mailbox-read-time pull-right\">\r\n                                                    <a");
            BeginWriteAttribute("href", " href=\"", 3749, "\"", 3791, 2);
            WriteAttributeValue("", 3756, "/Admin/Blog/AddOrUpdate?id=", 3756, 27, true);
#nullable restore
#line 79 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3783, item.Id, 3783, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""link-primary"">
                                                        <i class=""fa fa-edit""></i>&nbsp;Edit
                                                    </a>
                                                    |&nbsp;
                                                    <a");
            BeginWriteAttribute("href", " href=\"", 4083, "\"", 4120, 2);
            WriteAttributeValue("", 4090, "/Admin/Blog/Delete?id=", 4090, 22, true);
#nullable restore
#line 83 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 4112, item.Id, 4112, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                        <i class=\"fa fa-close\"></i>&nbsp;Delete \r\n                                                    </a>\r\n                                                </span>\r\n");
#nullable restore
#line 87 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                                            }
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a");
            BeginWriteAttribute("href", " href=\"", 4469, "\"", 4504, 2);
            WriteAttributeValue("", 4476, "/Admin/Blog/Post?id=", 4476, 20, true);
#nullable restore
#line 89 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 4496, item.Id, 4496, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 89 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                                                                          Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        <a href=\"#\" class=\"pull-right btn-box-tool\"></a>\r\n                                    </span>\r\n                                <span class=\"description\">Written by ");
#nullable restore
#line 92 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                                                                Write(item.AuthorName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Shared public - ");
#nullable restore
#line 92 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                                                                                                   Write(item.CreatedDate.ToString("MMM d, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                                <!-- /.user-block -->\r\n                                <p>\r\n                                    ");
#nullable restore
#line 96 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                               Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>                           \r\n                            </div>\r\n");
#nullable restore
#line 99 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"box-footer\">\r\n                <div class=\"box-footer clearfix\">\r\n                        <ul class=\"pagination pagination-sm no-margin pull-right\">\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 5377, "\"", 5450, 4);
            WriteAttributeValue("", 5384, "/Admin/Blog/Index?name=", 5384, 23, true);
#nullable restore
#line 105 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5407, name, 5407, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5412, "&&pageNumber=", 5412, 13, true);
#nullable restore
#line 105 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5425, Math.Max(pageNumber-1,1), 5425, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&laquo;</a></li>\r\n");
#nullable restore
#line 106 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                             for (int i = 1; i <= pageCount; ++i)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a");
            BeginWriteAttribute("href", " href=\"", 5606, "\"", 5656, 4);
            WriteAttributeValue("", 5613, "/Admin/Blog/Index?name=", 5613, 23, true);
#nullable restore
#line 108 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5636, name, 5636, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5641, "&&pageNumber=", 5641, 13, true);
#nullable restore
#line 108 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5654, i, 5654, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 108 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                                                                                     Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 109 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li><a");
            BeginWriteAttribute("href", " href=\"", 5736, "\"", 5817, 4);
            WriteAttributeValue("", 5743, "/Admin/Blog/Index?name=", 5743, 23, true);
#nullable restore
#line 110 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5766, name, 5766, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5771, "&&pageNumber=", 5771, 13, true);
#nullable restore
#line 110 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5784, Math.Min(pageNumber+1,pageCount), 5784, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&raquo;</a></li>\r\n                        </ul>\r\n                    </div>\r\n            </div>\r\n          </div>\r\n          <!-- /. box -->\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $.ajax({
            url: ""/Blog/GetCategoryBlog"",
            type: ""GET"",
            dataType: ""json"",
            beforeSend: function(){},
            success: function(data){
                data.forEach(function (item,index){
                    let row = `<li><a href=""/Admin/Blog/Index?arg=${item.id}""><i class=""fa fa-folder-o""></i>${item.name}</a></li>`;
                    $('#blog-category').prepend(row);
                });
            },
            error: function(){},
            complete: function(){}
        });

        $('#form-search').on('click', function(){
            let link = ""/Admin/Blog/Index?name="" + $('#input-search').val();
            $(""a[href='###']"").attr('href', link);
            $('#form-search')[0].click();
        });

        $('#add-folder').click(function(){
            console.log(1);
            $.ajax({
                url: ""/Admin/Blog/AddCategoryBlog?name="" + $('#cblog-name').val(),
                type: ""GET"",
  ");
                WriteLiteral(@"              dataType: ""json"",
                beforeSend: function(){},
                success: function(data){
                    location.reload();
                },
                error: function(){},
                complete: function(){}
            });
        })
    </script>
");
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
