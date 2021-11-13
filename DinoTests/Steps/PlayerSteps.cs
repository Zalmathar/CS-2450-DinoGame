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

        [Given(@"a player at \((.*), (.*)\)")]
        public void GivenAPlayerAt(int p0, int p1)
        {
            x = p0;
            y = p1;
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

        [When(@"a player frame update happens")]
        public void WhenAPlayerFrameUpdateHappens()
        {
            sc["player"].As<Player>().onFrameUpdate();
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
    }
}