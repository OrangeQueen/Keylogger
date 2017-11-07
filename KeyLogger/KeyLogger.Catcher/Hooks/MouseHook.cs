using System;
using System.Windows.Forms;
using KeyLogger.Messages;
using KeyLogger.Messages.Events;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace KeyLogger.Catcher.Hooks
{
    public class MouseHook : IInputHook
    {
        private readonly MouseHookListener _mMouseHookManager;
        private bool _disposed;

        public MouseHook()
        {
            _mMouseHookManager = new MouseHookListener(new GlobalHooker()) {Enabled = true};
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

        public void SetOnMouseMove(bool status)
        {
            if (status)
            {
                _mMouseHookManager.MouseMove += HookManager_MouseMove;
            }
            else
            {
                _mMouseHookManager.MouseMove -= HookManager_MouseMove;
            }
        }

        public void SetOnMouseClick(bool status)
        {
            if (status)
            {
                _mMouseHookManager.MouseClickExt += HookManager_MouseClick;
            }
            else
            {
                _mMouseHookManager.MouseClickExt -= HookManager_MouseClick;
            }
        }

        public void SetOnMouseUp(bool status)
        {
            if (status)
            {
                _mMouseHookManager.MouseUp += HookManager_MouseUp;
            }
            else
            {
                _mMouseHookManager.MouseUp -= HookManager_MouseUp;
            }
        }

        public void SetOnMouseDown(bool status)
        {
            if (status)
            {
                _mMouseHookManager.MouseDown += HookManager_MouseDown;
            }
            else
            {
                _mMouseHookManager.MouseDown -= HookManager_MouseDown;
            }
        }

        //public void SetMouseDoubleClick(bool status)
        //{
        //    if (status)
        //    {
        //        m_MouseHookManager.MouseDoubleClick += HookManager_MouseDoubleClick;
        //    }
        //    else
        //    {
        //        m_MouseHookManager.MouseDoubleClick -= HookManager_MouseDoubleClick;
        //    }
        //}

        public void SetMouseWheel(bool status)
        {
            if (status)
            {
                _mMouseHookManager.MouseWheel += HookManager_MouseWheel;
            }
            else
            {
                _mMouseHookManager.MouseWheel -= HookManager_MouseWheel;
            }
        }

        #endregion

        #region Event Handler Functions

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            var mouseinputmessage = new MouseInputMessage
            {
                MouseEvent = MouseEvent.MouseMove,
                X = e.X,
                Y = e.Y
            };

            OnInput(mouseinputmessage);
        }

        private void HookManager_MouseClick(object sender, MouseEventArgs e)
        {
            var mouseinputmessage = new MouseInputMessage
            {
                MouseEvent = MouseEvent.MouseClick,
                MouseButton = e.Button
            };

            OnInput(mouseinputmessage);

            //Log(string.Format("MouseClick \t\t {0}\n", e.Button));
        }

        private void HookManager_MouseUp(object sender, MouseEventArgs e)
        {
            var mouseinputmessage = new MouseInputMessage
            {
                MouseEvent = MouseEvent.MouseUp,
                MouseButton = e.Button
            };

            OnInput(mouseinputmessage);

            //Log(string.Format("MouseUp \t\t {0}\n", e.Button));
        }


        private void HookManager_MouseDown(object sender, MouseEventArgs e)
        {
            var mouseinputmessage = new MouseInputMessage
            {
                MouseEvent = MouseEvent.MouseDown,
                MouseButton = e.Button
            };

            OnInput(mouseinputmessage);
            //Log(string.Format("MouseDown \t\t {0}\n", e.Button));
        }


        //private void HookManager_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    //Log(string.Format("MouseDoubleClick \t\t {0}\n", e.Button));
        //}

        private void HookManager_MouseWheel(object sender, MouseEventArgs e)
        {
            var mouseinputmessage = new MouseInputMessage
            {
                MouseEvent = MouseEvent.MouseWheel,
                Delta = e.Delta
            };

            OnInput(mouseinputmessage);
            //labelWheel.Text = string.Format("Wheel={0:000}", e.Delta);
        }

        #endregion

        public void Enable()
        {
            _mMouseHookManager.Enabled = true;
        }

        public void Disable()
        {
            _mMouseHookManager.Enabled = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _mMouseHookManager.Enabled = false;
                InputEvent = null;
                //m_MouseHookManager.Dispose();
            }

            // Free any unmanaged objects here. 
            //
            _disposed = true;
        }
    }
}