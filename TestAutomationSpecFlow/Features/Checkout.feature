Feature: Checkout

Scenario Outline: Add product to the cart
	Given The user has opened product with <productId> on product details page
	When User adds product to the cart
	Then the user sees a confirmation panel that the product has been added
Examples: 
	| productId |
	| 1         |

Scenario Outline: Validate on the payments page if the product details are correct
	Given The user has opened product with <productId> on product details page
	When User adds product to the cart and proceed to checkout
	And Continue to sign in
	And User logs in with <username> and <password>
	And Continue to shipping page
	And User clicks terms of ervices
	And Continue to payment page
	Then I validate product details <productName> and <unitPrice> are correct
Examples: 
	| username                | password  | productId | productName                 | unitPrice |
	| login1234test@gmail.com | Test@1234 | 1         | Faded Short Sleeve T-shirts | 16.51     |