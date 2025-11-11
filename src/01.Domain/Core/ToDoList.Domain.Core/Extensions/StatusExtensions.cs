using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Core.Enums;

namespace ToDoList.Domain.Core.Extensions
{
    public static class StatusExtensions
    {
        public static string GetColor(this StatusEnum status)
        {
            switch (status)
            {
                case StatusEnum.Delayed:
                    return "red";
                case StatusEnum.Done:
                    return "green";
                case StatusEnum.InProgress:
                    return "blue";
                default:
                    return "";
            }
        }
    }
}
