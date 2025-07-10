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
        private const byte VK_D = 0x44; // D 鍵的虛擬鍵碼
        private const byte VK_C = 0x43; // D 鍵的虛擬鍵碼

        private const byte VK_UP = 0x26;
        private const byte VK_DOWN = 0x28;
        private const byte VK_RIGHT = 0x27;
        private const byte VK_LEFT = 0x25;




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
            //keybd_event(VK_RETURN, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            //keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up

            // 模擬按下Z
            //keybd_event(VK_Z, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            //Thread.Sleep(300);
            //keybd_event(VK_Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            //Thread.Sleep(300);
            //keybd_event(VK_Z, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            //Thread.Sleep(500);
            //keybd_event(VK_Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            //Thread.Sleep(500);
            //keybd_event(VK_Z, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            //Thread.Sleep(500);
            //keybd_event(VK_Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            //Thread.Sleep(500);
            //keybd_event(VK_Z, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            //Thread.Sleep(500);
            //keybd_event(VK_Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            int longpress = 50;
            int shortpress = 10;
            Thread.Sleep(1000);
            for (int i = 0; i < longpress; i++)
            {
                keybd_event(VK_Z, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
                Thread.Sleep(100);
                keybd_event(VK_Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
                Thread.Sleep(700);
            }
        }




        public void ScriptTest1(object sender, RoutedEventArgs e)
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

            while (true)
            {
                // here input script
                ArmyTopLayer1V2();

                ArmyTopLayer1ToNextLayer();

                ArmyTopLayer2();

                ArmyTopLayer2ToNextLayer();


                ArmyTopLayer3();

                ArmyTopLayer3ToNextLayer();

                ArmyTopLayer4();

                ArmyReturnTop_ClimbToLadder();

                ArmyReturnTop_ToSafeZone_GlobalMarket();

                ArmyReturnTop_ClickMarketButton();

                ArmyReturnTop_LeaveGlobalMarket();
            }

        }





        public void MoveMouseToMarketTest(object sender, RoutedEventArgs e)
        {
            //init
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


            Thread.Sleep(1000);

            ArmyReturnTop_ClimbToLadder();

            ArmyReturnTop_ToSafeZone_GlobalMarket();

            ArmyReturnTop_ClickMarketButton();

            ArmyReturnTop_LeaveGlobalMarket();

        }







        public void ArmyTopLayer1()
        {

            Thread.Sleep(1000);
            // init position
            Move(3000, VK_LEFT);
            Move(2800, VK_RIGHT);

            // down jump
            DownJump(600, VK_RIGHT);

            Move(1000, VK_LEFT);
            Move(100, VK_RIGHT);

            // auto attack start
            StandingAttackOrHeal(2);

            // Move attack 800 PER ture
            FlashAndAttackOrHeal(2400, VK_RIGHT);
            FlashAndAttackOrHeal(820, VK_LEFT);


            // auto attack start
            StandingAttackOrHeal(7);
        }

        public void ArmyTopLayer1V2()
        {

            Thread.Sleep(1000);
            // init position
            Move(3000, VK_LEFT);
            Move(6400, VK_RIGHT);
            Move(100, VK_LEFT);

            // auto attack start
            StandingAttackOrHeal(1);

            // Move attack 800 PER ture
            FlashAndAttackOrHeal(1000, VK_LEFT);
            Move(800, VK_LEFT);
            FlashAndAttackOrHeal(600, VK_LEFT);
            Move(600, VK_LEFT);
            StandingAttackOrHeal(1);
            Move(1000, VK_RIGHT);
            PatrolAttackOrHeal(1, 0);

            // auto attack start
            StandingAttackOrHeal(5);
            Move(800, VK_LEFT);
        }

        public void ArmyTopLayer2()
        {
            // down jump
            DownJump(600, VK_RIGHT);
            Move(1000, VK_LEFT);
            // auto attack start
            StandingAttackOrHeal(7);
            // Move attack 800 PER ture
            FlashAndAttackOrHeal(800, VK_LEFT);
            MoveAndAttackOrHeal(2, VK_LEFT);
            FlashAndAttackOrHeal(800, VK_LEFT);
            MoveAndAttackOrHeal(2, VK_LEFT);
            FlashAndAttackOrHeal(1000, VK_LEFT);
            FlashAndAttackOrHeal(1600, VK_RIGHT);
            Move(1500, VK_LEFT);

            // auto attack start
            PatrolAttackOrHeal(1, 1);
            StandingAttackOrHeal(1);

        }

        public void ArmyTopLayer3()
        {
            // down jump
            DownJump(600, VK_RIGHT);
            // Move attack 800 PER ture
            FlashAndAttackOrHeal(4000, VK_RIGHT);
            Move(400, VK_RIGHT);
            Move(100, VK_LEFT);
            FlashAndAttackOrHeal(600, VK_LEFT);

            // auto attack start
            PatrolAttackOrHeal(1, 1);
            Move(500, VK_LEFT);
            Move(1000, VK_RIGHT);

        }

        public void ArmyTopLayer4()
        {
            Move(500, VK_RIGHT);
            StandingAttackOrHeal(1);
            FlashAndAttackOrHeal(1800, VK_RIGHT);
            Move(1000, VK_RIGHT);
            FlashAndAttackOrHeal(600, VK_RIGHT);
            Move(1000, VK_RIGHT);
            FlashAndAttackOrHeal(600, VK_RIGHT);
            Move(600, VK_LEFT);
            StandingAttackOrHeal(1);
            FlashAndAttackOrHeal(1000, VK_LEFT);
            StandingAttackOrHeal(3);
            Move(1000, VK_LEFT);
            PatrolAttackOrHeal(2, 1);
            Move(800, VK_RIGHT);
            FlashAndAttackOrHeal(2000, VK_RIGHT);
            Move(800, VK_LEFT);
            FlashAndAttackOrHeal(600, VK_LEFT);
            Move(500, VK_LEFT);
            FlashAndAttackOrHeal(600, VK_LEFT);
            Move(500, VK_LEFT);
            FlashAndAttackOrHeal(600, VK_LEFT);
            Move(500, VK_LEFT);
            FlashAndAttackOrHeal(600, VK_LEFT);
            Move(500, VK_LEFT);


        }

        public void ArmyTopLayer1ToNextLayer()
        {
            Move(800, VK_RIGHT);
            FlashAndAttackOrHeal(600, VK_RIGHT);
            Move(1000, VK_RIGHT);
            FlashAndAttackOrHeal(600, VK_RIGHT);
            Move(1000, VK_RIGHT);
        }


        public void ArmyTopLayer2ToNextLayer()
        {
            FlashAndAttackOrHeal(1000, VK_LEFT);
            Move(2000, VK_LEFT);
            Move(1500, VK_RIGHT);

        }

        public void ArmyTopLayer3ToNextLayer()
        {
            Move(2000, VK_RIGHT);
            FlashAndAttackOrHeal(600, VK_LEFT);
            Move(1000, VK_LEFT);
            FlashAndAttackOrHeal(600, VK_LEFT);
            Move(1000, VK_LEFT);
            FlashAndAttackOrHeal(600, VK_LEFT);
            Move(1000, VK_LEFT);
            FlashAndAttackOrHeal(600, VK_LEFT);
            Move(2000, VK_LEFT);

        }

        public void ArmyReturnTop_ClimbToLadder()
        {
            MoveAndAttackOrHeal(1, VK_LEFT);
            StandingAttackOrHeal(2);
            MoveAndAttackOrHeal(1, VK_LEFT);
            StandingAttackOrHeal(2);
            MoveAndAttackOrHeal(1, VK_LEFT);
            StandingAttackOrHeal(2);
            MoveAndAttackOrHeal(1, VK_LEFT);
            StandingAttackOrHeal(2);
            Jump(VK_RIGHT);
            Thread.Sleep(500);
            JumpAndClimb(VK_RIGHT);
            ClimbUp(1300);
        }

        public void ArmyReturnTop_ToSafeZone_GlobalMarket()
        {
            Thread.Sleep(20000);
        }


        public void ArmyReturnTop_ClickMarketButton()
        {
            SetCursorPos(1450, 1040);
            // 模擬滑鼠左鍵點擊
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);

        }

        public void ArmyReturnTop_LeaveGlobalMarket()
        {
            MoveToPortal(6000, VK_LEFT, 330);

        }





        //-----------------------------------------------------------------------------------------------------------------------------


        public void Move(int time, byte direct)
        {
            keybd_event(direct, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            Thread.Sleep(time);
            keybd_event(direct, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up

        }

        public void MoveToPortal(int time, byte direct, int pressgap = 330)
        {
            int times = (int)(time / pressgap);

            keybd_event(direct, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            for (int i = 0; i < times; i++)
            {
                keybd_event(VK_UP, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
                Thread.Sleep(pressgap / (int)2);
                keybd_event(VK_UP, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
                Thread.Sleep(pressgap / (int)2);
            }
            keybd_event(direct, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up

        }


        public void DownJump(int time, byte direct)
        {
            keybd_event(VK_DOWN, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            keybd_event(direct, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            keybd_event(VK_C, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            Thread.Sleep(time);
            keybd_event(VK_DOWN, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            keybd_event(direct, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            keybd_event(VK_C, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
        }

        public void StandingAttackOrHeal(int times)
        {
            for (int i = 0; i < times; i++)
            {
                keybd_event(VK_Z, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
                Thread.Sleep(100);
                keybd_event(VK_Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
                Thread.Sleep(700);
            }
        }

        public void FlashAndAttackOrHeal(int time, byte direct)
        {
            keybd_event(VK_Z, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            keybd_event(VK_D, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            keybd_event(direct, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            Thread.Sleep(time);
            keybd_event(VK_Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            keybd_event(VK_D, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            keybd_event(direct, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
        }

        public void MoveAndAttackOrHeal(int time, byte direct)
        {
            keybd_event(direct, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            StandingAttackOrHeal(time);
            keybd_event(direct, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
        }

        // odd = left, even = right
        public void PatrolAttackOrHeal(int times, int direct = 0)
        {
            byte f1 = VK_LEFT;
            byte f2 = VK_RIGHT;
            if ((direct & 1) == 1)
            {
                f1 = VK_RIGHT;
                f2 = VK_LEFT;
            }
            for (int i = 0; i < times; i++)
            {
                StandingAttackOrHeal(1);
                Move(300, f1);
                StandingAttackOrHeal(1);
                Move(600, f2);
                StandingAttackOrHeal(1);
                Move(300, f1);
                StandingAttackOrHeal(1);
                Move(300, f2);
            }
        }

        public void JumpAndClimb(byte direct)
        {

            keybd_event(VK_C, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            Thread.Sleep(50);
            keybd_event(VK_C, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            keybd_event(VK_UP, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            Move(300, direct);
            keybd_event(VK_UP, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down

        }

        public void Jump(byte direct)
        {

            keybd_event(VK_C, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            keybd_event(direct, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            Thread.Sleep(50);
            keybd_event(direct, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            keybd_event(VK_C, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up

        }

        public void ClimbUp(int time)
        {

            keybd_event(VK_UP, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            Thread.Sleep(time);
            keybd_event(VK_UP, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up

        }
    }
}

