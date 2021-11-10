using System;
using TechTalk.SpecFlow;
using DinoClassLib;
using FluentAssertions;

namespace DinoTests.Steps
{
    [Binding]
    public class JUM_35_GeneratingObstaclesSteps
    {
        private readonly ScenarioContext sc_;

        public JUM_35_GeneratingObstaclesSteps(ScenarioContext scenarioContext)
        {
            sc_ = scenarioContext;
        }



        [Given(@"a controller that can create objects on frame update")]
        public void GivenAControllerThatCanCreateObjectsOnFrameUpdate()
        {
            IO IOdummy = new IO();
            sc_.Add("Controller", new Controller(IOdummy));
        }
        
        
        [When(@"frameUpdate has been called (.*) times")]
        public void WhenFrameUpdateHasBeenCalledTimes(int p0)
        {
            sc_.Add("numberOfFrames", p0);
            for(int i = 0; i<p0; i++){
                sc_["Controller"].As<Controller>().FrameUpdate();
            }
        }
        
        [Then(@"there should be close to (.*)% of the number of frameUpdates small rocks in the obstacles list")]
        public void ThenThereShouldBeCloseToOfTheNumberOfFrameUpdatesSmallRocksInTheObstaclesList(Decimal p0)
        {
            int numberOfSmallRocks = 0;
            float targetNumber = (float) p0 / 100 * sc_["numberOfFrames"].As<int>();
            sc_["Controller"].As<Controller>().Obstacles.ForEach(
                delegate (IPiece Obstacle)
                {
                    if (Obstacle is SmallRock)
                    {
                        numberOfSmallRocks++;
                    }
                });
            numberOfSmallRocks.Should().BeInRange((int) (targetNumber - targetNumber / 10), (int)(targetNumber + targetNumber / 10));
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
