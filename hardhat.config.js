require("@nomiclabs/hardhat-waffle");
require("@nomiclabs/hardhat-ethers");
const fs = require('fs');


task("accounts", "Prints the list of accounts", async (taskArgs, hre) => {
  const accounts = await hre.ethers.getSigners();

  for (const account of accounts) {
    console.log(account.address);
  }
});

module.exports = {
  defaultNetwork: "hardhat",
  networks: {
    hardhat: {
      chainId: 1337
    },
   
    goerli: {
      url: "https://eth-goerli.g.alchemy.com/v2/lGGfOK_3i3lNDUnx4s0uRYgpYMbZSq4C",
      accounts: [ "af9c66de0ebde81d7b38885a2e40e9022fd71d736e4f3ae8008600fc919e774e" ]
    }
  },
  solidity: {
    version: "0.8.4",
    settings: {
      optimizer: {
        enabled: true,
        runs: 200
      }
    }
  }
};