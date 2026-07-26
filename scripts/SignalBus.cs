using Godot;
using System;

public partial class SignalBus : Node
{
	public static SignalBus Instance;

	[Signal] public delegate void AppSelectedEventHandler();
	[Signal] public delegate void WindowFocusedEventHandler();
    [Signal] public delegate void CorruptionCompletedEventHandler();

    public override void _Ready()
    {
        Instance = this;
    }

}
