import Vue from 'vue'
import App from './App.vue'
import './assets/tailwind.css'
import './assets/app.scss'
import router from './router'

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
