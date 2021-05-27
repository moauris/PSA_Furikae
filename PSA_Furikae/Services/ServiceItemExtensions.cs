using PSA_Furikae.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSA_Furikae.Services
{
    public static class ServiceItemExtensions
    {
        public static string ToJson(this ServiceItem item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('{');
            sb.Append($"key:'{item.Key}',");
            sb.Append($"lenb:'{item.Lenb}',");
            sb.Append($"pCodeSaki:'{item.ProjectCodeSaki}',");
            sb.Append($"pCodeMoto:'{item.ProjectCodeMoto}',");
            sb.Append($"interlock:[");
            sb.Append(string.Join(",", item.MonthInterlock));
            sb.Append("]}");

            return sb.ToString();
        }
    }
}
