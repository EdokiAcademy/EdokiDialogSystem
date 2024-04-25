using Moq;

namespace DialogSystemLibrary.Test
{
    [TestClass]
    public class StoryEngineTest
    {
        [TestMethod]
        public void Engine_Test_Twee_All1stOption()
        {
            string tweeFilePath = "TestData/TalkToLaura01.twee";
            string tweeFile = File.ReadAllText(tweeFilePath);

            // Act
            Story story = new TweeStoryParser().ParseStory(tweeFile);
            RunEngineWithAll1stOption(story);
        }

        [TestMethod]
        public void Engine_Test_Edited_Twee_All1stOption()
        {
            string tweeFilePath = "TestData/TalkToLaura01_edited.twee";
            string tweeFile = File.ReadAllText(tweeFilePath);

            // Act
            Story story = new TweeStoryParser().ParseStory(tweeFile);
            RunEngineWithAll1stOption(story);
        }



        private void RunEngineWithAll1stOption(Story story)
        {
            var mockRenderer = new Mock<IDialogRenderer>();

            DialogEngine engine = new DialogEngine(story, mockRenderer.Object);

            engine.StartDialog();

            // Assert
            Assert.IsNotNull(engine);
            Assert.AreEqual("Start", engine.CurrentNode.NodeId);

            engine.NextDialog(0);
            Assert.AreEqual("Name", engine.CurrentNode.NodeId);
            engine.NextDialog(0);
            Assert.AreEqual("Welcome", engine.CurrentNode.NodeId);
            engine.NextDialog(0);
            Assert.AreEqual("LearnEn", engine.CurrentNode.NodeId);
            engine.NextDialog(0);
            Assert.AreEqual("SeeYou", engine.CurrentNode.NodeId);
            engine.NextDialog(0);
            Assert.AreEqual("Stop", engine.CurrentNode.NodeId);

            Assert.IsTrue(engine.IsEnd);
        }


        [TestMethod]
        public void Engine_Test_Twee_All2ndOption()
        {
            string tweeFilePath = "TestData/TalkToLaura01.twee";
            string tweeFile = File.ReadAllText(tweeFilePath);

            // Act
            Story story = new TweeStoryParser().ParseStory(tweeFile);
            RunEngineWithAll2ndOption(story);
        }

        [TestMethod]
        public void Engine_Test_Edited_Twee_All2ndOption()
        {
            string tweeFilePath = "TestData/TalkToLaura01_edited.twee";
            string tweeFile = File.ReadAllText(tweeFilePath);

            // Act
            Story story = new TweeStoryParser().ParseStory(tweeFile);
            RunEngineWithAll2ndOption(story);
        }



        private static void RunEngineWithAll2ndOption(Story story)
        {
            var mockRenderer = new Mock<IDialogRenderer>();

            DialogEngine engine = new DialogEngine(story, mockRenderer.Object);

            engine.StartDialog();

            // Assert
            Assert.IsNotNull(engine);
            Assert.AreEqual("Start", engine.CurrentNode.NodeId);

            engine.NextDialog(1);
            Assert.AreEqual("Comeback", engine.CurrentNode.NodeId);
            engine.NextDialog(1);
            Assert.AreEqual("AskNameSlowly", engine.CurrentNode.NodeId);
            engine.NextDialog(0);
            Assert.AreEqual("Welcome", engine.CurrentNode.NodeId);
            engine.NextDialog(1);
            Assert.AreEqual("Comeback2", engine.CurrentNode.NodeId);
            engine.NextDialog(1);
            Assert.AreEqual("Try", engine.CurrentNode.NodeId);
            engine.NextDialog(0);
            Assert.AreEqual("SeeYou", engine.CurrentNode.NodeId);
            engine.NextDialog(1);
            Assert.AreEqual("SeeYouSlowly", engine.CurrentNode.NodeId);

            Assert.IsTrue(engine.IsEnd);
        }
    }

}