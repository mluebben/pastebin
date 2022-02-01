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





const title = ref('')
const language = ref('plain')
const creationDate = ref('15.01.2022 13:45')
const expirationDate = ref('15.01.2022 13:45')
const code = ref('')

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

PasteBinApi.getPasteById(props.id).then(result => {
  console.log('show data: ', result)
  title.value = result.title
  language.value = result.language
  expirationDate.value = result.expirationDate
  code.value = result.code
})
</script>

<template>
<div class="container">
  <div class="row">
    <div class="col">
      <TextField id="title" label="Title" v-model="title" :readonly="true" />
    </div>
  </div>

  <div class="row mt-3">
    <div class="col">
      
      <!-- Nav tabs -->
      <ul class="nav nav-tabs" id="myTab" role="tablist">
        <li class="nav-item" role="presentation">
          <button class="nav-link active" id="formatted-tab" data-bs-toggle="tab" data-bs-target="#formatted" type="button" role="tab" aria-controls="home" aria-selected="true">{{ languageText }}</button>
        </li>
        <li class="nav-item" role="presentation">
          <button class="nav-link" id="raw-tab" data-bs-toggle="tab" data-bs-target="#raw" type="button" role="tab" aria-controls="profile" aria-selected="false">Raw</button>
        </li>
        <li class="nav-item" role="presentation">
          <button class="nav-link" id="meta-tab" data-bs-toggle="tab" data-bs-target="#meta" type="button" role="tab" aria-controls="profile" aria-selected="false">Metadata</button>
        </li>
      </ul>

      <!-- Tab panes -->
      <div class="tab-content">
        <div class="tab-pane active" id="formatted" role="tabpanel" aria-labelledby="formatted-tab">
          <prism-editor class="my-editor" v-model="code" :highlight="highlighter" line-numbers :readonly="true"></prism-editor>
        </div>
        <div class="tab-pane" id="raw" role="tabpanel" aria-labelledby="raw-tab">
          <form novalidate>
            <div class="form-row">
              <div class="form-group">
                <textarea class="form-control" rows="15" v-model="code"></textarea>
              </div>
            </div>
          </form>
        </div>
        <div class="tab-pane" id="meta" role="tabpanel" aria-labelledby="meta-tab">
          <form novalidate>
            <div class="form-row">
              <TextField id="title2" label="Title" v-model="title" :readonly="true" />
            </div>
            <div class="form-row">
              <TextField id="language" label="Language" v-model="languageText" :readonly="true" />
            </div>
            <div class="form-row">
              <TextField id="creationDate" label="Creation date" v-model="creationDate" :readonly="true" />
              <TextField id="expirationDate" label="Expiration date" v-model="expirationDateText" :readonly="true" />
            </div>
          </form>

        </div>
      </div>



      

    </div>
  </div>
</div>
</template>

<style scoped>

</style>
