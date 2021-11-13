using System;
using TechTalk.SpecFlow;
using DinoClassLib;
using FluentAssertions;

namespace DinoTests.Steps
{
    [Binding]
    public class SmallRockSteps
    {
        private readonly ScenarioContext sc;

        public SmallRockSteps(ScenarioContext scenarioContext)
        {
            sc = scenarioContext;
        }

        [Given(@"there is a small rock located at \((.*), (.*)\)")]
        public void GivenThereIsASmallRockLocatedAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().Obstacles.Add(new SmallRock(p0, p1));
        }

        [Given(@"a small rock at \((.*), (.*)\)")]
        public void GivenASmallRockAt(int p0, int p1)
        {
            x = p0;
            y = p1;
        }

        [Given(@"a small rock constructed at \((.*), (.*)\)")]
        public void GivenASmallRockConstructedAt(int p0, int p1)
        {
            try
            {
                sc.Add("smallrock", new SmallRock(p0, p1));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }

        [When(@"a small rock is constructed")]
        public void WhenASmallRockIsConstructed()
        {
            try
            {
                sc.Add("smallrock", new SmallRock(x, y));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }

        
        [When(@"a frame update happens")]
        public void WhenAFrameUpdateHappens()
        {
            sc["smallrock"].As<SmallRock>().onFrameUpdate();
        }

        [Then(@"the small rock position is at \((.*), (.*)\)")]
        public void ThenTheSmallRockPositionIsAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().Obstacles[0].position.getX().Should().Be(p0);
            sc["controller"].As<Controller>().Obstacles[0].position.getY().Should().Be(p1);
        }
        
        [Then(@"Position x is (.*)")]
        public void ThenPositionXIs(int p0)
        {
            sc["smallrock"].As<SmallRock>().position.getX().Should().Be(p0);
        }

        [Then(@"Position y is (.*)")]
        public void ThenPositionYIs(int p0)
        {
            sc["smallrock"].As<SmallRock>().position.getY().Should().Be(p0);
        }

        [Then(@"score is set to (.*)")]
        public void ThenScoreIsSetTo(int p0)
        {
            sc["smallrock"].As<SmallRock>().pointVal.Should().Be(p0);
        }

    }
}