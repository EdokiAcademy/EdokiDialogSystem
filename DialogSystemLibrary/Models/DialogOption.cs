namespace DialogSystemLibrary;

public class DialogOption
{
    private string iconName;
    private string content;
    private DialogNode nextNode;

    public string IconName => iconName;
    public string Content => content;
    public DialogNode NextNode => nextNode;

    private string nextNodeTitle;

    public DialogOption(string iconName, string content, string nextNodeTitle)
    {
        this.iconName = iconName;
        this.content = content;
        this.nextNodeTitle = nextNodeTitle;
    }

    public void InitNextNode(IEnumerable<DialogNode> allNodes)
    {
        if(!string.IsNullOrEmpty(nextNodeTitle))
            nextNode = allNodes.FirstOrDefault(n => n.NodeId == nextNodeTitle);
    }
}