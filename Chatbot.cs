public class Chatbot
{
    public string userInput { get; set; }
    public string botResponse { get; set; }
    public Chatbot(string userInput, string botResponse)
    {
        this.userInput = userInput;
        this.botResponse = botResponse;
    }
}