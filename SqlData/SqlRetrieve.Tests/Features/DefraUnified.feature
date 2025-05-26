Feature: Unified Operations
  This fearure combines Calculator,CsvReader,SqlDataRetrieve
  
  @Calculator
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
	
  @csv
  Scenario: Read CSV file and list records
    Given the CSV file is loaded
    When I read all records
    Then I should see 3 records

  @sql
  Scenario: Fetch names from SQL
    Given I have a SQL connection string
    When I retrieve names from the database
    Then the result should not be empty
