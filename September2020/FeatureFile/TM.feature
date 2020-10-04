Feature: TM
         Create TM, Edit TM and Delete TM

Background: Navigate to the TM
    Given I navigate to the TM


Scenario: Verify the TM is created.
Given I navigate to create new function


Scenario Outline: Verify multiple TM creation
When I input data using code: <code> and description: <desc>
Then I am able to verify data with code: <code>
Examples:
|          code        |                       desc                     |
|       Eskimo123      |          Welcome to Eskimo world!              |
|         Alice        |           Alice is lost!                       |


#Use Data table to avoid frequent login and out for each record
Scenario: Verify usage of Data Tables
When I input data using values from table:
|          code        |                     desc                       |
|       DavidOff123    |          Welcome to Daviodoff!                 |
|       DianaQueen     |          Diana will be the Queen!              |
|       StupidPie      |          Who is stupid pie?                    |



Scenario Outline: Verify company is edited
Given I navigate to edit
When I input new data with code: <code> and desc:<desc>
Then I am able to verify the edited record with code: <code>
Examples: 
|          code               |                       desc                     |
|       WelcometoMARS CO      |          Welcome to Mars Planet!               |
