using System;
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

        private readonly ScenarioContext sc_;

        public JumperStepDefinitions(ScenarioContext scenarioContext)
        {
            sc_ = scenarioContext;
        }


        [Given(@"a small rock at \((.*), (.*)\)")]
        public void GivenASmallRockAt(int p0, int p1)
        {
            x = p0;
            y = p1;

        }

        [When(@"a small rock is constructed")]
        public void WhenASmallRockIsConstructed()
        {
            try
            {
                sc_.Add("smallrock", new SmallRock(x, y));
            }
            catch (Exception e)
            {
                sc_.Add("Exception", e);
            }

        }

        [Then(@"Position x is (.*)")]
        public void ThenPositionXIs(int p0)
        {
            sc_["smallrock"].As<SmallRock>().position.getX().Should().Be(p0);
        }

        [Then(@"Position y is (.*)")]
        public void ThenPositionYIs(int p0)
        {
            sc_["smallrock"].As<SmallRock>().position.getY().Should().Be(p0);
        }

        [Then(@"score is set to (.*)")]
        public void ThenScoreIsSetTo(int p0)
        {
            sc_["smallrock"].As<SmallRock>().pointVal.Should().Be(p0);
        }


        [Then(@"throw exception")]
        public void ThenThrowException()
        {
            sc_.ContainsKey("Exception").Should().BeTrue();
        }

        [When(@"a frame update happens")]
        public void WhenAFrameUpdateHappens()
        {
            sc_["smallrock"].As<SmallRock>().onFrameUpdate();
        }

        [Given(@"a small rock constructed at \((.*), (.*)\)")]
        public void GivenASmallRockConstructedAt(int p0, int p1)
        {
            try
            {
                sc_.Add("smallrock", new SmallRock(p0, p1));
            }
            catch (Exception e)
            {
                sc_.Add("Exception", e);
            }
        }

        //big rock tests

         [Given(@"a big rock at \((.*), (.*)\)")]
        public void GivenABigRockkAt(int p0, int p1)
        {
            x = p0;
            y = p1;

        }

        [When(@"a big rock is constructed")]
        public void WhenABigRockIsConstructed()
        {
            try
            {
                sc_.Add("Bigrock", new BigRock(x, y));
            }
            catch (Exception e)
            {
                sc_.Add("Exception", e);
            }

        }

        [Then(@"big Position x is (.*)")]
        public void ThenBigPositionXIs(int p0)
        {
            sc_["Bigrock"].As<BigRock>().position.getX().Should().Be(p0);
        }

        [Then(@"big Position y is (.*)")]
        public void ThenBigPositionYIs(int p0)
        {
            sc_["Bigrock"].As<BigRock>().position.getY().Should().Be(p0);
        }

        [Then(@"big score is set to (.*)")]
        public void ThenBigScoreIsSetTo(int p0)
        {
            sc_["Bigrock"].As<BigRock>().pointVal.Should().Be(p0);
        }


        [When(@"a big frame update happens")]
        public void WhenABigFrameUpdateHappens()
        {
            sc_["Bigrock"].As<BigRock>().onFrameUpdate();
        }

        [Given(@"a big rock constructed at \((.*), (.*)\)")]
        public void GivenABigRockConstructedAt(int p0, int p1)
        {
            try
            {
                sc_.Add("Bigrock", new BigRock(p0, p1));
            }
            catch (Exception e)
            {
                sc_.Add("Exception", e);
            }
        }


        //bird tests start

        [Given(@"a bird at \((.*), (.*)\)")]
        public void GivenABirdAt(int p0, int p1)
        {
            x = p0;
            y = p1;

        }
        [When(@"a bird is constructed")]
        public void WhenABirdIsConstructed()
        {
            try
            {
                sc_.Add("bird", new Bird(x, y));
            }
            catch (Exception e)
            {
                sc_.Add("Exception", e);
            }
        }


        [Then(@"bird Position x is (.*)")]
        public void ThenBirdPositionXIs(int p0)
        {
            sc_["bird"].As<Bird>().position.getX().Should().Be(p0);
        }

        [Then(@"bird Position y is (.*)")]
        public void ThenBirdPositionYIs(int p0)
        {
            sc_["bird"].As<Bird>().position.getY().Should().Be(p0);
        }

        [Then(@"bird score is set to (.*)")]
        public void ThenBirdScoreIsSetTo(int p0)
        {
            sc_["bird"].As<Bird>().pointVal.Should().Be(p0);
        }
        [When(@"a bird frame update happens")]
        public void WhenABirdFrameUpdateHappens()
        {
            sc_["bird"].As<Bird>().onFrameUpdate();
        }


        [Given(@"a bird constructed at \((.*), (.*)\)")]
        public void GivenABirdConstructedAt(int p0, int p1)
        {
            try
            {
                sc_.Add("bird", new Bird(p0, p1));
            }
            catch (Exception e)
            {
                sc_.Add("Exception", e);
            }
        }

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
                sc_.Add("player", new Player(x, y));
            }
            catch (Exception e)
            {
                sc_.Add("Exception", e);
            }
        }
        [Then(@"player Position x is (.*)")]
        public void ThenPlayerPositionXIs(int p0)
        {
            sc_["player"].As<Player>().position.getX().Should().Be(p0);
        }

        [Then(@"player Position y is (.*)")]
        public void ThenPlayerPositionYIs(int p0)
        {
            sc_["player"].As<Player>().position.getY().Should().Be(p0);
        }

        [Then(@"player score is set to (.*)")]
        public void ThenPlayerScoreIsSetTo(int p0)
        {
            sc_["player"].As<Player>().pointVal.Should().Be(p0);
        }

        [Given(@"a player constructed at \((.*), (.*)\)")]
        public void GivenAPlayerConstructedAt(int p0, int p1)
        {
            try
            {
                sc_.Add("player", new Player(p0, p1));
            }
            catch (Exception e)
            {
                sc_.Add("Exception", e);
            }
        }


        [When(@"a player frame update happens")]
        public void WhenAPlayerFrameUpdateHappens()
        {
            sc_["player"].As<Player>().onFrameUpdate();
        }


        //frame update tests
        [Given(@"there is a controller object")]
        public void GivenThereIsAControllerObject()
        {
            sc_.Add("controller", new Controller());
        }

        [Given(@"there is a small rock located at \((.*), (.*)\)")]
        public void GivenThereIsASmallRockLocatedAt(int p0, int p1)
        {
            if (!sc_.ContainsKey("controller"))
            {
                sc_.Add("controller", new Controller());
            }
            sc_["controller"].As<Controller>().Obstacles.Add(new SmallRock(p0, p1));
        }

        [Given(@"there is a player located at \((.*), (.*)\)")]
        public void GivenThereIsAPlayerLocatedAt(int p0, int p1)
        {
            if (!sc_.ContainsKey("controller"))
            {
                sc_.Add("controller", new Controller());
            }
            sc_["controller"].As<Controller>().player.position.setX(p0);
            sc_["controller"].As<Controller>().player.position.setY(p1);
        }

        [When(@"the next frame cycle happens")]
        public void WhenTheNextFrameCycleHappens()
        {
            sc_["controller"].As<Controller>().FrameUpdate();
        }

        [Then(@"the player position is at \((.*), (.*)\)")]
        public void ThenThePlayerPositionIsAt(int p0, int p1)
        {
            sc_["controller"].As<Controller>().player.position.getX().Should().Be(p0);
            sc_["controller"].As<Controller>().player.position.getY().Should().Be(p1);
        }

        [Then(@"the small rock position is at \((.*), (.*)\)")]
        public void ThenTheSmallRockPositionIsAt(int p0, int p1)
        {
            sc_["controller"].As<Controller>().Obstacles[0].position.getX().Should().Be(p0);
            sc_["controller"].As<Controller>().Obstacles[0].position.getY().Should().Be(p1);
        }

        [Given(@"there is a large rock located at \((.*), (.*)\)")]
        public void GivenThereIsALargeRockLocatedAt(int p0, int p1)
        {
            if (!sc_.ContainsKey("controller"))
            {
                sc_.Add("controller", new Controller());
            }
            sc_["controller"].As<Controller>().Obstacles.Add(new BigRock(p0, p1));
        }

        [Then(@"the large rock position is at \((.*), (.*)\)")]
        public void ThenTheLargeRockPositionIsAt(int p0, int p1)
        {
            sc_["controller"].As<Controller>().Obstacles[0].position.getX().Should().Be(p0);
            sc_["controller"].As<Controller>().Obstacles[0].position.getY().Should().Be(p1);
        }

        [Given(@"there is a bird located at \((.*), (.*)\)")]
        public void GivenThereIsABirdLocatedAt(int p0, int p1)
        {
            if (!sc_.ContainsKey("controller"))
            {
                sc_.Add("controller", new Controller());
            }
            sc_["controller"].As<Controller>().Obstacles.Add(new Bird(p0, p1));
        }

        [Then(@"the bird position is at \((.*), (.*)\)")]
        public void ThenTheBirdPositionIsAt(int p0, int p1)
        {
            sc_["controller"].As<Controller>().Obstacles[0].position.getX().Should().Be(p0);
            sc_["controller"].As<Controller>().Obstacles[0].position.getY().Should().Be(p1);
        }

        [Given(@"player is jumping")]
        public void GivenPlayerIsJumping()
        {
            sc_["player"].As<Player>().IsJumping = true;
        }

        [When(@"player jumps again")]
        public void WhenPlayerJumpsAgain()
        {
            sc_["player"].As<Player>().IsJumping = true;
        }

        [Then(@"no collision is detected")]
        public void ThenNoCollisionIsDetected()
        {
            sc_.Get<Controller>("controller").gameState.Should().Be(Controller.status.running);
        }


        // Score test cases

        [When(@"the next frame cycle happens\.")]
        public void WhenTheNextFrameCycleHappens_()
        {
            sc_["controller"].As<Controller>().FrameUpdate();
        }

        [Then(@"The score increases by (.*) points")]
        public void ThenTheScoreIncreasesByPoints(int p0)
        {
            sc_["controller"].As<Controller>().Score.Should().Be(p0);
        }


        [Then(@"score remains the same")]
        public void ThenScoreRemainsTheSame()
        {
            sc_["controller"].As<Controller>().Score.Should().Be(0);
        }

        //collision and obstacle removal

        [Then(@"collision is detected")]
        public void ThenCollisionIsDetected()
        {
            sc_.Get<Controller>("controller").gameState.Should().Be(Controller.status.dead);
        }


        [Then(@"an obstacle is removed from the screen")]
        public void AnObstacleIsRemovedFromTheScreen()
        {
            sc_.Get<Controller>("controller").Obstacles[0].Should().Be(null);
        }
    }
}