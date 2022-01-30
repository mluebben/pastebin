// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap";


import "./assets/css/style.css"

import { createApp } from 'vue'
import App from './App.vue'

import router from './router'

const app = createApp(App)
app.use(router)
app.mount('#app')
