# API_REST_PALINDROMOS

Permite consultar si una palabra es un palíndromo a partir de un diccionario, cada vez que se realice una consulta,si la palabra no existe, deberá agregarse al diccionario. Adicional la API permite agregar palabras y eliminarlas así como consultar una lista de todas las palabras existentes.

Para listar las palabras existentes, se deberá hacer una solicitud GET de la forma siguiente: /api/Palabras (ejemplo local: http://localhost:57814/api/Palabras).

Para consultar si una palabra es palíndromo y agregarla al diccionario, se debe realizar una solicitud POST: /api/Palabras , enviando en el cuerpo de la solicitud la palabra en JSON como el siguiente ejemplo: {Palabra1:"Arenera"}.

Para eliminar una palabra del diccionario, se debe realizar una solicitud DELETE añadiendo el id de la palabra: /api/Palabras/id (ejemplo local: http://localhost:57814/api/Palabras/3).
