﻿using Money.Models.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Pages
{
    /// <summary>
    /// An enumeration of supported sorting of summary items.
    /// </summary>
    public enum SummarySortType
    {
        /// <summary>
        /// Sort items by amount.
        /// </summary>
        [DisplayName("By Amount")]
        [DefaultValue(SortDirection.Descending)]
        ByAmount,

        /// <summary>
        /// Sort items by category name.
        /// </summary>
        [DisplayName("By Category")]
        ByCategory
    }
}
