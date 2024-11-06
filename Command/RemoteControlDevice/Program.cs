//Command interface

public interface ICommand
{
    void Execute();
}

public class TurnOnTVCommand : ICommand
{
    private TV _tv;

    public TurnOnTVCommand(TV tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.TurnOn();
    }
}

public class TurnOffTVCommand : ICommand
{
    private TV _tv;

    public TurnOffTVCommand(TV tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.TurnOff();
    }
}

public class IncreaseVolumeCommand : ICommand
{
    private TV _tv;
    private int _volume;

    public IncreaseVolumeCommand(TV tv, int volume)
    {
        _tv = tv;
        _volume = volume;
    }

    public void Execute()
    {
        _tv.IncreaseVolume(_volume);
    }
}

public class DecreaseVolumeCommand : ICommand
{
    private TV _tv;
    private int _volume;

    public DecreaseVolumeCommand(TV tv, int volume)
    {
        _tv = tv;
        _volume = volume;
    }

    public void Execute()
    {
        _tv.DecreaseVolume(_volume);
    }
}

// Receiver
public class TV
{
    public void TurnOn()
    {
        Console.WriteLine("Turn on tv");
    }

    public void TurnOff()
    {
        Console.WriteLine("Turn off tv");
    }

    public void IncreaseVolume(int volumn)
    {
        Console.WriteLine($"Increase volumn to {volumn}");
    }

    public void DecreaseVolume(int volumn)
    {
        Console.WriteLine($"Decrease volumn to {volumn}");
    }
}

// Invoker
public class Remote
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TV tv = new TV();
        Remote remote = new Remote();

        remote.SetCommand(new TurnOnTVCommand(tv));
        remote.PressButton();

        remote.SetCommand(new IncreaseVolumeCommand(tv, 60));
        remote.PressButton();

        remote.SetCommand(new DecreaseVolumeCommand(tv, 10));
        remote.PressButton();

        remote.SetCommand(new TurnOffTVCommand(tv));
        remote.PressButton();
    }
}