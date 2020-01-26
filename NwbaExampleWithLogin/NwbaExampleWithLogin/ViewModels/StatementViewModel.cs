using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NwbaExample.Models;
using System.ComponentModel.DataAnnotations;
using X.PagedList;
using X.PagedList.Mvc.Core;
using X.PagedList.Mvc.Core.Common;



namespace NwbaExample.ViewModels
{
    public class StatementViewModel
    {
        public Customer Customer { get; set; }
        public int AccountOption { get; set; }
        public IPagedList<Transaction> Page { get; set; }
    }
}
