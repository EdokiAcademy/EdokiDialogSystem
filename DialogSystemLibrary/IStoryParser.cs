namespace DialogSystemLibrary;

public interface IStoryParser
{
    public const string STOP_STR = "<stop>";
    Story ParseStory(string file);
}
