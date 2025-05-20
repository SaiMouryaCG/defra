Feature: Calculator
  Scenario: Add two numbers from settings
    Given I have numbers from settings
    When I perform addition
    Then the result should be 30