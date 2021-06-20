﻿using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace ArtilleryCalculator
{
    class ClickListener : BaseWindowsHookListener
    {
        public delegate void ClickCallback();
        public ClickCallback Callback { get; set; }

        public ClickListener() : base(Native.WH_MOUSE_LL) { }

        protected override void HandleHook(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)Native.WM_LBUTTONDOWN)
            {
                Callback?.Invoke();
            }
        }
    }
}
