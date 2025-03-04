# PLANET HIGHWAYS - PROYECTO DE JUEGO EN UNITY

Repositorio que alberga el juego en Unity para la asignatura de Programación Multimedia y Dispositivos Móviles.

# INTRODUCCIÓN

## La idea del juego
La idea del juego consiste en crear una pequeña fusión entre un Mario Kart y un Mario Galaxy. Es decir, utilizar el concepto de niveles en forma de mini planetas y generar zonas de gravedad alrededor de estos. El jugador recorrería con _karts_/vehículos los circuitos planteados en los distintos planetas propuestos y estos contarían con distintas ambientaciones.

En lo que respecta a la cámara, nos gustaría que sea estática y en una posición relativamente cenital, de forma que se pueda ver parte del planeta a medida que se recorre.

## Inspiraciones
La idea de este juego surge como inspiración, como mencionábamos anteriormente, del uso de la gravedad por parte de Mario Galaxy y de la jugabilidad de Mario Kart:
           
Sin embargo, también parte de la idea de representar en un videojuego una pasión propia: los viajes. Quiero que se asemeje a A Short Hike o Celeste, es decir, que sea un juego con una estética sencilla o _low-poly_, centrado en la narrativa. Por ejemplo, en Celeste, toda la historia gira en torno al concepto de la depresión, pero en ningún momento se menciona esta, y la jugabilidad es un juego plataformas 2D.
        
En este sentido, nuestro juego se asemejaría a un _Road-Trip_, en el que nosotros somos los conductores que viajan por distintos mundos, viajando y observando nuevos paisajes.

## El motor utilizado
En este caso, hemos decidido implementar este juego a través de Unity y hacerlo en 3D. En un principio, pensamos que llevarlo a cabo en 2D, puesto que sería mucho más sencillo. Sin embargo, queríamos este componente gravitatorio y la estética _cartoon_ y de maqueta.

## Jugabilidad
La idea será generar distintos circuitos. Algunos recorrerán varios planetas, otros solo un único planeta. El desbloqueo de nuevos circuitos implicará recoger todas las monedas del nivel anterior. Por el momento, no habrá inteligencia artificial, ya que tendríamos que configurar que sean capaces de superar los circuitos, pero sería algo que nos gustaría implementar de cara al futuro, así como un sistema contrarreloj.

## Menú
Contaremos con un menú que tendrá dos opciones: jugar y opciones. El primero permitirá entrar en la sección de niveles, el segundo permitirá configurar algunas opciones del juego. Para ello, hemos pensado en los _assets_ _sci-fi_ de Kenney.

## Los _assets_

Dado que contamos con muy poco tiempo, no podemos crear nuestros propios _assets_. Así que nuestra intención ha sido buscar unos _assets_ que se adecúen a nuestro proyecto. Por ello, usaremos en primer lugar la propuesta de vehículos _low-poly_ de Kenney y también una serie de _assets_ para la decoración.

Por otra parte, generaremos una animación para el kart principal (mayormente, el movimiento de las ruedas), pero el resto de elementos serán estáticos y formarán parte del decorado.

---

# ENLACES A ASSETS Y OTROS RECURSOS

## Font utilizada

