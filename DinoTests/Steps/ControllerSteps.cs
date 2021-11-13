using System;
using TechTalk.SpecFlow;
using DinoClassLib;
using FluentAssertions;

namespace DinoTests.Steps
{
    [Binding]
    public class ControllerSteps
    {
        private readonly ScenarioContext sc;

        public ControllerSteps(ScenarioContext scenarioContext)
        {
            sc = scenarioContext;
        }
    }
}