using System;
using System.Windows;
using _Laboratory02.Models;

namespace _Laboratory02.Tools.Manager
{
    internal static class StaticManager
    {
        internal static Person CurrentPerson { get; set; }

        internal static void Initialize()
        {
        }

        internal static void CloseApp()
        {
            MessageBox.Show("Do you want to close program?");
            Environment.Exit(1);
        }
    }
}
