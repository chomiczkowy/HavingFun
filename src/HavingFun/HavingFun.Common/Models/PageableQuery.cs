﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Models
{
    public class PageableQuery: SortableQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
