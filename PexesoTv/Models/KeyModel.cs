using System;
using PexesoTv.Common;

namespace PexesoTv.Models
{
    public class KeyModelEvent
    {
        public KeyModelEvent()
        {
        }

        public string DisplayLabel
        {
            get;
            set;
        }

        public int KeyCode
        {
            get;
            set;
        }

        public KeyPad KeyPad
        {
            get;
            set;
        }
    }
}
