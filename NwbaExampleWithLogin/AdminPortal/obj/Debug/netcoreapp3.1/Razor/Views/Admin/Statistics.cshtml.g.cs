#pragma checksum "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\AdminPortal\Views\Admin\Statistics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6edc76d80c473fdf9d42c66eb61e58937bbc51f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Statistics), @"mvc.1.0.view", @"/Views/Admin/Statistics.cshtml")]
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
#line 1 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\AdminPortal\Views\_ViewImports.cshtml"
using AdminPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\AdminPortal\Views\_ViewImports.cshtml"
using AdminPortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6edc76d80c473fdf9d42c66eb61e58937bbc51f1", @"/Views/Admin/Statistics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7762539535b843c42841939b460dcdaf13e7229b", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Statistics : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<List<SimpleReportViewModel>>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\AdminPortal\Views\Admin\Statistics.cshtml"
  
    var IncomeLabels = Newtonsoft.Json.JsonConvert.SerializeObject(Model[0].Select(x => x.DimensionOne).ToList());
    var IncomeValues = Newtonsoft.Json.JsonConvert.SerializeObject(Model[0].Select(x => x.Quantity).ToList());
    var OutLabels = Newtonsoft.Json.JsonConvert.SerializeObject(Model[1].Select(x => x.DimensionOne).ToList());
    var OutValues = Newtonsoft.Json.JsonConvert.SerializeObject(Model[1].Select(x => x.Quantity).ToList());
    var PieLabels = Newtonsoft.Json.JsonConvert.SerializeObject(Model[2].Select(x => x.DimensionOne).ToList());
    var PieValues = Newtonsoft.Json.JsonConvert.SerializeObject(Model[2].Select(x => x.Quantity).ToList());
    ViewData["Title"] = "Bar Chart";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6edc76d80c473fdf9d42c66eb61e58937bbc51f14226", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Bar</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6edc76d80c473fdf9d42c66eb61e58937bbc51f15283", async() => {
                WriteLiteral(@"
    <div class=""box-body"">
        <label for=""income"">Income Chart</label>
        <div class=""chart-container"">
            <canvas id=""income"" style=""width:100%; height:500px""></canvas>
        </div>
        <label for=""out"">spending Chart</label>
        <div class=""chart-container"">
            <canvas id=""out"" style=""width:100%; height:500px""></canvas>
        </div>
        <label for=""pie"">Transaction type Chart</label>
        <div class=""chart-container"">
            <canvas id=""pie"" style=""width:100%; height:500px""></canvas>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>

<script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.bundle.min.js""></script>
<script src=""https://code.jquery.com/jquery-3.3.1.min.js""></script>

<script type=""text/javascript"">

    $(function () {
        var chartName = ""income"";
        var ctx = document.getElementById(chartName).getContext('2d');
        var data = {
                labels: ");
#nullable restore
#line 46 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\AdminPortal\Views\Admin\Statistics.cshtml"
                   Write(Html.Raw(IncomeLabels));

#line default
#line hidden
#nullable disable
            WriteLiteral(@",
                datasets: [{
                    label: ""Income Chart"",
                    backgroundColor: [
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(54, 162, 235, 0.2)'

                    ],
                    borderColor: [
                        'rgba(54, 162, 235, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(54, 162, 235, 1)',
                      ");
            WriteLiteral(@"  'rgba(54, 162, 235, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(54, 162, 235, 1)'

                    ],
                    borderWidth: 1,
                    data: ");
#nullable restore
#line 80 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\AdminPortal\Views\Admin\Statistics.cshtml"
                     Write(Html.Raw(IncomeValues));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                }]
            };

var options = {
                maintainAspectRatio: false,
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0,
                            beginAtZero: true
                        },
                        gridLines: {
                            display: true,
                            color: ""rgba(255,99,164,0.2)""
                        }
}],
                    xAxes: [{
                        ticks: {
                            min: 0,
                            beginAtZero: true
                        },
                        gridLines: {
                            display: false
                        }
                    }]
                }
            };

       var myChart = new  Chart(ctx, {
                options: options,
                data: data,
                type:'bar'

            });
        });
