

using DialogSystemLibrary;
using System.Text.RegularExpressions;

internal class Program
{
    private static int index = 0;
    private static void Main(string[] args)
    {
        if (args.Length == 0)
            Console.WriteLine("Please provide file path in arg");

        string fileContent = "";
        try
        {
            fileContent = File.ReadAllText(args[0]);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }

        fileContent = fileContent.Replace("\r\n", "\n");

        Regex regexNode = new Regex(@"^::\s.*position.*(?:\n(?!\n).*)*(?:\n\n|$)", RegexOptions.Multiline);
        MatchCollection matcheNodes = regexNode.Matches(fileContent);

        Console.WriteLine(matcheNodes.Count);

        /*
        Story story = new TweeStoryParser().ParseStory(fileContent);
        DialogRenderer renderer = new DialogRenderer();
        DialogEngine engine = new DialogEngine(story, renderer);

        engine.StartDialog();

        do
        {
            Iterate(engine, renderer);
        
        } while (!engine.IsEnd);

        engine.EndDialog();
        */
    }

    private static void Iterate(DialogEngine engine, DialogRenderer renderer)
    {
        ConsoleKeyInfo keyinfo = Console.ReadKey();

        switch (keyinfo.Key)
        {
            case ConsoleKey.DownArrow:
                index = Math.Min(index + 1, engine.OptionCount - 1);
                renderer.WriteDialog(engine.CurrentNode, index);
                break;

            case ConsoleKey.UpArrow:
                index = Math.Max(index - 1, 0);
                renderer.WriteDialog(engine.CurrentNode, index);
                break;

            case ConsoleKey.Enter:
                engine.NextDialog(index);
                index = 0;
                break;
        }
    }
}
