using System;
using TechTalk.SpecFlow;
using DinoClassLib;
using FluentAssertions;

namespace DinoTests.Steps
{
    [Binding]
    public class BirdSteps
    {
        private readonly ScenarioContext sc;

        public BirdSteps(ScenarioContext scenarioContext)
        {
            sc = scenarioContext;
        }

        [Given(@"there is a bird located at \((.*), (.*)\)")]
        public void GivenThereIsABirdLocatedAt(int p0, int p1)
        {
            sc.Get<Controller>("controller").Obstacles.Add(new Bird(p0, p1));
        }

        [Given(@"a bird at \((.*), (.*)\)")]
        public void GivenABirdAt(int p0, int p1)
        {
            sc.Add("x", p0);
            sc.Add("y", p1);
        }

        [Given(@"a bird constructed at \((.*), (.*)\)")]
        public void GivenABirdConstructedAt(int p0, int p1)
        {
            try
            {
                sc.Add("bird", new Bird(p0, p1));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }

        [When(@"a bird is constructed")]
        public void WhenABirdIsConstructed()
        {
            try
            {
                sc.Add("bird", new Bird(sc.Get<int>("x"), sc.Get<int>("y")));
            }
            catch (Exception e)
            {
                sc.Add("Exception", e);
            }
        }

        [When(@"a bird frame update happens")]
        public void WhenABirdFrameUpdateHappens()
        {
            sc.Get<Bird>("bird").onFrameUpdate();
        }

        [Then(@"the bird position is at \((.*), (.*)\)")]
        public void ThenTheBirdPositionIsAt(int p0, int p1)
        {
            sc.Get<Controller>("controller").Obstacles[0].position.getX().Should().Be(p0);
            sc.Get<Controller>("controller").Obstacles[0].position.getY().Should().Be(p1);
        }

        [Then(@"bird Position x is (.*)")]
        public void ThenBirdPositionXIs(int p0)
        {
            sc.Get<Bird>("bird").position.getX().Should().Be(p0);
        }

        [Then(@"bird Position y is (.*)")]
        public void ThenBirdPositionYIs(int p0)
        {
            sc.Get<Bird>("bird").position.getY().Should().Be(p0);
        }

        [Then(@"bird score is set to (.*)")]
        public void ThenBirdScoreIsSetTo(int p0)
        {
            sc.Get<Bird>("bird").pointVal.Should().Be(p0);
        }
    }
}