﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_QLNS.Models
{
    public class ChucVu : Core.ModelBase
    {
        public int MaCV { get { return GetINT(0); } set { SetData(0, value); } }
        public string TenCV { get { return GetSTR(1); } set { SetData(1, value); } }
        public float Phucapchucvu { get { return GetFLO(2); } set { SetData(2, value); } }
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
