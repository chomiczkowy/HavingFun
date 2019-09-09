using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Models
{
    public class PageableQueryResult<TItem>
    {
        public IEnumerable<TItem> Items { get; set; }
        public int AllItemsCount { get; set; }
    }
}
