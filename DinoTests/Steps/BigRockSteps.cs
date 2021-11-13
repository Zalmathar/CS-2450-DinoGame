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
            sc["controller"].As<Controller>().Obstacles.Add(new BigRock(p0, p1));
        }


        [Given(@"a big rock at \((.*), (.*)\)")]
        public void GivenABigRockkAt(int p0, int p1)
        {
            x = p0;
            y = p1;
        }

        [Given(@"a big rock constructed at \((.*), (.*)\)")]
        public void GivenABigRockConstructedAt(int p0, int p1)
        {
            try
            {
                sc.Add("Bigrock", new BigRock(p0, p1));
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
                sc.Add("Bigrock", new BigRock(x, y));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }

        [When(@"a big frame update happens")]
        public void WhenABigFrameUpdateHappens()
        {
            sc["Bigrock"].As<BigRock>().onFrameUpdate();
        }     

        [Then(@"the large rock position is at \((.*), (.*)\)")]
        public void ThenTheLargeRockPositionIsAt(int p0, int p1)
        {
            sc["controller"].As<Controller>().Obstacles[0].position.getX().Should().Be(p0);
            sc["controller"].As<Controller>().Obstacles[0].position.getY().Should().Be(p1);
        }

        [Then(@"big Position x is (.*)")]
        public void ThenBigPositionXIs(int p0)
        {
            sc["Bigrock"].As<BigRock>().position.getX().Should().Be(p0);
        }

        [Then(@"big Position y is (.*)")]
        public void ThenBigPositionYIs(int p0)
        {
            sc["Bigrock"].As<BigRock>().position.getY().Should().Be(p0);
        }

        [Then(@"big score is set to (.*)")]
        public void ThenBigScoreIsSetTo(int p0)
        {
            sc["Bigrock"].As<BigRock>().pointVal.Should().Be(p0);
        }
    }
}