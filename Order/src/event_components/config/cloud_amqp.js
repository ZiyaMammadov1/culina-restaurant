const amqp = require('amqplib')

let channel;

async function connectCloud(){
    const destination = await amqp.connect('amqps://dzrptgjw:WnlWhWO5E1qcYcGN_Bsvq_Kg2qnjliiZ@fuji.lmq.cloudamqp.com/dzrptgjw')
    channel = await destination.createChannel()
    if (!channel) throw new Error("RabbitMQ channel is not initialized");
    return channel;
}

module.exports = { connectCloud }