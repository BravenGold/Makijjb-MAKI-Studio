---[CustomerController Documentation - Alex Mackimmie]---

The customer controller prefab is the brain of customer control. It manages the object 
pooling and movement logic of customer game objects. The prefab is preconfigured for the following conditions:

- 4 Customers of Any Type

Using the inspector, more customers can be added by adding more PathingV2 components to the customercontroller object!

-----------------------------------------------------------------------------------------
IMPORTANT: Make sure to bind the scripts and objects where needed in the pathing scripts!\
-----------------------------------------------------------------------------------------

For the fields customer reference and customer object, simply drag the customer object you'd like to effect into the field
---

For the field Customer Object Pool, simply drag the CustomerController into there for each PathingV2 instance.
---

For the field Path Points, simply add gameobjects in a list to specify the path you'd like the customer to follow!
The customer will follow in the order they are listed, so double check the order!
---

For the Customer Object Pool script, specify a list of the customer objects in reverse order from how they are
listed in the pathing scripts. For example, if customer 1 is the first customer I add in a pathing script, then customer 1
should be the last customer added to the Customer Object Pool script. [DOUBLE CHECK THIS!]

-----------------------------------------------------------------------------------------
As long as everything is hooked up to game objects and scripts properly, all that is required is node positions to be configured
and boom! Customers should move and interact as intended.
-----------------------------------------------------------------------------------------