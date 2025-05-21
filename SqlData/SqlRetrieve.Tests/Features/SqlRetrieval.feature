Feature: SQL Retrieval

  Scenario: Fetch names from SQL
    Given I have a SQL connection string
    When I retrieve names from the database
    Then the result should not be empty
