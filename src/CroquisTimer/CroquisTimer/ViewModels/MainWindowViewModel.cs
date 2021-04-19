using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reflection;
using ControlzEx.Standard;
using CroquisTimer.Models;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace CroquisTimer.ViewModels
{
    public class MainWindowViewModel : BindableBase, IDestructible
    {
        #region Field
        private CompositeDisposable _disposables = new CompositeDisposable();
        private CountDownTimer _timer;
        #endregion

        #region Property
        public ReactiveProperty<string> Title { get; }

        public ReadOnlyReactiveProperty<string> TimeRemainingText { get; }
        #endregion

        #region Command
        public ReactiveCommand<bool> StartPauseTimerCommand { get; } = new ReactiveCommand<bool>();
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

            TimeRemainingText = _timer.TimeRemaining.Select(x => x.ToString("mm\\:ss")).ToReadOnlyReactiveProperty().AddTo(_disposables);

            StartPauseTimerCommand.Subscribe(isChecked => { if (isChecked) _timer.Start(); else _timer.Pause(); });
        }

        public void Destroy() => _disposables.Dispose();
        #endregion
    }
}
