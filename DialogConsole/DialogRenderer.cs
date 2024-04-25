

using DialogSystemLibrary;

public class DialogRenderer : IDialogRenderer
{

    public void RenderDialog(DialogNode node)
    {
        WriteDialog(node);
    }

    public void WriteDialog(DialogNode node, int selectIndex = 0)
    {
        Console.WriteLine();
        Console.WriteLine(node.Content);
        Thread.Sleep(200);
        WriteMenu(node.Options, selectIndex);
    }
    private void WriteMenu(List<DialogOption> options, int selectIndex=0)
    {
        if(options.Count <= 0)  return; 

        Console.WriteLine();

        for (int i = 0; i < options.Count; i++)
        {
            Console.Write(i == selectIndex ? "> " : "  ");
            Console.WriteLine(options[i].Content);
        }
    }
    public void EndDialog()
    {
        Console.WriteLine("Thank you for playing.") ;
    }

}