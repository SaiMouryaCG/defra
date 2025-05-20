Feature: Calculator Operations

  Scenario: Add numbers
    Given I have numbers from settings
    When I add them
    Then the result should be 30

  Scenario: Subtract numbers
    Given I have numbers from settings
    When I subtract them
    Then the result should be -10

  Scenario: Multiply numbers
    Given I have numbers from settings
    When I multiply them
    Then the result should be 200

  Scenario: Divide numbers
    Given I have numbers from settings
    When I divide them
    Then the result should be 0