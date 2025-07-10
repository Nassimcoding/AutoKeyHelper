using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoKeyHelper.keyboard;
using AutoKeyHelper.KeyBoardClassTestSuccess;

namespace AutoKeyHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //// 等 1 秒，給你時間切到目標視窗（記事本等）
            //await Task.Delay(1000);

            //// 按下 Z
            //PressKey(0x5A); // 0x5A = 'Z'

            //// 持續 10 秒
            //await Task.Delay(10000);

            //// 放開 Z
            //ReleaseKey(0x5A);
        }

        
        private void MoveMouseToCenter_Click(object sender, RoutedEventArgs e)
        {
            var test = new MouseMoveAndClickAndKeyBoardClickSample();
            test.ScriptTest1(sender,e);
        }

        private void MoveMouseToMarketTest(object sender, RoutedEventArgs e)
        {

            var test = new MouseMoveAndClickAndKeyBoardClickSample();
            test.MoveMouseToMarketTest(sender, e);



        }



        //private const uint INPUT_KEYBOARD = 1;
        //private const uint KEYEVENTF_KEYUP = 0x0002;

        //[StructLayout(LayoutKind.Sequential)]
        //struct INPUT
        //{
        //    public uint type;
        //    public InputUnion U;
        //}

        //[StructLayout(LayoutKind.Explicit)]
        //struct InputUnion
        //{
        //    [FieldOffset(0)]
        //    public KEYBDINPUT ki;
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //struct KEYBDINPUT
        //{
        //    public ushort wVk;
        //    public ushort wScan;
        //    public uint dwFlags;
        //    public uint time;
        //    public IntPtr dwExtraInfo;
        //}

        //[DllImport("user32.dll", SetLastError = true)]
        //static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        //private void PressKey(ushort keyCode)
        //{
        //    INPUT input = new INPUT
        //    {
        //        type = INPUT_KEYBOARD,
        //        U = new InputUnion
        //        {
        //            ki = new KEYBDINPUT
        //            {
        //                wVk = keyCode,
        //                wScan = 0,
        //                dwFlags = 0, // key down
        //                time = 0,
        //                dwExtraInfo = IntPtr.Zero
        //            }
        //        }
        //    };

        //    uint sent = SendInput(1, new[] { input }, Marshal.SizeOf(typeof(INPUT)));
        //    if (sent == 0)
        //    {
        //        MessageBox.Show($"PressKey failed: {Marshal.GetLastWin32Error()}");
        //    }
        //}

        //private void ReleaseKey(ushort keyCode)
        //{
        //    INPUT input = new INPUT
        //    {
        //        type = INPUT_KEYBOARD,
        //        U = new InputUnion
        //        {
        //            ki = new KEYBDINPUT
        //            {
        //                wVk = keyCode,
        //                wScan = 0,
        //                dwFlags = KEYEVENTF_KEYUP, // key up
        //                time = 0,
        //                dwExtraInfo = IntPtr.Zero
        //            }
        //        }
        //    };

        //    uint sent = SendInput(1, new[] { input }, Marshal.SizeOf(typeof(INPUT)));
        //    if (sent == 0)
        //    {
        //        MessageBox.Show($"ReleaseKey failed: {Marshal.GetLastWin32Error()}");
        //    }
        //}















        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    await Task.Delay(1000); // 給你時間切到記事本

        //    // 使用 Virtual-Key 模式（避免 SCANCODE 相容性問題）
        //    KeyboardSimulator.PressKey(0x2C); // z
        //    await Task.Delay(100);
        //    KeyboardSimulator.ReleaseKey(0x2C);
        //}

        //private const uint INPUT_KEYBOARD = 1;
        //private const uint KEYEVENTF_KEYUP = 0x0002;

        //[StructLayout(LayoutKind.Sequential)]
        //struct INPUT
        //{
        //    public uint type;
        //    public InputUnion u;
        //}

        //[StructLayout(LayoutKind.Explicit)]
        //struct InputUnion
        //{
        //    [FieldOffset(0)] public KEYBDINPUT ki;
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //struct KEYBDINPUT
        //{
        //    public ushort wVk;
        //    public ushort wScan;
        //    public uint dwFlags;
        //    public uint time;
        //    public IntPtr dwExtraInfo;
        //}

        //[DllImport("user32.dll", SetLastError = true)]
        //static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        //private void PressKey(ushort virtualKey)
        //{
        //    var input = new INPUT
        //    {
        //        type = INPUT_KEYBOARD,
        //        u = new InputUnion
        //        {
        //            ki = new KEYBDINPUT
        //            {
        //                wVk = virtualKey,
        //                wScan = 0,
        //                dwFlags = 0,
        //                time = 0,
        //                dwExtraInfo = IntPtr.Zero
        //            }
        //        }
        //    };

        //    var sent = SendInput(1, new[] { input }, Marshal.SizeOf(typeof(INPUT)));
        //    if (sent == 0)
        //    {
        //        MessageBox.Show($"PressKey failed: {Marshal.GetLastWin32Error()}");
        //    }
        //}

        //private void ReleaseKey(ushort virtualKey)
        //{
        //    var input = new INPUT
        //    {
        //        type = INPUT_KEYBOARD,
        //        u = new InputUnion
        //        {
        //            ki = new KEYBDINPUT
        //            {
        //                wVk = virtualKey,
        //                wScan = 0,
        //                dwFlags = KEYEVENTF_KEYUP,
        //                time = 0,
        //                dwExtraInfo = IntPtr.Zero
        //            }
        //        }
        //    };

        //    var sent = SendInput(1, new[] { input }, Marshal.SizeOf(typeof(INPUT)));
        //    if (sent == 0)
        //    {
        //        MessageBox.Show($"ReleaseKey failed: {Marshal.GetLastWin32Error()}");
        //    }
        //}
    }
}
