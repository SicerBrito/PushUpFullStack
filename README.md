# PushUpFullStack
Realizare la prueba FullStack de la estapa PushUp

# Descripción del Proyecto:
La empresa Adidas desea construir un sitio web que permita ofrecer todos sus implementos
deportivos. Este sistema se dividirá en dos partes: una aplicación web y una base de datos. La
aplicación web permitirá a los usuarios realizar compras, gestionar su cuenta y buscar productos. La
base de datos almacenará la información de los productos, los clientes y las transacciones.

1. Tabla de productos: 
    - ID del producto
    - Nombre del producto 
    - Descripción del producto 
    - Precio del producto 
    - Categoría del producto 
    - Disponibilidad del producto	tinyint	Estado de disponibilidad del producto (1 = disponible, 0 = no disponible)
    - Imagen del producto	blob (URL Imagen del producto)
    - Stock disponible

    ---

2. Tabla de clientes: 
    - ID del cliente
    - Nombre del cliente 
    - Dirección del cliente 
    - Información de contacto (teléfono, correo electrónico, etc.) 
    - Fecha de registro del cliente
    - Estado del cliente	tinyint	Estado del cliente (1 = activo, 0 = inactivo, -1 = bloqueado)

    ---

3. Tabla de transacciones: 
    - ID de la transacción
    - ID del cliente
    - Fecha de la transacción 
    - Productos comprados (puede ser una lista de IDs de productos o una tabla de detalles de productos comprados) 
    - Total de la transacción 
    - Método de pago

    ---


4. Tabla de categorías de productos: 
    - ID de categoría 
    - Nombre de categoría 
    - Descripción de categoría 

    ---


5. Tabla de carrito de compras:  (Esta tabla permitirá organizar los productos en diferentes categorías, lo que facilitará la búsqueda y navegación de los usuarios en el sitio web. )
    - ID de carrito 
    - ID del cliente
    - Lista de productos en el carrito (puede ser una lista de IDs de productos o una tabla de detalles de productos en el carrito) 
    - Cantidad de cada producto en el carrito	int	Cantidad de cada producto en el carrito de compras

    ---


6. Tabla de detalles de productos: (Esta tabla ayudará a mantener un seguimiento de los productos que los clientes agregan a su carrito de compras antes de finalizar la compra. )
    - ID de detalle 
    - ID del producto
    - Detalles adicionales del producto (color, tamaño, material, etc.) 

    ---
