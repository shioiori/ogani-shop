#pragma checksum "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e85d79efaf90bb16fdc8b306d35d94da36300220"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingCart_Index), @"mvc.1.0.view", @"/Views/ShoppingCart/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e85d79efaf90bb16fdc8b306d35d94da36300220", @"/Views/ShoppingCart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39bdf4e2eeb9182a14600fe5d339bdb2f9540938", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ShoppingCart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
  
    dynamic total = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""breadcrumb-section set-bg"" data-setbg=""/img/breadcrumb.jpg"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12 text-center"">
                <div class=""breadcrumb__text"">
                    <h2>Shopping Cart</h2>
                    <div class=""breadcrumb__option"">
                        <a href=""/Home/Index"">Home</a>
                        <span>Shopping Cart</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Breadcrumb Section End -->
<!-- Shoping Cart Section Begin -->
<section class=""shoping-cart spad"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""shoping__cart__table"">
                    <table id=""cart-table"">
                        <thead>
                            <tr>
                                <th class=""shoping__product"">Products</th>
                                <");
            WriteLiteral(@"th>Price</th>
                                <th>Quantity</th>
                                <th>Total</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 38 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
                              
                                foreach(var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr");
            BeginWriteAttribute("id", " id=\"", 1480, "\"", 1493, 1);
#nullable restore
#line 41 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
WriteAttributeValue("", 1485, item.Id, 1485, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 1494, "\"", 1511, 1);
#nullable restore
#line 41 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
WriteAttributeValue("", 1501, item.Name, 1501, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <td class=\"shoping__cart__item\">\r\n                                            <img");
            BeginWriteAttribute("src", " src=\"", 1637, "\"", 1655, 1);
#nullable restore
#line 43 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
WriteAttributeValue("", 1643, item.Avatar, 1643, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100px\"");
            BeginWriteAttribute("alt", " alt=\"", 1670, "\"", 1676, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <h5>");
#nullable restore
#line 44 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                        </td>\r\n                                        <td class=\"shoping__cart__price\">\r\n                                            $");
#nullable restore
#line 47 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
                                        Write(item.Price.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </td>
                                        <td class=""shoping__cart__quantity"">
                                            <div class=""quantity"">
                                                <div class=""pro-qty"">
                                                    <input type=""text"" min=""1"" class=""product-quantity""");
            BeginWriteAttribute("value", " value=\"", 2309, "\"", 2331, 1);
#nullable restore
#line 52 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
WriteAttributeValue("", 2317, item.Quantity, 2317, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                </div>
                                            </div>
                                        </td>
                                        <td class=""shoping__cart__total"">
                                            $");
#nullable restore
#line 57 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
                                         Write((item.Price * item.Quantity).ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td class=\"shoping__cart__item__close\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 2834, "\"", 2884, 2);
            WriteAttributeValue("", 2841, "/ShoppingCart/RemoveProduct?id=", 2841, 31, true);
#nullable restore
#line 60 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
WriteAttributeValue("", 2872, item.CartId, 2872, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span id=\"icon-close\" class=\"icon_close\"></span></a>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 63 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
                                    total += item.Price * item.Quantity;
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""shoping__cart__btns"">
                    <a href=""#"" class=""primary-btn cart-btn"">CONTINUE SHOPPING</a>
                    <a href=""#"" class=""primary-btn cart-btn cart-btn-right"">
                        <span class=""icon_loading""></span>
                        Upadate Cart
                    </a>
                </div>
            </div>
            <div class=""col-lg-6"">
                <div class=""shoping__continue"">
                    <div class=""shoping__discount"">
                        <h5>Discount Codes</h5>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e85d79efaf90bb16fdc8b306d35d94da3630022010776", async() => {
                WriteLiteral("\r\n                            <input type=\"text\" placeholder=\"Enter your coupon code\">\r\n                            <button type=\"submit\" class=\"site-btn\">APPLY COUPON</button>\r\n                        ");
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
                </div>
            </div>
            <div class=""col-lg-6"">
                <div class=""shoping__checkout"">
                    <h5>Cart Total</h5>
                    <ul>
                        <li>Subtotal <span id=""subtotal"">$");
#nullable restore
#line 96 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
                                                     Write(total.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                        <li>Total <span id=\"total\">$");
#nullable restore
#line 97 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
                                               Write(total.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></li>
                    </ul>
                    <a href=""/CheckOut/CheckOut"" class=""primary-btn"">PROCEED TO CHECKOUT</a>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Shoping Cart Section End -->

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>

        function UpdateQuantity(id, quantity){
            console.log(quantity);
            $.ajax({
                url: ""/ShoppingCart/AddItemToCart?id="" + id + ""&&quantity="" + quantity,
                type: ""GET"",
                dataType: ""json"",
                beforeSend: function(){},
                success: function(data){
                    console.log(""ok"");
                },
                error: function(){},
                complete: function(){}
            });
        }

        var listItem = JSON.parse('");
#nullable restore
#line 125 "F:\Backend Devmaster\AppManager\AppManager\Views\ShoppingCart\Index.cshtml"
                              Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');
        console.log(listItem);

        $('.dec').on('click', function(e){
            let qtt = parseInt($(this).closest('tr').find('.product-quantity').val());
            let id = $(this).closest('tr').attr('id');
            var item = listItem.find(x => x.id == id);
            UpdateQuantity(id, (qtt - 1) - item.quantity);
            item.quantity = qtt - 1;
            let price = $(this).closest('tr').find('.shoping__cart__price').html().replace(/\s/g,'').replace('$', '');
            prdprice = price * (qtt - 1);
            $(this).closest('tr').find('.shoping__cart__total').html('$' + parseFloat(prdprice).toFixed(2));
            let total = $('#total').html().replace(/\s/g,'').replace('$', '');
            $('#subtotal').html('$' + parseFloat(total - price).toFixed(2));
            $('#total').html('$' + parseFloat(total - price).toFixed(2));
        });

        $('.inc').on('click', function(e){
            let qtt = parseInt($(this).closest('tr').find('.product-quantity')");
                WriteLiteral(@".val());
            let id = $(this).closest('tr').attr('id');
            var item = listItem.find(x => x.id == id);
            UpdateQuantity(id, (qtt + 1) - item.quantity);
            item.quantity = qtt + 1;
            let price = $(this).closest('tr').find('.shoping__cart__price').html().replace(/\s/g,'').replace('$', '');
            prdprice = price * (qtt + 1);
            $(this).closest('tr').find('.shoping__cart__total').html('$' + parseFloat(prdprice).toFixed(2));
            let total = $('#total').html().replace(/\s/g,'').replace('$', '');
            $('#subtotal').html('$' + parseFloat(parseFloat(total) + parseFloat(price)).toFixed(2));
            $('#total').html('$' + parseFloat(parseFloat(total) + parseFloat(price)).toFixed(2));
        });
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
