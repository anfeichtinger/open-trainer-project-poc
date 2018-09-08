using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Memory;
using System.Media;

namespace dead_cells_v1._0_trainer__11
{
    public partial class TrainerUI : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        public TrainerUI()
        {
            InitializeComponent();
            //Register Hotkeys Here!!
            //F1
            int F1Id = 1;
            int F1Key = (int)Keys.F1;
            Boolean F1Registered = RegisterHotKey(
                this.Handle, F1Id, 0x0000, F1Key
            );
            //F2
            int F2Id = 2;
            int F2Key = (int)Keys.F2;
            Boolean F2Registered = RegisterHotKey(
                this.Handle, F2Id, 0x0000, F2Key
            );
            //F3
            int F3Id = 3;
            int F3Key = (int)Keys.F3;
            Boolean F3Registered = RegisterHotKey(
                this.Handle, F3Id, 0x0000, F3Key
            );
            //F4
            int F4Id = 4;
            int F4Key = (int)Keys.F4;
            Boolean F4Registered = RegisterHotKey(
                this.Handle, F4Id, 0x0000, F4Key
            );
            //F5
            int F5Id = 5;
            int F5Key = (int)Keys.F5;
            Boolean F5Registered = RegisterHotKey(
                this.Handle, F5Id, 0x0000, F5Key
            );
            //F6
            int F6Id = 6;
            int F6Key = (int)Keys.F6;
            Boolean F6Registered = RegisterHotKey(
                this.Handle, F6Id, 0x0000, F6Key
            );
            //F7
            int F7Id = 7;
            int F7Key = (int)Keys.F7;
            Boolean F7Registered = RegisterHotKey(
                this.Handle, F7Id, 0x0000, F7Key
            );
            //F8
            int F8Id = 8;
            int F8Key = (int)Keys.F8;
            Boolean F8Registered = RegisterHotKey(
                this.Handle, F8Id, 0x0000, F8Key
            );
            //F9
            int F9Id = 9;
            int F9Key = (int)Keys.F9;
            Boolean F9Registered = RegisterHotKey(
                this.Handle, F9Id, 0x0000, F9Key
            );
            //F10
            int F10Id = 10;
            int F10Key = (int)Keys.F10;
            Boolean F10Registered = RegisterHotKey(
                this.Handle, F10Id, 0x0000, F10Key
            );
            //F11
            int F11Id = 11;
            int F11Key = (int)Keys.F11;
            Boolean F11Registered = RegisterHotKey(
                this.Handle, F11Id, 0x0000, F11Key
            );
        }
        //AoB Scan helper
        public async Task<long> ScanAOB(long start, long end, string search, bool writable, bool executable, string file = "")
        {
            return timeScan = (await mem.AoBScan(start, end, search, writable, executable)).FirstOrDefault();
        }
        //Allow Form to be dragged - open
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void TrainerUI_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //Allow Form to be dragged - close
        // ExitBtn - open
        private void exitBtn_Click(object sender, EventArgs e)
        {
            ResetVars(true);
            procCheckerAsync.CancelAsync();
            this.Close();
        }
        private void exitBtn_MouseHover(object sender, EventArgs e)
        {
            exitBtn.BackColor = Color.IndianRed;
        }
        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            exitBtn.BackColor = Color.Red;
        }
        // ExitBtn - close
        //Link to OpenTrainerProject on GitHub
        private void otpLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Pharrax/OpenTrainerProject");
        }

        public Mem mem = new Mem(); //For Reading and Writing Memory
        bool gameOpen = false; // Is game open?
        private int pID = 0; //Whats the ID of the process? 0 if none
        private SoundPlayer notActive = new SoundPlayer(dead_cells_v1._0_trainer__11.Properties.Resources.notactive);
        private SoundPlayer active = new SoundPlayer(dead_cells_v1._0_trainer__11.Properties.Resources.active);
        //For Timer
        private System.Timers.Timer hotkeyTimer;
        private int elapsedTime = 0;

        //Store what is active f1 + f2 not needed here
        bool fn3 = false;
        bool fn4 = false;
        bool fn5 = false;
        bool fn6 = false;
        bool fn7 = false;
        bool fn8 = false;
        bool fn9 = false;
        bool fn10 = false;
        bool fn11 = false;
        long timeScan = 0;
        long maxHealthScan = 0;
        long coolScan = 0;
        long ammoScan = 0;
        Thread threadUnlimitedHealth;
        Thread threadFreezeMoney;
        Thread threadFreezeCells;
        Thread threadInfJumps;
        Thread threadRunFaster;
        Thread threadInvisible;

        //What to do before UI loads
        private void TrainerUI_Load(object sender, EventArgs e)
        {
            //Start procCheck if it isn't running yet
            if (!procCheckerAsync.IsBusy)
            {
                procCheckerAsync.RunWorkerAsync();
                procCheckerAsync.WorkerSupportsCancellation = true;
                //Timer so you can't activate functions while others are busy to avoid crashes
                if (hotkeyTimer == null)
                {
                    hotkeyTimer = new System.Timers.Timer();
                    hotkeyTimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerTick);
                    hotkeyTimer.Interval = 1;
                    hotkeyTimer.Enabled = true;
                    hotkeyTimer.Start();
                }
            }
            loadTooltips();
        }
        //Init Tooltips on function hover
        private void loadTooltips()
        {
            //Function1
            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(function1, "sets your current money to the value you choose on the left.\nwill be shown once you collect or spend money\nplease confirm with enter");
            //Function2
            ToolTip toolTip2 = new ToolTip();
            toolTip2.ShowAlways = true;
            toolTip2.SetToolTip(function2, "sets your current cells to the value you choose on the left.\nwill be shown once you collect or spend money\nplease confirm with enter");
            //Function3
            ToolTip toolTip3 = new ToolTip();
            toolTip3.ShowAlways = true;
            toolTip3.SetToolTip(function3, "sets current and max health to 999999.\nshould be pretty stable but you will still die from curses");
            //Function4
            ToolTip toolTip4 = new ToolTip();
            toolTip4.ShowAlways = true;
            toolTip4.SetToolTip(function4, "freezes your current money value");
            //Function5
            ToolTip toolTip5 = new ToolTip();
            toolTip5.ShowAlways = true;
            toolTip5.SetToolTip(function5, "freezes your current cells value");
            //Function6
            ToolTip toolTip6 = new ToolTip();
            toolTip6.ShowAlways = true;
            toolTip6.SetToolTip(function6, "freezes the timer on the left side.\nsometimes doesn't work, restart game and trainer if that happens");
            //Function7
            ToolTip toolTip7 = new ToolTip();
            toolTip7.ShowAlways = true;
            toolTip7.SetToolTip(function7, "makes you invisible to most enemys, bosses will still see you\nthe game will crash if you finish or restart with this enabled!");
            //Function8
            ToolTip toolTip8 = new ToolTip();
            toolTip8.ShowAlways = true;
            toolTip8.SetToolTip(function8, "grants infinite jumps mid-air");
            //Function9
            ToolTip toolTip9 = new ToolTip();
            toolTip9.ShowAlways = true;
            toolTip9.SetToolTip(function9, "ammo for bows and such will not decrease");
            //Function10
            ToolTip toolTip10 = new ToolTip();
            toolTip10.ShowAlways = true;
            toolTip10.SetToolTip(function10, "no cooldown when using utilities or granades");
            //Function11
            ToolTip toolTip11 = new ToolTip();
            toolTip11.ShowAlways = true;
            toolTip11.SetToolTip(function11, "increases your running speed");
        }
        //Count time
        private void TimerTick(object sender, EventArgs e)
        {
            if (elapsedTime < 70)
            elapsedTime += 1;
        }
        //Continously check if the game is running
        private void CheckForProc(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                while (!gameOpen)
                {
                    //Check for game proc
                    if (pID == 0)
                    {
                        pID = mem.getProcIDFromName("deadcells");
                    }
                    // If proc found, open it
                    if (pID > 0)
                    {
                        gameOpen = mem.OpenProcess(pID);
                    }
                    //If successfully opened update ui
                    if (gameOpen)
                    {
                        gameOpen = true;
                        //Update UI -> Game Running
                        gameStatus.BeginInvoke((Action)(() => gameStatus.Text = "GAME RUNNING, ID: 0x" + pID.ToString("X4")));
                    }
                    else
                    {
                        gameOpen = false;
                    }
                    Thread.Sleep(1000);
                }
                //Check for change of processID
                if (pID != mem.getProcIDFromName("deadcells"))
                {
                    //If it's a different start search for new processID
                    ResetVars(false);
                    gameStatus.BeginInvoke((Action)(() => gameStatus.Text = "GAME NOT RUNNING"));
                }
                Thread.Sleep(1000);
            }
        }
        //Reset Variables
        private void ResetVars(bool disable)
        {
            gameOpen = false;
            pID = 0;
            fn3 = false;
            fn4 = false;
            fn5 = false;
            fn6 = false;
            fn7 = false;
            fn8 = false;
            fn9 = false;
            fn10 = false;
            fn11 = false;
            timeScan = 0;
            ammoScan = 0;
            coolScan = 0;

            function2.ForeColor = Color.White;
            hotkey2.ForeColor = Color.White;
            function3.ForeColor = Color.White;
            hotkey3.ForeColor = Color.White;
            function4.ForeColor = Color.White;
            hotkey4.ForeColor = Color.White;
            function5.ForeColor = Color.White;
            hotkey5.ForeColor = Color.White;
            function6.ForeColor = Color.White;
            hotkey6.ForeColor = Color.White;
            function7.ForeColor = Color.White;
            hotkey7.ForeColor = Color.White;
            function8.ForeColor = Color.White;
            hotkey8.ForeColor = Color.White;
            function9.ForeColor = Color.White;
            hotkey9.ForeColor = Color.White;
            function10.ForeColor = Color.White;
            hotkey10.ForeColor = Color.White;
            function11.ForeColor = Color.White;
            hotkey11.ForeColor = Color.White;

            if (disable)
            {
                mem.writeMemory(timeScan.ToString("x8").ToUpper(), "bytes", "0xF2 0x0F 0x11 0x70 0x28 0x83 0xEC 0x0C 0xFF");
                mem.writeMemory(ammoScan.ToString("x8").ToUpper(), "bytes", "0x89 0x42 0x18");
                mem.writeMemory(coolScan.ToString("x8").ToUpper(), "bytes", "0xF2 0x0F 0x11 0x59 0x78");
            }
        }
        //React on hotkeys here!!
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                if (elapsedTime >= 70)
                {
                    if (gameOpen)
                    {
                        switch (id)
                        {
                            case 1:
                                elapsedTime = 0;
                                mem.writeMemory("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x5C,0x34", "int", fn1Value.Text);
                                SoundPlayer money = new SoundPlayer(dead_cells_v1._0_trainer__11.Properties.Resources.money);
                                money.Play();
                                money.Dispose();
                                break;
                            case 2:
                                elapsedTime = 0;
                                mem.writeMemory("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x64,0x31C", "int", fn2Value.Text);
                                SoundPlayer cells = new SoundPlayer(dead_cells_v1._0_trainer__11.Properties.Resources.cells);
                                cells.Play();
                                cells.Dispose();
                                break;
                            case 3:
                                elapsedTime = 0;
                                //Init Thread for freezing if it doesn't exist yet
                                if (threadUnlimitedHealth == null)
                                {
                                    threadUnlimitedHealth = new Thread(() =>
                                    {
                                        Thread.CurrentThread.IsBackground = true;
                                        Thread.CurrentThread.Name = "threadUnlimitedHealth";
                                        while (true)
                                        {
                                            if (fn3)
                                            {
                                                //Current Health
                                                mem.writeMemory("libhl.dll+0x0002D1A8,0x448,0x8,0x58,0x64,0xD8", "int", "999999");
                                                //Max Health
                                                mem.writeMemory("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x64,0xDC", "int", "999999");
                                                Thread.Sleep(200);
                                            }
                                            else
                                            {
                                                Thread.Sleep(200);
                                                continue;
                                            }
                                        }
                                    });
                                }
                                if (fn3)
                                {
                                    function3.ForeColor = Color.White;
                                    hotkey3.ForeColor = Color.White;
                                    if (maxHealthScan == 0)
                                    {
                                        maxHealthScan = ScanAOB(0x09000000, 0x0A000000, "89 88 DC 00 00 00 8B 88", true, true).Result;
                                    }
                                    mem.writeMemory(maxHealthScan.ToString("x8").ToUpper(),
                                        "bytes", "0x89 0x88 0xDC 0x00 0x00 0x00");
                                    fn3 = !fn3;
                                    notActive.Play();
                                }
                                else
                                {
                                    function3.ForeColor = Color.Red;
                                    hotkey3.ForeColor = Color.Red;
                                    fn3 = !fn3;
                                    if (!threadUnlimitedHealth.IsAlive) threadUnlimitedHealth.Start();
                                    if (maxHealthScan == 0)
                                    {
                                        maxHealthScan = ScanAOB(0x09000000, 0x0A000000, "89 88 DC 00 00 00 8B 88", true, true).Result;
                                    }
                                    mem.writeMemory(maxHealthScan.ToString("x8").ToUpper(), "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
                                    active.Play();
                                }
                                break;
                            case 4:
                                elapsedTime = 0;
                                //Init Thread for freezing if it doesn't exist yet
                                if (threadFreezeMoney == null)
                                {
                                    threadFreezeMoney = new Thread(() =>
                                    {
                                        Thread.CurrentThread.IsBackground = true;
                                        Thread.CurrentThread.Name = "threadFreezeMoney";

                                        string moneyVal = "";
                                        while (true)
                                        {
                                            if (moneyVal.Equals("")) moneyVal = mem.readInt("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x5C,0x34").ToString();
                                            if (fn4)
                                            {
                                                //Write value above every 300ms
                                                mem.writeMemory("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x5C,0x34", "int", moneyVal);
                                                Thread.Sleep(300);
                                            }
                                            else
                                            {
                                                moneyVal = "";
                                                Thread.Sleep(300);
                                                continue;
                                            }
                                        }
                                    });
                                }
                                if (fn4)
                                {
                                    function4.ForeColor = Color.White;
                                    hotkey4.ForeColor = Color.White;
                                    fn4 = !fn4;
                                    notActive.Play();
                                }
                                else
                                {
                                    function4.ForeColor = Color.Red;
                                    hotkey4.ForeColor = Color.Red;
                                    fn4 = !fn4;
                                    if (!threadFreezeMoney.IsAlive) threadFreezeMoney.Start();
                                    active.Play();
                                }
                                break;
                            case 5:
                                elapsedTime = 0;
                                //Init Thread for freezing if it doesn't exist yet
                                if (threadFreezeCells == null)
                                {
                                    threadFreezeCells = new Thread(() =>
                                    {
                                        Thread.CurrentThread.IsBackground = true;
                                        Thread.CurrentThread.Name = "threadFreezeCells";

                                        string cellsVal = "";
                                        while (true)
                                        {
                                            if (cellsVal.Equals("")) cellsVal = mem.readInt("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x64,0x31C").ToString();
                                            if (fn5)
                                            {
                                                //Write value above every 300ms
                                                mem.writeMemory("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x64,0x31C", "int", cellsVal);
                                                Thread.Sleep(300);
                                            }
                                            else
                                            {
                                                cellsVal = "";
                                                Thread.Sleep(300);
                                                continue;
                                            }
                                        }
                                    });
                                }
                                if (fn5)
                                {
                                    function5.ForeColor = Color.White;
                                    hotkey5.ForeColor = Color.White;
                                    fn5 = !fn5;
                                    notActive.Play();
                                }
                                else
                                {
                                    function5.ForeColor = Color.Red;
                                    hotkey5.ForeColor = Color.Red;
                                    fn5 = !fn5;
                                    if (!threadFreezeCells.IsAlive) threadFreezeCells.Start();
                                    active.Play();
                                }
                                break;
                            case 6:
                                elapsedTime = 0;
                                if (fn6)
                                {
                                    function6.ForeColor = Color.White;
                                    hotkey6.ForeColor = Color.White;
                                    //AoB Scan
                                    if (timeScan == 0)
                                    {
                                        timeScan = ScanAOB(0x09000000, 0x0A000000, "F2 0F 11 70 28 83 EC 0C FF", true, true).Result;
                                    }
                                    mem.writeMemory(timeScan.ToString("x8").ToUpper(), "bytes", "0xF2 0x0F 0x11 0x70 0x28 0x83 0xEC 0x0C 0xFF");
                                    fn6 = !fn6;
                                    notActive.Play();
                                }
                                else
                                {
                                    function6.ForeColor = Color.Red;
                                    hotkey6.ForeColor = Color.Red;
                                    //AoB Scan
                                    if (timeScan == 0)
                                    {
                                        timeScan = ScanAOB(0x09000000, 0x0A000000, "F2 0F 11 70 28 83 EC 0C FF", true, true).Result;
                                    }
                                    //Replace with code that does nothing
                                    mem.writeMemory(timeScan.ToString("x8").ToUpper(), "bytes", "0x90 0x90 0x90 0x90 0x90");
                                    fn6 = !fn6;
                                    active.Play();
                                }
                                break;
                            case 7:
                                elapsedTime = 0;
                                //Init Thread if it doesn't exist yet
                                if (threadInvisible == null)
                                {
                                    threadInvisible = new Thread(() =>
                                    {
                                        Thread.CurrentThread.IsBackground = true;
                                        Thread.CurrentThread.Name = "threadInvisible";
                                        while (true)
                                        {
                                            if (fn7)
                                            {
                                                mem.writeMemory("libhl.dll+0002D1A8,0x580,0x0,0x18,0x64,0x130,0x8,0x11E", "int", "16470");
                                                Thread.Sleep(100);
                                            }
                                            else
                                            {
                                                Thread.Sleep(300);
                                                continue;
                                            }
                                        }
                                    });
                                }
                                if (fn7)
                                {
                                    function7.ForeColor = Color.White;
                                    hotkey7.ForeColor = Color.White;
                                    fn7 = !fn7;
                                    mem.writeMemory("libhl.dll+0002D1A8,0x580,0x0,0x18,0x64,0x130,0x8,0x11E", "int", "49136");
                                    notActive.Play();
                                }
                                else
                                {
                                    function7.ForeColor = Color.Red;
                                    hotkey7.ForeColor = Color.Red;
                                    fn7 = !fn7;
                                    if (!threadInvisible.IsAlive) threadInvisible.Start();
                                    active.Play();
                                }
                                break;
                            case 8:
                                elapsedTime = 0;
                                //Init Thread for freezing if it doesn't exist yet
                                if (threadInfJumps == null)
                                {
                                    threadInfJumps = new Thread(() =>
                                    {
                                        Thread.CurrentThread.IsBackground = true;
                                        Thread.CurrentThread.Name = "threadInfJumps";
                                        while (true)
                                        {
                                            if (fn8)
                                            {
                                                //Write value every 150ms
                                                mem.writeMemory("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x64,0x290", "int", "0");
                                                Thread.Sleep(150);
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                    });
                                }
                                if (fn8)
                                {
                                    function8.ForeColor = Color.White;
                                    hotkey8.ForeColor = Color.White;
                                    fn8 = !fn8;
                                    notActive.Play();
                                }
                                else
                                {
                                    function8.ForeColor = Color.Red;
                                    hotkey8.ForeColor = Color.Red;
                                    fn8 = !fn8;
                                    if (!threadInfJumps.IsAlive) threadInfJumps.Start();
                                    active.Play();
                                }
                                break;
                            case 9:
                                elapsedTime = 0;
                                if (fn9)
                                {
                                    function9.ForeColor = Color.White;
                                    hotkey9.ForeColor = Color.White;
                                    //AoB Scan
                                    if (ammoScan == 0)
                                    {
                                        ammoScan = ScanAOB(0x09000000, 0x0A000000, "89 ?? 18 8B ?? 08 8B ?? 04 89 ?? 94", true, true).Result;
                                    }
                                    mem.writeMemory(ammoScan.ToString("x8").ToUpper(), "bytes", "0x89 0x42 0x18");
                                    fn9 = !fn9;
                                    notActive.Play();
                                }
                                else
                                {
                                    function9.ForeColor = Color.Red;
                                    hotkey9.ForeColor = Color.Red;
                                    //AoB Scan
                                    if (ammoScan == 0)
                                    {
                                        ammoScan = ScanAOB(0x09000000, 0x0A000000, "89 ?? 18 8B ?? 08 8B ?? 04 89 ?? 94", true, true).Result;
                                    }
                                    //Replace with code that does nothing
                                    mem.writeMemory(ammoScan.ToString("x8").ToUpper(), "bytes", "0x90 0x90 0x90");
                                    fn9 = !fn9;
                                    active.Play();
                                }
                                break;
                            case 10:
                                elapsedTime = 0;
                                if (fn10)
                                {
                                    function10.ForeColor = Color.White;
                                    hotkey10.ForeColor = Color.White;
                                    //AoB Scan
                                    if (coolScan == 0)
                                    {
                                        coolScan = ScanAOB(0x09000000, 0x0A000000, "F2 0F 11 59 78 8B 45", true, true).Result;
                                    }
                                    mem.writeMemory(coolScan.ToString("x8").ToUpper(), "bytes", "0xF2 0x0F 0x11 0x59 0x78");
                                    fn10 = !fn10;
                                    notActive.Play();
                                }
                                else
                                {
                                    function10.ForeColor = Color.Red;
                                    hotkey10.ForeColor = Color.Red;
                                    //AoB Scan
                                    if (coolScan == 0)
                                    {
                                        coolScan = ScanAOB(0x09000000, 0x0A000000, "F2 0F 11 59 78 8B 45", true, true).Result;
                                    }
                                    //Replace with code that does nothing
                                    mem.writeMemory(coolScan.ToString("x8").ToUpper(), "bytes", "0x90 0x90 0x90 0x90 0x90");
                                    fn10 = !fn10;
                                    active.Play();
                                }
                                break;
                            case 11:
                                elapsedTime = 0;
                                //Init Thread for freezing if it doesn't exist yet
                                if (threadRunFaster == null)
                                {
                                    threadRunFaster = new Thread(() =>
                                    {
                                        Thread.CurrentThread.IsBackground = true;
                                        Thread.CurrentThread.Name = "threadRunFaster";
                                        while (true)
                                        {
                                            if (fn11)
                                            {
                                                mem.writeMemory("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x64,0x2A8", "int", "8");
                                                Thread.Sleep(1000);
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                    });
                                }
                                if (fn11)
                                {
                                    function11.ForeColor = Color.White;
                                    hotkey11.ForeColor = Color.White;
                                    fn11 = !fn11;
                                    mem.writeMemory("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x64,0x2A8", "int", "0");
                                    notActive.Play();
                                }
                                else
                                {
                                    function11.ForeColor = Color.Red;
                                    hotkey11.ForeColor = Color.Red;
                                    fn11 = !fn11;
                                    if (!threadRunFaster.IsAlive) threadRunFaster.Start();
                                    active.Play();
                                }
                                break;
                        }
                    }
                    else
                    {
                        elapsedTime = 0;
                        SoundPlayer notfound = new SoundPlayer(dead_cells_v1._0_trainer__11.Properties.Resources.notfound);
                        notfound.Play();
                    }
                }
            }
            base.WndProc(ref m);
        }
    }
}