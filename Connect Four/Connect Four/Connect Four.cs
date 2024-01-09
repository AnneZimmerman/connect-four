namespace Connect_Four
{
    public partial class frmConnectFour : Form
    {
        enum TurnEnum { Blue, Green };
        TurnEnum currentturn = TurnEnum.Blue;

        enum GameStatusEnum { NotStarted, Playing, Tie, Winner };
        GameStatusEnum gamestatus = GameStatusEnum.NotStarted;

        List<Label> lstlabels;
        List<List<Label>> lstwinningsets;
        List<Button> lstbuttons;

        Color c = default(Color);
        string s = "";

        public frmConnectFour()
        {
            InitializeComponent();
            lstlabels = new() {
                lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9, lbl10,
                lbl11, lbl12, lbl13, lbl14, lbl15, lbl16, lbl17, lbl18, lbl19, lbl20, lbl21, lbl22,
                lbl23, lbl24, lbl25, lbl26, lbl27, lbl28, lbl29, lbl30, lbl31, lbl32, lbl33, lbl34,
                lbl35, lbl36, lbl37, lbl38, lbl39, lbl40, lbl41, lbl42
            };
            lstwinningsets = new() {
                new(){lbl1, lbl2, lbl3, lbl4}, new(){lbl2, lbl3, lbl4, lbl5},
                new(){lbl3, lbl4, lbl5, lbl6}, new(){lbl4, lbl5, lbl6, lbl7},
                new(){lbl8, lbl9, lbl10, lbl11}, new(){lbl9, lbl10, lbl11, lbl12},
                new(){lbl10, lbl11, lbl12, lbl13}, new(){lbl11, lbl12, lbl13, lbl14},
                new(){lbl15, lbl16, lbl17, lbl18}, new(){lbl16, lbl17, lbl18, lbl19},
                new(){lbl17, lbl18, lbl19, lbl20}, new(){lbl18, lbl19, lbl20, lbl21},
                new(){lbl22, lbl23, lbl24, lbl25}, new(){lbl23, lbl24, lbl25,lbl26},
                new(){lbl24, lbl25, lbl26, lbl27}, new(){lbl25, lbl26, lbl27, lbl28},
                new(){lbl29, lbl30, lbl31, lbl32}, new(){lbl30, lbl31, lbl32, lbl33},
                new(){lbl31, lbl32, lbl33, lbl34}, new(){lbl32, lbl33, lbl34, lbl35},
                new(){lbl36, lbl37, lbl38, lbl39}, new(){lbl37, lbl38, lbl39, lbl40},
                new(){lbl38, lbl39, lbl40, lbl41}, new(){lbl39, lbl40, lbl41, lbl42},
                new(){lbl1, lbl8, lbl15, lbl22}, new(){lbl8, lbl15, lbl22, lbl29},
                new(){lbl15, lbl22, lbl29, lbl36}, new(){lbl2, lbl9, lbl16, lbl23},
                new(){lbl9, lbl16, lbl23, lbl30}, new(){lbl16, lbl23, lbl30, lbl37},
                new(){lbl3, lbl10, lbl17, lbl24}, new(){lbl10, lbl17, lbl24, lbl31},
                new(){lbl17, lbl24, lbl31, lbl38}, new(){lbl4, lbl11, lbl18, lbl25},
                new(){lbl11, lbl18, lbl25, lbl32}, new(){lbl18, lbl25, lbl32, lbl39},
                new(){lbl5, lbl12, lbl19, lbl26}, new(){lbl12, lbl19, lbl26, lbl33},
                new(){lbl19, lbl26, lbl33, lbl40}, new(){lbl6, lbl13, lbl20, lbl27},
                new(){lbl13, lbl20, lbl27, lbl34}, new(){ lbl20, lbl27, lbl34, lbl41},
                new(){lbl7, lbl14, lbl21, lbl28}, new(){lbl14, lbl21, lbl28, lbl35},
                new(){lbl21, lbl28, lbl35, lbl42}, new(){lbl39, lbl33, lbl27, lbl21},
                new(){lbl38, lbl32, lbl26, lbl20}, new(){lbl32, lbl26, lbl20, lbl14},
                new(){lbl37, lbl31, lbl25, lbl19}, new(){lbl31, lbl25, lbl19, lbl13},
                new(){lbl25, lbl19, lbl13, lbl7}, new(){lbl36, lbl30, lbl24, lbl18},
                new(){lbl30, lbl24, lbl18, lbl12}, new(){lbl24, lbl18, lbl12, lbl6},
                new(){lbl29, lbl23, lbl17, lbl11}, new(){lbl23, lbl17, lbl11, lbl5},
                new(){lbl22, lbl16, lbl10, lbl4}, new(){lbl39, lbl31, lbl23, lbl15},
                new(){lbl40, lbl32, lbl24, lbl16}, new(){lbl32, lbl24, lbl16, lbl8},
                new(){lbl41, lbl33, lbl25, lbl17}, new(){lbl33, lbl25, lbl17, lbl9},
                new(){lbl25, lbl17, lbl9, lbl1}, new(){lbl42, lbl34, lbl26, lbl18},
                new(){lbl34, lbl26, lbl18, lbl10}, new(){lbl26, lbl18, lbl10, lbl2},
                new(){lbl35, lbl27, lbl19, lbl11}, new(){lbl27, lbl19, lbl11, lbl3},
                new(){lbl28, lbl20, lbl12, lbl4}
            };
            lstbuttons = new() { btn1, btn2, btn3, btn4, btn5, btn6, btn7 };
            lstbuttons.ForEach(b => b.Enabled = false);
            btnStart.Click += BtnStart_Click;
            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            btn4.Click += Btn4_Click;
            btn5.Click += Btn5_Click;
            btn6.Click += Btn6_Click;
            btn7.Click += Btn7_Click;
            DisplayStatus();
        }

        private void StartGame()
        {
            lstbuttons.ForEach(b => b.Enabled = true);
            lstlabels.ForEach(b => b.BackColor = Color.FloralWhite);
            lstlabels.ForEach(b => b.Text = "");
            currentturn = TurnEnum.Blue;
            gamestatus = GameStatusEnum.Playing;
            DisplayStatus();
        }

        private void DisplayStatus()
        {
            string msg = "Click Start to begin Game";
            switch (gamestatus)
            {
                case GameStatusEnum.Playing:
                    msg = "Current Turn: " + currentturn.ToString();
                    break;
                case GameStatusEnum.Tie:
                    msg = "Tie";
                    break;
                case GameStatusEnum.Winner:
                    msg = "Winner is: " + currentturn.ToString();
                    break;
            }
            lblStatus.Text = msg;
        }

        private void SetBackColor()
        {
            if (currentturn == TurnEnum.Blue)
            {
                c = Color.Blue;
                s = "Blue";
            }
            else
            {
                c = Color.Green;
                s = "Green";
            }
        }
//AS These two procedures to detect winner and tie can be combined with 2 separate if statements. Make the param in the paretheses optional so that you don't need to pass it in for delect tie.(DONE)
        private void DetectWinnerorTie(List<Label> lst = null)
        {
            if (lst.Count(b => b.Text == currentturn.ToString()) == lst.Count())
            {
                gamestatus = GameStatusEnum.Winner;
                lst.ForEach(b => b.BackColor = Color.Azure);
            }
            else if (lstlabels.Count(b => b.Text == "") == 0)
            {
                lstlabels.ForEach(b => b.BackColor = Color.PeachPuff);
                gamestatus = GameStatusEnum.Tie;
            }
        }

        private void FillSpace(Label l1, Label l2, Label l3, Label l4, Label l5, Label l6, Button b1)
        {
            if (gamestatus == GameStatusEnum.Playing)
            {
                SetBackColor();
                
                if (l5.BackColor != Color.FloralWhite)
                {
                    l6.BackColor = c;
                    l6.Text = s;
                    b1.Enabled = false;
                }
                else if (l4.BackColor != Color.FloralWhite)
                {
                    l5.BackColor = c;
                    l5.Text = s;
                }
                else if (l3.BackColor != Color.FloralWhite)
                {
                    l4.BackColor = c;
                    l4.Text = s;
                }
                else if (l2.BackColor != Color.FloralWhite)
                {
                    l3.BackColor = c;
                    l3.Text = s;
                }
                else if (l1.BackColor != Color.FloralWhite)
                {
                    l2.BackColor = c;
                    l2.Text = s;
                }
                else
                {
                    l1.BackColor = c;
                    l1.Text = s;
                }
                lstwinningsets.ForEach(l => DetectWinnerorTie(l));
                if (gamestatus == GameStatusEnum.Winner)
                {
                    lstbuttons.ForEach(b => b.Enabled = false);
                }
                if (gamestatus == GameStatusEnum.Playing)
                {
                        if (currentturn == TurnEnum.Blue)
                        {
                            currentturn = TurnEnum.Green;
                        }
                        else
                        {
                            currentturn = TurnEnum.Blue;
                        }
                }
            }
            DisplayStatus();
        }

        private void Btn7_Click(object? sender, EventArgs e)
        {
            FillSpace(lbl42, lbl35, lbl28, lbl21, lbl14, lbl7, btn7);
        }

        private void Btn6_Click(object? sender, EventArgs e)
        {
            FillSpace(lbl41, lbl34, lbl27, lbl20, lbl13, lbl6, btn6);
        }

        private void Btn5_Click(object? sender, EventArgs e)
        {
            FillSpace(lbl40, lbl33, lbl26, lbl19, lbl12, lbl5, btn5);
        }

        private void Btn4_Click(object? sender, EventArgs e)
        {
            FillSpace(lbl39, lbl32, lbl25, lbl18, lbl11, lbl4, btn4);
        }

        private void Btn3_Click(object? sender, EventArgs e)
        {
            FillSpace(lbl38, lbl31, lbl24, lbl17, lbl10, lbl3, btn3);
        }

        private void Btn2_Click(object? sender, EventArgs e)
        {
            FillSpace(lbl37, lbl30, lbl23, lbl16, lbl9, lbl2, btn2);
        }

        private void Btn1_Click(object? sender, EventArgs e)
        {
            FillSpace(lbl36, lbl29, lbl22, lbl15, lbl8, lbl1, btn1);
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            StartGame();
        }
    }
}