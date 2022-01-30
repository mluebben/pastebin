<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script setup lang="ts">

// Import Prism Editor	
//import { PrismEditor } from 'vue-prism-editor'
//import 'vue-prism-editor/dist/prismeditor.min.css' // import the styles somewhere

//import { highlight, languages } from '../prism/index.js'
//import { ref, computed } from 'vue'








//const highlighter = function(code) {
//  return highlight(code, language.value)
//}


</script>

<template>
<div class="container">
  <div class="row">
    <div class="col">
      <h1>API Specification</h1>
    </div>
  </div>
  <div class="row">
    <div class="col">
      
      <p>Make a HTTP POST request to the endpoint /api/pastes with the following JSON inside the request body</p>
      <p>Content-Type must be application/json</p>
      <pre>
{
"title":"test",
"language": "clike",
"code": "hallo welt",
"retention": 1
}
      </pre>
      

    </div>
  </div>
</div>
</template>

<style scoped>

</style>
