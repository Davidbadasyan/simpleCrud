/**
 * main.ts
 *
 * Bootstraps Vuetify and other plugins then mounts the App`
 */

// Components
import App from './App.vue'

// Composables
import { createApp, markRaw } from 'vue'

import { createPinia, setActivePinia } from "pinia";
import VCalendar from "v-calendar";

import router from "./router";
import "v-calendar/dist/style.css";


// Plugins
import { registerPlugins } from '@/plugins'

const app = createApp(App)

const pinia = createPinia()
pinia.use(({ store }) => {
store.router = markRaw(router)
})
setActivePinia(pinia);

registerPlugins(app)

app.use(VCalendar, {});
app.use(pinia)
app.mount('#app')
