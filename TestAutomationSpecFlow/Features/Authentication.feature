Feature: Authentication functionality

Scenario Outline: Click Signin on the landing page - Should redirect to Authentication Page
Given A user is on landing page
When User clicks Sign in on landing page
Then Should redirect to Authentication Page

Scenario Outline: Should sign in successfully
Given A user is on authentication page
When User logs in with <username> and <password>
Then User should log in successfully
Examples:
| username                | password  |
| login1234test@gmail.com | Test@1234 |


Scenario Outline: Logout and login again
Given A user is on authentication page
And User logs in with <username> and <password>
When User logs out
And Login again with <username> and <password>
Then User should log in successfully
Examples:
| username                | password  |
| login1234test@gmail.com | Test@1234 |

Scenario Outline: validate on the landing screen - correct name and surname is displayed
Given A user is on authentication page
When User logs in with <username> and <password>
Then I validate on the landing screen - correct <name> and <surname> is displayed
Examples:
| username                | password  | name | surname |
| login1234test@gmail.com | Test@1234 | tstf | tstl    |