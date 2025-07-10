using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoKeyHelper.KeyBoardClassTestSuccess
{
    public class MouseMoveAndClickAndKeyBoardClickSample
    {

        // 引用 Win32 API 的方法 (這要放在 class 內，但不是 method 裡)
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        // 鍵盤控制 API
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const uint KEYEVENTF_KEYDOWN = 0x0000;
        private const uint KEYEVENTF_KEYUP = 0x0002;
        private const byte VK_RETURN = 0x0D; // Enter 鍵的虛擬鍵碼
        private const byte VK_Z = 0x5A; // Z 鍵的虛擬鍵碼

        public void MouseAndKeyboardTest(object sender, RoutedEventArgs e)
        {
            // 取得主要螢幕的解析度
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;

            // 計算正中央的座標
            int centerX = (int)(screenWidth / 2);
            int centerY = (int)(screenHeight / 2);

            // 移動滑鼠
            SetCursorPos(centerX, centerY);
            // 模擬滑鼠左鍵點擊
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);

            // 模擬按下Enter
            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up

            // 模擬按下Z
            keybd_event(VK_Z, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            keybd_event(VK_Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
        }

    }
}
