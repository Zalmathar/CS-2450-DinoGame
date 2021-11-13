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
    }
}