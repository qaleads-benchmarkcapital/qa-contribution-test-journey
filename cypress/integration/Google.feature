Feature: Can perform Google search

  As a user 
  I would like to perform a basic seach 
  so that I can see search results related to my keyword
  
  Scenario: User can perform a basic search
    Given user is on Google landing page 
    When user attempts to search
    Then user can see results