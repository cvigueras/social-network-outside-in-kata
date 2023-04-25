# Social Network
TODO

# Posting

Given: 

- Alice posted 'Hello everyone' a message on 18/04/2023 at 14:35 p.m.
- Alice posted 'I'm new user' a message on 18/04/2023 at 14:38 p.m.
- Alice posted 'Hello world' a message on 18/04/2023 at 14:48 p.m.
 
When:

 When the user asks for Alice's timeline.

Then:

The timeline appears with the following messages:

- 18/04/2023 14:48 Alice => Hello world.
- 18/04/2023 14:38 Alice => I'm new user.
- 18/04/2023 14:35 Alice => Hello everyone.

# Following

Given: 

- Bob posted 'Hello I'm Bob' a menssage on 18/04/2023 at 14:35 p.m.
- Alice posted 'Hello I'm Alice' a menssage on 18/04/2023 at 14:38 p.m.
- Charlie posted 'Hello I'm Charlie' a message on 18/04/2023 at 14:48 p.m.
- Charlie has subscribed to Alice
- Charlie has subscribed to Bob
 
When:

Charlie asks to see his wall.

Then:

The following list of messages appears:

- 18/04/2023 14:48 Charlie => Hello I'm Charlie.
- 18/04/2023 14:38 Alice => Hello I'm Alice.
- 18/04/2023 14:35 Bob => Hello I'm Bob.