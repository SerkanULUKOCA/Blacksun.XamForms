﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksunBluetooth.Exceptions
{
    public class BluetoothMissingIDException : Exception
    {

        public BluetoothMissingIDException(string message)
            : base(message)
        {
            
        }

    }
}
