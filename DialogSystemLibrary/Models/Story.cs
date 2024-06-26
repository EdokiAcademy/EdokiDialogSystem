﻿using System.Text;

namespace DialogSystemLibrary;

public class Story
{
    private string storyTitle;
    private List<DialogNode> dialogs = new List<DialogNode>();
    private DialogNode startNode;

    public string StoryTitle => storyTitle;
    public List<DialogNode> Dialogs => dialogs;
    public DialogNode StartNode => startNode;

    public Story(string title, List<DialogNode> dialogNodes)
    {
        storyTitle = title;
        dialogs = dialogNodes;

        StringBuilder sb = new StringBuilder();
        sb.Append(storyTitle);

        var allNextNodes = dialogNodes.SelectMany(n => n.Options).Select(o => o.NextNode).Distinct().ToList();

        startNode = dialogNodes.Except(allNextNodes).First();
    }
}
