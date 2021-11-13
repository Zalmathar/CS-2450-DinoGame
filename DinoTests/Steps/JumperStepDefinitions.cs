using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using DinoClassLib;
using FluentAssertions;
namespace DinoTests.Steps
{
    [Binding]
    public sealed class JumperStepDefinitions
    {
        private int x, y;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext sc;

        public JumperStepDefinitions(ScenarioContext scenarioContext)
        {
            sc = scenarioContext;
        }




        







        [Then(@"throw exception")]
        public void ThenThrowException()
        {
            sc.ContainsKey("Exception").Should().BeTrue();
        }



        //big rock tests



        









        //bird tests start








        //player tests
        [Given(@"a player at \((.*), (.*)\)")]
        public void GivenAPlayerAt(int p0, int p1)
        {
            x = p0;
            y = p1;
        }

        [When(@"a player is constructed")]
        public void WhenAPlayerIsConstructed()
        {
            try
            {
                sc.Add("player", new Player(x, y));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }
        [Then(@"player Position x is (.*)")]
        public void ThenPlayerPositionXIs(int p0)
        {
            sc["player"].As<Player>().position.getX().Should().Be(p0);
        }

        [Then(@"player Position y is (.*)")]
        public void ThenPlayerPositionYIs(int p0)
        {
            sc["player"].As<Player>().position.getY().Should().Be(p0);
        }

        [Then(@"player score is set to (.*)")]
        public void ThenPlayerScoreIsSetTo(int p0)
        {
            sc["player"].As<Player>().pointVal.Should().Be(p0);
        }

        [Given(@"a player constructed at \((.*), (.*)\)")]
        public void GivenAPlayerConstructedAt(int p0, int p1)
        {
            try
            {
                sc.Add("player", new Player(p0, p1));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }


        [When(@"a player frame update happens")]
        public void WhenAPlayerFrameUpdateHappens()
        {
            sc["player"].As<Player>().onFrameUpdate();
        }


        //frame update tests
        [Given(@"there is a controller object")]
        public void GivenThereIsAControllerObject()
        {
            IO IOdummy = new IO();
            sc.Add("controller", new Controller(IOdummy));
            sc["controller"].As<Controller>().gameState = Controller.status.running;
        }

        [Given(@"there is a small rock located at \((.*), (.*)\)")]
        public void GivenThereIsASmallRockLocatedAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().Obstacles.Add(new SmallRock(p0, p1));
        }

        [Given(@"there is a player located at \((.*), (.*)\)")]
        public void GivenThereIsAPlayerLocatedAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().player.position.setX(p0);
            sc["controller"].As<Controller>().player.position.setY(p1);
        }

        [When(@"the next frame cycle happens")]
        public void WhenTheNextFrameCycleHappens()
        {
            sc["controller"].As<Controller>().FrameUpdate();
        }

        [Then(@"the player position is at \((.*), (.*)\)")]
        public void ThenThePlayerPositionIsAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().player.position.getX().Should().Be(p0);
            sc["controller"].As<Controller>().player.position.getY().Should().Be(p1);
        }

        [Then(@"the small rock position is at \((.*), (.*)\)")]
        public void ThenTheSmallRockPositionIsAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().Obstacles[0].position.getX().Should().Be(p0);
            sc["controller"].As<Controller>().Obstacles[0].position.getY().Should().Be(p1);
        }

        [Given(@"there is a large rock located at \((.*), (.*)\)")]
        public void GivenThereIsALargeRockLocatedAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().Obstacles.Add(new BigRock(p0, p1));
        }

        [Then(@"the large rock position is at \((.*), (.*)\)")]
        public void ThenTheLargeRockPositionIsAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().Obstacles[0].position.getX().Should().Be(p0);
            sc["controller"].As<Controller>().Obstacles[0].position.getY().Should().Be(p1);
        }

        [Given(@"there is a bird located at \((.*), (.*)\)")]
        public void GivenThereIsABirdLocatedAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().Obstacles.Add(new Bird(p0, p1));
        }

        [Then(@"the bird position is at \((.*), (.*)\)")]
        public void ThenTheBirdPositionIsAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().Obstacles[0].position.getX().Should().Be(p0);
            sc["controller"].As<Controller>().Obstacles[0].position.getY().Should().Be(p1);
        }

        [Given(@"player is jumping")]
        public void GivenPlayerIsJumping()
        {
            sc["player"].As<Player>().IsJumping = true;
        }

        [When(@"player jumps again")]
        public void WhenPlayerJumpsAgain()
        {
            sc["player"].As<Player>().IsJumping = true;
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
    }
}