#pragma checksum "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b20454a3f01868a3651845184b40b1f193c61e4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_User_ListUser), @"mvc.1.0.view", @"/Areas/Admin/Views/User/ListUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b20454a3f01868a3651845184b40b1f193c61e4a", @"/Areas/Admin/Views/User/ListUser.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_User_ListUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "User";

    int pageCount = (int)ViewBag.pageCount;
    int pageNumber = (int)ViewBag.pageNumber;
    int pageSize = (int)ViewBag.pageSize;
    int stt = pageSize * pageNumber - (pageSize - 1);
    string name = ViewBag.name;
    string role = ViewBag.role;

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
    <li class=""active"">Người dùng</li>
</ol>
</section>

<!-- Main content -->
<section class=""content"">
    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box"">
                <div class=""box-header"">
                <h3 class=""box-title"">Danh sách sản phẩm</h3>
                <div class=""btn-group"">
                  <button type=""button"" class=""btn btn-info"">Lọc theo</button>
                  <button type=""button"" class=""btn btn-info dropdown-toggle"" data-toggle=""dropdown"">
                    <span class=""caret""></span>
                    <span class=""sr-only"">Toggle Dropdown</span>
                  </button>
                  <ul class=""dropdown-menu"" role=""menu"">
                    <li><a href=""/Admin/User/ListUser?role=admin"">Admin</a></li>
                    <li><a href=""/Admin/User/ListUser?role=st");
            WriteLiteral(@"aff"">Nhân viên</a></li>
                    <li><a href=""/Admin/User/ListUser?role=collaborator"">Cộng tác viên</a></li>
                    <li><a href=""/Admin/User/ListUser?role=customer"">Khách hàng</a></li>
                  </ul>
                </div>
                <div class=""box-tools"">
                    <div class=""input-group input-group-sm"" style=""width: 150px;"">
                        <input type=""text"" name=""name"" class=""form-control pull-right"" id=""input-search"" placeholder=""Search""");
            BeginWriteAttribute("value", " value=\"", 1892, "\"", 1905, 1);
#nullable restore
#line 45 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 1900, name, 1900, 5, false);

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
                <!-- /.box-header -->
                <div class=""box-body table-responsive no-padding"">
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                               <th>STT</th>
                               <th>Ảnh đại diện</th>
                               <th>Họ và tên</th>
                               <th>Chức vụ</th>
                               <th>Thao tác</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 65 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
                              
                                foreach (var item in Model)
                                {    
                                     var r = item.Role[0].ToString().ToUpper() + item.Role.Substring(1);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                     <tr>\r\n                                        <td>");
#nullable restore
#line 70 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
                                       Write(stt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td><img");
            BeginWriteAttribute("src", " src=\"", 3248, "\"", 3270, 1);
#nullable restore
#line 71 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 3254, item.AvatarPath, 3254, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:128px; height:128px\"></td>\r\n                                        <td>");
#nullable restore
#line 72 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
                                       Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 72 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
                                                       Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 73 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
                                       Write(r);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3539, "\"", 3594, 2);
            WriteAttributeValue("", 3546, "/Admin/Account/UserProfile?account=", 3546, 35, true);
#nullable restore
#line 75 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 3581, item.Account, 3581, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-default btn-warning"" style=""color: white"">Chi tiết</a>
                                            <a href=""/Admin/Account/Delete"" class=""btn btn-default btn-danger"" style=""color: white"">Xóa</a>
                                        </td>
                                    </tr>
");
#nullable restore
#line 79 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
                                    stt++;
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
                <!-- /.box-body -->
                <div class=""box-footer clearfix"">
                    <ul class=""pagination pagination-sm no-margin pull-right"">
                        <li><a");
            BeginWriteAttribute("href", " href=\"", 4294, "\"", 4382, 6);
            WriteAttributeValue("", 4301, "/Admin/User/ListUser?name=", 4301, 26, true);
#nullable restore
#line 88 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 4327, name, 4327, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4332, "&&role=", 4332, 7, true);
#nullable restore
#line 88 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 4339, role, 4339, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4344, "&&pageNumber=", 4344, 13, true);
#nullable restore
#line 88 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 4357, Math.Max(pageNumber-1,1), 4357, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&laquo;</a></li>\r\n");
#nullable restore
#line 89 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
                         for (int i = 1; i <= pageCount; ++i)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li><a");
            BeginWriteAttribute("href", " href=\"", 4526, "\"", 4591, 6);
            WriteAttributeValue("", 4533, "/Admin/User/ListUser?name=", 4533, 26, true);
#nullable restore
#line 91 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 4559, name, 4559, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4564, "&&role=", 4564, 7, true);
#nullable restore
#line 91 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 4571, role, 4571, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4576, "&&pageNumber=", 4576, 13, true);
#nullable restore
#line 91 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 4589, i, 4589, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 91 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
                                                                                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 92 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li><a");
            BeginWriteAttribute("href", " href=\"", 4663, "\"", 4759, 6);
            WriteAttributeValue("", 4670, "/Admin/User/ListUser?name=", 4670, 26, true);
#nullable restore
#line 93 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 4696, name, 4696, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4701, "&&role=", 4701, 7, true);
#nullable restore
#line 93 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 4708, role, 4708, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4713, "&&pageNumber=", 4713, 13, true);
#nullable restore
#line 93 "F:\Backend Devmaster\AppManager\AppManager\Areas\Admin\Views\User\ListUser.cshtml"
WriteAttributeValue("", 4726, Math.Min(pageNumber+1,pageCount), 4726, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&raquo;</a></li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        <!-- /.box -->\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $('#form-search').on('click', function(){
            const urlParams = new URLSearchParams(window.location.search);
            const role = urlParams.get('role');
            const pageNumber = urlParams.get('pageNumber');
            let link = ""/Admin/User/ListUser?name="" + $('#input-search').val() + ""&&role="" + role + ""&&pageNumber="" + pageNumber;
            $(""a[href='###']"").attr('href', link);
            $('#form-search')[0].click();
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