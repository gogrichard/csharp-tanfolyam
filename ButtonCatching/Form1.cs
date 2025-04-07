namespace ButtonCatching;

using Logic;
using Timer = System.Windows.Forms.Timer;

public partial class Form1 : Form
{
    private Button _btnCatchMe;
    private Timer _moveTimer;
    private GameLogic _gameLogic;

    public Form1()
    {
        InitializeComponent();
        InitializeGame();
    }

    private void InitializeGame()
    {
        Text = "ButtonCatching";
        Size = new Size(600, 400);

        _gameLogic = new GameLogic();

        _btnCatchMe = new Button();
        _btnCatchMe.Text = "Start";
        _btnCatchMe.Size = new Size(100, 50);
        _btnCatchMe.Location = new Point(200, 150);
        _btnCatchMe.Click += BtnCatchMe_Click;

        Controls.Add(_btnCatchMe);

        _moveTimer = new Timer();
        _moveTimer.Interval = _gameLogic.Delay;
        _moveTimer.Tick += MoveTimer_Tick;
    }

    private void BtnCatchMe_Click(object? sender, EventArgs e)
    {
        _gameLogic.RegisterCatch();
        _btnCatchMe.Text = $"Catched: {_gameLogic.CatchCount}";

        MoveButtonToRandomPosition();

        _moveTimer.Interval = _gameLogic.Delay;
        _moveTimer.Start();
    }

    private void MoveTimer_Tick(object? sender, EventArgs e)
    {
        MoveButtonToRandomPosition();
    }

    private void MoveButtonToRandomPosition()
    {
        Point newPos = _gameLogic.GetRandomPosition(ClientSize, _btnCatchMe.Size);
        _btnCatchMe.Location = newPos;
    }
}