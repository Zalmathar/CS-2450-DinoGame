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
    }
}