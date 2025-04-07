namespace ButtonCatching.Logic;

using System;
using System.Drawing;

public class GameLogic
{
    private readonly Random _random = new();
    public int CatchCount { get; private set; } = 0;
    public int Delay { get; private set; } = 2000;
    public int MinDelay { get; set; } = 500;
    public int DelayStep { get; set; } = 100;

    public void RegisterCatch()
    {
        CatchCount++;
        if (Delay > MinDelay)
        {
            Delay -= DelayStep;
        }
    }

    public Point GetRandomPosition(Size clientSize, Size buttonSize)
    {
        int maxX = clientSize.Width - buttonSize.Width;
        int maxY = clientSize.Height - buttonSize.Height;
        return new Point(_random.Next(maxX), _random.Next(maxY));
    }
}