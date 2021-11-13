using System;
using TechTalk.SpecFlow;
using DinoClassLib;
using FluentAssertions;

namespace DinoTests.Steps
{
    [Binding]
    public class ControllerSteps
    {
        private readonly ScenarioContext sc;

        public ControllerSteps(ScenarioContext scenarioContext)
        {
            sc = scenarioContext;
        }

        [Given(@"there is a controller object")]
        public void GivenThereIsAControllerObject()
        {
            IO IOdummy = new IO();
            sc.Add("controller", new Controller(IOdummy));
            sc["controller"].As<Controller>().gameState = Controller.status.running;
        }

        [When(@"the next frame cycle happens")]
        public void WhenTheNextFrameCycleHappens()
        {
            sc["controller"].As<Controller>().FrameUpdate();
        }

        [Then(@"no collision is detected")]
        public void ThenNoCollisionIsDetected()
        {
            sc.Get<Controller>("controller").gameState.Should().Be(Controller.status.running);
        }

        [Then(@"collision is detected")]
        public void ThenCollisionIsDetected()
        {
            sc.Get<Controller>("controller").gameState.Should().Be(Controller.status.dead);
        }
      
        [Then(@"an obstacle is removed from the screen")]
        public void AnObstacleIsRemovedFromTheScreen()
        {
            sc.Get<Controller>("controller").Obstacles[0].Should().Be(null);
        }

        [Then(@"throw exception")]
        public void ThenThrowException()
        {
            sc.ContainsKey("Exception").Should().BeTrue();
        }
    }
}