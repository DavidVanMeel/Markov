namespace Markov
{
    internal class Program
    {
        private const string trainingDataURL = "C:\\Users\\david\\source\\repos\\Markov\\Markov\\Training data.txt";
        static void Main(string[] args)
        {
            bool exit = false;
            string command = "";

            //genereer de Markov chains o.b.v. trainingdata
            MarkovChain wordChain = new MarkovChain(".", trainingDataURL, ".");
            MarkovChain sentenceChain = new MarkovChain(".", trainingDataURL, "\\w+|\\W", 4);

            //command line loop to allow commands
            Console.WriteLine(">Please enter the type of output you wish to generate (\"WORDS\" or \"SENTENCES\")");

            while (!exit)
            {
                //read and format command
                command = Console.ReadLine();
                if (command is null)
                {
                    command = "";
                }
                command = command.ToUpper().Trim();

                //respond
                switch (command)
                {
                    case "WORDS":
                        Console.WriteLine(wordChain.GenerateString(1000));
                        break;
                    case "SENTENCES":
                        Console.WriteLine(sentenceChain.GenerateString(1000));
                        break;
                    case "EXIT":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine(">");
                        break;
                }
            }
        }
    }
}
