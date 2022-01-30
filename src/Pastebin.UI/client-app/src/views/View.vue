<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script setup lang="ts">

// Import Prism Editor	
import { PrismEditor } from 'vue-prism-editor'
import 'vue-prism-editor/dist/prismeditor.min.css' // import the styles somewhere

import { highlight, languages } from '../prism/index.js'
import { ref, computed } from 'vue'

import PasteBinApi from '../api/pastebinapi'


import TextField from '../components/controls/TextField.vue'



const props = defineProps({
  id: String
})

console.log('id: ', props.id)


console.log('After Imports')

const language = ref('plain')
const expirationDate = ref('15.01.2022 13:45')
const code = ref('Some code in here')

const expirationDateText = computed(() => expirationDate.value ? expirationDate.value : 'Never')


const languageText = computed(() => {
  const item = languages.find(x => x.value === language.value)
  if (!item) {
    return 'Unknown';
  }

  return item.label
})


const highlighter = function(code) {
  return highlight(code, language.value)
}


console.log('Trying to get data')



PasteBinApi.getPasteById(props.id).then(result => {
  console.log('show data: ', result)
  language.value = result.language
  expirationDate.value = result.expirationDate
  code.value = result.code
})




console.log('Setup ended')

</script>

<template>
<div class="container">
  <div class="row">
    <div class="col">
      <TextField id="language" label="Language" v-model="languageText" :readonly="true" />
    </div>
    <div class="col">
      <TextField id="expirationDate" label="Expiration date" v-model="expirationDateText" :readonly="true" />
    </div>
  </div>
  <div class="row">
    <div class="col">
      
      <label>Code</label>
      <prism-editor class="my-editor" v-model="code" :highlight="highlighter" line-numbers :readonly="true"></prism-editor>
      

      <label>Raw</label>
      <pre v-html="code"></pre>

    </div>
  </div>
</div>
</template>

<style scoped>

</style>
