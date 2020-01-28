using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NwbaExample.Data;
using NwbaExample.Models;

namespace NwbaExample.Utilities
{
    public class BillExicuter
    {
        private readonly NwbaContext _context;
        public BillExicuter(IServiceProvider serviceProvider)
        {
            _context = new NwbaContext(serviceProvider.GetRequiredService<DbContextOptions<NwbaContext>>());
        }
        public void ExicuteBill()
        {
            foreach (Bill bill in _context.Bills)
            {
                if (bill.Status == BillStatus.Active && bill.ScheduleDate.Date == DateTime.Today)
                {
                    bill.Exicute();
                    
                }
            }
            _context.SaveChanges();
        }
    }
}
