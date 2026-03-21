const express = require('express')
const route = express.Router();

const {createNewOrder, getOrdersAsync} = require('../controllers/order.controllers')

route.post('/orders', createNewOrder)
route.get('/orders', getOrdersAsync)

module.exports = route;