</script>
<script type=""text/java");
            WriteLiteral("script\">\r\n\r\n    $(function () {\r\n        var chartName = \"out\";\r\n        var ctx = document.getElementById(chartName).getContext(\'2d\');\r\n        var data = {\r\n                labels: ");
#nullable restore
#line 123 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\AdminPortal\Views\Admin\Statistics.cshtml"
                   Write(Html.Raw(OutLabels));

#line default
#line hidden
#nullable disable
            WriteLiteral(@",
                datasets: [{
                    label: ""Spending Chart"",
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(255, 99, 132, 0.2)'

                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(255,99,132,1)',
                        'rgba(255,99,132,1)',
                        'rgba(255,99,132,1)',
                        'rgba(25");
            WriteLiteral(@"5,99,132,1)',
                        'rgba(255,99,132,1)',
                        'rgba(255,99,132,1)',
                        'rgba(255,99,132,1)',
                        'rgba(255,99,132,1)',
                        'rgba(255,99,132,1)',
                        'rgba(255,99,132,1)',
                        'rgba(255,99,132,1)'
                    ],
                    borderWidth: 1,
                    data: ");
#nullable restore
#line 156 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\AdminPortal\Views\Admin\Statistics.cshtml"
                     Write(Html.Raw(OutValues));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                }]
            };

var options = {
                maintainAspectRatio: false,
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0,
                            beginAtZero: true
                        },
                        gridLines: {
                            display: true,
                            color: ""rgba(255,99,164,0.2)""
                        }
}],
                    xAxes: [{
                        ticks: {
                            min: 0,
                            beginAtZero: true
                        },
                        gridLines: {
                            display: false
                        }
                    }]
                }
            };

       var myChart = new  Chart(ctx, {
                options: options,
                data: data,
                type:'bar'

            });
        });
</script>
<script type=""text/java");
            WriteLiteral("script\">\r\n\r\n        $(function () {\r\n    var chartName = \"pie\";\r\n        var ctx = document.getElementById(chartName).getContext(\'2d\');\r\n        var data = {\r\n                labels: ");
#nullable restore
#line 199 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\AdminPortal\Views\Admin\Statistics.cshtml"
                   Write(Html.Raw(PieLabels));

#line default
#line hidden
#nullable disable
            WriteLiteral(@",
                datasets: [{
                    label: ""Transaction Type Chart"",
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)',
                        'rgba(255, 0, 0)',
                        'rgba(0, 255, 0)',
                        'rgba(0, 0, 255)',
                        'rgba(192, 192, 192)',
                        'rgba(255, 255, 0)',
                        'rgba(255, 0, 255)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
     ");
            WriteLiteral(@"                   'rgba(255, 159, 64, 1)',
                        'rgba(255, 0, 0)',
                        'rgba(0, 255, 0)',
                        'rgba(0, 0, 255)',
                        'rgba(192, 192, 192)',
                        'rgba(255, 255, 0)',
                        'rgba(255, 0, 255)'
                    ],
                    borderWidth: 1,
                    data: ");
#nullable restore
#line 231 "C:\2020Summer\WDT\Assignments\A2\NwbaExampleWithLogin\AdminPortal\Views\Admin\Statistics.cshtml"
                     Write(Html.Raw(PieValues));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }]
            };

var options = {
                maintainAspectRatio: false,
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0,
                            beginAtZero: true
                        },
                        gridLines: {
                            display: true,
                            color: ""rgba(255,99,164,0.2)""
                        }
}],
                    xAxes: [{
                        ticks: {
                            min: 0,
                            beginAtZero: true
                        },
                        gridLines: {
                            display: false
                        }
                    }]
                }
            };

       var myChart = new  Chart(ctx, {
                options: options,
                data: data,
                type:'pie'

            });
        });
</script>  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<List<SimpleReportViewModel>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
