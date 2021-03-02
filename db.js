


db.productos.save({
    "product_id": 1,
    "category_id": 2,
    "productname": "Xiaomi Mi10",
    "productdescription": "Celular Xiaomi Telcel",
    "vendedor_id": "Maria",
    "unitprice": 12000,
    "color": "Azul",
    "producturlpicture": "sellnow\\picture\\xiaomi_mi10.jpg",
    "productdiscount": 2,
    "productavailable": "True"
});

  
db.vendedor.save({
    "_id" : "Maria",
    "nombre" : "Maria Luisa",
    "apellido" : "Perez Lopez",
    "direccionid" : "Guest",
    "valoracion" : 4.9,
    "alias": "Zara",
    "email": "mariaza@gmail.com",
    "telefono": 6673738739,
    "password": "insane.25"
});

db.vendedor.save({
    "_id": "Luis",
    "nombre": "Luis Ramon",
    "apellido": "Perez Lopez",
    "direccion": [
        {
            "calle": "123 Fake Street",
            "ciudad": "Faketon",
            "estado": "MA",
            "codigo_postal": "12345"
        },
        {
            "calle": "1 Some Other Street",
            "ciudad": "Boston",
            "estado": "MA",
            "codigo_postal": "12345"
        }
    ],
    "valoracion": 4.5,
    "alias": "La tienda",
    "email": "luisla@gmail.com",
    "telefono": 6673438739,
    "password": "insane.25"
});

db.cliente.save({
    "cliente_id": "1",
    "nombre": "Maria Luisa",
    "apellido": "Perez Lopez",
    "direccion": "Guest",
    "email": "mariaza@gmail.com",
    "telefono": 6673738739,
    "password": "72672db3a8af4231cb7e984f6c09af3c"
})

db.pedido.save({
    "cliente_id": 1,
    "product_id": 1 ,
    "total": 450,
    "direccion": "Guest",
    "fecha": "24-11-20",
    "num_envio": "43989843",
    "pago_id": 6,
    "finalizado": false
})


