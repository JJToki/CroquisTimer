using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;

namespace CroquisTimer.Models
{
    public class CountDownTimer : BindableBase
    {
        #region Field
        /// <summary>
        /// タイマー
        /// </summary>
        private ReactiveTimer _timer;

        /// <summary>
        /// タイマー刻み
        /// </summary>
        private static readonly TimeSpan _interval = TimeSpan.FromSeconds(1);

        /// <summary>
        /// 制限時間
        /// </summary>
        private TimeSpan _timeLimit;
        #endregion

        #region Property
        /// <summary>
        /// 残り時間
        /// </summary>
        public ReactiveProperty<TimeSpan> TimeRemaining { get; }
        #endregion

        #region Method
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CountDownTimer()
        {
            _timer = new ReactiveTimer(_interval);
            _timer.Subscribe(_ => TimeRemaining.Value -= _interval);

            _timeLimit = new TimeSpan(0, 5, 0);

            TimeRemaining = new ReactiveProperty<TimeSpan>(_timeLimit);
        }

        /// <summary>
        /// 開始
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }

        /// <summary>
        /// 一時停止
        /// </summary>
        public void Pause()
        {
            _timer.Stop();
        }
        #endregion
    }
}
