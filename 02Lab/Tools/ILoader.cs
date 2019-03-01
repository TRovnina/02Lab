using System.ComponentModel;
using System.Windows;

namespace _02Lab.Tools
{
    internal interface ILoader : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
