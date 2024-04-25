using System.Reflection;

namespace DialogSystemLibrary.Test
{

    [TestClass]
    public class StoryParserTest
    {
        [TestMethod]
        public void Parse_TweeFile_Check_Count_And_StartNode()
        {
            string tweeFilePath = "TestData/TalkToLaura01.twee";
            string tweeFile = File.ReadAllText(tweeFilePath);

            // Act
            Story story = new TweeStoryParser().ParseStory(tweeFile);

            // Assert
            Assert.IsNotNull(story);
            Assert.AreEqual("TalkToLaura01", story.StoryTitle);
            Assert.AreEqual(11, story.Dialogs.Count);

            DialogNode startNode = story.StartNode;
            Assert.AreEqual("Hello, my name is Laura.", startNode.Content);
            Assert.AreEqual(2, startNode.Options.Count);


            Assert.AreEqual("yes", startNode.Options[0].IconName);
            Assert.AreEqual("no", startNode.Options[1].IconName);
            Assert.AreEqual("Name", startNode.Options[0].NextNode.NodeId);
        }
    }

}