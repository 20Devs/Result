using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyDevs.Result
{
    public partial class Result
    {
        public static bool operator ==(Result leftPhoneNumber, Result righPhoneNumber)
        {
            return true;
        }

        public static bool operator !=(Result leftPhoneNumber, Result righPhoneNumber)
        {
            return !(leftPhoneNumber == righPhoneNumber);
        }
    }
}
