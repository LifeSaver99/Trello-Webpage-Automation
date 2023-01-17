Feature: Trello


Scenario: Login to trello navigating through the home page
	Given I click the login button on the homepage to navigate to the login page
	When I input the username and password to login to trello
	Then the trello hompage is displayed
	
Scenario: Navigate to the "Health Corner" Boards from the workspace
	Given I click the login button on the homepage to navigate to the login page
	When I input the username and password to login to trello
	Then the trello hompage is displayed
	Then I select "ghaneva" from the workspace tab
	And the Health Corner Boards is Displayed

Scenario: Navigate to the Health Corner Boards using the search input on the HomePage
	Given I click the login button on the homepage to navigate to the login page
	When I input the username and password to login to trello
	Then the trello hompage is displayed
	Then I search for "Health Corner" in the search bar
	And the Health Corner Boards is Displayed

Scenario: Create a new workspace from the trello HomePage
	Given I click the login button on the homepage to navigate to the login page
	When I input the username and password to login to trello
	Then the trello hompage is displayed
	Then I search for "Health Corner" in the search bar
	And the Health Corner Boards is Displayed



	