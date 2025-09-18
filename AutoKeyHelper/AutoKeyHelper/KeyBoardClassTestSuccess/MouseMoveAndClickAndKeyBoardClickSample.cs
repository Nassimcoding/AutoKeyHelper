using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

        private const byte VK_A = 0x41; // A 鍵的虛擬鍵碼
        private const byte VK_B = 0x42; // B 鍵的虛擬鍵碼
        private const byte VK_C = 0x43; // C 鍵的虛擬鍵碼
        private const byte VK_D = 0x44; // D 鍵的虛擬鍵碼
        private const byte VK_E = 0x45; // E 鍵的虛擬鍵碼
        private const byte VK_F = 0x46; // F 鍵的虛擬鍵碼
        private const byte VK_G = 0x47; // G 鍵的虛擬鍵碼
        private const byte VK_H = 0x48; // H 鍵的虛擬鍵碼
        private const byte VK_I = 0x49; // I 鍵的虛擬鍵碼
        private const byte VK_J = 0x4A; // J 鍵的虛擬鍵碼
        private const byte VK_K = 0x4B; // K 鍵的虛擬鍵碼
        private const byte VK_L = 0x4C; // L 鍵的虛擬鍵碼
        private const byte VK_M = 0x4D; // M 鍵的虛擬鍵碼
        private const byte VK_N = 0x4E; // N 鍵的虛擬鍵碼
        private const byte VK_O = 0x4F; // O 鍵的虛擬鍵碼
        private const byte VK_P = 0x50; // P 鍵的虛擬鍵碼
        private const byte VK_Q = 0x51; // Q 鍵的虛擬鍵碼
        private const byte VK_R = 0x52; // R 鍵的虛擬鍵碼
        private const byte VK_S = 0x53; // S 鍵的虛擬鍵碼
        private const byte VK_T = 0x54; // T 鍵的虛擬鍵碼
        private const byte VK_U = 0x55; // U 鍵的虛擬鍵碼
        private const byte VK_V = 0x56; // V 鍵的虛擬鍵碼
        private const byte VK_W = 0x57; // W 鍵的虛擬鍵碼
        private const byte VK_X = 0x58; // X 鍵的虛擬鍵碼
        private const byte VK_Y = 0x59; // Y 鍵的虛擬鍵碼
        private const byte VK_Z = 0x5A; // Z 鍵的虛擬鍵碼

        private const byte VK_0 = 0x30; // 0 鍵的虛擬鍵碼
        private const byte VK_1 = 0x31; // 1 鍵的虛擬鍵碼
        private const byte VK_2 = 0x32; // 2 鍵的虛擬鍵碼
        private const byte VK_3 = 0x33; // 3 鍵的虛擬鍵碼
        private const byte VK_4 = 0x34; // 4 鍵的虛擬鍵碼
        private const byte VK_5 = 0x35; // 5 鍵的虛擬鍵碼
        private const byte VK_6 = 0x36; // 6 鍵的虛擬鍵碼
        private const byte VK_7 = 0x37; // 7 鍵的虛擬鍵碼
        private const byte VK_8 = 0x38; // 8 鍵的虛擬鍵碼
        private const byte VK_9 = 0x39; // 9 鍵的虛擬鍵碼

        private const byte VK_UP = 0x26;
        private const byte VK_DOWN = 0x28;
        private const byte VK_RIGHT = 0x27;
        private const byte VK_LEFT = 0x25;

        private bool isRunning = false;             // 旗標：是否正在執行
        private CancellationTokenSource cts = null; // 停止用





        private static readonly Dictionary<char, byte> _virtualKeyMap = new Dictionary<char, byte>
        {
            // 英文字母 A-Z
            {'A', 0x41}, {'B', 0x42}, {'C', 0x43}, {'D', 0x44}, {'E', 0x45},
            {'F', 0x46}, {'G', 0x47}, {'H', 0x48}, {'I', 0x49}, {'J', 0x4A},
            {'K', 0x4B}, {'L', 0x4C}, {'M', 0x4D}, {'N', 0x4E}, {'O', 0x4F},
            {'P', 0x50}, {'Q', 0x51}, {'R', 0x52}, {'S', 0x53}, {'T', 0x54},
            {'U', 0x55}, {'V', 0x56}, {'W', 0x57}, {'X', 0x58}, {'Y', 0x59},
            {'Z', 0x5A},

            // 數字 0-9
            {'0', 0x30}, {'1', 0x31}, {'2', 0x32}, {'3', 0x33}, {'4', 0x34},
            {'5', 0x35}, {'6', 0x36}, {'7', 0x37}, {'8', 0x38}, {'9', 0x39},
        };

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

                ArmyReturnTop_ClickMarketButton_ForLaptop();

                ArmyReturnTop_LeaveGlobalMarket();
            }

        }


        public void Zone1Metrol3_v1(object sender, RoutedEventArgs e)
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
                BigGhost_V2();
            }

        }



        public void ZombieMine2_v1(object sender, RoutedEventArgs e)
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



            for (int i = 0; i < 25; i++)
            {
                ZombieLayer1_V1();
            }
            ArmyReturnTop_ToSafeZone_GlobalMarket();

            ArmyReturnTop_ClickMarketButton_ForLaptop();

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

            ArmyReturnTop_ClickMarketButton_ForLaptop();
        }

        public void BigGhost1()
        {
            //LEFT TO RIGHT
            FlashAndAttackOrHeal(17600, VK_RIGHT);
            FlashAndAttackOrHeal(2400, VK_LEFT);
            StandingAttackOrHeal(2);
            // GET RIGHT CORNER ITEM
            FlashAndAttackOrHeal(1600, VK_RIGHT);
            // WAIT
            Thread.Sleep(30000);
            //RIGHT TO LEFT
            FlashAndAttackOrHeal(17600, VK_LEFT);
            FlashAndAttackOrHeal(2400, VK_RIGHT);
            StandingAttackOrHeal(2);
            // GET LEFT CORNER ITEM
            FlashAndAttackOrHeal(1600, VK_LEFT);
            // WAIT
            Thread.Sleep(30000);
        }

        public void BigGhost_V2()
        {
            //LEFT TO RIGHT
            FlashAndAttackOrHeal(17600, VK_RIGHT);
            FlashAndAttackOrHeal(1000, VK_LEFT);
            StandingAttackOrHeal(1);
            // GET RIGHT CORNER ITEM
            FlashAndAttackOrHeal(1000, VK_RIGHT);
            // MOVE TO FIRST
            Move(30000, VK_LEFT);
        }


        public void ZombieLayer1_V1()
        {
            //RIGHT TO LEFT
            MoveAndAttackOrHeal(40, VK_LEFT);
            Thread.Sleep(1500);
            //LEFT TO RIGHT 
            MoveAndAttackOrHeal(40, VK_RIGHT);
            Thread.Sleep(1500);
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
            Move(4000, VK_LEFT);
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


        public void ArmyReturnTop_ClickMarketButton_ForLaptop()
        {
            // 1280 X 720
            SetCursorPos(950, 700);
            SetCursorPos(950, 700);
            Thread.Sleep(50);
            // 模擬滑鼠左鍵點擊
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);

        }



        public void ArmyReturnTop_ClickMarketButton_ForDesktop()
        {
            // for 1920 X 1080 
            SetCursorPos(1450, 1040);
            SetCursorPos(1450, 1040);
            Thread.Sleep(50);
            // 模擬滑鼠左鍵點擊
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);

        }


        public void ArmyReturnTop_LeaveGlobalMarket()
        {
            // escape move lock
            Thread.Sleep(10000);
            Move(10000, VK_LEFT);
            MoveToPortal(2500, VK_RIGHT, 330);

        }



        public void ToyCityCloudDeck(object sender, RoutedEventArgs e)
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
                FlashMoveHolyLight(10000, VK_LEFT);
                FlashMoveHolyLight(1500, VK_RIGHT);

                FlashMoveHolyLight(1200, VK_UP);

                FlashMoveHolyLight(2000, VK_RIGHT);
                FlashMoveHolyLight(2000, VK_LEFT);

                FlashMoveHolyLight(1200, VK_DOWN);

                FlashMoveHolyLight(10000, VK_RIGHT);
                FlashMoveHolyLight(1200, VK_LEFT);

                FlashMoveHolyLight(2500, VK_UP);

                FlashMoveHolyLight(2000, VK_RIGHT);

                FlashMoveHolyLight(2000, VK_DOWN);
            }

        }


        public void prey(object sender, RoutedEventArgs e)
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
                UseBuff(VK_B);
                Thread.Sleep(3000);
                ArmyReturnTop_ClickMarketButton_ForDesktop();
                Thread.Sleep(10000);
                ArmyReturnTop_LeaveGlobalMarket();

            }
        }




        public void SandPDPrey(object sender, RoutedEventArgs e, bool r1920 = true, string inputkeys = "", int seconds = 240)
        {
            if (!isRunning)
            {
                // 啟動
                isRunning = true;
                cts = new CancellationTokenSource();
                Task.Run(() => DPrey(sender, e, cts.Token, r1920, inputkeys, seconds));

            }
            else
            {
                // 停止
                isRunning = false;
                cts.Cancel();

            }


        }
        public void DPrey(object sender, RoutedEventArgs e, CancellationToken token, bool r1920 = true, string inputkeys = "", int seconds = 240)
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

            try
            {
                while (!token.IsCancellationRequested)
                {
                    LoopUseBuff(inputkeys);
                    Thread.Sleep(3000);
                    if (r1920)
                    {
                        ArmyReturnTop_ClickMarketButton_ForDesktop();
                    }
                    else
                    {
                        ArmyReturnTop_ClickMarketButton_ForLaptop();
                    }
                    Thread.Sleep(seconds * 1000);
                    ArmyReturnTop_LeaveGlobalMarket();
                }
            }
            catch (OperationCanceledException)
            {
                // 被停止就直接跳出
            }
        }



        //-----------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------
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

        public void MoveAndAttackOrHeal(int times, byte direct)
        {
            keybd_event(direct, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            StandingAttackOrHeal(times);
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

        public void FlashMoveHolyLight(int time, byte direct)
        {

            keybd_event(VK_V, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            keybd_event(VK_D, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            keybd_event(direct, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            Thread.Sleep(time);
            keybd_event(VK_V, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            keybd_event(VK_D, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            keybd_event(direct, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up

        }

        public void UseBuff(byte key)
        {
            keybd_event(VK_B, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
            Thread.Sleep(1000);
            keybd_event(VK_B, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
        }

        public void LoopUseBuff(string s)
        {
            foreach (var item in s)
            {
                byte buff = _virtualKeyMap[item];
                keybd_event(buff, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Key Down
                Thread.Sleep(1000);
                keybd_event(buff, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Key Up
            }
        }



    }
}

