﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Core.Entities
{
    public class ServiceResult
    {
        public bool IsValid { get; set; }
        public object Data { get; set; }
        public int RowEffect { get; set; }
    }
}
