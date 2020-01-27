#pragma checksum "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbdab1b3a3641e294f341d0b9ce8abe0bced061a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Statement), @"mvc.1.0.view", @"/Views/Customer/Statement.cshtml")]
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
#line 1 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\_ViewImports.cshtml"
using NwbaExample;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\_ViewImports.cshtml"
using NwbaExample.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\_ViewImports.cshtml"
using NwbaExample.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbdab1b3a3641e294f341d0b9ce8abe0bced061a", @"/Views/Customer/Statement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b6a23a9ad7f0da21988488ab669df301eaaf802", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Statement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StatementViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Statement", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
  
    ViewData["Title"] = "My Statement";
    decimal netWorth = 0;

    foreach (Account account in Model.Customer.Accounts)
        netWorth += account.Balance;
    Account displayAccount = Model.Customer.Accounts.Find(x => x.AccountNumber == Model.AccountOption);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>My Statement</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbdab1b3a3641e294f341d0b9ce8abe0bced061a6668", async() => {
                WriteLiteral("\r\n    <div class=\"form-group\">\r\n");
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbdab1b3a3641e294f341d0b9ce8abe0bced061a7003", async() => {
                    WriteLiteral("\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbdab1b3a3641e294f341d0b9ce8abe0bced061a7283", async() => {
                        WriteLiteral("Select an Account");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    BeginWriteTagHelperAttribute();
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
             foreach (Account account in Model.Customer.Accounts)
            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbdab1b3a3641e294f341d0b9ce8abe0bced061a9241", async() => {
#nullable restore
#line 20 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                                                  Write(account.AccountType.ToString());

#line default
#line hidden
#nullable disable
                        WriteLiteral(" Balence: ");
#nullable restore
#line 20 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                                                                                           Write(account.Balance);

#line default
#line hidden
#nullable disable
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                   WriteLiteral(account.AccountNumber);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 21 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
            }

#line default
#line hidden
#nullable disable
                    WriteLiteral("        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 16 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.AccountOption);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbdab1b3a3641e294f341d0b9ce8abe0bced061a13267", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 23 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.AccountOption);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Display\" class=\"btn btn-primary btn-block\" />\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 27 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
 if (Model.AccountOption != 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>My ");
#nullable restore
#line 29 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
      Write(displayAccount.AccountType.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" Account No.");
#nullable restore
#line 29 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                                                        Write(displayAccount.AccountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Balance: A$");
#nullable restore
#line 29 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                                                                                                 Write(displayAccount.Balance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 34 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
               Write(Html.DisplayNameFor(model => displayAccount.Transactions[0].TransactionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 37 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
               Write(Html.DisplayNameFor(model => displayAccount.Transactions[0].AccountNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 40 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
               Write(Html.DisplayNameFor(model => displayAccount.Transactions[0].DestinationAccountNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 43 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
               Write(Html.DisplayNameFor(model => displayAccount.Transactions[0].Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 46 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
               Write(Html.DisplayNameFor(model => displayAccount.Transactions[0].Comment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 49 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
               Write(Html.DisplayNameFor(model => displayAccount.Transactions[0].TransactionTimeUtc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 55 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
             foreach (var item in Model.Page)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TransactionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                   Write(Html.DisplayFor(modelItem => item.AccountNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DestinationAccountNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 71 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Comment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 74 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
                   Write(DateTime.SpecifyKind(item.TransactionTimeUtc, DateTimeKind.Utc).ToLocalTime());

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 77 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 80 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
Write(Html.PagedListPager(Model.Page, page => Url.Action("Statement", new { page, AccountOption = Model.AccountOption }),
            new PagedListRenderOptions
            {
                LiElementClasses = new[] { "page-item" },
                PageClasses = new[] { "page-link" }
            }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\r\n");
#nullable restore
#line 87 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div>\r\n    <h4>My Details</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 95 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 98 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayFor(model => model.Customer.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 101 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer.Tfn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 104 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayFor(model => model.Customer.Tfn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 107 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 110 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayFor(model => model.Customer.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 113 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 116 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayFor(model => model.Customer.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 119 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 122 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayFor(model => model.Customer.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 125 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer.PostCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 128 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayFor(model => model.Customer.PostCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 131 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayNameFor(model => model.Customer.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 134 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
       Write(Html.DisplayFor(model => model.Customer.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Net Worth:\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            A$");
#nullable restore
#line 140 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\NwbaExampleWithLogin\Views\Customer\Statement.cshtml"
         Write(netWorth.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StatementViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
