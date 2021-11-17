using System;
using TechTalk.SpecFlow;
using DinoClassLib;
using FluentAssertions;

namespace DinoTests.Steps
{
    [Binding]
    public class PlayerSteps
    {
        private readonly ScenarioContext sc;

        public PlayerSteps(ScenarioContext scenarioContext)
        {
            sc = scenarioContext;
        }

        [Given(@"there is a player located at \((.*), (.*)\)")]
        public void GivenThereIsAPlayerLocatedAt(int p0, int p1)
        {
            if (!sc.ContainsKey("controller"))
            {
                sc.Add("controller", new Controller(new IO()));
            }
            sc.Get<Controller>("controller").player.position.setX(p0);
            sc.Get<Controller>("controller").player.position.setY(p1);
        }

        [Given(@"a player at \((.*), (.*)\)")]
        public void GivenAPlayerAt(int p0, int p1)
        {
            sc.Add("x", p0);
            sc.Add("y", p1);
        }

        [Given(@"a player constructed at \((.*), (.*)\)")]
        public void GivenAPlayerConstructedAt(int p0, int p1)
        {
            try
            {
                sc.Add("player", new Player(new Position (p0, p1)));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }
        
        [Given(@"player is jumping")]
        public void GivenPlayerIsJumping()
        {
            sc.Get<Player>("player").IsJumping = true;
        }

        [When(@"a player is constructed")]
        public void WhenAPlayerIsConstructed()
        {
            try
            {
                sc.Add("player", new Player(new Position (sc.Get<int>("x"), sc.Get<int>("y"))));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }

        [When(@"a player frame update happens")]
        public void WhenAPlayerFrameUpdateHappens()
        {
            sc.Get<Player>("player").OnFrameUpdate();
        }

        [When(@"player jumps again")]
        public void WhenPlayerJumpsAgain()
        {
            sc.Get<Player>("player").IsJumping = true;
        }

        [Then(@"the player position is at \((.*), (.*)\)")]
        public void ThenThePlayerPositionIsAt(int p0, int p1)
        {
            sc.Get<Controller>("controller").player.position.getX().Should().Be(p0);
            sc.Get<Controller>("controller").player.position.getY().Should().Be(p1);
        }

        [Then(@"player Position x is (.*)")]
        public void ThenPlayerPositionXIs(int p0)
        {
            sc.Get<Player>("player").position.getX().Should().Be(p0);
        }

        [Then(@"player Position y is (.*)")]
        public void ThenPlayerPositionYIs(int p0)
        {
            sc.Get<Player>("player").position.getY().Should().Be(p0);
        }

        [Then(@"player score is set to (.*)")]
        public void ThenPlayerScoreIsSetTo(int p0)
        {
            sc.Get<Player>("player").PointVal.Should().Be(p0);
        }
    }
}