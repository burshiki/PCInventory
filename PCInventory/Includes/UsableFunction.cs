﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCInventory.Includes
{
    internal class UsableFunction
    {

        public void ResponsiveDtg(DataGridView dvg)
        {
            dvg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
    }
}
