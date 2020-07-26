// vue.config.js

// eslint-disable-next-line @typescript-eslint/no-var-requires
const CopyWebpackPlugin = require('copy-webpack-plugin')
module.exports = {
//  outputDir: 'wwwroot',
  filenameHashing: false,
  // productionSourceMap: false,
  configureWebpack: {
    plugins: [
      new CopyWebpackPlugin([
        { from: 'node_modules/oidc-client/dist/oidc-client.min.js', to: 'js' },
        { from: 'public/callback.html', to: '' },
        { from: 'public/silent-renew.html', to: '' },
        { from: 'public/favicon.ico', to: '' }
      ])
    ]
  },
  pages: {
    index: {
      entry: 'src/main.ts',
      template: 'public/index.html'
    }
  }
}
