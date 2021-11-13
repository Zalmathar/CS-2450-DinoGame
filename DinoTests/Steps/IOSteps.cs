using System;
using TechTalk.SpecFlow;
using DinoClassLib;
using FluentAssertions;

namespace DinoTests.Steps
{
    [Binding]
    public class IOSteps
    {
        private readonly ScenarioContext sc;

        public IOSteps(ScenarioContext scenarioContext)
        {
            sc = scenarioContext;
        }
    }
}