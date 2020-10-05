Feature: TM
         Create TM, Edit TM and Delete TM

Background: Navigate to the TM
    Given I navigate to login turnup
    Given I navigate to the TM

#Verify TM Create (ordinary input)
Scenario Outline: Verify multiple TM creation
When I input data using code: <code> and description: <desc>
Then I am able to verify data with code: <code>
Examples:
|          code        |                       desc                     |
|       Eskimo123      |          Welcome to Eskimo world!              |
|         Alice        |           Alice is lost!                       |


#Verify TM Create (Data table)
#Use Data table to avoid frequent login and out for each record
Scenario: Verify usage of Data Tables
When I input data using values from table:
|          code        |                     desc                       |
|       DavidOff123    |          Welcome to Daviodoff!                 |
|       DianaQueen     |          Diana will be the Queen!              |
|       StupidPie      |          Who is stupid pie?                    |


#Verify TM Edit
Scenario Outline: Verify TM is edited
Given I navigate to edit
When I input new data with code: <code> and desc:<desc>
Then I am able to verify the edited record with code: <code>
Examples: 
|          code               |                       desc                     |
|       WelcometoMARS         |          Welcome to Mars Planet!               |


#Verify TM Delete
Scenario: Verify TM is not deleted
Given I navigate to delete TM
When I cancel to delete TM
Then I am able to verify the data is not deleted

Scenario: Verify TM is deleted
Given I navigate to delete TM
When I confirm to delete TM
Then I am able to verify the data is deleted