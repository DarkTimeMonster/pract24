namespace ConsoleApp6;

public class Automat
{
    protected string currentState;
    
    protected Dictionary<(string, string), string> transitions;

    public Automat()
    {
        currentState = "a";
        transitions = new Dictionary<(string, string), string>
        {
            { ("a", "012"), "b" },
            { ("a", "210"), "b" },
            { ("b", "012"), "a" },
            { ("b", "211"), "a" },
            { ("a", "110"), "a" },
            { ("b", "111"), "b" }
        };
    }

    public void ProcessInput(string input)
    {
        if (transitions.TryGetValue((currentState, input), out string nextState))
        {
            Console.WriteLine($"Переход: {currentState} -> {nextState} по входу {input}");
            currentState = nextState;
        }
        else
        {
            Console.WriteLine($"Нет перехода из состояния {currentState} по входу {input}");
        }
    }

    public string GetCurrentState()
    {
        return currentState;
    }
}