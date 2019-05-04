using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace f
{
    class Hook
    {
        implementation()
        {
            if( (msg = wm_mousemove) && (getkeystate(vk_control) < 0) )
            {
                with pmousehookstruct
                (data) ^
                do
                {
                    ctrl = findcontrol(hwnd);
                    if (ctrl != null)
                    {
                        {
                            form = getparentform(ctrl);
                        }
                        if (form != null)
                        {
                            {
                                form.caption = '';
                                if (ctrl is tcustomedit)
                                {
                                    with tcustomedit
                                    (ctrl)
                                    do
                                    {
                                        p = screentoclient(pt);
                                    } 
                                    if (ctrl is tcustomrichedit)
                                    {
                                        firstpos = sendmessage(hwnd, em_charfrompos, 0, integer(@p))
                                    }
                                    else
                                    {
                                        firstpos = sendmessage(hwnd, em_charfrompos, 0, p.y
                                        shl
                                        16
                                        or
                                        p.x)
                                        ;
                                    }

                                    if (not(ctrl is tcustomrichedit))
                                    {
                                        firstpos = firstpos &&$
                                        ffff;
                                    }
                                    s = text;
                                    inc(firstpos);
                                    if ((firstpos <= length(s)) && (s[firstpos] in
                                    englishletters) )
                                    {
                                        {
                                            lastpos = firstpos;
                                        }
                                        while (firstpos > 0) &&
                                        (s[firstpos] in
                                        englishletters)
                                        do
                                            dec(firstpos); 
                                        inc(firstpos);
                                        while (lastpos <= length(s)) &&
                                        (s[lastpos] in
                                        englishletters)
                                        do
                                            inc(lastpos); 
                                        s = copy(s, firstpos, lastpos - firstpos);
                                        form.caption = s
                                    }
                                }
                            }
                        }
                    }
                    result = callnexthookex(hook, code, msg, data)
                } 
            }

            formcreate(form sender)
{
caption = '';
if( hook = 0 )
{
    hook = setwindowshookex(wh_mouse, mouseproc, 0, getcurrentthreadid);
}
}

formdestroy(form sender)
{
if( application.mainform = self )
{
    unhookwindowshookex(hook);
}
}

formdblclick(form sender)
{
    tform1.create(application).show;
}

formclose(form sender) {
if( application.mainform != self )
{
    action = cafree;
}
}


    }
}


    /*
     
     [DllImport("user32")] public static extern int GetCursorPos(ref POINTAPI lpPoint)
[DllImport("user32")] public static extern int SendMessage(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Integer)
[DllImport("user32")] public static extern int WindowFromPoint(int xPoint, int yPoint)

const object WM_GETTEXT = 13;
const object WM_GETTEXTLENGTH = 14;

POINTAPI P;
long lRet;
long hHandle;
string aText;
long lTextlen;
string aText;
lRet = GetCursorPos(P);
hHandle = WindowFromPoint(P.x, P.y);
lTextlen = SendMessage(hHandle, WM_GETTEXTLENGTH, 0, 0);
if (lTextlen)
{
         if (lTextlen > 1024) lTextlen = 1024; 
         lTextlen += 1
         aText = Space(lTextlen);
         lRet = SendMessage(hHandle, WM_GETTEXT, lTextlen, aText);
         aText = aText.Substring(lRet);
}
     
     */