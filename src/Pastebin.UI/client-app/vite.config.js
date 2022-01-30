import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import prismjsPlugin from 'vite-plugin-prismjs'
import path from 'path'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [
    vue(),
    prismjsPlugin({
      languages: "all"
    })
  ],
  resolve: {
    alias: {
      '@/': `${path.resolve(__dirname, 'src')}/`
    }
  },
  server: {
    hmr: {
      protocol: 'ws'
    }
  }
})
