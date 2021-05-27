using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSA_Furikae.Models
{
    public class ServiceItem
    {
        public string Key { get; }
        public int Lenb { get; }
        public string ProjectCodeSaki { get; }
        public string ProjectCodeMoto { get; }

        public double[] MonthInterlock { get; set; } =
            Enumerable.Repeat<double>(double.MinValue, 12).ToArray();

        public ServiceItem(
            string key
            , int lenb
            , string saki
            , string moto)
        {
            Key = key; Lenb = lenb;
            ProjectCodeSaki = saki;
            ProjectCodeMoto = moto;
        }

        public double this[int index]
        {
            get
            {
                return MonthInterlock[index];
            }
            set
            {
                MonthInterlock[index] = value;
            }
        }
    }
}
