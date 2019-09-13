using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.Common.Models
{
    public class Command<T>
    {
        public Command(T data)
        {
            this.Data = data;
        }

        public T Data { get; private set; }
        public int ExecutingUserId { get; set; }
    }

    public class Query<T>
    {
        public Query(T data)
        {
            this.Data = data;
        }

        public T Data { get; private set; }
        public int ExecutingUserId { get; set; }
    }
}
