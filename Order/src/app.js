const express = require('express');
const app = express();
app.use(express.json())




const order_route = require('./routes/order.routes')
app.use('/',order_route)


const correlationIdHandler = require('./middlewares/correlation.Middleware')
app.use(correlationIdHandler)

const globalHandler = require('./middlewares/globalExceptionHandler.Middleware')
app.use(globalHandler)





app.use((req, res, next) => {
    res.status(404).json({ message: 'Not Found' });
});


const { connectCloud } = require('./event_components/config/cloud_amqp');
const { consumeUserCreated } = require('./event_components/consumers/userCreatedConsumer');

async function startConsumers() {
  await connectCloud();
  await consumeUserCreated();
}

startConsumers();

module.exports = app;
