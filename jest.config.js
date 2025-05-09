// jest.config.js
module.exports = {
  transform: {
    // use babel-jest for all .js/.jsx files
    '^.+\\.(js|jsx)$': 'babel-jest'
  },
  transformIgnorePatterns: [
    // ignore all node_modules EXCEPT axios
    'node_modules/(?!(axios)/)'
  ]
};
