const orders = [
  {     id: 1,      receiver: 'Neo',             address: 'Matrix City, Virtual World',      item: 'Blue Pill',              price: '5$'  },
  {     id: 2,      receiver: 'Harry Potter',    address: 'Hogwarts Castle, Scotland',       item: 'Chocolate Frog',         price: '10$'  },
  {     id: 3,      receiver: 'Gollum',          address: 'Misty Mountains, Middle-earth',   item: 'Precious Ring Snack',    price: '1 000 000$'  },
  {     id: 4,      receiver: 'Marty McFly',     address: 'Hill Valley, California, USA',    item: 'Pepsi Free',             price: '3$'  }
];

exports.createOrderAsync = async (orderCreateDto)=>{
    const newOrder = {
        id: orders.length + 1,
        receiver: orderCreateDto.receiver,
        address: orderCreateDto.address, 
        item: orderCreateDto.item, 
        price: orderCreateDto.price          
    }

    orders.push(newOrder)
    return newOrder
}

exports.getOrdersAsync = async () => {
    return orders
} 