1. [Página Oficial de Fonts de Google](https://fonts.google.com/)
    - Vernon Adams - [Sigmar Font](https://fonts.google.com/specimen/Sigmar)

> [!NOTE]
> Esta _font_ ha sido utilizada para el título del juego.

## Enlaces a los _assets_

1. [Página Web Oficial de Kenney](https://kenney.nl/)
    - Kenney - [Toy Car Kit](https://kenney.nl/assets/toy-car-kit)
    - Kenney - [Holiday Kit](https://kenney.nl/assets/holiday-kit)
    - Kenney - [UI Pack Sci-Fi Kit](https://kenney.nl/assets/ui-pack-sci-fi)
    - Kenney - [Watercraft Kit](https://kenney.nl/assets/watercraft-kit)
    - Kenney - [Survival Kit](https://kenney.nl/assets/survival-kit)
    - Kenney - [Modular Buildings Kit](https://kenney.nl/assets/modular-buildings)
    - Kenney - [Space Station Kit](https://kenney.nl/assets/space-station-kit)
    - Kenney - [Space Kit](https://kenney.nl/assets/space-kit)
    - Kenney - [Graveyard Kit](https://kenney.nl/assets/graveyard-kit)
    - Kenney - [Coaster Kit](https://kenney.nl/assets/coaster-kit)
    - Kenney - [Pirate Kit](https://kenney.nl/assets/pirate-kit)
    - Kenney - [City Kit (Commercial)](https://kenney.nl/assets/city-kit-commercial)

> [!NOTE]
> La mayoría de los _assets_ de Kenney guardan mucha similitud en el estilo artístico, por lo que podemos utilizar todos estos assets y conservar un estilo concreto. Más específicamente, el estilo _low-poly_ que comentábamos en el anteproyecto.

2. [Unity Assets Store](https://assetstore.unity.com/)

    - Evgenii Nikolskii - [Planets of the Solar System 3D](https://assetstore.unity.com/packages/3d/environments/planets-of-the-solar-system-3d-90219)
    - HQP Studios - [Rocks and Terrains Pack - Low Poly](https://assetstore.unity.com/packages/3d/environments/rocks-and-terrains-pack-low-poly-281733)
    - Bitgem - [URP Stylized Water Shader - Proto Series](https://assetstore.unity.com/packages/vfx/shaders/urp-stylized-water-shader-proto-series-187485)
    - Chromisu - [Handpainted Grass & Ground Textures](https://assetstore.unity.com/packages/p/handpainted-grass-ground-textures-187634)
    - Pure Poly - [Free Low Poly Nature Forest](https://assetstore.unity.com/packages/3d/environments/landscapes/free-low-poly-nature-forest-205742)
    - Dungeon Mason - [RPG Monster Duo PBR Polyart](https://assetstore.unity.com/packages/3d/characters/creatures/rpg-monster-duo-pbr-polyart-157762)
    - MR3_2004 - [Heart in pixel](https://assetstore.unity.com/packages/2d/gui/icons/heart-in-pixel-287862)

> [!NOTE]
> La mayoría de estos assets provienen de creadores distintos. Sin embargo, también guardan una estética similar y se adecúan a las necesidades de nuestro proyecto.

3. [SketchFab](https://sketchfab.com/)

    - FunkyTownky - [Lowpoly coins](https://sketchfab.com/3d-models/lowpoly-coins-6332d4c5b2b54e38ab1f0ed932fe81ae)

> [!NOTE]
> En este caso, solo hemos utilizado un asset, pero guarda la estética similar al resto de assets utilizados.

---

## Otras herramientas

### PolyBrush
- Unity - [Make a Planet in Unity 2019 with Polybrush! (Tutorial)](https://www.youtube.com/watch?v=QHslFO0vlGg)

En este tutorial se explica cómo usar un plugin de Unity llamado _PolyBrush_ para modificar la malla del terreno de cualquier elemento. En nuestro caso, para modificar una esfera.

---

## Algunos tutoriales generales
- JudgeGroovyMan - [Unity5 - Importing Kenney.nl assets](https://www.youtube.com/watch?v=1D7Hdk-j5z8)

El tutorial anterior explica cómo importar los _assets_ de Kenney, pero es aplicable a muchos otros _assets_.

- RhomitaDev - [I made the GRAVITY of Super Mario Galaxy in 4 minutes in Unity 3D](https://www.youtube.com/watch?v=x_5pxFtDMMI)

Este tutorial explica cómo funciona la lógica de la gravedad implementada a un juego de plataformas. Nosotros lo hemos modificado y adecuado a nuestras necesidades. 

- Mike Dolan - [How To Make a Space Sim in Unity - 3D Space Sky Box Tutorial](https://www.youtube.com/watch?v=Kx-RAJ_7HTE)

En este tutorial se explica cómo crear efectos visuales sencillos. En concreto, en este caso, cómo crear estrellas de forma dinámica y también cómo modificar algunas de las propiedades de la cámara básica de Unity.

- Bitgem - [Unity URP Stylized Water Shader](https://www.youtube.com/watch?v=fHuN7WkrmsI&t)

Es el tutorial oficial de los aassets con el mismo nombre. Permite conocer en profundidad como utilizar estos shaders.

- Rigor Mortis Tortoise - [How to add Custom FONTS to Unity 2023 (Updated) | Unity Tutorial](https://www.youtube.com/watch?v=m6fJXzqfjYY)

Tutorial utilizado para importar fonts distintas a la predeterminada en Unity.

- BravePixelG - [Cómo crear un menú inicial en Unity](https://www.youtube.com/watch?v=sJUBoFgO7Ng)

Tutorial con el que añadir mayor funcionalidad al menú principal del juego.

- Rehope Games - [How to Add MUSIC and SOUND EFFECTS to a Game in Unity | Unity 2D Platformer Tutorial #16](https://www.youtube.com/watch?v=N8whM1GjH4w&t)

En este tutorial se explica cómo añadir música al juego, así como efectos de sonido y cómo utilizar un controlador de audio para separar música y SFX.

- BravePixelG - [Cómo crear un puntaje en Unity (Sistema de puntos)](https://www.youtube.com/watch?v=j_WevuGeTmg)

En este tutorial se explica como crear un sistema de puntaje sencillo.

---

# DIARIO SINTETIZADO Y OTROS ELEMENTOS DE INTERÉS

## **23 FEBRERO**
- Comienza el proyecto

## **24 FEBRERO**
- Se adapta el sistema de gravedad personalizado

## **25 FEBRERO**
- Nuevo sistema de cámara: se añade una FreeLookCamera de Cinemachine, con la que podemos rotar la cámara.

## **26-27 FEBRERO**
- Actualización del sistema de cámara: para conseguir que la cámara siguiese a nuestro personaje y respondiese a los ejes X e Y, ha sido necesario modificar las siguientes propiedades de una cámara CinemachineFreeLook:

![Propiedades cámara](/readmeimg/configCinemachineCamera.png)

- Comienza la decoración del nivel, que se realiza a mano, colocando 1 a 1 los _assets_ para proporcionar una experiencia _low-poly_ tipo maqueta en miniatura.

![Decoración a mano mostrada](/readmeimg/decorando1.png)

- Modificación de la cámara para invertir el eje Y.

## **1 MARZO**
- Modificación de las propiedades de la cámara, determinando unos grados máximos en el eje Y, para limitar las posibilidades del jugador y evitar _clipping_.

- Finalización del circuito, inclusión de meta y adición de las zonas de gravedad necesarias para la jugabilidad del circuito.

![Circuito final con zonas de gravedad](/readmeimg/circuitoCompletado.png)

## **2-3 MARZO**

- Añadido menú de inicio con varias opciones:
    - Menú de niveles
    - Menú de opciones
    - Botón de salida
- Añadido sonido y monedas al juego.

## **4 MARZO**

- Añadido sistema de puntuación.
- Añadidos assets de enemigos.
- Añadido sistema de vida y reinicio de nivel con muerte.

---

![Firma con mi nombre](/readmeimg/firma.png)