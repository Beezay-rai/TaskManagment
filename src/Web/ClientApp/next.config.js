const { loadComponents } = require("next/dist/server/load-components");

const nextconfig = {
  reactStrictMode: true,
  devIndicators: {
    buildActivity: false,
    
  },
};

module.exports = nextconfig;
