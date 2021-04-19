using System.Reactive.Disposables;
using System.Reflection;
using CroquisTimer.Models;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace CroquisTimer.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Field
        CompositeDisposable _disposables;
        CountDownTimer _timer;
        #endregion

        #region Property
        public ReactiveProperty<string> Title { get; }
        public ReactiveProperty<string> TimeRemainingText { get; }
        #endregion

        #region Command
        public ReactiveCommand StartTimerCommand { get; } = new ReactiveCommand();
        #endregion

        #region Method
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            _timer = new CountDownTimer();

            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Title = new ReactiveProperty<string>(assemblyName).AddTo(_disposables);

            StartTimerCommand.Subscribe(() => _timer.Start());
        }
        #endregion
    }
}
