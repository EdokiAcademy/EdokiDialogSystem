using System.Text.RegularExpressions;

namespace DialogSystemLibrary;

public class TweeStoryParser: IStoryParser
{

    public Story ParseStory(string tweeFile)
    {
        if (!tweeFile.StartsWith(":: StoryTitle"))
        {
            throw new ArgumentException("File is not a twee file");
        }

        tweeFile = tweeFile.Replace("\r\n", "\n");

        Regex regexStoryTitle = new Regex(@"^:: StoryTitle\n(.+)\n$", RegexOptions.Multiline);
        MatchCollection matchStoryTitle = regexStoryTitle.Matches(tweeFile);
        string storyTitle = matchStoryTitle[0].Groups[1].Value;


        Regex regexNode = new Regex(@"^::.*(?:\r?\n(?!\r?\n)|.)*(?:\]\]|>)$", RegexOptions.Multiline);
        MatchCollection matcheNodes = regexNode.Matches(tweeFile);

        List<DialogNode> dialogs = new List<DialogNode>();
        foreach (Match match in matcheNodes)
        {
            // Extract Title
            string title = Regex.Match(match.Value, @"::\s*(?<title>[^{]+)").Groups["title"].Value.Trim();

            // Extract Content
            string content = "";
            if (match.Value.Contains("[["))
                content = Regex.Match(match.Value, @"}(?<content>.*?)\[\[", RegexOptions.Singleline).Groups["content"].Value.Trim();
            else
                content = Regex.Match(match.Value, @"}(?<content>.*?)$", RegexOptions.Singleline).Groups["content"].Value.Trim();

            // Extract Options
            List<DialogOption> options = new List<DialogOption>();
            MatchCollection optionsMatches = Regex.Matches(match.Value, @"\[\[(?<option>[^\]]+)\]\]");
            foreach(Match optionsMatch in optionsMatches)
            {
                string option = optionsMatch.Groups["option"].Value.Trim();

                string icon = Regex.Match(option, @"<icon:(.*?)>").Groups[1].Value;
                string optionContent = Regex.Match(option, @">([^->]+)").Groups[1].Value;
                string nextTitle = Regex.Match(option, @"->(.*)").Groups[1].Value;



                options.Add(new DialogOption(icon, optionContent, nextTitle));
            }

            dialogs.Add(new DialogNode(title, content, content.Contains(IStoryParser.STOP_STR), options));
        }

        //Init option next node
        foreach (DialogNode dialogNode in dialogs)
            foreach (DialogOption option in dialogNode.Options)
                option.InitNextNode(dialogs);

        Story story = new Story(storyTitle, dialogs);
        return story;
    }
}
