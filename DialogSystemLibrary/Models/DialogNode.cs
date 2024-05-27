namespace DialogSystemLibrary;

[Serializable]
public class DialogNode
{
    private string nodeId;
    private string audioId;
    private string content;
    private bool isStopNode;
    private List<DialogOption> options = new List<DialogOption>();

    public string NodeId => nodeId;
    public string AudioId => audioId;
    public string Content => content;
    public bool IsStopNode=> isStopNode;
    
    public List<DialogOption> Options=> options;

    public DialogNode(string nodeTitle, string content, List<DialogOption> options, string audioId="")
    {
        nodeId = nodeTitle;
        this.content = content;
        this.options = options;
        isStopNode = options == null || options.Count <= 0;
        this.audioId = audioId;
    }
}
