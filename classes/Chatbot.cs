public class Chatbot
{
    public string catagory { get; set; }
    public List<string> userInputs { get; set; }
    public List<string> botResponses { get; set; }

    public Chatbot(string catagory, List<string> userInputs, List<string> botResponses)
    {
        this.catagory = catagory;
        this.userInputs = userInputs;
        this.botResponses = botResponses;
    }
}
