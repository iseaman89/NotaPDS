using System.Collections.ObjectModel;
using System.Runtime.Intrinsics.X86;
using BAPDS.Model;
using BAPDS.ViewModel;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;

namespace BAPDS.View;

public partial class ProjectChoisePage : ContentPage
{
    public ProjectChoisePage(ProjectChoiseViewModel projectChoiseViewModel)
    {
        InitializeComponent();
        BindingContext = projectChoiseViewModel;
    }
}