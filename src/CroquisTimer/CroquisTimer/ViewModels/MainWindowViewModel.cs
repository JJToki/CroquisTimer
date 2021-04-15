using System.Reflection;
using Prism.Mvvm;
using Reactive.Bindings;

namespace CroquisTimer.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Property
        public ReactiveProperty<string> Title { get; }
        #endregion

        #region Method
        public MainWindowViewModel()
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Title = new ReactiveProperty<string>(assemblyName);
        }
        #endregion
    }
}
