const orderService = require('../services/order.services')


exports.createNewOrder = async (req, res)=>{
    const orderCreateDto = req.body
    const order = await orderService.createOrderAsync(orderCreateDto)
    res.json(order)
}

exports.getOrdersAsync = async (req, res)=>{
    const orders = await orderService.getOrdersAsync()
    res.json(orders)
}