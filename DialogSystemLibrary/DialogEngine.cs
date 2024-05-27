namespace DialogSystemLibrary;


public class DialogEngine
{
    public bool IsEnd => currentNode == null ? false : currentNode.IsStopNode;
    public int OptionCount => currentNode.Options.Count;
    public DialogNode CurrentNode => currentNode;

    private Story story;
    private DialogNode currentNode;
    private IDialogRenderer renderer;
    public DialogEngine(Story story, IDialogRenderer renderer)
    {
        this.story = story;
        this.renderer = renderer;
    }

    public void StartDialog()
    {
        renderer.RenderDialog(story.StartNode);
        currentNode = story.StartNode;
    }

    public void NextDialog(DialogOption selected)
    {
        currentNode = selected.NextNode;
        renderer.RenderDialog(selected.NextNode);
    }

    public void NextDialog(int selectedIndex) =>
        NextDialog(currentNode.Options[selectedIndex]);

    public void EndDialog()
    {
        renderer.EndDialog();
    }

}