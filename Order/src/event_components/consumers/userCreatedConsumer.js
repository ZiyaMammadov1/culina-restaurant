const { connectCloud } = require ('../config/cloud_amqp')

async function consumeUserCreated(){
    const channel = await connectCloud();

    // const exchange = "UserCreatedIntegrationEvent"
    const exchange = "AuthService.Application.IntegrationEvents:UserCreatedIntegrationEvent"
    await channel.assertExchange(exchange, "fanout", { durable: true });

    const queue = await channel.assertQueue("", { exclusive: true })
    await channel.bindQueue(queue.queue, exchange, "")

    console.log(`${queue.queue, exchange}`)

    channel.consume(queue.queue, (message) => {
        console.log('test ucun 2')
         const payload = JSON.parse(message.content.toString());

        const user = payload.message;
        console.log("User created:", user.userId, user.username, user.email, user.occurredOn);
        channel.ack(message)
    })
}

module.exports = { consumeUserCreated } 