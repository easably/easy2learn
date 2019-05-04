// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace Windows7
{
    /// <summary>
    /// The primary coordinator of the Windows 7 taskbar-related activities.
    /// </summary>
    public static class Windows7Taskbar
    {
        private static ITaskbarList3 _taskbarList;
        internal static ITaskbarList3 TaskbarList
        {
            get
            {
                if (_taskbarList == null)
                {
                    lock (typeof(Windows7Taskbar))
                    {
                        if (_taskbarList == null)
                        {
                            _taskbarList = (ITaskbarList3)new CTaskbarList();
                            _taskbarList.HrInit();
                        }
                    }
                }
                return _taskbarList;
            }
        }

        static readonly OperatingSystem osInfo = Environment.OSVersion;

        public static bool Windows7OrGreater
        {
            get
            {
                return (osInfo.Version.Major == 6 && osInfo.Version.Minor >= 1)
                    || (osInfo.Version.Major > 6);
            }
        }

        /// <summary>
        /// Sets the progress state of the specified window's
        /// taskbar button.
        /// </summary>
        /// <param name="hwnd">The window handle.</param>
        /// <param name="state">The progress state.</param>
        public static void SetProgressState(IntPtr hwnd, ThumbnailProgressState state)
        {
            if(Windows7OrGreater)
                TaskbarList.SetProgressState(hwnd, state);
        }
        /// <summary>
        /// Sets the progress value of the specified window's
        /// taskbar button.
        /// </summary>
        /// <param name="hwnd">The window handle.</param>
        /// <param name="current">The current value.</param>
        /// <param name="maximum">The maximum value.</param>
        public static void SetProgressValue(IntPtr hwnd, ulong current, ulong maximum)
        {
            if(Windows7OrGreater)
                TaskbarList.SetProgressValue(hwnd, current, maximum);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        static ulong applicationProgress = 0;
        static ulong applicationProgressMax = 40;

        public static void CalculateAndSet(IntPtr hwnd, int allInList, int current)
        {
            if (current == 0) return;
            ulong newVal = 0;
            ulong max = applicationProgressMax;
            decimal d = allInList / Convert.ToInt32(applicationProgressMax);
            if (d != 0)
            {
                newVal = Convert.ToUInt64(current / d);
            }

            if ((ulong)allInList < applicationProgressMax)
            {
                max = (ulong)allInList;
                newVal = (ulong)current;
            }

            if (newVal != applicationProgress)
            {
                applicationProgress = newVal;
                Windows7Taskbar.SetProgressValue(hwnd, applicationProgress, max);
            }
        }
    }
}