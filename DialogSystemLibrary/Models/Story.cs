using System.Text;

namespace DialogSystemLibrary;

public class Story
{
    private string storyTitle;
    private List<DialogNode> dialogs = new List<DialogNode>();

    public string StoryTitle => storyTitle;
    public List<DialogNode> Dialogs => dialogs;
    public DialogNode StartNode => Dialogs.First(n => n.NodeId == "Start");

    public Story(string title, List<DialogNode> dialogNodes)
    {
        storyTitle = title;
        dialogs = dialogNodes;

        StringBuilder sb = new StringBuilder();
        sb.Append(storyTitle);
    }


}
