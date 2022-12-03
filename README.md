# Tecnicas

## Scroll con movimiento del fondo.

Nota: En los GIF de la solución 1 y 2, la escena no se mueve para que se pueda apreciar la diferencia de ambas.

-> Para saber cuando se debe de recolocar los fondos, tenemos que comprobar si la posición del fondo + su ancho son menores a la posición de la cámara.
-> Entonces recolocamos el fondo A hacia la posición del fondo B + el ancho de A (y viceversa)

```
if(backgroundA.transform.position.x + widthA.sprite.bounds.size.x < myCamera.transform.position.x)
  backgroundA.transform.position = new Vector3(backgroundB.transform.position.x + widthA.sprite.bounds.size.x,0,0);
else if(backgroundB.transform.position.x + widthB.sprite.bounds.size.x < myCamera.transform.position.x)
  backgroundB.transform.position = new Vector3(backgroundA.transform.position.x + widthB.sprite.bounds.size.x,0,0);
```

### Solución 1 

-> Movemos los fondos A y B, la cámara es fija

![gif](./GIF/sceneSol1.gif)

### Solución 2

-> Movemos la cámara, los fondos A y B se posicionan según el movimiento de esta.

![gif](./GIF/sceneSol2.gif)

### Solución 3

-> Para este caso usaremos un objeto de unity llamado Quad y modificaremos su textura usando "SetTextureOffset()" del componente material y según una velocidad establecida.

Nota: En el código aparece la velocidad de scroll en el eje Y, pero no la usamos.

![gif](./GIF/sceneSol3.gif)
