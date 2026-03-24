class userCreatedEvent{
    constructor(userId, username, email, occuredOn){
        this.userId = userId,
        this.username = username,
        this.email = email,
        this.occuredOn = occuredOn
    }
}

module.exports = { UserCreatedEvent };