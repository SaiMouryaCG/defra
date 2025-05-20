Feature: CSV Reader
  As a user
  I want to read records from a CSV file
  So that I can validate the contents

  Scenario: Read CSV file and list records
    Given the CSV file is loaded
    When I read all records
    Then I should see 3 records
