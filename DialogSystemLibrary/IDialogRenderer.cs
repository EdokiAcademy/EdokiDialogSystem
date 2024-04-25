namespace DialogSystemLibrary;

public interface IDialogRenderer
{
    void RenderDialog(DialogNode node);
    void EndDialog();
}
