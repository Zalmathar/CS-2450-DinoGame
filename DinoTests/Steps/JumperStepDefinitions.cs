using System;
using TechTalk.SpecFlow;
using DinoClassLib;
using FluentAssertions;
namespace DinoTests.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private int x, y;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext sc_;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
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


    }
}