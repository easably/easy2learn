using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CefSharp;
using System.Windows.Forms;

namespace f
{
    public class KeyHandlerPlayer : IKeyboardHandler
    {
        IActionPlayerHost host;

        public KeyHandlerPlayer(IActionPlayerHost host)
        {
            if (!(host is Control)) throw new ArrayTypeMismatchException("For new KeyHandlerPlayer need 'host' as Control");
            this.host = host;
        }

        public bool OnKeyEvent(IWebBrowser browser, KeyType type, int code, int modifiers, bool isSystemKey, bool isAfterJavaScript)
        {
            if (type == KeyType.KeyUp) {
                if (code == 219 || code == 82) ((Control)host).Invoke((Action)(() => {
                    host.RePlay(); // [ or R
                }));
                else if (code == 80 || code == 37) ((Control)host).Invoke((Action)(() =>
                {
                    host.PlayPrev(); // P ->
                }));
                else if (code == 78 || code == 221 || code == 39)  ((Control)host).Invoke((Action)(() => {
                    host.PlayNext(); // 'N' -78  ']'-221 '<-' -39
                }));
                else if (code == 32 )  ((Control)host).Invoke((Action)(() => {
                    host.Play(); // space
                }));
            }
            return false;
        }
    }
}
