using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_QLNS.Models
{
    public class TrinhDoHocVan : Core.ModelBase
    {
        public int MaTDHV { get { return GetINT(0); } set { SetData(0, value); } }
        public string Trinhdohocvan { get { return GetSTR(1); } set { SetData(1, value); } }
        public string Chuyennganh { get { return GetSTR(2); } set { SetData(2, value); } }
        public override Type GetDataType()
        {
            return this.GetType();   
        }
        public override void Setup()
        {
            MaxFields = 2;
            ValueData = new object[MaxFields + 1];
        }
    }
}
