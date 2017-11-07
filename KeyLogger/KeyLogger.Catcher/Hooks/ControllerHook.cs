using System;
using J2i.Net.XInputWrapper;
using KeyLogger.Messages;

namespace KeyLogger.Catcher.Hooks
{
    public class ControllerHook : IInputHook
    {
        private readonly XboxController _selectedController;
        private bool _disposed;

        public ControllerHook()
        {
            _selectedController = XboxController.RetrieveController(0);
            _selectedController.StateChanged += selectedController_StateChanged;
            XboxController.StartPolling();
        }

        public ControllerHook(int number)
        {
            if (number >= 0 && number < 4)
            {
                _selectedController = XboxController.RetrieveController(number);
                _selectedController.StateChanged += selectedController_StateChanged;
                XboxController.StartPolling();
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public event EventHandler<HookEventArgs> InputEvent = null;

        public void OnInput(InputMessage inputmessage)
        {
            if (InputEvent != null)
                InputEvent(this, new HookEventArgs {Message = inputmessage});
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Enable()
        {
            XboxController.StartPolling();
        }

        public void Disable()
        {
            XboxController.StopPolling();
        }


        private void selectedController_StateChanged(object sender, XboxControllerStateChangedEventArgs e)
        {
            var xc = (XboxController) sender;

            var controllerinputmessage = new ControllerInputMessage
            {
                A = xc.IsAPressed,
                B = xc.IsBPressed,
                Back = xc.IsBackPressed,
                DPadDown = xc.IsDPadDownPressed,
                DPadLeft = xc.IsDPadLeftPressed,
                DPadRight = xc.IsDPadRightPressed,
                DPadUp = xc.IsDPadUpPressed,
                LeftShoulder = xc.IsLeftShoulderPressed,
                LeftStick = xc.IsLeftStickPressed,
                LeftThumbStick = new ControllerInputMessage.Point {X = xc.LeftThumbStick.X, Y = xc.LeftThumbStick.Y},
                LeftTrigger = xc.LeftTrigger,
                RightShoulder = xc.IsRightShoulderPressed,
                RightStick = xc.IsRightStickPressed,
                RightThumbStick = new ControllerInputMessage.Point {X = xc.RightThumbStick.X, Y = xc.RightThumbStick.Y},
                RightTrigger = xc.RightTrigger,
                Start = xc.IsStartPressed,
                X = xc.IsXPressed,
                Y = xc.IsYPressed
            };

            OnInput(controllerinputmessage);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                XboxController.StopPolling();
                InputEvent = null;
            }

            // Free any unmanaged objects here. 
            //
            _disposed = true;
        }
    }
}