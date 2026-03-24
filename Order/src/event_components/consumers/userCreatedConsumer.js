const {getChannel} = require ('../config/cloud_amqp')

async function consumeUserCreated(){
    const channel = getChannel();

    const exchange = "UserCreatedIntegrationEvent"
    await channel.assertExchange(exchange, "fanout", { durable: true });

    const queue = await channel.assertQueue("", { exclusive: true })
    await channel.bindQueue(queue.queue, exchange, "")

    channel.consume(queue.queue, (message) => {
        const data = JSON.parse(message.content.toString())
        console.log(data)
        channel.ack(message)
    })
}

module.exports = { consumeUserCreated } 