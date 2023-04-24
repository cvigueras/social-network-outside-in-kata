# Social Network
TODO

# Posting

Dado: 

- Alice posteó 'Hola a todos' un mensaje el 18/04/2023 a las 14:35
- Alice posteó 'Soy usuario nuevo' un mensaje el 18/04/2023 a las 14:38
- Alice posteó 'Hola mundo' un mensaje el 18/04/2023 a las 14:48
 
Cuando:

 Cuando el usuario pide el timeline de Alice.

Entonces:

Aparece el timeline con los siguientes mensajes:

- 18/04/2023 14:48 Alice => Hola mundo.
- 18/04/2023 14:38 Alice => Soy usuario nuevo.
- 18/04/2023 14:35 Alice => Hola a todos.

# Following

Dado: 

- Bob posteó 'Hola soy Bob' un mensaje el 18/04/2023 a las 14:35
- Alice posteó 'Hola soy Alice' un mensaje el 18/04/2023 a las 14:38
- Charlie posteó 'Hola soy Charlie' un mensaje el 18/04/2023 a las 14:48
- Charlie se ha suscrito a Alice
- Charlie se ha suscrito a Bob
 
Cuando:

Charlie pide ver su wall

Entonces:

Aparece la siguiente lista de mensajes:
- 18/04/2023 14:48 Charlie => Hola soy Charlie.
- 18/04/2023 14:38 Alice => Hola soy Alice.
- 18/04/2023 14:35 Bob => Hola soy Bob.
