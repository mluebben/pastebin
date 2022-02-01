<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script setup>
// Import Prism Editor	
import { PrismEditor } from 'vue-prism-editor'
import 'vue-prism-editor/dist/prismeditor.min.css' // import the styles somewhere

import { highlight, languages } from '../prism/index.js'
import { ref } from 'vue'

import PasteBinApi from '@/api/pastebinapi'

import router from '@/router'

import Button from '@/components/controls/Button.vue'
import TextField from '@/components/controls/TextField.vue'
import SelectField from '@/components/controls/SelectField.vue'

const title = ref('')
const language = ref('clike')
const retention = ref('0')
const code = ref('')

const highlighter = function(code) {
  return highlight(code, language.value)
}

const submit = async function() {
  const result = await PasteBinApi.post({
    title: title.value,
    retention: retention.value,
    language: language.value,
    code: code.value,
  })

  const id = result.id
  router.push({ name: 'view', params: { id: id } })
}

const languageItems = ref(languages)
const retentionItems = ref([
  { value: "0", label: "Forever" },
  { value: "1", label: "1 day" },
  { value: "30", label: "30 days" },
  { value: "360", label: "360 days" }
])
</script>

<template>
<div class="container">
  <div class="row">
    <div class="col">
      <TextField id="title" label="Title" v-model="title" />
    </div>
  </div>
  <div class="row">
    <div class="col">
      <SelectField id="language" label="Language" v-model="language" :items="languageItems" />
    </div>
    <div class="col">
      <SelectField id="retention" label="Retention" v-model="retention" :items="retentionItems" />
    </div>
  </div>
  <div class="row">
    <label>Code</label>
  </div>
  <div class="row">
    <div class="col">
      <prism-editor class="my-editor form-control" v-model="code" :highlight="highlighter" line-numbers placeholder="Paste content here ..."></prism-editor>
    </div>
  </div>
  <div class="row">
    <div class="col">
      <Button class="btn-primary" @click="submit">Submit</button>
    </div>
  </div>
</div>
</template>

<style scoped>
.my-editor {
  border: 1px solid #ced4da;
  border-radius: 0.25em;;
  min-height: 100px;
}
</style>
