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


        [Then(@"Bird Position x is (.*)")]
        public void ThenBirdPositionXIs(int p0)
        {
            sc_["bird"].As<Bird>().position.getX().Should().Be(p0);
        }


        [Then(@"Bird Position y is (.*)")]
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
    }
}