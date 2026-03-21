const crypto = require('crypto');

const HEADER_NAME = 'X-Correlation-Id';

const correlation = (req,res,next) => {

  let correlationId = req.get(HEADER_NAME);

  if(!correlationId) correlationId = crypto.randomUUID()

    req.correlationId = correlationId;

    res.setHeader(HEADER_NAME, correlationId);
    
    console.log(`CorrelationID ${res.get(HEADER_NAME)}`)

    next();
}

module.exports = correlation;