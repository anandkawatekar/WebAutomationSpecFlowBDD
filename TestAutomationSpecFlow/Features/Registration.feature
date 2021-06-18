Feature: User Registeration

Scenario Outline: Register on the Website
Given A user is on authentication page
When User begins to create account by entering email address
And User enters personal information on create account page
And clicks on Register button
Then I validate user account is created successfully


Scenario Outline: Create Account by entering email address
Given A user is on authentication page
When User begins to create account by entering email address
Then User should redirect to create account page
