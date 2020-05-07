using System;
using System.Windows.Forms;

namespace Pomodoro
{
    public partial class PomoForm : Form
    {
        decimal _pomoTime, _breakTime, _timeElapsed;
        bool _isPomo = true, _isStart = true, _hasStarted;

        private void startBt_Click(object sender, EventArgs e)
        {
            if (_isStart)
            {
                if (_hasStarted)
                {
                    pomoTimer.Start();

                    ((Button)sender).Text = "Stop";
                    _isStart = !_isStart;

                    return;
                }
                _pomoTime = pomoVal.Value * 60; _breakTime = breakVal.Value * 60;
                _timeElapsed = 0;

                pomoTimer.Start();

                ((Button)sender).Text = "Stop";
                _isStart = !_isStart;
                _hasStarted = true;
            }
            else
            {
                pomoTimer.Stop();

                ((Button)sender).Text = "Start";
                _isStart = !_isStart;
            }
        }

        private void pomoTimer_Tick(object sender, EventArgs e)
        {
            _timeElapsed += (decimal)(((Timer)sender).Interval) / 1000;

            if (_timeElapsed >= (_isPomo ? _pomoTime : _breakTime))
            {
                _timeElapsed = 0;
                _isPomo = !_isPomo;
                this.Text = (_isPomo ? "Pomodoro Timer" : "Break Timer!");

                // Play a system sound
                System.Media.SystemSounds.Asterisk.Play();
            }

            // Update progressbar display
            progBar.Value = (int)(_timeElapsed / (_isPomo ? _pomoTime : _breakTime) * 100);
        }

        private void resetBt_Click(object sender, EventArgs e)
        {
            _timeElapsed = 0;
            progBar.Value = 0;
        }

        private void progBar_Click(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, (int)_timeElapsed);
            string fmt = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            MessageBox.Show(fmt, "Time Elapsed");
        }

        private void pomoVal_ValueChanged(object sender, EventArgs e)
        {
            _pomoTime = ((NumericUpDown)sender).Value * 60;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            _breakTime = ((NumericUpDown)sender).Value * 60;
        }

        public PomoForm()
        {
            InitializeComponent();
        }

        private void pomoForm_Load(object sender, EventArgs e)
        {
            _pomoTime = pomoVal.Value * 60; _breakTime = breakVal.Value * 60;
            _timeElapsed = _pomoTime;
        }
    }
}
