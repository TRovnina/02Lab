using System.ComponentModel;
using System.Windows;

namespace _Laboratory02.Tools
{
    internal interface ILoader : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
