public class HelloWorldServices : IHelloWorldService{

    public string GetHellowWorld(){
        return "Hellow World!";
    }
}

public interface IHelloWorldService{
    string GetHellowWorld();
}
