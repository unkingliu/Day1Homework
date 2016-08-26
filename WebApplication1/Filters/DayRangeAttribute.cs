using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Filters
{
    public sealed class DayRangeAttribute : ValidationAttribute, IClientValidatable
    {
        private int minimumDays;
        private int maximumDays;

        /// <summary>
        /// 日期範圍驗證<para>只驗證日期，不考慮時間</para>
        /// copy from http://demo.tc/post/689
        ///</summary>
        /// <param name="minimumDays">最小日期</param>
        /// <param name="maximumDays">最大日期</param>
        public DayRangeAttribute(int minimumDays, int maximumDays)
        {
            //日期範圍基本的輸入參數驗證
            if (minimumDays.CompareTo(maximumDays) > -1)
            {
                throw new Exception("範圍設定錯誤，最小日期不得大於等於最大日期");
            }

            this.minimumDays = minimumDays;
            this.maximumDays = maximumDays;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var compareDate = value as DateTime?;
            if (compareDate.HasValue)
            {
                compareDate = compareDate.Value.Date;
                return compareDate.Value >= DateTime.Today.AddDays(minimumDays).Date && compareDate.Value <= DateTime.Today.AddDays(maximumDays).Date;
            }
            return false;
        }

        public IEnumerable<ModelClientValidationRule>
        GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "dayrange",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            rule.ValidationParameters["min"] = minimumDays;
            rule.ValidationParameters["max"] = maximumDays;
            yield return rule;
        }
    }
}