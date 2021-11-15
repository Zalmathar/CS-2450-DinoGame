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
            sc.Get<Controller>("controller").gameState = Controller.status.running;
        }

        [Given(@"a controller that can create objects on frame update")]
        public void GivenAControllerThatCanCreateObjectsOnFrameUpdate()
        {
            IO IOdummy = new IO();
            sc.Add("Controller", new Controller(IOdummy));
        }
        

        [When(@"the next frame cycle happens")]
        public void WhenTheNextFrameCycleHappens()
        {
            sc.Get<Controller>("controller").FrameUpdate();
        }

        [When(@"frameUpdate has been called (.*) times")]
        public void WhenFrameUpdateHasBeenCalledTimes(int p0)
        {
            sc.Add("numberOfFrames", p0);
            for (int i = 0; i < p0; i++)
            {
                sc.Get<Controller>("controller").FrameUpdate();
            }
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

        [Then(@"The score increases by (.*) points")]
        public void ThenTheScoreIncreasesByPoints(int p0)
        {
            sc.Get<Controller>("controller").score.Should().Be(p0);
        }

        [Then(@"score remains the same")]
        public void ThenScoreRemainsTheSame()
        {
            sc.Get<Controller>("controller").score.Should().Be(0);
        }



        // This feature tests are best tested from a code review
        
        [Then(@"there should be close to (.*)% of the number of frameUpdates small rocks in the obstacles list")]
        public void ThenThereShouldBeCloseToOfTheNumberOfFrameUpdatesSmallRocksInTheObstaclesList(Decimal p0)
        {
            int numberOfSmallRocks = 0;
            float targetNumber = (float)p0 / 100 * sc["numberOfFrames"].As<int>();
            sc.Get<Controller>("controller").Obstacles.ForEach(
                delegate (IPiece Obstacle)
                {
                    if (Obstacle is SmallRock)
                    {
                        numberOfSmallRocks++;
                    }
                });
            numberOfSmallRocks.Should().BeInRange((int)(targetNumber - targetNumber / 10), (int)(targetNumber + targetNumber / 10));
        }

        [Then(@"there should be close to (.*)% of the number of frameUpdates Large rocks in the obstacles list")]
        public void ThenThereShouldBeCloseToOfTheNumberOfFrameUpdatesLargeRocksInTheObstaclesList(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"there should be close to (.*)% of the number of frameUpdates birds in the obstacles list")]
        public void ThenThereShouldBeCloseToOfTheNumberOfFrameUpdatesBirdsInTheObstaclesList(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"close to (.*) of those birds should be positioned at y = (.*)")]
        public void ThenCloseToOfThoseBirdsShouldBePositionedAtY(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
    }
}