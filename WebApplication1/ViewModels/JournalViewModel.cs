using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Filters;

namespace WebApplication1.ViewModels
{
    public class JournalViewModel
    {
        [Display(Name = "金額")]
        [Required(ErrorMessage = "必須輸入{0}")]
        [Range(1, int.MaxValue, ErrorMessage = "只能輸入正整數")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Amount { get; set; }
        [Display(Name = "日期")]
        [Required(ErrorMessage = "必須輸入{0}")]
        [DayRange(-1 * Int16.MaxValue, 0, ErrorMessage = "不得大於今天,或日期太早")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }
        [Display(Name = "備註")]
        [Required(ErrorMessage = "必須輸入{0}")]
        public String Remark { get; set; }
        [Required(ErrorMessage = "必須選擇收入/支出")]
        [Display(Name = "類別")]
        public JournalType jType { get; set; }
    }

    public enum JournalType { 收入, 支出 }
}