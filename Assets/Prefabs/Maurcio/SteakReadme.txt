The rawmeat prefab was made to serve the purpose of being a cookable and interactable object. It has the 
sprite attached to it that indicated whether it is cooked or not. The problem it is solving is to indicate
to the player that the food is either cooked or not. 

Having a visual indicator along with a code one. It has 
the steak.cs script attached to it. It is a sublclass of the food 
super class. It has the value of the points allocated to this class along with
handling the animation for the prefab. 

It has an animator attached to it that handles the changin from cooked to raw. The raw occurs when the value `cooked` is set false. 
Then when it is changed to true it is shown visually to be cooked. 

Attached to this prefab is also a 2d box collider because that is how many of the interactions are handled. This is how it is able
to acces the oven. Because it enters the 2D circle collider of the oveninteract. When F is clicked then it is cooked with the previously
mentioned animator. It is also because this prefab has the steak tag attached to it. 