﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kouvee.Exceptions
{
    public class NumberOnlyException : Exception
    {
        public NumberOnlyException()
        {
            System.Windows.Forms.MessageBox.Show("Hanya Boleh Angka");
        }
    }
}
