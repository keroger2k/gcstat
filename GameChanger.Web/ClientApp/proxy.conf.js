const { env } = require('process');

/* API Url */
const target = 'http://localhost:5188';

const PROXY_CONFIG = [
  {
    context: [
      "/api/search",
      "/api/team",
    ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
