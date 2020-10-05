Feature: Company
	Create, edit and delete company item

Background: Navigate to Company page
    Given I navigate to log in turnup
    Given I navigate to company page

Scenario: Verify company is created
Given I navigate to create company

Scenario Outline: Verify multiple company creation
When I input data using Company Name: <CompanyName> and Contact: <FirstName> <LastName> <Phone> <Mobile> <Email>
Then I am able to verify data with Company Name: <CompanyName>
Examples:
| CompanyName | FirstName | LastName | Phone    | Mobile   |          Email      |
| Eskimo Co   | Esk        | Lee      | 0210909  | 02331221 | eskimo@gmail.com    |
| Nanada Co   | Nana       | Lo       | 1223323  | 43242344 | nanada@hotmail.com  |


#Use data table to avoid frequent login and out for each item creation
#the table header have to keep consistent or will fail
Scenario: Verify usage of company data table to create
When I create company record using data table:
| companyName | firstName | lastName | phone    | mobile   |          email      |  
| Taylor Co   | Taylor    | Lee      | 0210909  | 02331221 | eskimo@gmail.com    |
| Donald Co   | Donald    | Lo       | 1223323  | 43242344 | nanada@hotmail.com  |
| Stupid Co   | Steward   | Yee      | 1225323  | 43545344 | stupid@hotmail.com  |
| Cooler Co   | Cool      | Yee      | 8725323  | 43545344 | cooler@hotmail.com  |

