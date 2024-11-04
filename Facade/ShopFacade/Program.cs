namespace ShopFacade;

public class LoginService
{
    public void LoginFb(string userName)
    {
        Console.WriteLine(userName + "Login Facebook");
    }

    public void LoginYoutube(string userName)
    {
        Console.WriteLine(userName + "Login Youtube");
    }

    public void LoginGithub(string userName)
    {
        Console.WriteLine(userName + "Login Github");
    }
}

public class PaymentService
{
    public void PayByPayPal()
    {
        Console.WriteLine("Pay by PayPal");
    }

    public void PayByMoMo()
    {
        Console.WriteLine("Pay by MoMo");
    }

    public void PayByDebitCard()
    {
        Console.WriteLine("Pay by debit card");
    }
}

public class ShipService
{
    public void NowShip()
    {
        Console.WriteLine("Now Ship");
    }

    public void GrabShip()
    {
        Console.WriteLine("Grab Ship");
    }

    public void NinjaVanShip()
    {
        Console.WriteLine("Ninja Van Ship");
    }
}

public class NotificationService
{
    public void NotifyViaSms()
    {
        Console.WriteLine("Notification SMS");
    }

    public void NotifyViaSmsGmail()
    {
        Console.WriteLine("Notification Gmail");
    }
}

public class ShopFacade
{
    private readonly LoginService _loginService;
    private readonly PaymentService _paymentService;
    private readonly ShipService _shipService;
    private readonly NotificationService _notificationService;


    public ShopFacade(LoginService loginService, PaymentService paymentService, ShipService shipService,
        NotificationService notificationService)
    {
        _loginService = loginService;
        _paymentService = paymentService;
        _shipService = shipService;
        _notificationService = notificationService;
    }

    public void BuyProductByMoMoWithGrabShipping(string name)
    {
        _loginService.LoginFb(name);
        _paymentService.PayByMoMo();
        _shipService.GrabShip();
        _notificationService.NotifyViaSms();
    }

    public void BuyProductByPayPalWithNinjaVanShipping(string name)
    {
        _loginService.LoginGithub(name);
        _paymentService.PayByPayPal();
        _shipService.NinjaVanShip();
        _notificationService.NotifyViaSmsGmail();
    }
}

public static class Program
{
    public static void Main()
    {
        var shopFacade = new ShopFacade(new LoginService(), new PaymentService(), new ShipService(),
            new NotificationService());
        shopFacade.BuyProductByMoMoWithGrabShipping("Nick");
        Console.WriteLine("----------------------------------------");
        shopFacade.BuyProductByPayPalWithNinjaVanShipping("Nick");
    }
}