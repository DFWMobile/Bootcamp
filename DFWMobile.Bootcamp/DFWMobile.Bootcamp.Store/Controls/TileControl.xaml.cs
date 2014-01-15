using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DFWMobile.Bootcamp.Store.Controls
{
    public sealed partial class TileControl : UserControl
    {
        private readonly Random _randomGenerator = new Random(DateTime.Now.Millisecond);

        private readonly Storyboard _frontToBack;
        private readonly Storyboard _backToFront;

        private readonly DispatcherTimer _dispatcherTimer;

        private bool _front;
        public TileControl()
        {
            this.InitializeComponent();
            _frontToBack = this.Resources["TileFlipF_B"] as Storyboard;
            _frontToBack.AutoReverse = false;
            _frontToBack.FillBehavior = FillBehavior.HoldEnd;
            _backToFront = this.Resources["TileFlipF_A"] as Storyboard;
            _backToFront.AutoReverse = false;
            _backToFront.FillBehavior = FillBehavior.HoldEnd;
            _front = false;

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += DispatcherTimerTick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 5 + _randomGenerator.Next(1, 5));
            _dispatcherTimer.Start();
        }

        private void DispatcherTimerTick(object sender, object args)
        {
            Flip();

            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 5 + _randomGenerator.Next(1, 5));
        }

        public void Flip()
        {
            if (_front)
            {
                _front = false;
                _frontToBack.Begin();
            }
            else
            {
                _front = true;
                _backToFront.Begin();
            }
        }

        public object FrontTile
        {
            get { return FrontPresenter.Content; }
            set { FrontPresenter.Content = value; }
        }

        public object BackTile
        {
            get { return BackPresenter.Content; }
            set { BackPresenter.Content = value; }
        }
    }
}
