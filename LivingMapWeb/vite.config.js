import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import basicSsl from '@vitejs/plugin-basic-ssl'

// https를 기본으로 사용하도록 변경해줘

// https://vitejs.dev/config/
export default defineConfig({
  server: {
    https: true
  },
  
  plugins: [
    vue(),
    basicSsl({
      /** name of certification */
      name: 'test',
      /** custom trust domains */
      domains: ['localhost:5173'],
      /** custom certification directory */
      certDir: '/Users/.../.devServer/cert'
    })
  ],
})
