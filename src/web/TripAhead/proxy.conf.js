module.exports = {
  "/trips.api": {
    target: process.env["services__tripsservice__http__0"],
    pathRewrite: {
      "^/trips.api": "/api/v1",
    },
  },
  "/orders.api": {
    target: process.env["services__ordersservice__http__0"],
    pathRewrite: {
      "^/orders.api": "/api/v1",
    },
  },
};