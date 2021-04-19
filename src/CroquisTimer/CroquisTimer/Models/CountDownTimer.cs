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
        ReactiveTimer _timer;

        /// <summary>
        /// 制限時間
        /// </summary>
        TimeSpan _timeLimit;

        /// <summary>
        /// 開始時刻
        /// </summary>
        DateTime _timeStart;
        #endregion

        #region Property
        /// <summary>
        /// 残り時間
        /// </summary>
        public ReactiveProperty<TimeSpan> TimeRemaining { get; } = new ReactiveProperty<TimeSpan>(default(TimeSpan));
        #endregion

        #region Method
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CountDownTimer()
        {
            _timer = new ReactiveTimer(TimeSpan.FromSeconds(1));
            _timer.Subscribe(x => TimeRemaining.Value = _timeLimit - (DateTime.Now - _timeStart));


            _timeLimit = new TimeSpan(0, 5, 0);
        }

        /// <summary>
        /// 開始
        /// </summary>
        public void Start()
        {
            _timeStart = DateTime.Now;
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
