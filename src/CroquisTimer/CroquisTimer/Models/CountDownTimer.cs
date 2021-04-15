using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Mvvm;

namespace CroquisTimer.Models
{
    public class CountDownTimer : BindableBase
    {
        #region Field
        DispatcherTimer _dispatcherTimer;

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
        private TimeSpan _timeRemaining;
        public TimeSpan TimeRemaining
        {
            get { return _timeRemaining; }
            set { SetProperty(ref _timeRemaining, value); }
        }
        #endregion

        #region Method
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CountDownTimer()
        {
            _dispatcherTimer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 1),
            };

            _dispatcherTimer.Tick += (s, e) =>
            {
                TimeRemaining = _timeLimit - (DateTime.Now - _timeStart);
            };

            _timeLimit = new TimeSpan(0, 5, 0);
        }

        /// <summary>
        /// 開始
        /// </summary>
        public void Start()
        {
            _timeStart = DateTime.Now;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// 一時停止
        /// </summary>
        public void Pause()
        {
            _dispatcherTimer.Stop();
        }
        #endregion
    }
}
