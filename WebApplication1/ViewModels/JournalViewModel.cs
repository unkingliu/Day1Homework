using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class JournalViewModel
    {
        [Display(Name = "金額")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Amount { get; set; }
        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }
        [Display(Name = "備註")]
        public String Remark { get; set; }
        [Display(Name = "類別")]
        public JournalType jType { get; set; }
    }

    public enum JournalType { 收入,支出 }
}