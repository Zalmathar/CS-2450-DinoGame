using System;
using TechTalk.SpecFlow;
using DinoClassLib;
using FluentAssertions;

namespace DinoTests.Steps
{
    [Binding]
    public class BigRockSteps
    {
        private readonly ScenarioContext sc;

        public BigRockSteps(ScenarioContext scenarioContext)
        {
            sc = scenarioContext;
        }

        [Given(@"there is a large rock located at \((.*), (.*)\)")]
        public void GivenThereIsALargeRockLocatedAt(int p0, int p1)
        {
            if (!sc.ContainsKey("controller"))
            {
                sc.Add("controller", new Controller(new IO()));
            }
            sc.Get<Controller>("controller").Obstacles.Add(new BigRock(new Position (p0, p1)));
        }


        [Given(@"a big rock at \((.*), (.*)\)")]
        public void GivenABigRockkAt(int p0, int p1)
        {
            sc.Add("x", p0);
            sc.Add("y", p1);
        }

        [Given(@"a big rock constructed at \((.*), (.*)\)")]
        public void GivenABigRockConstructedAt(int p0, int p1)
        {
            try
            {
                sc.Add("Bigrock", new BigRock(new Position (p0, p1)));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }

        [When(@"a big rock is constructed")]
        public void WhenABigRockIsConstructed()
        {
            try
            {
                sc.Add("Bigrock", new BigRock(new Position (sc.Get<int>("x"), sc.Get<int>("y"))));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }

        [When(@"a big frame update happens")]
        public void WhenABigFrameUpdateHappens()
        {
            sc.Get<BigRock>("Bigrock").OnFrameUpdate();
        }     

        [Then(@"the large rock position is at \((.*), (.*)\)")]
        public void ThenTheLargeRockPositionIsAt(int p0, int p1)
        {
            sc.Get<Controller>("controller").Obstacles[0].position.getX().Should().Be(p0);
            sc.Get<Controller>("controller").Obstacles[0].position.getY().Should().Be(p1);
        }

        [Then(@"big Position x is (.*)")]
        public void ThenBigPositionXIs(int p0)
        {
            sc.Get<BigRock>("Bigrock").position.getX().Should().Be(p0);
        }

        [Then(@"big Position y is (.*)")]
        public void ThenBigPositionYIs(int p0)
        {
            sc.Get<BigRock>("Bigrock").position.getY().Should().Be(p0);
        }

        [Then(@"big score is set to (.*)")]
        public void ThenBigScoreIsSetTo(int p0)
        {
            sc.Get<BigRock>("Bigrock").PointVal.Should().Be(p0);
        }
    }
}