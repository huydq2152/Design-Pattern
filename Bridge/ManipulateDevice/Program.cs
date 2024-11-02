public interface IDevice
{
    void TurnOn();
    void TurnOff();
    void SetChannel(int channel);
    void SetVolume(int volume);
}

public class TV : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("Turn on TV");
    }

    public void TurnOff()
    {
        Console.WriteLine("Turn off TV");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine($"Set channel of TV to {channel}");
    }

    public void SetVolume(int volume)
    {
        Console.WriteLine($"Set volume of TV to {volume}");
    }
}

public class AirConditioner : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("Turn on Air Conditioner");
    }

    public void TurnOff()
    {
        Console.WriteLine("Turn off Air Conditioner");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine("Air Conditioner npt support set channel function");
    }

    public void SetVolume(int volume)
    {
        Console.WriteLine($"Set volume of Air Conditioner to {volume}");
    }
}

public abstract class RemoteControl
{
    protected IDevice device;

    public RemoteControl(IDevice device)
    {
        this.device = device;
    }

    public void TurnOn()
    {
        device.TurnOn();
    }

    public void TurnOff()
    {
        device.TurnOff();
    }

    public void SetChannel(int channel)
    {
        device.SetChannel(channel);
    }

    public void SetVolume(int volume)
    {
        device.SetVolume(volume);
    }
}

public class BasicRemote : RemoteControl
{
    public BasicRemote(IDevice device) : base(device)
    {
    }
}

public class AdvancedRemote : RemoteControl
{
    public AdvancedRemote(IDevice device) : base(device)
    {
    }

    public void SetTimer(int hours)
    {
        Console.WriteLine($"Set time to turn off device after {hours} hours.");
    }
}

public static class Program
{
    public static void Main()
    {
        var tv = new TV();
        var basicRemoteOfTV = new BasicRemote(tv);
        var advancedRemoteOfTV = new AdvancedRemote(tv);
        basicRemoteOfTV.TurnOn();
        basicRemoteOfTV.TurnOff();
        basicRemoteOfTV.SetChannel(7);
        advancedRemoteOfTV.TurnOn();
        advancedRemoteOfTV.TurnOff();
        advancedRemoteOfTV.SetVolume(25);
        advancedRemoteOfTV.SetTimer(2);

        var ac = new AirConditioner();
        var basicRemoteOfAC = new BasicRemote(ac);
        var advancedRemoteOfAC = new AdvancedRemote(ac);
        basicRemoteOfAC.TurnOn();
        basicRemoteOfAC.TurnOff();
        basicRemoteOfAC.SetChannel(7);
        advancedRemoteOfAC.TurnOn();
        advancedRemoteOfAC.TurnOff();
        advancedRemoteOfAC.SetVolume(25);
        advancedRemoteOfAC.SetTimer(2);
    }
}

// Use bridge design pattern to separate device part (implementation) and manipulate part (abstract)