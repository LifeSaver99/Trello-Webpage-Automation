Feature: Trello


Scenario: Login to trello navigating through the home page
	Given I click the login button on the homepage to navigate to the login page
	When I login as user
	
Scenario: Navigate to the "Health Corner" Boards from the workspace
	Given I click the login button on the homepage to navigate to the login page
	When I login as user
	Then I select "ghaneva" from the workspace tab
	And the Health Corner Boards is Displayed

Scenario: Navigate to the Health Corner Boards using the search input on the HomePage
	Given I click the login button on the homepage to navigate to the login page
	When I login as user
	Then I search for "Health Corner" in the search bar
	And the Health Corner Boards is Displayed

Scenario: Create a new workspace from the trello HomePage
	Given I click the login button on the homepage to navigate to the login page
	When I login as user
	And I click the create new worrkspace button
	And Input "My Workspace4" as the workspace name
	And I Input the WorkSPace type
	And I submit the new Workspace created
	Then I verify "My Workspace4" is displayed in workspaces

Scenario: Validate Test fails at white space input in Email Input
	Given I click the login button
	When I login as invalid user
	Then the trello dashboard is displayed



	