namespace DialogSystemLibrary;

[Serializable]
public class DialogNode
{
    private string nodeId;
    private string content;
    private bool isStopNode;
    private List<DialogOption> options = new List<DialogOption>();

    public string NodeId => nodeId;
    public string Content => content;
    public bool IsStopNode=> isStopNode;
    
    public List<DialogOption> Options=> options;

    public DialogNode(string nodeTitle, string content, bool isStop, List<DialogOption> options)
    {
        nodeId = nodeTitle;
        this.content = content;
        isStopNode = isStop;
        this.options = options;
    }
}
