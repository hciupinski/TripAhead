module.exports = {
  "/keycloak.api": {
    target: process.env["services__keycloak__http__0"],
    changeOrigin: true,
  },
  "/trips.api": {
    target: process.env["services__tripsservice__https__0"],
    pathRewrite: {
      "^/trips.api": "/api/v1",
    },
    logLevel: "debug",
    changeOrigin: false,
    secure: false,
    headers: {
      'X-Custom-Foo': 'bar'
    },
    onProxyRes: (proxyRes, req, res) => {
      proxyRes.headers['x-added'] = 'foobar';
    },
    bypass: (req, res, proxyOptions) => {
      res.setHeader('X-Header-Test', 'bacon');
    }
  },
  "/orders.api": {
    target: process.env["services__ordersservice__https__0"],
    pathRewrite: {
      "^/orders.api": "/api/v1",
    },
    changeOrigin: true,
  },
};
