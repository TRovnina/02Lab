using System;
using System.Windows;
using _02Lab.Models;

namespace _02Lab.Tools.Manager
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
