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
    }
}